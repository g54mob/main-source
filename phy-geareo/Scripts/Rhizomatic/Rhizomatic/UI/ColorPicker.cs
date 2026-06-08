using UnityEngine;
using UnityEngine.UI;

namespace Rhizomatic.UI
{
	public class ColorPicker : UIAdapter<Color>
	{
		public Image preview;

		public Selectable selectable;

		public ColorPickerPopup popupPrefab;

		protected override void UpdateView()
		{
		}

		public void Open()
		{
		}
	}
}
