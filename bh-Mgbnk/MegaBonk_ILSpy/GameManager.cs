using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Actors.Enemies;
using Assets.Scripts._Data.MapsAndStages;
using Assets.Scripts.Actors.Enemies;
using Assets.Scripts.Actors.Player;
using Assets.Scripts.Game.Spawning;
using Assets.Scripts.Inventory__Items__Pickups;
using Assets.Scripts.Inventory__Items__Pickups.Stats;
using Assets.Scripts.Managers;
using Assets.Scripts.Menu.Shop;
using Assets.Scripts.Saves___Serialization.Progression.Challenges;
using Assets.Scripts.Utility;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class GameManager : MonoBehaviour
{
	private sealed class _003CDoDeathAnimation_003Ed__41 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		private float _003CanimationTime_003E5__2;

		private float _003Ctime_003E5__3;

		private Transform _003CplayerTransform_003E5__4;

		private Vector3 _003CrotationPoint_003E5__5;

		private Vector3 _003CrotationAxis_003E5__6;

		private Quaternion _003CinitialRotation_003E5__7;

		private Vector3 _003CradiusVector_003E5__8;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		public _003CDoDeathAnimation_003Ed__41(int _003C_003E1__state)
		{
			((IDisposable)this).Dispose();
			this._003C_003E1__state = _003C_003E1__state;
		}

		void IDisposable.Dispose()
		{
		}

		private unsafe bool MoveNext()
		{
			//IL_0008: Expected O, but got Ref
			//IL_0723: Expected I4, but got I8
			//IL_0794: Expected I4, but got O
			//IL_001d: Expected O, but got I4
			//IL_006e: Expected I4, but got I8
			//IL_005a: Expected I4, but got I8
			//IL_08a1: Invalid comparison between I4 and F4
			//IL_0379: Expected F4, but got I4
			//IL_08d3: Expected O, but got Ref
			//IL_0906: Expected O, but got Ref
			//IL_0914: Expected O, but got Ref
			//IL_096e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0973: Expected O, but got Unknown
			//IL_0988: Unknown result type (might be due to invalid IL or missing references)
			//IL_098d: Expected O, but got Unknown
			//IL_0391: Expected O, but got Ref
			//IL_03b8: Expected O, but got Ref
			//IL_0670: Expected O, but got Ref
			//IL_080a: Expected I, but got O
			//IL_023f: Expected O, but got F4
			//IL_02b4: Expected O, but got F4
			object obj2 = default(object);
			object obj = (object)(&obj2);
			bool flag = _003C_003E1__state == 0;
			if (!flag)
			{
				object obj3 = _003C_003E1__state - 1;
				if (!flag)
				{
					if ((nint)obj3 != 1)
					{
						goto IL_0706;
					}
					_003C_003E1__state = -1;
					goto IL_07b3;
				}
				_003C_003E1__state = -1;
				MyPlayer instance = MyPlayer.Instance;
				if ((object)MyPlayer.Instance != null && (object)instance.playerRenderer != null)
				{
					instance.playerRenderer.ResetMaterial();
					MyTime.Pause();
					if ((object)PlayerCamera.Instance != null)
					{
						PlayerCamera.Instance.DeathCamera();
						UiManager instance2 = UiManager.Instance;
						if ((object)UiManager.Instance != null && (object)instance2.deathScreen != null)
						{
							instance2.deathScreen.PlayAudio();
							_003CanimationTime_003E5__2 = 2f;
							if ((object)MyPlayer.Instance != null)
							{
								Transform transform = MyPlayer.Instance.transform;
								_003CplayerTransform_003E5__4 = transform;
								MyPlayer instance3 = MyPlayer.Instance;
								if ((object)MyPlayer.Instance != null && (object)instance3.playerMovement != null)
								{
									Vector3 rbFeetPosition = instance3.playerMovement.GetRbFeetPosition();
									nint num = (nint)typeof(Vector3);
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v770 @ rax_v41 (Il2CppClass<UnityEngine.Vector3>)+B8]");
									nint num2 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v771 @ rcx_v40 (Il2CppStaticFields<UnityEngine.Vector3>)+20]");
									float num3 = 0f * 0.2f;
									float num4 = num3 + rbFeetPosition.z;
									Vector3 vector = default(Vector3);
									_003CrotationPoint_003E5__5 = vector;
									MyPlayer instance4 = MyPlayer.Instance;
									if ((object)MyPlayer.Instance != null && (object)instance4.playerRenderer != null)
									{
										Transform transform2 = instance4.playerRenderer.transform;
										if ((object)transform2 != null)
										{
											Vector3 forward = transform2.forward;
											_003CrotationAxis_003E5__6 = (Vector3)forward.x;
											_ = forward.z;
											if ((object)_003CplayerTransform_003E5__4 != null)
											{
												Vector3 position = _003CplayerTransform_003E5__4.position;
												if ((object)_003CplayerTransform_003E5__4 != null)
												{
													_003CinitialRotation_003E5__7 = (Quaternion)_003CplayerTransform_003E5__4.rotation.x;
													float num5 = position.z;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (GameManager+<DoDeathAnimation>d__41)+38]");
													float num6 = num5 - 0f;
													_003CradiusVector_003E5__8 = vector;
													goto IL_07b3;
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
				_003C_003E1__state = -1;
				GameManager instance5 = Instance;
				if ((object)Instance != null)
				{
					instance5.cutscene = true;
					WaitForSeconds waitForSeconds = new WaitForSeconds(0.1f);
					_003C_003E2__current = waitForSeconds;
					_003C_003E1__state = 1;
					goto IL_09b1;
				}
			}
			goto IL_0786;
			IL_0706:
			return false;
			IL_09b1:
			return true;
			IL_07b3:
			if (1f > _003Ctime_003E5__3)
			{
				float deltaTime = Time.deltaTime;
				float num7 = deltaTime / _003CanimationTime_003E5__2;
				float num8 = num7 + _003Ctime_003E5__3;
				if (!(1f > num8))
				{
					num8 = 1f;
				}
				_003Ctime_003E5__3 = num8;
				float num9 = Easing.InPower(num8, 5);
				float num10;
				if (!(0f > num9))
				{
					bool flag2 = !(num9 > 1f);
					num10 = num9;
					if (!flag2)
					{
						num10 = 1f;
					}
				}
				else
				{
					num10 = 0f;
				}
				float angle = num10 * 90f;
				Vector3 axis = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 73));
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (GameManager+<DoDeathAnimation>d__41)+44]");
				_ = 0;
				_ = _003CrotationAxis_003E5__6;
				Quaternion quaternion = Quaternion.AngleAxis(angle, axis);
				Vector3 vector2 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 73));
				Quaternion quaternion2 = (Quaternion)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
				_ = _003CradiusVector_003E5__8;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (GameManager+<DoDeathAnimation>d__41)+60]");
				_ = 0;
				_ = quaternion.x;
				Vector3 vector3 = quaternion2 * vector2;
				float num11 = vector3.x + (float)_003CrotationPoint_003E5__5;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (GameManager+<DoDeathAnimation>d__41)+34]");
				object obj4 = 0 + vector3.y;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (GameManager+<DoDeathAnimation>d__41)+38]");
				object obj5 = 0 + vector3.z;
				if ((object)_003CplayerTransform_003E5__4 != null)
				{
					Vector3 position2 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 73));
					_003CplayerTransform_003E5__4.position = position2;
					Vector3 axis2 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 73));
					_ = _003CrotationAxis_003E5__6;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (GameManager+<DoDeathAnimation>d__41)+44]");
					_ = 0;
					Quaternion quaternion3 = Quaternion.AngleAxis(angle, axis2);
					float num12 = quaternion3.w * (float)_003CinitialRotation_003E5__7;
					float num13 = quaternion3.z;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (GameManager+<DoDeathAnimation>d__41)+4C]");
					float num14 = num13 * 0f;
					float num15 = quaternion3.x;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (GameManager+<DoDeathAnimation>d__41)+54]");
					float num16 = num15 * 0f;
					float num17 = quaternion3.y;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (GameManager+<DoDeathAnimation>d__41)+54]");
					float num18 = num17 * 0f;
					float num19 = num16 + num12;
					float num20 = quaternion3.z;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (GameManager+<DoDeathAnimation>d__41)+54]");
					float num21 = num20 * 0f;
					float num22 = quaternion3.y;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (GameManager+<DoDeathAnimation>d__41)+50]");
					float num23 = num22 * 0f;
					float num24 = num19 + num14;
					float num25 = quaternion3.x;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (GameManager+<DoDeathAnimation>d__41)+50]");
					float num26 = num25 * 0f;
					float num27 = num24 - num23;
					float num28 = quaternion3.w;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (GameManager+<DoDeathAnimation>d__41)+4C]");
					float num29 = num28 * 0f;
					float num30 = num18 + num29;
					float num31 = quaternion3.z * (float)_003CinitialRotation_003E5__7;
					float num32 = quaternion3.z;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (GameManager+<DoDeathAnimation>d__41)+50]");
					float num33 = num32 * 0f;
					float num34 = num30 + num26;
					float num35 = quaternion3.y * (float)_003CinitialRotation_003E5__7;
					float num36 = quaternion3.y;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (GameManager+<DoDeathAnimation>d__41)+4C]");
					float num37 = num36 * 0f;
					float num38 = num34 - num31;
					float num39 = quaternion3.w;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (GameManager+<DoDeathAnimation>d__41)+50]");
					float num40 = num39 * 0f;
					float num41 = quaternion3.w;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (GameManager+<DoDeathAnimation>d__41)+54]");
					float num42 = num41 * 0f;
					float num43 = num21 + num40;
					float num44 = quaternion3.x * (float)_003CinitialRotation_003E5__7;
					float num45 = quaternion3.x;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (GameManager+<DoDeathAnimation>d__41)+4C]");
					float num46 = num45 * 0f;
					float num47 = num42 - num44;
					float num48 = num43 + num35;
					float num49 = num47 - num37;
					float num50 = num48 - num46;
					float num51 = num49 - num33;
					if ((object)_003CplayerTransform_003E5__4 != null)
					{
						Quaternion rotation = (Quaternion)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 57));
						_003CplayerTransform_003E5__4.rotation = rotation;
						_003C_003E2__current = null;
						_003C_003E1__state = 2;
						goto IL_09b1;
					}
				}
			}
			else
			{
				UiManager instance6 = UiManager.Instance;
				if ((object)UiManager.Instance != null && (object)instance6.deathScreen != null)
				{
					instance6.deathScreen.StartDeathScreen();
					goto IL_0706;
				}
			}
			goto IL_0786;
			IL_0786:
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

	public LayerMask whatIsGround;

	public LayerMask whatIsProjectileRaycast;

	public LayerMask whatIsEnemy;

	public LayerMask whatIsObjects;

	public LayerMask whatIsPlayer;

	public LayerMask whatIsGroundAndObjects;

	public LayerMask whatIsCameraCollision;

	public LayerMask whatIsBlockingRails;

	public LayerMask whatIsProjectileObstruction;

	private float gameTimer;

	public static GameManager Instance;

	public static Action A_StageStarted;

	public static Action A_RunStarted;

	public static Action A_GameOver;

	public MyPlayer player;

	public PlayerCamera playerCamera;

	public UiManager uiManager;

	public int bossCurses;

	private bool inited;

	private bool hasSetMapDifficulty;

	private float nextGetStageTime;

	private float getMaxStageTimeInterval;

	private float lastFoundStageTime;

	private bool _003CisGameOver_003Ek__BackingField;

	private bool _003CisCrypt_003Ek__BackingField;

	private bool _003CisDungeonTimerStarted_003Ek__BackingField;

	private float _003CdungeonTimeToComplete_003Ek__BackingField;

	private bool _003CisDungeonOvertime_003Ek__BackingField;

	public static Action A_DungeonStarted;

	public static Action A_DungeonEnded;

	private int _003CcryptIndex_003Ek__BackingField;

	private bool isPlaying;

	public bool cutscene;

	public bool isGameOver
	{
		get
		{
			return _003CisGameOver_003Ek__BackingField;
		}
		private set
		{
			_003CisGameOver_003Ek__BackingField = value;
		}
	}

	public bool isCrypt
	{
		get
		{
			return _003CisCrypt_003Ek__BackingField;
		}
		private set
		{
			_003CisCrypt_003Ek__BackingField = value;
		}
	}

	public bool isDungeonTimerStarted
	{
		get
		{
			return _003CisDungeonTimerStarted_003Ek__BackingField;
		}
		private set
		{
			_003CisDungeonTimerStarted_003Ek__BackingField = value;
		}
	}

	public float dungeonTimeToComplete
	{
		get
		{
			return _003CdungeonTimeToComplete_003Ek__BackingField;
		}
		private set
		{
			_003CdungeonTimeToComplete_003Ek__BackingField = value;
		}
	}

	public bool isDungeonOvertime
	{
		get
		{
			return _003CisDungeonOvertime_003Ek__BackingField;
		}
		private set
		{
			_003CisDungeonOvertime_003Ek__BackingField = value;
		}
	}

	public int cryptIndex
	{
		get
		{
			return _003CcryptIndex_003Ek__BackingField;
		}
		private set
		{
			_003CcryptIndex_003Ek__BackingField = value;
		}
	}

	private void Awake()
	{
		TryInit();
	}

	private void TryInit()
	{
		//IL_04b8: Expected O, but got I4
		//IL_04ce: Expected I, but got O
		//IL_04f4: Expected O, but got I4
		//IL_050a: Expected I, but got O
		//IL_0558: Expected O, but got I4
		//IL_056e: Expected I, but got O
		//IL_0594: Expected O, but got I4
		//IL_05aa: Expected I, but got O
		//IL_01fd: Expected I, but got O
		//IL_05f4: Expected O, but got I4
		//IL_01d1: Expected I, but got O
		//IL_0248: Expected I, but got O
		//IL_0256: Expected I, but got O
		//IL_02d7: Expected I, but got O
		//IL_0427: Expected O, but got I
		if (inited)
		{
			return;
		}
		inited = true;
		nint num5;
		nint num6;
		Delegate obj10;
		if (Instance == null)
		{
			Instance = this;
			Action b = OnDied;
			Delegate obj = Delegate.Combine(PlayerHealth.A_Died, b);
			Delegate obj4;
			object obj3;
			if ((object)obj == null)
			{
				PlayerHealth.A_Died = null;
			}
			else
			{
				bool flag = (object)obj.GetType() != typeof(Action);
				Delegate obj2 = null;
				if (!flag)
				{
					obj2 = obj;
				}
				bool flag2 = (object)obj2 == null;
				obj3 = 0;
				obj4 = obj;
				nint num = (nint)typeof(Action);
				if (flag2)
				{
					goto IL_06a1;
				}
				PlayerHealth.A_Died = (Action)obj2;
				bool flag3 = (object)obj.GetType() != typeof(Action);
				Delegate obj5 = null;
				if (!flag3)
				{
					obj5 = obj;
				}
				bool flag4 = (object)obj5 == null;
				obj3 = 0;
				obj4 = obj;
				nint num2 = (nint)typeof(Action);
				if (flag4)
				{
					goto IL_06ac;
				}
			}
			Action b2 = OnStageBossDied;
			Delegate obj6 = Delegate.Combine(EnemyManager.A_StageBossDied, b2);
			if ((object)obj6 == null)
			{
				EnemyManager.A_StageBossDied = null;
			}
			else
			{
				bool flag5 = (object)obj6.GetType() != typeof(Action);
				Delegate obj7 = null;
				if (!flag5)
				{
					obj7 = obj6;
				}
				bool flag6 = (object)obj7 == null;
				obj3 = 0;
				obj4 = obj6;
				nint num3 = (nint)typeof(Action);
				if (flag6)
				{
					goto IL_06bc;
				}
				EnemyManager.A_StageBossDied = (Action)obj7;
				bool flag7 = (object)obj6.GetType() != typeof(Action);
				Delegate obj8 = null;
				if (!flag7)
				{
					obj8 = obj6;
				}
				bool flag8 = (object)obj8 == null;
				obj3 = 0;
				obj4 = obj6;
				nint num4 = (nint)typeof(Action);
				if (flag8)
				{
					goto IL_06cc;
				}
			}
			Action<PlayerInventory> b3 = OnPlayerInit;
			Delegate obj9 = Delegate.Combine(MyPlayer.A_PlayerInventoryInitialized, b3);
			if ((object)obj9 == null)
			{
				MyPlayer.A_PlayerInventoryInitialized = (Action<PlayerInventory>)obj9;
				num5 = (nint)MyPlayer.A_PlayerInventoryInitialized;
				goto IL_0276;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<PlayerInventory> action = default(Action<PlayerInventory>);
			bool flag9 = action == null;
			num6 = (nint)typeof(Action<PlayerInventory>);
			obj4 = null;
			obj10 = obj9;
			if (!flag9)
			{
				MyPlayer.A_PlayerInventoryInitialized = action;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
				object obj11 = default(object);
				bool flag10 = obj11 == null;
				num5 = (nint)typeof(Action<PlayerInventory>);
				num6 = (nint)typeof(Action<PlayerInventory>);
				obj4 = null;
				obj10 = obj9;
				if (!flag10)
				{
					goto IL_0276;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
			obj3 = 0;
			goto IL_06cc;
		}
		GameObject obj12 = base.gameObject;
		UnityEngine.Object.Destroy(obj12);
		return;
		IL_06ac:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_06a1;
		IL_06bc:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_06ac;
		IL_06a1:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		return;
		IL_0276:
		if (!(MyPlayer.Instance != null))
		{
			return;
		}
		MyPlayer instance = MyPlayer.Instance;
		bool flag11 = (object)MyPlayer.Instance == null;
		num6 = num5;
		obj10 = (Delegate)(object)MyPlayer.Instance;
		if (!flag11)
		{
			if (!instance.hasStarted)
			{
				return;
			}
			MyPlayer instance2 = MyPlayer.Instance;
			bool flag12 = (object)MyPlayer.Instance == null;
			num6 = num5;
			obj10 = (Delegate)(object)MyPlayer.Instance;
			if (!flag12)
			{
				num6 = (nint)instance2.inventory;
				if (hasSetMapDifficulty)
				{
					return;
				}
				hasSetMapDifficulty = true;
				MapData mapData = MapController._003CcurrentMap_003Ek__BackingField;
				bool flag13 = (object)MapController._003CcurrentMap_003Ek__BackingField == null;
				obj10 = (Delegate)(object)MyPlayer.Instance;
				if (!flag13)
				{
					if (mapData.eMap != EMap.Graveyard)
					{
						return;
					}
					bool flag14 = instance2.inventory == null;
					obj10 = (Delegate)(object)MyPlayer.Instance;
					if (!flag14)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v525 @ rdi_v10 (Il2CppClass<System.Action`1<PlayerInventory>>)+50]");
						num6 = 0;
						StatModifier statModifier = new StatModifier();
						bool flag15 = statModifier == null;
						obj10 = (Delegate)(object)statModifier;
						if (!flag15)
						{
							((Delegate)(object)statModifier).invoke_impl = (IntPtr)1069547520;
							_ = 1;
							((Delegate)(object)statModifier).method_ptr = (IntPtr)55;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v525 @ rdi_v10 (Il2CppClass<System.Action`1<PlayerInventory>>)+50]");
							bool flag16 = (nint)0 == 0;
							obj10 = (Delegate)(object)statModifier;
							if (!flag16)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v525 @ rdi_v10 (Il2CppClass<System.Action`1<PlayerInventory>>)+50]");
								bool addToShrineLog = default(bool);
								((StatInventory)0).ChangeStat(statModifier, permanent: true, 0f, addToShrineLog);
								return;
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
		IL_06cc:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_06bc;
	}

	private void OnPlayerInit(PlayerInventory inventory)
	{
		if (!hasSetMapDifficulty)
		{
			hasSetMapDifficulty = true;
			MapData mapData = MapController._003CcurrentMap_003Ek__BackingField;
			if (mapData.eMap == EMap.Graveyard)
			{
				StatModifier statModifier = new StatModifier();
				statModifier.modification = 1.5f;
				statModifier.modifyType = EStatModifyType.Multiplication;
				statModifier.stat = EStat.EnemyScalingMultiplier;
				bool addToShrineLog = default(bool);
				inventory.statInventory.ChangeStat(statModifier, permanent: true, 0f, addToShrineLog);
			}
		}
	}

	public void CreateInstances()
	{
		TryInit();
		player.TryInit();
		playerCamera.TryInit();
		uiManager.TryInit();
	}

	public float GetStageTimeMax()
	{
		//IL_00a7: Expected O, but got I4
		//IL_00b8: Expected O, but got I4
		//IL_0328: Unknown result type (might be due to invalid IL or missing references)
		//IL_032d: Expected O, but got Unknown
		//IL_0132: Expected I, but got O
		//IL_013a: Expected I, but got O
		//IL_014a: Expected O, but got I
		//IL_0186: Expected O, but got I
		//IL_01c3: Expected F4, but got I
		//IL_01d3: Invalid comparison between I and F4
		//IL_01f7: Expected F4, but got I
		if (nextGetStageTime > MyTime.time)
		{
			return lastFoundStageTime;
		}
		float num = MyTime.time + getMaxStageTimeInterval;
		nextGetStageTime = num;
		EnemyManager instance = EnemyManager.Instance;
		if ((object)EnemyManager.Instance == null || instance.summonerController == null)
		{
			StageData stageData = MapController._003CcurrentStage_003Ek__BackingField;
			if ((object)MapController._003CcurrentStage_003Ek__BackingField != null && stageData.stageTimeline != null)
			{
				return stageData.stageTimeline.GetStageTime();
			}
		}
		else
		{
			EnemyManager instance2 = EnemyManager.Instance;
			if ((object)EnemyManager.Instance != null && instance2.summonerController != null)
			{
				num = instance2.summonerController.GetStageTimeMax();
				bool flag = ChallengesTracker.HasChallengeModifier("speedrun");
				bool flag2 = !flag;
				float num2 = num;
				if (!flag2)
				{
					ChallengeModifier[] challengeModifiers = ChallengesTracker.challengeModifiers;
					if (ChallengesTracker.challengeModifiers == null)
					{
						goto IL_02e1;
					}
					object obj = 0;
					num2 = num;
					for (object obj2 = 0; (nint)obj2 < challengeModifiers.Length; obj++, obj2 = obj)
					{
						ChallengeModifier challengeModifier = challengeModifiers[obj];
						if ((object)challengeModifiers[obj] != null)
						{
							if (!(challengeModifier.internalName == "speedrun"))
							{
								continue;
							}
							nint num3 = (nint)typeof(ChallengeModifierSpeedrun);
							nint num4 = (nint)challengeModifier;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v496 @ rdx_v12 (Il2CppClass<ChallengeModifierSpeedrun>)+130]");
							object obj3 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v495 @ r8_v8 (Il2CppClass<ChallengeModifier>)+130]");
							nint num5 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v496 @ rdx_v12 (Il2CppClass<ChallengeModifierSpeedrun>)+130]");
							if (num5 >= 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v495 @ r8_v8 (Il2CppClass<ChallengeModifier>)+C8]");
								object obj4 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v541 @ rax_v38+FFFFFFF8+v525 @ rax_v35*8]");
								if (0 == (nint)typeof(ChallengeModifierSpeedrun))
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v297 @ rdi_v7 (ChallengeModifier)+30]");
									num = 0f;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v297 @ rdi_v7 (ChallengeModifier)+30]");
									if (!(0f > num2))
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v297 @ rdi_v7 (ChallengeModifier)+30]");
										num2 = 0f;
									}
									continue;
								}
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
							throw new IndexOutOfRangeException();
						}
						goto IL_02e1;
					}
				}
				lastFoundStageTime = num2;
				return num2;
			}
		}
		goto IL_02e1;
		IL_02e1:
		throw new NullReferenceException();
	}

	private void Start()
	{
		FinalFightController.isFightingFinalBoss = false;
		Action a_StageStarted = A_StageStarted;
		if (A_StageStarted != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v30.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
		}
		if (MapController.IsFirstStage())
		{
			Action a_RunStarted = A_RunStarted;
			if (A_RunStarted != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v77.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
			}
		}
	}

	private void OnDestroy()
	{
		//IL_024e: Expected O, but got I4
		//IL_02cc: Expected O, but got I4
		//IL_02e2: Expected I, but got O
		//IL_0330: Expected O, but got I4
		//IL_0346: Expected I, but got O
		//IL_036c: Expected O, but got I4
		//IL_0382: Expected I, but got O
		//IL_01ca: Expected O, but got I4
		//IL_021e: Expected O, but got I4
		ResumeEnemyGroundCollision();
		Delegate a_Died = PlayerHealth.A_Died;
		Action action = OnDied;
		Delegate obj = Delegate.Remove(PlayerHealth.A_Died, action);
		Action action2;
		object obj3;
		Delegate obj4;
		if ((object)obj == null)
		{
			PlayerHealth.A_Died = null;
		}
		else
		{
			bool flag = (object)obj.GetType() != typeof(Action);
			Delegate obj2 = null;
			if (!flag)
			{
				obj2 = obj;
			}
			if ((object)obj2 == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
				action2 = action;
				obj3 = 0;
				obj4 = obj;
				goto IL_03c8;
			}
			PlayerHealth.A_Died = (Action)obj2;
			bool flag2 = (object)obj.GetType() != typeof(Action);
			Delegate obj5 = null;
			if (!flag2)
			{
				obj5 = obj;
			}
			bool flag3 = (object)obj5 == null;
			obj3 = 0;
			obj4 = obj;
			nint num = (nint)typeof(Action);
			if (flag3)
			{
				goto IL_03d8;
			}
		}
		Action value = OnStageBossDied;
		Delegate obj6 = Delegate.Remove(EnemyManager.A_StageBossDied, value);
		if ((object)obj6 == null)
		{
			EnemyManager.A_StageBossDied = null;
		}
		else
		{
			bool flag4 = (object)obj6.GetType() != typeof(Action);
			Delegate obj7 = null;
			if (!flag4)
			{
				obj7 = obj6;
			}
			bool flag5 = (object)obj7 == null;
			obj3 = 0;
			obj4 = obj6;
			nint num2 = (nint)typeof(Action);
			if (flag5)
			{
				goto IL_03e3;
			}
			EnemyManager.A_StageBossDied = (Action)obj7;
			bool flag6 = (object)obj6.GetType() != typeof(Action);
			Delegate obj8 = null;
			if (!flag6)
			{
				obj8 = obj6;
			}
			bool flag7 = (object)obj8 == null;
			obj3 = 0;
			obj4 = obj6;
			nint num3 = (nint)typeof(Action);
			if (flag7)
			{
				goto IL_03f3;
			}
		}
		Action<PlayerInventory> value2 = OnPlayerInit;
		Delegate obj9 = Delegate.Remove(MyPlayer.A_PlayerInventoryInitialized, value2);
		if ((object)obj9 == null)
		{
			MyPlayer.A_PlayerInventoryInitialized = null;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<PlayerInventory> action3 = default(Action<PlayerInventory>);
		bool flag8 = action3 == null;
		a_Died = (Delegate)(object)typeof(Action<PlayerInventory>);
		action2 = (Action)obj9;
		obj3 = 0;
		obj4 = null;
		if (flag8)
		{
			goto IL_03b8;
		}
		MyPlayer.A_PlayerInventoryInitialized = action3;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		object obj10 = default(object);
		bool flag9 = obj10 == null;
		a_Died = (Delegate)(object)typeof(Action<PlayerInventory>);
		action2 = (Action)obj9;
		obj3 = 0;
		obj4 = null;
		if (!flag9)
		{
			return;
		}
		goto IL_03c8;
		IL_03c8:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_03b8;
		IL_03b8:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_03f3;
		IL_03f3:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_03e3;
		IL_03d8:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		return;
		IL_03e3:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_03d8;
	}

	private unsafe void Update()
	{
		//IL_00d2: Expected O, but got Ref
		//IL_00fc: Expected F4, but got I4
		//IL_00fc: Expected O, but got I4
		if (!isPlaying)
		{
			return;
		}
		MyPlayer myPlayer = GetPlayer();
		if (myPlayer != null)
		{
			bool flag = !_003CisCrypt_003Ek__BackingField;
			float num = gameTimer + MyTime.deltaTime;
			gameTimer = num;
			if (!flag && !_003CisDungeonOvertime_003Ek__BackingField && MyTime.cryptTimer > _003CdungeonTimeToComplete_003Ek__BackingField && !_003CisDungeonOvertime_003Ek__BackingField)
			{
				UiManager uiManager = this.uiManager;
				_003CisDungeonOvertime_003Ek__BackingField = true;
				uiManager.alertUi.SetAlertTimesUp();
				Transform transform = MyPlayer.Instance.transform;
				Vector3 position = transform.position;
				object obj = default(object);
				int num2 = default(int);
				bool flag2 = default(bool);
				float fromHeight = default(float);
				Vector3 enemySpawnPositionAroundPoint = SpawnPositions.GetEnemySpawnPositionAroundPoint((Vector3)(&obj), 5f, 10f, num2, flag2, fromHeight);
				Enemy enemy = EnemyManager.Instance.SpawnBoss(EEnemy.GhostInvincible, 0, EEnemyFlag.Boss, (Vector3)num2, flag2 ? 1 : 0);
			}
		}
	}

	public PlayerMovement GetPlayerMovement()
	{
		if (!(PlayerMovement.Instance == null))
		{
			return PlayerMovement.Instance;
		}
		return null;
	}

	public MyPlayer GetPlayer()
	{
		if (!(MyPlayer.Instance != null))
		{
			return null;
		}
		return MyPlayer.Instance;
	}

	public float GetAliveTime()
	{
		return gameTimer;
	}

	public PlayerInventory GetPlayerInventory()
	{
		MyPlayer myPlayer = GetPlayer();
		if (myPlayer != null)
		{
			MyPlayer myPlayer2 = GetPlayer();
			if ((object)myPlayer2 != null)
			{
				return myPlayer2.inventory;
			}
			return (PlayerInventory)(object)new NullReferenceException();
		}
		return null;
	}

	private void OnDied()
	{
		_003CisGameOver_003Ek__BackingField = true;
		Action a_GameOver = A_GameOver;
		if (A_GameOver != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v31.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
		}
		_003CDoDeathAnimation_003Ed__41 obj = new _003CDoDeathAnimation_003Ed__41(0);
		obj._003C_003E1__state = 0;
		Coroutine coroutine = StartCoroutine(obj);
	}

	public void OnTeleportAway()
	{
		_003CisGameOver_003Ek__BackingField = true;
		Action a_GameOver = A_GameOver;
		if (A_GameOver != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v29.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
		}
	}

	private IEnumerator DoDeathAnimation()
	{
		_003CDoDeathAnimation_003Ed__41 obj = new _003CDoDeathAnimation_003Ed__41(0);
		obj._003C_003E1__state = 0;
		return obj;
	}

	public bool IsFinalSwarm()
	{
		//IL_004e: Expected I4, but got O
		if (!(EnemyManager.Instance != null))
		{
			return false;
		}
		if ((object)EnemyManager.Instance != null)
		{
			return EnemyManager.Instance.IsFinalSwarm();
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	public void StartDungeon(float timeToComplete)
	{
		//IL_0075: Expected F4, but got I4
		int num = _003CcryptIndex_003Ek__BackingField + 1;
		_003CcryptIndex_003Ek__BackingField = num;
		_003CdungeonTimeToComplete_003Ek__BackingField = timeToComplete;
		_003CisCrypt_003Ek__BackingField = true;
		_003CisDungeonOvertime_003Ek__BackingField = false;
		MyTime.cryptTimer = 0f;
		if (ChallengesTracker.HasChallengeModifier("crypt"))
		{
			ChallengeData currentChallenge = ChallengesTracker.GetCurrentChallenge();
			if (currentChallenge != null)
			{
				_003CdungeonTimeToComplete_003Ek__BackingField = currentChallenge.targetValue;
			}
		}
		int layer = LayerMask.NameToLayer("Enemy");
		int layer2 = LayerMask.NameToLayer("Ground");
		Physics.IgnoreLayerCollision(layer, layer2, ignore: true);
		int layer3 = LayerMask.NameToLayer("Enemy");
		int layer4 = LayerMask.NameToLayer("Object");
		Physics.IgnoreLayerCollision(layer3, layer4, ignore: true);
		Action a_DungeonStarted = A_DungeonStarted;
		if (A_DungeonStarted != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v208.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
		}
	}

	public void StopDungeon()
	{
		//IL_0032: Expected I, but got O
		//IL_006f: Expected I, but got O
		//IL_008b: Expected I, but got O
		_003CisCrypt_003Ek__BackingField = false;
		_003CisDungeonOvertime_003Ek__BackingField = false;
		UnityEngine.Object instance = EnemyManager.Instance;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180D598D0");
		nint num = 0;
		Dictionary<uint, Enemy>.Enumerator enumerator = default(Dictionary<uint, Enemy>.Enumerator);
		UnityEngine.Object obj = default(UnityEngine.Object);
		while (true)
		{
			if (enumerator.MoveNext())
			{
				bool flag = obj != null;
				num = unchecked((nint)null);
				if (flag)
				{
					if ((object)obj == null)
					{
						break;
					}
					bool flag2 = ((Enemy)obj).IsDead();
					num = unchecked((nint)null);
					if (!flag2)
					{
						((Enemy)obj).ReleaseToPoolNextFrame();
						num = unchecked((nint)null);
					}
				}
				continue;
			}
			enumerator.Dispose();
			ResumeEnemyGroundCollision();
			Action a_DungeonEnded = A_DungeonEnded;
			if (A_DungeonEnded != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v288.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
			}
			return;
		}
		throw new NullReferenceException();
	}

	public void StartDungeonTimer()
	{
		if (!_003CisDungeonTimerStarted_003Ek__BackingField)
		{
			_003CisDungeonTimerStarted_003Ek__BackingField = true;
		}
	}

	private void ResumeEnemyGroundCollision()
	{
		int layer = LayerMask.NameToLayer("Enemy");
		int layer2 = LayerMask.NameToLayer("Ground");
		Physics.IgnoreLayerCollision(layer, layer2, ignore: false);
		int layer3 = LayerMask.NameToLayer("Enemy");
		int layer4 = LayerMask.NameToLayer("Object");
		Physics.IgnoreLayerCollision(layer3, layer4, ignore: false);
	}

	private unsafe void StartDungeonOvertime()
	{
		//IL_0076: Expected O, but got Ref
		//IL_00a0: Expected F4, but got I4
		//IL_00a0: Expected O, but got I4
		if (!_003CisDungeonOvertime_003Ek__BackingField)
		{
			UiManager uiManager = this.uiManager;
			_003CisDungeonOvertime_003Ek__BackingField = true;
			uiManager.alertUi.SetAlertTimesUp();
			Transform transform = MyPlayer.Instance.transform;
			Vector3 position = transform.position;
			object obj = default(object);
			int num = default(int);
			bool flag = default(bool);
			float fromHeight = default(float);
			Vector3 enemySpawnPositionAroundPoint = SpawnPositions.GetEnemySpawnPositionAroundPoint((Vector3)(&obj), 5f, 10f, num, flag, fromHeight);
			Enemy enemy = EnemyManager.Instance.SpawnBoss(EEnemy.GhostInvincible, 0, EEnemyFlag.Boss, (Vector3)num, flag ? 1 : 0);
		}
	}

	public static float GetViewDistance()
	{
		return 50f;
	}

	public static float GetViewDistanceSqr()
	{
		return 2500f;
	}

	public static float GetEnemyTeleportDistance()
	{
		return 75f;
	}

	public static float GetEnemyTeleportDistanceSqr()
	{
		return 5625f;
	}

	public bool IsTimeFreeze()
	{
		//IL_00ad: Expected I4, but got O
		MyPlayer instance = MyPlayer.Instance;
		if ((object)MyPlayer.Instance == null || instance.inventory == null)
		{
			return false;
		}
		MyPlayer instance2 = MyPlayer.Instance;
		if ((object)MyPlayer.Instance != null)
		{
			PlayerInventory inventory = instance2.inventory;
			if (instance2.inventory != null && inventory.statusEffects != null)
			{
				return inventory.statusEffects.HasStatusEffect(EStatusEffect.TimeFreeze);
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	public bool IsPlaying()
	{
		return isPlaying;
	}

	public bool IsFinalBossDead()
	{
		//IL_004e: Expected I4, but got O
		if (!MapController.isFinalBossStage)
		{
			return false;
		}
		EnemyManager instance = EnemyManager.Instance;
		if ((object)EnemyManager.Instance != null)
		{
			return instance._003CstageBossIsDead_003Ek__BackingField;
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	public void StartPlaying()
	{
		isPlaying = true;
	}

	public bool HasEnteredBossRoom()
	{
		//IL_008e: Expected I4, but got O
		RsgController instance = RsgController.Instance;
		UnityEngine.Object obj = (((object)RsgController.Instance == null) ? null : instance.roomBoss);
		bool flag = obj != null;
		if (!flag)
		{
			return flag;
		}
		RsgController instance2 = RsgController.Instance;
		if ((object)RsgController.Instance != null)
		{
			GraveyardBossRoom roomBoss = instance2.roomBoss;
			if ((object)instance2.roomBoss != null)
			{
				return roomBoss._003ChasSpawnedBoss_003Ek__BackingField;
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	private void OnStageBossDied()
	{
		if (!MapController.isFinalBossStage)
		{
			return;
		}
		EnemyManager instance = EnemyManager.Instance;
		Dictionary<uint, Enemy>.ValueCollection values = instance.enemies.Values;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AEBE00");
		Dictionary<uint, Enemy>.ValueCollection.Enumerator enumerator = default(Dictionary<uint, Enemy>.ValueCollection.Enumerator);
		Enemy enemy = default(Enemy);
		while (true)
		{
			if (enumerator.MoveNext())
			{
				if ((object)enemy == null)
				{
					break;
				}
				enemy.EnemyDied(null);
				continue;
			}
			enumerator.Dispose();
			return;
		}
		throw new NullReferenceException();
	}

	public GameManager()
	{
		//IL_001a: Expected I4, but got I8
		getMaxStageTimeInterval = 0.1f;
		_003CcryptIndex_003Ek__BackingField = -1;
		base._002Ector();
	}
}
