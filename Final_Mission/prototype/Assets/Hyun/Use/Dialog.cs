using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class Dialog : MonoBehaviour
{
    // Use this for initialization
    private Text _textComponent;

    public string[] DialogueStrings;

    public float SecondsBetweenCharacters = 0.15f;
    public float CharacterRateMultuplier = 0.5f;

    public KeyCode DialogueInput = KeyCode.Return;
    private bool _isStringBeingRevealed = false;
    private bool _isDialoguePlaying = false;
    private bool _isEndofDialogue = false;

    public GameObject ContinueIcon;
    public GameObject StopIcon;

    void Start()
    {
        _textComponent = GetComponent<Text>();
        _textComponent.text = "";

        HideIcons();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (!_isStringBeingRevealed)
            {
                _isDialoguePlaying = true;
                StartCoroutine(StartDialogue());
            }
        }
    }
    private IEnumerator StartDialogue()
    {
        int dialogueLengh = DialogueStrings.Length;
        int currentDialogueIndex = 0;
        while (currentDialogueIndex < dialogueLengh || !_isStringBeingRevealed)
        {
            if (!_isStringBeingRevealed)
            {
                _isStringBeingRevealed = true;
                StartCoroutine(DisplatStrings(DialogueStrings[currentDialogueIndex++]));

                if (currentDialogueIndex >= dialogueLengh)
                    _isEndofDialogue = true;
            }
            yield return 0;
        }
        while (true)
        {
            if (Input.GetKeyDown(DialogueInput)) break;
            yield return 0;
        }
        HideIcons();
        _isEndofDialogue = false;
        _isDialoguePlaying = false;
    }
    private IEnumerator DisplatStrings(string stringToDisplay)
    {
        int stringLength = stringToDisplay.Length;
        int currentCaracterIndex = 0;
        HideIcons();
        _textComponent.text = "";
        while (currentCaracterIndex < stringLength)
        {
            _textComponent.text += stringToDisplay[currentCaracterIndex];
            currentCaracterIndex++;
            if (currentCaracterIndex < stringLength)
            {
                if (Input.GetKey(DialogueInput))
                {

                    yield return new WaitForSeconds(SecondsBetweenCharacters*CharacterRateMultuplier);
                }
                else
                {
                    yield return new WaitForSeconds(SecondsBetweenCharacters);
                }
            }
            else break;
        }
        ShowIcon();
        while (true)
        {
            if (Input.GetKeyDown(DialogueInput)) break;

            yield return 0;
        }
        HideIcons();
        _isStringBeingRevealed = false;
        _textComponent.text = "";
    }
    private void HideIcons()
    {
        ContinueIcon.SetActive(false);
        StopIcon.SetActive(false);
    }
    private void ShowIcon()
    {
        if (_isEndofDialogue)
        {
            StopIcon.SetActive(true);
            return;
        }
        ContinueIcon.SetActive(true);
    }
}
