using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.UI;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Items;
using VampireSurvivors.Data.Stage;
using VampireSurvivors.Framework.DLC;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects;

namespace VampireSurvivors.UI;

public class RelicPanel : MonoBehaviour
{
	private GameObject _Prefab;

	private RectTransform _Container;

	private List<GameObject> _spawned;

	private List<ItemType> _spawnedType;

	private DataManager _data;

	private PlayerOptions _playerOptions;

	private bool _hasYellowRelic;

	private void Construct(DataManager data, PlayerOptions player)
	{
		_data = data;
		_playerOptions = player;
	}

	public unsafe void SetRelics(StageData stage, StageType stageType)
	{
		//IL_009f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a4: Expected O, but got Unknown
		//IL_014c: Expected I4, but got O
		//IL_0236: Expected I4, but got O
		//IL_04bf: Expected I4, but got O
		//IL_071b: Expected O, but got I
		//IL_0e76: Expected I, but got O
		//IL_05a8: Expected O, but got I4
		//IL_0770: Unknown result type (might be due to invalid IL or missing references)
		//IL_0775: Expected O, but got Unknown
		//IL_067d: Expected O, but got I4
		//IL_07eb: Expected O, but got I
		//IL_0cc3: Expected O, but got I4
		//IL_10b7: Expected I4, but got O
		//IL_10b7: Expected I, but got O
		//IL_08fb: Expected O, but got I
		//IL_08fb: Expected O, but got I
		//IL_117f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1184: Expected I4, but got Unknown
		//IL_11a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_11a8: Expected I4, but got Unknown
		//IL_11c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_11cc: Expected Ref, but got Unknown
		//IL_1156: Unknown result type (might be due to invalid IL or missing references)
		//IL_115b: Expected I4, but got Unknown
		//IL_10df: Unknown result type (might be due to invalid IL or missing references)
		//IL_10e4: Expected I4, but got Unknown
		//IL_1103: Unknown result type (might be due to invalid IL or missing references)
		//IL_1108: Expected I4, but got Unknown
		//IL_0ab7: Expected O, but got Ref
		//IL_1127: Unknown result type (might be due to invalid IL or missing references)
		//IL_112c: Expected Ref, but got Unknown
		//IL_09ff: Expected O, but got Ref
		//IL_0b58: Expected O, but got I
		//IL_0aa0: Expected O, but got I
		//IL_0b94: Expected I4, but got O
		//IL_1082->IL0db0: Incompatible stack heights: 1 vs 0
		//IL_0c33->IL0db0: Incompatible stack heights: 1 vs 0
		//IL_0ce2->IL0db0: Incompatible stack heights: 2 vs 0
		//IL_0d1a->IL0db0: Incompatible stack heights: 2 vs 0
		//IL_0da6->IL0db0: Incompatible stack heights: 2 vs 0
		//IL_0d59->IL0db0: Incompatible stack heights: 2 vs 0
		PlayerOptions playerOptions = _playerOptions;
		nint num = default(nint);
		List<ItemType> list;
		PlayerOptionsData playerOptionsData;
		if (_playerOptions != null)
		{
			PlayerOptionsData config = _playerOptions.Config;
			if (config != null)
			{
				playerOptions = (PlayerOptions)(object)config._003CCollectedItems_003Ek__BackingField;
				if (config._003CCollectedItems_003Ek__BackingField != null)
				{
					bool hasYellowRelic;
					if (playerOptions.PowerUpPurchased == null)
					{
						hasYellowRelic = false;
					}
					else
					{
						playerOptions = (PlayerOptions)(object)playerOptions.RunGoldUpdated;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
						object obj2 = default(object);
						object obj = obj2 - -1;
						bool flag = obj == null;
						hasYellowRelic = !flag;
						num = 0;
					}
					_hasYellowRelic = hasYellowRelic;
					if (_spawned != null)
					{
						List<GameObject>.Enumerator enumerator = default(List<GameObject>.Enumerator);
						while (enumerator.MoveNext())
						{
							UnityEngine.Object.Destroy(null, 0f);
						}
						playerOptions = (PlayerOptions)(object)_spawned;
						if (_spawned != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v194 @ rcx_v138 (VampireSurvivors.Objects.PlayerOptions)+1C]");
							_ = (nint)0 + (nint)1;
							playerOptions.PowerUpPurchased = null;
							if ((nint)playerOptions.PowerUpPurchased > 0)
							{
								Array.Clear((Array)(object)playerOptions.RunGoldUpdated, 0, (int)playerOptions.PowerUpPurchased);
							}
							playerOptions = (PlayerOptions)(object)_spawnedType;
							if (_spawnedType != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v194 @ rcx_v138 (VampireSurvivors.Objects.PlayerOptions)+1C]");
								_ = (nint)0 + (nint)1;
								playerOptions.PowerUpPurchased = null;
								list = new List<ItemType>();
								bool flag2 = stage == null;
								playerOptions = (PlayerOptions)(object)list;
								if (!flag2)
								{
									bool flag3 = stage._003Crelics_003Ek__BackingField == null;
									playerOptions = (PlayerOptions)(object)list;
									if (!flag3)
									{
										bool flag4 = list == null;
										playerOptions = (PlayerOptions)(object)list;
										if (flag4)
										{
											goto IL_0db0;
										}
										((List<System.Int32Enum>)(object)list).InsertRange((int)((PlayerOptionsData)(object)list)._003CPlatform_003Ek__BackingField, (IEnumerable<System.Int32Enum>)stage._003Crelics_003Ek__BackingField);
										playerOptions = (PlayerOptions)(object)list;
									}
									if (stageType != StageType.TP_CASTLE)
									{
										goto IL_0446;
									}
									PlayerOptions playerOptions2 = _playerOptions;
									if (_playerOptions != null)
									{
										if (playerOptions2._onlineClientWithRunDataConfig == null)
										{
											if (playerOptions2._hostGameConfig == null)
											{
												if (playerOptions2._currentAdventureSaveData != null)
												{
													PlayerOptionsData currentAdventureSaveData = playerOptions2._currentAdventureSaveData;
													if ((object)currentAdventureSaveData._003CSelectedAdventureType_003Ek__BackingField != null)
													{
														playerOptionsData = currentAdventureSaveData;
														goto IL_0f9b;
													}
												}
												playerOptionsData = playerOptions2._mainGameConfig;
											}
											else
											{
												playerOptionsData = playerOptions2._hostGameConfig;
											}
										}
										else
										{
											playerOptionsData = playerOptions2._onlineClientWithRunDataConfig;
										}
										goto IL_0f9b;
									}
								}
							}
						}
					}
				}
			}
		}
		goto IL_0db0;
		IL_0f9b:
		if (playerOptionsData != null)
		{
			playerOptions = (PlayerOptions)(object)playerOptionsData._003CCollectedItems_003Ek__BackingField;
			if (playerOptionsData._003CCollectedItems_003Ek__BackingField != null)
			{
				if (playerOptions.PowerUpPurchased != null)
				{
					playerOptions = (PlayerOptions)(object)playerOptions.RunGoldUpdated;
					((List<ItemType>)(object)playerOptions.RunGoldUpdated).InsertRange(219, (IEnumerable<ItemType>)null);
					object obj3 = default(object);
					bool flag5 = (nint)obj3 == -1;
					num = 0;
					if (!flag5)
					{
						if (list == null)
						{
							goto IL_0db0;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1372 @ rax_v70 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+1C]");
						_ = (nint)0 + (nint)1;
						((PlayerOptionsData)(object)list)._003CPlatform_003Ek__BackingField = null;
						bool flag6 = stage._003Crelics2_003Ek__BackingField == null;
						num = 0;
						if (!flag6)
						{
							((List<System.Int32Enum>)(object)list).InsertRange(0, (IEnumerable<System.Int32Enum>)stage._003Crelics2_003Ek__BackingField);
							num = 0;
							playerOptions = (PlayerOptions)(object)list;
						}
					}
				}
				goto IL_0446;
			}
		}
		goto IL_0db0;
		IL_04e4:
		if (stageType == StageType.SINKING && ((PlayerOptionsData)(object)list)._003CPlatform_003Ek__BackingField != null)
		{
			((List<ItemType>)(object)((PlayerOptionsData)(object)list)._003CsaveDate_003Ek__BackingField).InsertRange(100, (IEnumerable<ItemType>)null);
			object obj4 = default(object);
			if ((nint)obj4 != -1)
			{
				Dictionary<DlcType, BundleManifestData> loadedDlc = DlcSystem.LoadedDlc;
				bool flag7 = loadedDlc == null;
				playerOptions = null;
				if (flag7)
				{
					goto IL_0db0;
				}
				int num2 = ((Dictionary<System.Int32Enum, object>)(object)loadedDlc).FindEntry((System.Int32Enum)4);
				object obj5 = !flag7;
				if (obj5 == null)
				{
					bool flag8 = ((List<System.Int32Enum>)(object)list).Remove((System.Int32Enum)100);
				}
			}
			bool flag9 = ((PlayerOptionsData)(object)list)._003CPlatform_003Ek__BackingField == null;
			num = 0;
			if (!flag9)
			{
				((List<ItemType>)(object)((PlayerOptionsData)(object)list)._003CsaveDate_003Ek__BackingField).InsertRange(400, (IEnumerable<ItemType>)null);
				object obj6 = default(object);
				bool flag10 = (nint)obj6 == -1;
				num = 0;
				if (!flag10)
				{
					Dictionary<DlcType, BundleManifestData> loadedDlc2 = DlcSystem.LoadedDlc;
					bool flag11 = loadedDlc2 == null;
					playerOptions = null;
					if (flag11)
					{
						goto IL_0db0;
					}
					int num3 = ((Dictionary<System.Int32Enum, object>)(object)loadedDlc2).FindEntry((System.Int32Enum)6);
					object obj7 = !flag11;
					num = 0;
					if (obj7 == null)
					{
						bool flag12 = ((List<System.Int32Enum>)(object)list).Remove((System.Int32Enum)400);
						num = 0;
					}
				}
			}
		}
		PlayerOptionsData playerOptionsData2 = (PlayerOptionsData)(object)list;
		object obj8 = default(object);
		object obj9 = default(object);
		object obj11 = default(object);
		object obj15 = default(object);
		while (true)
		{
			if (obj8 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v85 @ stack_-A8_v29+1C]");
				if (obj9 != null)
				{
					break;
				}
				object obj10 = obj11;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v85 @ stack_-A8_v29+18]");
				if ((nint)obj10 >= 0)
				{
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v85 @ stack_-A8_v29+10]");
				object obj12 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v85 @ stack_-A8_v29+10]");
				if ((nint)0 != 0)
				{
					object obj13 = obj11;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v504 @ rdx_v62+18]");
					if ((nint)obj13 < 0)
					{
						object obj14 = obj11 + 1;
						List<ItemType> spawnedType = _spawnedType;
						if (_spawnedType != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1656 @ rcx_v95 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
							bool flag13 = (nint)0 == 0;
							nint num4 = num;
							if (!flag13)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1656 @ rcx_v95 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+10]");
								nint num5 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v504 @ rdx_v62+20+v481 @ stack_-A0_v27*4]");
								((List<ItemType>)num5).InsertRange(0, null);
								bool flag14 = (nint)obj15 != -1;
								num4 = 0;
								obj11 = obj14;
								num = 0;
								if (flag14)
								{
									continue;
								}
							}
							DataManager data = _data;
							if (_data != null)
							{
								if (data._003CAllItems_003Ek__BackingField != null)
								{
									Dictionary<ItemType, ItemData> dictionary = data._003CAllItems_003Ek__BackingField;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v504 @ rdx_v62+20+v481 @ stack_-A0_v27*4]");
									bool flag15 = ((Dictionary<System.Int32Enum, object>)(object)dictionary).TryGetValue((System.Int32Enum)0, out object value);
									bool flag16 = !flag15;
									obj11 = obj14;
									num = num4;
									if (flag16)
									{
										continue;
									}
									if (value != null)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v549 @ stack_-88_v29 (System.Object)+38]");
										nint num6 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v549 @ stack_-88_v29 (System.Object)+30]");
										Sprite sprite = SpriteManager.GetSprite((string)num6, (string)0);
										GameObject gameObject = UnityEngine.Object.Instantiate(_Prefab, _Container);
										if ((object)gameObject != null)
										{
											gameObject.SetActive(value: true);
											Image component = gameObject.GetComponent<Image>();
											if ((object)component != null)
											{
												component.sprite = sprite;
												if (_playerOptions != null)
												{
													PlayerOptionsData config2 = _playerOptions.Config;
													if (config2 != null)
													{
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v504 @ rdx_v62+20+v2527 @ rcx_v94*4]");
														IEnumerable<ItemType> collection;
														if (!config2.HasCollectedItem(ItemType.VOID))
														{
															component.color = (Color)(&playerOptionsData2);
															Transform transform = gameObject.transform;
															if ((object)transform == null)
															{
																throw new NullReferenceException();
															}
															Transform child = transform.GetChild(0);
															if ((object)child == null)
															{
																throw new NullReferenceException();
															}
															GameObject gameObject2 = child.gameObject;
															if ((object)gameObject2 == null)
															{
																throw new NullReferenceException();
															}
															gameObject2.SetActive(value: false);
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12500]");
															playerOptionsData2 = (PlayerOptionsData)0;
															collection = null;
														}
														else
														{
															component.color = (Color)(&playerOptionsData2);
															Transform transform2 = gameObject.transform;
															if ((object)transform2 == null)
															{
																throw new NullReferenceException();
															}
															Transform child2 = transform2.GetChild(0);
															if ((object)child2 == null)
															{
																throw new NullReferenceException();
															}
															GameObject gameObject3 = child2.gameObject;
															if ((object)gameObject3 == null)
															{
																throw new NullReferenceException();
															}
															gameObject3.SetActive(value: true);
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A11DE0]");
															playerOptionsData2 = (PlayerOptionsData)0;
															collection = null;
														}
														if (_spawned != null)
														{
															((List<ItemType>)(object)_spawned).InsertRange((int)gameObject, collection);
															if (_spawnedType != null)
															{
																List<ItemType> spawnedType2 = _spawnedType;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v504 @ rdx_v62+20+v481 @ stack_-A0_v27*4]");
																spawnedType2.InsertRange(0, collection);
																obj11 = obj14;
																num = num4;
																continue;
															}
															throw new NullReferenceException();
														}
														throw new NullReferenceException();
													}
													throw new NullReferenceException();
												}
												throw new NullReferenceException();
											}
											throw new NullReferenceException();
										}
										throw new NullReferenceException();
									}
									throw new NullReferenceException();
								}
								throw new NullReferenceException();
							}
							throw new NullReferenceException();
						}
						throw new NullReferenceException();
					}
					throw new IndexOutOfRangeException();
				}
				throw new NullReferenceException();
			}
			throw new NullReferenceException();
		}
		bool flag17 = obj8 == null;
		nint num7 = 0;
		if (!flag17)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v85 @ stack_-A8_v29+1C]");
			if (obj9 == null)
			{
				bool flag18 = ((UnityEngine.Object)this).m_CachedPtr == (IntPtr)0;
				IntPtr gcHandlePtr = Component.get_gameObject_Injected(((UnityEngine.Object)this).m_CachedPtr);
				GameObject gameObject4 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<GameObject>(gcHandlePtr);
				List<GameObject> spawned = _spawned;
				if (_spawned != null && (object)gameObject4 != null)
				{
					bool flag19 = ((PlayerOptionsData)(object)gameObject4)._003CsaveDate_003Ek__BackingField == null;
					int num8 = spawned._size ^ spawned._size;
					int num9 = spawned._size & num8;
					bool flag20 = num9 < 0;
					bool flag21 = spawned._size < 0;
					bool flag22 = spawned._size == 0;
					bool flag23 = flag21 == flag20;
					bool flag24 = !flag22;
					PlayerOptionsData playerOptionsData3 = (PlayerOptionsData)(flag24 & flag23);
					GameObject.SetActive_Injected((IntPtr)((PlayerOptionsData)(object)gameObject4)._003CsaveDate_003Ek__BackingField, (byte)(int)playerOptionsData3 != 0);
					if (_spawned == null)
					{
						return;
					}
					if ((object)_Container != null)
					{
						GridLayoutGroup component2 = _Container.GetComponent<GridLayoutGroup>();
						List<GameObject> spawned2 = _spawned;
						if (_spawned != null)
						{
							IEnumerable<ItemType> collection2 = default(IEnumerable<ItemType>);
							int constraintCount;
							if (spawned2._size >= 5)
							{
								if ((object)component2 == null)
								{
									goto IL_0db0;
								}
								if (spawned2._size < 7)
								{
									int index = component2 + 104;
									((List<ItemType>)(object)component2).InsertRange(index, collection2);
								}
								else
								{
									int index2 = component2 + 104;
									((List<ItemType>)(object)component2).InsertRange(index2, collection2);
								}
								int index3 = component2 + 112;
								((List<ItemType>)(object)component2).InsertRange(index3, collection2);
								((LayoutGroup)component2).SetProperty<System.Int32Enum>(ref *(System.Int32Enum*)(component2 + 120), (System.Int32Enum)1);
								constraintCount = 6;
							}
							else
							{
								if ((object)component2 == null)
								{
									goto IL_0db0;
								}
								int index4 = component2 + 104;
								((List<ItemType>)(object)component2).InsertRange(index4, collection2);
								int index5 = component2 + 112;
								((List<ItemType>)(object)component2).InsertRange(index5, collection2);
								((LayoutGroup)component2).SetProperty<System.Int32Enum>(ref *(System.Int32Enum*)(component2 + 120), (System.Int32Enum)1);
								constraintCount = 4;
							}
							component2.constraintCount = constraintCount;
							return;
						}
					}
				}
				goto IL_0db0;
			}
			System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_EnumFailedVersion();
			num7 = unchecked((nint)null);
		}
		throw new NullReferenceException();
		IL_0446:
		if (_hasYellowRelic && stage._003CyellowRelics_003Ek__BackingField != null)
		{
			if (list != null)
			{
				((List<System.Int32Enum>)(object)list).InsertRange((int)((PlayerOptionsData)(object)list)._003CPlatform_003Ek__BackingField, (IEnumerable<System.Int32Enum>)stage._003CyellowRelics_003Ek__BackingField);
				goto IL_04e4;
			}
		}
		else if (list != null)
		{
			goto IL_04e4;
		}
		goto IL_0db0;
		IL_0db0:
		throw new NullReferenceException();
	}

	public RelicPanel()
	{
		List<GameObject> spawned = new List<GameObject>();
		_spawned = spawned;
		List<ItemType> spawnedType = new List<ItemType>();
		_spawnedType = spawnedType;
	}
}
