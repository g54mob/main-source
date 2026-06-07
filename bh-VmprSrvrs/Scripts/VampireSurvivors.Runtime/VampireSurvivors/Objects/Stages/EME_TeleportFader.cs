using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

namespace VampireSurvivors.Objects.Stages
{
	public class EME_TeleportFader : MonoBehaviour
	{
		private enum FadeState
		{
			Idle = 0,
			FadeIn = 1,
			Hold = 2,
			FadeOut = 3
		}

		[SerializeField]
		private Image _faderImage;

		[SerializeField]
		private Image _whiteFade;

		[Space]
		[SerializeField]
		private float _fadeInTime;

		[SerializeField]
		private float _fadeHoldTime;

		[SerializeField]
		private float _fadeOutTime;

		[Space]
		[SerializeField]
		private float _maxTrianglesAlpha;

		[SerializeField]
		private bool _fadeInTrianglesAlpha;

		[SerializeField]
		private bool _includeBackgroundWhiteFade;

		[SerializeField]
		private AnimationCurve _whiteFadeCurve;

		private float _fadeTimer;

		private FadeState _currentState;

		private static readonly int FadeProgress;

		public event Action OnFadeInComplete
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action OnFadeOutComplete
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public void Init()
		{
		}

		public void BeginFade(Action onFadeInComplete, Action onFadeOutComplete)
		{
		}

		public void UpdateFade()
		{
		}

		private void SetFadeProgress(float fadeValue)
		{
		}

		public void TestFade()
		{
		}
	}
}
