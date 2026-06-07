using System.Collections.Generic;
using UnityEngine;

namespace Gh.Tk.UI
{
	public class SwatchPicker3DUIView : MonoBehaviour
	{
		[SerializeField]
		private List<SwatchButton3DUIView> _currentSwatchButtons;

		[SerializeField]
		private List<SwatchButton3DUIView> _swatchPaletteButtons;

		[SerializeField]
		private GameObject _paletteTabButton;

		[SerializeField]
		private Container3DUIView _tabButtonContainer;

		private List<Button3DUIView> _paletteTabButtons;

		private EntityObject _activeObject;
	}
}
