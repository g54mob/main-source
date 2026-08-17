using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Cpp2ILInjected;
using TMPro;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.UI;
using VampireSurvivors.App.Scripts.Framework.Adventures;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects;
using VampireSurvivors.Objects.Characters;

namespace VampireSurvivors.UI;

public class EvolutionItemUI : MonoBehaviour
{
	private sealed class _003CFormatHighlightSize_003Ed__20(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public EvolutionItemUI _003C_003E4__this;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_0014: Expected I4, but got I8
			//IL_008c: Expected I4, but got I8
			//IL_00a1: Expected O, but got I
			//IL_00de: Expected O, but got I
			//IL_00f4: Expected O, but got I
			//IL_011a: Expected O, but got I
			//IL_0135: Expected O, but got I
			//IL_016c: Expected O, but got I
			//IL_0187: Expected O, but got I
			//IL_019d: Expected O, but got I
			//IL_01c3: Expected O, but got I
			//IL_01de: Expected O, but got I
			//IL_0215: Expected O, but got I
			//IL_0230: Expected O, but got I
			//IL_0246: Expected O, but got I
			//IL_0272: Expected O, but got I
			//IL_029e: Expected O, but got I
			//IL_02d1: Expected O, but got I
			Component component = _003C_003E4__this;
			if (_003C_003E1__state == 0)
			{
				_003C_003E1__state = -1;
				RectTransform component2 = component.GetComponent<RectTransform>();
				LayoutRebuilder.ForceRebuildLayoutImmediate(component2);
				Canvas.ForceUpdateCanvases();
				_003C_003E2__current = null;
				_003C_003E1__state = 1;
				return true;
			}
			if (_003C_003E1__state == 1)
			{
				_003C_003E1__state = -1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rbx_v1 (UnityEngine.Component)+88]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v130 @ rax_v11+18]");
				if ((nint)0 > (nint)0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v130 @ rax_v11+10]");
					object obj2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v146 @ rcx_v7+20]");
					RectTransform component3 = ((GameObject)0).GetComponent<RectTransform>();
					Vector2 anchoredPosition = component3.anchoredPosition;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rbx_v1 (UnityEngine.Component)+88]");
					object obj3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v148 @ rcx_v10+18]");
					object obj4 = -1;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v148 @ rcx_v10+18]");
					if ((nint)obj4 < 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v148 @ rcx_v10+10]");
						object obj5 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v148 @ rcx_v10+18]");
						object obj6 = -1;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v119 @ rdx_v7+20+v134 @ rax_v15*8]");
						RectTransform component4 = ((GameObject)0).GetComponent<RectTransform>();
						Vector2 anchoredPosition2 = component4.anchoredPosition;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rbx_v1 (UnityEngine.Component)+88]");
						object obj7 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v150 @ rcx_v13+18]");
						object obj8 = -1;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v150 @ rcx_v13+18]");
						if ((nint)obj8 < 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v150 @ rcx_v13+10]");
							object obj9 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v150 @ rcx_v13+18]");
							object obj10 = -1;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v122 @ rdx_v10+20+v138 @ rax_v19*8]");
							RectTransform component5 = ((GameObject)0).GetComponent<RectTransform>();
							Vector2 sizeDelta = component5.sizeDelta;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rbx_v1 (UnityEngine.Component)+20]");
							RectTransform rectTransform = ((Graphic)0).rectTransform;
							Vector2 vector = default(Vector2);
							rectTransform.anchoredPosition = vector;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rbx_v1 (UnityEngine.Component)+20]");
							RectTransform rectTransform2 = ((Graphic)0).rectTransform;
							GridLayoutGroup componentInParent = component.GetComponentInParent<GridLayoutGroup>();
							rectTransform2.sizeDelta = vector;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rbx_v1 (UnityEngine.Component)+20]");
							object obj11 = 0;
							Color color = ColourHelper.HexToColor("0xA5A64C");
							object obj12 = obj11;
							Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v380 @ r9_v2+2A8] (should have been resolved before IL gen)");
							goto IL_0327;
						}
					}
				}
				System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
				bool result = default(bool);
				return result;
			}
			goto IL_0327;
			IL_0327:
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		void IEnumerator.Reset()
		{
			NotSupportedException ex = new NotSupportedException();
			throw ex;
		}
	}

	private Image _HighlightPanel;

	private GameObject _WeaponPrefab;

	private GameObject _TextPrefab;

	private GameObject _QuestionMarkPrefab;

	private CanvasGroup _CanvasGroup;

	private HorizontalLayoutGroup _layoutGroup;

	private EvolutionData _evoData;

	private PlayerOptions _playerOptions;

	private Dictionary<WeaponType, List<WeaponData>> _weapons;

	private VampireSurvivors.Objects.Characters.CharacterController _character;

	private List<Equipment> _equipment;

	private List<WeaponType> _owned;

	private float _iconPos;

	private float _symbolSpacing = 35f;

	private List<GameObject> addedWeaponObjects;

	private bool formatHighlight;

	private const string EqualsString = "=";

	private const string PlusString = "+";

	public unsafe void CreateWeaponContainer(PlayerOptions player, Dictionary<WeaponType, List<WeaponData>> weapons, List<WeaponType> owned, EvolutionData evo, VampireSurvivors.Objects.Characters.CharacterController character)
	{
		//IL_0a2b: Expected O, but got I4
		//IL_0300: Expected F4, but got I4
		//IL_0236: Expected O, but got I4
		//IL_0346: Expected O, but got I
		//IL_02db: Expected O, but got I4
		//IL_0bc1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bc6: Expected O, but got Unknown
		//IL_0982: Expected O, but got Ref
		//IL_0bfa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bff: Expected O, but got Unknown
		//IL_0421: Expected O, but got I
		//IL_047e: Expected O, but got I
		//IL_0c42: Expected I4, but got I8
		//IL_04b5: Expected O, but got I
		//IL_04c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_04c7: Expected O, but got Unknown
		//IL_0893: Expected F4, but got I4
		//IL_089d: Expected F4, but got O
		//IL_06fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0700: Expected O, but got Unknown
		//IL_06c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_06c8: Expected O, but got Unknown
		//IL_0ca1->IL09d8: Incompatible stack heights: 1 vs 0
		//IL_099e->IL09d8: Incompatible stack heights: 1 vs 0
		//IL_0c51->IL0cc4: Incompatible stack heights: 1 vs 0
		//IL_0b7b->IL09d8: Incompatible stack heights: 1 vs 0
		//IL_08a2->IL0af7: Incompatible stack heights: 1 vs 0
		//IL_0bb6->IL0ccf: Incompatible stack heights: 3 vs 1
		_playerOptions = player;
		Dictionary<WeaponType, List<WeaponData>> weapons2 = default(Dictionary<WeaponType, List<WeaponData>>);
		_weapons = weapons2;
		EvolutionData evolutionData = default(EvolutionData);
		_evoData = evolutionData;
		List<WeaponType> owned2 = default(List<WeaponType>);
		_owned = owned2;
		VampireSurvivors.Objects.Characters.CharacterController character2 = default(VampireSurvivors.Objects.Characters.CharacterController);
		_character = character2;
		if (_playerOptions != null)
		{
			PlayerOptionsData config = _playerOptions.Config;
			if (config != null && evolutionData != null && config._003CCollectedWeapons_003Ek__BackingField != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A969B0");
				bool flag = AdventureManager._003CIsInAdventureMode_003Ek__BackingField || evolutionData.weapon == WeaponType.SILVERWIND2 || evolutionData.weapon == WeaponType.FOURSEASONS2 || evolutionData.weapon == WeaponType.SUMMONNIGHT2 || evolutionData.weapon == WeaponType.MIRAGEROBE2 || true;
				bool flag2 = !AdventureManager._003CIsInAdventureMode_003Ek__BackingField;
				if (flag2)
				{
					flag2 = evolutionData.weapon == WeaponType.SPELL_STROM;
					if (!flag2)
					{
						flag2 = evolutionData.weapon == WeaponType.SWORD2;
						if (!flag2)
						{
							flag2 = evolutionData.weapon == WeaponType.FLASHARROW2;
							if (!flag2)
							{
								flag2 = evolutionData.weapon == WeaponType.PRISMATICMISS2;
								if (!flag2)
								{
									object obj = evolutionData.weapon - 132;
									flag2 = obj == null;
								}
							}
						}
					}
				}
				object obj2 = !flag2;
				bool flag3 = flag;
				if (obj2 == null)
				{
					bool flag4 = evolutionData.weapon == WeaponType.VAMPIRICA;
					flag3 = flag;
					if (!flag4)
					{
						bool flag5 = evolutionData.weapon == WeaponType.HOLY_MISSILE;
						flag3 = flag;
						if (!flag5)
						{
							bool flag6 = evolutionData.weapon == WeaponType.THOUSAND;
							flag3 = flag;
							if (!flag6)
							{
								object obj3 = evolutionData.weapon - 6;
								bool flag7 = obj3 == null;
								flag3 = flag7;
							}
						}
					}
				}
				List<WeaponType> list = CreateRequiredWeaponList();
				if (list != null)
				{
					float num = 0f;
					Dictionary<WeaponType, List<WeaponData>> dictionary = null;
					Dictionary<WeaponType, List<WeaponData>> dictionary2 = null;
					object obj10 = default(object);
					object obj11 = default(object);
					List<GameObject>.Enumerator enumerator = default(List<GameObject>.Enumerator);
					IntPtr intPtr = default(IntPtr);
					while (true)
					{
						Dictionary<WeaponType, List<WeaponData>> dictionary3 = dictionary;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v502 @ rax_v54 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
						if ((nint)dictionary3 < 0)
						{
							Dictionary<WeaponType, List<WeaponData>> dictionary4 = dictionary2;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v502 @ rax_v54 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
							if ((nint)dictionary4 >= 0)
							{
								goto IL_0a68;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v502 @ rax_v54 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
							object obj4 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v502 @ rax_v54 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
							if ((nint)0 == 0)
							{
								break;
							}
							Dictionary<WeaponType, List<WeaponData>> dictionary5 = dictionary2;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v527 @ rcx_v102+18]");
							if ((nint)dictionary5 < 0)
							{
								if (_weapons == null)
								{
									break;
								}
								Dictionary<WeaponType, List<WeaponData>> weapons3 = _weapons;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v527 @ rcx_v102+20+v846 @ rsi_v17 (System.Collections.Generic.Dictionary`2<VampireSurvivors.Data.WeaponType, System.Collections.Generic.List`1<VampireSurvivors.Data.Weapons.WeaponData>>)*4]");
								object obj5 = ((Dictionary<System.Int32Enum, object>)(object)weapons3).get_Item((System.Int32Enum)0);
								if (obj5 == null)
								{
									break;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v505 @ rax_v118 (System.Object)+18]");
								if ((nint)0 <= (nint)0)
								{
									goto IL_0a68;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v505 @ rax_v118 (System.Object)+10]");
								object obj6 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v505 @ rax_v118 (System.Object)+10]");
								if ((nint)0 == 0)
								{
									break;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v506 @ rax_v119+18]");
								if ((nint)0 > (nint)0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v506 @ rax_v119+20]");
									object obj7 = 0;
									if ((nint)dictionary2 > 0)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v527 @ rcx_v102+20+v846 @ rsi_v17 (System.Collections.Generic.Dictionary`2<VampireSurvivors.Data.WeaponType, System.Collections.Generic.List`1<VampireSurvivors.Data.Weapons.WeaponData>>)*4]");
										object obj8 = -68;
										object obj9 = obj8 & 0xFFFFFFFBL;
										if (obj9 != null)
										{
											AddCharacterIcon("+");
											num = _symbolSpacing + _iconPos;
											_iconPos = num;
										}
									}
									if (flag3)
									{
										goto IL_0610;
									}
									if (_playerOptions == null)
									{
										break;
									}
									PlayerOptionsData config2 = _playerOptions.Config;
									if (config2 == null || config2._003CUnlockedWeapons_003Ek__BackingField == null)
									{
										break;
									}
									List<WeaponType> list2 = config2._003CUnlockedWeapons_003Ek__BackingField;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v527 @ rcx_v102+20+v846 @ rsi_v17 (System.Collections.Generic.Dictionary`2<VampireSurvivors.Data.WeaponType, System.Collections.Generic.List`1<VampireSurvivors.Data.Weapons.WeaponData>>)*4]");
									List<WeaponData> list3 = ((Dictionary<WeaponType, List<WeaponData>>)(object)list2).get_Item(WeaponType.VOID);
									if (list3 != null)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v506 @ rax_v119+20]");
										if ((nint)0 == 0)
										{
											break;
										}
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v460 @ r15_v17+101]");
										if ((nint)0 == 0)
										{
											goto IL_0610;
										}
									}
									AddQuestionIcon();
									goto IL_0654;
								}
							}
							goto IL_0a6e;
						}
						AddCharacterIcon("=");
						float iconPos = _symbolSpacing + _iconPos;
						_iconPos = iconPos;
						if (obj10 != null)
						{
							EvolutionData evoData = _evoData;
							if (_evoData == null)
							{
								break;
							}
							GameObject gameObject = AddWeaponIcon(evoData.weapon);
							if (addedWeaponObjects == null)
							{
								break;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180497F80");
							float iconPos2 = _symbolSpacing + _iconPos;
							_iconPos = iconPos2;
							if (_owned == null)
							{
								break;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A969B0");
							if (obj11 != null)
							{
								if ((object)_HighlightPanel == null)
								{
									break;
								}
								GameObject gameObject2 = _HighlightPanel.gameObject;
								if ((object)gameObject2 == null)
								{
									break;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v514 @ rax_v92 (UnityEngine.GameObject)+10]");
								bool flag8 = (nint)0 == 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v514 @ rax_v92 (UnityEngine.GameObject)+10]");
								GameObject.SetActive_Injected((IntPtr)0, true);
								formatHighlight = true;
								if (addedWeaponObjects == null)
								{
									break;
								}
								while (enumerator.MoveNext())
								{
									Image component = ((GameObject)null).GetComponent<Image>();
									bool flag9 = (object)component == null;
									bool flag10 = ((UnityEngine.Object)component).m_CachedPtr == (IntPtr)0;
									Behaviour.set_enabled_Injected(((UnityEngine.Object)component).m_CachedPtr, false);
								}
								float num2 = 0f;
								iconPos2 = (float)addedWeaponObjects;
							}
						}
						else
						{
							AddQuestionIcon();
							float iconPos2 = _symbolSpacing + _iconPos;
							_iconPos = iconPos2;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v502 @ rax_v54 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
						if ((nint)0 == 4)
						{
							if ((object)_layoutGroup == null)
							{
								break;
							}
							object obj12 = _layoutGroup + 102;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A90470");
							if ((object)_layoutGroup == null)
							{
								break;
							}
							object obj13 = _layoutGroup + 100;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A90470");
							if ((object)_layoutGroup == null)
							{
								break;
							}
							_layoutGroup.spacing = 15f;
							HorizontalLayoutGroup layoutGroup = _layoutGroup;
							if ((object)_layoutGroup == null)
							{
								break;
							}
							object padding = ((LayoutGroup)layoutGroup).m_Padding;
							if (((LayoutGroup)layoutGroup).m_Padding == null)
							{
								break;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v539 @ rcx_v72 (System.Object)+10]");
							bool flag11 = (nint)0 == 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v539 @ rcx_v72 (System.Object)+10]");
							RectOffset.set_left_Injected((IntPtr)0, -45);
							float num2 = 15f;
						}
						SetVisibility();
						if ((object)this == null)
						{
							break;
						}
						bool flag12 = ((UnityEngine.Object)this).m_CachedPtr == (IntPtr)0;
						IntPtr gcHandlePtr = Component.get_gameObject_Injected(((UnityEngine.Object)this).m_CachedPtr);
						GameObject gameObject3 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<GameObject>(gcHandlePtr);
						if (_evoData == null)
						{
							break;
						}
						string text = ((Enum)(&intPtr)).ToString();
						if ((object)gameObject3 == null)
						{
							break;
						}
						((UnityEngine.Object)gameObject3).SetName(text);
						RectTransform component2 = GetComponent<RectTransform>();
						LayoutRebuilder.ForceRebuildLayoutImmediate(component2);
						Canvas.ForceUpdateCanvases();
						return;
						IL_0a68:
						System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
						goto IL_0a6e;
						IL_0610:
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v527 @ rcx_v102+20+v846 @ rsi_v17 (System.Collections.Generic.Dictionary`2<VampireSurvivors.Data.WeaponType, System.Collections.Generic.List`1<VampireSurvivors.Data.Weapons.WeaponData>>)*4]");
						GameObject gameObject4 = AddWeaponIcon(WeaponType.VOID);
						if (addedWeaponObjects == null)
						{
							break;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180497F80");
						goto IL_0654;
						IL_0a6e:
						throw new IndexOutOfRangeException();
						IL_0654:
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v527 @ rcx_v102+20+v846 @ rsi_v17 (System.Collections.Generic.Dictionary`2<VampireSurvivors.Data.WeaponType, System.Collections.Generic.List`1<VampireSurvivors.Data.Weapons.WeaponData>>)*4]");
						if ((nint)0 != 72)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v527 @ rcx_v102+20+v846 @ rsi_v17 (System.Collections.Generic.Dictionary`2<VampireSurvivors.Data.WeaponType, System.Collections.Generic.List`1<VampireSurvivors.Data.Weapons.WeaponData>>)*4]");
							if ((nint)0 != 67)
							{
								num = _iconPos + 32f;
								_iconPos = num;
								dictionary2 = (Dictionary<WeaponType, List<WeaponData>>)(dictionary2 + 1);
								dictionary = dictionary2;
								continue;
							}
						}
						num = _symbolSpacing + _iconPos;
						_iconPos = num;
						dictionary2 = (Dictionary<WeaponType, List<WeaponData>>)(dictionary2 + 1);
						dictionary = dictionary2;
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private void OnEnable()
	{
		if (formatHighlight)
		{
			_003CFormatHighlightSize_003Ed__20 obj = null;
			obj._003C_003E1__state = 0;
			obj._003C_003E4__this = this;
			Coroutine coroutine = StartCoroutine(obj);
			formatHighlight = false;
		}
	}

	private IEnumerator FormatHighlightSize()
	{
		_003CFormatHighlightSize_003Ed__20 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		return obj;
	}

	public void CreateTriassoContainer(PlayerOptions player, Dictionary<WeaponType, List<WeaponData>> weapons, List<WeaponType> owned, EvolutionData evo, VampireSurvivors.Objects.Characters.CharacterController character)
	{
		_playerOptions = player;
		_weapons = weapons;
		EvolutionData evoData = default(EvolutionData);
		_evoData = evoData;
		_owned = owned;
		VampireSurvivors.Objects.Characters.CharacterController character2 = default(VampireSurvivors.Objects.Characters.CharacterController);
		_character = character2;
		object obj = ((Dictionary<System.Int32Enum, object>)(object)_weapons).get_Item((System.Int32Enum)96);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v400 @ rax_v15 (System.Object)+18]");
		if ((nint)0 > (nint)0)
		{
			PlayerOptionsData config = _playerOptions.Config;
			List<WeaponData> list = ((Dictionary<WeaponType, List<WeaponData>>)(object)config._003CCollectedWeapons_003Ek__BackingField).get_Item(WeaponType.TRIASSO1);
			if (list == null)
			{
				PlayerOptionsData config2 = _playerOptions.Config;
				List<WeaponData> list2 = ((Dictionary<WeaponType, List<WeaponData>>)(object)config2._003CUnlockedWeapons_003Ek__BackingField).get_Item(WeaponType.TRIASSO1);
				if (list2 == null)
				{
					AddQuestionIcon();
					AddCharacterIcon("=");
					AddQuestionIcon();
					AddCharacterIcon("=");
					AddQuestionIcon();
					goto IL_0165;
				}
			}
			GameObject gameObject = AddWeaponIcon(WeaponType.TRIASSO1);
			AddCharacterIcon("=");
			GameObject gameObject2 = AddWeaponIcon(WeaponType.TRIASSO2);
			AddCharacterIcon("=");
			GameObject gameObject3 = AddWeaponIcon(WeaponType.TRIASSO3);
			goto IL_0165;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		return;
		IL_0165:
		SetVisibility();
	}

	public void CreateGenericContainer(PlayerOptions player, Dictionary<WeaponType, List<WeaponData>> weapons, List<WeaponType> owned, EvolutionData evo, VampireSurvivors.Objects.Characters.CharacterController character)
	{
		//IL_0051: Expected O, but got I8
		//IL_005a: Expected O, but got I4
		//IL_00bd: Expected O, but got I
		//IL_05e0: Expected I, but got O
		//IL_063f: Expected I, but got O
		//IL_023d: Expected O, but got I
		//IL_027a: Expected O, but got I
		//IL_03d8: Expected O, but got I
		//IL_0412: Unknown result type (might be due to invalid IL or missing references)
		//IL_0417: Expected O, but got Unknown
		//IL_0609->IL04bc: Incompatible stack heights: 1 vs 0
		//IL_064f->IL05a9: Incompatible stack heights: 2 vs 0
		_playerOptions = player;
		Dictionary<WeaponType, List<WeaponData>> weapons2 = default(Dictionary<WeaponType, List<WeaponData>>);
		_weapons = weapons2;
		EvolutionData evolutionData = default(EvolutionData);
		_evoData = evolutionData;
		_owned = owned;
		VampireSurvivors.Objects.Characters.CharacterController character2 = default(VampireSurvivors.Objects.Characters.CharacterController);
		_character = character2;
		if (evolutionData != null)
		{
			if (evolutionData.evolutionLine == null)
			{
				Debug.LogError("Evolution line is null, we should not be creating a generic line here");
				return;
			}
			object obj = 6603577472L;
			object obj2 = 0;
			object obj7 = default(object);
			object obj8 = default(object);
			nint num = default(nint);
			object obj10 = default(object);
			while (true)
			{
				IEnumerable<System.Int32Enum> evolutionLine = (IEnumerable<System.Int32Enum>)evolutionData.evolutionLine;
				if (evolutionData.evolutionLine == null)
				{
					break;
				}
				object obj3 = obj2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v451 @ rax_v29 (System.Collections.Generic.IEnumerable`1<System.Int32Enum>)+18]");
				PlayerOptionsData playerOptionsData;
				if ((nint)obj3 < 0)
				{
					object obj4 = obj2;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v451 @ rax_v29 (System.Collections.Generic.IEnumerable`1<System.Int32Enum>)+18]");
					if ((nint)obj4 < 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v451 @ rax_v29 (System.Collections.Generic.IEnumerable`1<System.Int32Enum>)+10]");
						object obj5 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v451 @ rax_v29 (System.Collections.Generic.IEnumerable`1<System.Int32Enum>)+10]");
						if ((nint)0 == 0)
						{
							break;
						}
						object obj6 = obj2;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v464 @ rcx_v45+18]");
						if ((nint)obj6 < 0)
						{
							PlayerOptions playerOptions = _playerOptions;
							if (_playerOptions == null)
							{
								break;
							}
							if (playerOptions._onlineClientWithRunDataConfig == null)
							{
								if (playerOptions._hostGameConfig == null)
								{
									if (playerOptions._currentAdventureSaveData != null)
									{
										playerOptionsData = playerOptions._currentAdventureSaveData;
										if ((object)playerOptionsData._003CSelectedAdventureType_003Ek__BackingField != null)
										{
											goto IL_052c;
										}
									}
									playerOptionsData = playerOptions._mainGameConfig;
									if (playerOptions._mainGameConfig == null)
									{
										break;
									}
								}
								else
								{
									playerOptionsData = playerOptions._hostGameConfig;
								}
							}
							else
							{
								playerOptionsData = playerOptions._onlineClientWithRunDataConfig;
							}
							goto IL_052c;
						}
					}
					else
					{
						System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
					}
					throw new IndexOutOfRangeException();
				}
				System.Int32Enum int32Enum = Enumerable.Last((IEnumerable<System.Int32Enum>)evolutionData.evolutionLine);
				if (_owned == null)
				{
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A969B0");
				if (obj7 != null)
				{
					PlayerOptions highlightPanel = (PlayerOptions)(object)_HighlightPanel;
					if ((object)_HighlightPanel == null)
					{
						break;
					}
					bool flag = highlightPanel.RunGoldUpdated == null;
					IntPtr gcHandlePtr = Component.get_gameObject_Injected((IntPtr)highlightPanel.RunGoldUpdated);
					GameObject gameObject = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<GameObject>(gcHandlePtr);
					if ((object)gameObject == null)
					{
						break;
					}
					bool flag2 = ((PlayerOptions)(object)gameObject).RunGoldUpdated == null;
					GameObject.SetActive_Injected((IntPtr)((PlayerOptions)(object)gameObject).RunGoldUpdated, true);
					formatHighlight = true;
				}
				SetVisibility();
				return;
				IL_052c:
				List<WeaponType> list = playerOptionsData._003CCollectedWeapons_003Ek__BackingField;
				if (playerOptionsData._003CCollectedWeapons_003Ek__BackingField == null)
				{
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v472 @ rcx_v47 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
				nint num2;
				object obj9;
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v472 @ rcx_v47 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
					obj = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
					bool flag3 = (nint)obj8 != -1;
					num = 0;
					weapons2 = null;
					num2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v472 @ rcx_v47 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
					obj9 = 0;
					if (flag3)
					{
						goto IL_034a;
					}
				}
				if (_playerOptions == null)
				{
					break;
				}
				PlayerOptionsData config = _playerOptions.Config;
				if (config == null || config._003CUnlockedWeapons_003Ek__BackingField == null)
				{
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A969B0");
				bool flag4 = obj10 != null;
				num2 = num;
				obj9 = obj;
				if (flag4)
				{
					goto IL_034a;
				}
				AddQuestionIcon();
				num2 = num;
				obj9 = obj;
				goto IL_0393;
				IL_0393:
				List<WeaponType> evolutionLine2 = evolutionData.evolutionLine;
				if (evolutionData.evolutionLine == null)
				{
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v457 @ rax_v54 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
				object obj11 = -1;
				if (obj2 != obj11)
				{
					AddCharacterIcon("=");
					weapons2 = null;
				}
				obj2++;
				num = num2;
				obj = obj9;
				continue;
				IL_034a:
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v464 @ rcx_v45+20+v493 @ rsi_v12*4]");
				GameObject gameObject2 = AddWeaponIcon(WeaponType.VOID);
				if (addedWeaponObjects == null)
				{
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180497F80");
				weapons2 = null;
				goto IL_0393;
			}
		}
		throw new NullReferenceException();
	}

	private void SetVisibility()
	{
		if (DisabledItem())
		{
			_CanvasGroup.alpha = 0.5f;
		}
		if (UnobtainableItem())
		{
			_CanvasGroup.alpha = 0.35f;
		}
		if (!VisibleItem())
		{
			GameObject gameObject = base.gameObject;
			gameObject.SetActive(value: false);
		}
	}

	private void AddCharacterIcon(string character)
	{
		Transform parent = base.transform;
		GameObject gameObject = UnityEngine.Object.Instantiate(_TextPrefab, parent);
		TextMeshProUGUI component = gameObject.GetComponent<TextMeshProUGUI>();
		component.text = character;
		RectTransform component2 = gameObject.GetComponent<RectTransform>();
		Vector2 anchoredPosition = default(Vector2);
		component2.anchoredPosition = anchoredPosition;
	}

	private GameObject AddWeaponIcon(WeaponType t)
	{
		//IL_00a8: Expected O, but got I
		//IL_00bd: Expected O, but got I
		//IL_0112: Expected O, but got I
		//IL_0127: Expected O, but got I
		//IL_0153: Expected O, but got I
		//IL_0153: Expected O, but got I
		Transform parent = base.transform;
		GameObject gameObject = UnityEngine.Object.Instantiate(_WeaponPrefab, parent);
		Transform transform = gameObject.transform;
		Transform child = transform.GetChild(0);
		Image component = child.GetComponent<Image>();
		object obj = ((Dictionary<System.Int32Enum, object>)(object)_weapons).get_Item((System.Int32Enum)t);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v138 @ rax_v14 (System.Object)+18]");
		if ((nint)0 > (nint)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v138 @ rax_v14 (System.Object)+10]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v139 @ rax_v15+20]");
			object obj3 = 0;
			object obj4 = ((Dictionary<System.Int32Enum, object>)(object)_weapons).get_Item((System.Int32Enum)t);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v140 @ rax_v16 (System.Object)+18]");
			if ((nint)0 > (nint)0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v140 @ rax_v16 (System.Object)+10]");
				object obj5 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v141 @ rax_v17+20]");
				object obj6 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v149 @ rcx_v13+40]");
				nint num = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v119 @ rdx_v11+38]");
				Sprite sprite = SpriteManager.GetSprite((string)num, (string)0);
				component.sprite = sprite;
				RectTransform component2 = gameObject.GetComponent<RectTransform>();
				Vector2 anchoredPosition = default(Vector2);
				component2.anchoredPosition = anchoredPosition;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A969B0");
				object obj7 = default(object);
				if (obj7 != null)
				{
					Image component3 = gameObject.GetComponent<Image>();
					component3.enabled = true;
				}
				return gameObject;
			}
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		GameObject result = default(GameObject);
		return result;
	}

	private void AddQuestionIcon()
	{
		Transform parent = base.transform;
		GameObject gameObject = UnityEngine.Object.Instantiate(_QuestionMarkPrefab, parent);
		RectTransform component = gameObject.GetComponent<RectTransform>();
		Vector2 anchoredPosition = default(Vector2);
		component.anchoredPosition = anchoredPosition;
	}

	private unsafe bool VisibleItem()
	{
		//IL_02b3: Expected O, but got I
		//IL_02c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c8: Expected O, but got Unknown
		//IL_0461: Expected O, but got Ref
		//IL_032c: Expected O, but got I4
		//IL_0334: Unknown result type (might be due to invalid IL or missing references)
		//IL_0339: Expected O, but got Unknown
		//IL_0357: Expected O, but got I
		//IL_03b4: Expected O, but got I
		//IL_03c9: Expected O, but got I
		//IL_026c: Expected O, but got I4
		EvolutionData evoData = _evoData;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A969B0");
		object obj = default(object);
		bool flag2;
		if (obj == null)
		{
			List<WeaponType> list = CreateRequiredWeaponList();
			PlayerOptionsData config = _playerOptions.Config;
			EvolutionData evoData2 = _evoData;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A969B0");
			object obj2 = default(object);
			if (obj2 == null)
			{
				EvolutionData evoData3 = _evoData;
				if (evoData3.weapon != WeaponType.VAMPIRICA && evoData3.weapon != WeaponType.HOLY_MISSILE && evoData3.weapon != WeaponType.THOUSAND && evoData3.weapon != WeaponType.SCYTHE && evoData3.weapon != WeaponType.SILVERWIND2 && evoData3.weapon != WeaponType.FOURSEASONS2 && evoData3.weapon != WeaponType.SUMMONNIGHT2 && evoData3.weapon != WeaponType.MIRAGEROBE2 && evoData3.weapon != WeaponType.BUBBLES2 && evoData3.weapon != WeaponType.SPELL_STROM && evoData3.weapon != WeaponType.SWORD2 && evoData3.weapon != WeaponType.FLASHARROW2 && evoData3.weapon != WeaponType.PRISMATICMISS2)
				{
					object obj3 = evoData3.weapon - 132;
					bool flag = obj3 == null;
					flag2 = flag;
					goto IL_0296;
				}
			}
			flag2 = true;
			goto IL_0296;
		}
		goto IL_0494;
		IL_0494:
		return true;
		IL_044a:
		return false;
		IL_0296:
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v84 @ rax_v14 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v84 @ rax_v14 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		object obj4 = num ^ 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v84 @ rax_v14 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		object obj5 = 0 & obj4;
		bool flag3 = (nint)obj5 < 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v84 @ rax_v14 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		bool flag4 = (nint)0 < (nint)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v84 @ rax_v14 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		bool flag5 = (nint)0 == 0;
		if (!flag5)
		{
			bool flag6 = flag4 == flag3;
			object obj6 = !flag6;
			object obj7 = obj6 | flag5;
			if (obj7 == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v84 @ rax_v14 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
				object obj8 = 0;
				Dictionary<WeaponType, List<WeaponData>> weapons = _weapons;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v87 @ rax_v27+20]");
				object obj9 = ((Dictionary<System.Int32Enum, object>)(object)weapons).get_Item((System.Int32Enum)0);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v88 @ rax_v28 (System.Object)+18]");
				if ((nint)0 > (nint)0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v88 @ rax_v28 (System.Object)+10]");
					object obj10 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v89 @ rax_v29+20]");
					object obj11 = 0;
					if (!flag2)
					{
						PlayerOptionsData config2 = _playerOptions.Config;
						List<WeaponType> list2 = config2._003CUnlockedWeapons_003Ek__BackingField;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v87 @ rax_v27+20]");
						List<WeaponData> list3 = ((Dictionary<WeaponType, List<WeaponData>>)(object)list2).get_Item(WeaponType.VOID);
						if (list3 != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v80 @ rdi_v10+101]");
							if ((nint)0 == (flag2 ? 1 : 0))
							{
								goto IL_0494;
							}
						}
						goto IL_044a;
					}
					goto IL_0494;
				}
			}
			System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
			bool result = default(bool);
			return result;
		}
		IntPtr intPtr = default(IntPtr);
		string text = ((Enum)(&intPtr)).ToString();
		string message = "Weapon " + text + " has empty 'evolves from' and 'requires' fields.  Remove those fields if you don't need them please!";
		Debug.LogError(message);
		goto IL_044a;
	}

	private bool DisabledItem()
	{
		//IL_00b9: Expected O, but got I4
		//IL_00c2: Expected O, but got I4
		//IL_0125: Expected O, but got I
		//IL_0162: Unknown result type (might be due to invalid IL or missing references)
		//IL_0167: Expected O, but got Unknown
		EvolutionData evoData = _evoData;
		if (evoData.evolutionLine != null)
		{
			System.Int32Enum int32Enum = Enumerable.Last((IEnumerable<System.Int32Enum>)evoData.evolutionLine);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A969B0");
			object obj = default(object);
			if (obj != null)
			{
				goto IL_0182;
			}
		}
		EvolutionData evoData2 = _evoData;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A969B0");
		object obj2 = default(object);
		if (obj2 == null)
		{
			List<WeaponType> list = CreateRequiredWeaponList();
			object obj3 = 0;
			object obj4 = 0;
			object obj8 = default(object);
			bool result = default(bool);
			while (true)
			{
				object obj5 = obj4;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v336 @ rax_v16 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
				if ((nint)obj5 < 0)
				{
					object obj6 = obj3;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v336 @ rax_v16 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
					if ((nint)obj6 < 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v336 @ rax_v16 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
						object obj7 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A969B0");
						if (obj8 != null)
						{
							break;
						}
						obj3++;
						obj4 = obj3;
						continue;
					}
					System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
					return result;
				}
				return true;
			}
		}
		goto IL_0182;
		IL_0182:
		return false;
	}

	private bool UnobtainableItem()
	{
		//IL_0137: Expected O, but got I
		//IL_0194: Expected O, but got I
		//IL_01a9: Expected O, but got I
		EvolutionData evoData = _evoData;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A969B0");
		object obj = default(object);
		if (obj == null)
		{
			EvolutionData evoData2 = _evoData;
			if (evoData2.evolutionLine != null)
			{
				System.Int32Enum int32Enum = Enumerable.Last((IEnumerable<System.Int32Enum>)evoData2.evolutionLine);
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A969B0");
				object obj2 = default(object);
				if (obj2 != null)
				{
					goto IL_0298;
				}
			}
			List<WeaponType> list = CreateRequiredWeaponList();
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			int num4 = 0;
			bool result = default(bool);
			while (true)
			{
				int num5 = num4;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v111 @ rax_v16 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
				if ((nint)num5 >= (nint)0)
				{
					break;
				}
				int num6 = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v111 @ rax_v16 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
				if ((nint)num6 < (nint)0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v111 @ rax_v16 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
					object obj3 = 0;
					Dictionary<WeaponType, List<WeaponData>> weapons = _weapons;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v94 @ rdx_v10+20+v80 @ rdi_v8 (System.Int32)*4]");
					object obj4 = ((Dictionary<System.Int32Enum, object>)(object)weapons).get_Item((System.Int32Enum)0);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v113 @ rax_v19 (System.Object)+18]");
					if ((nint)0 > (nint)0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v113 @ rax_v19 (System.Object)+10]");
						object obj5 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v114 @ rax_v20+20]");
						object obj6 = 0;
						List<WeaponType> owned = _owned;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v94 @ rdx_v10+20+v80 @ rdi_v8 (System.Int32)*4]");
						List<WeaponData> list2 = ((Dictionary<WeaponType, List<WeaponData>>)(object)owned).get_Item(WeaponType.VOID);
						if (list2 == null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v101 @ rbx_v10+101]");
							if ((nint)0 == 0)
							{
								num3++;
							}
							else
							{
								num2++;
							}
						}
						int availableWeaponSlots = GetAvailableWeaponSlots();
						bool flag = availableWeaponSlots >= 0;
						int num7 = availableWeaponSlots;
						if (!flag)
						{
							num7 = 0;
						}
						int num8 = GetAvailablePassiveSlots();
						if (num8 < 0)
						{
							num8 = 0;
						}
						if (num7 >= num3 && num8 >= num2)
						{
							num++;
							num4 = num;
							continue;
						}
						return true;
					}
				}
				System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
				return result;
			}
		}
		goto IL_0298;
		IL_0298:
		return false;
	}

	private int GetAvailableWeaponSlots()
	{
		//IL_009f: Expected I4, but got O
		//IL_007a: Expected O, but got I4
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
		//IL_008c: Expected I4, but got Unknown
		VampireSurvivors.Objects.Characters.CharacterController character = _character;
		if ((object)_character != null)
		{
			CharacterWeaponsManager weaponsManager = character._weaponsManager;
			if ((object)character._weaponsManager != null)
			{
				List<Equipment> list = ((EquipmentManager)weaponsManager)._003CActiveEquipment_003Ek__BackingField;
				if (((EquipmentManager)weaponsManager)._003CActiveEquipment_003Ek__BackingField != null)
				{
					object obj = character._maxWeaponBonus - list._size;
					return obj + character._maxWeaponCount;
				}
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (int)ex;
	}

	private int GetAvailablePassiveSlots()
	{
		//IL_009f: Expected I4, but got O
		//IL_007a: Expected O, but got I4
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
		//IL_008c: Expected I4, but got Unknown
		VampireSurvivors.Objects.Characters.CharacterController character = _character;
		if ((object)_character != null)
		{
			CharacterAccessoriesManager accessoriesManager = character._accessoriesManager;
			if ((object)character._accessoriesManager != null)
			{
				List<Equipment> list = ((EquipmentManager)accessoriesManager)._003CActiveEquipment_003Ek__BackingField;
				if (((EquipmentManager)accessoriesManager)._003CActiveEquipment_003Ek__BackingField != null)
				{
					object obj = character._maxAccessoryBonus - list._size;
					return obj + character._maxAccessoryCount;
				}
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (int)ex;
	}

	private unsafe static bool WeaponsInThisStage(WeaponType t)
	{
		//IL_0019: Expected O, but got I4
		//IL_0021: Expected O, but got Ref
		List<VampireSurvivors.Objects.Pickups.Pickup>.Enumerator enumerator = default(List<VampireSurvivors.Objects.Pickups.Pickup>.Enumerator);
		if (enumerator.MoveNext())
		{
			List<VampireSurvivors.Objects.Pickups.Pickup>.Enumerator enumerator2 = (List<VampireSurvivors.Objects.Pickups.Pickup>.Enumerator)0;
			List<VampireSurvivors.Objects.Pickups.Pickup>.Enumerator enumerator3 = (List<VampireSurvivors.Objects.Pickups.Pickup>.Enumerator)(&enumerator);
			throw new NullReferenceException();
		}
		return false;
	}

	private bool OwnsWeapon(WeaponType t)
	{
		//IL_0022: Expected I4, but got O
		if (_owned != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A969B0");
			bool result = default(bool);
			return result;
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	private List<WeaponType> CreateRequiredWeaponList()
	{
		//IL_0430: Expected O, but got I
		//IL_0097: Expected O, but got I
		//IL_048f: Expected O, but got I
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Expected O, but got Unknown
		//IL_01b6: Expected O, but got I
		//IL_01c4: Expected O, but got I
		//IL_0268: Expected O, but got I
		//IL_0276: Unknown result type (might be due to invalid IL or missing references)
		//IL_027b: Expected O, but got Unknown
		//IL_00fa: Expected O, but got I
		//IL_0121: Expected I, but got O
		//IL_013f: Expected O, but got I
		//IL_02cb: Expected O, but got I
		//IL_02f2: Expected I, but got O
		//IL_0310: Expected O, but got I
		List<WeaponType> result = new List<WeaponType>();
		EvolutionData evoData = _evoData;
		object obj2 = default(object);
		object obj4 = default(object);
		nint num2 = default(nint);
		if (evoData.evolvesFrom != null)
		{
			List<WeaponType> list = evoData.evolvesFrom;
			object obj = default(object);
			object obj7 = default(object);
			while (true)
			{
				if (obj != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v172 @ stack_-30_v20+1C]");
					if (obj2 != null)
					{
						break;
					}
					object obj3 = obj4;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v172 @ stack_-30_v20+18]");
					if ((nint)obj3 >= 0)
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v172 @ stack_-30_v20+10]");
					object obj5 = 0;
					object obj6 = obj4 + 1;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v3 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
					bool flag = (nint)0 == 0;
					nint num = num2;
					nint num3 = 0;
					List<WeaponType> list2 = list;
					if (!flag)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v3 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
						list2 = (List<WeaponType>)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
						bool flag2 = (nint)obj7 != -1;
						num = 0;
						num3 = unchecked((nint)null);
						num2 = 0;
						obj4 = obj6;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v3 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
						list = (List<WeaponType>)0;
						if (flag2)
						{
							continue;
						}
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A96950");
					num2 = num;
					obj4 = obj6;
					list = list2;
					continue;
				}
				throw new NullReferenceException();
			}
			bool flag3 = obj == null;
			List<WeaponType> list3 = (List<WeaponType>)0;
			if (!flag3)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v172 @ stack_-30_v20+1C]");
				if (obj2 == null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v172 @ stack_-30_v20+18]");
					object obj8 = (nint)0 + (nint)1;
					obj4 = obj8;
					List<WeaponType> list4 = (List<WeaponType>)0;
					goto IL_043e;
				}
				System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_EnumFailedVersion();
				list3 = null;
			}
			throw new NullReferenceException();
		}
		goto IL_043e;
		IL_043e:
		EvolutionData evoData2 = _evoData;
		if (evoData2.requires != null)
		{
			List<WeaponType> list5 = evoData2.requires;
			nint num4 = num2;
			object obj9 = default(object);
			object obj13 = default(object);
			while (true)
			{
				if (obj9 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v562 @ stack_-30_v18+1C]");
					if (obj2 != null)
					{
						break;
					}
					object obj10 = obj4;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v562 @ stack_-30_v18+18]");
					if ((nint)obj10 >= 0)
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v562 @ stack_-30_v18+10]");
					object obj11 = 0;
					object obj12 = obj4 + 1;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v3 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
					bool flag4 = (nint)0 == 0;
					nint num5 = num4;
					nint num6 = 0;
					List<WeaponType> list6 = list5;
					if (!flag4)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v3 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
						list6 = (List<WeaponType>)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
						bool flag5 = (nint)obj13 != -1;
						num5 = 0;
						num6 = unchecked((nint)null);
						num4 = 0;
						obj4 = obj12;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v3 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
						list5 = (List<WeaponType>)0;
						if (flag5)
						{
							continue;
						}
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A96950");
					num4 = num5;
					obj4 = obj12;
					list5 = list6;
					continue;
				}
				throw new NullReferenceException();
			}
			bool flag6 = obj9 == null;
			List<WeaponType> list4 = (List<WeaponType>)0;
			if (!flag6)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v562 @ stack_-30_v18+1C]");
				if (obj2 == null)
				{
					goto IL_044d;
				}
				System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_EnumFailedVersion();
				list4 = null;
			}
			throw new NullReferenceException();
		}
		goto IL_044d;
		IL_044d:
		return result;
	}

	public EvolutionItemUI()
	{
		List<GameObject> list = new List<GameObject>();
		addedWeaponObjects = list;
	}
}
