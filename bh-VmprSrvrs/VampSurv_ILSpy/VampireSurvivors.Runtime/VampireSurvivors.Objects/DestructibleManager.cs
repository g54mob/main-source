using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using QFSW.MOP2;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using Zenject;

namespace VampireSurvivors.Objects;

public class DestructibleManager : IInitializable, IDisposable
{
	private static DestructibleFactory _factory;

	private void Construct(DestructibleFactory factory)
	{
		_factory = factory;
	}

	public void Initialize()
	{
		_factory.InitPools();
	}

	public void Dispose()
	{
		_factory.PurgePools();
	}

	public static ObjectPool GetPool(PropType type)
	{
		if ((object)_factory != null)
		{
			return _factory.GetPool(type);
		}
		return (ObjectPool)(object)new NullReferenceException();
	}

	public unsafe static List<Destructible> AllActiveDestructibles()
	{
		//IL_0015: Expected O, but got I
		//IL_0031: Expected O, but got Ref
		//IL_0048: Expected O, but got Ref
		List<Destructible> list = new List<Destructible>();
		DestructibleFactory factory = _factory;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v50 @ r9_v1 (VampireSurvivors.Framework.DestructibleFactory)+78]");
		Dictionary<PropType, ObjectPool>.Enumerator enumerator = (Dictionary<PropType, ObjectPool>.Enumerator)0;
		Dictionary<PropType, ObjectPool>.Enumerator enumerator2 = default(Dictionary<PropType, ObjectPool>.Enumerator);
		object obj = default(object);
		Dictionary<int, GameObject>.Enumerator enumerator4 = default(Dictionary<int, GameObject>.Enumerator);
		GameObject gameObject = default(GameObject);
		while (enumerator2.MoveNext())
		{
			bool flag = obj == null;
			Dictionary<PropType, ObjectPool>.Enumerator enumerator3 = (Dictionary<PropType, ObjectPool>.Enumerator)(&enumerator2);
			if (!flag)
			{
				Dictionary<int, GameObject>.Enumerator allActiveObjectsEnumerator = ((ObjectPool)(&enumerator)).GetAllActiveObjectsEnumerator();
				while (enumerator4.MoveNext())
				{
					if ((object)gameObject != null)
					{
						Destructible component = gameObject.GetComponent<Destructible>();
						if (list != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA2070");
							continue;
						}
						throw new NullReferenceException();
					}
					throw new NullReferenceException();
				}
				continue;
			}
			throw new NullReferenceException();
		}
		return list;
	}
}
