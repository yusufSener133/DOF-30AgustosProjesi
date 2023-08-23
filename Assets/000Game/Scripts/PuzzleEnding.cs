using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PuzzleEnding : MonoBehaviour
{
    [SerializeField] private Button _endingButton;
    [SerializeField] private TMP_Text _endingText;
    [SerializeField, TextArea] private string _endingMessage;
    [SerializeField] private float _textSpeed = .1f;

    private void OnEnable()
    {
        _endingButton.interactable = false;
        StartCoroutine(StartingText());
    }
    IEnumerator StartingText()
    {
        _endingText.text = "";
        foreach (var item in _endingMessage)
        {
            _endingText.text += item;
            yield return new WaitForSeconds(_textSpeed);
        }
        _endingButton.interactable = true;
    }
}/**/
