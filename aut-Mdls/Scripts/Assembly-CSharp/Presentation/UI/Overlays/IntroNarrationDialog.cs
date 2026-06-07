using System.Collections.Generic;
using Events.UI.Overlays;
using Presentation.Locators;
using UnityEngine;

namespace Presentation.UI.Overlays
{
	public class IntroNarrationDialog : NarrationDialog
	{
		private static readonly int AtlasAnimTalk = Animator.StringToHash("AtlasAnimTalk");

		private static readonly int AtlasAnimIdle = Animator.StringToHash("AtlasAnimIdle");

		private static readonly int AtlasTalkIndex = Animator.StringToHash("TalkIndex");

		[SerializeField]
		private List<GameObject> _introCanvases = new List<GameObject>();

		[SerializeField]
		private IntroManagerLocator _introManagerLocator;

		[SerializeField]
		private Animator _atlasAnimator;

		private void Start()
		{
			_introManagerLocator.IntroManager.OnIntroStart += OnIntroStart;
			_introManagerLocator.IntroManager.OnIntroEnd += OnIntroEnd;
		}

		private void OnDestroy()
		{
			_introManagerLocator.IntroManager.OnIntroStart -= OnIntroStart;
			_introManagerLocator.IntroManager.OnIntroEnd -= OnIntroEnd;
			UnInitialize();
		}

		private void OnIntroStart()
		{
			foreach (GameObject introCanvase in _introCanvases)
			{
				introCanvase.SetActive(value: true);
			}
		}

		private void OnIntroEnd()
		{
			if (_narratorTalking)
			{
				_audioManagerLocator?.AudioManager.StopNarratorTalkLoop();
			}
			UnInitialize();
			foreach (GameObject introCanvase in _introCanvases)
			{
				introCanvase.SetActive(value: false);
			}
		}

		protected override void StartNarrationAnim()
		{
			base.StartNarrationAnim();
			_atlasAnimator.SetInteger(AtlasTalkIndex, Random.Range(0, 4));
			_atlasAnimator.SetTrigger(AtlasAnimTalk);
			_audioManagerLocator?.AudioManager.StartAtlasTalkLoop();
		}

		protected override void EndNarrationAnim()
		{
			base.EndNarrationAnim();
			_atlasAnimator.SetTrigger(AtlasAnimIdle);
		}

		protected override bool CanShow(NarrationDto dto)
		{
			return dto.NarratorType == NarrationDto.Narrators.Intro;
		}
	}
}
