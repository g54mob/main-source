using System;
using Cpp2ILInjected;
using UnityEngine;

public class UpdateableData : ScriptableObject
{
	private Action m_OnValuesUpdate;

	public bool autoUpdate;

	public event Action OnValuesUpdate
	{
		add
		{
			//IL_0047: Unknown result type (might be due to invalid IL or missing references)
			//IL_004c: Expected O, but got Unknown
			Delegate obj = this.m_OnValuesUpdate;
			Delegate obj5 = default(Delegate);
			while (true)
			{
				Delegate obj2 = Delegate.Combine(obj, value);
				bool flag = (object)obj2 == null;
				Delegate obj3 = null;
				if (!flag)
				{
					bool flag2 = (object)obj2.GetType() != typeof(Action);
					obj3 = null;
					if (!flag2)
					{
						obj3 = obj2;
					}
					if ((object)obj3 == null)
					{
						break;
					}
				}
				object obj4 = this + 24;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802652A0");
				bool flag3 = (object)obj5 != obj;
				obj = obj5;
				if (!flag3)
				{
					return;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		}
		remove
		{
			//IL_0047: Unknown result type (might be due to invalid IL or missing references)
			//IL_004c: Expected O, but got Unknown
			Delegate obj = this.m_OnValuesUpdate;
			Delegate obj5 = default(Delegate);
			while (true)
			{
				Delegate obj2 = Delegate.Remove(obj, value);
				bool flag = (object)obj2 == null;
				Delegate obj3 = null;
				if (!flag)
				{
					bool flag2 = (object)obj2.GetType() != typeof(Action);
					obj3 = null;
					if (!flag2)
					{
						obj3 = obj2;
					}
					if ((object)obj3 == null)
					{
						break;
					}
				}
				object obj4 = this + 24;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802652A0");
				bool flag3 = (object)obj5 != obj;
				obj = obj5;
				if (!flag3)
				{
					return;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		}
	}
}
