using TMPro;
using UnityEngine;

public class ScoreTag : MonoBehaviour
{
	public GameObject highlight;

	public TMP_Text rank;

	public TMP_Text username;

	public TMP_Text score;

	public void SetNameAndScore(string _name, int _score, int _rank, bool isPlayer)
	{
		highlight.SetActive(isPlayer);
		rank.text = _rank + ".";
		username.text = _name;
		score.text = _score.ToString();
	}
}
