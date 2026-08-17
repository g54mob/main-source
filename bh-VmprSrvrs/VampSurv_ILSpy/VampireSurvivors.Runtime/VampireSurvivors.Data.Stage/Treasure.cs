using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Items;
using VampireSurvivors.Objects.Pickups;

namespace VampireSurvivors.Data.Stage;

[Serializable]
public class Treasure
{
	private sealed class _003C_003Ec__DisplayClass35_0
	{
		public float x;

		public float y;

		public WeaponType weaponPrize;

		internal void _003CSpawnWorldSpaceWeapon_003Eb__0()
		{
			//IL_0061: Expected I, but got O
			//IL_006f: Expected I, but got O
			//IL_007f: Expected O, but got I
			//IL_00ff: Expected O, but got I4
			//IL_00bb: Expected O, but got I
			//IL_00f1: Expected O, but got I4
			Vector2 pos = default(Vector2);
			float value = default(float);
			ItemType relicType = default(ItemType);
			bool shouldCallValidatePickups = default(bool);
			bool isRemote = default(bool);
			Pickup pickup = GM.Core.MakePickup(pos, ItemType.WEAPON, weaponPrize, value, relicType, shouldCallValidatePickups, isRemote, onlineSynchronization: false);
			bool flag = (object)pickup == null;
			Pickup pickup2 = null;
			object obj3;
			if (!flag)
			{
				nint num = (nint)pickup;
				nint num2 = (nint)typeof(PickupWeapon);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v173 @ rdx_v6 (Il2CppClass<VampireSurvivors.Objects.Items.PickupWeapon>)+130]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v172 @ r8_v6 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+130]");
				nint num3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v173 @ rdx_v6 (Il2CppClass<VampireSurvivors.Objects.Items.PickupWeapon>)+130]");
				if (num3 >= 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v172 @ r8_v6 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+C8]");
					object obj2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v265 @ rax_v27+FFFFFFF8+v174 @ rax_v23*8]");
					if (0 == (nint)typeof(PickupWeapon))
					{
						obj3 = 1;
						goto IL_018e;
					}
				}
				obj3 = 0;
				goto IL_018e;
			}
			goto IL_01b5;
			IL_01b5:
			if ((object)pickup2 != null && ((UnityEngine.Object)pickup2).m_CachedPtr != (IntPtr)0)
			{
				_ = 1;
				GM.Core.RegisterStagePickup(pickup2);
			}
			GameManager core = GM.Core;
			core._gizmoManager.ShowHighlightAt(x, y);
			return;
			IL_018e:
			bool flag2 = obj3 == null;
			pickup2 = null;
			if (!flag2)
			{
				pickup2 = pickup;
			}
			goto IL_01b5;
		}
	}

	private List<float> _003Cchances_003Ek__BackingField;

	private int _003Clevel_003Ek__BackingField;

	private List<PrizeType?> _003CprizeTypes_003Ek__BackingField;

	private List<WeaponType> _003CfixedPrizes_003Ek__BackingField;

	private bool _003ChasArcana_003Ek__BackingField;

	private bool _003ChasRandoms_003Ek__BackingField;

	[NonSerialized]
	public bool QuickTreasureAnim;

	[NonSerialized]
	public VampireSurvivors.Objects.Characters.CharacterController openingPlayer;

	[NonSerialized]
	public VampireSurvivors.Objects.Characters.CharacterController winningPlayer;

	[NonSerialized]
	public List<TreasurePrizeTypePair> prizes;

	[NonSerialized]
	public List<WeaponType> accumulatedWeaponPrizes;

	[NonSerialized]
	public float accumulatedCoinPrize;

	[NonSerialized]
	public float quickAddedCoins;

	[NonSerialized]
	public List<WeaponType> accumulatedWorldSpacePrizes;

	public List<float> chances
	{
		get
		{
			return _003Cchances_003Ek__BackingField;
		}
		set
		{
			_003Cchances_003Ek__BackingField = value;
		}
	}

	public int level
	{
		get
		{
			return _003Clevel_003Ek__BackingField;
		}
		set
		{
			_003Clevel_003Ek__BackingField = value;
		}
	}

	public List<PrizeType?> prizeTypes
	{
		get
		{
			return _003CprizeTypes_003Ek__BackingField;
		}
		set
		{
			_003CprizeTypes_003Ek__BackingField = value;
		}
	}

	public List<WeaponType> fixedPrizes
	{
		get
		{
			return _003CfixedPrizes_003Ek__BackingField;
		}
		set
		{
			_003CfixedPrizes_003Ek__BackingField = value;
		}
	}

	public bool hasArcana
	{
		get
		{
			return _003ChasArcana_003Ek__BackingField;
		}
		set
		{
			_003ChasArcana_003Ek__BackingField = value;
		}
	}

	public bool hasRandoms
	{
		get
		{
			return _003ChasRandoms_003Ek__BackingField;
		}
		set
		{
			_003ChasRandoms_003Ek__BackingField = value;
		}
	}

	public void AddPrizes(List<TreasurePrizeTypePair> argPrizes, List<WeaponType> argAccumulatedWeaponPrizes, int argAccumulatedCoinPrize, List<WeaponType> argAccumulatedWorldSpacePrizes = null)
	{
		//IL_0038: Expected F4, but got I4
		prizes = argPrizes;
		accumulatedWeaponPrizes = argAccumulatedWeaponPrizes;
		accumulatedCoinPrize = argAccumulatedCoinPrize;
		List<WeaponType> list = default(List<WeaponType>);
		if (list != null)
		{
			accumulatedWorldSpacePrizes = list;
		}
	}

	public int GetCoinPrize()
	{
		//IL_00cf: Expected I4, but got O
		//IL_006b: Expected I, but got O
		//IL_00bb: Expected I4, but got I8
		GameManager core = GM.Core;
		if ((object)GM.Core != null)
		{
			GameSessionData gameSessionData = core._gameSessionData;
			if (core._gameSessionData != null)
			{
				VampireSurvivors.Objects.Characters.CharacterController activeCharacter = gameSessionData._activeCharacter;
				if ((object)gameSessionData._activeCharacter != null)
				{
					nint num = (nint)activeCharacter;
					float num2 = gameSessionData._activeCharacter.PGreed();
					float num3 = accumulatedCoinPrize * GameManager.GoldMultiplier;
					object obj = default(object);
					float num4 = num3 * (float)obj;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185003E40");
					if (num4 < 2.1474836E+09f)
					{
						if (-2.1474836E+09f < num4)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm0\"");
							int result = default(int);
							return result;
						}
						return -2147483648;
					}
					return 2147483647;
				}
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (int)ex;
	}

	public unsafe void ClaimPrizes(VampireSurvivors.Objects.Characters.CharacterController character)
	{
		//IL_056c: Expected O, but got I
		//IL_0103: Expected O, but got I
		//IL_01e1: Expected O, but got I
		//IL_0584: Expected I4, but got O
		//IL_058f: Expected I4, but got O
		//IL_0158: Unknown result type (might be due to invalid IL or missing references)
		//IL_015d: Expected O, but got Unknown
		//IL_0260: Expected O, but got I
		//IL_0295: Unknown result type (might be due to invalid IL or missing references)
		//IL_029a: Expected O, but got Unknown
		//IL_032a: Expected O, but got I
		//IL_03a8: Expected O, but got I
		//IL_0786->IL04bd: Incompatible stack heights: 3 vs 0
		//IL_04a5->IL04bd: Incompatible stack heights: 3 vs 0
		//IL_0312->IL05fb: Incompatible stack heights: 3 vs 2
		//IL_0390->IL06b2: Incompatible stack heights: 5 vs 4
		//IL_045b->IL0732: Incompatible stack heights: 5 vs 0
		GameManager core = GM.Core;
		if ((object)GM.Core != null && core._playerOptions != null)
		{
			float num = core._playerOptions.AddCoins(accumulatedCoinPrize, character);
			quickAddedCoins = num;
			if (accumulatedWeaponPrizes != null)
			{
				object obj = default(object);
				object obj2 = default(object);
				object obj4 = default(object);
				while (true)
				{
					if (obj != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v146 @ stack_-108_v24+1C]");
						if (obj2 == null)
						{
							object obj3 = obj4;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v146 @ stack_-108_v24+18]");
							if ((nint)obj3 < 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v146 @ stack_-108_v24+10]");
								object obj5 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v146 @ stack_-108_v24+10]");
								if ((nint)0 != 0)
								{
									object obj6 = obj4;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v286 @ rdx_v47+18]");
									if ((nint)obj6 < 0)
									{
										obj4++;
										if ((object)GM.Core != null)
										{
											GameManager core2 = GM.Core;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v286 @ rdx_v47+20+v922 @ rcx_v73*4]");
											core2.LevelWeaponUp(WeaponType.VOID, removeFromStore: false, character);
											continue;
										}
										throw new NullReferenceException();
									}
									throw new IndexOutOfRangeException();
								}
								throw new NullReferenceException();
							}
							break;
						}
						break;
					}
					throw new NullReferenceException();
				}
				bool flag = obj == null;
				PlayerOptions playerOptions = (PlayerOptions)0;
				if (!flag)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v146 @ stack_-108_v24+1C]");
					if (obj2 == null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v146 @ stack_-108_v24+18]");
						object obj7 = (nint)0 + (nint)1;
						bool flag2 = (byte)(int)accumulatedWorldSpacePrizes != 0;
						if ((int)(~accumulatedWorldSpacePrizes) == 0)
						{
							bool flag3 = false;
							object obj8 = obj7;
							object obj9 = default(object);
							object obj15 = default(object);
							bool useRealTime = default(bool);
							MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
							int repeat = default(int);
							TimerType type = default(TimerType);
							while (true)
							{
								bool flag4 = obj9 == null;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v145 @ stack_-108_v26+1C]");
								if (obj2 != null)
								{
									break;
								}
								object obj10 = obj8;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v145 @ stack_-108_v26+18]");
								if ((nint)obj10 >= 0)
								{
									break;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v145 @ stack_-108_v26+10]");
								object obj11 = 0;
								object obj12 = obj8;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v811 @ rdx_v37+18]");
								if ((nint)obj12 < 0)
								{
									object obj13 = obj8 + 1;
									Transform cachedTrans = ((ArcadeSprite)character).CachedTrans;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1999 @ rax_v78 (UnityEngine.Transform)+10]");
									bool flag5 = (nint)0 == 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1999 @ rax_v78 (UnityEngine.Transform)+10]");
									float2 ret;
									Transform.get_position_Injected((IntPtr)0, out *(Vector3*)(&ret));
									float2 float5;
									if (character.body != null)
									{
										BaseBody body = character.body;
										ArcadeTransform transform = body._transform;
										bool flag6 = body._transform == null;
										transform.position = ret;
										float5 = ret;
									}
									else
									{
										float5 = ret;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1999 @ rax_v78 (UnityEngine.Transform)+10]");
										ArcadeTransform transform = (ArcadeTransform)0;
									}
									float num2 = (float)(flag3 ? 1 : 0) * ((float)Math.PI * 2f / 5f);
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
									float num3 = num2 * 1.65f;
									float x = (float)float5 + num3;
									Transform cachedTrans2 = ((ArcadeSprite)character).CachedTrans;
									bool flag7 = (object)cachedTrans2 == null;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1619 @ rax_v86 (UnityEngine.Transform)+10]");
									bool flag8 = (nint)0 == 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1619 @ rax_v86 (UnityEngine.Transform)+10]");
									float2 ret2;
									Transform.get_position_Injected((IntPtr)0, out *(Vector3*)(&ret2));
									object obj14;
									if (character.body != null)
									{
										BaseBody body2 = character.body;
										ArcadeTransform transform2 = body2._transform;
										bool flag9 = body2._transform == null;
										transform2.position = ret2;
										obj14 = obj15;
									}
									else
									{
										obj14 = obj15;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1619 @ rax_v86 (UnityEngine.Transform)+10]");
										ArcadeTransform transform2 = (ArcadeTransform)0;
									}
									float num4 = (float)(flag3 ? 1 : 0) * ((float)Math.PI * 2f / 5f);
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
									float num5 = num4 * 1.65f;
									float y = (float)obj14 + num5;
									float num6 = (float)(flag3 ? 1 : 0) * 50f;
									float num7 = num6 + 1f;
									_003C_003Ec__DisplayClass35_0 CS_0024_003C_003E8__locals7 = new _003C_003Ec__DisplayClass35_0();
									bool flag10 = CS_0024_003C_003E8__locals7 == null;
									CS_0024_003C_003E8__locals7.x = x;
									CS_0024_003C_003E8__locals7.y = y;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v811 @ rdx_v37+20+v801 @ stack_-100_v25*4]");
									CS_0024_003C_003E8__locals7.weaponPrize = WeaponType.VOID;
									Action onComplete = delegate
									{
										//IL_0061: Expected I, but got O
										//IL_006f: Expected I, but got O
										//IL_007f: Expected O, but got I
										//IL_00ff: Expected O, but got I4
										//IL_00bb: Expected O, but got I
										//IL_00f1: Expected O, but got I4
										Vector2 pos = default(Vector2);
										float value = default(float);
										ItemType relicType = default(ItemType);
										bool shouldCallValidatePickups = default(bool);
										bool isRemote = default(bool);
										Pickup pickup = GM.Core.MakePickup(pos, ItemType.WEAPON, CS_0024_003C_003E8__locals7.weaponPrize, value, relicType, shouldCallValidatePickups, isRemote, onlineSynchronization: false);
										bool flag13 = (object)pickup == null;
										Pickup pickup2 = null;
										object obj18;
										if (!flag13)
										{
											nint num8 = (nint)pickup;
											nint num9 = (nint)typeof(PickupWeapon);
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v173 @ rdx_v6 (Il2CppClass<VampireSurvivors.Objects.Items.PickupWeapon>)+130]");
											object obj16 = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v172 @ r8_v6 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+130]");
											nint num10 = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v173 @ rdx_v6 (Il2CppClass<VampireSurvivors.Objects.Items.PickupWeapon>)+130]");
											if (num10 >= 0)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v172 @ r8_v6 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+C8]");
												object obj17 = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v265 @ rax_v27+FFFFFFF8+v174 @ rax_v23*8]");
												if (0 == (nint)typeof(PickupWeapon))
												{
													obj18 = 1;
													goto IL_018e;
												}
											}
											obj18 = 0;
											goto IL_018e;
										}
										goto IL_01b5;
										IL_01b5:
										if ((object)pickup2 != null && ((UnityEngine.Object)pickup2).m_CachedPtr != (IntPtr)0)
										{
											_ = 1;
											GM.Core.RegisterStagePickup(pickup2);
										}
										GameManager core4 = GM.Core;
										core4._gizmoManager.ShowHighlightAt(CS_0024_003C_003E8__locals7.x, CS_0024_003C_003E8__locals7.y);
										return;
										IL_018e:
										bool flag14 = obj18 == null;
										pickup2 = null;
										if (!flag14)
										{
											pickup2 = pickup;
										}
										goto IL_01b5;
									};
									float duration = num7 * 0.001f;
									Timer timer = Timers.Register(duration, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
									flag3 = (byte)((flag3 ? 1u : 0u) + 1u) != 0;
									obj8 = obj13;
									flag2 = false;
									continue;
								}
								throw new IndexOutOfRangeException();
							}
							bool flag11 = obj9 == null;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v145 @ stack_-108_v26+1C]");
							bool flag12 = obj2 != null;
							GameManager core3 = GM.Core;
							if ((object)GM.Core != null && core3._levelUpFactory != null)
							{
								core3._levelUpFactory.CalculateWeights(character);
								return;
							}
						}
						goto IL_04bd;
					}
					System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_EnumFailedVersion();
					playerOptions = null;
				}
				throw new NullReferenceException();
			}
		}
		goto IL_04bd;
		IL_04bd:
		throw new NullReferenceException();
	}

	private void SpawnWorldSpaceWeapon(float x, float y, WeaponType weaponPrize, float delay)
	{
		_003C_003Ec__DisplayClass35_0 CS_0024_003C_003E8__locals6 = new _003C_003Ec__DisplayClass35_0();
		CS_0024_003C_003E8__locals6.x = x;
		CS_0024_003C_003E8__locals6.y = y;
		CS_0024_003C_003E8__locals6.weaponPrize = weaponPrize;
		Action onComplete = delegate
		{
			//IL_0061: Expected I, but got O
			//IL_006f: Expected I, but got O
			//IL_007f: Expected O, but got I
			//IL_00ff: Expected O, but got I4
			//IL_00bb: Expected O, but got I
			//IL_00f1: Expected O, but got I4
			Vector2 pos = default(Vector2);
			float value = default(float);
			ItemType relicType = default(ItemType);
			bool shouldCallValidatePickups = default(bool);
			bool isRemote = default(bool);
			Pickup pickup = GM.Core.MakePickup(pos, ItemType.WEAPON, CS_0024_003C_003E8__locals6.weaponPrize, value, relicType, shouldCallValidatePickups, isRemote, onlineSynchronization: false);
			bool flag = (object)pickup == null;
			Pickup pickup2 = null;
			object obj4;
			if (!flag)
			{
				nint num = (nint)pickup;
				nint num2 = (nint)typeof(PickupWeapon);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v173 @ rdx_v6 (Il2CppClass<VampireSurvivors.Objects.Items.PickupWeapon>)+130]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v172 @ r8_v6 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+130]");
				nint num3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v173 @ rdx_v6 (Il2CppClass<VampireSurvivors.Objects.Items.PickupWeapon>)+130]");
				if (num3 >= 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v172 @ r8_v6 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+C8]");
					object obj3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v265 @ rax_v27+FFFFFFF8+v174 @ rax_v23*8]");
					if (0 == (nint)typeof(PickupWeapon))
					{
						obj4 = 1;
						goto IL_018e;
					}
				}
				obj4 = 0;
				goto IL_018e;
			}
			goto IL_01b5;
			IL_01b5:
			if ((object)pickup2 != null && ((UnityEngine.Object)pickup2).m_CachedPtr != (IntPtr)0)
			{
				_ = 1;
				GM.Core.RegisterStagePickup(pickup2);
			}
			GameManager core = GM.Core;
			core._gizmoManager.ShowHighlightAt(CS_0024_003C_003E8__locals6.x, CS_0024_003C_003E8__locals6.y);
			return;
			IL_018e:
			bool flag2 = obj4 == null;
			pickup2 = null;
			if (!flag2)
			{
				pickup2 = pickup;
			}
			goto IL_01b5;
		};
		object obj = default(object);
		float duration = (float)obj * 0.001f;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer timer = Timers.Register(duration, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
	}

	public Treasure()
	{
		List<WeaponType> list = new List<WeaponType>();
		accumulatedWorldSpacePrizes = list;
	}
}
