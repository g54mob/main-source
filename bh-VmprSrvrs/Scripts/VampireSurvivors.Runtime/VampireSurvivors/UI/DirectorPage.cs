using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using VampireSurvivors.Objects;
using VampireSurvivors.Objects.Characters;
using Zenject;

namespace VampireSurvivors.UI
{
	public class DirectorPage : GameWindowedUIPage
	{
		[SerializeField]
		private RectTransform _MaskContainer;

		[SerializeField]
		private List<RectTransform> _MaskIcons;

		[SerializeField]
		private UISpriteAnimation _BurstVFX;

		[SerializeField]
		private RectTransform EasyButton;

		[SerializeField]
		private RectTransform HardButton;

		[SerializeField]
		private RectTransform OKButton;

		private string langKey;

		private int sceneFlag;

		private bool _hasTrumpet;

		private bool _hasMirror;

		private SignalBus _signalBus;

		private PlayerOptions _playerOptions;

		private ParticleSystem _angryPfx1;

		private ParticleSystem _angryPfx2;

		private bool _angryPfxCreated;

		private bool _hasSwitched;

		private Sequence _shuffleSequence;

		private Sequence _okButtonOutSequence;

		[Inject]
		private void Construct(SignalBus signal, PlayerOptions player)
		{
		}

		private void OnRemoteOkButton()
		{
		}

		private void OnRemoteTooEasy()
		{
		}

		private void OnRemoteTooHard()
		{
		}

		public void SelectTooEasy()
		{
		}

		private void OnSelectedTooEasy()
		{
		}

		public void SelectTooHard()
		{
		}

		private void OnSelectedTooHard()
		{
		}

		protected void OnDestroy()
		{
		}

		protected override void OnShowStart(GameObject g)
		{
		}

		private void ShowPanels()
		{
		}

		protected override VampireSurvivors.Objects.Characters.CharacterController GetCharacterControllingUi()
		{
			return null;
		}

		private void TweenButtonIn(RectTransform b)
		{
		}

		private Sequence TweenButtonOut(RectTransform b)
		{
			return null;
		}

		private void DoMaskTween()
		{
		}

		public void OKButtonClicked()
		{
		}

		private void OnOkButtonClicked()
		{
		}

		private void CreateAngryParticles()
		{
		}
	}
}
