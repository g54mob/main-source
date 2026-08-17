using System;
using System.Collections.Generic;
using System.Linq;
using Cpp2ILInjected;
using UnityEngine;

public class PhaserArray : ArcadeColliderType
{
	public ArcadeColliderType[] _objects;

	public bool isParent => false;

	public BaseBody body => null;

	public bool isTilemap => false;

	public int length
	{
		get
		{
			//IL_003e: Expected I4, but got O
			ArcadeColliderType[] objects = _objects;
			if (_objects != null)
			{
				return objects.Length;
			}
			NullReferenceException ex = new NullReferenceException();
			return (int)ex;
		}
	}

	public GameObject gameObject => null;

	// C# has no syntax for parameterized property 'Item'.
	public ArcadeColliderType get_Item(int i)
	{
		ArcadeColliderType[] objects = _objects;
		if (i < objects.Length)
		{
			return objects[i];
		}
		return (ArcadeColliderType)(object)new IndexOutOfRangeException();
	}

	public void set_Item(int i, ArcadeColliderType value)
	{
		//IL_0034: Expected I, but got O
		ArcadeColliderType[] objects = _objects;
		if (value != null)
		{
			nint num = (nint)objects;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj = default(object);
			if (obj == null)
			{
				ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
				throw ex;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
	}

	public PhaserArray(ArcadeColliderType singleObject)
	{
		//IL_002a: Expected I, but got O
		ArcadeColliderType[] array = new ArcadeColliderType[1];
		if (singleObject != null)
		{
			nint num = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj = default(object);
			if (obj == null)
			{
				ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
				throw ex;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		_objects = array;
	}

	public PhaserArray(List<PhaserGameObject> objects)
	{
		PhaserGameObject[] objects2 = objects.ToArray();
		_objects = objects2;
	}

	public PhaserArray(HashSet<PhaserGameObject> objects)
	{
		if (objects != null)
		{
			System.Linq.Buffer<object> buffer = new System.Linq.Buffer<object>((IEnumerable<object>)objects);
			System.Linq.Buffer<PhaserGameObject> buffer2 = default(System.Linq.Buffer<PhaserGameObject>);
			PhaserGameObject[] objects2 = buffer2.ToArray();
			_objects = objects2;
			return;
		}
		Exception ex = System.Linq.Error.ArgumentNull("source");
		throw ex;
	}
}
