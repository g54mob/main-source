using UnityEngine;

namespace Assets.Scripts.Design
{
	public class HideScript : MonoBehaviour
	{
		[SerializeField]
		private bool _displayOnlyWhenDragged;

		[SerializeField]
		private bool _hideDuringPartIcons;

		[SerializeField]
		private bool _hideDuringScreenshot;

		public bool DisplayOnlyWhenDragged => _displayOnlyWhenDragged;

		public bool HideDuringPartIcons => _hideDuringPartIcons;

		public bool HideDuringScreenshot => _hideDuringScreenshot;
	}
}
