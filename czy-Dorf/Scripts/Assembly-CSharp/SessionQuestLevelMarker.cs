using UnityEngine;
using UnityEngine.UI;

public class SessionQuestLevelMarker : MonoBehaviour
{
	private sealed class _003C_003Ec__DisplayClass7_0
	{
		public SessionQuestMenuCard sessionQuestMenuCard;

		public int levelIndex;

		internal void _003CSetup_003Eb__0()
		{
			sessionQuestMenuCard.ShowLevel(levelIndex);
		}
	}

	[SerializeField]
	private Button button;

	[SerializeField]
	private Image image;

	[SerializeField]
	private Image outline;

	[SerializeField]
	private Color completedColor;

	[SerializeField]
	private Color normalColor;

	private int levelIndex;

	private SessionQuestMenuCard sessionQuestMenuCard;

	public void Setup(SessionQuestMenuCard sessionQuestMenuCard, int levelIndex)
	{
		_003C_003Ec__DisplayClass7_0 CS_0024_003C_003E8__locals6 = new _003C_003Ec__DisplayClass7_0();
		CS_0024_003C_003E8__locals6.sessionQuestMenuCard = sessionQuestMenuCard;
		CS_0024_003C_003E8__locals6.levelIndex = levelIndex;
		this.sessionQuestMenuCard = CS_0024_003C_003E8__locals6.sessionQuestMenuCard;
		this.levelIndex = CS_0024_003C_003E8__locals6.levelIndex;
		button.onClick.AddListener(delegate
		{
			CS_0024_003C_003E8__locals6.sessionQuestMenuCard.ShowLevel(CS_0024_003C_003E8__locals6.levelIndex);
		});
		UpdateState();
	}

	public void UpdateState()
	{
		RewardState levelState = sessionQuestMenuCard.SessionQuest.GetLevelState(levelIndex);
		button.interactable = levelState != RewardState.Hidden;
		image.color = ((levelState == RewardState.Completed) ? completedColor : normalColor);
	}

	public void Activate(bool newShow)
	{
		outline.gameObject.SetActive(newShow);
	}
}
