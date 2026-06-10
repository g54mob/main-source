using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class RemapController : MonoBehaviour
{
	[Header("Components")]
	public RectTransform rect;

	public ButtonController primaryControlButton;

	public TextMeshProUGUI controlDescriptionText;

	public TextMeshProUGUI primaryText;

	public string actionName;

	public int actionId;

	public int index;

	public string category;

	[FormerlySerializedAs("BindTimerBackground")]
	public Image bindTimerBackground;

	public void OnSetAlternateButton()
	{
	}

	public void ShowBindingTimeLeftVisuals(float timer)
	{
	}

	public void HideBindingTimeLeftVisuals()
	{
	}
}
