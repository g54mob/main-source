using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
using VampireSurvivors.App.Scripts.Framework.Adventures;
using VampireSurvivors.App.UI;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Items;
using VampireSurvivors.Data.PowerUp;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Objects;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Items;
using VampireSurvivors.Signals;
using Zenject;

namespace VampireSurvivors.UI
{
	public class MerchantUIPage : GameWindowedUIPage
	{
		[CompilerGenerated]
		private sealed class _003CBuyAllRoutine_003Ed__54 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public MerchantUIPage _003C_003E4__this;

			public RectTransform sender;

			public float count;

			private int _003Ci_003E5__2;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003CBuyAllRoutine_003Ed__54(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		[CompilerGenerated]
		private sealed class _003CWaitAndTween_003Ed__72 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public MerchantUIPage _003C_003E4__this;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003CWaitAndTween_003Ed__72(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		[SerializeField]
		private ShopItemUI _ShopItemPrefab;

		[SerializeField]
		private RectTransform _ItemContainer;

		[SerializeField]
		private GameObject _EggResultPrefab;

		[SerializeField]
		private RectTransform _Panel;

		[SerializeField]
		private UISpriteAnimation _BurstVFX;

		[SerializeField]
		private GridLayoutGroup _Grid;

		[SerializeField]
		private ContentSizeFitter _GridFitter;

		[SerializeField]
		private RectTransform _CurrencyPanel;

		[SerializeField]
		private Image _Mask;

		private SignalBus _signalBus;

		private DataManager _data;

		private PlayerOptions _playerOptions;

		private EggManager _egg;

		private AdventureManager _adventureManager;

		private ShopFactory _shopFactory;

		private Dictionary<ItemType, ItemData> _items;

		private Dictionary<WeaponType, List<WeaponData>> _weapons;

		private Dictionary<PowerUpType, List<PowerUpData>> _powerUps;

		private Coroutine _maxEggsPurchasedRoutine;

		private string[] _textColors;

		private float _SpamPressTimer;

		private bool _SpamPressFirst;

		protected bool hideBackgroundMask;

		private List<string> _itemSprites;

		private int _goldenEggSoundIndex;

		private int[] _goldenEggSFXDetune;

		private ShopItemUI _selected;

		private VampireSurvivors.Objects.Characters.CharacterController _currentCharacter;

		private TutorialPopup _spawnedTutorialPopup;

		private List<ItemType> ForbiddenItemsInMultiplayer;

		[Inject]
		private void Construct(SignalBus signalBus, DataManager data, PlayerOptions playerOptions, GameSessionData session, EggManager egg, AdventureManager adventureManager, ShopFactory shopFactory)
		{
		}

		protected override void Awake()
		{
		}

		private void OnRemotePurchase(OnlineSignals.OnlinePurchase purchase)
		{
		}

		private void OnDestroy()
		{
		}

		public void Close()
		{
		}

		public override float GetCurrency()
		{
			return 0f;
		}

		public override void SetSelected(ShopItemUI item)
		{
		}

		public override void Purchase(WeaponType t, WeaponData d, float price, ShopItemUI shopItemUI)
		{
		}

		public override void OnUserConfirmInput()
		{
		}

		public override void Purchase(ItemType t, ItemData d, ShopItemUI item, float price, RectTransform sender)
		{
		}

		public void PurchaseSelected()
		{
		}

		private void InvokeCustomPurchaseActionAndClose(ShopItemUI item)
		{
		}

		protected override void OnHideStart(GameObject g)
		{
		}

		protected override void OnShowStart(GameObject g)
		{
		}

		protected override void OnHideFinish(GameObject g)
		{
		}

		private void EditorShowTutorial()
		{
		}

		private void OnMerchantTutorialClosed()
		{
		}

		protected override void Update()
		{
		}

		protected void OnMerchantEnterPressed()
		{
		}

		protected override VampireSurvivors.Objects.Characters.CharacterController GetCharacterControllingUi()
		{
			return null;
		}

		protected override void OnCancelPressed()
		{
		}

		private void ProcessWeaponPurchase(WeaponType t, int price, ShopItemUI shopItemUI)
		{
		}

		private void ProcessItemPurchase(ItemType t, ShopItemUI item, RectTransform sender)
		{
		}

		private void SetCurrentCharacter(UISignals.OpenMerchantSignal sig)
		{
		}

		[IteratorStateMachine(typeof(_003CBuyAllRoutine_003Ed__54))]
		private IEnumerator BuyAllRoutine(float count, RectTransform sender)
		{
			return null;
		}

		private static void MakeEggNoise(int sfxIndex, int delay)
		{
		}

		private string RandomFrame()
		{
			return null;
		}

		private void Populate()
		{
		}

		private void RecenterGridGroup()
		{
		}

		public static List<WeaponType> GetValidAdventureWeaponsForMerchant(List<WeaponType> merchantInventory, PlayerOptions playerOptions)
		{
			return null;
		}

		public static List<WeaponType> GetValidCustomMerchantWeapons(List<WeaponType> merchantInventory, PlayerOptions playerOptions)
		{
			return null;
		}

		public static List<ItemType> GetValidCustomMerchantItems(List<ItemType> merchantInventoryItems, PlayerOptions playerOptions)
		{
			return null;
		}

		private void ShowEggResult(RectTransform sender, string att, float val)
		{
		}

		private void ShowEggResultSprite(RectTransform sender)
		{
		}

		private string LookUpFrame(string name)
		{
			return null;
		}

		private bool DoesPlayerAlreadyHaveWeapon(WeaponType t)
		{
			return false;
		}

		private GameObject AddWeapon(WeaponType t, int index, bool useWeaponDataPrice = false)
		{
			return null;
		}

		private void AddItem(ItemType t, int index)
		{
		}

		private ShopItemUI AddCustomActionShopItem(CustomActionInventoryItem inventoryItem)
		{
			return null;
		}

		private float GetAdventureMerchantPriceMarkupMultiplier()
		{
			return 0f;
		}

		private void ClearSpawned()
		{
		}

		private void IntroAnimation()
		{
		}

		[IteratorStateMachine(typeof(_003CWaitAndTween_003Ed__72))]
		private IEnumerator WaitAndTween()
		{
			return null;
		}

		private void DisableWeaponPanels()
		{
		}
	}
}
