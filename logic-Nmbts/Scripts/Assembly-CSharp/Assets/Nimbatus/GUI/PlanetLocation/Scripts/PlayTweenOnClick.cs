using UnityEngine;

namespace Assets.Nimbatus.GUI.PlanetLocation.Scripts
{
	public class PlayTweenOnClick : MonoBehaviour
	{
		public TweenPosition Tween;

		public bool Forward;

		public void OnClick()
		{
			Tween.Play(Forward);
		}
	}
}
