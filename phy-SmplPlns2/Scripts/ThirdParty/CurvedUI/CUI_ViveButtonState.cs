using UnityEngine;

namespace CurvedUI
{
	public class CUI_ViveButtonState : MonoBehaviour
	{
		private enum ViveButton
		{
			Trigger = 0,
			TouchpadTouch = 1,
			TouchpadPress = 2,
			Grip = 3,
			Menu = 4
		}

		[SerializeField]
		private Color ActiveColor = Color.green;

		[SerializeField]
		private Color InActiveColor = Color.gray;

		[SerializeField]
		private ViveButton ShowStateFor;
	}
}
