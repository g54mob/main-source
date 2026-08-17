using System;
using System.Collections.Generic;
using Cpp2ILInjected;

public class Collider
{
	protected string _name;

	protected World _world;

	public bool _active;

	protected bool _overlapOnly;

	protected ArcadeColliderType _object1;

	protected ArcadeColliderType _object2;

	protected ArcadePhysicsCallback _collideCallback;

	protected ArcadePhysicsCallback _processCallback;

	protected CallbackContext _callbackContext;

	public Collider(World world, bool overlapOnly, ArcadeColliderType object1, ArcadeColliderType object2, ArcadePhysicsCallback collideCallback, ArcadePhysicsCallback processCallback, CallbackContext callbackContext)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18998B24D]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		_name = "Collider";
		_world = world;
		_active = true;
		_overlapOnly = overlapOnly;
		_object1 = object1;
		ArcadeColliderType object3 = default(ArcadeColliderType);
		_object2 = object3;
		ArcadePhysicsCallback collideCallback2 = default(ArcadePhysicsCallback);
		_collideCallback = collideCallback2;
		ArcadePhysicsCallback processCallback2 = default(ArcadePhysicsCallback);
		_processCallback = processCallback2;
		CallbackContext callbackContext2 = default(CallbackContext);
		_callbackContext = callbackContext2;
	}

	public Collider setName(string name)
	{
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Expected O, but got Unknown
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18998B24E]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		object obj = this + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		object obj2 = default(object);
		if (obj2 != null)
		{
			object obj3 = obj2;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v46 @ rdx_v1+1B8] (should have been resolved before IL gen)");
			string text = default(string);
			string name2 = name + " " + text;
			_name = name2;
			return this;
		}
		return (Collider)(object)new NullReferenceException();
	}

	public virtual void update()
	{
		ArcadePhysicsCallback processCallback = default(ArcadePhysicsCallback);
		CallbackContext callbackContext = default(CallbackContext);
		bool overlapOnly = default(bool);
		bool flag = _world.collideObjects(_object1, _object2, _collideCallback, processCallback, callbackContext, overlapOnly);
	}

	public void destroy()
	{
		World world = _world.removeCollider(this);
		_active = false;
		_world = null;
		_object1 = null;
		_object2 = null;
		_collideCallback = null;
		_processCallback = null;
		_callbackContext = null;
	}

	public unsafe void SetColliderRunPosition(int position)
	{
		//IL_003b: Expected O, but got Ref
		World world = _world.removeCollider(this);
		World world2 = _world;
		ProcessQueue<Collider> colliders = world2._colliders;
		object obj = default(object);
		colliders._pendingInserts.Add((KeyValuePair<Collider, int>)(&obj));
		int toProcess = colliders._toProcess + 1;
		colliders._toProcess = toProcess;
	}
}
