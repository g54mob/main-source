using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using Unity.Mathematics;
using Unity.Profiling;
using Unity.Profiling.LowLevel;
using Unity.Profiling.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.Tilemaps;

public class World : EventEmitter
{
	public PhaserScene _scene;

	public HashSet<Body> _bodies;

	private bool _iteratingOverBodies;

	private Stack<Body> _spareBodies;

	private HashSet<StaticBody> _staticBodies;

	private HashSet<BaseBody> _pendingAdd;

	private HashSet<BaseBody> _pendingDestroy;

	private ProcessQueue<Collider> _colliders;

	private Vector2 _gravity;

	public ArcadeBodyBounds _bounds;

	public CheckCollisionObject _checkCollision;

	private int _fps;

	private bool _fixedStep;

	private double _elapsed;

	private double _frameTime;

	private double _frameTimeMS;

	private int _stepsLastFrame;

	private double _timeScale;

	public float OVERLAP_BIAS;

	private float TILE_BIAS;

	private bool _forceX;

	private bool _isPaused;

	private int _total;

	public ArcadeWorldDefaults _defaults;

	private int _maxEntries;

	public bool _useTree;

	private List<Group> _groupsWithRTrees;

	private Dictionary<Group, RBush> _groupRTrees;

	public RBush _staticTree;

	private ArcadeWorldConfig _config;

	private static readonly ProfilerMarker _markerEnableBody;

	private static readonly ProfilerMarker MarkerAdd;

	private static readonly ProfilerMarker s_updateMarker;

	private static readonly ProfilerMarker s_preUpdateMarker;

	private static readonly ProfilerMarker s_collidersMarker;

	private static readonly ProfilerMarker s_stepMarker;

	private static readonly ProfilerMarker s_postUpdateMarker;

	private static readonly ProfilerMarker s_drawDebugMarker;

	private static readonly ProfilerMarker s_bodyDestructionMarker;

	private static readonly ProfilerMarker s_separateMarker;

	private static readonly ProfilerMarker s_separateCircleMarker;

	private static readonly ProfilerMarker s_separateCircleSqrRtMarker;

	private static readonly ProfilerMarker s_intersectsMarker;

	private PhaserTile[] _tileCache;

	private static readonly ProfilerMarker s_spriteVsTilemapMarker;

	private static readonly ProfilerMarker s_spriteVsTilemapFastMarker;

	private static readonly ProfilerMarker s_spriteVsTilemapCallbacksMarker;

	private static readonly ProfilerMarker s_separateTileMarker;

	public World(PhaserScene scene, ArcadeWorldConfig config)
	{
		PhaserTile[] tileCache = new PhaserTile[1024];
		_tileCache = tileCache;
		base._002Ector();
		_scene = scene;
		HashSet<Body> bodies = (HashSet<Body>)(object)new HashSet<object>();
		_bodies = bodies;
		Stack<Body> spareBodies = new Stack<Body>();
		_spareBodies = spareBodies;
		HashSet<StaticBody> staticBodies = (HashSet<StaticBody>)(object)new HashSet<object>();
		_staticBodies = staticBodies;
		HashSet<BaseBody> pendingAdd = (HashSet<BaseBody>)(object)new HashSet<object>();
		_pendingAdd = pendingAdd;
		HashSet<BaseBody> pendingDestroy = (HashSet<BaseBody>)(object)new HashSet<object>();
		_pendingDestroy = pendingDestroy;
		ProcessQueue<Collider> colliders = new ProcessQueue<Collider>();
		_colliders = colliders;
		_config = config;
		_gravity = config._gravity;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [config @ r8 (ArcadeWorldConfig)+24]");
		_ = 0;
		_bounds = config._bounds;
		_checkCollision = config._checkCollision;
		_fps = config._fps;
		_fixedStep = config._fixedStep;
		_elapsed = 0.0;
		_stepsLastFrame = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"divsd xmm1,xmm0\"");
		_frameTime = 1.0;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"mulsd xmm1,qword ptr [188A109F8h]\"");
		_frameTimeMS = 1.0;
		_timeScale = config._timeScale;
		OVERLAP_BIAS = (float)config._overlapBias;
		TILE_BIAS = (float)config._tileBias;
		_forceX = config._forceX;
		_isPaused = config._isPaused;
		_total = 0;
		_defaults = new ArcadeWorldDefaults
		{
			_debugShowStaticBody = true,
			_bodyDebugColor = 16711935,
			_staticBodyDebugColor = 255,
			_velocityDebugColor = 65280
		};
		_maxEntries = config._maxEntries;
		_useTree = config._useTree;
		List<Group> groupsWithRTrees = new List<Group>();
		_groupsWithRTrees = groupsWithRTrees;
		Dictionary<Group, RBush> groupRTrees = new Dictionary<Group, RBush>();
		_groupRTrees = groupRTrees;
		RBush staticTree = new RBush(_maxEntries);
		_staticTree = staticTree;
		VSDebug.Init();
	}

	public unsafe void enable(ArcadeColliderType obj, PhysicsType bodyType = PhysicsType.DYNAMIC_BODY)
	{
		//IL_0376: Expected I, but got O
		//IL_000d: Expected I, but got O
		//IL_001d: Expected O, but got I
		//IL_039c: Expected O, but got I4
		//IL_03a6: Expected O, but got I4
		//IL_03af: Expected O, but got I4
		//IL_013d: Expected O, but got I
		//IL_0059: Expected O, but got I
		//IL_0096: Expected O, but got I
		//IL_00d2: Expected O, but got I
		//IL_01a0: Expected O, but got I
		//IL_03d4: Expected I, but got O
		//IL_03dc: Expected I, but got O
		//IL_03ec: Expected O, but got I
		//IL_01da: Expected I, but got O
		//IL_01e2: Expected I4, but got O
		//IL_01f2: Expected O, but got I
		//IL_02f1: Expected O, but got I
		//IL_022e: Expected O, but got I
		//IL_0334: Expected O, but got I
		//IL_033d: Expected I, but got O
		//IL_034b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0350: Expected O, but got Unknown
		//IL_0268: Expected I, but got O
		//IL_027b: Expected O, but got Ref
		nint num = (nint)typeof(PhaserArray);
		ArcadeColliderType arcadeColliderType;
		if (obj != null)
		{
			nint num2 = (nint)obj;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v52 @ rdx_v1 (Il2CppClass<PhaserArray>)+130]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ r8_v17 (Il2CppClass<ArcadeColliderType>)+130]");
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v52 @ rdx_v1 (Il2CppClass<PhaserArray>)+130]");
			if (num3 >= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ r8_v17 (Il2CppClass<ArcadeColliderType>)+C8]");
				object obj3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v82 @ rax_v39+FFFFFFF8+v67 @ rax_v38*8]");
				if (0 == (nint)typeof(PhaserArray))
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v52 @ rdx_v1 (Il2CppClass<PhaserArray>)+130]");
					PhaserArray phaserArray = (PhaserArray)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ r8_v17 (Il2CppClass<ArcadeColliderType>)+130]");
					nint num4 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v52 @ rdx_v1 (Il2CppClass<PhaserArray>)+130]");
					if (num4 >= 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ r8_v17 (Il2CppClass<ArcadeColliderType>)+C8]");
						object obj4 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v137 @ rax_v43+FFFFFFF8+v119 @ rax_v40 (PhaserArray)*8]");
						if (0 == (nint)typeof(PhaserArray))
						{
							arcadeColliderType = obj;
							goto IL_0393;
						}
					}
					throw new InvalidCastException();
				}
			}
		}
		PhaserArray phaserArray2 = new PhaserArray(obj);
		arcadeColliderType = phaserArray2;
		goto IL_0393;
		IL_0393:
		object obj5 = 0;
		HashSet<object>.Enumerator enumerator = (HashSet<object>.Enumerator)0;
		HashSet<object>.Enumerator enumerator2 = (HashSet<object>.Enumerator)0;
		object obj9 = default(object);
		HashSet<object>.Enumerator enumerator4 = default(HashSet<object>.Enumerator);
		while (true)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v181 @ r12_v7 (ArcadeColliderType)+10]");
			object obj6 = 0;
			object obj7 = obj5;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v268 @ rax_v16+18]");
			if ((nint)obj7 >= 0)
			{
				return;
			}
			object obj8 = obj5;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v268 @ rax_v16+18]");
			if ((nint)obj8 < 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v268 @ rax_v16+20+v198 @ rdi_v7*8]");
				PhaserGameObject phaserGameObject = (PhaserGameObject)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
				nint num7;
				if (obj9 != null)
				{
					nint num5 = (nint)typeof(Group);
					PhysicsType physicsType = (PhysicsType)phaserGameObject;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v316 @ rdx_v13 (Il2CppClass<Group>)+130]");
					object obj10 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v322 @ r8_v12 (PhysicsType)+130]");
					nint num6 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v316 @ rdx_v13 (Il2CppClass<Group>)+130]");
					if (num6 >= 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v322 @ r8_v12 (PhysicsType)+C8]");
						object obj11 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v326 @ rax_v24+FFFFFFF8+v571 @ rax_v23*8]");
						if (0 == (nint)typeof(Group))
						{
							num7 = (nint)((MonoBehaviour)phaserGameObject).m_CancellationTokenSource;
							if (enumerator.MoveNext())
							{
								HashSet<object>.Enumerator enumerator3 = (HashSet<object>.Enumerator)(&enumerator);
								throw new NullReferenceException();
							}
							enumerator = enumerator4;
							enumerator2 = enumerator4;
							goto IL_0342;
						}
					}
					throw new InvalidCastException();
				}
				nint num8 = (nint)typeof(PhaserGameObject);
				nint num9 = (nint)phaserGameObject;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v619 @ rdx_v10 (Il2CppClass<PhaserGameObject>)+130]");
				object obj12 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v620 @ r8_v9 (Il2CppClass<PhaserGameObject>)+130]");
				nint num10 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v619 @ rdx_v10 (Il2CppClass<PhaserGameObject>)+130]");
				if (num10 < 0)
				{
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v620 @ r8_v9 (Il2CppClass<PhaserGameObject>)+C8]");
				object obj13 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v635 @ rax_v20+FFFFFFF8+v621 @ rax_v19*8]");
				if (0 != (nint)typeof(PhaserGameObject))
				{
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v268 @ rax_v16+20+v198 @ rdi_v7*8]");
				PhaserGameObject phaserGameObject2 = enableBody((PhaserGameObject)0, bodyType);
				num7 = unchecked((nint)null);
				goto IL_0342;
			}
			throw new IndexOutOfRangeException();
			IL_0342:
			obj5++;
		}
		throw new InvalidCastException();
	}

	public PhaserGameObject enableBody(PhaserGameObject obj, PhysicsType bodyType = PhysicsType.DYNAMIC_BODY)
	{
		//IL_00a7: Expected O, but got I8
		if ((object)obj == null)
		{
			goto IL_01e8;
		}
		if (obj.body == null)
		{
			if (bodyType == PhysicsType.DYNAMIC_BODY)
			{
				Stack<object> spareBodies = (Stack<object>)(object)_spareBodies;
				if (_spareBodies != null)
				{
					if (spareBodies._size <= 0)
					{
						Body body = new Body();
						body.Reset(this, obj, initial: true);
						obj.body = body;
						goto IL_0213;
					}
					if (_spareBodies != null)
					{
						object body2 = ((Stack<object>)(object)_spareBodies).Pop();
						obj.body = (BaseBody)body2;
						if (obj.body != null)
						{
							obj.body.Reset(this, obj);
							goto IL_0213;
						}
					}
				}
				goto IL_01e8;
			}
			if (bodyType == PhysicsType.STATIC_BODY)
			{
				StaticBody staticBody = null;
				Transform transform = obj.transform;
				SpriteRenderer componentInChildren = obj.GetComponentInChildren<SpriteRenderer>();
				ArcadeTransform arcadeTransform = null;
				arcadeTransform.cachedLocalPosition = (float2)3323739136L;
				_ = 1176255488;
				arcadeTransform.Reset(transform, componentInChildren, staticBody);
				staticBody._transform = arcadeTransform;
				obj.body = staticBody;
			}
		}
		goto IL_0213;
		IL_01e8:
		return (PhaserGameObject)(object)new NullReferenceException();
		IL_0213:
		BaseBody baseBody = add(obj.body);
		return obj;
	}

	public BaseBody add(BaseBody body)
	{
		//IL_0164: Expected I, but got O
		//IL_016c: Expected I, but got O
		//IL_017c: Expected O, but got I
		//IL_028d: Expected I, but got O
		//IL_01b4: Expected O, but got I
		//IL_0060: Expected I, but got O
		//IL_0068: Expected I, but got O
		//IL_0078: Expected O, but got I
		//IL_00b0: Expected O, but got I
		//IL_0249->IL0249: Incompatible stack heights: 3 vs 1
		//IL_0218->IL0249: Incompatible stack heights: 3 vs 1
		//IL_0101->IL0249: Incompatible stack heights: 3 vs 1
		//IL_0156->IL0249: Incompatible stack heights: 3 vs 1
		if ((object)MarkerAdd != null)
		{
			ProfilerUnsafeUtility.BeginSample((IntPtr)MarkerAdd);
		}
		bool flag = body == null;
		if (body._physicsType != PhysicsType.DYNAMIC_BODY)
		{
			if (body._physicsType == PhysicsType.STATIC_BODY)
			{
				nint num = (nint)typeof(StaticBody);
				nint num2 = (nint)body;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v222 @ rdx_v10 (Il2CppClass<StaticBody>)+130]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v223 @ r8_v10 (Il2CppClass<BaseBody>)+130]");
				nint num3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v222 @ rdx_v10 (Il2CppClass<StaticBody>)+130]");
				bool flag2 = num3 < 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v223 @ r8_v10 (Il2CppClass<BaseBody>)+C8]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v355 @ rax_v22+FFFFFFF8+v224 @ rax_v21*8]");
				bool flag3 = 0 != (nint)typeof(StaticBody);
				if (((HashSet<object>)(object)_staticBodies).AddIfNotPresent((object)body))
				{
					RBush staticTree = _staticTree;
					RBush.Node data = staticTree.data;
					int level = data.height - 1;
					staticTree._insert((RBush.IRectangular)body, level, false);
				}
			}
		}
		else
		{
			nint num4 = (nint)typeof(Body);
			nint num5 = (nint)body;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v201 @ rdx_v4 (Il2CppClass<Body>)+130]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v202 @ r8_v4 (Il2CppClass<BaseBody>)+130]");
			nint num6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v201 @ rdx_v4 (Il2CppClass<Body>)+130]");
			bool flag4 = num6 < 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v202 @ r8_v4 (Il2CppClass<BaseBody>)+C8]");
			object obj4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v318 @ rax_v15+FFFFFFF8+v203 @ rax_v14*8]");
			bool flag5 = 0 != (nint)typeof(Body);
			if (!_iteratingOverBodies)
			{
				bool flag6 = ((HashSet<object>)(object)_bodies).AddIfNotPresent((object)body);
			}
			else
			{
				bool flag7 = ((HashSet<object>)(object)_pendingAdd).AddIfNotPresent((object)body);
				bool flag8 = ((HashSet<object>)(object)_pendingDestroy).Remove((object)body);
			}
		}
		body._enable = true;
		ProfilerMarker.AutoScope autoScope = default(ProfilerMarker.AutoScope);
		autoScope.Dispose();
		return body;
	}

	private unsafe void disable(ArcadeColliderType obj)
	{
		//IL_0344: Expected I, but got O
		//IL_000d: Expected I, but got O
		//IL_001d: Expected O, but got I
		//IL_036a: Expected O, but got I4
		//IL_0374: Expected O, but got I4
		//IL_037d: Expected O, but got I4
		//IL_013d: Expected O, but got I
		//IL_0059: Expected O, but got I
		//IL_0096: Expected O, but got I
		//IL_00d2: Expected O, but got I
		//IL_01a0: Expected O, but got I
		//IL_0319: Unknown result type (might be due to invalid IL or missing references)
		//IL_031e: Expected O, but got Unknown
		//IL_01da: Expected I, but got O
		//IL_01f2: Expected O, but got I
		//IL_022e: Expected O, but got I
		//IL_026b: Expected O, but got I
		//IL_0283: Expected O, but got Ref
		nint num = (nint)typeof(PhaserArray);
		ArcadeColliderType arcadeColliderType;
		if (obj != null)
		{
			nint num2 = (nint)obj;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rdx_v1 (Il2CppClass<PhaserArray>)+130]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v60 @ r8_v18 (Il2CppClass<ArcadeColliderType>)+130]");
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rdx_v1 (Il2CppClass<PhaserArray>)+130]");
			if (num3 >= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v60 @ r8_v18 (Il2CppClass<ArcadeColliderType>)+C8]");
				object obj3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v76 @ rax_v38+FFFFFFF8+v61 @ rax_v37*8]");
				if (0 == (nint)typeof(PhaserArray))
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rdx_v1 (Il2CppClass<PhaserArray>)+130]");
					PhaserArray phaserArray = (PhaserArray)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v60 @ r8_v18 (Il2CppClass<ArcadeColliderType>)+130]");
					nint num4 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rdx_v1 (Il2CppClass<PhaserArray>)+130]");
					if (num4 >= 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v60 @ r8_v18 (Il2CppClass<ArcadeColliderType>)+C8]");
						object obj4 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v131 @ rax_v42+FFFFFFF8+v113 @ rax_v39 (PhaserArray)*8]");
						if (0 == (nint)typeof(PhaserArray))
						{
							arcadeColliderType = obj;
							goto IL_0361;
						}
					}
					throw new InvalidCastException();
				}
			}
		}
		PhaserArray phaserArray2 = new PhaserArray(obj);
		arcadeColliderType = phaserArray2;
		goto IL_0361;
		IL_0361:
		object obj5 = 0;
		HashSet<object>.Enumerator enumerator = (HashSet<object>.Enumerator)0;
		HashSet<object>.Enumerator enumerator2 = (HashSet<object>.Enumerator)0;
		object obj10 = default(object);
		HashSet<object>.Enumerator enumerator4 = default(HashSet<object>.Enumerator);
		BaseBody body = default(BaseBody);
		while (true)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v175 @ r14_v7 (ArcadeColliderType)+10]");
			object obj6 = 0;
			object obj7 = obj5;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v260 @ rax_v16+18]");
			if ((nint)obj7 >= 0)
			{
				return;
			}
			object obj8 = obj5;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v260 @ rax_v16+18]");
			if ((nint)obj8 < 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v260 @ rax_v16+20+v192 @ rdi_v7*8]");
				object obj9 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
				if (obj10 != null)
				{
					nint num5 = (nint)typeof(Group);
					object obj11 = obj9;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v306 @ rdx_v12 (Il2CppClass<Group>)+130]");
					object obj12 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v457 @ r8_v13+130]");
					nint num6 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v306 @ rdx_v12 (Il2CppClass<Group>)+130]");
					if (num6 < 0)
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v457 @ r8_v13+C8]");
					object obj13 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v316 @ rax_v23+FFFFFFF8+v589 @ rax_v22*8]");
					if (0 != (nint)typeof(Group))
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v309 @ rbx_v10+18]");
					object obj14 = 0;
					if (enumerator.MoveNext())
					{
						ArcadeColliderType arcadeColliderType2 = null;
						HashSet<object>.Enumerator enumerator3 = (HashSet<object>.Enumerator)(&enumerator);
						throw new NullReferenceException();
					}
					enumerator = enumerator4;
					enumerator2 = enumerator4;
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1809B54E0");
					disableBody(body);
				}
				obj5++;
				continue;
			}
			throw new IndexOutOfRangeException();
		}
		throw new InvalidCastException();
	}

	public void disableBody(BaseBody body)
	{
		//IL_01b3: Expected I, but got O
		//IL_01bb: Expected I, but got O
		//IL_01cb: Expected O, but got I
		//IL_0207: Expected O, but got I
		//IL_005a: Expected I, but got O
		//IL_0062: Expected I, but got O
		//IL_0072: Expected O, but got I
		//IL_00ae: Expected O, but got I
		//IL_0101: Expected I, but got O
		//IL_0109: Expected I, but got O
		//IL_0119: Expected O, but got I
		//IL_0155: Expected O, but got I
		if (body._physicsType != PhysicsType.DYNAMIC_BODY)
		{
			if (body._physicsType == PhysicsType.STATIC_BODY)
			{
				nint num = (nint)typeof(StaticBody);
				nint num2 = (nint)body;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v221 @ r8_v8 (Il2CppClass<StaticBody>)+130]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ r9_v7 (Il2CppClass<BaseBody>)+130]");
				nint num3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v221 @ r8_v8 (Il2CppClass<StaticBody>)+130]");
				if (num3 >= 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ r9_v7 (Il2CppClass<BaseBody>)+C8]");
					object obj2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v297 @ rax_v15+FFFFFFF8+v222 @ rax_v14*8]");
					if (0 == (nint)typeof(StaticBody))
					{
						bool flag = ((HashSet<object>)(object)_staticBodies).Remove((object)body);
						nint num4 = (nint)typeof(StaticBody);
						nint num5 = (nint)body;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v180 @ r8_v10 (Il2CppClass<StaticBody>)+130]");
						object obj3 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v178 @ r9_v8 (Il2CppClass<BaseBody>)+130]");
						nint num6 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v180 @ r8_v10 (Il2CppClass<StaticBody>)+130]");
						if (num6 >= 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v178 @ r9_v8 (Il2CppClass<BaseBody>)+C8]");
							object obj4 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v183 @ rax_v18+FFFFFFF8+v182 @ rax_v17*8]");
							if (0 == (nint)typeof(StaticBody))
							{
								RBush rBush = _staticTree.remove(body);
								body._enable = false;
								return;
							}
						}
						throw new InvalidCastException();
					}
				}
				throw new InvalidCastException();
			}
			goto IL_024c;
		}
		nint num7 = (nint)typeof(Body);
		nint num8 = (nint)body;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v161 @ r8_v6 (Il2CppClass<Body>)+130]");
		object obj5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v131 @ r9_v6 (Il2CppClass<BaseBody>)+130]");
		nint num9 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v161 @ r8_v6 (Il2CppClass<Body>)+130]");
		if (num9 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v131 @ r9_v6 (Il2CppClass<BaseBody>)+C8]");
			object obj6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v276 @ rax_v12+FFFFFFF8+v162 @ rax_v11*8]");
			if (0 == (nint)typeof(Body))
			{
				bool flag2 = ((HashSet<object>)(object)_bodies).Remove((object)body);
				goto IL_024c;
			}
		}
		throw new InvalidCastException();
		IL_024c:
		body._enable = false;
	}

	private void remove(BaseBody body)
	{
		//IL_01aa: Expected I, but got O
		//IL_01b2: Expected I, but got O
		//IL_01c2: Expected O, but got I
		//IL_01fe: Expected O, but got I
		//IL_005a: Expected I, but got O
		//IL_0062: Expected I, but got O
		//IL_0072: Expected O, but got I
		//IL_00ae: Expected O, but got I
		//IL_0101: Expected I, but got O
		//IL_0109: Expected I, but got O
		//IL_0119: Expected O, but got I
		//IL_0155: Expected O, but got I
		if (body._physicsType != PhysicsType.DYNAMIC_BODY)
		{
			if (body._physicsType != PhysicsType.STATIC_BODY)
			{
				return;
			}
			nint num = (nint)typeof(StaticBody);
			nint num2 = (nint)body;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v211 @ r8_v8 (Il2CppClass<StaticBody>)+130]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ r9_v7 (Il2CppClass<BaseBody>)+130]");
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v211 @ r8_v8 (Il2CppClass<StaticBody>)+130]");
			if (num3 >= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ r9_v7 (Il2CppClass<BaseBody>)+C8]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v296 @ rax_v15+FFFFFFF8+v212 @ rax_v14*8]");
				if (0 == (nint)typeof(StaticBody))
				{
					bool flag = ((HashSet<object>)(object)_staticBodies).Remove((object)body);
					nint num4 = (nint)typeof(StaticBody);
					nint num5 = (nint)body;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v181 @ r8_v10 (Il2CppClass<StaticBody>)+130]");
					object obj3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v179 @ r9_v8 (Il2CppClass<BaseBody>)+130]");
					nint num6 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v181 @ r8_v10 (Il2CppClass<StaticBody>)+130]");
					if (num6 >= 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v179 @ r9_v8 (Il2CppClass<BaseBody>)+C8]");
						object obj4 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v184 @ rax_v18+FFFFFFF8+v183 @ rax_v17*8]");
						if (0 == (nint)typeof(StaticBody))
						{
							RBush rBush = _staticTree.remove(body);
							return;
						}
					}
					throw new InvalidCastException();
				}
			}
			throw new InvalidCastException();
		}
		nint num7 = (nint)typeof(Body);
		nint num8 = (nint)body;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v161 @ rdx_v7 (Il2CppClass<Body>)+130]");
		object obj5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v162 @ r9_v5 (Il2CppClass<BaseBody>)+130]");
		nint num9 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v161 @ rdx_v7 (Il2CppClass<Body>)+130]");
		if (num9 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v162 @ r9_v5 (Il2CppClass<BaseBody>)+C8]");
			object obj6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v276 @ rax_v11+FFFFFFF8+v163 @ rax_v10*8]");
			if (0 == (nint)typeof(Body))
			{
				bool flag2 = ((HashSet<object>)(object)_bodies).Remove((object)body);
				return;
			}
		}
		throw new InvalidCastException();
	}

	public World setBounds(float x, float y, float width, float height, bool? checkLeft = null, bool checkRight = true, bool checkUp = true, bool checkDown = true)
	{
		//IL_0021: Expected F4, but got I
		ArcadeBodyBounds bounds = _bounds;
		if (_bounds != null)
		{
			object obj = default(object);
			bool flag = obj == null;
			IntPtr intPtr = default(IntPtr);
			bounds.height = (nint)intPtr;
			bounds.x = x;
			bounds.y = y;
			bounds.width = width;
			if (flag)
			{
				goto IL_016a;
			}
			CheckCollisionObject checkCollision = _checkCollision;
			if (_checkCollision != null)
			{
				bool left = default(bool);
				checkCollision._left = left;
				CheckCollisionObject checkCollision2 = _checkCollision;
				if (_checkCollision != null)
				{
					bool right = default(bool);
					checkCollision2._right = right;
					CheckCollisionObject checkCollision3 = _checkCollision;
					if (_checkCollision != null)
					{
						bool up = default(bool);
						checkCollision3._up = up;
						CheckCollisionObject checkCollision4 = _checkCollision;
						if (_checkCollision != null)
						{
							bool down = default(bool);
							checkCollision4._down = down;
							goto IL_016a;
						}
					}
				}
			}
		}
		return (World)(object)new NullReferenceException();
		IL_016a:
		return this;
	}

	public World setBoundsCollision(bool left = true, bool right = true, bool up = true, bool down = true)
	{
		CheckCollisionObject checkCollision = _checkCollision;
		if (_checkCollision != null)
		{
			checkCollision._left = left;
			CheckCollisionObject checkCollision2 = _checkCollision;
			if (_checkCollision != null)
			{
				checkCollision2._right = right;
				CheckCollisionObject checkCollision3 = _checkCollision;
				if (_checkCollision != null)
				{
					checkCollision3._up = up;
					CheckCollisionObject checkCollision4 = _checkCollision;
					if (_checkCollision != null)
					{
						bool down2 = default(bool);
						checkCollision4._down = down2;
						return this;
					}
				}
			}
		}
		return (World)(object)new NullReferenceException();
	}

	public World pause()
	{
		_isPaused = true;
		emit(WorldEvents.PauseEvent);
		return this;
	}

	public World resume()
	{
		_isPaused = false;
		emit(WorldEvents.ResumeEvent);
		return this;
	}

	public Collider addCollider(ArcadeColliderType object1, ArcadeColliderType object2, ArcadePhysicsCallback collideCallback, ArcadePhysicsCallback processCallback, CallbackContext callbackContext)
	{
		ArcadeColliderType object3 = default(ArcadeColliderType);
		ArcadePhysicsCallback collideCallback2 = default(ArcadePhysicsCallback);
		ArcadePhysicsCallback processCallback2 = default(ArcadePhysicsCallback);
		CallbackContext callbackContext2 = default(CallbackContext);
		Collider result = new Collider(this, overlapOnly: false, object1, object3, collideCallback2, processCallback2, callbackContext2);
		if (_colliders != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1809B4520");
			return result;
		}
		return (Collider)(object)new NullReferenceException();
	}

	public Collider addOverlap(ArcadeColliderType object1, ArcadeColliderType object2, ArcadePhysicsCallback collideCallback, ArcadePhysicsCallback processCallback, CallbackContext callbackContext)
	{
		ArcadeColliderType object3 = default(ArcadeColliderType);
		ArcadePhysicsCallback collideCallback2 = default(ArcadePhysicsCallback);
		ArcadePhysicsCallback processCallback2 = default(ArcadePhysicsCallback);
		CallbackContext callbackContext2 = default(CallbackContext);
		Collider result = new Collider(this, overlapOnly: true, object1, object3, collideCallback2, processCallback2, callbackContext2);
		if (_colliders != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1809B4520");
			return result;
		}
		return (Collider)(object)new NullReferenceException();
	}

	public Collider addColliderDirect(Collider collider)
	{
		if (_colliders != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1809B4520");
			return collider;
		}
		return (Collider)(object)new NullReferenceException();
	}

	public World removeCollider(Collider collider)
	{
		ProcessQueue<Collider> colliders = _colliders;
		if (_colliders != null)
		{
			List<object> list = (List<object>)(object)colliders._destroy;
			if (colliders._destroy != null)
			{
				object[] items = list._items;
				int version = list._version + 1;
				list._version = version;
				if (list._items != null)
				{
					if (list._size >= items.Length)
					{
						((List<object>)(object)colliders._destroy).AddWithResize((object)collider);
					}
					else
					{
						int size = list._size + 1;
						list._size = size;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
					}
					int toProcess = colliders._toProcess + 1;
					colliders._toProcess = toProcess;
					return this;
				}
			}
		}
		return (World)(object)new NullReferenceException();
	}

	public unsafe World insertColliderDirect(Collider collider, int position)
	{
		//IL_003e: Expected O, but got Ref
		ProcessQueue<Collider> colliders = _colliders;
		if (colliders._pendingInserts != null)
		{
			object obj = default(object);
			colliders._pendingInserts.Add((KeyValuePair<Collider, int>)(&obj));
			int toProcess = colliders._toProcess + 1;
			colliders._toProcess = toProcess;
			return this;
		}
		return (World)(object)new NullReferenceException();
	}

	public void setFPS(int frameRate)
	{
		_fps = frameRate;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"divsd xmm1,xmm0\"");
		_frameTime = 1.0;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"mulsd xmm1,qword ptr [188A109F8h]\"");
		_frameTimeMS = 1.0;
	}

	public void update()
	{
		//IL_023a: Expected O, but got F4
		//IL_00e7: Expected F4, but got I4
		object obj = Time.deltaTime;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtss2sd xmm1,xmm0\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"mulsd xmm1,qword ptr [188A109F8h]\"");
		if (_isPaused)
		{
			return;
		}
		HashSet<Body> bodies = _bodies;
		bool flag = bodies._count < 0;
		if (bodies._count == 0)
		{
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"mulsd xmm7,qword ptr [rbx+88h]\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"addsd xmm0,xmm1\"");
		_elapsed = _elapsed;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"comisd xmm0,xmm7\"");
		bool flag2 = !flag;
		bool flag3 = _fixedStep;
		float delta = (float)_frameTime;
		if (!flag3)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"mulsd xmm1,qword ptr [188A103D8h]\"");
			_elapsed = 0.0;
			flag2 = true;
			delta = 0f;
		}
		_iteratingOverBodies = true;
		HashSet<object>.Enumerator enumerator = default(HashSet<object>.Enumerator);
		while (enumerator.MoveNext())
		{
			Body body = null;
			if (body._enable)
			{
				((Body)null).preUpdate(flag2, delta);
			}
		}
		_iteratingOverBodies = false;
		if (flag2)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"subsd xmm0,xmm7\"");
			_elapsed = _elapsed;
			step(delta, runBodyStep: false);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"comisd xmm0,xmm7\"");
		if ((flag2 ? 1 : 0) >= (false ? 1 : 0))
		{
			do
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"subsd xmm0,xmm7\"");
				_elapsed = _elapsed;
				step(delta);
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"comisd xmm0,xmm7\"");
			}
			while ((flag2 ? 1 : 0) >= (false ? 1 : 0));
		}
	}

	public void step(float delta, bool runBodyStep = true)
	{
		//IL_00ac: Expected F4, but got I4
		//IL_00b5: Expected O, but got I4
		//IL_00be: Expected O, but got I4
		//IL_0048: Expected F4, but got I4
		//IL_04b5: Expected O, but got I4
		//IL_0186: Expected F4, but got I4
		//IL_0367: Expected I, but got F4
		//IL_025b: Expected O, but got I
		//IL_0385: Expected O, but got I
		//IL_0534: Unknown result type (might be due to invalid IL or missing references)
		//IL_0539: Expected O, but got Unknown
		//IL_02aa: Expected I, but got O
		//IL_03b8: Expected I, but got O
		HashSet<Body> bodies = _bodies;
		bool flag = _bodies == null;
		World world = this;
		if (!flag)
		{
			bool flag2 = default(bool);
			object obj;
			if (flag2)
			{
				_iteratingOverBodies = true;
				float num = 0f;
				HashSet<object>.Enumerator enumerator = default(HashSet<object>.Enumerator);
				if (enumerator.MoveNext())
				{
					Body body = null;
					Body body2 = null;
					throw new NullReferenceException();
				}
				_iteratingOverBodies = false;
				HashSet<object>.Enumerator enumerator2 = (HashSet<object>.Enumerator)bodies;
				obj = 0;
			}
			else
			{
				float num = 0f;
				HashSet<object>.Enumerator enumerator2 = (HashSet<object>.Enumerator)0;
				obj = 0;
			}
			UpdateGroups();
			if (_useTree)
			{
				bool flag3 = _groupsWithRTrees == null;
				world = this;
				if (flag3)
				{
					goto IL_0409;
				}
				List<Group>.Enumerator enumerator3 = default(List<Group>.Enumerator);
				if (enumerator3.MoveNext())
				{
					Group obj2 = null;
					if (_groupRTrees != null)
					{
						RBush rBush = _groupRTrees.get_Item((Group)null);
						if (rBush != null)
						{
							RBush rBush2 = rBush.clear();
							throw new NullReferenceException();
						}
						throw new NullReferenceException();
					}
					throw new NullReferenceException();
				}
				bodies = (HashSet<Body>)(object)_groupsWithRTrees;
				float num = 0f;
				HashSet<object>.Enumerator enumerator2 = (HashSet<object>.Enumerator)_groupsWithRTrees;
			}
			bool flag4 = _colliders == null;
			world = (World)(object)_colliders;
			if (!flag4)
			{
				List<Collider> list = _colliders.Update();
				bool flag5 = list == null;
				object obj3 = obj;
				world = (World)(object)_colliders;
				if (!flag5)
				{
					float num4 = default(float);
					object obj5 = default(object);
					while (true)
					{
						if ((nint)obj3 < list._size)
						{
							if ((nint)obj < list._size)
							{
								world = (World)(object)list._items;
								if (list._items == null)
								{
									break;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v136 @ rcx_v11 (World)+20+v232 @ rbx_v11*8]");
								world = (World)0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v136 @ rcx_v11 (World)+20+v232 @ rbx_v11*8]");
								if ((nint)0 == 0)
								{
									break;
								}
								if (world._bodies != null)
								{
									nint num2 = (nint)world;
									Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v972 @ rax_v45 (Il2CppClass<World>)+178] (should have been resolved before IL gen)");
								}
								obj++;
								obj3 = obj;
								continue;
							}
							System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
							throw new IndexOutOfRangeException();
						}
						UpdateGroups();
						nint num3 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v233 @ rbx_v12 (Il2CppMethodInfo)+38]");
						if ((nint)0 == 0)
						{
							world = (World)(object)typeof(object[]);
						}
						Delegate[] array = base.callbacks;
						if (base.callbacks == null)
						{
							break;
						}
						if ((object)array[4] != null)
						{
							object[] array2 = new object[1];
							object obj4 = (IntPtr)num4;
							bool flag6 = array2 == null;
							world = (World)0;
							if (flag6)
							{
								break;
							}
							if (obj4 != null)
							{
								nint num5 = (nint)array2;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
								if (obj5 == null)
								{
									ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
									throw ex;
								}
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
							object obj6 = array[4].DynamicInvokeImpl(array2);
						}
						int stepsLastFrame = _stepsLastFrame + 1;
						_stepsLastFrame = stepsLastFrame;
						return;
					}
				}
			}
		}
		goto IL_0409;
		IL_0409:
		throw new NullReferenceException();
	}

	private void UpdateGroups()
	{
		Dictionary<object, object>.Enumerator enumerator = default(Dictionary<object, object>.Enumerator);
		if (!enumerator.MoveNext())
		{
			return;
		}
		throw new NullReferenceException();
	}

	public unsafe void postUpdate()
	{
		//IL_05bb: Expected O, but got Ref
		//IL_00c6: Expected I, but got O
		//IL_0144: Expected O, but got Ref
		if (_stepsLastFrame != 0)
		{
			_stepsLastFrame = 0;
			_iteratingOverBodies = true;
			if (_bodies == null)
			{
				goto IL_0505;
			}
			HashSet<object>.Enumerator enumerator = default(HashSet<object>.Enumerator);
			World world2;
			if (enumerator.MoveNext())
			{
				World world = null;
				world2 = null;
				throw new NullReferenceException();
			}
			_iteratingOverBodies = false;
			world2 = (World)(&enumerator);
		}
		HashSet<BaseBody> pendingAdd = _pendingAdd;
		if (_pendingAdd != null)
		{
			HashSet<object>.Enumerator enumerator2 = default(HashSet<object>.Enumerator);
			if (pendingAdd._count > 0)
			{
				while (enumerator2.MoveNext())
				{
					BaseBody baseBody = add(null);
					nint num = unchecked((nint)null);
				}
				if (_pendingAdd == null)
				{
					goto IL_0505;
				}
				bool flag = ((HashSet<BaseBody>.Enumerator*)_pendingAdd)->MoveNext();
			}
			HashSet<BaseBody>.Enumerator pendingDestroy = (HashSet<BaseBody>.Enumerator)_pendingDestroy;
			if (_pendingDestroy != null)
			{
				if ((nint)pendingDestroy._current > 0)
				{
					if (enumerator2.MoveNext())
					{
						object obj = null;
						RBush rBush = (RBush)(&enumerator2);
						throw new NullReferenceException();
					}
					bool flag2 = ((HashSet<BaseBody>.Enumerator*)_pendingDestroy)->MoveNext();
				}
				UpdateGroups();
				return;
			}
		}
		goto IL_0505;
		IL_0505:
		throw new NullReferenceException();
	}

	public void updateMotion(Body body, float delta)
	{
		//IL_0047: Invalid comparison between F4 and I4
		//IL_01fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0201: Expected F4, but got Unknown
		//IL_020e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0213: Expected O, but got Unknown
		//IL_023d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0242: Expected O, but got Unknown
		//IL_008e: Invalid comparison between F4 and I4
		//IL_0121: Expected F4, but got I4
		if (body._allowRotation)
		{
			float num = body._angularVelocity;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000185008B28h\"");
			if (body._angularAcceleration == 0f)
			{
				if (body._allowDrag)
				{
					bool flag = body._angularDrag == 0f;
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000185008AEFh\"");
					if (!flag)
					{
						float num2 = body._angularDrag * delta;
						float num3 = num - num2;
						if (!(num3 > -0.1f))
						{
							float num4 = num2 + num;
							num = ((0.1f > num4) ? (num + num2) : 0f);
						}
						else
						{
							num -= num2;
						}
					}
				}
			}
			else
			{
				float num5 = body._angularAcceleration * delta;
				num += num5;
			}
			float maxAngular = body._maxAngular;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
			float num6 = maxAngular ^ 0;
			object obj = num & -2147483649L;
			if ((nint)obj > 2139095040 || num > body._maxAngular)
			{
				num = body._maxAngular;
			}
			object obj2 = num & -2147483649L;
			if ((nint)obj2 > 2139095040 || num6 > num)
			{
				num = num6;
			}
			float num7 = num - body._angularVelocity;
			float num8 = (body._angularVelocity = num7 + body._angularVelocity) * delta;
			float rotation = num8 + body._rotation;
			body._rotation = rotation;
		}
		computeVelocity(body, delta);
	}

	public void computeAngularVelocity(Body body, float delta)
	{
		//IL_0025: Invalid comparison between F4 and I4
		//IL_01cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d0: Expected F4, but got Unknown
		//IL_01dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e2: Expected O, but got Unknown
		//IL_020c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0211: Expected O, but got Unknown
		//IL_006c: Invalid comparison between F4 and I4
		//IL_00ff: Expected F4, but got I4
		float num = body._angularVelocity;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000185008C48h\"");
		if (body._angularAcceleration == 0f)
		{
			if (body._allowDrag)
			{
				bool flag = body._angularDrag == 0f;
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000185008C0Fh\"");
				if (!flag)
				{
					float num2 = body._angularDrag * delta;
					float num3 = num - num2;
					if (!(num3 > -0.1f))
					{
						float num4 = num2 + num;
						num = ((0.1f > num4) ? (num + num2) : 0f);
					}
					else
					{
						num -= num2;
					}
				}
			}
		}
		else
		{
			float num5 = body._angularAcceleration * delta;
			num += num5;
		}
		float maxAngular = body._maxAngular;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
		float num6 = maxAngular ^ 0;
		object obj = num & -2147483649L;
		if ((nint)obj > 2139095040 || num > body._maxAngular)
		{
			num = body._maxAngular;
		}
		object obj2 = num & -2147483649L;
		if ((nint)obj2 > 2139095040 || num6 > num)
		{
			num = num6;
		}
		float num7 = num - body._angularVelocity;
		float num8 = (body._angularVelocity = num7 + body._angularVelocity) * delta;
		float rotation = num8 + body._rotation;
		body._rotation = rotation;
	}

	public void computeVelocity(Body body, float delta)
	{
		//IL_0057: Expected F4, but got I
		//IL_007d: Expected F4, but got O
		//IL_00bc: Expected O, but got I
		//IL_011d: Expected F4, but got O
		//IL_05e8: Expected O, but got F4
		//IL_0151: Expected F4, but got O
		//IL_0563: Expected O, but got F4
		//IL_0296: Unknown result type (might be due to invalid IL or missing references)
		//IL_029b: Expected F4, but got Unknown
		//IL_02c7: Expected F4, but got O
		//IL_017a: Unknown result type (might be due to invalid IL or missing references)
		//IL_017f: Expected O, but got Unknown
		//IL_022f: Expected F4, but got O
		//IL_0495: Unknown result type (might be due to invalid IL or missing references)
		//IL_049a: Expected O, but got Unknown
		//IL_04a3: Invalid comparison between F4 and O
		//IL_02e6: Expected F4, but got I4
		//IL_02fb: Expected F4, but got O
		//IL_020e: Expected F4, but got O
		//IL_04c8: Expected F4, but got I4
		//IL_01e0: Expected F4, but got I4
		//IL_01ed: Expected F4, but got O
		//IL_03fe: Expected F4, but got I4
		bool flag = !body._allowGravity;
		float2 drag = body._drag;
		float num = body._speed;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [body @ rdx (Body)+74]");
		float num2 = 0f;
		float num3 = (float)body._velocity;
		if (!flag)
		{
			object obj = (object)body._gravity + (object)_gravity;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [body @ rdx (Body)+80]");
			nint num4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (World)+5C]");
			object obj2 = num4 + 0;
			float num5 = (float)obj * delta;
			float num6 = (float)obj2 * delta;
			num3 = (float)body._velocity + num5;
			num2 += num6;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp near ptr 0000000185008E56h\"");
		if ((object)body._acceleration == null)
		{
			bool flag2 = (byte)(~(body._allowDrag ? 1u : 0u)) != 0;
			float num7 = (float)body._acceleration;
			if (!flag2)
			{
				bool flag3 = (object)drag == null;
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000185008DD5h\"");
				num7 = (float)body._acceleration;
				if (!flag3)
				{
					if (!body._useDamping)
					{
						drag *= delta;
						float num8 = num3 - (float)drag;
						if (!(num8 > -0.01f))
						{
							float num9 = (float)drag + num3;
							if (!(0.01f > num9))
							{
								num3 = 0f;
								num7 = (float)body._acceleration;
							}
							else
							{
								num3 += (float)drag;
								num7 = (float)body._acceleration;
							}
						}
						else
						{
							num3 -= (float)drag;
							num7 = (float)body._acceleration;
						}
					}
					else
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B71D10");
						num3 *= (float)drag;
						float num10 = num2 * num2;
						float num11 = num3 * num3;
						float num12 = num10 + num11;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1850045F0");
						float num13 = num12 & -2147483649L;
						bool flag4 = 0.001f < num13;
						float num6 = num13;
						num = num12;
						num7 = (float)body._acceleration;
						if (!flag4)
						{
							num6 = num13;
							num3 = 0f;
							num = num12;
							num7 = (float)body._acceleration;
						}
					}
				}
			}
		}
		else
		{
			float num7 = (float)body._acceleration * delta;
			num3 += num7;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp near ptr 0000000185008F07h\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [body @ rdx (Body)+EC]");
		if ((nint)0 == 0)
		{
			if (~(body._allowDrag ? 1u : 0u) == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [body @ rdx (Body)+F8]");
				bool flag5 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000185008E84h\"");
				if (!flag5)
				{
					if (!body._useDamping)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [body @ rdx (Body)+F8]");
						float num14 = 0f * delta;
						float num15 = num2 - num14;
						if (!(num15 > -0.01f))
						{
							float num16 = num14 + num2;
							if (!(0.01f > num16))
							{
								num2 = 0f;
							}
							else
							{
								num2 += num14;
							}
						}
						else
						{
							num2 -= num14;
						}
					}
					else
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B71D10");
						float num17 = num2;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [body @ rdx (Body)+F8]");
						num2 = num17 * 0f;
						float num6 = num3 * num3;
						float num18 = num2 * num2;
						float num19 = num18 + num6;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1850045F0");
						object obj3 = num19 & -2147483649L;
						bool flag6 = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)0.001f) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj3);
						num = num19;
						if (!flag6)
						{
							num2 = 0f;
							num = num19;
						}
					}
				}
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [body @ rdx (Body)+EC]");
			float num20 = 0f * delta;
			num2 += num20;
		}
		body._velocity = (float2)num3;
		if (body._maxSpeed > -1f && num > body._maxSpeed)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185015910");
			object obj4 = default(object);
			float num21 = (float)obj4 * body._maxSpeed;
			object obj5 = default(object);
			float num22 = (float)obj5 * body._maxSpeed;
			body._velocity = (float2)num21;
			num = body._maxSpeed;
		}
		body._speed = num;
	}

	private bool separate(BaseBody body1, BaseBody body2, ArcadePhysicsCallback processCallback, CallbackContext callbackContext, bool overlapOnly, bool intersects = false)
	{
		//IL_0683: Expected I, but got O
		//IL_072a: Expected F4, but got I
		//IL_072a: Expected F4, but got O
		//IL_02b6: Invalid comparison between F4 and O
		//IL_03a0: Expected O, but got I
		//IL_03b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b5: Expected O, but got Unknown
		//IL_03d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_03de: Expected F4, but got Unknown
		//IL_03e6: Invalid comparison between F4 and O
		//IL_0285: Invalid comparison between I and F4
		//IL_02eb: Invalid comparison between O and F4
		//IL_0063->IL0063: Incompatible stack heights: 1 vs 0
		//IL_00d4->IL0638: Incompatible stack heights: 2 vs 1
		//IL_00f6->IL0638: Incompatible stack heights: 2 vs 1
		//IL_011d->IL0638: Incompatible stack heights: 2 vs 1
		//IL_0180->IL0691: Incompatible stack heights: 2 vs 1
		//IL_01f9->IL0691: Incompatible stack heights: 2 vs 1
		//IL_0638->IL0691: Incompatible stack heights: 2 vs 1
		//IL_033f->IL0691: Incompatible stack heights: 2 vs 1
		World world = this;
		if ((object)s_separateMarker != null)
		{
			ProfilerUnsafeUtility.BeginSample((IntPtr)s_separateMarker);
			world = (World)s_separateMarker;
		}
		object obj = default(object);
		BaseBody baseBody = default(BaseBody);
		bool num;
		if (obj == null)
		{
			bool flag = baseBody == null;
			num = flag;
			if (!baseBody._enable)
			{
				goto IL_0638;
			}
		}
		bool flag2 = body2 == null;
		num = flag2;
		ProfilerMarker.AutoScope autoScope = default(ProfilerMarker.AutoScope);
		bool result;
		bool flag5 = default(bool);
		if (body2._enable)
		{
			bool flag3 = baseBody == null;
			if ((object)baseBody._checkCollision != null && (object)body2._checkCollision != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185004110");
				object obj2 = default(object);
				if (obj2 != null)
				{
					ArcadePhysicsCallback arcadePhysicsCallback = default(ArcadePhysicsCallback);
					if (arcadePhysicsCallback != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v545.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
						object obj3 = default(object);
						if (obj3 == null)
						{
							autoScope.Dispose();
							result = false;
							goto IL_0691;
						}
					}
					float num2 = default(float);
					if (baseBody._isCircle && body2._isCircle)
					{
						bool flag4 = separateCircle(baseBody, body2, flag5, num2);
						autoScope.Dispose();
						result = flag4;
					}
					else
					{
						if (baseBody._isCircle == body2._isCircle)
						{
							goto IL_033f;
						}
						bool flag6 = baseBody._isCircle;
						BaseBody baseBody2 = body2;
						if (!flag6)
						{
							baseBody2 = baseBody;
						}
						bool flag7 = baseBody._isCircle;
						BaseBody baseBody3 = baseBody;
						if (!flag7)
						{
							baseBody3 = body2;
						}
						float right = (float)baseBody2._size + (float)baseBody2._position;
						float2 position = baseBody2._position;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v676 @ rax_v41 (BaseBody)+54]");
						ArcadeRect arcadeRect = ArcadeRect.FromBounds((float)position, 0f, right, num2);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v622 @ rbx_v13 (BaseBody)+6C]");
						object obj4 = default(object);
						if ((nint)obj4 <= 0)
						{
							float num3 = (float)obj4 + (float)obj4;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v622 @ rbx_v13 (BaseBody)+6C]");
							bool flag8 = !(0f > num3);
							object obj5 = obj4;
							if (flag8)
							{
								goto IL_033f;
							}
						}
						float x = arcadeRect.x;
						float2 center = baseBody3._center;
						if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)x) <= System.Runtime.CompilerServices.Unsafe.As<float2, UIntPtr>(ref center))
						{
							float num3 = (float)obj4 + arcadeRect.x;
							bool flag9 = System.Runtime.CompilerServices.Unsafe.As<float2, UIntPtr>(ref baseBody3._center) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num3);
							object obj5 = obj4;
							if (flag9)
							{
								goto IL_033f;
							}
						}
						bool flag10 = separateCircle(baseBody, body2, flag5, num2);
						autoScope.Dispose();
						result = flag10;
					}
					goto IL_0691;
				}
			}
		}
		goto IL_0638;
		IL_033f:
		bool flag11 = !flag5;
		bool flag13;
		bool flag14;
		if (!flag5)
		{
			if (!_forceX)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v261 @ rdx_v4 (BaseBody)+80]");
				nint num4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ rcx_v1 (World)+5C]");
				object obj6 = num4 + 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
				object obj7 = obj6 & 0;
				object obj8 = (object)baseBody._gravity + (object)_gravity;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
				float num3 = obj8 & 0;
				if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num3) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj7))
				{
					bool flag12 = MathUtils.SeparateY(baseBody, body2, overlapOnly: false, OVERLAP_BIAS);
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185004110");
					object obj9 = default(object);
					flag11 = obj9 == null;
					flag13 = flag12;
					flag14 = false;
					if (!flag11)
					{
						bool flag15 = MathUtils.SeparateX(baseBody, body2, overlapOnly: false, OVERLAP_BIAS);
						flag13 = flag12;
						flag14 = flag15;
					}
					goto IL_06c3;
				}
			}
			bool flag16 = MathUtils.SeparateX(baseBody, body2, overlapOnly: false, OVERLAP_BIAS);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185004110");
			object obj10 = default(object);
			flag11 = obj10 == null;
			flag13 = false;
			flag14 = flag16;
			if (!flag11)
			{
				bool flag17 = MathUtils.SeparateY(baseBody, body2, overlapOnly: false, OVERLAP_BIAS);
				flag13 = flag17;
				flag14 = flag16;
			}
		}
		else
		{
			bool flag18 = MathUtils.SeparateX(baseBody, body2, flag5, OVERLAP_BIAS);
			bool flag19 = MathUtils.SeparateY(baseBody, body2, flag5, OVERLAP_BIAS);
			flag13 = flag19;
			flag14 = flag18;
		}
		goto IL_06c3;
		IL_0691:
		return result;
		IL_0638:
		autoScope.Dispose();
		result = false;
		goto IL_0691;
		IL_06c3:
		if (!flag11)
		{
			if (!flag5)
			{
				if (baseBody._onCollide != flag5 || body2._onCollide != flag5)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18300D320");
				}
			}
			else if (baseBody._onOverlap || body2._onOverlap)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18300D320");
			}
		}
		result = flag13 | flag14;
		autoScope.Dispose();
		goto IL_0691;
	}

	public unsafe bool separateCircle(BaseBody body1, BaseBody body2, bool overlapOnly, float bias = 0f)
	{
		//IL_0af5: Expected I, but got O
		//IL_01b6: Expected F4, but got I
		//IL_01d8: Expected F4, but got I
		//IL_01d8: Expected F4, but got O
		//IL_008c: Expected O, but got I
		//IL_0162: Expected F4, but got I
		//IL_0184: Expected F4, but got I
		//IL_0184: Expected F4, but got O
		//IL_0a07: Invalid comparison between F4 and I4
		//IL_0b10: Invalid comparison between F4 and O
		//IL_03e1: Invalid comparison between F4 and I4
		//IL_0a86: Expected O, but got I4
		//IL_03cb: Expected O, but got F4
		//IL_03d3: Expected O, but got F4
		//IL_024b: Invalid comparison between O and F4
		//IL_025d: Expected F4, but got I4
		//IL_026d: Expected O, but got Ref
		//IL_037e: Expected F4, but got I4
		//IL_038e: Expected O, but got Ref
		//IL_0463: Expected O, but got I
		//IL_03ac: Expected O, but got F4
		//IL_032c: Expected O, but got F4
		//IL_050f: Expected O, but got I4
		//IL_0518: Expected O, but got I4
		//IL_04d1: Expected O, but got I4
		//IL_0b67: Expected O, but got F4
		//IL_02c8: Expected F4, but got I4
		//IL_02d8: Expected O, but got Ref
		//IL_0b7c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b81: Expected O, but got Unknown
		//IL_0ba3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ba8: Expected O, but got Unknown
		//IL_0567: Expected O, but got I
		//IL_030f: Expected O, but got F4
		//IL_0317: Expected O, but got F4
		//IL_0cd2: Expected O, but got I
		//IL_0d18: Expected O, but got I
		//IL_06c7: Expected O, but got F4
		//IL_0727: Expected O, but got F4
		//IL_0755: Expected F4, but got O
		//IL_076a: Expected F4, but got I
		//IL_07fd: Expected O, but got I
		//IL_09d8: Expected O, but got I4
		//IL_0863: Expected O, but got F4
		//IL_08c3: Expected O, but got F4
		//IL_08f1: Expected F4, but got O
		//IL_0906: Expected F4, but got I
		//IL_0999: Expected O, but got I
		if ((object)s_separateCircleMarker != null)
		{
			ProfilerUnsafeUtility.BeginSample((IntPtr)s_separateCircleMarker);
		}
		float num = default(float);
		float overlapX = MathUtils.GetOverlapX(body1, body2, overlapOnly: false, num);
		float overlapY = MathUtils.GetOverlapY(body1, body2, overlapOnly: false, num);
		bool flag = body1 == null;
		bool flag2 = body2 == null;
		float num3;
		float num4;
		BaseBody baseBody2;
		if (body1._isCircle == body2._isCircle)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [body2 @ r8 (BaseBody)+6C]");
			nint num2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [body1 @ rdx (BaseBody)+6C]");
			object obj = num2 - 0;
			object obj2 = body2._center - body1._center;
			object obj3 = obj * obj;
			object obj4 = obj2 * obj2;
			object obj5 = obj4 + obj3;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1850045F0");
			object obj6 = body2._halfSize + body1._halfSize;
			num3 = (float)obj6 - (float)obj5;
			BaseBody baseBody = body2;
			num4 = num;
			baseBody2 = body1;
			goto IL_0afa;
		}
		ArcadeRect arcadeRect;
		float bottom = default(float);
		if (body2._isCircle)
		{
			float right = (float)body1._size + (float)body1._position;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [body1 @ rdx (BaseBody)+54]");
			float num5 = 0f;
			float2 position = body1._position;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [body1 @ rdx (BaseBody)+54]");
			arcadeRect = ArcadeRect.FromBounds((float)position, 0f, right, bottom);
		}
		else
		{
			float right2 = (float)body2._size + (float)body2._position;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [body2 @ r8 (BaseBody)+54]");
			float num5 = 0f;
			float2 position2 = body2._position;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [body2 @ r8 (BaseBody)+54]");
			arcadeRect = ArcadeRect.FromBounds((float)position2, 0f, right2, bottom);
		}
		num4 = arcadeRect.x;
		float2 float5 = ((!body1._isCircle) ? body2._halfSize : body1._halfSize);
		float num6 = default(float);
		object obj7 = default(object);
		float num8;
		object obj8 = default(object);
		float num9;
		float num11;
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num6) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj7))
		{
			float num7 = num6 + num6;
			bool flag3 = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj7) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num7);
			num8 = 0f;
			BaseBody baseBody = body2;
			baseBody2 = (BaseBody)(&obj8);
			if (!flag3)
			{
				if (num4 > num6)
				{
					num9 = num6;
					baseBody = (BaseBody)num6;
					goto IL_0b4d;
				}
				float num10 = num6 + num4;
				bool flag4 = !(num6 > num10);
				float num5 = num6;
				num8 = 0f;
				baseBody = body2;
				baseBody2 = (BaseBody)(&obj8);
				if (!flag4)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185003D90");
					num8 = num10 - (float)float5;
					num5 = num6;
					baseBody = (BaseBody)num6;
					baseBody2 = (BaseBody)num6;
				}
			}
		}
		else
		{
			BaseBody baseBody;
			if (num4 > num6)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185003D90");
				num11 = num6;
				baseBody = (BaseBody)num6;
				baseBody2 = (BaseBody)num6;
				goto IL_0b39;
			}
			num9 = num6 + num4;
			bool flag5 = !(num6 > num9);
			float num5 = num6;
			num8 = 0f;
			baseBody = body2;
			baseBody2 = (BaseBody)(&obj8);
			if (!flag5)
			{
				num5 = num6;
				baseBody = (BaseBody)num6;
				goto IL_0b4d;
			}
		}
		goto IL_0b24;
		IL_0c60:
		bool result;
		return result;
		IL_0afa:
		object obj15;
		object obj16;
		float num24;
		float num25;
		float num26;
		if (!overlapOnly)
		{
			bool flag6 = num3 == 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 000000018500982Bh\"");
			if (flag6)
			{
				goto IL_0a1e;
			}
			if (!body1._immovable || !body2._immovable)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [body1 @ rdx (BaseBody)+6C]");
				nint num12 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [body2 @ r8 (BaseBody)+6C]");
				object obj9 = num12 - 0;
				object obj10 = body1._center - body2._center;
				object obj11 = obj9 * obj9;
				object obj12 = obj10 * obj10;
				object obj13 = obj12 + obj11;
				object obj14;
				if (0 <= (nint)obj13)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"sqrtss xmm0,xmm1\"");
					obj14 = 0;
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73D18");
					obj14 = obj13;
				}
				bool flag7 = obj14 == null;
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000185009884h\"");
				obj15 = 0;
				obj16 = 0;
				if (!flag7)
				{
					object obj17 = body2._center - body1._center;
					obj16 = obj17 / obj14;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [body2 @ r8 (BaseBody)+6C]");
					nint num13 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [body1 @ rdx (BaseBody)+6C]");
					object obj18 = num13 - 0;
					obj15 = obj18 / obj14;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [body2 @ r8 (BaseBody)+74]");
				object obj19 = 0 * obj15;
				object obj20 = (object)body2._velocity * obj16;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [body1 @ rdx (BaseBody)+74]");
				object obj21 = 0 * obj15;
				object obj22 = (object)body1._velocity * obj16;
				object obj23 = obj22 + obj21;
				object obj24 = obj23 - obj20;
				object obj25 = obj24 - obj19;
				object obj26 = obj25 + obj25;
				float num14 = body2._mass + body1._mass;
				float num15 = (float)obj26 / num14;
				float num18;
				float num20;
				if (!body1._immovable && !body2._immovable)
				{
					float num16 = num3 * 0.5f;
					float num17 = num16 + 1E-06f;
					num18 = num17 * (float)obj16;
					float num19 = num16 + 1E-06f;
					num20 = num19 * (float)obj15;
				}
				else
				{
					float num21 = num15 + num15;
					float num22 = num3 + 1E-06f;
					num18 = num22 * (float)obj16;
					float num23 = num3 + 1E-06f;
					num20 = num23 * (float)obj15;
					bool flag8 = body1._immovable;
					num15 = num21;
					num24 = num21;
					num25 = num20;
					num26 = num18;
					if (flag8)
					{
						goto IL_0c3b;
					}
				}
				float num27 = num15 / body1._mass;
				float num28 = num27 * (float)obj16;
				float num29 = (float)body1._velocity - num28;
				body1._velocity = (float2)num29;
				float num30 = num15 / body1._mass;
				float num31 = num30 * (float)obj15;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [body1 @ rdx (BaseBody)+74]");
				float num32 = 0f - num31;
				float num33 = (float)body1._position - num18;
				body1._position = (float2)num33;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [body1 @ rdx (BaseBody)+54]");
				float num34 = 0f - num20;
				body1.MinX = (float)body1._position;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [body1 @ rdx (BaseBody)+54]");
				body1.MinY = 0f;
				float maxX = (float)body1._size + (float)body1._position;
				body1.MaxX = maxX;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [body1 @ rdx (BaseBody)+5C]");
				float num35 = 0f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [body1 @ rdx (BaseBody)+54]");
				float maxY = num35 + 0f;
				body1.MaxY = maxY;
				float2 center = body1._halfSize + body1._position;
				body1._center = center;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [body1 @ rdx (BaseBody)+64]");
				nint num36 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [body1 @ rdx (BaseBody)+54]");
				object obj27 = num36 + 0;
				num24 = num15;
				num25 = num20;
				num26 = num18;
				goto IL_0c3b;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000185009B41h\"");
		if (num3 == 0f)
		{
			goto IL_0a1e;
		}
		if (body1._onOverlap || body2._onOverlap)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18300D320");
			BaseBody baseBody = (BaseBody)5;
		}
		result = true;
		goto IL_0c65;
		IL_0c3b:
		if (!body2._immovable)
		{
			float num37 = num24 / body2._mass;
			float num38 = num37 * (float)obj16;
			float num39 = num38 + (float)body2._velocity;
			body2._velocity = (float2)num39;
			float num40 = num24 / body2._mass;
			float num41 = num40 * (float)obj15;
			float num42 = num41;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [body2 @ r8 (BaseBody)+74]");
			float num43 = num42 + 0f;
			float num44 = (float)body2._position + num26;
			body2._position = (float2)num44;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [body2 @ r8 (BaseBody)+54]");
			float num45 = 0f + num25;
			body2.MinX = (float)body2._position;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [body2 @ r8 (BaseBody)+54]");
			body2.MinY = 0f;
			float maxX2 = (float)body2._size + (float)body2._position;
			body2.MaxX = maxX2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [body2 @ r8 (BaseBody)+5C]");
			float num46 = 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [body2 @ r8 (BaseBody)+54]");
			float maxY2 = num46 + 0f;
			body2.MaxY = maxY2;
			float2 center2 = body2._halfSize + body2._position;
			body2._center = center2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [body2 @ r8 (BaseBody)+64]");
			nint num47 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [body2 @ r8 (BaseBody)+54]");
			object obj28 = num47 + 0;
		}
		float2 velocity = body1._bounce * body1._velocity;
		body1._velocity = velocity;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [body1 @ rdx (BaseBody)+88]");
		nint num48 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [body1 @ rdx (BaseBody)+74]");
		object obj29 = num48 * 0;
		float2 velocity2 = body2._bounce * body2._velocity;
		body2._velocity = velocity2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [body2 @ r8 (BaseBody)+88]");
		nint num49 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [body2 @ r8 (BaseBody)+74]");
		object obj30 = num49 * 0;
		if (body1._onCollide || body2._onCollide)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18300D320");
			BaseBody baseBody = (BaseBody)6;
		}
		ProfilerMarker.AutoScope autoScope = default(ProfilerMarker.AutoScope);
		autoScope.Dispose();
		result = true;
		goto IL_0c60;
		IL_0b24:
		num3 = num8 * -1f;
		goto IL_0afa;
		IL_0a1e:
		result = false;
		goto IL_0c65;
		IL_0c65:
		autoScope.Dispose();
		goto IL_0c60;
		IL_0b39:
		num8 = num11 - (float)float5;
		goto IL_0b24;
		IL_0b4d:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185003D90");
		num11 = num9;
		baseBody2 = (BaseBody)num6;
		goto IL_0b39;
	}

	[MethodImpl((MethodImplOptions)256)]
	public bool intersects(BaseBody body1, BaseBody body2)
	{
		//IL_034b: Expected I, but got O
		//IL_0275: Unknown result type (might be due to invalid IL or missing references)
		//IL_027a: Expected O, but got Unknown
		//IL_0297: Expected O, but got I
		//IL_00e7: Expected O, but got I
		//IL_0178: Expected O, but got I
		//IL_0309->IL035e: Incompatible stack heights: 2 vs 0
		//IL_01bb->IL01f1: Incompatible stack heights: 2 vs 1
		//IL_0260->IL035e: Incompatible stack heights: 2 vs 0
		//IL_035e->IL035e: Incompatible stack heights: 2 vs 0
		//IL_01f1->IL035e: Incompatible stack heights: 2 vs 0
		if ((object)s_intersectsMarker != null)
		{
			ProfilerUnsafeUtility.BeginSample((IntPtr)s_intersectsMarker);
		}
		bool result;
		ProfilerMarker.AutoScope autoScope = default(ProfilerMarker.AutoScope);
		if (body1 != body2)
		{
			bool flag = body1 == null;
			if (body1._isCircle)
			{
				goto IL_01f1;
			}
			bool flag2 = body2 == null;
			if (!body2._isCircle)
			{
				object obj = body1._size + body1._position;
				float2 position = body2._position;
				bool flag3 = System.Runtime.CompilerServices.Unsafe.As<float2, UIntPtr>(ref position) >= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj);
				result = false;
				if (!flag3)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [body1 @ rdx (BaseBody)+5C]");
					nint num = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [body1 @ rdx (BaseBody)+54]");
					object obj2 = num + 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [body2 @ r8 (BaseBody)+54]");
					bool flag4 = 0 >= (nint)obj2;
					result = false;
					if (!flag4)
					{
						object obj3 = body2._size + body2._position;
						float2 position2 = body1._position;
						bool flag5 = System.Runtime.CompilerServices.Unsafe.As<float2, UIntPtr>(ref position2) >= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj3);
						result = false;
						if (!flag5)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [body2 @ r8 (BaseBody)+5C]");
							nint num2 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [body2 @ r8 (BaseBody)+54]");
							object obj4 = num2 + 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [body1 @ rdx (BaseBody)+54]");
							bool flag6 = 0 < (nint)obj4;
							result = flag6;
						}
					}
				}
				autoScope.Dispose();
			}
			else
			{
				if (body1._isCircle)
				{
					goto IL_01f1;
				}
				bool flag7 = ((World)s_intersectsMarker).circleBodyIntersects(body2, body1);
				autoScope.Dispose();
				result = flag7;
			}
		}
		else
		{
			autoScope.Dispose();
			result = false;
		}
		goto IL_035e;
		IL_01f1:
		bool flag8 = body2 == null;
		if (!body2._isCircle)
		{
			bool flag9 = ((World)s_intersectsMarker).circleBodyIntersects(body1, body2);
			autoScope.Dispose();
			result = flag9;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [body2 @ r8 (BaseBody)+64]");
			object obj5 = 0 + body1._halfSize;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [body2 @ r8 (BaseBody)+6C]");
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [body1 @ rdx (BaseBody)+6C]");
			object obj6 = num3 - 0;
			object obj7 = body2._center - body1._center;
			object obj8 = obj6 * obj6;
			object obj9 = obj7 * obj7;
			object obj10 = obj9 + obj8;
			object obj11 = obj5 * obj5;
			bool flag10 = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj11) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj10);
			result = !flag10;
			autoScope.Dispose();
		}
		goto IL_035e;
		IL_035e:
		return result;
	}

	[MethodImpl((MethodImplOptions)256)]
	public bool circleBodyIntersects(BaseBody circle, BaseBody body)
	{
		//IL_0177: Expected I4, but got O
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Expected O, but got Unknown
		//IL_0184: Unknown result type (might be due to invalid IL or missing references)
		//IL_0189: Expected O, but got Unknown
		//IL_01b6: Expected O, but got I
		//IL_01d3: Expected O, but got I
		//IL_01ed: Expected O, but got I8
		//IL_0217: Unknown result type (might be due to invalid IL or missing references)
		//IL_021c: Expected O, but got Unknown
		//IL_0164: Expected O, but got I
		//IL_026d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0272: Expected O, but got Unknown
		//IL_028f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0294: Expected O, but got Unknown
		float2 float5;
		if (circle != null && body != null)
		{
			float5 = circle._center;
			float2 float6 = body._size + body._position;
			object obj = circle._center & -2147483649L;
			if ((nint)obj <= 2139095040)
			{
				float2 center = circle._center;
				if (center <= float6 != 0)
				{
					goto IL_0177;
				}
			}
			float5 = float6;
			goto IL_0177;
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
		IL_0177:
		object obj2 = float5 & -2147483649L;
		if ((nint)obj2 <= 2139095040)
		{
			float2 position = body._position;
			if (position <= float5 != 0)
			{
				goto IL_01a6;
			}
		}
		float5 = body._position;
		goto IL_01a6;
		IL_0239:
		object obj3 = circle._center - float5;
		object obj4 = circle._center - float5;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [circle @ rdx (BaseBody)+6C]");
		object obj6;
		object obj5 = 0 - obj6;
		object obj7 = obj4 * obj3;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [circle @ rdx (BaseBody)+6C]");
		object obj8 = 0 - obj6;
		object obj9 = obj5 * obj8;
		object obj10 = circle._halfSize * circle._halfSize;
		object obj11 = obj7 + obj9;
		bool flag = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj10) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj11);
		return !flag;
		IL_020a:
		object obj12 = obj6 & -2147483649L;
		if ((nint)obj12 <= 2139095040)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [body @ r8 (BaseBody)+54]");
			if (0 <= (nint)obj6)
			{
				goto IL_0239;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [body @ r8 (BaseBody)+54]");
		obj6 = 0;
		goto IL_0239;
		IL_01a6:
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [circle @ rdx (BaseBody)+6C]");
		obj6 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [body @ r8 (BaseBody)+5C]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [body @ r8 (BaseBody)+54]");
		object obj13 = num + 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [circle @ rdx (BaseBody)+6C]");
		object obj14 = 0 & -2147483649L;
		if ((nint)obj14 <= 2139095040)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [circle @ rdx (BaseBody)+6C]");
			if (0 <= (nint)obj13)
			{
				goto IL_020a;
			}
		}
		obj6 = obj13;
		goto IL_020a;
	}

	public bool overlap(ArcadeColliderType object1, ArcadeColliderType object2, ArcadePhysicsCallback collideCallback = null, ArcadePhysicsCallback processCallback = null, CallbackContext callbackContext = null)
	{
		ArcadePhysicsCallback processCallback2 = default(ArcadePhysicsCallback);
		CallbackContext callbackContext2 = default(CallbackContext);
		bool overlapOnly = default(bool);
		return collideObjects(object1, object2, collideCallback, processCallback2, callbackContext2, overlapOnly);
	}

	public bool collide(ArcadeColliderType object1, ArcadeColliderType object2, ArcadePhysicsCallback collideCallback = null, ArcadePhysicsCallback processCallback = null, CallbackContext callbackContext = null)
	{
		ArcadePhysicsCallback processCallback2 = default(ArcadePhysicsCallback);
		CallbackContext callbackContext2 = default(CallbackContext);
		bool overlapOnly = default(bool);
		return collideObjects(object1, object2, collideCallback, processCallback2, callbackContext2, overlapOnly);
	}

	public bool collideObjects(ArcadeColliderType object1, ArcadeColliderType object2, ArcadePhysicsCallback collideCallback, ArcadePhysicsCallback processCallback, CallbackContext callbackContext, bool overlapOnly)
	{
		//IL_025a: Expected I, but got O
		//IL_0042: Expected I, but got O
		//IL_004a: Expected I, but got O
		//IL_005a: Expected O, but got I
		//IL_0295: Expected I, but got O
		//IL_02a5: Expected O, but got I
		//IL_0325: Expected O, but got I4
		//IL_0096: Expected O, but got I
		//IL_02e1: Expected O, but got I
		//IL_0178: Expected I, but got O
		//IL_0180: Expected I, but got O
		//IL_0190: Expected O, but got I
		//IL_0355: Expected I, but got O
		//IL_0365: Expected O, but got I
		//IL_0317: Expected O, but got I4
		//IL_03e5: Expected O, but got I4
		//IL_0348: Expected O, but got I4
		//IL_01cc: Expected O, but got I
		//IL_0de7: Expected O, but got I4
		//IL_03a1: Expected O, but got I
		//IL_0104: Expected O, but got I
		//IL_0479: Expected O, but got I4
		//IL_0493: Expected O, but got I4
		//IL_03d7: Expected O, but got I4
		//IL_0be9: Expected I, but got O
		//IL_0bf7: Expected I, but got O
		//IL_1049: Expected I, but got O
		//IL_1059: Expected O, but got I
		//IL_023a: Expected O, but got I
		//IL_1035: Expected I4, but got O
		//IL_08b1: Expected I, but got O
		//IL_08bf: Expected I, but got O
		//IL_0c0c: Expected O, but got I
		//IL_0feb: Expected I, but got O
		//IL_0ffb: Expected O, but got I
		//IL_0c43: Expected O, but got I
		//IL_08d4: Expected O, but got I
		//IL_0683: Expected I, but got O
		//IL_0691: Expected I, but got O
		//IL_0c7f: Expected O, but got I
		//IL_090b: Expected O, but got I
		//IL_0f27: Expected I, but got O
		//IL_0f37: Expected O, but got I
		//IL_0519: Expected I, but got O
		//IL_0527: Expected I, but got O
		//IL_0eac: Expected I, but got O
		//IL_0ebc: Expected O, but got I
		//IL_0cb6: Expected O, but got I
		//IL_0947: Expected O, but got I
		//IL_06ae: Expected O, but got I
		//IL_053c: Expected O, but got I
		//IL_097e: Expected O, but got I
		//IL_06e5: Expected O, but got I
		//IL_0d0b: Expected O, but got I
		//IL_0d30: Expected I, but got O
		//IL_0d3e: Expected I, but got O
		//IL_0573: Expected O, but got I
		//IL_0721: Expected O, but got I
		//IL_05af: Expected O, but got I
		//IL_0fa7: Expected I, but got O
		//IL_0fb7: Expected O, but got I
		//IL_0758: Expected O, but got I
		//IL_05e6: Expected O, but got I
		//IL_09cf: Expected O, but got I
		//IL_0792: Expected O, but got I4
		//IL_0a06: Expected O, but got I
		//IL_108d: Expected I, but got O
		//IL_109d: Expected O, but got I
		//IL_0638: Expected O, but got I
		//IL_065d: Expected I, but got O
		//IL_066b: Expected I, but got O
		//IL_0a42: Expected O, but got I
		//IL_07a7: Expected O, but got I
		//IL_0a79: Expected O, but got I
		//IL_07de: Expected O, but got I
		//IL_0aad: Expected I, but got O
		//IL_0abd: Expected O, but got I
		//IL_0f15: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f1a: Expected O, but got Unknown
		//IL_0af9: Expected O, but got I
		//IL_0857: Expected O, but got I
		//IL_0857: Expected O, but got I
		//IL_0868: Expected I, but got O
		//IL_0876: Expected I, but got O
		//IL_0b30: Expected O, but got I
		//IL_0b45: Expected O, but got I
		//IL_0b7b: Expected O, but got I
		//IL_0b7b: Expected O, but got I
		//IL_0ba0: Expected I, but got O
		//IL_0bae: Expected I, but got O
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		object obj = default(object);
		bool flag = obj == null;
		ArcadeColliderType arcadeColliderType = object1;
		if (!flag)
		{
			nint num = (nint)typeof(Group);
			nint num2 = (nint)object1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v349 @ rdx_v54 (Il2CppClass<Group>)+130]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v350 @ r8_v55 (Il2CppClass<ArcadeColliderType>)+130]");
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v349 @ rdx_v54 (Il2CppClass<Group>)+130]");
			if (num3 >= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v350 @ r8_v55 (Il2CppClass<ArcadeColliderType>)+C8]");
				object obj3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v372 @ rax_v110+FFFFFFF8+v351 @ rax_v109*8]");
				if (0 == (nint)typeof(Group))
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [object1 @ rdx (ArcadeColliderType)+30]");
					bool flag2 = (nint)0 != 2;
					arcadeColliderType = object1;
					if (!flag2)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [object1 @ rdx (ArcadeColliderType)+18]");
						PhaserArray phaserArray = new PhaserArray((HashSet<PhaserGameObject>)0);
						arcadeColliderType = phaserArray;
					}
					goto IL_0116;
				}
			}
			throw new InvalidCastException();
		}
		goto IL_0116;
		IL_0dd0:
		object obj4;
		bool flag3 = obj4 == null;
		int num4;
		ArcadeColliderType arcadeColliderType2 = (ArcadeColliderType)num4;
		ArcadeColliderType arcadeColliderType3;
		if (!flag3)
		{
			arcadeColliderType2 = arcadeColliderType3;
		}
		goto IL_0da6;
		IL_0d5b:
		if (arcadeColliderType3 == null)
		{
			arcadeColliderType2 = (ArcadeColliderType)num4;
			goto IL_0da6;
		}
		nint num5 = (nint)arcadeColliderType3;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v501 @ rdx_v25 (Il2CppClass<PhaserArray>)+130]");
		object obj5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v655 @ r9_v36 (Il2CppClass<ArcadeColliderType>)+130]");
		nint num6 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v501 @ rdx_v25 (Il2CppClass<PhaserArray>)+130]");
		if (num6 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v655 @ r9_v36 (Il2CppClass<ArcadeColliderType>)+C8]");
			object obj6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v776 @ rax_v96+FFFFFFF8+v656 @ rax_v92*8]");
			if (0 == (nint)typeof(PhaserArray))
			{
				obj4 = 1;
				goto IL_0dd0;
			}
		}
		obj4 = 0;
		goto IL_0dd0;
		IL_024c:
		nint num7 = (nint)typeof(PhaserArray);
		ArcadeColliderType arcadeColliderType4;
		if (arcadeColliderType == null)
		{
			num4 = 0;
			arcadeColliderType4 = null;
			goto IL_0d5b;
		}
		nint num8 = (nint)arcadeColliderType;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v501 @ rdx_v25 (Il2CppClass<PhaserArray>)+130]");
		object obj7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v515 @ r8_v48 (Il2CppClass<ArcadeColliderType>)+130]");
		nint num9 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v501 @ rdx_v25 (Il2CppClass<PhaserArray>)+130]");
		object obj9;
		if (num9 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v515 @ r8_v48 (Il2CppClass<ArcadeColliderType>)+C8]");
			object obj8 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v628 @ rax_v102+FFFFFFF8+v516 @ rax_v98*8]");
			if (0 == (nint)typeof(PhaserArray))
			{
				obj9 = 1;
				goto IL_0d7b;
			}
		}
		obj9 = 0;
		goto IL_0d7b;
		IL_0da6:
		_total = num4;
		ArcadePhysicsCallback processCallback2 = default(ArcadePhysicsCallback);
		CallbackContext callbackContext2 = default(CallbackContext);
		bool overlapOnly2 = default(bool);
		World world;
		if (arcadeColliderType4 == null && arcadeColliderType2 == null)
		{
			bool flag4 = collideHandler(arcadeColliderType, arcadeColliderType3, collideCallback, processCallback2, callbackContext2, overlapOnly2);
			world = this;
		}
		else
		{
			bool flag5 = arcadeColliderType2 == null;
			bool flag6 = !flag5;
			bool flag7 = arcadeColliderType4 == null;
			object obj10 = flag7 & flag6;
			bool flag8 = obj10 == null;
			object obj11 = !flag8;
			if (obj11 == null)
			{
				if (arcadeColliderType4 != null && arcadeColliderType2 == null)
				{
					if (arcadeColliderType3 == null)
					{
						world = this;
						int num10 = num4;
						nint num11 = (nint)typeof(PhaserArray);
						nint num12 = (nint)typeof(PhaserArray);
						while (true)
						{
							nint num13 = (nint)arcadeColliderType;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v147 @ r8_v44 (Il2CppClass<PhaserArray>)+130]");
							object obj12 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v127 @ r9_v33 (Il2CppClass<ArcadeColliderType>)+130]");
							nint num14 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v147 @ r8_v44 (Il2CppClass<PhaserArray>)+130]");
							if (num14 >= 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v127 @ r9_v33 (Il2CppClass<ArcadeColliderType>)+C8]");
								object obj13 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v882 @ rax_v83+FFFFFFF8+v881 @ rax_v82*8]");
								if (0 == num11)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v159 @ rdx_v43 (Il2CppClass<PhaserArray>)+130]");
									object obj14 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v127 @ r9_v33 (Il2CppClass<ArcadeColliderType>)+130]");
									nint num15 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v159 @ rdx_v43 (Il2CppClass<PhaserArray>)+130]");
									if (num15 >= 0)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v127 @ r9_v33 (Il2CppClass<ArcadeColliderType>)+C8]");
										object obj15 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v695 @ rax_v85+FFFFFFF8+v694 @ rax_v84*8]");
										if (0 == num12)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v198 @ rdi_v18 (ArcadeColliderType)+10]");
											object obj16 = 0;
											int num16 = num10;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v169 @ rax_v86+18]");
											if ((nint)num16 >= (nint)0)
											{
												break;
											}
											World world2 = world;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v169 @ rax_v86+20+v137 @ rbx_v32 (System.Int32)*8]");
											bool flag9 = world2.collideHandler((ArcadeColliderType)0, null, collideCallback, processCallback2, callbackContext2, overlapOnly2);
											num10++;
											world = this;
											num11 = (nint)typeof(PhaserArray);
											num12 = (nint)typeof(PhaserArray);
											continue;
										}
									}
									throw new InvalidCastException();
								}
							}
							throw new InvalidCastException();
						}
					}
					else
					{
						world = this;
						nint num17 = (nint)typeof(PhaserArray);
						nint num18 = (nint)typeof(PhaserArray);
						int num19 = num4;
						while (true)
						{
							nint num20 = (nint)arcadeColliderType;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v148 @ r8_v37 (Il2CppClass<PhaserArray>)+130]");
							object obj17 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1877 @ r9_v30 (Il2CppClass<ArcadeColliderType>)+130]");
							nint num21 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v148 @ r8_v37 (Il2CppClass<PhaserArray>)+130]");
							if (num21 >= 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1877 @ r9_v30 (Il2CppClass<ArcadeColliderType>)+C8]");
								object obj18 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1589 @ rax_v70+FFFFFFF8+v1507 @ rax_v69*8]");
								if (0 == num17)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1881 @ rdx_v40 (Il2CppClass<PhaserArray>)+130]");
									object obj19 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1877 @ r9_v30 (Il2CppClass<ArcadeColliderType>)+130]");
									nint num22 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1881 @ rdx_v40 (Il2CppClass<PhaserArray>)+130]");
									if (num22 >= 0)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1877 @ r9_v30 (Il2CppClass<ArcadeColliderType>)+C8]");
										object obj20 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1327 @ rax_v72+FFFFFFF8+v1326 @ rax_v71*8]");
										if (0 == num18)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v198 @ rdi_v18 (ArcadeColliderType)+10]");
											object obj21 = 0;
											int num23 = num19;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v170 @ rax_v73+18]");
											if ((nint)num23 >= (nint)0)
											{
												break;
											}
											object obj22 = num19 + 1;
											while (true)
											{
												nint num24 = (nint)arcadeColliderType;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1881 @ rdx_v40 (Il2CppClass<PhaserArray>)+130]");
												object obj23 = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v149 @ r8_v39 (Il2CppClass<ArcadeColliderType>)+130]");
												nint num25 = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1881 @ rdx_v40 (Il2CppClass<PhaserArray>)+130]");
												if (num25 >= 0)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v149 @ r8_v39 (Il2CppClass<ArcadeColliderType>)+C8]");
													object obj24 = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v989 @ rax_v77+FFFFFFF8+v988 @ rax_v76*8]");
													if (0 == num18)
													{
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v198 @ rdi_v18 (ArcadeColliderType)+10]");
														object obj25 = 0;
														object obj26 = obj22;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v171 @ rax_v78+18]");
														if ((nint)obj26 >= 0)
														{
															break;
														}
														if (num19 != (nint)obj22)
														{
															World world3 = world;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v170 @ rax_v73+20+v202 @ rsi_v22 (System.Int32)*8]");
															nint num26 = 0;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v171 @ rax_v78+20+v139 @ rbx_v29*8]");
															bool flag10 = world3.collideHandler((ArcadeColliderType)num26, (ArcadeColliderType)0, collideCallback, processCallback2, callbackContext2, overlapOnly2);
															world = this;
															num20 = (nint)collideCallback;
															num18 = (nint)typeof(PhaserArray);
														}
														obj22++;
														continue;
													}
												}
												throw new InvalidCastException();
											}
											num19++;
											num17 = num18;
											continue;
										}
									}
									throw new InvalidCastException();
								}
							}
							throw new InvalidCastException();
						}
					}
				}
				else
				{
					world = this;
					int num27 = num4;
					nint num28 = (nint)typeof(PhaserArray);
					nint num29 = (nint)typeof(PhaserArray);
					while (true)
					{
						nint num30 = (nint)arcadeColliderType;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v151 @ r8_v28 (Il2CppClass<PhaserArray>)+130]");
						object obj27 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v130 @ r9_v23 (Il2CppClass<ArcadeColliderType>)+130]");
						nint num31 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v151 @ r8_v28 (Il2CppClass<PhaserArray>)+130]");
						if (num31 >= 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v130 @ r9_v23 (Il2CppClass<ArcadeColliderType>)+C8]");
							object obj28 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1368 @ rax_v53+FFFFFFF8+v1254 @ rax_v52*8]");
							if (0 == num28)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v164 @ rdx_v34 (Il2CppClass<PhaserArray>)+130]");
								object obj29 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v130 @ r9_v23 (Il2CppClass<ArcadeColliderType>)+130]");
								nint num32 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v164 @ rdx_v34 (Il2CppClass<PhaserArray>)+130]");
								if (num32 >= 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v130 @ r9_v23 (Il2CppClass<ArcadeColliderType>)+C8]");
									object obj30 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1619 @ rax_v55+FFFFFFF8+v1520 @ rax_v54*8]");
									if (0 == num29)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v198 @ rdi_v18 (ArcadeColliderType)+10]");
										object obj31 = 0;
										int num33 = num27;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v172 @ rax_v56+18]");
										if ((nint)num33 >= (nint)0)
										{
											break;
										}
										int num34 = num4;
										nint num35 = num29;
										while (true)
										{
											nint num36 = (nint)arcadeColliderType3;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v153 @ r8_v30 (Il2CppClass<PhaserArray>)+130]");
											object obj32 = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v131 @ r9_v25 (Il2CppClass<ArcadeColliderType>)+130]");
											nint num37 = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v153 @ r8_v30 (Il2CppClass<PhaserArray>)+130]");
											if (num37 >= 0)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v131 @ r9_v25 (Il2CppClass<ArcadeColliderType>)+C8]");
												object obj33 = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1851 @ rax_v59+FFFFFFF8+v1838 @ rax_v58*8]");
												if (0 == num35)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v164 @ rdx_v34 (Il2CppClass<PhaserArray>)+130]");
													object obj34 = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v131 @ r9_v25 (Il2CppClass<ArcadeColliderType>)+130]");
													nint num38 = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v164 @ rdx_v34 (Il2CppClass<PhaserArray>)+130]");
													if (num38 >= 0)
													{
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v131 @ r9_v25 (Il2CppClass<ArcadeColliderType>)+C8]");
														object obj35 = 0;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1773 @ rax_v61+FFFFFFF8+v1772 @ rax_v60*8]");
														if (0 == num29)
														{
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v200 @ rsi_v18 (ArcadeColliderType)+10]");
															object obj36 = 0;
															int num39 = num27;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v173 @ rax_v62+18]");
															if ((nint)num39 >= (nint)0)
															{
																break;
															}
															nint num40 = (nint)arcadeColliderType;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v164 @ rdx_v34 (Il2CppClass<PhaserArray>)+130]");
															object obj37 = 0;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v154 @ r8_v32 (Il2CppClass<ArcadeColliderType>)+130]");
															nint num41 = 0;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v164 @ rdx_v34 (Il2CppClass<PhaserArray>)+130]");
															if (num41 >= 0)
															{
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v154 @ r8_v32 (Il2CppClass<ArcadeColliderType>)+C8]");
																object obj38 = 0;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v174 @ rax_v64+FFFFFFF8+v1715 @ rax_v63*8]");
																if (0 == num29)
																{
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v198 @ rdi_v18 (ArcadeColliderType)+10]");
																	object obj39 = 0;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v200 @ rsi_v18 (ArcadeColliderType)+10]");
																	object obj40 = 0;
																	World world4 = world;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v183 @ rcx_v51+20+v141 @ rbx_v25 (System.Int32)*8]");
																	nint num42 = 0;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1663 @ rax_v66+20+v82 @ rbp_v22 (System.Int32)*8]");
																	bool flag11 = world4.collideHandler((ArcadeColliderType)num42, (ArcadeColliderType)0, collideCallback, processCallback2, callbackContext2, overlapOnly2);
																	num34++;
																	world = this;
																	num35 = (nint)typeof(PhaserArray);
																	num29 = (nint)typeof(PhaserArray);
																	continue;
																}
															}
															throw new InvalidCastException();
														}
													}
													throw new InvalidCastException();
												}
											}
											throw new InvalidCastException();
										}
										num27++;
										num28 = num29;
										continue;
									}
								}
								throw new InvalidCastException();
							}
						}
						throw new InvalidCastException();
					}
				}
			}
			else
			{
				world = this;
				int num43 = num4;
				nint num44 = (nint)typeof(PhaserArray);
				nint num45 = (nint)typeof(PhaserArray);
				while (true)
				{
					nint num46 = (nint)arcadeColliderType3;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v155 @ r8_v23 (Il2CppClass<PhaserArray>)+130]");
					object obj41 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v132 @ r9_v20 (Il2CppClass<ArcadeColliderType>)+130]");
					nint num47 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v155 @ r8_v23 (Il2CppClass<PhaserArray>)+130]");
					if (num47 >= 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v132 @ r9_v20 (Il2CppClass<ArcadeColliderType>)+C8]");
						object obj42 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1268 @ rax_v46+FFFFFFF8+v1156 @ rax_v45*8]");
						if (0 == num44)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v165 @ rdx_v29 (Il2CppClass<PhaserArray>)+130]");
							object obj43 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v132 @ r9_v20 (Il2CppClass<ArcadeColliderType>)+130]");
							nint num48 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v165 @ rdx_v29 (Il2CppClass<PhaserArray>)+130]");
							if (num48 >= 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v132 @ r9_v20 (Il2CppClass<ArcadeColliderType>)+C8]");
								object obj44 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1533 @ rax_v48+FFFFFFF8+v1441 @ rax_v47*8]");
								if (0 == num45)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v200 @ rsi_v18 (ArcadeColliderType)+10]");
									object obj45 = 0;
									int num49 = num43;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v175 @ rax_v49+18]");
									if ((nint)num49 >= (nint)0)
									{
										break;
									}
									World world5 = world;
									ArcadeColliderType object3 = arcadeColliderType;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v175 @ rax_v49+20+v142 @ rbx_v22 (System.Int32)*8]");
									bool flag12 = world5.collideHandler(object3, (ArcadeColliderType)0, collideCallback, processCallback2, callbackContext2, overlapOnly2);
									num43++;
									world = this;
									num44 = (nint)typeof(PhaserArray);
									num45 = (nint)typeof(PhaserArray);
									continue;
								}
							}
							throw new InvalidCastException();
						}
					}
					InvalidCastException ex = new InvalidCastException();
					return (byte)(int)ex != 0;
				}
			}
		}
		int num50 = world._total ^ world._total;
		int num51 = world._total & num50;
		bool flag13 = num51 < 0;
		bool flag14 = world._total < 0;
		bool flag15 = world._total == 0;
		bool flag16 = flag14 == flag13;
		bool flag17 = !flag15;
		return flag17 & flag16;
		IL_0d7b:
		bool flag18 = obj9 == null;
		num4 = 0;
		arcadeColliderType4 = null;
		if (!flag18)
		{
			num4 = 0;
			arcadeColliderType4 = arcadeColliderType;
		}
		goto IL_0d5b;
		IL_0116:
		bool flag19 = object2 == null;
		arcadeColliderType3 = object2;
		if (!flag19)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
			object obj46 = default(object);
			bool flag20 = obj46 == null;
			arcadeColliderType3 = object2;
			if (!flag20)
			{
				nint num52 = (nint)typeof(Group);
				nint num53 = (nint)object2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v461 @ rdx_v52 (Il2CppClass<Group>)+130]");
				object obj47 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v458 @ r8_v53 (Il2CppClass<ArcadeColliderType>)+130]");
				nint num54 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v461 @ rdx_v52 (Il2CppClass<Group>)+130]");
				if (num54 >= 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v458 @ r8_v53 (Il2CppClass<ArcadeColliderType>)+C8]");
					object obj48 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v464 @ rax_v106+FFFFFFF8+v543 @ rax_v105*8]");
					if (0 == (nint)typeof(Group))
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [object2 @ r8 (ArcadeColliderType)+30]");
						bool flag21 = (nint)0 != 2;
						arcadeColliderType3 = object2;
						if (!flag21)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [object2 @ r8 (ArcadeColliderType)+18]");
							PhaserArray phaserArray2 = new PhaserArray((HashSet<PhaserGameObject>)0);
							arcadeColliderType3 = phaserArray2;
						}
						goto IL_024c;
					}
				}
				throw new InvalidCastException();
			}
		}
		goto IL_024c;
	}

	private bool collideHandler(ArcadeColliderType object1, ArcadeColliderType object2, ArcadePhysicsCallback collideCallback, ArcadePhysicsCallback processCallback, CallbackContext callbackContext, bool overlapOnly)
	{
		//IL_0a38: Expected I, but got O
		//IL_0a40: Expected I, but got O
		//IL_0a50: Expected O, but got I
		//IL_0cd5: Expected I4, but got O
		//IL_0a8c: Expected O, but got I
		//IL_08f3: Expected I, but got O
		//IL_08fb: Expected I, but got O
		//IL_090b: Expected O, but got I
		//IL_05ee: Expected I, but got O
		//IL_05f6: Expected I, but got O
		//IL_0606: Expected O, but got I
		//IL_0ac1: Expected I, but got O
		//IL_0ad1: Expected O, but got I
		//IL_0947: Expected O, but got I
		//IL_0642: Expected O, but got I
		//IL_04b7: Expected I, but got O
		//IL_04bf: Expected I, but got O
		//IL_04cf: Expected O, but got I
		//IL_00ab: Expected I, but got O
		//IL_00b3: Expected I, but got O
		//IL_00c3: Expected O, but got I
		//IL_07ae: Expected I, but got O
		//IL_07b6: Expected I, but got O
		//IL_07c6: Expected O, but got I
		//IL_0b0d: Expected O, but got I
		//IL_0982: Expected I, but got O
		//IL_098a: Expected I, but got O
		//IL_099a: Expected O, but got I
		//IL_067d: Expected I, but got O
		//IL_0685: Expected I, but got O
		//IL_0695: Expected O, but got I
		//IL_050b: Expected O, but got I
		//IL_00ff: Expected O, but got I
		//IL_0802: Expected O, but got I
		//IL_0372: Expected I, but got O
		//IL_037a: Expected I, but got O
		//IL_038a: Expected O, but got I
		//IL_09d6: Expected O, but got I
		//IL_06d1: Expected O, but got I
		//IL_0540: Expected I, but got O
		//IL_0550: Expected O, but got I
		//IL_083d: Expected I, but got O
		//IL_0845: Expected I, but got O
		//IL_0855: Expected O, but got I
		//IL_03c6: Expected O, but got I
		//IL_0241: Expected I, but got O
		//IL_0249: Expected I, but got O
		//IL_0259: Expected O, but got I
		//IL_058c: Expected O, but got I
		//IL_0891: Expected O, but got I
		//IL_0401: Expected I, but got O
		//IL_0409: Expected I, but got O
		//IL_0419: Expected O, but got I
		//IL_0295: Expected O, but got I
		//IL_0bb2: Expected I4, but got O
		//IL_0bb2: Expected O, but got I
		//IL_0bb2: Expected O, but got I
		//IL_018b: Expected I, but got O
		//IL_0193: Expected I, but got O
		//IL_01a3: Expected O, but got I
		//IL_0455: Expected O, but got I
		//IL_01df: Expected O, but got I
		if (object1 != null && object2 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1809B54E0");
			object obj = default(object);
			ArcadePhysicsCallback arcadePhysicsCallback = default(ArcadePhysicsCallback);
			CallbackContext callbackContext2 = default(CallbackContext);
			bool overlapOnly2 = default(bool);
			if (obj == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
				object obj2 = default(object);
				if (obj2 == null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
					object obj3 = default(object);
					if (obj3 != null)
					{
						nint num = (nint)typeof(PhaserTilemap);
						nint num2 = (nint)object1;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v517 @ rdx_v40 (Il2CppClass<PhaserTilemap>)+130]");
						object obj4 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v518 @ r8_v45 (Il2CppClass<ArcadeColliderType>)+130]");
						nint num3 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v517 @ rdx_v40 (Il2CppClass<PhaserTilemap>)+130]");
						if (num3 >= 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v518 @ r8_v45 (Il2CppClass<ArcadeColliderType>)+C8]");
							object obj5 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v580 @ rax_v92+FFFFFFF8+v519 @ rax_v89*8]");
							if (0 == (nint)typeof(PhaserTilemap))
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1809B54E0");
								object obj6 = default(object);
								if (obj6 == null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
									object obj7 = default(object);
									if (obj7 != null)
									{
										nint num4 = (nint)typeof(Group);
										nint num5 = (nint)object2;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1025 @ rdx_v46 (Il2CppClass<Group>)+130]");
										object obj8 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1026 @ r8_v52 (Il2CppClass<ArcadeColliderType>)+130]");
										nint num6 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1025 @ rdx_v46 (Il2CppClass<Group>)+130]");
										if (num6 >= 0)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1026 @ r8_v52 (Il2CppClass<ArcadeColliderType>)+C8]");
											object obj9 = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1126 @ rax_v106+FFFFFFF8+v1085 @ rax_v103*8]");
											if (0 == (nint)typeof(Group))
											{
												return collideGroupVsTilemapLayer((Group)object2, (PhaserTilemap)object1, collideCallback, arcadePhysicsCallback, callbackContext2, overlapOnly2);
											}
										}
										throw new InvalidCastException();
									}
									goto IL_0bfb;
								}
								nint num7 = (nint)typeof(PhaserGameObject);
								nint num8 = (nint)object2;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v958 @ rdx_v43 (Il2CppClass<PhaserGameObject>)+130]");
								object obj10 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v959 @ r8_v49 (Il2CppClass<ArcadeColliderType>)+130]");
								nint num9 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v958 @ rdx_v43 (Il2CppClass<PhaserGameObject>)+130]");
								if (num9 >= 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v959 @ r8_v49 (Il2CppClass<ArcadeColliderType>)+C8]");
									object obj11 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1024 @ rax_v97+FFFFFFF8+v960 @ rax_v96*8]");
									if (0 == (nint)typeof(PhaserGameObject))
									{
										return collideSpriteVsTilemapLayer((PhaserGameObject)object2, (PhaserTilemap)object1, collideCallback, arcadePhysicsCallback, callbackContext2, overlapOnly2);
									}
								}
								throw new InvalidCastException();
							}
						}
						throw new InvalidCastException();
					}
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1809B54E0");
					object obj12 = default(object);
					if (obj12 != null)
					{
						nint num10 = (nint)typeof(PhysicsGroup);
						nint num11 = (nint)object1;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v536 @ rdx_v29 (Il2CppClass<PhysicsGroup>)+130]");
						object obj13 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v537 @ r8_v33 (Il2CppClass<ArcadeColliderType>)+130]");
						nint num12 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v536 @ rdx_v29 (Il2CppClass<PhysicsGroup>)+130]");
						if (num12 >= 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v537 @ r8_v33 (Il2CppClass<ArcadeColliderType>)+C8]");
							object obj14 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v635 @ rax_v63+FFFFFFF8+v538 @ rax_v62*8]");
							if (0 == (nint)typeof(PhysicsGroup))
							{
								nint num13 = (nint)typeof(PhaserGameObject);
								nint num14 = (nint)object2;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v753 @ rdx_v30 (Il2CppClass<PhaserGameObject>)+130]");
								object obj15 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v754 @ r8_v34 (Il2CppClass<ArcadeColliderType>)+130]");
								nint num15 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v753 @ rdx_v30 (Il2CppClass<PhaserGameObject>)+130]");
								if (num15 >= 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v754 @ r8_v34 (Il2CppClass<ArcadeColliderType>)+C8]");
									object obj16 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v888 @ rax_v65+FFFFFFF8+v755 @ rax_v64*8]");
									if (0 == (nint)typeof(PhaserGameObject))
									{
										return collideSpriteVsGroup((PhaserGameObject)object2, (PhysicsGroup)object1, collideCallback, arcadePhysicsCallback, callbackContext2, overlapOnly2);
									}
								}
								throw new InvalidCastException();
							}
						}
						throw new InvalidCastException();
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
					object obj17 = default(object);
					if (obj17 != null)
					{
						nint num16 = (nint)typeof(PhysicsGroup);
						nint num17 = (nint)object2;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v738 @ rdx_v33 (Il2CppClass<PhysicsGroup>)+130]");
						object obj18 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v739 @ r8_v37 (Il2CppClass<ArcadeColliderType>)+130]");
						nint num18 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v738 @ rdx_v33 (Il2CppClass<PhysicsGroup>)+130]");
						if (num18 >= 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v739 @ r8_v37 (Il2CppClass<ArcadeColliderType>)+C8]");
							object obj19 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v843 @ rax_v72+FFFFFFF8+v740 @ rax_v71*8]");
							if (0 == (nint)typeof(PhysicsGroup))
							{
								nint num19 = (nint)object1;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v738 @ rdx_v33 (Il2CppClass<PhysicsGroup>)+130]");
								object obj20 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v988 @ r8_v38 (Il2CppClass<ArcadeColliderType>)+130]");
								nint num20 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v738 @ rdx_v33 (Il2CppClass<PhysicsGroup>)+130]");
								if (num20 >= 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v988 @ r8_v38 (Il2CppClass<ArcadeColliderType>)+C8]");
									object obj21 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1072 @ rax_v74+FFFFFFF8+v989 @ rax_v73*8]");
									if (0 == (nint)typeof(PhysicsGroup))
									{
										return collideGroupVsGroup((PhysicsGroup)object1, (PhysicsGroup)object2, collideCallback, arcadePhysicsCallback, callbackContext2, overlapOnly2);
									}
								}
								throw new InvalidCastException();
							}
						}
						throw new InvalidCastException();
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
					object obj22 = default(object);
					if (obj22 != null)
					{
						nint num21 = (nint)typeof(PhaserTilemap);
						nint num22 = (nint)object2;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v973 @ rdx_v36 (Il2CppClass<PhaserTilemap>)+130]");
						object obj23 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v974 @ r8_v41 (Il2CppClass<ArcadeColliderType>)+130]");
						nint num23 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v973 @ rdx_v36 (Il2CppClass<PhaserTilemap>)+130]");
						if (num23 >= 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v974 @ r8_v41 (Il2CppClass<ArcadeColliderType>)+C8]");
							object obj24 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1045 @ rax_v81+FFFFFFF8+v975 @ rax_v80*8]");
							if (0 == (nint)typeof(PhaserTilemap))
							{
								nint num24 = (nint)typeof(Group);
								nint num25 = (nint)object1;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v809 @ rdx_v37 (Il2CppClass<Group>)+130]");
								object obj25 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v811 @ r8_v42 (Il2CppClass<ArcadeColliderType>)+130]");
								nint num26 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v809 @ rdx_v37 (Il2CppClass<Group>)+130]");
								if (num26 >= 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v811 @ r8_v42 (Il2CppClass<ArcadeColliderType>)+C8]");
									object obj26 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v814 @ rax_v83+FFFFFFF8+v813 @ rax_v82*8]");
									if (0 == (nint)typeof(Group))
									{
										return collideGroupVsTilemapLayer((Group)object1, (PhaserTilemap)object2, collideCallback, arcadePhysicsCallback, callbackContext2, overlapOnly2);
									}
								}
								throw new InvalidCastException();
							}
						}
						throw new InvalidCastException();
					}
				}
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1809B54E0");
				object obj27 = default(object);
				if (obj27 != null)
				{
					nint num27 = (nint)typeof(PhaserGameObject);
					nint num28 = (nint)object2;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ rdx_v9 (Il2CppClass<PhaserGameObject>)+130]");
					object obj28 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v452 @ r8_v11 (Il2CppClass<ArcadeColliderType>)+130]");
					nint num29 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ rdx_v9 (Il2CppClass<PhaserGameObject>)+130]");
					if (num29 >= 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v452 @ r8_v11 (Il2CppClass<ArcadeColliderType>)+C8]");
						object obj29 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v488 @ rax_v20+FFFFFFF8+v453 @ rax_v19*8]");
						if (0 == (nint)typeof(PhaserGameObject))
						{
							nint num30 = (nint)object1;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ rdx_v9 (Il2CppClass<PhaserGameObject>)+130]");
							object obj30 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v75 @ r8_v12 (Il2CppClass<ArcadeColliderType>)+130]");
							nint num31 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ rdx_v9 (Il2CppClass<PhaserGameObject>)+130]");
							if (num31 >= 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v75 @ r8_v12 (Il2CppClass<ArcadeColliderType>)+C8]");
								object obj31 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v81 @ rax_v22+FFFFFFF8+v566 @ rax_v21*8]");
								if (0 == (nint)typeof(PhaserGameObject))
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [object1 @ rdx (ArcadeColliderType)+28]");
									if ((nint)0 != 0)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [object2 @ r8 (ArcadeColliderType)+28]");
										if ((nint)0 != 0)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [object1 @ rdx (ArcadeColliderType)+28]");
											nint num32 = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [object2 @ r8 (ArcadeColliderType)+28]");
											ArcadePhysicsCallback processCallback2 = default(ArcadePhysicsCallback);
											if (separate((BaseBody)num32, (BaseBody)0, processCallback2, (CallbackContext)(object)arcadePhysicsCallback, (byte)(int)callbackContext2 != 0, overlapOnly2))
											{
												if (collideCallback != null)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: collideCallback.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
												}
												int total = _total + 1;
												_total = total;
											}
											return true;
										}
									}
									goto IL_0bfb;
								}
							}
							throw new InvalidCastException();
						}
					}
					InvalidCastException ex = new InvalidCastException();
					return (byte)(int)ex != 0;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
				object obj32 = default(object);
				if (obj32 != null)
				{
					nint num33 = (nint)typeof(PhysicsGroup);
					nint num34 = (nint)object2;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v551 @ rdx_v15 (Il2CppClass<PhysicsGroup>)+130]");
					object obj33 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v552 @ r8_v18 (Il2CppClass<ArcadeColliderType>)+130]");
					nint num35 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v551 @ rdx_v15 (Il2CppClass<PhysicsGroup>)+130]");
					if (num35 >= 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v552 @ r8_v18 (Il2CppClass<ArcadeColliderType>)+C8]");
						object obj34 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v680 @ rax_v32+FFFFFFF8+v553 @ rax_v31*8]");
						if (0 == (nint)typeof(PhysicsGroup))
						{
							nint num36 = (nint)typeof(PhaserGameObject);
							nint num37 = (nint)object1;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v783 @ rdx_v16 (Il2CppClass<PhaserGameObject>)+130]");
							object obj35 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v784 @ r8_v19 (Il2CppClass<ArcadeColliderType>)+130]");
							nint num38 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v783 @ rdx_v16 (Il2CppClass<PhaserGameObject>)+130]");
							if (num38 >= 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v784 @ r8_v19 (Il2CppClass<ArcadeColliderType>)+C8]");
								object obj36 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v955 @ rax_v34+FFFFFFF8+v785 @ rax_v33*8]");
								if (0 == (nint)typeof(PhaserGameObject))
								{
									return collideSpriteVsGroup((PhaserGameObject)object1, (PhysicsGroup)object2, collideCallback, arcadePhysicsCallback, callbackContext2, overlapOnly2);
								}
							}
							throw new InvalidCastException();
						}
					}
					throw new InvalidCastException();
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
				object obj37 = default(object);
				if (obj37 != null)
				{
					nint num39 = (nint)typeof(PhaserTilemap);
					nint num40 = (nint)object2;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v768 @ rdx_v19 (Il2CppClass<PhaserTilemap>)+130]");
					object obj38 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v769 @ r8_v22 (Il2CppClass<ArcadeColliderType>)+130]");
					nint num41 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v768 @ rdx_v19 (Il2CppClass<PhaserTilemap>)+130]");
					if (num41 >= 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v769 @ r8_v22 (Il2CppClass<ArcadeColliderType>)+C8]");
						object obj39 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v925 @ rax_v41+FFFFFFF8+v770 @ rax_v40*8]");
						if (0 == (nint)typeof(PhaserTilemap))
						{
							nint num42 = (nint)typeof(PhaserGameObject);
							nint num43 = (nint)object1;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v892 @ rdx_v20 (Il2CppClass<PhaserGameObject>)+130]");
							object obj40 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v894 @ r8_v23 (Il2CppClass<ArcadeColliderType>)+130]");
							nint num44 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v892 @ rdx_v20 (Il2CppClass<PhaserGameObject>)+130]");
							if (num44 >= 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v894 @ r8_v23 (Il2CppClass<ArcadeColliderType>)+C8]");
								object obj41 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v897 @ rax_v43+FFFFFFF8+v896 @ rax_v42*8]");
								if (0 == (nint)typeof(PhaserGameObject))
								{
									return collideSpriteVsTilemapLayer((PhaserGameObject)object1, (PhaserTilemap)object2, collideCallback, arcadePhysicsCallback, callbackContext2, overlapOnly2);
								}
							}
							throw new InvalidCastException();
						}
					}
					throw new InvalidCastException();
				}
			}
		}
		goto IL_0bfb;
		IL_0bfb:
		return false;
	}

	private bool collideSpriteVsSprite(PhaserGameObject sprite1, PhaserGameObject sprite2, ArcadePhysicsCallback collideCallback, ArcadePhysicsCallback processCallback, CallbackContext callbackContext, bool overlapOnly)
	{
		//IL_010b: Expected I4, but got O
		if ((object)sprite1 != null)
		{
			if (sprite1.body != null)
			{
				if ((object)sprite2 == null)
				{
					goto IL_00fd;
				}
				if (sprite2.body != null)
				{
					ArcadePhysicsCallback processCallback2 = default(ArcadePhysicsCallback);
					CallbackContext callbackContext2 = default(CallbackContext);
					bool overlapOnly2 = default(bool);
					bool flag = default(bool);
					if (separate(sprite1.body, sprite2.body, processCallback2, callbackContext2, overlapOnly2, flag))
					{
						if (collideCallback != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: collideCallback.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
						}
						int total = _total + 1;
						_total = total;
					}
					return true;
				}
			}
			return false;
		}
		goto IL_00fd;
		IL_00fd:
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	private unsafe bool collideSpriteVsGroup(PhaserGameObject sprite, PhysicsGroup group, ArcadePhysicsCallback collideCallback, ArcadePhysicsCallback processCallback, CallbackContext callbackContext, bool overlapOnly)
	{
		//IL_0116: Expected O, but got I4
		//IL_011e: Expected O, but got Ref
		//IL_030f: Expected O, but got I4
		//IL_05a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_05a6: Expected O, but got Unknown
		if ((object)sprite != null)
		{
			RBush.IRectangular body = sprite.body;
			if (group != null)
			{
				HashSet<PhaserGameObject> children = ((Group)group).children;
				if (((Group)group).children != null)
				{
					if (children._count != 0 && sprite.body != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ r12_v5 (RBush+IRectangular)+40]");
						if ((nint)0 != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ r12_v5 (RBush+IRectangular)+98]");
							if ((nint)0 != 0)
							{
								if (_useTree || group._physicsType == PhysicsType.STATIC_BODY)
								{
									RBush rBush;
									if (group._physicsType == PhysicsType.DYNAMIC_BODY)
									{
										if (_groupRTrees == null)
										{
											goto IL_049a;
										}
										rBush = _groupRTrees.get_Item((Group)group);
									}
									else
									{
										rBush = _staticTree;
									}
									if (rBush != null)
									{
										List<BaseBody> list = rBush.search(sprite.body);
										if (list != null)
										{
											if (list._size <= 0)
											{
												goto IL_0494;
											}
											object obj = 0;
											ArcadePhysicsCallback processCallback2 = default(ArcadePhysicsCallback);
											CallbackContext callbackContext2 = default(CallbackContext);
											bool overlapOnly2 = default(bool);
											bool flag = default(bool);
											bool result = default(bool);
											while (true)
											{
												if ((nint)obj < list._size)
												{
													BaseBody[] items = list._items;
													if (list._items == null)
													{
														break;
													}
													BaseBody baseBody = items[obj];
													if (sprite.body != items[obj])
													{
														if (items[obj] == null)
														{
															break;
														}
														if (baseBody._enable && (object)baseBody._checkCollision != null && group.contains(baseBody._gameObject) && separate(sprite.body, items[obj], processCallback2, callbackContext2, overlapOnly2, flag))
														{
															if (collideCallback != null)
															{
																Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: collideCallback.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
															}
															int total = _total + 1;
															_total = total;
														}
													}
													obj++;
													if ((nint)obj < list._size)
													{
														continue;
													}
													goto IL_0494;
												}
												System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
												return result;
											}
										}
									}
									goto IL_049a;
								}
								HashSet<object>.Enumerator enumerator = default(HashSet<object>.Enumerator);
								if (enumerator.MoveNext())
								{
									object obj2 = 0;
									HashSet<object>.Enumerator enumerator2 = (HashSet<object>.Enumerator)(&enumerator);
									throw new NullReferenceException();
								}
							}
						}
					}
					goto IL_0494;
				}
			}
		}
		goto IL_049a;
		IL_0494:
		return false;
		IL_049a:
		throw new NullReferenceException();
	}

	private unsafe bool collideGroupVsTilemapLayer(Group group, PhaserTilemap tilemapLayer, ArcadePhysicsCallback collideCallback, ArcadePhysicsCallback processCallback, CallbackContext callbackContext, bool overlapOnly)
	{
		//IL_004c: Expected O, but got Ref
		if (group != null)
		{
			HashSet<PhaserGameObject> children = group.children;
			if (group.children != null)
			{
				if (children._count != 0)
				{
					bool result = false;
					HashSet<object>.Enumerator enumerator = default(HashSet<object>.Enumerator);
					if (enumerator.MoveNext())
					{
						PhaserGameObject phaserGameObject = null;
						HashSet<object>.Enumerator enumerator2 = (HashSet<object>.Enumerator)(&enumerator);
						throw new NullReferenceException();
					}
					return result;
				}
				return false;
			}
		}
		throw new NullReferenceException();
	}

	public unsafe bool collideSpriteVsTilemapLayer(PhaserGameObject sprite, PhaserTilemap tilemap, ArcadePhysicsCallback collideCallback, ArcadePhysicsCallback processCallback, CallbackContext callbackContext, bool overlapOnly)
	{
		//IL_0331: Expected I, but got O
		//IL_0146: Invalid comparison between O and F4
		//IL_016f: Invalid comparison between F4 and I
		//IL_0198: Invalid comparison between I and F4
		//IL_01c1: Invalid comparison between F4 and I
		//IL_01de: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e3: Expected O, but got Unknown
		//IL_01f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fb: Expected O, but got Unknown
		//IL_0218: Expected O, but got I
		//IL_023a: Expected O, but got Ref
		//IL_02a5: Expected I4, but got O
		//IL_02a5: Expected I4, but got O
		//IL_02a5: Expected O, but got I4
		//IL_02a5: Expected O, but got Ref
		if ((object)s_spriteVsTilemapMarker != null)
		{
			ProfilerUnsafeUtility.BeginSample((IntPtr)s_spriteVsTilemapMarker);
		}
		bool flag = (object)sprite == null;
		BaseBody body = sprite.body;
		bool flag2 = sprite.body == null;
		ProfilerMarker.AutoScope autoScope = default(ProfilerMarker.AutoScope);
		if (body._enable && (object)body._checkCollision != null)
		{
			if ((object)tilemap != null && ((UnityEngine.Object)tilemap).m_CachedPtr != (IntPtr)0)
			{
				Tilemap layer = tilemap._layer;
				if ((object)tilemap._layer != null && ((UnityEngine.Object)layer).m_CachedPtr != (IntPtr)0 && tilemap.active)
				{
					if (System.Runtime.CompilerServices.Unsafe.As<float4, UIntPtr>(ref tilemap._worldBounds) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)body.MaxX))
					{
						float minX = body.MinX;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [tilemap @ r8 (PhaserTilemap)+88]");
						if (!(minX > 0f))
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [tilemap @ r8 (PhaserTilemap)+84]");
							if (!(0f > body.MaxY))
							{
								float minY = body.MinY;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [tilemap @ r8 (PhaserTilemap)+8C]");
								if (!(minY > 0f))
								{
									object obj = tilemap + 192;
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185003D10");
									object obj2 = tilemap + 192;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v140 @ rdi_v3 (BaseBody)+54]");
									nint num = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v140 @ rdi_v3 (BaseBody)+5C]");
									object obj3 = num + 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185003D10");
									object obj4 = default(object);
									int tilesInBounds = tilemap.GetTilesInBounds((BoundsInt)(&obj4), _tileCache);
									if (tilesInBounds == 0)
									{
										autoScope.Dispose();
										return false;
									}
									int tilesCount = default(int);
									PhaserTilemap tilemapLayer = default(PhaserTilemap);
									ArcadePhysicsCallback collideCallback2 = default(ArcadePhysicsCallback);
									ArcadePhysicsCallback processCallback2 = default(ArcadePhysicsCallback);
									bool result = collideSpriteVsTilesHandler(sprite, (BoundsInt)(&obj4), _tileCache, tilesCount, tilemapLayer, collideCallback2, processCallback2, (CallbackContext)tilesInBounds, (byte)(int)tilemap != 0, (byte)(int)collideCallback != 0);
									autoScope.Dispose();
									return result;
								}
							}
						}
					}
					autoScope.Dispose();
					return false;
				}
			}
			autoScope.Dispose();
			return false;
		}
		autoScope.Dispose();
		return false;
	}

	public unsafe void collideSpriteVsTilemapLayerFast(PhaserGameObject sprite, PhaserTilemap tilemap, ArcadePhysicsCallback collideCallback, ArcadePhysicsCallback processCallback, CallbackContext callbackContext, bool overlapOnly)
	{
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		//IL_0151: Expected I, but got O
		//IL_0088: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Expected O, but got Unknown
		//IL_00aa: Expected O, but got I
		//IL_00cc: Expected O, but got Ref
		//IL_011e: Expected I4, but got O
		//IL_011e: Expected I4, but got O
		//IL_011e: Expected O, but got I4
		//IL_011e: Expected O, but got Ref
		if ((object)s_spriteVsTilemapFastMarker != null)
		{
			ProfilerUnsafeUtility.BeginSample((IntPtr)s_spriteVsTilemapFastMarker);
		}
		bool flag = (object)sprite == null;
		BaseBody body = sprite.body;
		bool flag2 = (object)tilemap == null;
		World world = (World)(tilemap + 192);
		bool flag3 = sprite.body == null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185003D10");
		object obj = tilemap + 192;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v136 @ rdi_v3 (BaseBody)+54]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v136 @ rdi_v3 (BaseBody)+5C]");
		object obj2 = num + 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185003D10");
		object obj3 = default(object);
		int tilesInBounds = tilemap.GetTilesInBounds((BoundsInt)(&obj3), _tileCache);
		if (tilesInBounds != 0)
		{
			int tilesCount = default(int);
			PhaserTilemap tilemapLayer = default(PhaserTilemap);
			ArcadePhysicsCallback collideCallback2 = default(ArcadePhysicsCallback);
			ArcadePhysicsCallback processCallback2 = default(ArcadePhysicsCallback);
			bool flag4 = collideSpriteVsTilesHandler(sprite, (BoundsInt)(&obj3), _tileCache, tilesCount, tilemapLayer, collideCallback2, processCallback2, (CallbackContext)tilesInBounds, (byte)(int)tilemap != 0, (byte)(int)collideCallback != 0);
		}
		ProfilerMarker.AutoScope autoScope = default(ProfilerMarker.AutoScope);
		autoScope.Dispose();
	}

	private unsafe bool collideSpriteVsTilesHandler(PhaserGameObject sprite, BoundsInt bounds, PhaserTile[] tiles, int tilesCount, PhaserTilemap tilemapLayer, ArcadePhysicsCallback collideCallback, ArcadePhysicsCallback processCallback, CallbackContext callbackContext, bool overlapOnly, bool isLayer)
	{
		//IL_0057: Expected I, but got O
		//IL_006f: Expected O, but got I
		//IL_00f3: Expected O, but got I4
		//IL_00e5: Expected O, but got I4
		//IL_0121: Expected O, but got I4
		//IL_0152: Expected O, but got I
		//IL_0184: Expected O, but got I4
		//IL_018d: Expected O, but got I4
		//IL_026a: Unknown result type (might be due to invalid IL or missing references)
		//IL_026f: Expected O, but got Unknown
		//IL_027f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0284: Expected O, but got Unknown
		//IL_0294: Unknown result type (might be due to invalid IL or missing references)
		//IL_0299: Expected O, but got Unknown
		//IL_02a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ae: Expected O, but got Unknown
		//IL_02df: Expected O, but got I4
		//IL_02f1: Invalid comparison between O and F4
		//IL_0315: Invalid comparison between O and F4
		//IL_036d: Expected F4, but got I
		//IL_040a: Expected O, but got I4
		//IL_0412: Expected O, but got I4
		//IL_0427: Expected O, but got I4
		//IL_043c: Expected O, but got I4
		//IL_050e: Expected O, but got I4
		//IL_0529: Expected O, but got I4
		//IL_0531: Expected O, but got Ref
		//IL_0562: Expected O, but got I4
		//IL_057d: Expected O, but got I4
		//IL_0585: Expected O, but got Ref
		//IL_0615: Expected O, but got I
		//IL_06d7: Expected O, but got I4
		//IL_065e: Expected O, but got I4
		//IL_01c8->IL06fe: Incompatible stack heights: 1 vs 0
		//IL_022e->IL06fe: Incompatible stack heights: 2 vs 0
		//IL_07f3->IL06fe: Incompatible stack heights: 2 vs 0
		//IL_0825->IL08b8: Incompatible stack heights: 2 vs 1
		//IL_082a->IL06f9: Incompatible stack heights: 2 vs 1
		if ((object)sprite == null)
		{
			goto IL_06fe;
		}
		BaseBody body = sprite.body;
		PhaserTile[] array;
		Body body2;
		if (sprite.body == null)
		{
			array = tiles;
			body2 = null;
			goto IL_0722;
		}
		nint num = (nint)typeof(Body);
		array = (PhaserTile[])(object)body;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v239 @ r8_v17 (Il2CppClass<Body>)+130]");
		object obj = 0;
		PhaserTile phaserTile = array[34];
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v239 @ r8_v17 (Il2CppClass<Body>)+130]");
		object obj2;
		if ((nint)phaserTile >= 0)
		{
			PhaserTile phaserTile2 = array[21];
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v281 @ rax_v43 (PhaserTile)+FFFFFFF8+v241 @ rax_v39*8]");
			if (0 == (nint)typeof(Body))
			{
				obj2 = 1;
				goto IL_073f;
			}
		}
		obj2 = 0;
		goto IL_073f;
		IL_06fe:
		throw new NullReferenceException();
		IL_06f9:
		bool result;
		return result;
		IL_0722:
		BoundsInt boundsInt = default(BoundsInt);
		if (isLayer)
		{
			int num2 = (int)(nint)((Delegate)isLayer).interp_method;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [isLayer @ stack_30 (ArcadePhysicsCallback)+C8]");
			bool flag = (nint)0 < (nint)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [isLayer @ stack_30 (ArcadePhysicsCallback)+C8]");
			object obj3 = -0;
			bool flag2 = obj3 == null;
			bool flag3 = !flag;
			bool flag4 = !flag2;
			object obj4 = flag4 & flag3;
			if (((Delegate)isLayer).interp_method != (IntPtr)0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v147 @ rdi_v5 (System.Int32)+10]");
				bool flag5 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v147 @ rdi_v5 (System.Int32)+10]");
				GridLayout.get_cellSize_Injected((IntPtr)0, out Vector3 ret);
				bool flag6 = (overlapOnly ? 1 : 0) <= (false ? 1 : 0);
				result = false;
				if (flag6)
				{
					goto IL_06f9;
				}
				if (tiles != null)
				{
					bool flag7 = false;
					object obj5 = ret;
					object obj7 = default(object);
					object obj6 = obj7;
					int num3 = 0;
					PhaserTile[] array2 = tiles;
					World world = default(World);
					PhaserScene phaserScene = default(PhaserScene);
					object obj17 = default(object);
					Body body3 = default(Body);
					object obj18 = default(object);
					ArcadePhysicsCallback arcadePhysicsCallback3 = default(ArcadePhysicsCallback);
					float num6 = default(float);
					object obj22 = default(object);
					object obj24 = default(object);
					ref ArcadeRect tileWorldRect = default(ref ArcadeRect);
					PhaserTilemap tilemapLayer2 = default(PhaserTilemap);
					float tileBias = default(float);
					bool isLayer2 = default(bool);
					object obj25 = default(object);
					object obj26 = default(object);
					IntPtr intPtr = default(IntPtr);
					while (true)
					{
						bool flag8 = num3 >= array2.Length;
						PhaserTile phaserTile3 = array2[num3];
						if (array2[num3] == null)
						{
							break;
						}
						object obj8 = (object)phaserTile3.position >> 32;
						bool flag9 = obj4 == null;
						int2 position = phaserTile3.position;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [isLayer @ stack_30 (ArcadePhysicsCallback)+C8]");
						object obj9 = position * 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [isLayer @ stack_30 (ArcadePhysicsCallback)+C0]");
						object obj10 = obj9 + 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [isLayer @ stack_30 (ArcadePhysicsCallback)+CC]");
						object obj11 = obj8 * 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [isLayer @ stack_30 (ArcadePhysicsCallback)+C4]");
						object obj12 = obj11 + 0;
						object obj13;
						if (!flag9)
						{
							obj10 -= obj5;
							obj13 = obj6;
						}
						else
						{
							obj13 = 0;
						}
						object obj14 = obj12 - obj13;
						if (body2 == null)
						{
							break;
						}
						Body body4;
						PhaserScene phaserScene2;
						if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj10) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)body2.MaxX) && System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj14) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)body2.MaxY))
						{
							object obj15 = obj10 + obj5;
							float2 position2 = body2._position;
							if (System.Runtime.CompilerServices.Unsafe.As<float2, UIntPtr>(ref position2) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj15))
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v157 @ rbx_v5 (Body)+54]");
								float num4 = 0f;
								object obj16 = obj14 + obj6;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v157 @ rbx_v5 (Body)+54]");
								if (0 < (nint)obj16)
								{
									bool flag10 = world == null;
									ArcadePhysicsCallback arcadePhysicsCallback = (ArcadePhysicsCallback)(object)array;
									PhaserGameObject phaserGameObject = (PhaserGameObject)boundsInt;
									if (!flag10)
									{
										phaserScene = world._scene;
										Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v805._scene (PhaserScene) (should have been resolved before IL gen)");
										bool flag11 = obj17 == null;
										body3 = (Body)world._iteratingOverBodies;
										arcadePhysicsCallback = (ArcadePhysicsCallback)isLayer;
										phaserGameObject = sprite;
										body4 = (Body)world._iteratingOverBodies;
										phaserScene2 = world._scene;
										array = (PhaserTile[])isLayer;
										boundsInt = (BoundsInt)sprite;
										if (flag11)
										{
											goto IL_06dc;
										}
									}
									bool flag12 = obj18 != null;
									object obj19 = obj5;
									object obj20 = obj6;
									ArcadePhysicsCallback arcadePhysicsCallback2 = arcadePhysicsCallback3;
									float num5 = num6;
									object obj21 = obj22;
									object obj23 = obj24;
									PhaserTile phaserTile4 = (PhaserTile)(object)arcadePhysicsCallback;
									Body body5 = (Body)(object)phaserGameObject;
									if (!flag12)
									{
										num4 = TILE_BIAS;
										bool flag13 = SeparateTile(num3, body2, array2[num3], ref tileWorldRect, tilemapLayer2, tileBias, isLayer2);
										bool flag14 = !flag13;
										obj19 = ret;
										obj20 = obj7;
										arcadePhysicsCallback2 = (ArcadePhysicsCallback)isLayer;
										num5 = TILE_BIAS;
										obj21 = obj25;
										obj23 = 0;
										body3 = (Body)(&obj26);
										phaserTile4 = array2[num3];
										body5 = body2;
										obj5 = ret;
										obj6 = obj7;
										arcadePhysicsCallback3 = (ArcadePhysicsCallback)isLayer;
										num6 = TILE_BIAS;
										obj22 = obj25;
										obj24 = 0;
										body4 = (Body)(&obj26);
										phaserScene2 = phaserScene;
										array = (PhaserTile[])(object)array2[num3];
										boundsInt = (BoundsInt)body2;
										if (flag14)
										{
											goto IL_06dc;
										}
									}
									int total = _total + 1;
									_total = total;
									bool flag15 = intPtr == (IntPtr)0;
									array = (PhaserTile[])(object)phaserTile4;
									boundsInt = (BoundsInt)body5;
									if (!flag15)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [methodInfo @ stack_38 (Il2CppMethodInfo)+18] (should have been resolved before IL gen)");
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [methodInfo @ stack_38 (Il2CppMethodInfo)+28]");
										body3 = (Body)0;
										array = (PhaserTile[])(object)array2[num3];
										boundsInt = (BoundsInt)sprite;
									}
									if (obj18 != null && body2._onOverlap)
									{
										object obj27 = 7;
									}
									else
									{
										bool flag16 = !body2._onCollide;
										flag7 = true;
										obj5 = obj19;
										obj6 = obj20;
										arcadePhysicsCallback3 = arcadePhysicsCallback2;
										num6 = num5;
										obj22 = obj21;
										obj24 = obj23;
										body4 = body3;
										phaserScene2 = phaserScene;
										if (flag16)
										{
											goto IL_06dc;
										}
										object obj27 = 8;
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1809B45C0");
									flag7 = true;
									obj5 = obj19;
									obj6 = obj20;
									arcadePhysicsCallback3 = arcadePhysicsCallback2;
									num6 = num5;
									obj22 = obj21;
									obj24 = obj23;
									body4 = body2;
									phaserScene2 = phaserScene;
									array = (PhaserTile[])(object)array2[num3];
									boundsInt = (BoundsInt)sprite;
									goto IL_06dc;
								}
							}
						}
						goto IL_07f8;
						IL_06dc:
						body3 = body4;
						phaserScene = phaserScene2;
						array2 = tiles;
						goto IL_07f8;
						IL_07f8:
						num3++;
						bool flag17 = num3 < (overlapOnly ? 1 : 0);
						result = flag7;
						if (flag17)
						{
							continue;
						}
						goto IL_06f9;
					}
				}
			}
		}
		goto IL_06fe;
		IL_073f:
		bool flag18 = obj2 == null;
		boundsInt = (BoundsInt)typeof(Body);
		body2 = null;
		if (!flag18)
		{
			boundsInt = (BoundsInt)typeof(Body);
			body2 = (Body)sprite.body;
		}
		goto IL_0722;
	}

	private bool SeparateTile(int i, Body body, PhaserTile tile, ref ArcadeRect tileWorldRect, PhaserTilemap tilemapLayer, float tileBias, bool isLayer)
	{
		//IL_0096: Expected O, but got I4
		//IL_009e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Expected O, but got Unknown
		//IL_0812: Expected I, but got O
		//IL_0862: Expected O, but got I4
		//IL_086a: Unknown result type (might be due to invalid IL or missing references)
		//IL_086f: Expected O, but got Unknown
		//IL_0162: Expected O, but got I4
		//IL_013a: Expected O, but got I4
		//IL_018a: Expected O, but got I4
		//IL_08ba: Invalid comparison between F4 and I4
		//IL_023b: Expected F4, but got I4
		//IL_028f: Invalid comparison between F4 and I4
		//IL_08d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_08de: Expected O, but got Unknown
		//IL_025b: Expected F4, but got I4
		//IL_02bb: Expected O, but got I4
		//IL_05ab: Expected F4, but got I4
		//IL_02e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e6: Expected F4, but got Unknown
		//IL_0319: Unknown result type (might be due to invalid IL or missing references)
		//IL_031e: Expected F4, but got Unknown
		//IL_032b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0330: Expected O, but got Unknown
		//IL_071a: Expected F4, but got I4
		//IL_03e1: Expected F4, but got I4
		//IL_09ef: Invalid comparison between F4 and I4
		//IL_05d6: Expected F4, but got O
		//IL_05e3: Invalid comparison between F4 and I4
		//IL_074d: Expected F4, but got I
		//IL_076f: Invalid comparison between F4 and I4
		//IL_0414: Expected F4, but got I
		//IL_0421: Invalid comparison between F4 and I4
		//IL_0939: Unknown result type (might be due to invalid IL or missing references)
		//IL_093e: Expected F4, but got Unknown
		//IL_095b: Expected O, but got I
		//IL_097f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0984: Expected F4, but got Unknown
		//IL_0991: Unknown result type (might be due to invalid IL or missing references)
		//IL_0996: Expected O, but got Unknown
		//IL_061e: Invalid comparison between O and F4
		//IL_057a: Expected F4, but got O
		//IL_045c: Invalid comparison between O and F4
		//IL_064a: Invalid comparison between I and F4
		//IL_0488: Invalid comparison between I and F4
		//IL_0671: Unknown result type (might be due to invalid IL or missing references)
		//IL_0676: Expected O, but got Unknown
		//IL_04af: Unknown result type (might be due to invalid IL or missing references)
		//IL_04b4: Expected O, but got Unknown
		//IL_06b7: Expected O, but got I
		//IL_04f5: Expected O, but got I
		//IL_0a1c->IL089d: Incompatible stack heights: 2 vs 1
		//IL_0702->IL089d: Incompatible stack heights: 2 vs 1
		//IL_0540->IL089d: Incompatible stack heights: 2 vs 1
		if ((object)s_separateTileMarker != null)
		{
			ProfilerUnsafeUtility.BeginSample((IntPtr)s_separateTileMarker);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v123 @ stack_28+8]");
		object obj = default(object);
		float num = 0f + (float)obj;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v123 @ stack_28+C]");
		float num2 = 0f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v123 @ stack_28+4]");
		float num3 = num2 + 0f;
		bool flag = tile == null;
		int num4 = tile._data & 4;
		bool flag2 = num4 == 0;
		bool flag3 = num4 < 0;
		bool flag4 = !flag3;
		object obj2 = !flag4;
		object obj3 = obj2 | flag2;
		bool flag5;
		if (obj3 == null)
		{
			flag5 = true;
		}
		else
		{
			int num5 = tile._data & 8;
			bool flag6 = num5 == 0;
			flag5 = !flag6;
		}
		int num6 = tile._data & 1;
		bool flag7 = num6 == 0;
		bool flag8 = num6 < 0;
		bool flag9 = !flag8;
		object obj4 = !flag9;
		object obj5 = obj4 | flag7;
		bool flag10;
		if (obj5 == null)
		{
			flag10 = true;
		}
		else
		{
			int num7 = tile._data & 2;
			bool flag11 = num7 == 0;
			flag10 = !flag11;
		}
		object obj6 = default(object);
		object obj7;
		ProfilerMarker.AutoScope autoScope = default(ProfilerMarker.AutoScope);
		bool result;
		if (obj6 == null)
		{
			obj7 = 1;
			flag5 = true;
		}
		else
		{
			bool flag12 = flag5;
			obj7 = flag10;
			if (!flag12)
			{
				bool flag13 = flag10;
				obj7 = flag10;
				if (!flag13)
				{
					autoScope.Dispose();
					result = false;
					goto IL_089d;
				}
			}
		}
		bool flag14 = body == null;
		float num8 = body.deltaAbsX();
		float num9 = body.deltaAbsY();
		object obj8 = default(object);
		float num12;
		float num13;
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj8) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj8))
		{
			float num10 = body.deltaAbsX();
			float num11 = body.deltaAbsY();
			bool flag15 = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj8) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj8);
			num12 = 1f;
			num13 = 0f;
			if (!flag15)
			{
				num12 = -1f;
				num13 = 0f;
			}
		}
		else
		{
			num12 = 1f;
			num13 = -1f;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 000000018500C3F6h\"");
		PhaserTile phaserTile;
		if (body._dx == 0f)
		{
			phaserTile = null;
		}
		else
		{
			bool flag16 = body._dy == 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 000000018500C407h\"");
			phaserTile = null;
			if (!flag16)
			{
				phaserTile = (PhaserTile)1;
			}
		}
		object obj9 = obj7 & flag5;
		object obj10 = (object)phaserTile & obj9;
		if (obj10 != null)
		{
			float num14 = (float)body._position - num;
			float num15 = num14 & -2147483649L;
			object obj11 = body._size + body._position;
			float num16 = (float)obj11 - (float)obj;
			float num17 = num16 & -2147483649L;
			object obj12 = num17 & -2147483649L;
			float num18;
			if ((nint)obj12 <= 2139095040)
			{
				bool flag17 = num17 > num15;
				num18 = num15;
				if (!flag17)
				{
					num13 = num17;
					goto IL_0915;
				}
			}
			else
			{
				num18 = num15;
			}
			num13 = num18;
			goto IL_0915;
		}
		goto IL_09c0;
		IL_0702:
		bool flag18 = obj7 == null;
		float num19 = 0f;
		float tileBias2 = default(float);
		bool isLayer2 = default(bool);
		if (!flag18)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v123 @ stack_28+4]");
			float num20 = MathUtils.TileCheckY(body, tile, 0f, num3, tileBias2, isLayer2);
			phaserTile = tile;
			num19 = num20;
		}
		goto IL_09dc;
		IL_0915:
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [body @ r8 (Body)+54]");
		float num21 = 0f - num3;
		float num22 = num21 & -2147483649L;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [body @ r8 (Body)+5C]");
		nint num23 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [body @ r8 (Body)+54]");
		object obj13 = num23 + 0;
		float num24 = (float)obj13;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v123 @ stack_28+4]");
		float num25 = num24 - 0f;
		float num26 = num25 & -2147483649L;
		object obj14 = num26 & -2147483649L;
		float num27;
		if ((nint)obj14 <= 2139095040)
		{
			bool flag19 = num26 > num22;
			num27 = num22;
			if (!flag19)
			{
				num12 = num26;
				goto IL_09c0;
			}
		}
		else
		{
			num27 = num22;
		}
		num12 = num27;
		goto IL_09c0;
		IL_09c0:
		if (!(num12 > num13))
		{
			bool flag20 = obj7 == null;
			num19 = 0f;
			if (!flag20)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v123 @ stack_28+4]");
				float num28 = MathUtils.TileCheckY(body, tile, 0f, num3, tileBias2, isLayer2);
				bool flag21 = num28 == 0f;
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 000000018500C510h\"");
				phaserTile = tile;
				num19 = num28;
				if (!flag21)
				{
					if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)body.MaxX))
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v123 @ stack_28+4]");
						if (0f < body.MaxY)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v123 @ stack_28+8]");
							object obj15 = 0 + obj;
							float2 position = body._position;
							if (System.Runtime.CompilerServices.Unsafe.As<float2, UIntPtr>(ref position) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj15))
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v123 @ stack_28+C]");
								nint num29 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v123 @ stack_28+4]");
								object obj16 = num29 + 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [body @ r8 (Body)+54]");
								bool flag22 = 0 < (nint)obj16;
								phaserTile = tile;
								num19 = num28;
								if (flag22)
								{
									goto IL_0540;
								}
							}
						}
					}
					autoScope.Dispose();
					result = true;
					goto IL_089d;
				}
			}
			goto IL_0540;
		}
		bool flag23 = !flag5;
		float num30 = 0f;
		if (!flag23)
		{
			float num31 = MathUtils.TileCheckX(body, tile, (float)obj, num, tileBias2, isLayer2);
			bool flag24 = num31 == 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 000000018500C5C9h\"");
			phaserTile = tile;
			num30 = num31;
			if (!flag24)
			{
				if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)body.MaxX))
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v123 @ stack_28+4]");
					if (0f < body.MaxY)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v123 @ stack_28+8]");
						object obj17 = 0 + obj;
						float2 position2 = body._position;
						if (System.Runtime.CompilerServices.Unsafe.As<float2, UIntPtr>(ref position2) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj17))
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v123 @ stack_28+C]");
							nint num32 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v123 @ stack_28+4]");
							object obj18 = num32 + 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [body @ r8 (Body)+54]");
							bool flag25 = 0 < (nint)obj18;
							phaserTile = tile;
							num30 = num31;
							if (flag25)
							{
								goto IL_0702;
							}
						}
					}
				}
				autoScope.Dispose();
				result = true;
				goto IL_089d;
			}
		}
		goto IL_0702;
		IL_0a0e:
		autoScope.Dispose();
		goto IL_089d;
		IL_079e:
		PhaserTile phaserTile2;
		phaserTile = phaserTile2;
		result = true;
		goto IL_0a0e;
		IL_0540:
		if (!flag5)
		{
			goto IL_0766;
		}
		float num33 = MathUtils.TileCheckX(body, tile, (float)obj, num, tileBias2, isLayer2);
		phaserTile = tile;
		num30 = num33;
		goto IL_09dc;
		IL_09dc:
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 000000018500C653h\"");
		bool flag26 = num30 != 0f;
		phaserTile2 = phaserTile;
		if (!flag26)
		{
			goto IL_0766;
		}
		goto IL_079e;
		IL_0766:
		bool flag27 = num19 == 0f;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 000000018500C653h\"");
		phaserTile2 = phaserTile;
		result = false;
		if (!flag27)
		{
			goto IL_079e;
		}
		goto IL_0a0e;
		IL_089d:
		return result;
	}

	[MethodImpl((MethodImplOptions)256)]
	private bool TileIntersectsBody(ref ArcadeRect tileWorldRect, BaseBody body)
	{
		//IL_00fc: Expected I4, but got O
		//IL_002f: Invalid comparison between O and F4
		//IL_005b: Invalid comparison between I and F4
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
		//IL_008c: Expected O, but got Unknown
		//IL_00cd: Expected O, but got I
		if (body != null)
		{
			if (System.Runtime.CompilerServices.Unsafe.As<ArcadeRect, UIntPtr>(ref tileWorldRect) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)body.MaxX))
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [tileWorldRect @ rdx (ArcadeRect&)+4]");
				if (0f < body.MaxY)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [tileWorldRect @ rdx (ArcadeRect&)+8]");
					object obj = 0 + tileWorldRect;
					float2 position = body._position;
					if (System.Runtime.CompilerServices.Unsafe.As<float2, UIntPtr>(ref position) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj))
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [tileWorldRect @ rdx (ArcadeRect&)+C]");
						nint num = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [tileWorldRect @ rdx (ArcadeRect&)+4]");
						object obj2 = num + 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [body @ r8 (BaseBody)+54]");
						return 0 < (nint)obj2;
					}
				}
			}
			return false;
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	private bool collideGroupVsGroup(PhysicsGroup group1, PhysicsGroup group2, ArcadePhysicsCallback collideCallback, ArcadePhysicsCallback processCallback, CallbackContext callbackContext, bool overlapOnly)
	{
		//IL_014f: Expected I4, but got O
		if (group1 != null)
		{
			HashSet<PhaserGameObject> children = ((Group)group1).children;
			if (((Group)group1).children == null)
			{
				goto IL_0141;
			}
			if (children._count != 0 && group2 != null)
			{
				HashSet<PhaserGameObject> children2 = ((Group)group2).children;
				if (((Group)group2).children == null)
				{
					goto IL_0141;
				}
				if (children2._count != 0)
				{
					if (((Group)group1).children == null)
					{
						goto IL_0141;
					}
					HashSet<object>.Enumerator enumerator = default(HashSet<object>.Enumerator);
					ArcadePhysicsCallback processCallback2 = default(ArcadePhysicsCallback);
					CallbackContext callbackContext2 = default(CallbackContext);
					bool overlapOnly2 = default(bool);
					while (enumerator.MoveNext())
					{
						bool flag = collideSpriteVsGroup(null, group2, collideCallback, processCallback2, callbackContext2, overlapOnly2);
					}
				}
			}
		}
		return false;
		IL_0141:
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	public void wrap(ArcadeColliderType obj, float padding = 0f)
	{
		throw new Exception("Decompilation failed: Stack state not settling! (500001 blocks already visited)");
	}

	public unsafe void wrapArray(IEnumerable<ArcadeColliderType> objs, float padding = 0f)
	{
		//IL_0017: Expected O, but got Ref
		//IL_00e3: Expected O, but got I4
		//IL_0088: Expected O, but got I
		//IL_0091: Expected O, but got I4
		//IL_010b: Expected O, but got I
		//IL_0114: Unknown result type (might be due to invalid IL or missing references)
		//IL_0119: Expected O, but got Unknown
		//IL_009f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a4: Expected O, but got Unknown
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		object obj2 = default(object);
		object obj = (object)(&obj2);
		World world = null;
		ArcadeColliderType generalObj = default(ArcadeColliderType);
		float padding2 = default(float);
		object obj3 = default(object);
		object obj13 = default(object);
		for (; obj2 != null; Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v314 @ rdx_v9] (should have been resolved before IL gen)"), wrapObject(generalObj, padding2))
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
			object obj12;
			object obj5;
			if (obj3 != null)
			{
				object obj4 = obj2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v118 @ r10_v3+12E]");
				if ((nint)0 < (nint)0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v118 @ r10_v3+B0]");
					obj5 = 0;
					object obj6 = 0;
					while (true)
					{
						object obj7 = obj6 + obj6;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v125 @ r8_v7+v253 @ rax_v21*8]");
						if (0 == (nint)typeof(IEnumerator<ArcadeColliderType>))
						{
							break;
						}
						obj6++;
						object obj8 = obj6;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v118 @ r10_v3+12E]");
						if ((nint)obj8 < 0)
						{
							continue;
						}
						goto IL_00c8;
					}
					object obj9 = obj6 + obj6;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v125 @ r8_v7+8+v309 @ rcx_v17*8]");
					object obj10 = (nint)0 << 4;
					object obj11 = obj10 + 312;
					obj12 = obj11 + obj4;
					continue;
				}
				goto IL_00c8;
			}
			if (obj != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004820");
			}
			return;
			IL_00c8:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC0A30");
			obj12 = obj13;
			obj5 = 0;
		}
		throw new NullReferenceException();
	}

	public void wrapObject(ArcadeColliderType generalObj, float padding = 0f)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		object obj = default(object);
		if (obj != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180496460");
			ArcadeBodyBounds bounds = _bounds;
			float num = bounds.x - padding;
			float num2 = bounds.width + bounds.x;
			float num3 = num2 + padding;
			float num4 = default(float);
			if (!(num > num4))
			{
				if (num4 > num3)
				{
					float num5 = num4 - num3;
					num4 = num5 + num;
				}
			}
			else
			{
				float num6 = num4 - num;
				num4 = num6 + num3;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180496590");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180496460");
			ArcadeBodyBounds bounds2 = _bounds;
			float num7 = bounds2.y - padding;
			float num8 = bounds2.height + bounds2.y;
			float num9 = num8 + padding;
			if (!(num7 > num4))
			{
				if (num4 > num9)
				{
					float num10 = num4 - num9;
					num4 = num10 + num7;
				}
			}
			else
			{
				float num11 = num4 - num7;
				num4 = num11 + num9;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180496590");
			return;
		}
		throw new InvalidCastException();
	}

	private float Wrap(float v, float left, float right)
	{
		float num = default(float);
		if (!(left > num))
		{
			if (num > right)
			{
				float num2 = num - right;
				return num2 + left;
			}
			return num;
		}
		float num3 = num - left;
		return num3 + right;
	}

	public RBush GetTree(Group group)
	{
		if (_groupRTrees != null)
		{
			return _groupRTrees.get_Item(group);
		}
		return (RBush)(object)new NullReferenceException();
	}

	public RBush addGroupTree(Group group)
	{
		if (_groupRTrees != null)
		{
			int num = _groupRTrees.FindEntry(group);
			if (num >= 0)
			{
				goto IL_0166;
			}
			RBush value = new RBush(_maxEntries);
			if (_groupRTrees != null)
			{
				bool flag = ((Dictionary<object, object>)(object)_groupRTrees).TryInsert((object)group, (object)value, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
				List<object> groupsWithRTrees = (List<object>)(object)_groupsWithRTrees;
				if (_groupsWithRTrees != null)
				{
					int version = groupsWithRTrees._version + 1;
					groupsWithRTrees._version = version;
					object[] items = groupsWithRTrees._items;
					if (groupsWithRTrees._items != null)
					{
						if (groupsWithRTrees._size >= items.Length)
						{
							((List<object>)(object)_groupsWithRTrees).AddWithResize((object)group);
						}
						else
						{
							int size = groupsWithRTrees._size + 1;
							groupsWithRTrees._size = size;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
						}
						goto IL_0166;
					}
				}
			}
		}
		goto IL_019d;
		IL_0166:
		if (_groupRTrees != null)
		{
			return _groupRTrees.get_Item(group);
		}
		goto IL_019d;
		IL_019d:
		return (RBush)(object)new NullReferenceException();
	}

	public void addSubsetGroupTree(Group group, Group parentGroup)
	{
		RBush value = addGroupTree(parentGroup);
		bool flag = ((Dictionary<object, object>)(object)_groupRTrees).TryInsert((object)group, (object)value, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
	}

	public void destroyBody(BaseBody body)
	{
		bool flag = ((HashSet<object>)(object)_pendingAdd).Remove((object)body);
		bool flag2 = ((HashSet<object>)(object)_pendingDestroy).AddIfNotPresent((object)body);
	}

	private void shutdown()
	{
		//IL_0184: Expected I4, but got I8
		//IL_0216: Expected I4, but got I8
		//IL_0326: Expected O, but got I
		List<Group>.Enumerator enumerator = default(List<Group>.Enumerator);
		while (enumerator.MoveNext())
		{
			if (_groupRTrees != null)
			{
				RBush rBush = _groupRTrees.get_Item((Group)null);
				RBush rBush2 = rBush.clear();
				continue;
			}
			throw new NullReferenceException();
		}
		List<Group> groupsWithRTrees = _groupsWithRTrees;
		int version = groupsWithRTrees._version + 1;
		groupsWithRTrees._version = version;
		groupsWithRTrees._size = 0;
		if (groupsWithRTrees._size > 0)
		{
			Array.Clear(groupsWithRTrees._items, 0, groupsWithRTrees._size);
		}
		_groupRTrees.Clear();
		RBush rBush3 = _staticTree.clear();
		HashSet<Body> bodies = _bodies;
		if (bodies._lastIndex > 0)
		{
			Array.Clear(bodies._slots, 0, bodies._lastIndex);
			int[] buckets = bodies._buckets;
			Array.Clear(bodies._buckets, 0, buckets.Length);
			bodies._count = 0;
			bodies._freeList = -1;
		}
		int version2 = bodies._version + 1;
		bodies._version = version2;
		HashSet<StaticBody> staticBodies = _staticBodies;
		if (staticBodies._lastIndex > 0)
		{
			Array.Clear(staticBodies._slots, 0, staticBodies._lastIndex);
			int[] buckets2 = staticBodies._buckets;
			Array.Clear(staticBodies._buckets, 0, buckets2.Length);
			staticBodies._count = 0;
			staticBodies._freeList = -1;
		}
		int version3 = staticBodies._version + 1;
		staticBodies._version = version3;
		ProcessQueue<Collider> colliders = _colliders;
		colliders._toProcess = 0;
		List<Collider> pending = colliders._pending;
		int version4 = pending._version + 1;
		pending._version = version4;
		pending._size = 0;
		if (pending._size > 0)
		{
			Array.Clear(pending._items, 0, pending._size);
		}
		List<KeyValuePair<Collider, int>> pendingInserts = colliders._pendingInserts;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v161 @ rcx_v15 (System.Collections.Generic.List`1<System.Collections.Generic.KeyValuePair`2<Collider, System.Int32>>)+1C]");
		_ = (nint)0 + (nint)1;
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v161 @ rcx_v15 (System.Collections.Generic.List`1<System.Collections.Generic.KeyValuePair`2<Collider, System.Int32>>)+18]");
		if ((nint)0 > (nint)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v161 @ rcx_v15 (System.Collections.Generic.List`1<System.Collections.Generic.KeyValuePair`2<Collider, System.Int32>>)+10]");
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v161 @ rcx_v15 (System.Collections.Generic.List`1<System.Collections.Generic.KeyValuePair`2<Collider, System.Int32>>)+18]");
			Array.Clear((Array)num, 0, 0);
		}
		List<Collider> active = colliders._active;
		int version5 = active._version + 1;
		active._version = version5;
		active._size = 0;
		if (active._size > 0)
		{
			Array.Clear(active._items, 0, active._size);
		}
		List<Collider> list = colliders._destroy;
		int version6 = list._version + 1;
		list._version = version6;
		list._size = 0;
		if (list._size > 0)
		{
			Array.Clear(list._items, 0, list._size);
		}
		Delegate[] array = base.callbacks;
		int num2 = 0;
		for (int num3 = 0; num3 < array.Length; num3 = num2)
		{
			Delegate[] array2 = base.callbacks;
			array2[num2] = null;
			num2++;
			array = base.callbacks;
		}
	}

	public void destroy()
	{
		shutdown();
		_scene = null;
	}

	static World()
	{
		//IL_026c: Expected O, but got I
		//IL_0292: Expected O, but got I
		//IL_000e: Expected O, but got I
		//IL_0034: Expected O, but got I
		//IL_005f: Expected O, but got I
		//IL_0085: Expected O, but got I
		//IL_00b0: Expected O, but got I
		//IL_00d6: Expected O, but got I
		//IL_0101: Expected O, but got I
		//IL_0127: Expected O, but got I
		//IL_0152: Expected O, but got I
		//IL_0178: Expected O, but got I
		//IL_01a3: Expected O, but got I
		//IL_01c9: Expected O, but got I
		//IL_01f4: Expected O, but got I
		//IL_021a: Expected O, but got I
		//IL_0245: Expected O, but got I
		IntPtr intPtr = ProfilerUnsafeUtility.CreateMarker("World.enableBody", 5, MarkerFlags.Default, 0);
		_markerEnableBody = (ProfilerMarker)(nint)intPtr;
		IntPtr intPtr2 = ProfilerUnsafeUtility.CreateMarker("World.add", 5, MarkerFlags.Default, 0);
		MarkerAdd = (ProfilerMarker)(nint)intPtr2;
		IntPtr intPtr3 = ProfilerUnsafeUtility.CreateMarker("World.update", 5, MarkerFlags.Default, 0);
		s_updateMarker = (ProfilerMarker)(nint)intPtr3;
		IntPtr intPtr4 = ProfilerUnsafeUtility.CreateMarker("World.update.preUpdate", 5, MarkerFlags.Default, 0);
		s_preUpdateMarker = (ProfilerMarker)(nint)intPtr4;
		IntPtr intPtr5 = ProfilerUnsafeUtility.CreateMarker("World.update.colliders", 5, MarkerFlags.Default, 0);
		s_collidersMarker = (ProfilerMarker)(nint)intPtr5;
		IntPtr intPtr6 = ProfilerUnsafeUtility.CreateMarker("World.step", 5, MarkerFlags.Default, 0);
		s_stepMarker = (ProfilerMarker)(nint)intPtr6;
		IntPtr intPtr7 = ProfilerUnsafeUtility.CreateMarker("World.postUpdate", 5, MarkerFlags.Default, 0);
		s_postUpdateMarker = (ProfilerMarker)(nint)intPtr7;
		IntPtr intPtr8 = ProfilerUnsafeUtility.CreateMarker("World.postUpdate.drawDebug", 5, MarkerFlags.Default, 0);
		s_drawDebugMarker = (ProfilerMarker)(nint)intPtr8;
		IntPtr intPtr9 = ProfilerUnsafeUtility.CreateMarker("World.postUpdate.bodyDestruction", 5, MarkerFlags.Default, 0);
		s_bodyDestructionMarker = (ProfilerMarker)(nint)intPtr9;
		IntPtr intPtr10 = ProfilerUnsafeUtility.CreateMarker("World.update.separate", 5, MarkerFlags.Default, 0);
		s_separateMarker = (ProfilerMarker)(nint)intPtr10;
		IntPtr intPtr11 = ProfilerUnsafeUtility.CreateMarker("World.update.separateCircle", 5, MarkerFlags.Default, 0);
		s_separateCircleMarker = (ProfilerMarker)(nint)intPtr11;
		IntPtr intPtr12 = ProfilerUnsafeUtility.CreateMarker("World.update.separateCircle.sqrRt", 5, MarkerFlags.Default, 0);
		s_separateCircleSqrRtMarker = (ProfilerMarker)(nint)intPtr12;
		IntPtr intPtr13 = ProfilerUnsafeUtility.CreateMarker("World.update.intersects", 5, MarkerFlags.Default, 0);
		s_intersectsMarker = (ProfilerMarker)(nint)intPtr13;
		IntPtr intPtr14 = ProfilerUnsafeUtility.CreateMarker("World.collideSpriteVsTilemapLayer", 5, MarkerFlags.Default, 0);
		s_spriteVsTilemapMarker = (ProfilerMarker)(nint)intPtr14;
		IntPtr intPtr15 = ProfilerUnsafeUtility.CreateMarker("World.collideSpriteVsTilemapLayerFast", 5, MarkerFlags.Default, 0);
		s_spriteVsTilemapFastMarker = (ProfilerMarker)(nint)intPtr15;
		IntPtr intPtr16 = ProfilerUnsafeUtility.CreateMarker("World.collideSpriteVsTilesHandler.callbacks", 5, MarkerFlags.Default, 0);
		s_spriteVsTilemapCallbacksMarker = (ProfilerMarker)(nint)intPtr16;
		IntPtr intPtr17 = ProfilerUnsafeUtility.CreateMarker("World.SeparateTile", 5, MarkerFlags.Default, 0);
		s_separateTileMarker = (ProfilerMarker)(nint)intPtr17;
	}
}
