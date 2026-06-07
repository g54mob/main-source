using UnityEngine;

namespace Assets.Nimbatus.GUI.Common.Scripts
{
	public class ScrollbarArrow : MonoBehaviour
	{
		public UIScrollBar Scrollbar;

		public float Direction = 0.1f;

		public UISprite Sprite;

		private bool _isPressed;

		public void Update()
		{
			Sprite.alpha = Scrollbar.alpha;
			if (_isPressed)
			{
				Scrollbar.value += Direction * Time.deltaTime;
			}
		}

		public void OnPress(bool isPressed)
		{
			_isPressed = isPressed;
		}
	}
}
