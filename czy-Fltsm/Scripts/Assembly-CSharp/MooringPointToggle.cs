using I2.Loc;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Tooltip))]
public class MooringPointToggle : MonoBehaviour
{
	public Toggle Toggle;

	[SerializeField]
	private Image _boatImage;

	private Tooltip _tooltip;

	public UnityMooringPointToggleEvent OnValueChanged;

	public BoatType BoatType { get; private set; }

	public void Initialize(BoatType boatType, Sprite boatSprite, LocalizedString boatName)
	{
		BoatType = boatType;
		_boatImage.sprite = boatSprite;
		_tooltip = GetComponent<Tooltip>();
		_tooltip.LocalizedText = boatName;
		OnValueChanged = new UnityMooringPointToggleEvent();
		Toggle.onValueChanged.AddListener(TriggerValueChangedEvent);
	}

	private void TriggerValueChangedEvent(bool value)
	{
		if (OnValueChanged != null)
		{
			OnValueChanged.Invoke(value, BoatType);
		}
	}
}
