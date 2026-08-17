using System;
using Cpp2ILInjected;
using QFSW.MOP2;
using UnityEngine;

namespace VampireSurvivors.Objects;

public class BasePoolableSpriteBehaviour : ArcadeSprite, IPoolable
{
	private ObjectPool _ParentPool;

	public bool PoolReady
	{
		get
		{
			ObjectPool parentPool = _ParentPool;
			if ((object)_ParentPool != null)
			{
				bool flag = ((UnityEngine.Object)parentPool).m_CachedPtr == (IntPtr)0;
				return !flag;
			}
			return false;
		}
	}

	void IPoolable.InitializeTemplate(ObjectPool pool)
	{
		_ParentPool = pool;
	}

	public void Release()
	{
		GameObject obj = base.gameObject;
		_ParentPool.Release(obj);
	}

	public BasePoolableSpriteBehaviour()
	{
		//IL_0020: Expected I, but got O
		((GameMonoBehaviour)this)._onResumeSent = true;
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
