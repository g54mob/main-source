using System;
using System.Collections.Generic;
using Cpp2ILInjected;

public class Factory(World world)
{
	private World _world = world;

	private PhaserScene _scene = world._scene;

	public Collider collider(ArcadeColliderType object1, ArcadeColliderType object2, ArcadePhysicsCallback collideCallback = null, ArcadePhysicsCallback processCallback = null, CallbackContext callbackContext = null)
	{
		World world = _world;
		if (_world != null)
		{
			ArcadeColliderType object3 = default(ArcadeColliderType);
			ArcadePhysicsCallback collideCallback2 = default(ArcadePhysicsCallback);
			ArcadePhysicsCallback processCallback2 = default(ArcadePhysicsCallback);
			CallbackContext callbackContext2 = default(CallbackContext);
			Collider result = new Collider(_world, overlapOnly: false, object1, object3, collideCallback2, processCallback2, callbackContext2);
			if (world._colliders != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1809B4520");
				return result;
			}
		}
		return (Collider)(object)new NullReferenceException();
	}

	public Collider overlap(ArcadeColliderType object1, ArcadeColliderType object2, ArcadePhysicsCallback collideCallback = null, ArcadePhysicsCallback processCallback = null, CallbackContext callbackContext = null)
	{
		World world = _world;
		if (_world != null)
		{
			ArcadeColliderType object3 = default(ArcadeColliderType);
			ArcadePhysicsCallback collideCallback2 = default(ArcadePhysicsCallback);
			ArcadePhysicsCallback processCallback2 = default(ArcadePhysicsCallback);
			CallbackContext callbackContext2 = default(CallbackContext);
			Collider result = new Collider(_world, overlapOnly: true, object1, object3, collideCallback2, processCallback2, callbackContext2);
			if (world._colliders != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1809B4520");
				return result;
			}
		}
		return (Collider)(object)new NullReferenceException();
	}

	public PhaserGameObject existing(PhaserGameObject gameObject, bool isStatic = false)
	{
		if (_world != null)
		{
			PhaserGameObject phaserGameObject = _world.enableBody(gameObject, isStatic ? PhysicsType.STATIC_BODY : PhysicsType.DYNAMIC_BODY);
			return gameObject;
		}
		return (PhaserGameObject)(object)new NullReferenceException();
	}

	public StaticPhysicsGroup staticGroup(List<PhaserGameObject> children = null, PhysicsGroupConfig config = null)
	{
		StaticPhysicsGroup staticPhysicsGroup = new StaticPhysicsGroup();
		((GameMonoBehaviour)staticPhysicsGroup)._onResumeSent = true;
		return staticPhysicsGroup;
	}

	public PhysicsGroup group(List<PhaserGameObject> children = null, PhysicsGroupConfig config = null, bool allowRTreeQueries = true, int capacity = 10)
	{
		int capacity2 = default(int);
		PhysicsGroup physicsGroup = (PhysicsGroup)new Group(capacity2);
		((Group)physicsGroup)._002Ector(capacity2);
		physicsGroup._physicsType = PhysicsType.DYNAMIC_BODY;
		if (allowRTreeQueries)
		{
			if (_world == null)
			{
				return (PhysicsGroup)(object)new NullReferenceException();
			}
			RBush rBush = _world.addGroupTree(physicsGroup);
		}
		return physicsGroup;
	}

	public void destroy()
	{
		_world = null;
		_scene = null;
	}
}
