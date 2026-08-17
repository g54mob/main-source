using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine;

namespace Plugins.PauseSystem;

public class GamePerfFixManager : MonoBehaviour
{
	private readonly HashSet<GameMonoBehaviour> _gameMonoBehaviours;

	private readonly HashSet<GameMonoBehaviour> _gameMonoBehavioursToAdd;

	private readonly HashSet<GameMonoBehaviour> _gameMonoBehavioursToRemove;

	private static GamePerfFixManager _sInstance;

	public static GamePerfFixManager Instance => _sInstance;

	private void Awake()
	{
		GamePerfFixManager sInstance = _sInstance;
		if ((object)_sInstance != null && ((UnityEngine.Object)sInstance).m_CachedPtr != (IntPtr)0)
		{
			Debug.LogError("There should only be one GamePerfFixManager class in a scene");
		}
		_sInstance = this;
	}

	protected internal unsafe void Update()
	{
		//IL_002d: Expected O, but got Ref
		UpdateHashSetElements();
		HashSet<object>.Enumerator enumerator = default(HashSet<object>.Enumerator);
		nint num2 = default(nint);
		while (enumerator.MoveNext())
		{
			HashSet<object> gameMonoBehavioursToRemove = (HashSet<object>)(object)_gameMonoBehavioursToRemove;
			bool flag = _gameMonoBehavioursToRemove == null;
			HashSet<object>.Enumerator enumerator2 = (HashSet<object>.Enumerator)(&enumerator);
			if (!flag)
			{
				bool flag2 = gameMonoBehavioursToRemove._count <= 0;
				nint num = num2;
				if (!flag2)
				{
					bool flag3 = ((HashSet<object>)(object)_gameMonoBehavioursToRemove).Contains((object)null);
					num = 0;
					num2 = 0;
					if (flag3)
					{
						continue;
					}
				}
				throw new NullReferenceException();
			}
			throw new NullReferenceException();
		}
		UpdateHashSetElements();
	}

	private void OnDestroy()
	{
		//IL_0047: Expected I, but got O
		_sInstance = null;
		nint num = (nint)typeof(GamePerfFixManager);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
	}

	public void AddBehaviour(GameMonoBehaviour gameMonoBehaviour)
	{
		bool flag = ((HashSet<object>)(object)_gameMonoBehavioursToAdd).AddIfNotPresent((object)gameMonoBehaviour);
		bool flag2 = ((HashSet<object>)(object)_gameMonoBehavioursToRemove).Remove((object)gameMonoBehaviour);
	}

	public void RemoveBehaviour(GameMonoBehaviour gameMonoBehaviour)
	{
		bool flag = ((HashSet<object>)(object)_gameMonoBehavioursToAdd).Remove((object)gameMonoBehaviour);
		bool flag2 = ((HashSet<object>)(object)_gameMonoBehavioursToRemove).AddIfNotPresent((object)gameMonoBehaviour);
	}

	private unsafe void UpdateHashSetElements()
	{
		HashSet<GameMonoBehaviour> gameMonoBehavioursToAdd = _gameMonoBehavioursToAdd;
		bool flag = _gameMonoBehavioursToAdd == null;
		GamePerfFixManager gamePerfFixManager = this;
		if (!flag)
		{
			bool flag2 = gameMonoBehavioursToAdd._count <= 0;
			gamePerfFixManager = this;
			HashSet<object>.Enumerator enumerator = default(HashSet<object>.Enumerator);
			if (!flag2)
			{
				while (enumerator.MoveNext())
				{
					if (_gameMonoBehaviours != null)
					{
						bool flag3 = ((HashSet<object>)(object)_gameMonoBehaviours).AddIfNotPresent((object)null);
						continue;
					}
					throw new NullReferenceException();
				}
				bool flag4 = _gameMonoBehavioursToAdd == null;
				gamePerfFixManager = (GamePerfFixManager)(object)_gameMonoBehavioursToAdd;
				if (flag4)
				{
					goto IL_012c;
				}
				bool flag5 = ((HashSet<GameMonoBehaviour>.Enumerator*)_gameMonoBehavioursToAdd)->MoveNext();
				gamePerfFixManager = (GamePerfFixManager)(object)_gameMonoBehavioursToAdd;
			}
			HashSet<GameMonoBehaviour> gameMonoBehavioursToRemove = _gameMonoBehavioursToRemove;
			if (_gameMonoBehavioursToRemove != null)
			{
				if (gameMonoBehavioursToRemove._count <= 0)
				{
					return;
				}
				while (enumerator.MoveNext())
				{
					if (_gameMonoBehaviours != null)
					{
						bool flag6 = ((HashSet<object>)(object)_gameMonoBehaviours).Remove((object)null);
						continue;
					}
					throw new NullReferenceException();
				}
				bool flag7 = _gameMonoBehavioursToRemove == null;
				gamePerfFixManager = (GamePerfFixManager)(object)_gameMonoBehavioursToRemove;
				if (!flag7)
				{
					bool flag8 = ((HashSet<GameMonoBehaviour>.Enumerator*)_gameMonoBehavioursToRemove)->MoveNext();
					return;
				}
			}
		}
		goto IL_012c;
		IL_012c:
		throw new NullReferenceException();
	}

	public GamePerfFixManager()
	{
		//IL_0037: Expected I4, but got I8
		//IL_00e7: Expected I4, but got I8
		//IL_0189: Expected I4, but got I8
		HashSet<GameMonoBehaviour> hashSet = null;
		EqualityComparer<object> equalityComparer = EqualityComparer<object>.Default;
		if (equalityComparer == null)
		{
			equalityComparer = EqualityComparer<object>.Default;
		}
		hashSet._comparer = equalityComparer;
		hashSet._freeList = -1;
		hashSet._count = 0;
		hashSet._version = 0;
		int num = hashSet.Initialize(8000);
		_gameMonoBehaviours = hashSet;
		HashSet<GameMonoBehaviour> hashSet2 = null;
		EqualityComparer<object> equalityComparer2 = EqualityComparer<object>.Default;
		if (equalityComparer2 == null)
		{
			equalityComparer2 = EqualityComparer<object>.Default;
		}
		hashSet2._comparer = equalityComparer2;
		hashSet2._count = 0;
		hashSet2._freeList = -1;
		hashSet2._version = 0;
		int num2 = hashSet2.Initialize(500);
		_gameMonoBehavioursToAdd = hashSet2;
		HashSet<GameMonoBehaviour> hashSet3 = null;
		EqualityComparer<object> equalityComparer3 = EqualityComparer<object>.Default;
		if (equalityComparer3 == null)
		{
			equalityComparer3 = EqualityComparer<object>.Default;
		}
		hashSet3._comparer = equalityComparer3;
		hashSet3._count = 0;
		hashSet3._freeList = -1;
		hashSet3._version = 0;
		int num3 = hashSet3.Initialize(500);
		_gameMonoBehavioursToRemove = hashSet3;
	}
}
