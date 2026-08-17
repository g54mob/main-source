using System;
using System.Collections.Generic;
using System.Linq;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.UI;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Characters;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.UI;

public class PauseEquipmentPanel : MonoBehaviour
{
	private Image _PlayerSprite;

	private RectTransform _Weapons;

	private RectTransform _Accessories;

	private GameObject _EquipmentIconPrefab;

	private List<GameObject> _spawned;

	private DataManager _data;

	private LevelUpFactory _levelUpFactory;

	private CanvasGroup _Group;

	private void Construct(DataManager data, LevelUpFactory level)
	{
		_data = data;
		_levelUpFactory = level;
	}

	public unsafe void Populate(VampireSurvivors.Objects.Characters.CharacterController character)
	{
		//IL_0d90: Expected I, but got O
		//IL_0070: Expected I, but got O
		//IL_00b1: Expected O, but got I
		//IL_00c7: Expected O, but got I
		//IL_00dd: Expected O, but got I
		//IL_00ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f2: Expected O, but got Unknown
		//IL_016d: Expected I, but got O
		//IL_0397: Expected O, but got I
		//IL_0e2e: Expected I, but got O
		//IL_01a0: Expected O, but got I
		//IL_05ce: Expected I, but got O
		//IL_05d6: Expected O, but got Ref
		//IL_0455: Expected O, but got I
		//IL_08e0: Expected I, but got O
		//IL_08e8: Expected O, but got Ref
		//IL_0c6e: Expected I, but got O
		//IL_05bf: Expected I, but got O
		//IL_04aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_04af: Expected O, but got Unknown
		//IL_050c: Expected I, but got O
		//IL_0543: Expected I, but got O
		//IL_0356->IL0c43: Incompatible stack heights: 1 vs 0
		//IL_0ecb->IL0c43: Incompatible stack heights: 2 vs 0
		//IL_0f19->IL0c43: Incompatible stack heights: 2 vs 0
		//IL_0f69->IL0c43: Incompatible stack heights: 2 vs 0
		//IL_1052->IL0c43: Incompatible stack heights: 3 vs 0
		//IL_10cd->IL0c43: Incompatible stack heights: 5 vs 0
		//IL_110e->IL0fc6: Incompatible stack heights: 6 vs 2
		nint num = (nint)_PlayerSprite;
		if ((object)_PlayerSprite != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v55 @ rbx_v1 (Il2CppMethodInfo)+10]");
			if ((nint)0 != 0)
			{
				if ((object)_PlayerSprite != null)
				{
					GameObject gameObject = _PlayerSprite.gameObject;
					nint num2 = (nint)GM.Core;
					if ((object)GM.Core != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v383 @ rbx_v60 (Il2CppMethodInfo)+2A0]");
						bool active;
						if ((nint)0 == 0)
						{
							active = false;
						}
						else
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v383 @ rbx_v60 (Il2CppMethodInfo)+2A0]");
							object obj = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v919 @ rax_v280+18]");
							object obj2 = -1;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v919 @ rax_v280+18]");
							object obj3 = (nint)0 ^ (nint)1;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v919 @ rax_v280+18]");
							object obj4 = 0 ^ obj2;
							object obj5 = obj3 & obj4;
							bool flag = (nint)obj5 < 0;
							bool flag2 = (nint)obj2 < 0;
							bool flag3 = obj2 == null;
							bool flag4 = flag2 == flag;
							bool flag5 = !flag3;
							active = flag5 & flag4;
						}
						if ((object)gameObject != null)
						{
							gameObject.SetActive(active);
							nint num3 = (nint)GM.Core;
							if ((object)GM.Core != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v164 @ rbx_v61 (Il2CppMethodInfo)+2A0]");
								if ((nint)0 != 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v164 @ rbx_v61 (Il2CppMethodInfo)+2A0]");
									object obj6 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v176 @ rax_v273+18]");
									if ((nint)0 > (nint)1)
									{
										if ((object)character != null)
										{
											CharacterData currentSkinData = character._currentSkinData;
											if (character._currentSkinData != null)
											{
												Sprite sprite = SpriteManager.GetSprite(currentSkinData._003CspriteName_003Ek__BackingField, currentSkinData._003CtextureName_003Ek__BackingField);
												if ((object)_PlayerSprite != null)
												{
													_PlayerSprite.sprite = sprite;
													goto IL_026c;
												}
											}
										}
										goto IL_0c43;
									}
								}
								goto IL_026c;
							}
						}
					}
				}
				goto IL_0c43;
			}
		}
		goto IL_026c;
		IL_026c:
		ClearSpawned();
		List<object> list;
		List<object> list2;
		nint num6;
		if (_data != null)
		{
			Dictionary<WeaponType, List<WeaponData>> convertedWeapons = _data.GetConvertedWeapons();
			if ((object)character != null)
			{
				CharacterWeaponsManager weaponsManager = character._weaponsManager;
				if ((object)character._weaponsManager != null)
				{
					bool flag6 = ((EquipmentManager)weaponsManager)._003CActiveEquipment_003Ek__BackingField == null;
					list = new List<object>(((EquipmentManager)weaponsManager)._003CActiveEquipment_003Ek__BackingField);
					string accessoriesManager = (string)(object)character._accessoriesManager;
					if ((object)character._accessoriesManager != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v391 @ rdi_v44 (System.String)+28]");
						bool flag7 = (nint)0 == 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v391 @ rdi_v44 (System.String)+28]");
						list2 = new List<object>((IEnumerable<object>)0);
						GameEquipmentPanel panelForCharacter = GameEquipmentPanel.GetPanelForCharacter(character);
						nint num5;
						if ((object)panelForCharacter != null && panelForCharacter._extraWeapons != null)
						{
							object obj7 = default(object);
							object obj8 = default(object);
							object obj10 = default(object);
							nint num4;
							while (true)
							{
								if (obj7 != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v614 @ stack_-98_v45+1C]");
									if (obj8 != null)
									{
										break;
									}
									object obj9 = obj10;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v614 @ stack_-98_v45+18]");
									if ((nint)obj9 >= 0)
									{
										break;
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v614 @ stack_-98_v45+10]");
									object obj11 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v614 @ stack_-98_v45+10]");
									if ((nint)0 != 0)
									{
										object obj12 = obj10;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v640 @ rdx_v101+18]");
										if ((nint)obj12 < 0)
										{
											object obj13 = obj10 + 1;
											if ((object)character._weaponsManager != null)
											{
												CharacterWeaponsManager weaponsManager2 = character._weaponsManager;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v640 @ rdx_v101+20+v604 @ stack_-90_v43*4]");
												Weapon weaponByType = weaponsManager2.GetWeaponByType(WeaponType.VOID, searchHidden: true);
												num4 = (nint)typeof(UnityEngine.Object);
												bool flag8 = (object)weaponByType == null;
												obj10 = obj13;
												if (flag8)
												{
													continue;
												}
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2829 @ rax_v243 (VampireSurvivors.Objects.Weapons.Weapon)+10]");
												bool flag9 = (nint)0 == 0;
												obj10 = obj13;
												num4 = (nint)typeof(UnityEngine.Object);
												if (!flag9)
												{
													if (list2 == null)
													{
														throw new NullReferenceException();
													}
													List<Equipment> list3 = Enumerable.ToList((IEnumerable<Equipment>)list2);
													obj10 = obj13;
												}
												continue;
											}
											throw new NullReferenceException();
										}
										throw new IndexOutOfRangeException();
									}
									throw new NullReferenceException();
								}
								throw new NullReferenceException();
							}
							bool flag10 = obj7 == null;
							num4 = 0;
							if (!flag10)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v614 @ stack_-98_v45+1C]");
								if (obj8 == null)
								{
									num5 = 0;
									num6 = unchecked((nint)null);
									goto IL_0eb3;
								}
								System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_EnumFailedVersion();
								num4 = unchecked((nint)null);
							}
							throw new NullReferenceException();
						}
						num5 = 0;
						num6 = unchecked((nint)null);
						goto IL_0eb3;
					}
				}
			}
		}
		goto IL_0c43;
		IL_0fc6:
		RectTransform component = GetComponent<RectTransform>();
		LayoutRebuilder.ForceRebuildLayoutImmediate(component);
		Canvas.ForceUpdateCanvases();
		WaitAndRefresh();
		return;
		IL_0eb3:
		if (list != null)
		{
			List<Equipment>.Enumerator enumerator = default(List<Equipment>.Enumerator);
			if (enumerator.MoveNext())
			{
				nint num7 = unchecked((nint)null);
				Dictionary<System.Int32Enum, object> dictionary = (Dictionary<System.Int32Enum, object>)(&enumerator);
				throw new NullReferenceException();
			}
			if (list2 != null)
			{
				List<Equipment>.Enumerator enumerator2 = default(List<Equipment>.Enumerator);
				if (enumerator2.MoveNext())
				{
					nint num8 = unchecked((nint)null);
					List<Equipment>.Enumerator enumerator3 = (List<Equipment>.Enumerator)(&enumerator2);
					throw new NullReferenceException();
				}
				if (_spawned != null)
				{
					IntPtr intPtr = num6;
					List<GameObject>.Enumerator enumerator4 = default(List<GameObject>.Enumerator);
					if (enumerator4.MoveNext())
					{
						GameObject gameObject2 = null;
						throw new NullReferenceException();
					}
					if (num6 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3341 @ rdi_v47 (Il2CppMethodInfo)+10]");
						if ((nint)0 != 0 && intPtr != (IntPtr)0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v385 @ rbx_v50 (Il2CppMethodInfo)+10]");
							if ((nint)0 != 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3341 @ rdi_v47 (Il2CppMethodInfo)+10]");
								bool flag11 = (nint)0 == 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3341 @ rdi_v47 (Il2CppMethodInfo)+10]");
								IntPtr gcHandlePtr = Component.get_transform_Injected((IntPtr)0);
								Transform transform = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr);
								if ((object)transform != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v418 @ rax_v159 (UnityEngine.Transform)+10]");
									bool flag12 = (nint)0 == 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v418 @ rax_v159 (UnityEngine.Transform)+10]");
									Transform.SetSiblingIndex_Injected((IntPtr)0, 0);
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v385 @ rbx_v50 (Il2CppMethodInfo)+10]");
									bool flag13 = (nint)0 == 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v385 @ rbx_v50 (Il2CppMethodInfo)+10]");
									IntPtr gcHandlePtr2 = Component.get_transform_Injected((IntPtr)0);
									Transform transform2 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr2);
									if ((object)transform2 != null)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v419 @ rax_v168 (UnityEngine.Transform)+10]");
										bool flag14 = (nint)0 == 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v419 @ rax_v168 (UnityEngine.Transform)+10]");
										Transform.SetSiblingIndex_Injected((IntPtr)0, 1);
										goto IL_0fc6;
									}
								}
								goto IL_0c43;
							}
						}
					}
					goto IL_0fc6;
				}
			}
		}
		goto IL_0c43;
		IL_0c43:
		throw new NullReferenceException();
	}

	private void WaitAndRefresh()
	{
		//IL_0394: Expected O, but got I4
		//IL_012d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0132: Expected O, but got Unknown
		//IL_0054->IL02d0: Incompatible stack heights: 1 vs 0
		//IL_035f->IL02d0: Incompatible stack heights: 2 vs 0
		//IL_02b7->IL02cf: Incompatible stack heights: 2 vs 0
		//IL_013f->IL03b5: Incompatible stack heights: 3 vs 0
		//IL_009c->IL02d0: Incompatible stack heights: 3 vs 0
		//IL_00cb->IL02d0: Incompatible stack heights: 3 vs 0
		//IL_00f5->IL02d0: Incompatible stack heights: 3 vs 0
		//IL_040a->IL040a: Incompatible stack heights: 5 vs 0
		GridLayoutGroup[] componentsInChildren = GetComponentsInChildren<GridLayoutGroup>();
		bool flag = componentsInChildren == null;
		object obj = null;
		object obj2 = null;
		if (!flag)
		{
			Vector2 cellSize = default(Vector2);
			List<GameObject>.Enumerator enumerator = default(List<GameObject>.Enumerator);
			object obj4 = default(object);
			while (true)
			{
				if ((nint)obj2 < componentsInChildren.Length)
				{
					bool flag2 = (nint)obj >= componentsInChildren.Length;
					GridLayoutGroup gridLayoutGroup = componentsInChildren[obj];
					if ((object)componentsInChildren[obj] == null)
					{
						break;
					}
					bool flag3 = ((UnityEngine.Object)gridLayoutGroup).m_CachedPtr == (IntPtr)0;
					IntPtr gcHandlePtr = Component.get_transform_Injected(((UnityEngine.Object)gridLayoutGroup).m_CachedPtr);
					Transform transform = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr);
					if ((object)transform == null)
					{
						break;
					}
					bool flag4 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
					object obj3 = Transform.get_childCount_Injected(((UnityEngine.Object)transform).m_CachedPtr);
					if ((nint)obj3 > 0)
					{
						Transform transform2 = componentsInChildren[obj].transform;
						if ((object)transform2 == null)
						{
							break;
						}
						Transform child = transform2.GetChild(0);
						if ((object)child == null)
						{
							break;
						}
						RectTransform component = child.GetComponent<RectTransform>();
						if ((object)component == null)
						{
							break;
						}
						Vector2 sizeDelta = component.sizeDelta;
						componentsInChildren[obj].cellSize = cellSize;
					}
					obj++;
					obj2 = obj;
					continue;
				}
				if (_spawned == null)
				{
					break;
				}
				while (enumerator.MoveNext())
				{
					Transform transform3 = ((GameObject)null).transform;
					bool flag5 = (object)transform3 == null;
					Transform parent = transform3.parent;
					bool flag6 = (object)parent == null;
					GridLayoutGroup component2 = parent.GetComponent<GridLayoutGroup>();
					if ((object)component2 != null && ((UnityEngine.Object)component2).m_CachedPtr != (IntPtr)0)
					{
						RectTransform component3 = ((GameObject)null).GetComponent<RectTransform>();
						bool flag7 = (object)component3 == null;
						Vector2 sizeDelta2 = component3.sizeDelta;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1199 @ rax_v27 (UnityEngine.UI.GridLayoutGroup)+6C]");
						if ((nint)obj4 > 0)
						{
							component2.cellSize = cellSize;
						}
						Image component4 = ((GameObject)null).GetComponent<Image>();
						bool flag8 = (object)component4 == null;
						bool flag9 = (object)component4.m_Sprite == null;
						Rect rect = component4.m_Sprite.rect;
						component2.cellSize = cellSize;
						continue;
					}
					return;
				}
				RectTransform component5 = GetComponent<RectTransform>();
				LayoutRebuilder.ForceRebuildLayoutImmediate(component5);
				Canvas.ForceUpdateCanvases();
				return;
			}
		}
		throw new NullReferenceException();
	}

	private EquipmentIconPaused Spawn(WeaponType t, Sprite s, int level, int maxLevel, RectTransform rTrans, bool isBanished)
	{
		Transform parent = default(Transform);
		GameObject gameObject = UnityEngine.Object.Instantiate(_EquipmentIconPrefab, parent);
		if ((object)gameObject != null)
		{
			EquipmentIconPaused component = gameObject.GetComponent<EquipmentIconPaused>();
			if ((object)component != null)
			{
				int maxLevel2 = default(int);
				Sprite s2 = default(Sprite);
				bool isBanished2 = default(bool);
				component.SetData(t, level, maxLevel2, s2, isBanished2);
				if (_spawned != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180497F80");
					return component;
				}
			}
		}
		return (EquipmentIconPaused)(object)new NullReferenceException();
	}

	private void ClearSpawned()
	{
		//IL_0087: Expected I4, but got O
		//IL_0087: Expected O, but got I
		bool flag = _spawned == null;
		PauseEquipmentPanel pauseEquipmentPanel = this;
		if (!flag)
		{
			List<GameObject>.Enumerator enumerator = default(List<GameObject>.Enumerator);
			while (enumerator.MoveNext())
			{
				UnityEngine.Object.Destroy(null, 0f);
			}
			pauseEquipmentPanel = (PauseEquipmentPanel)(object)_spawned;
			if (_spawned != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rcx_v2 (VampireSurvivors.UI.PauseEquipmentPanel)+1C]");
				_ = (nint)0 + (nint)1;
				((MonoBehaviour)pauseEquipmentPanel).m_CancellationTokenSource = null;
				if ((nint)((MonoBehaviour)pauseEquipmentPanel).m_CancellationTokenSource > 0)
				{
					Array.Clear((Array)(nint)((UnityEngine.Object)pauseEquipmentPanel).m_CachedPtr, 0, (int)((MonoBehaviour)pauseEquipmentPanel).m_CancellationTokenSource);
				}
				return;
			}
		}
		throw new NullReferenceException();
	}

	public PauseEquipmentPanel()
	{
		List<GameObject> spawned = new List<GameObject>();
		_spawned = spawned;
	}
}
