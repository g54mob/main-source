using System.Collections.Generic;
using DG.Tweening;
using DarkTonic.MasterAudio;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Characters;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Signals;
using Zenject;

namespace VampireSurvivors.UI
{
	public class CharacterFoundPage : BaseUIPage
	{
		[SerializeField]
		private Image _Icon;

		[SerializeField]
		private TextMeshProUGUI _Name;

		[SerializeField]
		private TextMeshProUGUI _ThankYouText;

		[SerializeField]
		private RectTransform _TextPanel;

		[SerializeField]
		private GameObject _ThankYouTextPanel;

		[SerializeField]
		private Image _BGFader;

		[SerializeField]
		private Image _PanelDarkOverlay;

		[SerializeField]
		private GameObject _DoneButton;

		[SerializeField]
		private GameObject _OkButton;

		[SerializeField]
		private GameObject _Ray;

		[SerializeField]
		private Transform _RayContainer;

		[SerializeField]
		private ParticleEmitterManager _Particles;

		[SerializeField]
		private RectTransform _Panel;

		[FormerlySerializedAs("_BGOverlay")]
		[SerializeField]
		private Image _BGAdditiveOverlay;

		[SerializeField]
		private GameObject VFX;

		private SignalBus _signalBus;

		private DataManager _dataManager;

		private CharacterData _unlockedCharacterData;

		private CharacterType _unlockedCharacterType;

		private List<Image> _ghosts;

		private List<GameObject> _rays;

		private Image _darkIcon;

		private ParticleSystem _darkParticles;

		private ParticleSystem _colorParticles;

		private List<Tween> _tweens;

		private GravityWell _gravityWell;

		private VampireSurvivors.Objects.Characters.CharacterController _currentCharacter;

		private bool _playDarkParticles;

		private bool _canSkip;

		private List<Tween> _toCompleteOnSkip;

		private PlaySoundResult _openCoffinSoundResult;

		private GravityWellConfig gravityWellCongfig;

		[Inject]
		private void Construct(SignalBus signalBus, DataManager data)
		{
		}

		private void OnRevealCharacterRemotely()
		{
		}

		private void OnCollectedCharacterRemotely()
		{
		}

		private void OnDestroy()
		{
		}

		private void FixedUpdate()
		{
		}

		public void CollectCharacter()
		{
		}

		private void PerformCollectCharacter()
		{
		}

		private void AnimateOut()
		{
		}

		public void Reveal()
		{
		}

		private void PerformReveal()
		{
		}

		protected override void OnShowStart(GameObject g)
		{
		}

		protected override VampireSurvivors.Objects.Characters.CharacterController GetCharacterControllingUi()
		{
			return null;
		}

		private void Skip()
		{
		}

		protected override void OnHideFinish(GameObject g)
		{
		}

		private void EnableDoneButton()
		{
		}

		private void CreateBlackParticles()
		{
		}

		protected override void OnCancelPressed()
		{
		}

		private void MakeColorParticles()
		{
		}

		private void EnableOkButton()
		{
		}

		private void DisableOkButton()
		{
		}

		private void SaveCharacterData(GameplaySignals.CharacterFoundSignal sig)
		{
		}

		private void PlayGhosts()
		{
		}

		private void PlayFirework()
		{
		}

		private void AddRays()
		{
		}

		private GameObject CreateRay(string color)
		{
			return null;
		}

		private static Color hexToColor(string hex)
		{
			return default(Color);
		}
	}
}
