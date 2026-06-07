using UnityEngine;

namespace Gh.Tk.UI.Dialogs.MealDesigner
{
	public class FlavourGauge3DUIView : BaseInteractable3DUIView
	{
		[SerializeField]
		private FlavourPip[] _pips;

		private int _value;

		private int? _previewValue;

		public void SetValue(int value)
		{
		}

		public void SetPreviewValue(int? value)
		{
		}

		private void UpdateVisual()
		{
		}
	}
}
