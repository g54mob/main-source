using System;
using Cpp2ILInjected;
using UnityEngine;

namespace VampireSurvivors;

public class PhysicsTestbed : MonoBehaviour
{
	private GameObject _EnemyPrefab;

	public PhysicsGroup Enemies;

	public PhysicsGroup _enemyGroup;

	private static PhysicsTestbed _sInstance;

	public static PhysicsTestbed Instance => _sInstance;

	private void Awake()
	{
		_sInstance = this;
	}

	private void Start()
	{
		InitPhysics();
		SpawnEnemies();
	}

	private void InitPhysics()
	{
		PhaserScene s_scene = ArcadePhysics.s_scene;
		Factory add = s_scene.add;
		PhysicsGroup physicsGroup = (PhysicsGroup)new Group(10);
		((Group)physicsGroup)._002Ector(10);
		physicsGroup._physicsType = PhysicsType.DYNAMIC_BODY;
		RBush rBush = add._world.addGroupTree(physicsGroup);
		Enemies = physicsGroup;
		PhysicsGroup enemies = Enemies;
		enemies._physicsType = PhysicsType.DYNAMIC_BODY;
		PhaserScene s_scene2 = ArcadePhysics.s_scene;
		if (s_scene2.add != null)
		{
			PhysicsGroup physicsGroup2 = (PhysicsGroup)new Group(10);
			((Group)physicsGroup2)._002Ector(10);
			physicsGroup2._physicsType = PhysicsType.DYNAMIC_BODY;
			_enemyGroup = physicsGroup2;
			PhysicsGroup enemyGroup = _enemyGroup;
			enemyGroup._physicsType = PhysicsType.DYNAMIC_BODY;
			ArcadePhysics.s_world.addSubsetGroupTree(_enemyGroup, Enemies);
			PhaserScene s_scene3 = ArcadePhysics.s_scene;
			if ((object)s_scene3.physics != null)
			{
				ArcadeColliderType @object = default(ArcadeColliderType);
				ArcadePhysicsCallback collideCallback = default(ArcadePhysicsCallback);
				ArcadePhysicsCallback processCallback = default(ArcadePhysicsCallback);
				CallbackContext callbackContext = default(CallbackContext);
				CircleSpecificCollider circleSpecificCollider = new CircleSpecificCollider(ArcadePhysics.s_world, overlapOnly: false, Enemies, @object, collideCallback, processCallback, callbackContext);
				Collider collider = circleSpecificCollider.setName("Enemies>Enemies");
				PhaserScene s_scene4 = ArcadePhysics.s_scene;
				if ((object)s_scene4.physics != null)
				{
					World s_world = ArcadePhysics.s_world;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1809B4520");
					return;
				}
			}
		}
		throw new NullReferenceException();
	}

	private unsafe void SpawnEnemies()
	{
		//IL_014f: Expected O, but got I4
		//IL_01a7: Expected O, but got I
		//IL_01ee: Expected O, but got I
		//IL_003e: Expected O, but got I8
		//IL_007c: Expected O, but got I8
		//IL_00cc: Expected O, but got Ref
		//IL_00cc: Expected O, but got Ref
		//IL_0112: Unknown result type (might be due to invalid IL or missing references)
		//IL_0117: Expected O, but got Unknown
		object obj = 0;
		PhysicsTestbed physicsTestbed = this;
		object obj5 = default(object);
		Quaternion identityQuaternion = default(Quaternion);
		GameObject gameObject = default(GameObject);
		while (true)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
				if (obj2 == null)
				{
					MissingMethodException ex = new MissingMethodException();
					throw ex;
				}
				physicsTestbed = (PhysicsTestbed)6573110936L;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v144 @ rax_v4 (should have been resolved before IL gen)");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
				if (obj3 == null)
				{
					MissingMethodException ex2 = new MissingMethodException();
					throw ex2;
				}
				physicsTestbed = (PhysicsTestbed)6573110936L;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v183 @ rax_v7 (should have been resolved before IL gen)");
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v323 @ rbx_v2 (Il2CppMethodInfo)+38]");
			if ((nint)0 == 0)
			{
			}
			UnityEngine.Object obj4 = UnityEngine.Object.Instantiate((UnityEngine.Object)_EnemyPrefab, (Vector3)(&obj5), (Quaternion)(&identityQuaternion));
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			if ((object)gameObject == null)
			{
				break;
			}
			ArcadeSprite component = gameObject.GetComponent<ArcadeSprite>();
			obj++;
			bool flag = (nint)obj < 500;
			identityQuaternion = Quaternion.identityQuaternion;
			physicsTestbed = (PhysicsTestbed)(object)gameObject;
			if (!flag)
			{
				return;
			}
		}
		throw new InvalidCastException();
	}

	public PhysicsTestbed()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
