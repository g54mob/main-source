using UnityEngine;

namespace __Project__.Scripts.PlayerAim
{
	public class AimColorPreview : NoktaSingleton<AimColorPreview>
	{
		[SerializeField]
		private ColorPicker colorPicker;

		public ColorPicker ColorPicker => null;

		private void OnEnable()
		{
		}

		public void ColorOnEnableInit()
		{
		}

		private void OnDisable()
		{
		}

		private void OnColorChanged(Color color)
		{
		}
	}
}
