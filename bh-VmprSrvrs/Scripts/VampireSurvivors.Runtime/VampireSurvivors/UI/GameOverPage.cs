using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using VampireSurvivors.App.Framework.System;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Objects;
using Zenject;

namespace VampireSurvivors.UI
{
	public class GameOverPage : BaseUIPage
	{
		[FormerlySerializedAs("Pixeler")]
		[SerializeField]
		private PixelationTool _Pixeler;

		[SerializeField]
		private Button _QuitButton;

		[SerializeField]
		private Button _ReviveButton;

		[SerializeField]
		private Button _WatchAdForReviveButton;

		[SerializeField]
		private Button _ArcadeFreeReviveButton;

		[SerializeField]
		private UISpriteAnimation _ReviveAnimation;

		[SerializeField]
		private Material _GameOverPixelise;

		[SerializeField]
		private Image _WhiteFlash;

		[SerializeField]
		private Image _Background;

		[SerializeField]
		private Animator _Animator;

		[SerializeField]
		private Image _Title;

		[SerializeField]
		private Material _BackgroundPixelMat;

		[SerializeField]
		private Material _TitlePixelMat;

		[SerializeField]
		private Image _StageCompleted;

		[SerializeField]
		private Image _MoneyPile;

		[SerializeField]
		private TextMeshProUGUI _BonusCoins;

		[SerializeField]
		private TextMeshProUGUI _CoinReward;

		[SerializeField]
		private TextMeshProUGUI _ReviveCoins;

		[SerializeField]
		private TextMeshProUGUI _QuitText;

		[SerializeField]
		private TextMeshProUGUI _ReviveText;

		private SignalBus _signalBus;

		private GameSessionData _gameSessionData;

		private ArcanaManager _arcanaManager;

		private PlayerOptions _playerOptions;

		private DataManager _data;

		private UnityServicesManager _unityServicesManager;

		private int _awardGivenXTimes;

		private int _totalCoins;

		private bool _hasRevives;

		private bool _stageComplete;

		private static readonly int CellSizeX;

		private static readonly int CellSizeY;

		private static readonly int PixelSize;

		private static readonly int TexSize;

		[Inject]
		private void Construct(SignalBus signal, GameSessionData gameSessionData, ArcanaManager arcanaManager, PlayerOptions player, DataManager data, UnityServicesManager unityServicesManager)
		{
		}

		private void Start()
		{
		}

		private void OnDestroy()
		{
		}

		public void AnimateText()
		{
		}

		public void Revive()
		{
		}

		public void Quit()
		{
		}

		public void WatchAdForRevive()
		{
		}

		public void ArcadeFreeRevive()
		{
		}

		protected override void OnShowStart(GameObject g)
		{
		}

		private bool CanShowAdvertReviveButton()
		{
			return false;
		}

		private bool CanShowArcadeFreeReviveButton()
		{
			return false;
		}

		private bool IsAppleArcade()
		{
			return false;
		}

		private int ReviveCashAmount()
		{
			return 0;
		}

		private void OnIntroEnded()
		{
		}

		private void EnterStageReward()
		{
		}

		private void PlayReviveAnimation()
		{
		}

		private void OnReviveAnimComplete()
		{
		}

		private void AnimateButtons()
		{
		}

		private void ReviveCharacter()
		{
		}
	}
}
