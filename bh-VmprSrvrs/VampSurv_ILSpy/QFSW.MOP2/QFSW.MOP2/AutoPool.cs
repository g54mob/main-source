using System;
using Cpp2ILInjected;
using UnityEngine;

namespace QFSW.MOP2;

public class AutoPool : PoolableMonoBehaviour
{
	private float _poolTimer;

	private bool _scaledTime;

	private float _elapsedTime;

	protected override void OnEnable()
	{
		base.OnEnable();
		_elapsedTime = 0f;
	}

	private void Update()
	{
		//IL_0033: Expected O, but got I
		//IL_0028: Expected O, but got I
		if (!_scaledTime)
		{
			object obj = 0;
		}
		else
		{
			object obj = 0;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v53 @ rax_v7 (should have been resolved before IL gen)");
		object obj2 = default(object);
		if ((_elapsedTime = (float)obj2 + _elapsedTime) > _poolTimer)
		{
			ObjectPool parentPool = base._parentPool;
			if ((object)base._parentPool != null && ((UnityEngine.Object)parentPool).m_CachedPtr != (IntPtr)0)
			{
				GameObject obj3 = base.gameObject;
				base._parentPool.Release(obj3);
			}
		}
	}

	public AutoPool()
	{
		//IL_0036: Expected I, but got O
		_poolTimer = 1f;
		_scaledTime = true;
		((GameMonoBehaviour)this)._onResumeSent = true;
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
