using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class QuestConditionLabel : MonoBehaviour
{
	[SerializeField]
	[FormerlySerializedAs("text")]
	private TextMeshProUGUI label;

	[SerializeField]
	private Image icon;

	[SerializeField]
	private Color fulfilledColor;

	[SerializeField]
	private Color unfulfillableColor;

	[SerializeField]
	private Color normalColor;

	[SerializeField]
	private QuestIconLibrary questIconLibrary;

	[SerializeField]
	private string labelText;

	public void Setup(QuestCondition condition)
	{
		labelText = condition.GetLabelText();
		Sprite sprite = questIconLibrary.GetIcon(condition);
		icon.gameObject.SetActive(sprite != null);
		icon.sprite = sprite;
	}

	private void UpdateLabelText(int currentValue, int targetValue)
	{
		string text = labelText;
		text = text.Replace("[currentValue]", currentValue.ToString());
		text = text.Replace("[targetValue]", targetValue.ToString());
		label.text = text;
	}

	public void SetFulfillmentState(FulfillmentStatus conditionFulfilled, int currentValue, int targetValue)
	{
		UpdateLabelText(currentValue, targetValue);
		switch (conditionFulfilled)
		{
		case FulfillmentStatus.Fulfilled:
			label.color = fulfilledColor;
			break;
		case FulfillmentStatus.Unfulfillable:
			label.color = unfulfillableColor;
			break;
		default:
			label.color = normalColor;
			break;
		}
	}
}
