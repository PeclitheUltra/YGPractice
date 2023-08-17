using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;

public class ScoreDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private Game _game;
    private Regex _regex = new Regex("[0-9]+");
    
    private void Start()
    {
        _game.Scored += UpdateText;
    }

    private void UpdateText()
    {
        _text.text = _regex.Replace(_text.text, _game.Score.ToString());
    }
}
