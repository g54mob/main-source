using UnityEngine;
using UnityEngine.UI;

namespace CTS.BBT
{
	public class UIFurnitureFilterToggle : MonoBehaviour
	{
		[SerializeField]
		private Toggle _toggle;

		[SerializeField]
		private FurnitureShopPopulator _populator;

		[SerializeField]
		private EFurnitureTags _tag;

		private void OnEnable()
		{
			_toggle.onValueChanged.AddListener(SetFilter);
			SetFilter(_toggle.isOn);
		}

		private void OnDisable()
		{
			_toggle.onValueChanged.RemoveListener(SetFilter);
		}

		private void SetFilter(bool p_value)
		{
			if (p_value)
			{
				_populator.AddFilter(_tag);
			}
			else
			{
				_populator.RemoveFilter(_tag);
			}
		}
	}
}
