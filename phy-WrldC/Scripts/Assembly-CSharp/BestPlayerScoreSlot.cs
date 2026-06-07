using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BestPlayerScoreSlot : MonoBehaviour
{
	private TextMeshProUGUI userRankText;

	private TextMeshProUGUI userNameText;

	private TextMeshProUGUI userGoldMedalsText;

	private TextMeshProUGUI userSilverMedalsText;

	private TextMeshProUGUI userBronzeMedalsText;

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
			userGoldMedalsText = base.transform.FindComponent<TextMeshProUGUI>("UserGoldMedalsText", isRecursively: true);
			userSilverMedalsText = base.transform.FindComponent<TextMeshProUGUI>("UserSilverMedalsText", isRecursively: true);
			userBronzeMedalsText = base.transform.FindComponent<TextMeshProUGUI>("UserBronzeMedalsText", isRecursively: true);
			userScoreText = base.transform.FindComponent<TextMeshProUGUI>("UserScoreText", isRecursively: true);
			userProfileImage = base.transform.FindComponent<RawImage>("UserProfileImage", isRecursively: true);
			userGenericProfileImage = base.transform.FindComponent<Image>("UserGenericProfileImage", isRecursively: true);
			isAlreadyInitialize = true;
		}
	}

	public void SetInfos(int rank, string name, int score, int goldMedal, int silverMedal, int bronzeMedal, bool isCurrentUser)
	{
		string text = (isCurrentUser ? "F7EC3D" : "FFFFFF");
		userRankText.SetText($"<color=#{text}>{rank}</color>");
		userNameText.SetText("<color=#" + text + ">" + name + "</color>");
		userGoldMedalsText.SetText($"\uf013 {goldMedal}");
		userSilverMedalsText.SetText($"\uf013 {silverMedal}");
		userBronzeMedalsText.SetText($"\uf013 {bronzeMedal}");
		userScoreText.SetText(score.ToString());
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
