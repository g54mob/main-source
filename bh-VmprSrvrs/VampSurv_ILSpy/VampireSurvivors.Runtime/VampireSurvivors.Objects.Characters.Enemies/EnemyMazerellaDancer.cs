using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Coherence.Toolkit;
using Cpp2ILInjected;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Objects.Pickups;

namespace VampireSurvivors.Objects.Characters.Enemies;

public class EnemyMazerellaDancer : EnemyController
{
	public enum DancerSide
	{
		Left,
		Right
	}

	private enum DancerState
	{
		Uninitialized,
		MovingToRelic,
		MovingToPath,
		MovingAlongPath,
		MovingToDanceFloor,
		DancingOnDanceFloor,
		SpawningPickupsOnDeath,
		Dead
	}

	private MazerellaDancerMagnet _magnet;

	private float _maxMovementSpeed;

	private float _movementSmoothing = 0.1f;

	private float _distanceFromPlayer;

	private float _regularLerpAmount;

	private float _moveToRelicDuration;

	private AnimationCurve _moveToRelicCurve;

	private float _moveToScreenEdgeDuration;

	private AnimationCurve _moveToScreenEdgeCurve;

	private float _moveToDanceFloorDuration;

	private AnimationCurve _moveToDanceFloorCurve;

	private Vector3 _danceFloorTargetPositionOffset;

	private CoherenceSync _sync;

	private readonly MazerellaDancerAnimation _mazerellaDancerAnimation;

	private MazerellaDancerMazeNavigation _mazeNavigation;

	private DancerState _currentState;

	private DancerSide _dancerSide;

	private Vector3 _movementStartPosition;

	private Vector3 _movementTargetPosition;

	private float _movementTimer;

	private Bounds _danceFloorBounds;

	private float _mazePathPosition;

	private CharacterController _targetPlayer;

	private float MaxMoveSpeed
	{
		get
		{
			CharacterController targetPlayer = _targetPlayer;
			float result;
			if ((object)_targetPlayer != null)
			{
				bool flag = ((UnityEngine.Object)targetPlayer).m_CachedPtr == (IntPtr)0;
				result = _maxMovementSpeed;
				if (!flag)
				{
					float num = _targetPlayer.PMoveSpeed();
					object obj = default(object);
					float num2 = (float)obj * _maxMovementSpeed;
					if (_maxMovementSpeed < num2)
					{
						result = num2;
					}
					return result;
				}
			}
			else
			{
				result = _maxMovementSpeed;
			}
			return result;
		}
	}

	public void SetMovementTargetPosition(Vector3 targetPosition)
	{
		//IL_000f: Expected O, but got F4
		_movementTargetPosition = (Vector3)targetPosition.x;
		_ = targetPosition.z;
	}

	public void SetDanceFloorBounds(Bounds bounds)
	{
		_danceFloorBounds = (Bounds)bounds.m_Center;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [bounds @ rdx (UnityEngine.Bounds)+10]");
		_ = 0;
	}

	public void InitAnimsCommand(bool isLeft)
	{
		DancerSide dancerSide = (_dancerSide = (DancerSide)((isLeft ? 1 : 0) ^ 1));
		_mazerellaDancerAnimation.InitAnims(_EnemyRenderer, _SpriteAnimation, dancerSide);
	}

	public void InitDancer(DancerSide dancerSide, MazerellaDancerMazeNavigation mazeNavigation, MazerellaDancerMazeNavigation.NavigationNode playerStartNavigationNode)
	{
		//IL_007b: Expected I4, but got O
		base._003CIsCullable_003Ek__BackingField = false;
		_dancerSide = dancerSide;
		Action<bool> action = null;
		((EnemyMazerellaDancer)(object)action).InitAnimsCommand((byte)(int)this != 0);
		bool flag = dancerSide == DancerSide.Left;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182F5C410");
		_mazeNavigation = mazeNavigation;
		RetargetIfNecessary();
		CharacterController component = base._targetTransform.GetComponent<CharacterController>();
		_targetPlayer = component;
	}

	public override void InitEnemy(EnemyType enemyType, bool asRemote = false)
	{
		//IL_0040: Expected O, but got F4
		base.InitEnemy(enemyType, asRemote);
		CoherenceSync component = GetComponent<CoherenceSync>();
		_sync = component;
		if (_currentState != DancerState.MovingToRelic)
		{
			_movementTimer = 0f;
			Transform transform = base.transform;
			Vector3 vector = transform.position;
			_movementStartPosition = (Vector3)vector.x;
			_ = vector.z;
			_currentState = DancerState.MovingToRelic;
		}
	}

	private void SetCurrentState(DancerState newState)
	{
		//IL_002f: Expected O, but got I8
		//IL_0049: Expected O, but got I8
		if (newState != _currentState)
		{
			if (newState <= DancerState.Dead)
			{
				object obj = 6442450944L;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ r14_v1+77338B8+newState @ rdx (VampireSurvivors.Objects.Characters.Enemies.EnemyMazerellaDancer+DancerState)*4]");
				object obj2 = 0 + 6442450944L;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v67 @ rax_v12 (should have been resolved before IL gen)");
			}
			DancerState dancerState = default(DancerState);
			object actualValue = dancerState;
			ArgumentOutOfRangeException ex = new ArgumentOutOfRangeException("newState", actualValue, null);
			throw ex;
		}
	}

	protected override void OnUpdate()
	{
		//IL_003c: Expected O, but got I4
		GameManager core = GM.Core;
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 55 Invalid \"Jump target not found in method: 0x187733EDD\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 67 Invalid \"Jump target not found in method: 0x187733EDD\"");
		if (core._multiplayer.IsOnlineMultiplayer)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 94 Invalid \"Jump target not found in method: 0x187733EDD\"");
			bool isStageHost = GM.Core.IsStageHost;
			Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 107 Invalid \"Jump target not found in method: 0x187733E9C\"");
		}
		if (_currentState != DancerState.Uninitialized)
		{
			object obj = _currentState + -6;
			if ((nint)obj > 1)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 146 Invalid \"Jump target not found in method: 0x187733EDD\"");
				_magnet.UpdatePickUpLocations();
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 163 Invalid \"Jump target not found in method: 0x187733F22\"");
	}

	public void InitMagnet()
	{
		//IL_0160: Unknown result type (might be due to invalid IL or missing references)
		//IL_0165: Expected O, but got Unknown
		if ((object)_magnet != null)
		{
			_magnet.InitMagnet(_cachedTransform);
			MazerellaDancerMagnet magnet = _magnet;
			Action b = delegate
			{
				//IL_0102: Expected O, but got I
				if (_currentState != DancerState.Dead)
				{
					MazerellaDancerMagnet magnet2 = _magnet;
					List<Pickup> collectedPickups = magnet2._collectedPickups;
					int version = collectedPickups._version + 1;
					collectedPickups._version = version;
					collectedPickups._size = 0;
					if (collectedPickups._size > 0)
					{
						Array.Clear(collectedPickups._items, 0, collectedPickups._size);
					}
					List<MazerellaDancerMagnet.VacuumedPickup> vacuumedPickups = magnet2._vacuumedPickups;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v117 @ rcx_v7 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Characters.MazerellaDancerMagnet+VacuumedPickup>)+1C]");
					_ = (nint)0 + (nint)1;
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v117 @ rcx_v7 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Characters.MazerellaDancerMagnet+VacuumedPickup>)+18]");
					if ((nint)0 > (nint)0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v117 @ rcx_v7 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Characters.MazerellaDancerMagnet+VacuumedPickup>)+10]");
						nint num = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v117 @ rcx_v7 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Characters.MazerellaDancerMagnet+VacuumedPickup>)+18]");
						Array.Clear((Array)num, 0, 0);
					}
					magnet2.OnAllPickupsSpawned = null;
					base.Die();
					_currentState = DancerState.Dead;
				}
			};
			if ((object)_magnet != null)
			{
				Delegate obj = magnet.OnAllPickupsSpawned;
				object obj2 = _magnet + 136;
				while (true)
				{
					Delegate obj3 = Delegate.Combine(obj, b);
					bool flag = (object)obj3 == null;
					Delegate obj4 = null;
					if (!flag)
					{
						bool flag2 = (object)obj3.GetType() != typeof(Action);
						obj4 = null;
						if (!flag2)
						{
							obj4 = obj3;
						}
						if ((object)obj4 == null)
						{
							break;
						}
					}
					bool flag3 = obj == obj2;
					Delegate obj5;
					if (obj == obj2)
					{
						obj2 = obj4;
						obj5 = obj;
					}
					else
					{
						obj5 = (Delegate)obj2;
					}
					Delegate obj6 = obj;
					if (!flag3)
					{
						obj6 = obj5;
					}
					bool flag4 = (object)obj6 != obj;
					obj = obj6;
					if (!flag4)
					{
						return;
					}
				}
				goto IL_01d0;
			}
		}
		NullReferenceException ex = new NullReferenceException();
		goto IL_01d0;
		IL_01d0:
		throw new InvalidCastException();
	}

	public void InitMazePathPosition(float mazePathPosition)
	{
		_mazePathPosition = mazePathPosition;
	}

	private unsafe Vector3 TargetPositionOnPathOffsetFromPlayer()
	{
		//IL_0245: Unknown result type (might be due to invalid IL or missing references)
		//IL_024a: Expected O, but got Unknown
		//IL_0252: Invalid comparison between F4 and O
		//IL_012c: Invalid comparison between F4 and I4
		//IL_0186: Expected native int or pointer, but got O
		//IL_0198: Expected native int or pointer, but got O
		//IL_00a0: Expected I, but got O
		//IL_00b0: Expected O, but got I
		MazerellaDancerMazeNavigation mazeNavigation = default(MazerellaDancerMazeNavigation);
		if (_dancerSide != DancerSide.Left)
		{
			mazeNavigation = _mazeNavigation;
			if ((object)_mazeNavigation == null)
			{
				goto IL_01a2;
			}
		}
		float num = mazeNavigation._003CCurrentTotalNormalizedPosition_003Ek__BackingField;
		CharacterController targetPlayer = _targetPlayer;
		float num2;
		if ((object)_targetPlayer != null)
		{
			bool flag = ((UnityEngine.Object)targetPlayer).m_CachedPtr == (IntPtr)0;
			num2 = _maxMovementSpeed;
			EnemyMazerellaDancer enemyMazerellaDancer = this;
			if (!flag)
			{
				CharacterController targetPlayer2 = _targetPlayer;
				if ((object)_targetPlayer == null)
				{
					goto IL_01a2;
				}
				nint num3 = (nint)targetPlayer2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v320 @ rdx_v4 (Il2CppClass<VampireSurvivors.Objects.Characters.CharacterController>)+570]");
				enemyMazerellaDancer = (EnemyMazerellaDancer)0;
				float num4 = _targetPlayer.PMoveSpeed();
				object obj = default(object);
				float num5 = (float)obj * _maxMovementSpeed;
				if (_maxMovementSpeed < num5)
				{
					num2 = num5;
				}
			}
		}
		else
		{
			num2 = _maxMovementSpeed;
			EnemyMazerellaDancer enemyMazerellaDancer = this;
		}
		float deltaTime = PauseSystem.DeltaTime;
		float num6 = deltaTime * num2;
		float num7 = num - _mazePathPosition;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
		object obj2 = num7 & 0;
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num6) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2))
		{
			float num8 = num - _mazePathPosition;
			float num9 = ((num8 < 0f) ? (-1f) : 1f);
			float num10 = num9 * num6;
			num = num10 + _mazePathPosition;
		}
		_mazePathPosition = num;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181B93760");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6FB44");
		if ((object)_mazeNavigation != null)
		{
			int lineSegmentIndex = default(int);
			float offsetDistanceInWorldSpace = default(float);
			Vector3 positionOnLineSegmentWithOffset = _mazeNavigation.GetPositionOnLineSegmentWithOffset(lineSegmentIndex, _mazePathPosition, offsetDistanceInWorldSpace);
			Vector3 vector = default(Vector3);
			((Vector3*)(nint)vector)->x = positionOnLineSegmentWithOffset.x;
			((Vector3*)(nint)vector)->z = positionOnLineSegmentWithOffset.z;
			return vector;
		}
		goto IL_01a2;
		IL_01a2:
		return (Vector3)new NullReferenceException();
	}

	private unsafe void LerpToPosition(Vector3 startPosition, Vector3 targetPosition, float duration, AnimationCurve movementCurve, Action onMovementComplete = null)
	{
		//IL_0145: Expected F4, but got O
		//IL_0149: Expected O, but got F4
		//IL_0188: Expected O, but got F4
		//IL_0196: Invalid comparison between I4 and F4
		//IL_01fb->IL0132: Incompatible stack heights: 4 vs 2
		float deltaTime = PauseSystem.DeltaTime;
		if (!(duration > (_movementTimer = deltaTime + _movementTimer)))
		{
			Transform transform = base.transform;
			bool flag = (object)transform == null;
			bool flag2 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
			float value = default(float);
			Transform.set_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref *(Vector3*)(&value));
			object obj = default(object);
			if (obj != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v473 @ stack_30+18] (should have been resolved before IL gen)");
			}
			return;
		}
		Transform transform2 = default(Transform);
		bool flag3 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
		object obj2 = AnimationCurve.Evaluate_Injected(((UnityEngine.Object)transform2).m_CachedPtr, (float)startPosition);
		Transform transform3 = base.transform;
		bool flag4 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
		object obj3 = AnimationCurve.Evaluate_Injected(((UnityEngine.Object)transform2).m_CachedPtr, 0f);
		if (0f > startPosition.x || startPosition.x > 1f)
		{
		}
		bool flag5 = (object)transform3 == null;
		bool flag6 = ((UnityEngine.Object)transform3).m_CachedPtr == (IntPtr)0;
		Vector3 value2 = default(Vector3);
		Transform.set_position_Injected(((UnityEngine.Object)transform3).m_CachedPtr, ref value2);
	}

	public override void GetDamaged(float value, HitVfxType showHitVfx = HitVfxType.Default, float damageKb = 1f, WeaponType damageType = WeaponType.VOID, bool hasKb = true)
	{
		if (_currentState == DancerState.DancingOnDanceFloor)
		{
			base.GetDamaged(value, showHitVfx, damageKb, damageType, hasKb);
		}
	}

	public override void GetDamagedSpecial(float value, HitVfxType showHitVfx = HitVfxType.Default, float damageKb = 1f, WeaponType damageType = WeaponType.VOID, bool hasKb = true, Vector3? damagePosition = null)
	{
		if (_currentState == DancerState.DancingOnDanceFloor)
		{
			WeaponType damageType2 = default(WeaponType);
			bool hasKb2 = default(bool);
			Vector3? damagePosition2 = default(Vector3?);
			base.GetDamagedSpecial(value, showHitVfx, damageKb, damageType2, hasKb2, damagePosition2);
		}
	}

	protected override void Die()
	{
		GameManager core = GM.Core;
		if (core._multiplayer.IsOnlineMultiplayer && !GM.Core.IsStageHost)
		{
			base.Die();
		}
		if (_currentState == DancerState.SpawningPickupsOnDeath)
		{
			return;
		}
		if ((bool)_magnet)
		{
			MazerellaDancerMagnet magnet = _magnet;
			magnet._isEnabled = false;
			GameManager core2 = GM.Core;
			if (!core2._multiplayer.IsOnlineMultiplayer || _sync.HasStateAuthority)
			{
				_magnet.SetupPickupsToSpawnOnDeath();
			}
		}
		_currentState = DancerState.SpawningPickupsOnDeath;
	}

	public EnemyMazerellaDancer()
	{
		MazerellaDancerAnimation mazerellaDancerAnimation = new MazerellaDancerAnimation();
		List<MazerellaDancerAnimation.DanceAnimationStage> danceAnimationStages = new List<MazerellaDancerAnimation.DanceAnimationStage>();
		mazerellaDancerAnimation._danceAnimationStages = danceAnimationStages;
		_mazerellaDancerAnimation = mazerellaDancerAnimation;
		_currentState = DancerState.MovingAlongPath;
		base._002Ector();
	}

	private void _003COnUpdate_003Eb__33_0()
	{
		//IL_003b: Expected O, but got F4
		if (_currentState != DancerState.MovingToPath)
		{
			_movementTimer = 0f;
			Transform transform = base.transform;
			Vector3 vector = transform.position;
			_movementStartPosition = (Vector3)vector.x;
			_ = vector.z;
			_currentState = DancerState.MovingToPath;
		}
	}

	private void _003COnUpdate_003Eb__33_1()
	{
		if (_currentState != DancerState.MovingAlongPath)
		{
			_currentState = DancerState.MovingAlongPath;
		}
	}

	private void _003COnUpdate_003Eb__33_2()
	{
		if (_currentState != DancerState.DancingOnDanceFloor)
		{
			_currentState = DancerState.DancingOnDanceFloor;
		}
	}

	private void _003CInitMagnet_003Eb__34_0()
	{
		//IL_0102: Expected O, but got I
		if (_currentState != DancerState.Dead)
		{
			MazerellaDancerMagnet magnet = _magnet;
			List<Pickup> collectedPickups = magnet._collectedPickups;
			int version = collectedPickups._version + 1;
			collectedPickups._version = version;
			collectedPickups._size = 0;
			if (collectedPickups._size > 0)
			{
				Array.Clear(collectedPickups._items, 0, collectedPickups._size);
			}
			List<MazerellaDancerMagnet.VacuumedPickup> vacuumedPickups = magnet._vacuumedPickups;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v117 @ rcx_v7 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Characters.MazerellaDancerMagnet+VacuumedPickup>)+1C]");
			_ = (nint)0 + (nint)1;
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v117 @ rcx_v7 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Characters.MazerellaDancerMagnet+VacuumedPickup>)+18]");
			if ((nint)0 > (nint)0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v117 @ rcx_v7 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Characters.MazerellaDancerMagnet+VacuumedPickup>)+10]");
				nint num = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v117 @ rcx_v7 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Characters.MazerellaDancerMagnet+VacuumedPickup>)+18]");
				Array.Clear((Array)num, 0, 0);
			}
			magnet.OnAllPickupsSpawned = null;
			base.Die();
			_currentState = DancerState.Dead;
		}
	}
}
