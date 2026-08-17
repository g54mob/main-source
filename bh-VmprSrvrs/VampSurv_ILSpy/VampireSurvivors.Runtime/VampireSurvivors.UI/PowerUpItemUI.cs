using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using I2.Loc;
using TMPro;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.UI;
using VampireSurvivors.Data;
using VampireSurvivors.Data.PowerUp;
using VampireSurvivors.Graphics;

namespace VampireSurvivors.UI;

public class PowerUpItemUI : SelectableUI
{
	private Localize Title;

	private Image Icon;

	private GameObject UpgradeSlotPrefab;

	private RectTransform Container;

	private Button Clicker;

	private Image Background;

	private Image Frame;

	private Color MaxColor;

	public PowerUpData _data;

	public PowerUpType _type;

	public PowerUpsPage _page;

	private int _currentLevel;

	private int _maxRank;

	private List<GameObject> _spawnedSlots;

	public unsafe void SetData(PowerUpData data, PowerUpType type, PowerUpsPage page, int currentLevel, int maxRank)
	{
		//IL_01bb: Expected I, but got O
		//IL_08e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_08eb: Expected O, but got Unknown
		//IL_0875: Unknown result type (might be due to invalid IL or missing references)
		//IL_087a: Expected O, but got Unknown
		//IL_03e1: Expected I, but got O
		//IL_040e: Expected O, but got I
		//IL_042c: Expected I, but got O
		//IL_044f: Expected O, but got I
		//IL_0596: Expected O, but got Ref
		//IL_069f: Expected O, but got I
		//IL_06de: Expected O, but got I
		//IL_0772: Expected O, but got I
		//IL_0bdb: Expected O, but got I
		//IL_049e->IL04bf: Incompatible stack heights: 1 vs 0
		//IL_04a3->IL04a3: Incompatible stack heights: 1 vs 0
		//IL_0a1d->IL0806: Incompatible stack heights: 1 vs 0
		//IL_06fe->IL0806: Incompatible stack heights: 1 vs 0
		//IL_0a71->IL0806: Incompatible stack heights: 2 vs 0
		//IL_0ad0->IL0806: Incompatible stack heights: 3 vs 0
		//IL_0b30->IL0806: Incompatible stack heights: 4 vs 0
		//IL_0b90->IL0806: Incompatible stack heights: 5 vs 0
		//IL_0750->IL0806: Incompatible stack heights: 5 vs 0
		//IL_0792->IL0806: Incompatible stack heights: 5 vs 0
		//IL_0bfb->IL0806: Incompatible stack heights: 6 vs 0
		//IL_0c49->IL0806: Incompatible stack heights: 7 vs 0
		//IL_07ec->IL0806: Incompatible stack heights: 8 vs 0
		_data = data;
		_type = type;
		_page = page;
		int num = default(int);
		_currentLevel = num;
		int num2 = default(int);
		_maxRank = num2;
		if (_data != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A2C7B]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			string prefix = _data.GetPrefix(_type);
			string term = prefix + "name";
			if ((object)Title != null)
			{
				Title.Term = term;
				PowerUpData data2 = _data;
				if (_data != null && data != null)
				{
					Sprite sprite = SpriteManager.GetSprite(data2._003CframeName_003Ek__BackingField, data._003Ctexture_003Ek__BackingField);
					if ((object)Icon != null)
					{
						Icon.sprite = sprite;
						GameObject gameObject = base.gameObject;
						if ((object)Title != null)
						{
							TextMeshProUGUI component = Title.GetComponent<TextMeshProUGUI>();
							if ((object)component != null)
							{
								string text = component.text;
								if ((object)gameObject != null)
								{
									((UnityEngine.Object)gameObject).SetName(text);
									bool flag = num2 <= 0;
									nint num3 = unchecked((nint)null);
									if (flag)
									{
										goto IL_030e;
									}
									while (true)
									{
										GameObject gameObject2 = UnityEngine.Object.Instantiate(UpgradeSlotPrefab, Container);
										if (_spawnedSlots == null)
										{
											break;
										}
										GameObject gameObject3 = UnityEngine.Object.Instantiate((GameObject)(object)_spawnedSlots, (Transform)(object)gameObject2);
										if (num3 < _currentLevel)
										{
											if ((object)gameObject2 == null)
											{
												break;
											}
											Transform transform = gameObject2.transform;
											if ((object)transform == null)
											{
												break;
											}
											Transform child = transform.GetChild(0);
											if ((object)child == null)
											{
												break;
											}
											GameObject gameObject4 = child.gameObject;
											if ((object)gameObject4 == null)
											{
												break;
											}
											gameObject4.SetActive(value: true);
										}
										num3++;
										if (num3 >= num2)
										{
											goto IL_030e;
										}
									}
								}
							}
						}
					}
				}
			}
		}
		goto IL_0806;
		IL_0806:
		throw new NullReferenceException();
		IL_08ad:
		CheckMaxedOut();
		GridLayoutGroup component3;
		CenterGridLayoutGroup component2 = component3.GetComponent<CenterGridLayoutGroup>();
		if ((object)component2 != null)
		{
			component2.Update();
			if ((object)Title != null)
			{
				TextMeshProUGUI component4 = Title.GetComponent<TextMeshProUGUI>();
				bool flag2 = num > 0;
				string hex = "0xffffff";
				if (!flag2)
				{
					hex = "0x444444";
				}
				Color color = ColourHelper.HexToColor(hex);
				if ((object)component4 != null)
				{
					Rect ret = default(Rect);
					component4.color = (Color)(&ret);
					if ((object)Title != null)
					{
						TextMeshProUGUI component5 = Title.GetComponent<TextMeshProUGUI>();
						if ((object)component5 != null)
						{
							float num4 = UIHelper.JS_MAGIC_SCALE_NUMBER * 6f;
							bool flag3 = ((TMP_Text)component5).m_fontSize == num4;
							Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000186D5E6E0h\"");
							if (!flag3)
							{
								((TMP_Text)component5).m_fontSize = num4;
								((TMP_Text)component5).m_havePropertiesChanged = true;
								if (!((TMP_Text)component5).m_enableAutoSizing)
								{
									((TMP_Text)component5).m_fontSizeBase = num4;
								}
								component5.SetVerticesDirty();
								component5.SetLayoutDirty();
							}
							if ((object)Icon != null)
							{
								RectTransform rectTransform = Icon.rectTransform;
								PowerUpData icon = (PowerUpData)(object)Icon;
								if ((object)Icon != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v465 @ rdi_v30 (VampireSurvivors.Data.PowerUp.PowerUpData)+E0]");
									object obj = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v465 @ rdi_v30 (VampireSurvivors.Data.PowerUp.PowerUpData)+E0]");
									if ((nint)0 != 0)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v466 @ rdi_v31 (System.Object)+10]");
										bool flag4 = (nint)0 == 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v466 @ rdi_v31 (System.Object)+10]");
										Sprite.get_rect_Injected((IntPtr)0, out Rect ret2);
										PowerUpData icon2 = (PowerUpData)(object)Icon;
										if ((object)Icon != null)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v472 @ rdi_v32 (VampireSurvivors.Data.PowerUp.PowerUpData)+E0]");
											object obj2 = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v472 @ rdi_v32 (VampireSurvivors.Data.PowerUp.PowerUpData)+E0]");
											if ((nint)0 != 0)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v467 @ rdi_v33 (System.Object)+10]");
												bool flag5 = (nint)0 == 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v467 @ rdi_v33 (System.Object)+10]");
												Sprite.get_rect_Injected((IntPtr)0, out ret);
												if ((object)rectTransform != null)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v384 @ rax_v91 (UnityEngine.RectTransform)+10]");
													bool flag6 = (nint)0 == 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v384 @ rax_v91 (UnityEngine.RectTransform)+10]");
													Vector2 value = default(Vector2);
													RectTransform.set_sizeDelta_Injected((IntPtr)0, ref value);
													object icon3 = Icon;
													if ((object)Icon != null)
													{
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v473 @ rdi_v35 (System.Object)+10]");
														bool flag7 = (nint)0 == 0;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v473 @ rdi_v35 (System.Object)+10]");
														IntPtr gcHandlePtr = Component.get_transform_Injected((IntPtr)0);
														Transform transform2 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr);
														if ((object)transform2 != null)
														{
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v386 @ rax_v108 (UnityEngine.Transform)+10]");
															bool flag8 = (nint)0 == 0;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v386 @ rax_v108 (UnityEngine.Transform)+10]");
															IntPtr parent_Injected = Transform.GetParent_Injected((IntPtr)0);
															Transform transform3 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(parent_Injected);
															if ((object)transform3 != null)
															{
																Image component6 = transform3.GetComponent<Image>();
																if ((object)component6 != null)
																{
																	RectTransform rectTransform2 = component6.rectTransform;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v388 @ rax_v114 (UnityEngine.UI.Image)+E0]");
																	object obj3 = 0;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v388 @ rax_v114 (UnityEngine.UI.Image)+E0]");
																	if ((nint)0 != 0)
																	{
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v469 @ rdi_v37 (System.Object)+10]");
																		bool flag9 = (nint)0 == 0;
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v469 @ rdi_v37 (System.Object)+10]");
																		Sprite.get_rect_Injected((IntPtr)0, out ret);
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v388 @ rax_v114 (UnityEngine.UI.Image)+E0]");
																		PowerUpData powerUpData = (PowerUpData)0;
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v388 @ rax_v114 (UnityEngine.UI.Image)+E0]");
																		if ((nint)0 != 0)
																		{
																			bool flag10 = powerUpData._003Clevel_003Ek__BackingField == 0;
																			Sprite.get_rect_Injected((IntPtr)powerUpData._003Clevel_003Ek__BackingField, out ret2);
																			if ((object)rectTransform2 != null)
																			{
																				bool flag11 = ((UnityEngine.Object)rectTransform2).m_CachedPtr == (IntPtr)0;
																				RectTransform.set_sizeDelta_Injected(((UnityEngine.Object)rectTransform2).m_CachedPtr, ref value);
																				if (!data._003CisSpecial_003Ek__BackingField)
																				{
																					return;
																				}
																				Sprite sprite2 = SpriteManager.GetSprite("frameE", "UI");
																				if ((object)Frame != null)
																				{
																					Frame.sprite = sprite2;
																					return;
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
		}
		goto IL_0806;
		IL_04bf:
		if ((object)Container != null)
		{
			CenterGridLayoutGroup component7 = Container.GetComponent<CenterGridLayoutGroup>();
			if ((object)component7 != null)
			{
				component7._MaxWidth = 75f;
				goto IL_08ad;
			}
		}
		goto IL_0806;
		IL_030e:
		if ((object)Container != null)
		{
			component3 = Container.GetComponent<GridLayoutGroup>();
			List<GameObject> spawnedSlots = _spawnedSlots;
			if (_spawnedSlots != null && (object)component3 != null)
			{
				if (spawnedSlots._size > 5)
				{
					object obj4 = component3 + 104;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A903E0");
					nint num5 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v451 @ rsi_v33 (Il2CppMethodInfo)+38]");
					if ((nint)0 == 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
					}
					nint num6 = (nint)(object)(nint)num;
					if (num6 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996AEB8]");
						object obj5 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996AEB8]");
						bool flag12 = num6 != 0;
						nint num7 = unchecked((nint)null);
						if (!flag12)
						{
							num7 = num6;
						}
						if (num7 != 0)
						{
							object obj6 = num6;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v955 @ rcx_v147+40]");
							nint num8 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v949 @ rdx_v90+40]");
							bool flag13 = num8 != 0;
							int constraintCount = component3.m_ConstraintCount;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1586 @ rax_v163 (Il2CppMethodInfo)+10]");
							if ((nint)constraintCount == 0)
							{
								goto IL_04bf;
							}
						}
					}
					component3.m_ConstraintCount = 5;
					((LayoutGroup)component3).SetDirty();
					goto IL_04bf;
				}
				object obj7 = component3 + 104;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A903E0");
				List<GameObject> spawnedSlots2 = _spawnedSlots;
				if (_spawnedSlots != null)
				{
					component3.constraintCount = spawnedSlots2._size;
					goto IL_08ad;
				}
			}
		}
		goto IL_0806;
	}

	public unsafe void Reset()
	{
		//IL_0056: Expected O, but got Ref
		//IL_01d6->IL01f5: Incompatible stack heights: 7 vs 0
		_currentLevel = 0;
		if (_spawnedSlots != null)
		{
			List<GameObject> spawnedSlots = _spawnedSlots;
			List<GameObject>.Enumerator enumerator = default(List<GameObject>.Enumerator);
			while (enumerator.MoveNext())
			{
				object obj = null;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v173 @ rbx_v16 (System.Object)+10]");
				bool flag = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v173 @ rbx_v16 (System.Object)+10]");
				IntPtr gcHandlePtr = GameObject.get_transform_Injected((IntPtr)0);
				Transform transform = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr);
				bool flag2 = (object)transform == null;
				bool flag3 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				IntPtr child_Injected = Transform.GetChild_Injected(((UnityEngine.Object)transform).m_CachedPtr, 0);
				Transform transform2 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(child_Injected);
				bool flag4 = (object)transform2 == null;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v852 @ rax_v50 (UnityEngine.Transform)+10]");
				bool flag5 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v852 @ rax_v50 (UnityEngine.Transform)+10]");
				IntPtr gcHandlePtr2 = Component.get_gameObject_Injected((IntPtr)0);
				GameObject gameObject = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<GameObject>(gcHandlePtr2);
				bool flag6 = (object)gameObject == null;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v724 @ rax_v55 (UnityEngine.GameObject)+10]");
				bool flag7 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v724 @ rax_v55 (UnityEngine.GameObject)+10]");
				GameObject.SetActive_Injected((IntPtr)0, false);
			}
			if ((object)Background != null)
			{
				Background.color = (Color)(&spawnedSlots);
				return;
			}
		}
		throw new NullReferenceException();
	}

	private void CreateSlot(int i)
	{
		GameObject gameObject = UnityEngine.Object.Instantiate(UpgradeSlotPrefab, Container);
		GameObject gameObject2 = UnityEngine.Object.Instantiate((GameObject)(object)_spawnedSlots, (Transform)(object)gameObject);
		if (i < _currentLevel)
		{
			Transform transform = gameObject.transform;
			Transform child = transform.GetChild(0);
			GameObject gameObject3 = child.gameObject;
			gameObject3.SetActive(value: true);
		}
	}

	public unsafe bool UpdateAfterPurchase()
	{
		//IL_003a: Expected O, but got I4
		//IL_0161: Expected O, but got Ref
		//IL_02d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d6: Expected O, but got Unknown
		//IL_02ef->IL031a: Incompatible stack heights: 11 vs 0
		//IL_02f4->IL00ee: Incompatible stack heights: 11 vs 0
		if (_currentLevel < _maxRank)
		{
			bool flag = ++_currentLevel <= 0;
			object obj = 0;
			if (!flag)
			{
				do
				{
					List<GameObject> spawnedSlots = _spawnedSlots;
					bool flag2 = _spawnedSlots == null;
					bool flag3 = (nint)obj >= spawnedSlots._size;
					GameObject[] items = spawnedSlots._items;
					bool flag4 = spawnedSlots._items == null;
					Transform transform = (Transform)(object)items[obj];
					bool flag5 = (object)items[obj] == null;
					bool flag6 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
					IntPtr gcHandlePtr = GameObject.get_transform_Injected(((UnityEngine.Object)transform).m_CachedPtr);
					Transform transform2 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr);
					bool flag7 = (object)transform2 == null;
					bool flag8 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
					IntPtr child_Injected = Transform.GetChild_Injected(((UnityEngine.Object)transform2).m_CachedPtr, 0);
					Transform transform3 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(child_Injected);
					bool flag9 = (object)transform3 == null;
					bool flag10 = ((UnityEngine.Object)transform3).m_CachedPtr == (IntPtr)0;
					IntPtr gcHandlePtr2 = Component.get_gameObject_Injected(((UnityEngine.Object)transform3).m_CachedPtr);
					GameObject gameObject = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<GameObject>(gcHandlePtr2);
					bool flag11 = (object)gameObject == null;
					bool flag12 = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
					GameObject.SetActive_Injected(((UnityEngine.Object)gameObject).m_CachedPtr, true);
					obj++;
				}
				while ((nint)obj < _currentLevel);
			}
			CheckMaxedOut();
			bool flag13 = (object)Title == null;
			TextMeshProUGUI component = Title.GetComponent<TextMeshProUGUI>();
			bool flag14 = _currentLevel > 0;
			string hex = "0xffffff";
			if (!flag14)
			{
				hex = "0x444444";
			}
			Color color = ColourHelper.HexToColor(hex);
			bool flag15 = (object)component == null;
			object obj2 = default(object);
			component.color = (Color)(&obj2);
			return true;
		}
		return false;
	}

	public unsafe void SetActive(bool b)
	{
		//IL_004c: Expected O, but got Ref
		//IL_0029: Expected O, but got I
		Color color;
		if (b)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12250]");
			color = (Color)0;
		}
		else
		{
			color = MaxColor;
		}
		Background.color = (Color)(&color);
	}

	public void SetInfo()
	{
		_page.SetInfo(_data, _type, this);
	}

	private unsafe void CheckMaxedOut()
	{
		//IL_0054: Expected I, but got O
		//IL_0061: Expected O, but got Ref
		//IL_00e7: Expected O, but got Ref
		//IL_00c3: Expected O, but got I
		if (_currentLevel >= _maxRank)
		{
			Button clicker = Clicker;
			clicker.m_OnClick.RemoveAllListeners();
			Image background = Background;
			nint num = (nint)background;
			Color color = default(Color);
			background.color = (Color)(&color);
			PowerUpsPage page = _page;
			PlayerOptionsData config = page._playerOptions.Config;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A980C0");
			object obj = default(object);
			if (obj != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12250]");
				color = (Color)0;
			}
			else
			{
				color = MaxColor;
			}
			Background.color = (Color)(&color);
		}
	}

	public bool IsMaxedOut()
	{
		//IL_0011: Expected O, but got I4
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Expected I4, but got Unknown
		object obj = _currentLevel - _maxRank;
		int num = _currentLevel ^ _maxRank;
		int num2 = _currentLevel ^ obj;
		int num3 = num & num2;
		bool flag = num3 < 0;
		bool flag2 = (nint)obj < 0;
		return flag2 == flag;
	}

	protected override void OnSelected()
	{
		_page.SetInfo(_data, _type, this);
	}

	public PowerUpItemUI()
	{
		List<GameObject> spawnedSlots = new List<GameObject>();
		_spawnedSlots = spawnedSlots;
		base._ShowSelector = true;
		base._ShouldUpdatePositionWhenForcingDumbFix = true;
		ReselectIfDefaultSelectedOnPage = true;
	}
}
