using TMPro;
using UnityEngine;

public class LeaderboardEntry : MonoBehaviour
{
	[SerializeField]
	private TextMeshProUGUI rankText;

	[SerializeField]
	private TextMeshProUGUI playerNameText;

	[SerializeField]
	private TextMeshProUGUI timeText;

	public void Setup(int rank, string playerName, string timeText)
	{
		rankText.text = "#" + rank;
		playerNameText.text = playerName;
		this.timeText.text = timeText;
	}
}
