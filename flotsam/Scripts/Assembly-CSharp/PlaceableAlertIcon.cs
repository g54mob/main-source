using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class PlaceableAlertIcon : MonoBehaviour
{
	[Header("Components")]
	[SerializeField]
	[FormerlySerializedAs("Image")]
	private Image _image;

	[SerializeField]
	[FormerlySerializedAs("DescriptiveText")]
	private TextMeshProUGUI _descriptiveText;

	[SerializeField]
	[FormerlySerializedAs("Tooltip")]
	private Tooltip _tooltip;

	public void Initialize(PlaceableAlertProperties malfunctionProperties, string name)
	{
		if (malfunctionProperties == null)
		{
			Debug.LogError("Malfunction properties for " + name + " were null.");
			return;
		}
		base.gameObject.SetActive(value: true);
		_descriptiveText.text = malfunctionProperties.Summary;
		if ((bool)malfunctionProperties.UIIconProperties)
		{
			_image.overrideSprite = malfunctionProperties.UIIconProperties.Sprite;
			_tooltip.LocalizedText = malfunctionProperties.UIIconProperties.TooltipText;
		}
		else
		{
			Debug.LogError("Icon properties for " + malfunctionProperties.name + " were null.");
		}
	}
}
