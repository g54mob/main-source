using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AchievementInstanceController : MonoBehaviour
{
	[SerializeField]
	private Image checkmark;

	[SerializeField]
	private Transform completeLine;

	[SerializeField]
	private TextLabelController achievementName;

	[SerializeField]
	private TextLabelController achievementDesc;

	public void SetAchievementData(string ach_name, string ach_description)
	{
		achievementName.SetLabel(ach_name);
		achievementDesc.SetLabel(ach_description);
	}

	public void QuickUnlockAchievement()
	{
		checkmark.enabled = true;
		completeLine.transform.localScale = Vector3.one;
		achievementName.gameObject.GetComponent<TextMeshProUGUI>().color = Color.grey;
		achievementDesc.gameObject.GetComponent<TextMeshProUGUI>().color = Color.grey;
	}

	public void SetAchievementUnlocked()
	{
		checkmark.enabled = true;
		checkmark.transform.localScale = new Vector3(3f, 3f, 3f);
		DOTween.Sequence().Append(checkmark.transform.DOScale(new Vector3(1f, 1f, 1f), 1.25f).SetEase(Ease.OutBack)).AppendCallback(delegate
		{
			completeLine.transform.localScale = new Vector2(0f, 1f);
		})
			.Append(completeLine.transform.DOScale(new Vector3(1f, 1f), 1f).SetEase(Ease.OutElastic));
		achievementName.gameObject.GetComponent<TextMeshProUGUI>().color = Color.Lerp(Color.white, Color.grey, 1.5f);
		achievementDesc.gameObject.GetComponent<TextMeshProUGUI>().color = Color.Lerp(Color.white, Color.grey, 1.5f);
	}
}
