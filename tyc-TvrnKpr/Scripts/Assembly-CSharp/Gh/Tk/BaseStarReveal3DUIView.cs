using System.Collections.Generic;
using UnityEngine;

namespace Gh.Tk
{
	public class BaseStarReveal3DUIView : MonoBehaviour, IBasicAnimEventSupport
	{
		public bool showBackground;

		public bool muteMusic;

		public string revealSoundEventName;

		public Button3DUIView[] clickableElements;

		private readonly List<string> _enabledTransforms;

		private readonly List<string> _disabledTransforms;

		private List<Animator> _animators;

		private void Start()
		{
		}

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		private void OnClick()
		{
		}

		public void AnimEventAddStar()
		{
		}

		public void Enable(string transformName)
		{
		}

		public void Disable(string transformName)
		{
		}

		public void Reset()
		{
		}

		public void Play()
		{
		}
	}
}
