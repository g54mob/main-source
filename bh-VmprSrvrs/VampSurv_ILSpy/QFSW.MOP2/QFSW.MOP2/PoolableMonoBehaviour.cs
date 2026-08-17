using System;
using Cpp2ILInjected;
using UnityEngine;

namespace QFSW.MOP2;

public class PoolableMonoBehaviour : GameMonoBehaviour, IPoolable
{
	private ObjectPool _parentPool;

	public bool PoolReady
	{
		get
		{
			ObjectPool parentPool = _parentPool;
			if ((object)_parentPool != null)
			{
				bool flag = ((UnityEngine.Object)parentPool).m_CachedPtr == (IntPtr)0;
				return !flag;
			}
			return false;
		}
	}

	void IPoolable.InitializeTemplate(ObjectPool pool)
	{
		_parentPool = pool;
	}

	public void Release()
	{
		GameObject obj = base.gameObject;
		if ((object)_parentPool != null)
		{
			_parentPool.Release(obj);
			return;
		}
		throw new NullReferenceException();
	}

	public PoolableMonoBehaviour()
	{
		//IL_0020: Expected I, but got O
		base._onResumeSent = true;
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
