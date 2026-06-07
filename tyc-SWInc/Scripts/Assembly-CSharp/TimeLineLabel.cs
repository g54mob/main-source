using UnityEngine;
using UnityEngine.UI;

public class TimeLineLabel : MonoBehaviour
{
	public Image Icon;

	public Image Back;

	public GameObject ButtonContainer;

	public Button Button;

	public Text Label;

	public void Set(EventTimeLine.MarketEventData data, bool interactable)
	{
		Label.text = data.Desc;
		Button.onClick.RemoveAllListeners();
		Back.color = data.MColor.ChangeValueSaturation(1f, 0.3f);
		if (data.MAction != null && interactable)
		{
			ButtonContainer.SetActive(true);
			Button.onClick.AddListener(delegate
			{
				data.MAction();
			});
		}
		else
		{
			ButtonContainer.SetActive(false);
		}
		Icon.sprite = ObjectDatabase.GetIcon(data.Icon);
	}
}
