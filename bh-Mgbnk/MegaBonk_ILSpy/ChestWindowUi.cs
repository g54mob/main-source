using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Actors.Player;
using Assets.Scripts.Inventory__Items__Pickups;
using Assets.Scripts.Inventory__Items__Pickups.Interactables;
using Assets.Scripts.Inventory__Items__Pickups.Items;
using Assets.Scripts.Inventory.Stats;
using Assets.Scripts.Managers;
using Assets.Scripts.Menu.Shop;
using Assets.Scripts.UI.InGame.Rewards;
using Assets.Scripts.UI.Localization;
using Assets.Scripts.Utility;
using Cpp2ILInjected;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class ChestWindowUi : BaseEncounterWindow
{
	private sealed class _003CAnimateSingleTextObject_003Ed__22 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public TextMeshProUGUI text;

		public float fadeTime;

		private float _003Ctimer_003E5__2;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		public _003CAnimateSingleTextObject_003Ed__22(int _003C_003E1__state)
		{
			((IDisposable)this).Dispose();
			this._003C_003E1__state = _003C_003E1__state;
		}

		void IDisposable.Dispose()
		{
		}

		private unsafe bool MoveNext()
		{
			//IL_025f: Expected I4, but got I8
			//IL_0052: Expected O, but got I4
			//IL_00a3: Expected I4, but got I8
			//IL_0285: Expected I4, but got O
			//IL_008f: Expected I4, but got I8
			//IL_012b: Invalid comparison between I4 and F4
			//IL_0176: Expected F4, but got I4
			//IL_023d: Expected O, but got Ref
			//IL_0325: Invalid comparison between I4 and F4
			//IL_01c6: Expected F4, but got I4
			//IL_01d8: Expected O, but got Ref
			bool flag = _003C_003E1__state == 0;
			if (!flag)
			{
				object obj = _003C_003E1__state - 1;
				if (!flag)
				{
					if ((nint)obj != 1)
					{
						goto IL_0242;
					}
					_003C_003E1__state = -1;
				}
				else
				{
					_003C_003E1__state = -1;
					if ((object)text == null)
					{
						goto IL_0277;
					}
					text.CrossFadeAlpha(1f, fadeTime, ignoreTimeScale: true);
					_003Ctimer_003E5__2 = 0f;
				}
				float num3 = default(float);
				if (fadeTime > _003Ctimer_003E5__2)
				{
					float deltaTime = Time.deltaTime;
					float num = (_003Ctimer_003E5__2 = deltaTime + _003Ctimer_003E5__2) / fadeTime;
					if (!(0f > num))
					{
						if (num > 1f)
						{
							num = 1f;
						}
					}
					else
					{
						num = 0f;
					}
					if ((object)text != null)
					{
						Transform transform = text.transform;
						float num2 = Easing.InCirc(num);
						if (!(0f > num2))
						{
							if (num2 > 1f)
							{
								num2 = 1f;
							}
						}
						else
						{
							num2 = 0f;
						}
						if ((object)transform != null)
						{
							transform.localScale = (Vector3)(&num3);
							_003C_003E2__current = null;
							_003C_003E1__state = 2;
							return true;
						}
					}
				}
				else if ((object)text != null)
				{
					Transform transform2 = text.transform;
					if ((object)transform2 != null)
					{
						transform2.localScale = (Vector3)(&num3);
						goto IL_0242;
					}
				}
				goto IL_0277;
			}
			_003C_003E1__state = -1;
			_003C_003E2__current = null;
			_003C_003E1__state = 1;
			return true;
			IL_0277:
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
			IL_0242:
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		void IEnumerator.Reset()
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802696E0");
			NotSupportedException ex = new NotSupportedException();
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802696E0");
			throw ex;
		}
	}

	private sealed class _003CAnimateText_003Ed__21 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public ChestWindowUi _003C_003E4__this;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		public _003CAnimateText_003Ed__21(int _003C_003E1__state)
		{
			((IDisposable)this).Dispose();
			this._003C_003E1__state = _003C_003E1__state;
		}

		void IDisposable.Dispose()
		{
		}

		private unsafe bool MoveNext()
		{
			//IL_00f6: Expected I4, but got I8
			//IL_037b: Expected I4, but got O
			//IL_0015: Expected O, but got I4
			//IL_0070: Expected I4, but got I8
			//IL_005b: Expected I4, but got I8
			//IL_02d4: Expected O, but got Ref
			ChestWindowUi chestWindowUi = _003C_003E4__this;
			bool flag = _003C_003E1__state == 0;
			if (!flag)
			{
				object obj = _003C_003E1__state - 1;
				bool result;
				if (!flag)
				{
					bool flag2 = (nint)obj != 1;
					result = false;
					if (!flag2)
					{
						_003C_003E1__state = -1;
						return false;
					}
				}
				else
				{
					_003C_003E1__state = -1;
					if ((object)_003C_003E4__this == null)
					{
						goto IL_036d;
					}
					IEnumerator routine = _003C_003E4__this.AnimateSingleTextObject(chestWindowUi.t_itemDesc, 0.35f);
					Coroutine coroutine = _003C_003E4__this.StartCoroutine(routine);
					_003C_003E2__current = coroutine;
					_003C_003E1__state = 2;
					result = true;
				}
				return result;
			}
			_003C_003E1__state = -1;
			if ((object)_003C_003E4__this != null && (object)chestWindowUi.itemData != null)
			{
				string name = chestWindowUi.itemData.GetName();
				if ((object)chestWindowUi.t_itemName != null)
				{
					chestWindowUi.t_itemName.text = name;
					if ((object)chestWindowUi.itemData != null)
					{
						string description = chestWindowUi.itemData.GetDescription();
						if ((object)chestWindowUi.t_itemDesc != null)
						{
							chestWindowUi.t_itemDesc.text = description;
							ItemData itemData = chestWindowUi.itemData;
							if ((object)chestWindowUi.itemData != null)
							{
								string rarity = LocalizationUtility.GetRarity(itemData.rarity);
								if ((object)chestWindowUi.t_itemRarity != null)
								{
									chestWindowUi.t_itemRarity.text = rarity;
									ItemData itemData2 = chestWindowUi.itemData;
									if ((object)chestWindowUi.itemData != null)
									{
										Color itemRarityColor = MyColorUtility.GetItemRarityColor(itemData2.rarity);
										if ((object)chestWindowUi.t_itemRarity != null)
										{
											object obj2 = default(object);
											chestWindowUi.t_itemRarity.color = (Color)(&obj2);
											IEnumerator routine2 = _003C_003E4__this.AnimateSingleTextObject(chestWindowUi.t_itemRarity, 0.35f);
											Coroutine coroutine2 = _003C_003E4__this.StartCoroutine(routine2);
											IEnumerator routine3 = _003C_003E4__this.AnimateSingleTextObject(chestWindowUi.t_itemName, 0.35f);
											Coroutine coroutine3 = _003C_003E4__this.StartCoroutine(routine3);
											WaitForSeconds waitForSeconds = new WaitForSeconds(0.25f);
											_003C_003E2__current = waitForSeconds;
											_003C_003E1__state = 1;
											return true;
										}
									}
								}
							}
						}
					}
				}
			}
			goto IL_036d;
			IL_036d:
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		void IEnumerator.Reset()
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802696E0");
			NotSupportedException ex = new NotSupportedException();
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802696E0");
			throw ex;
		}
	}

	public TextMeshProUGUI t_itemName;

	public TextMeshProUGUI t_itemDesc;

	public TextMeshProUGUI t_itemRarity;

	public ChestOpening chestOpening;

	public LevelupScreen levelupScreen;

	public MyButtonOffersUtility b_banish;

	public MyButton b_open;

	public MyButton b_leave;

	public MyButton b_take;

	public ItemData itemData;

	public Window window;

	public static Action A_Open;

	public static Action A_Close;

	private EChest chestType;

	private void Awake()
	{
		//IL_00b2: Expected I, but got O
		//IL_008a: Expected I, but got O
		Action<ItemData> b = OpeningFinished;
		Delegate obj = Delegate.Combine(ChestOpening.A_ChestFinished, b);
		if ((object)obj == null)
		{
			ChestOpening.A_ChestFinished = (Action<ItemData>)obj;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<ItemData> action = default(Action<ItemData>);
		if (action != null)
		{
			ChestOpening.A_ChestFinished = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj2 = default(object);
			bool flag = obj2 == null;
			nint num = (nint)typeof(Action<ItemData>);
			if (!flag)
			{
				return;
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
			nint num = (nint)typeof(Action<ItemData>);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
	}

	private void OnDestroy()
	{
		//IL_00b2: Expected I, but got O
		//IL_008a: Expected I, but got O
		Action<ItemData> value = OpeningFinished;
		Delegate obj = Delegate.Remove(ChestOpening.A_ChestFinished, value);
		if ((object)obj == null)
		{
			ChestOpening.A_ChestFinished = (Action<ItemData>)obj;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<ItemData> action = default(Action<ItemData>);
		if (action != null)
		{
			ChestOpening.A_ChestFinished = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj2 = default(object);
			bool flag = obj2 == null;
			nint num = (nint)typeof(Action<ItemData>);
			if (!flag)
			{
				return;
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
			nint num = (nint)typeof(Action<ItemData>);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
	}

	public override void Open(EEncounter encounterType)
	{
		GameObject gameObject = chestOpening.gameObject;
		gameObject.SetActive(value: true);
		GameObject gameObject2 = base.gameObject;
		gameObject2.SetActive(value: true);
		EChest chest = (chestType = ChestUtility.EncounterToChestType(encounterType));
		chestOpening.SetChest(chest);
		GameObject gameObject3 = b_take.gameObject;
		gameObject3.SetActive(value: false);
		GameObject gameObject4 = b_leave.gameObject;
		gameObject4.SetActive(value: false);
		GameObject gameObject5 = b_open.gameObject;
		gameObject5.SetActive(value: false);
		GameObject gameObject6 = b_banish.gameObject;
		gameObject6.SetActive(value: false);
		t_itemName.CrossFadeAlpha(0f, 0f, ignoreTimeScale: true);
		t_itemDesc.CrossFadeAlpha(0f, 0f, ignoreTimeScale: true);
		t_itemRarity.CrossFadeAlpha(0f, 0f, ignoreTimeScale: true);
		ControllerShaker.Shake(0, 0.4f, 0.35f);
		Invoke("ShowOpenButton", 0.35f);
		Action a_Open = A_Open;
		if (A_Open != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v318.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
		}
	}

	private void ShowOpenButton()
	{
		GameObject gameObject = b_open.gameObject;
		gameObject.SetActive(value: true);
	}

	public override void OnClose()
	{
		GameObject gameObject = base.gameObject;
		gameObject.SetActive(value: false);
		MyInputManager.RefreshHorizontalNavigationForChests(isChestWindowOpen: false);
		Action a_Close = A_Close;
		if (A_Close != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v68.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
		}
	}

	public override void ChooseOffer(int index)
	{
	}

	private void OpeningFinished(ItemData unused)
	{
		GameObject gameObject = b_take.gameObject;
		gameObject.SetActive(value: true);
		GameObject gameObject2 = b_banish.gameObject;
		gameObject2.SetActive(value: true);
		MyPlayer instance = MyPlayer.Instance;
		PlayerInventory inventory = instance.inventory;
		MyPlayer instance2 = MyPlayer.Instance;
		PlayerInventory inventory2 = instance2.inventory;
		int shopToolPrice = levelupScreen.GetShopToolPrice(inventory2.banishesUsed);
		b_banish.SetAmount(inventory.banishes, shopToolPrice);
		MyButton component = b_take.GetComponent<MyButton>();
		ButtonManager.ForceHoverButton(component);
		ControllerShaker.StopShakes();
		ControllerShaker.Shake(0, 0.7f, 0.25f);
		_003CAnimateText_003Ed__21 obj = new _003CAnimateText_003Ed__21(0);
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		Coroutine coroutine = StartCoroutine(obj);
	}

	private IEnumerator AnimateText()
	{
		_003CAnimateText_003Ed__21 obj = new _003CAnimateText_003Ed__21(0);
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		return obj;
	}

	private IEnumerator AnimateSingleTextObject(TextMeshProUGUI text, float fadeTime)
	{
		_003CAnimateSingleTextObject_003Ed__22 obj = new _003CAnimateSingleTextObject_003Ed__22(0);
		obj._003C_003E1__state = 0;
		obj.text = text;
		obj.fadeTime = fadeTime;
		return obj;
	}

	public void OpenButton()
	{
		float stat = PlayerStats.GetStat(EStat.Luck);
		ItemData randomChestItem = ItemUtility.GetRandomChestItem(chestType, stat);
		itemData = randomChestItem;
		chestOpening.OpenChest(itemData);
		GameObject gameObject = b_open.gameObject;
		gameObject.SetActive(value: false);
		ButtonManager.SetNull();
		SelectionArrow.Instance.Hide();
		MyInputManager.RefreshHorizontalNavigationForChests(isChestWindowOpen: true);
	}

	public void TakeButton()
	{
		MyPlayer instance = MyPlayer.Instance;
		PlayerInventory inventory = instance.inventory;
		ItemData itemData = this.itemData;
		inventory.itemInventory.AddItem(itemData.eItem);
		UiManager instance2 = UiManager.Instance;
		instance2.encounterWindows.RewardFinished();
	}

	public unsafe void DiscardButton()
	{
		//IL_006a: Expected O, but got Ref
		//IL_006a: Expected O, but got Ref
		EffectManager instance = EffectManager.Instance;
		Transform transform = MyPlayer.Instance.transform;
		Vector3 position = transform.position;
		Transform transform2 = MyPlayer.Instance.transform;
		Vector3 up = transform2.up;
		object obj = default(object);
		object obj2 = default(object);
		GameObject gameObject = UnityEngine.Object.Instantiate(instance.chestDiscard, (Vector3)(&obj), (Quaternion)(&obj2));
		UiManager instance2 = UiManager.Instance;
		instance2.encounterWindows.RewardFinished();
	}

	public unsafe void BanishButton()
	{
		//IL_01a8: Expected O, but got Ref
		//IL_01a8: Expected O, but got Ref
		//IL_008c: Invalid comparison between I4 and F4
		MyPlayer instance = MyPlayer.Instance;
		PlayerInventory inventory = instance.inventory;
		if (inventory.banishes > 0)
		{
			MyPlayer instance2 = MyPlayer.Instance;
			PlayerInventory inventory2 = instance2.inventory;
			int banishesUsed = levelupScreen.GetBanishesUsed();
			int shopToolPrice = levelupScreen.GetShopToolPrice(banishesUsed);
			if (!((float)shopToolPrice > inventory2._003Cgold_003Ek__BackingField))
			{
				MyPlayer instance3 = MyPlayer.Instance;
				int banishesUsed2 = levelupScreen.GetBanishesUsed();
				int shopToolPrice2 = levelupScreen.GetShopToolPrice(banishesUsed2);
				int amount = -shopToolPrice2;
				instance3.inventory.ChangeGold(amount);
				RunUnlockables.BanishItem(itemData);
				levelupScreen.DecrementBanishes();
				UiManager instance4 = UiManager.Instance;
				instance4.encounterWindows.RewardFinished();
				EffectManager.Instance.BanishItem(itemData);
				return;
			}
		}
		AlwaysUi instance5 = AlwaysUi.Instance;
		string localizedString = LocalizationUtility.GetLocalizedString("PopupText", "NO_BANISHES");
		Transform transform = b_banish.transform;
		Vector3 position = transform.position;
		object obj = default(object);
		object obj2 = default(object);
		float desiredScale = default(float);
		instance5.UiTextPopup.SetText(localizedString, (Vector3)(&obj), (Color)(&obj2), desiredScale);
	}
}
