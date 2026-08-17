using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Assets.Scripts.Actors.Player;
using Assets.Scripts.Inventory__Items__Pickups;
using Assets.Scripts.Inventory__Items__Pickups.GoldAndMoney;
using Assets.Scripts.Inventory__Items__Pickups.Items;
using Assets.Scripts.UI.InGame.Rewards;
using Assets.Scripts.UI.Localization;
using Assets.Scripts.Utility;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UI;
using Utility;

public class InteractableMicrowave : BaseInteractable
{
	private sealed class _003CCookItem_003Ed__36 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public InteractableMicrowave _003C_003E4__this;

		public EItem itemToCreate;

		private float _003Ctimer_003E5__2;

		private float _003CcookTime_003E5__3;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		public _003CCookItem_003Ed__36(int _003C_003E1__state)
		{
			((IDisposable)this).Dispose();
			this._003C_003E1__state = _003C_003E1__state;
		}

		void IDisposable.Dispose()
		{
		}

		private unsafe bool MoveNext()
		{
			//IL_0014: Expected I4, but got I8
			//IL_0539: Expected I4, but got I8
			//IL_00f3: Expected O, but got I4
			//IL_05a2: Expected O, but got Ref
			//IL_010f: Expected O, but got I4
			//IL_012f: Expected O, but got I4
			//IL_08d0: Expected O, but got Ref
			//IL_01a7: Expected O, but got I4
			//IL_031d: Expected O, but got Ref
			//IL_039e: Unsupported input type for neg.
			//IL_039e: Unknown result type (might be due to invalid IL or missing references)
			//IL_03a3: Expected I4, but got Unknown
			//IL_04e9: Expected O, but got I4
			InteractableMicrowave interactableMicrowave = _003C_003E4__this;
			if (_003C_003E1__state == 0)
			{
				_003C_003E1__state = -1;
				bool flag = (object)_003C_003E4__this == null;
				_003CCookItem_003Ed__36 obj = this;
				if (!flag)
				{
					int num = interactableMicrowave._003CusesLeft_003Ek__BackingField - 1;
					interactableMicrowave._003CusesLeft_003Ek__BackingField = num;
					List<EItem> list = new List<EItem>();
					obj = (_003CCookItem_003Ed__36)(object)list;
					MyPlayer instance = MyPlayer.Instance;
					if ((object)MyPlayer.Instance != null)
					{
						PlayerInventory inventory = instance.inventory;
						if (instance.inventory != null)
						{
							obj = (_003CCookItem_003Ed__36)(object)inventory.itemInventory;
							if (inventory.itemInventory != null)
							{
								bool flag2 = obj._003C_003E1__state == 0;
								obj = (_003CCookItem_003Ed__36)obj._003C_003E1__state;
								if (!flag2)
								{
									Dictionary<EItem, ItemBase>.KeyCollection keys = ((Dictionary<EItem, ItemBase>)obj._003C_003E1__state).Keys;
									bool flag3 = keys == null;
									obj = (_003CCookItem_003Ed__36)obj._003C_003E1__state;
									if (!flag3)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AEBE40");
										Dictionary<EItem, ItemBase>.KeyCollection.Enumerator enumerator = default(Dictionary<EItem, ItemBase>.KeyCollection.Enumerator);
										EItem eItem = default(EItem);
										while (enumerator.MoveNext())
										{
											if ((object)DataManager.Instance != null)
											{
												ItemData item = DataManager.Instance.GetItem(eItem);
												if ((object)item != null)
												{
													obj = (_003CCookItem_003Ed__36)interactableMicrowave._003Crarity_003Ek__BackingField;
													if (item.rarity == interactableMicrowave._003Crarity_003Ek__BackingField && eItem != itemToCreate)
													{
														if (list == null)
														{
															throw new NullReferenceException();
														}
														list.Add(eItem);
													}
													continue;
												}
												throw new NullReferenceException();
											}
											throw new NullReferenceException();
										}
										enumerator.Dispose();
										obj = (_003CCookItem_003Ed__36)(&enumerator);
										if (list != null && MyRandom.random != null)
										{
											int index = (((_003CCookItem_003Ed__36)(object)MyRandom.random).MoveNext() ? 1 : 0);
											EItem eItem2 = list.get_Item(index);
											MyPlayer instance2 = MyPlayer.Instance;
											if ((object)MyPlayer.Instance != null)
											{
												PlayerInventory inventory2 = instance2.inventory;
												if (instance2.inventory != null && inventory2.itemInventory != null)
												{
													inventory2.itemInventory.RemoveItem(eItem2, showEffect: false);
													if ((object)DataManager.Instance != null)
													{
														ItemData item2 = DataManager.Instance.GetItem(eItem2);
														if ((object)EffectManager.Instance != null)
														{
															Vector3 vector = default(Vector3);
															float hoverTime = default(float);
															float moveTime = default(float);
															float scale = default(float);
															EffectManager.Instance.TakeItem(item2, interactableMicrowave.microwaveCenterTransform, (Vector3)(&vector), hoverTime, moveTime, scale);
															MyPlayer instance3 = MyPlayer.Instance;
															if ((object)MyPlayer.Instance != null)
															{
																int chestPrice = MoneyUtility.GetChestPrice();
																float num2 = (float)chestPrice * 0.34f;
																Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331070");
																bool flag4 = instance3.inventory == null;
																obj = null;
																if (!flag4)
																{
																	object obj2 = default(object);
																	int amount = 0 - obj2;
																	instance3.inventory.ChangeGold(amount);
																	interactableMicrowave._003CisCooking_003Ek__BackingField = true;
																	if ((object)interactableMicrowave.sfxStart != null)
																	{
																		interactableMicrowave.sfxStart.Play();
																		if ((object)interactableMicrowave.animator != null)
																		{
																			interactableMicrowave.animator.Play("Start");
																			if ((object)interactableMicrowave.exclamationMark != null)
																			{
																				interactableMicrowave.exclamationMark.SetActive(value: false);
																				if ((object)interactableMicrowave.cookingParticles != null)
																				{
																					interactableMicrowave.cookingParticles.SetActive(value: true);
																					if ((object)interactableMicrowave.progressBar != null)
																					{
																						interactableMicrowave.progressBar.SetActive(value: true);
																						_003Ctimer_003E5__2 = 0f;
																						object obj3 = (int)interactableMicrowave._003Crarity_003Ek__BackingField + (int)interactableMicrowave._003Crarity_003Ek__BackingField;
																						float num3 = (float)obj3 + 4f;
																						_003CcookTime_003E5__3 = num3;
																						goto IL_093e;
																					}
																				}
																			}
																		}
																	}
																}
															}
														}
													}
												}
											}
										}
									}
								}
							}
						}
					}
				}
				goto IL_0818;
			}
			if (_003C_003E1__state != 1)
			{
				goto IL_080a;
			}
			_003C_003E1__state = -1;
			goto IL_093e;
			IL_080a:
			return false;
			IL_0818:
			throw new NullReferenceException();
			IL_093e:
			if (!(_003CcookTime_003E5__3 > _003Ctimer_003E5__2))
			{
				if ((object)_003C_003E4__this != null)
				{
					interactableMicrowave._003CisCooking_003Ek__BackingField = false;
					interactableMicrowave.hasItem = true;
					interactableMicrowave.newItem = itemToCreate;
					if ((object)interactableMicrowave.sfxFinish != null)
					{
						interactableMicrowave.sfxFinish.Play();
						if ((object)interactableMicrowave.sfxStart != null)
						{
							interactableMicrowave.sfxStart.Stop();
							if ((object)interactableMicrowave.animator != null)
							{
								interactableMicrowave.animator.Play("Finish");
								if ((object)DataManager.Instance != null)
								{
									ItemData item3 = DataManager.Instance.GetItem(interactableMicrowave.newItem);
									if ((object)item3 != null && (object)interactableMicrowave.itemIcon != null)
									{
										interactableMicrowave.itemIcon.texture = item3.icon;
										if ((object)interactableMicrowave.particles != null)
										{
											interactableMicrowave.particles.SetActive(value: true);
											if ((object)interactableMicrowave.exclamationMark != null)
											{
												interactableMicrowave.exclamationMark.SetActive(value: true);
												if ((object)interactableMicrowave.cookingParticles != null)
												{
													interactableMicrowave.cookingParticles.SetActive(value: false);
													if ((object)interactableMicrowave.progressBar != null)
													{
														interactableMicrowave.progressBar.SetActive(value: false);
														goto IL_080a;
													}
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
			else
			{
				float num4 = _003Ctimer_003E5__2 + MyTime.deltaTime;
				_003Ctimer_003E5__2 = num4;
				if ((object)_003C_003E4__this != null && (object)interactableMicrowave.progressBarProgress != null)
				{
					Transform transform = interactableMicrowave.progressBarProgress.transform;
					if ((object)transform != null)
					{
						float num5 = default(float);
						transform.localScale = (Vector3)(&num5);
						_003C_003E2__current = null;
						_003C_003E1__state = 1;
						return true;
					}
				}
			}
			goto IL_0818;
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

	public Material matCommon;

	public Material matRare;

	public Material matEpic;

	public Material matLegendary;

	public Renderer meshRenderer;

	private EItemRarity _003Crarity_003Ek__BackingField;

	private int _003CusesLeft_003Ek__BackingField;

	public static InteractableMicrowave currentlyInteracting;

	private bool _003CisCooking_003Ek__BackingField;

	public Animator animator;

	public AudioSource sfxStart;

	public AudioSource sfxFinish;

	public GameObject particles;

	public GameObject explosion;

	public RawImage itemIcon;

	public Transform microwaveCenterTransform;

	public GameObject exclamationMark;

	public GameObject progressBar;

	public GameObject minimapIcon;

	public GameObject cookingParticles;

	public RawImage progressBarProgress;

	public static Action<EItem> A_Used;

	public static Action A_Exploded;

	private float readyAtTime;

	private bool hasItem;

	private EItem newItem;

	public static string debugName = "Microwaves";

	public EItemRarity rarity
	{
		get
		{
			return _003Crarity_003Ek__BackingField;
		}
		private set
		{
			_003Crarity_003Ek__BackingField = value;
		}
	}

	public int usesLeft
	{
		get
		{
			return _003CusesLeft_003Ek__BackingField;
		}
		private set
		{
			_003CusesLeft_003Ek__BackingField = value;
		}
	}

	public bool isCooking
	{
		get
		{
			return _003CisCooking_003Ek__BackingField;
		}
		private set
		{
			_003CisCooking_003Ek__BackingField = value;
		}
	}

	private new void Start()
	{
		//IL_004c: Expected O, but got I4
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Expected O, but got Unknown
		//IL_013d: Expected O, but got I4
		//IL_0154: Unknown result type (might be due to invalid IL or missing references)
		//IL_0159: Expected I4, but got Unknown
		base.Start();
		EItemRarity eItemRarity = (_003Crarity_003Ek__BackingField = Rarity.GetShadyGuyRarity(0f, new float[4] { 0.75f, 0.15f, 0.075f, 0.025f }));
		bool flag = eItemRarity == EItemRarity.Common;
		Renderer renderer;
		Material material;
		if (!flag)
		{
			object obj = eItemRarity - 1;
			if (!flag)
			{
				object obj2 = obj - 1;
				if (!flag)
				{
					if ((nint)obj2 != 1)
					{
						goto IL_010e;
					}
					renderer = meshRenderer;
					material = matLegendary;
				}
				else
				{
					renderer = meshRenderer;
					material = matEpic;
				}
			}
			else
			{
				renderer = meshRenderer;
				material = matRare;
			}
		}
		else
		{
			renderer = meshRenderer;
			material = matCommon;
		}
		renderer.SetMaterial(material);
		goto IL_010e;
		IL_010e:
		bool flag2 = _003Crarity_003Ek__BackingField == EItemRarity.Common;
		if (!flag2)
		{
			object obj3 = _003Crarity_003Ek__BackingField - 1;
			if (!flag2)
			{
				int num = obj3 - 1;
				if (!flag2)
				{
					if (num == 1)
					{
						_003CusesLeft_003Ek__BackingField = num;
						return;
					}
					goto IL_019e;
				}
			}
			_003CusesLeft_003Ek__BackingField = 2;
			return;
		}
		goto IL_019e;
		IL_019e:
		_003CusesLeft_003Ek__BackingField = 3;
	}

	public unsafe override bool Interact()
	{
		//IL_03c9: Expected I4, but got O
		//IL_0095: Invalid comparison between O and F4
		//IL_028d: Expected O, but got Ref
		//IL_028d: Expected O, but got Ref
		UiTextPopup uiTextPopup;
		string text;
		if (!_003CisCooking_003Ek__BackingField)
		{
			if (hasItem)
			{
				hasItem = false;
				float num = MyTime.time + 0.5f;
				readyAtTime = num;
				MyPlayer instance = MyPlayer.Instance;
				if ((object)MyPlayer.Instance != null)
				{
					PlayerInventory inventory = instance.inventory;
					if (instance.inventory != null && inventory.itemInventory != null)
					{
						inventory.itemInventory.AddItem(newItem);
						if ((object)animator != null)
						{
							animator.Play("Idle");
							if ((object)particles != null)
							{
								particles.SetActive(value: false);
								if (_003CusesLeft_003Ek__BackingField <= 0)
								{
									Invoke("Explode", 0.5f);
								}
								return true;
							}
						}
					}
				}
			}
			else
			{
				MyPlayer instance2 = MyPlayer.Instance;
				if ((object)MyPlayer.Instance != null)
				{
					PlayerInventory inventory2 = instance2.inventory;
					if (instance2.inventory != null)
					{
						int chestPrice = MoneyUtility.GetChestPrice();
						float num2 = (float)chestPrice * 0.34f;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331070");
						object obj = default(object);
						if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)inventory2._003Cgold_003Ek__BackingField))
						{
							AlwaysUi instance3 = AlwaysUi.Instance;
							if ((object)AlwaysUi.Instance != null)
							{
								uiTextPopup = instance3.UiTextPopup;
								string localizedString = LocalizationUtility.GetLocalizedString("PopupText", "CANT_AFFORD");
								text = localizedString;
								goto IL_046b;
							}
						}
						else
						{
							MyPlayer instance4 = MyPlayer.Instance;
							if ((object)MyPlayer.Instance != null)
							{
								PlayerInventory inventory3 = instance4.inventory;
								if (instance4.inventory != null && inventory3.itemInventory != null)
								{
									int uniqueItemsInRarity = inventory3.itemInventory.GetUniqueItemsInRarity(_003Crarity_003Ek__BackingField);
									if (uniqueItemsInRarity <= 1)
									{
										Dictionary<string, string> dictionary = new Dictionary<string, string>();
										string value = LocalizationUtility.GetRarity(_003Crarity_003Ek__BackingField);
										if (dictionary != null)
										{
											((Dictionary<object, object>)(object)dictionary).Add((object)"rarity", (object)value);
											string localizedString2 = LocalizationUtility.GetLocalizedString("PopupText", "MICROWAVE_NEED_RARITY", dictionary);
											AlwaysUi instance5 = AlwaysUi.Instance;
											if ((object)AlwaysUi.Instance != null)
											{
												uiTextPopup = instance5.UiTextPopup;
												text = localizedString2;
												goto IL_046b;
											}
										}
									}
									else
									{
										currentlyInteracting = this;
										UiManager instance6 = UiManager.Instance;
										if ((object)UiManager.Instance != null && (object)instance6.encounterWindows != null)
										{
											instance6.encounterWindows.AddEncounter(EEncounter.Microwave);
											goto IL_0292;
										}
									}
								}
							}
						}
					}
				}
			}
			goto IL_03bb;
		}
		return false;
		IL_0292:
		return false;
		IL_046b:
		int width = Screen.width;
		int height = Screen.height;
		if ((object)uiTextPopup != null)
		{
			object obj2 = default(object);
			object obj3 = default(object);
			float desiredScale = default(float);
			uiTextPopup.SetText(text, (Vector3)(&obj2), (Color)(&obj3), desiredScale);
			goto IL_0292;
		}
		goto IL_03bb;
		IL_03bb:
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	public void UseMicrowave(EItem eItemToCreate)
	{
		_003CCookItem_003Ed__36 obj = new _003CCookItem_003Ed__36(0);
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		obj.itemToCreate = eItemToCreate;
		Coroutine coroutine = StartCoroutine(obj);
		Action<EItem> a_Used = A_Used;
		if (A_Used != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v77 @ r9_v1 (System.Action`1<Assets.Scripts.Inventory__Items__Pickups.Items.EItem>)+18] (should have been resolved before IL gen)");
		}
	}

	private IEnumerator CookItem(EItem itemToCreate)
	{
		_003CCookItem_003Ed__36 obj = new _003CCookItem_003Ed__36(0);
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		obj.itemToCreate = itemToCreate;
		return obj;
	}

	private float GetCookTime()
	{
		//IL_0011: Expected O, but got I4
		object obj = (int)_003Crarity_003Ek__BackingField + (int)_003Crarity_003Ek__BackingField;
		return (float)obj + 4f;
	}

	private void Explode()
	{
		exclamationMark.SetActive(value: false);
		explosion.SetActive(value: true);
		animator.Play("Explode");
		minimapIcon.SetActive(value: false);
		Action a_Exploded = A_Exploded;
		if (A_Exploded != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v101.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
		}
	}

	public override bool CanInteract()
	{
		//IL_00a8: Invalid comparison between F4 and I4
		if (!hasItem)
		{
			if (_003CusesLeft_003Ek__BackingField <= 0 || _003CisCooking_003Ek__BackingField)
			{
				return false;
			}
			bool flag = MyTime.time < readyAtTime;
			float num = MyTime.time - readyAtTime;
			bool flag2 = num == 0f;
			bool flag3 = !flag;
			bool flag4 = !flag2;
			return flag4 & flag3;
		}
		return true;
	}

	public unsafe override string GetInteractString()
	{
		//IL_0094: Expected O, but got Ref
		if (!hasItem)
		{
			string localizedString = LocalizationUtility.GetLocalizedString("Game_Interactables", "MICROWAVE_USE");
			int chestPrice = MoneyUtility.GetChestPrice();
			float num = (float)chestPrice * 0.34f;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331070");
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
			object arg = default(object);
			string text = $" | <sprite name=gold>{arg}";
			return localizedString + text;
		}
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		IntPtr intPtr = default(IntPtr);
		string s = ((Enum)(&intPtr)).ToString();
		string value = EnumUtility.EnumToReadable(s);
		if (dictionary != null)
		{
			((Dictionary<object, object>)(object)dictionary).Add((object)"item", (object)value);
			return LocalizationUtility.GetLocalizedString("Game_Interactables", "MICROWAVE_TAKE", dictionary);
		}
		return (string)(object)new NullReferenceException();
	}

	public int GetPrice()
	{
		int chestPrice = MoneyUtility.GetChestPrice();
		float num = (float)chestPrice * 0.34f;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331070");
		int result = default(int);
		return result;
	}

	private int GetUses(EItemRarity itemRarity)
	{
		//IL_002b: Expected O, but got I4
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Expected I4, but got Unknown
		bool flag = itemRarity == EItemRarity.Common;
		if (!flag)
		{
			object obj = itemRarity - 1;
			if (!flag)
			{
				int num = obj - 1;
				if (!flag)
				{
					if (num == 1)
					{
						return num;
					}
					goto IL_0080;
				}
			}
			return 2;
		}
		goto IL_0080;
		IL_0080:
		return 3;
	}

	public override bool ShowInDebug()
	{
		return true;
	}

	public override string GetDebugName()
	{
		return debugName;
	}

	public InteractableMicrowave()
	{
		showOutline = true;
		((MonoBehaviour)this)._002Ector();
	}
}
