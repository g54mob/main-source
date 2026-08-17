using System;
using System.Threading;
using Cpp2ILInjected;

namespace VampireSurvivors.Framework.Platforms;

public class ActionDeferral(Action onUnlock)
{
	private Action m_OnUnlock = onUnlock;

	private int m_Locks;

	public void Lock()
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Expected O, but got Unknown
		//IL_0088: Expected O, but got I8
		object obj2 = default(object);
		object obj = obj2 + 8;
		if (this != null)
		{
			Monitor.Enter(this);
			int locks = m_Locks + 1;
			m_Locks = locks;
			object obj3 = default(object);
			if (obj3 != null)
			{
				bool flag = this == null;
				object obj4 = 4294967295L;
				if (flag)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180ACF6C0");
					object obj5 = default(object);
					throw obj5;
				}
				Monitor.Exit(this);
			}
			return;
		}
		ArgumentNullException ex = new ArgumentNullException("obj");
		ex._002Ector("obj");
		throw ex;
	}

	public bool Unlock()
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Expected O, but got Unknown
		//IL_0088: Expected O, but got I8
		object obj2 = default(object);
		object obj = obj2 + 24;
		if (this != null)
		{
			Monitor.Enter(this);
			int locks = m_Locks - 1;
			m_Locks = locks;
			object obj3 = default(object);
			if (obj3 != null)
			{
				bool flag = this == null;
				object obj4 = 4294967295L;
				if (flag)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180ACF6C0");
					object obj5 = default(object);
					throw obj5;
				}
				Monitor.Exit(this);
			}
			return true;
		}
		ArgumentNullException ex = new ArgumentNullException("obj");
		ex._002Ector("obj");
		throw ex;
	}
}
