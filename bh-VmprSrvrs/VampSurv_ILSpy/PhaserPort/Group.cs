using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using Unity.Profiling;
using Unity.Profiling.LowLevel;
using Unity.Profiling.LowLevel.Unsafe;
using UnityEngine;

public class Group : EventEmitter, ArcadeColliderType
{
	private HashSet<PhaserGameObject> children;

	private readonly HashSet<PhaserGameObject> childrenToRemove;

	private readonly HashSet<PhaserGameObject> childrenToAdd;

	public PhysicsType _physicsType;

	private static readonly ProfilerMarker MarkerRemove;

	public int length
	{
		get
		{
			//IL_001d: Expected I4, but got O
			HashSet<PhaserGameObject> hashSet = children;
			if (children != null)
			{
				return hashSet._count;
			}
			NullReferenceException ex = new NullReferenceException();
			return (int)ex;
		}
	}

	public bool isParent => true;

	public BaseBody body => null;

	public bool isTilemap => false;

	public GameObject gameObject => null;

	public Group(int capacity)
	{
		//IL_001a: Expected O, but got I
		//IL_0067: Expected I4, but got I8
		//IL_00a8: Expected O, but got I
		//IL_0103: Expected I4, but got I8
		base._002Ector();
		HashSet<PhaserGameObject> hashSet = (HashSet<PhaserGameObject>)(object)new HashSet<object>(capacity, (IEqualityComparer<object>)PhaserGameObjectComparer.Default);
		children = hashSet;
		EqualityComparer<object> comparer = (EqualityComparer<object>)(object)PhaserGameObjectComparer.Default;
		HashSet<PhaserGameObject> hashSet2 = new HashSet<PhaserGameObject>(100, (IEqualityComparer<PhaserGameObject>)0);
		if (PhaserGameObjectComparer.Default == null)
		{
			comparer = EqualityComparer<object>.Default;
		}
		hashSet2._comparer = comparer;
		hashSet2._freeList = -1;
		hashSet2._count = 0;
		hashSet2._version = 0;
		childrenToRemove = hashSet2;
		EqualityComparer<object> comparer2 = (EqualityComparer<object>)(object)PhaserGameObjectComparer.Default;
		HashSet<PhaserGameObject> hashSet3 = new HashSet<PhaserGameObject>(100, (IEqualityComparer<PhaserGameObject>)0);
		if (PhaserGameObjectComparer.Default == null)
		{
			comparer2 = EqualityComparer<object>.Default;
		}
		hashSet3._comparer = comparer2;
		hashSet3._count = 0;
		hashSet3._freeList = -1;
		hashSet3._version = 0;
		childrenToAdd = hashSet3;
		_physicsType = PhysicsType.UNDEFINED;
	}

	public Group add(PhaserGameObject child)
	{
		if (childrenToAdd != null)
		{
			bool flag = ((HashSet<object>)(object)childrenToAdd).AddIfNotPresent((object)child);
			if (childrenToRemove != null)
			{
				bool flag2 = ((HashSet<object>)(object)childrenToRemove).Remove((object)child);
				return this;
			}
		}
		return (Group)(object)new NullReferenceException();
	}

	public void remove(PhaserGameObject child)
	{
		//IL_0089: Expected I, but got O
		if ((object)MarkerRemove != null)
		{
			ProfilerUnsafeUtility.BeginSample((IntPtr)MarkerRemove);
		}
		bool flag = childrenToAdd == null;
		bool flag2 = ((HashSet<object>)(object)childrenToAdd).Remove((object)child);
		bool flag3 = childrenToRemove == null;
		bool flag4 = ((HashSet<object>)(object)childrenToRemove).AddIfNotPresent((object)child);
		ProfilerMarker.AutoScope autoScope = default(ProfilerMarker.AutoScope);
		autoScope.Dispose();
	}

	public bool isFull()
	{
		return false;
	}

	public int countActive(bool value = true)
	{
		int result = 0;
		HashSet<object>.Enumerator enumerator = default(HashSet<object>.Enumerator);
		if (enumerator.MoveNext())
		{
			Group obj = null;
			throw new NullReferenceException();
		}
		return result;
	}

	public bool contains(PhaserGameObject child)
	{
		//IL_002b: Expected I4, but got O
		if (children != null)
		{
			return ((HashSet<object>)(object)children).Contains((object)child);
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	public HashSet<PhaserGameObject> getChildren()
	{
		return children;
	}

	protected void clear()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
	}

	public unsafe void UpdateHashSetElements()
	{
		HashSet<PhaserGameObject> hashSet = childrenToAdd;
		bool flag = childrenToAdd == null;
		Group obj = this;
		if (!flag)
		{
			bool flag2 = hashSet._count <= 0;
			obj = this;
			HashSet<object>.Enumerator enumerator = default(HashSet<object>.Enumerator);
			if (!flag2)
			{
				while (enumerator.MoveNext())
				{
					if (children != null)
					{
						bool flag3 = ((HashSet<object>)(object)children).AddIfNotPresent((object)null);
						continue;
					}
					throw new NullReferenceException();
				}
				bool flag4 = childrenToAdd == null;
				obj = (Group)(object)childrenToAdd;
				if (flag4)
				{
					goto IL_012c;
				}
				bool flag5 = ((HashSet<PhaserGameObject>.Enumerator*)childrenToAdd)->MoveNext();
				obj = (Group)(object)childrenToAdd;
			}
			HashSet<PhaserGameObject> hashSet2 = childrenToRemove;
			if (childrenToRemove != null)
			{
				if (hashSet2._count <= 0)
				{
					return;
				}
				while (enumerator.MoveNext())
				{
					if (children != null)
					{
						bool flag6 = ((HashSet<object>)(object)children).Remove((object)null);
						continue;
					}
					throw new NullReferenceException();
				}
				bool flag7 = childrenToRemove == null;
				obj = (Group)(object)childrenToRemove;
				if (!flag7)
				{
					bool flag8 = ((HashSet<PhaserGameObject>.Enumerator*)childrenToRemove)->MoveNext();
					return;
				}
			}
		}
		goto IL_012c;
		IL_012c:
		throw new NullReferenceException();
	}

	static Group()
	{
		//IL_002b: Expected O, but got I
		IntPtr intPtr = ProfilerUnsafeUtility.CreateMarker("Group.remove", 1, MarkerFlags.Default, 0);
		MarkerRemove = (ProfilerMarker)(nint)intPtr;
	}
}
