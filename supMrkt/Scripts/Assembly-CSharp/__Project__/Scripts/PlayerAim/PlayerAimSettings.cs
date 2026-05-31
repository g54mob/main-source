using UnityEngine;
using UnityEngine.UI;

namespace __Project__.Scripts.PlayerAim
{
	public class PlayerAimSettings : NoktaSingleton<PlayerAimSettings>
	{
		[SerializeField]
		private Image aimImage;

		[SerializeField]
		private Transform aimScaleTransform;

		private float _defaultScaleFactor;

		private Coroutine _coroutine;

		private void Awake()
		{
		}

		private void OnEnable()
		{
		}

		public void SetAimSprite(int aimIndex)
		{
		}

		public void SetAimColor(string hexCode)
		{
		}

		public void SetScale(float value)
		{
		}
	}
}
