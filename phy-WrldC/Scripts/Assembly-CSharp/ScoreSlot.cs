using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreSlot : MonoBehaviour
{
	private TextMeshProUGUI userRankText;

	private TextMeshProUGUI userNameText;

	private TextMeshProUGUI userDifficultText;

	private TextMeshProUGUI userDetailsText;

	private TextMeshProUGUI userScoreText;

	private RawImage userProfileImage;

	private Image userGenericProfileImage;

	private bool isAlreadyInitialize;

	public void Initialize()
	{
		if (!isAlreadyInitialize)
		{
			userRankText = base.transform.FindComponent<TextMeshProUGUI>("UserRankText", isRecursively: true);
			userNameText = base.transform.FindComponent<TextMeshProUGUI>("UserNameText", isRecursively: true);
			userDifficultText = base.transform.FindComponent<TextMeshProUGUI>("UserDifficultText", isRecursively: true);
			userDetailsText = base.transform.FindComponent<TextMeshProUGUI>("UserDetailsText", isRecursively: true);
			userScoreText = base.transform.FindComponent<TextMeshProUGUI>("UserScoreText", isRecursively: true);
			userProfileImage = base.transform.FindComponent<RawImage>("UserProfileImage", isRecursively: true);
			userGenericProfileImage = base.transform.FindComponent<Image>("UserGenericProfileImage", isRecursively: true);
			isAlreadyInitialize = true;
		}
	}

	public void SetInfos(string rank, string name, int score, LeaderboardType leaderboardType, int[] details, bool isCurrentUser)
	{
		if (details.Length >= 5)
		{
			string text = (isCurrentUser ? "F7EC3D" : "FFFFFF");
			userRankText.SetText("<color=#" + text + ">" + rank + "</color>");
			userNameText.SetText("<color=#" + text + ">" + name + "</color>");
			string sourceText = "";
			switch (details[4])
			{
			case 0:
				sourceText = "<color=#F7EC3D4D>\uf006</color><color=#7878784D>\uf006</color>";
				break;
			case 1:
				sourceText = "<color=#F7EC3D4D>\uf006</color><color=#787878>\uf005</color>";
				break;
			case 2:
				sourceText = "<color=#F7EC3D>\uf005</color><color=#7878784D>\uf006</color>";
				break;
			case 3:
				sourceText = "<color=#F7EC3D>\uf005</color><color=#787878>\uf005</color>";
				break;
			}
			userDifficultText.SetText(sourceText);
			string sourceText2 = "";
			string sourceText3 = "";
			string text2 = Util.TimeParser((float)details[0] / 1000f);
			string text3 = details[1].ToString();
			string text4 = details[2].ToString();
			string text5 = ((float)details[3] / 100f).ToString();
			switch (leaderboardType)
			{
			case LeaderboardType.Time:
				sourceText2 = "\uf0eb  " + text4 + "\n\uf1b3  " + text3 + "  \ue908  " + text5;
				sourceText3 = "<color=#8998DF>\uf017  " + Util.TimeParser((float)score / 1000f) + "</color>";
				break;
			case LeaderboardType.Blocks:
				sourceText2 = "\uf017  " + text2 + "\n\uf0eb  " + text4 + "  \ue908  " + text5;
				sourceText3 = $"<color=#FFFFFF>\uf1b3  {score}</color>";
				break;
			case LeaderboardType.Cost:
				sourceText2 = "\uf017  " + text2 + "\n\uf1b3  " + text3 + "  \ue908  " + text5;
				sourceText3 = $"<color=#F7EC3D>\uf0eb  {score}</color>";
				break;
			case LeaderboardType.Weight:
				sourceText2 = "\uf017  " + text2 + "\n\uf1b3  " + text3 + "  \uf0eb  " + text4;
				sourceText3 = $"<color=#8998DF>\ue908  {(float)score / 100f:0.00}</color>";
				break;
			}
			userDetailsText.SetText(sourceText2);
			userScoreText.SetText(sourceText3);
		}
	}

	public void SetProfileImage(Texture2D texture2D)
	{
		if (texture2D == null)
		{
			userProfileImage.gameObject.SetActive(value: false);
			userGenericProfileImage.gameObject.SetActive(value: true);
		}
		else
		{
			userGenericProfileImage.gameObject.SetActive(value: false);
			userProfileImage.gameObject.SetActive(value: true);
			userProfileImage.texture = texture2D;
		}
	}
}
