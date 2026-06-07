using UnityEngine;
using UnityEngine.UI;

public class FieldSlot : MonoBehaviour
{
	[SerializeField]
	private Image _icon;

	[SerializeField]
	private Slider _slider;

	public DecorationSlot Slot { get; private set; }

	public int SlotIndex { get; private set; }

	public Decoration Decoration { get; private set; }

	private void LateUpdate()
	{
		if ((bool)Decoration)
		{
			_slider.value = Decoration.ConstructionHandler.Progress;
		}
	}

	public void InitializeSlot(DecorationSlot slot, int index)
	{
		Slot = slot;
		SlotIndex = index;
		Decoration = null;
		_icon.enabled = false;
		_slider.value = 0f;
	}

	public bool TryInitializeDecoration(Decoration decoration)
	{
		if (decoration.SlotIndices.Contains(SlotIndex))
		{
			Decoration = decoration;
			_icon.enabled = true;
			_icon.sprite = decoration.Properties.Icon;
			_slider.value = decoration.ConstructionHandler.Progress;
			return true;
		}
		return false;
	}
}
