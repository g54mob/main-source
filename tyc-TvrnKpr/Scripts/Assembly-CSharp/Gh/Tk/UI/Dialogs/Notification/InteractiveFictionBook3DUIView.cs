using System;
using System.Collections.Generic;
using UnityEngine;

namespace Gh.Tk.UI.Dialogs.Notification
{
	public class InteractiveFictionBook3DUIView : ShowHideAnimation3DUIView
	{
		public const string ErtingaleValley = "ElvenValley";

		public const string Unterdeep = "DwarvenMines";

		public const string Swamp = "Swamp";

		public const string Halflington = "Halflington";

		public const string Gugamush = "Gugamush";

		public const string WizardsTower = "Wizard";

		public const string MeraminCity = "City";

		public string BookId;

		public Transform sceneRenderBone;

		public Transform pageContentBone;

		[Header("IF Book")]
		[SerializeField]
		private BasicAnimationEventObserver rootAnimationEventObserver;

		[SerializeField]
		private GameObject _bookSymbols;

		private Vector3 _bookSymbolsStartScale;

		public GameObject[] cornersLeftPage;

		public GameObject[] cornersRightPage;

		[Header("Inky Character")]
		[SerializeField]
		private GameObject _inkyPos;

		[SerializeField]
		private GameObject _inkyCharacter;

		[SerializeField]
		private GameObject _inkySplashParticles;

		[SerializeField]
		private ParticleSystem _inkyPageContactParticles;

		[Header("Slinky Character")]
		[SerializeField]
		private GameObject _slinkyCharacter;

		public List<ParticleSystem> insigniaRevealParticles;

		private List<InkToColorAnimator> _inkToColorAnimators;

		[Header("Blinky")]
		[SerializeField]
		private GameObject _blinkyCharacter;

		[SerializeField]
		private float _clickDistanceForBlinkySummoning;

		[SerializeField]
		private int _clickCountForBlinkySummoning;

		[SerializeField]
		private GameObject[] _spawnSurfaces;

		[SerializeField]
		private GameObject _clickParticlePrefab;

		[SerializeField]
		private GameObject[] _blinkyRandomPositionContainers;

		private bool _pokeEnabled;

		private Vector3 _lastClickPosition;

		private int _clickCountNearPosition;

		private bool _inkClickSplashDisabled;

		private float _timeToNextBlinkySpawning;

		private bool _wasBlinkySpawningDisabled;

		private static readonly int Enabled;

		public InteractiveFictionDialog3DUIView DialogView { get; set; }

		[field: SerializeField]
		public Animator BookAnimator { get; private set; }

		[field: SerializeField]
		public Animator RunesAnimator { get; private set; }

		public bool IsSlinkyJumpingIn { get; set; }

		public Action<bool> AnimateTextAction { get; set; }

		public static string GetBookIdForLevel(string levelId)
		{
			return null;
		}

		private void PlayInkyJumpinAnimation()
		{
		}

		public void PlaySlinkyJumpinAnimation()
		{
		}

		private void ListenToInkBlobAnimations()
		{
		}

		public void ResetBlinkyStats()
		{
		}

		private void StopListeningToInkBlobAnimations()
		{
		}

		private void InkyAnimEvent(object sender, AnimationEventArgs e)
		{
		}

		private void BlinkyAnimEvent(object sender, AnimationEventArgs e)
		{
		}

		private void BookAnimEvent(object sender, AnimationEventArgs e)
		{
		}

		private void SlinkyAnimEvent(object sender, AnimationEventArgs e)
		{
		}

		private void OnSlinkyFinishedJumping()
		{
		}

		public void OnReadyToShowContent()
		{
		}

		public void OnReadyToRevealInk()
		{
		}

		public void MouseUp_CheckBlinky()
		{
		}

		private void PlayRandomVariation(Animator animator, string parameterName)
		{
		}

		private void UpdateBlinkyRandomSpawning()
		{
		}

		protected override void Awake()
		{
		}

		public void OnOpen()
		{
		}

		public void OnClosed()
		{
		}

		public void OnReopen()
		{
		}

		public void OnShowIFScene()
		{
		}

		public void OnShowFateSpinner()
		{
		}

		public void OnHideFateSpinner()
		{
		}

		public void SetBookSymbolsActive(bool active)
		{
		}

		public void OnUpdate()
		{
		}

		private void OnDestroy()
		{
		}

		protected override void OnDisable()
		{
		}

		public void OnDialogAnimEvent(object sender, AnimationEventArgs e)
		{
		}
	}
}
