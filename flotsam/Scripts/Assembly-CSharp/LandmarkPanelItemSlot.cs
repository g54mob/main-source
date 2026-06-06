using UnityEngine;
using UnityEngine.UI;

public class LandmarkPanelItemSlot : MonoBehaviour
{
	[Header("References")]
	[Tooltip("The background image that will change color based on availability.")]
	[SerializeField]
	private Image _background;

	[Tooltip("The icon image that will change based on the item that the objective needs.")]
	[SerializeField]
	private Image _icon;

	[Tooltip("The text component that will show how many items the player needs to complete the objective.")]
	[SerializeField]
	private Text _counter;

	public bool MeetsRequirement { get; private set; }

	public void Initialize(ItemProperties itemProprties, int required, int available)
	{
		MeetsRequirement = required <= available;
		_background.color = (MeetsRequirement ? Color.green : Color.red);
		_icon.sprite = itemProprties.InventorySprite;
		_counter.text = available + "/" + required;
	}
}
