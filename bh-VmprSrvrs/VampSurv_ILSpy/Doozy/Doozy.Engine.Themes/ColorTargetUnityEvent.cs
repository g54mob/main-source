using System;
using Cpp2ILInjected;
using Doozy.Engine.Events;
using UnityEngine;

namespace Doozy.Engine.Themes;

public class ColorTargetUnityEvent : ThemeTarget
{
	public ColorEvent Event;

	public unsafe override void UpdateTarget(ThemeData theme)
	{
		//IL_0227: Expected O, but got Ref
		//IL_023f: Expected O, but got Ref
		if (Event == null || (object)theme == null || ((UnityEngine.Object)theme).m_CachedPtr == (IntPtr)0)
		{
			return;
		}
		if ((object)ThemeId == (object)Guid.Empty)
		{
			object obj = (object)Guid.Empty >> 32;
			object obj2 = (object)ThemeId >> 32;
			if (obj2 == obj)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm3,8\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm2,8\"");
				if ((object)ThemeId == (object)Guid.Empty)
				{
					object obj3 = (object)Guid.Empty >> 32;
					object obj4 = (object)ThemeId >> 32;
					if (obj4 == obj3)
					{
						return;
					}
				}
			}
		}
		if ((object)PropertyId == (object)Guid.Empty)
		{
			object obj5 = (object)Guid.Empty >> 32;
			object obj6 = (object)PropertyId >> 32;
			if (obj6 == obj5)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm3,8\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm2,8\"");
				if ((object)PropertyId == (object)Guid.Empty)
				{
					object obj7 = (object)Guid.Empty >> 32;
					object obj8 = (object)PropertyId >> 32;
					if (obj8 == obj7)
					{
						return;
					}
				}
			}
		}
		ThemeVariantData activeVariant = theme.ActiveVariant;
		if (activeVariant != null)
		{
			ThemeVariantData activeVariant2 = theme.ActiveVariant;
			Guid guid = default(Guid);
			Color color = activeVariant2.GetColor((Guid)(&guid));
			Event.Invoke((Color)(&guid));
		}
	}

	private void Reset()
	{
		//IL_0022: Expected I, but got O
		nint num = (nint)typeof(Guid);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ rax_v2 (Il2CppClass<System.Guid>)+B8]");
		nint num2 = 0;
		ThemeId = Guid.Empty;
		VariantId = Guid.Empty;
		PropertyId = Guid.Empty;
		if (Event == null)
		{
			ColorEvent colorEvent = new ColorEvent();
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180494DF0");
			Event = colorEvent;
		}
	}

	private void UpdateReference()
	{
		if (Event == null)
		{
			ColorEvent colorEvent = new ColorEvent();
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180494DF0");
			Event = colorEvent;
		}
	}
}
