using System;
using UnityEngine;

namespace Assets.Nimbatus.GUI.MainMenu.Scripts
{
	public class ShowKickstarterPopup : MonoBehaviour
	{
		public TweenPosition Tween;

		private static bool _hasShown;

		public void Start()
		{
			DateTime dateTime = new DateTime(2017, 12, 5, 20, 0, 0, DateTimeKind.Utc);
			if (DateTime.UtcNow < dateTime && !_hasShown)
			{
				Tween.PlayForward();
				_hasShown = true;
			}
		}

		public void OnClick()
		{
			Tween.PlayReverse();
		}

		public void Update()
		{
			if (Input.GetKeyDown(KeyCode.Escape) && Tween.value == Tween.to)
			{
				OnClick();
			}
		}
	}
}
