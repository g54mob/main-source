using UnityEngine;

namespace UMA.CharacterSystem
{
	public class UMAColorFader : MonoBehaviour
	{
		public enum FadeType
		{
			FadeIn = 0,
			FadeOut = 1
		}

		public DynamicCharacterAvatar DCA;

		private OverlayColorData Color;

		public FadeType Fade;

		public string ColorName;

		public float time;

		private void Start()
		{
		}

		private void Update()
		{
		}
	}
}
