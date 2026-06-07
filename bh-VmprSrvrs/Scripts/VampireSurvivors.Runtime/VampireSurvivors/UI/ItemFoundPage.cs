using I2.Loc;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VampireSurvivors.Achievements;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Items;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Objects;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Signals;
using Zenject;

namespace VampireSurvivors.UI
{
	public class ItemFoundPage : BaseUIPage
	{
		[SerializeField]
		private Localize _ItemName;

		[SerializeField]
		private Localize _ItemDescription;

		[SerializeField]
		private Localize _Title;

		[SerializeField]
		private RectTransform _ContentPanel;

		[SerializeField]
		private Image _Icon;

		[SerializeField]
		private GameObject _GetButton;

		[SerializeField]
		private GameObject _DiscardButton;

		[SerializeField]
		private YellowSignManager _YellowSign;

		[SerializeField]
		private UISpriteAnimation _BurstVFX;

		[SerializeField]
		private ParticleEmitterManager _ParticleEmitter;

		[SerializeField]
		private RectTransform _Panel;

		[SerializeField]
		private GospelManager _Gospel;

		[SerializeField]
		private RectTransform _ScrollView;

		[SerializeField]
		private GameObject _New;

		[SerializeField]
		private TextMeshProUGUI _LevelText;

		private SignalBus _signalBus;

		private ItemType _item;

		private ItemData _itemData;

		private DataManager _dataManager;

		private WeaponType _weapon;

		private WeaponData _weaponData;

		private WeaponData _baseWeaponData;

		private PlayerOptions _playerOptions;

		private AchievementManager _achievementManager;

		private VampireSurvivors.Objects.Characters.CharacterController _playerWhoFoundIt;

		private bool _axisReset;

		private bool _canDiscard;

		private bool _discarded;

		private bool _hasReceived;

		private ParticleSystem _colorParticles;

		private bool _shouldTime;

		private float _autoAcceptCurrentTime;

		private float _autoAcceptTimeLimit;

		[Inject]
		private void Construct(SignalBus signalBus, DataManager data, PlayerOptions playerOptions, AchievementManager achievementManager)
		{
		}

		private void OnClosePage(OnlineSignals.OnlineCloseItemFoundPage close)
		{
		}

		protected override void Update()
		{
		}

		private void FixedUpdate()
		{
		}

		public void Receive()
		{
		}

		public void Discard()
		{
		}

		private void DiscardItem()
		{
		}

		private void ReceiveItem()
		{
		}

		private void OnDestroy()
		{
		}

		protected override void OnShowStart(GameObject g)
		{
		}

		protected override VampireSurvivors.Objects.Characters.CharacterController GetCharacterControllingUi()
		{
			return null;
		}

		protected override void OnHideFinish(GameObject g)
		{
		}

		private void CacheItem(GameplaySignals.PlayerPickedUpNewItemSignal sig)
		{
		}

		private void SetItemDisplay()
		{
		}

		private void SetWeaponDisplay(int level)
		{
		}

		private void SetRelicDisplay()
		{
		}

		private void MakeColorParticles()
		{
		}

		private void SetIconSize()
		{
		}
	}
}
