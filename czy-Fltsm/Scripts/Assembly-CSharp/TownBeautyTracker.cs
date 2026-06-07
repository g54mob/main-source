using TMPro;
using UnityEngine;

public class TownBeautyTracker : SceneBehaviour
{
	[SerializeField]
	private TextMeshProUGUI _textField;

	private void Start()
	{
		Community.PlayerCommunity.BeautyScoreUpdated += UpdateBeautyScore;
		UpdateBeautyScore();
	}

	private void OnDestroy()
	{
		Community.PlayerCommunity.BeautyScoreUpdated -= UpdateBeautyScore;
	}

	private void UpdateBeautyScore()
	{
		_textField.text = Community.PlayerCommunity.BeautyScore.ToString();
	}
}
