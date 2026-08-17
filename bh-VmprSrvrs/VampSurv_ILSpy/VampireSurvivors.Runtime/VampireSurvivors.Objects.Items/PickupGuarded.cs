using System;
using System.Collections;
using System.Collections.Generic;
using Coherence.Toolkit;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Bindings;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pickups;
using VampireSurvivors.Tools;

namespace VampireSurvivors.Objects.Items;

public class PickupGuarded : NetworkPickup
{
	private sealed class _003CDeferredReturnToPool_003Ed__41(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public PickupGuarded _003C_003E4__this;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_003b: Expected I4, but got I8
			//IL_00d5: Expected I4, but got I8
			//IL_015d: Expected I4, but got O
			PickupGuarded pickupGuarded = _003C_003E4__this;
			if (_003C_003E1__state == 0)
			{
				_003C_003E1__state = -1;
				if ((object)_003C_003E4__this != null && (object)pickupGuarded._itemRenderer != null)
				{
					pickupGuarded._itemRenderer.enabled = false;
					_003C_003E4__this.RemovePhysics();
					goto IL_00f4;
				}
			}
			else
			{
				if (_003C_003E1__state != 1)
				{
					goto IL_0149;
				}
				_003C_003E1__state = -1;
				if ((object)_003C_003E4__this != null)
				{
					goto IL_00f4;
				}
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
			IL_00f4:
			if (_003C_003E4__this.AnyGuardsAlive())
			{
				_003C_003E2__current = null;
				_003C_003E1__state = 1;
				return true;
			}
			((NetworkPickup)_003C_003E4__this).Despawn();
			goto IL_0149;
			IL_0149:
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

	protected Transform _cachedTransform;

	protected Stage _stage;

	protected Camera _camera;

	protected float _left;

	protected float _right;

	protected float _top;

	protected float _bottom;

	protected bool _hasSpawned;

	protected float _guardRadius;

	protected EnemyType _enemyType;

	protected int _spawnQuantity;

	protected bool _hasAssignedSpawnData;

	protected int _eventID;

	protected bool _vfxEnabled;

	private float _totalTime;

	private const float ParticlesInterval = 0.040000003f;

	private const float Radius = 1.4399999f;

	private bool _003CIsAnyGuardAlive_003Ek__BackingField;

	private readonly List<EnemyController> Guards;

	private float _003CSpawnAngle_003Ek__BackingField;

	private bool _003CSkipOnlineGuardsCheckOnDespawn_003Ek__BackingField;

	public bool IsAnyGuardAlive
	{
		get
		{
			return _003CIsAnyGuardAlive_003Ek__BackingField;
		}
		set
		{
			_003CIsAnyGuardAlive_003Ek__BackingField = value;
		}
	}

	public float SpawnAngle
	{
		get
		{
			return _003CSpawnAngle_003Ek__BackingField;
		}
		set
		{
			_003CSpawnAngle_003Ek__BackingField = value;
		}
	}

	public bool HasSpawned
	{
		get
		{
			return _hasSpawned;
		}
		set
		{
			_hasSpawned = value;
		}
	}

	public bool SkipOnlineGuardsCheckOnDespawn
	{
		get
		{
			return _003CSkipOnlineGuardsCheckOnDespawn_003Ek__BackingField;
		}
		set
		{
			_003CSkipOnlineGuardsCheckOnDespawn_003Ek__BackingField = value;
		}
	}

	private void Construct(Stage stage)
	{
		_stage = stage;
	}

	protected override void Awake()
	{
		base.Awake();
		Camera main = Camera.main;
		_camera = main;
		Transform cachedTransform = base.transform;
		_cachedTransform = cachedTransform;
	}

	protected unsafe virtual void OnDrawGizmosSelected()
	{
		//IL_0045: Expected O, but got I
		//IL_0154: Expected F4, but got Ref
		//IL_015d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0162: Expected O, but got Unknown
		//IL_0173->IL01a0: Incompatible stack heights: 5 vs 1
		Transform transform = base.transform;
		bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
		Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 ret);
		Vector3 center = default(Vector3);
		Vector3 vector = default(Vector3);
		Gizmos.DrawWireCube_Injected(ref center, ref vector);
		List<Vector2> points = MathTools.GetPoints(_spawnQuantity, _003CSpawnAngle_003Ek__BackingField, 1.4399999f);
		Transform transform2 = null;
		Transform transform3 = null;
		Vector3 center2 = default(Vector3);
		while (true)
		{
			Transform obj = transform3;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v174 @ rax_v36 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
			if ((nint)obj >= 0)
			{
				break;
			}
			bool flag2 = ((UnityEngine.Object)this).m_CachedPtr == (IntPtr)0;
			IntPtr gcHandlePtr = Component.get_transform_Injected(((UnityEngine.Object)this).m_CachedPtr);
			Transform transform4 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr);
			bool flag3 = ((UnityEngine.Object)transform4).m_CachedPtr == (IntPtr)0;
			Transform.get_position_Injected(((UnityEngine.Object)transform4).m_CachedPtr, out ret);
			Transform obj2 = transform2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v174 @ rax_v36 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
			bool flag4 = (nint)obj2 >= 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v174 @ rax_v36 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+10]");
			object obj3 = 0;
			Transform obj4 = transform2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v181 @ rcx_v40+18]");
			bool flag5 = (nint)obj4 >= 0;
			Gizmos.DrawWireSphere_Injected(ref center2, (float)(nint)(&ret));
			transform2 = (Transform)(transform2 + 1);
			transform3 = transform2;
		}
	}

	public override void SetData(ItemType itemType)
	{
		base.SetData(itemType);
		((Pickup)this)._003CResRosary_003Ek__BackingField = 1f;
		OnRecycle();
	}

	public override void InternalUpdate()
	{
		base.InternalUpdate();
		if (!_hasSpawned && IsAnyPlayerInGuardSpawnRange())
		{
			TriggerSpawn();
		}
	}

	public void SetEnemySpawnType(EnemyType enemyType, int spawnQuantity)
	{
		int num = spawnQuantity ^ spawnQuantity;
		int num2 = spawnQuantity & num;
		bool flag = num2 < 0;
		bool flag2 = spawnQuantity < 0;
		bool flag3 = spawnQuantity == 0;
		_enemyType = enemyType;
		_spawnQuantity = spawnQuantity;
		bool flag4 = flag2 == flag;
		bool flag5 = !flag3;
		bool flag6 = flag5 & flag4;
		_hasAssignedSpawnData = true;
		_003CIsAnyGuardAlive_003Ek__BackingField = flag6;
	}

	public override void Despawn()
	{
		GameManager core = GM.Core;
		if (core._multiplayer.IsOnlineMultiplayer && _003CIsAnyGuardAlive_003Ek__BackingField && !_003CSkipOnlineGuardsCheckOnDespawn_003Ek__BackingField)
		{
			_003CDeferredReturnToPool_003Ed__41 obj = null;
			obj._003C_003E1__state = 0;
			obj._003C_003E4__this = this;
			Coroutine coroutine = StartCoroutine(obj);
		}
		else
		{
			base.Despawn();
		}
	}

	protected void SetParticleEffectsActive(bool particleEffectsActive)
	{
		_vfxEnabled = particleEffectsActive;
	}

	private IEnumerator DeferredReturnToPool()
	{
		_003CDeferredReturnToPool_003Ed__41 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		return obj;
	}

	private bool IsAnyPlayerInGuardSpawnRange()
	{
		List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator = default(List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator);
		if (enumerator.MoveNext())
		{
			Component component = null;
			Component component2 = null;
			throw new NullReferenceException();
		}
		return false;
	}

	protected virtual void OnRecycle()
	{
		List<EnemyController> guards = Guards;
		_hasSpawned = false;
		if (Guards != null)
		{
			int version = guards._version + 1;
			guards._version = version;
			guards._size = 0;
			if (guards._size > 0)
			{
				Array.Clear(guards._items, 0, guards._size);
			}
			Bounds bounds = CameraExtensions.OrthographicBounds(_camera);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v79 @ rax_v11 (UnityEngine.Bounds)+10]");
			float num = 0f * 2f;
			float guardRadius = num * 0.5f;
			Transform cachedTransform = _cachedTransform;
			_guardRadius = guardRadius;
			if ((object)_cachedTransform != null)
			{
				bool flag = ((UnityEngine.Object)cachedTransform).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)cachedTransform).m_CachedPtr, out Vector3 ret);
				float left = (float)ret - _guardRadius;
				float right = (float)ret + _guardRadius;
				_hasAssignedSpawnData = false;
				_left = left;
				object obj = default(object);
				float top = (float)obj + _guardRadius;
				float bottom = (float)obj - _guardRadius;
				_right = right;
				_top = top;
				_bottom = bottom;
				return;
			}
		}
		throw new NullReferenceException();
	}

	public void ChangeActiveRadius(float pixelRadius = 32f)
	{
		Transform cachedTransform = _cachedTransform;
		float num = pixelRadius * 0.01f;
		bool flag = ((UnityEngine.Object)cachedTransform).m_CachedPtr == (IntPtr)0;
		Transform.get_position_Injected(((UnityEngine.Object)cachedTransform).m_CachedPtr, out Vector3 ret);
		float left = (float)ret - num;
		float right = (float)ret + num;
		_left = left;
		object obj = default(object);
		float top = (float)obj + num;
		_right = right;
		float bottom = (float)obj - num;
		_top = top;
		_bottom = bottom;
	}

	protected virtual void TriggerSpawn()
	{
		//IL_01a0: Expected I, but got O
		//IL_01eb->IL01eb: Incompatible stack heights: 1 vs 0
		//IL_0267->IL026c: Incompatible stack heights: 3 vs 1
		//IL_016d->IL026c: Incompatible stack heights: 3 vs 1
		//IL_01e6->IL026c: Incompatible stack heights: 4 vs 1
		if (!_hasAssignedSpawnData || !_coherenceSync.HasStateAuthority)
		{
			return;
		}
		_hasSpawned = true;
		if (_spawnQuantity <= 0)
		{
			return;
		}
		List<Vector2> points = MathTools.GetPoints(_spawnQuantity, _003CSpawnAngle_003Ek__BackingField, 1.4399999f);
		Transform cachedTransform = _cachedTransform;
		bool flag = ((UnityEngine.Object)cachedTransform).m_CachedPtr == (IntPtr)0;
		Transform.get_position_Injected(((UnityEngine.Object)cachedTransform).m_CachedPtr, out Vector3 _);
		Stage stage = _stage;
		int randomId = stage._stageEventManager.GetRandomId();
		_eventID = randomId;
		List<Vector2>.Enumerator enumerator = default(List<Vector2>.Enumerator);
		object obj2 = default(object);
		object obj3 = default(object);
		Vector2 spawnPos = default(Vector2);
		bool forceSpawn = default(bool);
		while (enumerator.MoveNext())
		{
			object obj = obj2 - obj3;
			bool flag2 = (object)_stage == null;
			GameObject gameObject = _stage.SpawnEnemy(_enemyType, spawnPos, asRemote: false, forceSpawn);
			bool flag3 = (object)gameObject == null;
			EnemyController component = gameObject.GetComponent<EnemyController>();
			if ((object)component != null && ((UnityEngine.Object)component).m_CachedPtr != (IntPtr)0)
			{
				component._003CIsBoss_003Ek__BackingField = true;
				component._003CIsCullable_003Ek__BackingField = false;
				GameObject owner = base.gameObject;
				nint num = (nint)component;
				component.SetOwner(owner);
				component._003CStageEventId_003Ek__BackingField = _eventID;
				bool flag4 = Guards == null;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1804FE520");
			}
		}
	}

	protected void CheckSpawnParticles()
	{
		//IL_012f->IL00dd: Incompatible stack heights: 1 vs 0
		//IL_00dd->IL00e4: Incompatible stack heights: 1 vs 0
		if (!_vfxEnabled)
		{
			return;
		}
		float deltaTime = PauseSystem.DeltaTime;
		if (!((_totalTime = deltaTime + _totalTime) > 0.040000003f))
		{
			return;
		}
		_totalTime = 0f;
		CheckRenderer();
		if ((object)((ArcadeSprite)this)._spriteRenderer != null)
		{
			Transform transform = ((ArcadeSprite)this)._spriteRenderer.transform;
			if ((object)transform != null)
			{
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
				if ((object)_gameManager != null)
				{
					Vector2 pos = default(Vector2);
					_gameManager.SpawnPickupEffectsParticles(pos);
					return;
				}
			}
		}
		throw new NullReferenceException();
	}

	protected bool AnyGuardsAlive()
	{
		//IL_0100: Expected O, but got I4
		//IL_00a6: Expected O, but got I
		//IL_01cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d2: Expected O, but got Unknown
		//IL_01dd: Expected O, but got I4
		//IL_0192: Expected O, but got I4
		if (_003CIsAnyGuardAlive_003Ek__BackingField && !_hasSpawned)
		{
			return true;
		}
		CoherenceSync coherenceSync = _coherenceSync;
		NetworkEntityState networkEntityState = coherenceSync._003CEntityState_003Ek__BackingField;
		if (coherenceSync._003CEntityState_003Ek__BackingField != null)
		{
			ObservableAuthorityType observableAuthorityType = networkEntityState._003CAuthorityType_003Ek__BackingField;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v101 @ rax_v18 (Coherence.Toolkit.ObservableAuthorityType)+10]");
			bool flag;
			if ((nint)0 == 1)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v101 @ rax_v18 (Coherence.Toolkit.ObservableAuthorityType)+10]");
				flag = false;
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v101 @ rax_v18 (Coherence.Toolkit.ObservableAuthorityType)+10]");
				object obj = -3;
				bool flag2 = obj == null;
				flag = flag2;
			}
			if (!flag)
			{
				goto IL_01eb;
			}
		}
		List<EnemyController> guards = Guards;
		_003CIsAnyGuardAlive_003Ek__BackingField = false;
		bool flag3 = (nint)Guards < 0;
		object obj2 = guards._size - 1;
		if (!flag3)
		{
			List<EnemyController> guards2 = Guards;
			object obj4;
			bool result = default(bool);
			do
			{
				if ((nint)obj2 < guards2._size)
				{
					EnemyController[] items = guards2._items;
					EnemyController enemyController = items[obj2];
					bool flag4 = (enemyController._003CIsDead_003Ek__BackingField ? 1 : 0) < (false ? 1 : 0);
					if (!enemyController._003CIsDead_003Ek__BackingField)
					{
						object obj3 = enemyController._003CStageEventId_003Ek__BackingField - _eventID;
						flag4 = (nint)obj3 < 0;
						if (enemyController._003CStageEventId_003Ek__BackingField == _eventID)
						{
							_003CIsAnyGuardAlive_003Ek__BackingField = true;
							return _003CIsAnyGuardAlive_003Ek__BackingField;
						}
					}
					obj2--;
					obj4 = !flag4;
					continue;
				}
				System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
				return result;
			}
			while (obj4 != null);
		}
		goto IL_01eb;
		IL_01eb:
		return _003CIsAnyGuardAlive_003Ek__BackingField;
	}

	public PickupGuarded()
	{
		//IL_0047: Expected I4, but got I8
		_guardRadius = 1f;
		_enemyType = EnemyType.PATROL_XLARMOR_SWORD;
		_spawnQuantity = 12;
		_eventID = -1;
		_vfxEnabled = true;
		_totalTime = 0.1f;
		List<EnemyController> guards = new List<EnemyController>();
		Guards = guards;
		_003CSpawnAngle_003Ek__BackingField = (float)Math.PI * 2f;
		base._002Ector();
	}

	private void _003C_003En__0()
	{
		base.Despawn();
	}
}
