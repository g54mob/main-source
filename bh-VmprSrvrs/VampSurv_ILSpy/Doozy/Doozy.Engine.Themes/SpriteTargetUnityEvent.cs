using System;
using Cpp2ILInjected;
using Doozy.Engine.Events;
using UnityEngine;
using UnityEngine.Events;

namespace Doozy.Engine.Themes;

public class SpriteTargetUnityEvent : ThemeTarget
{
	public SpriteEvent Event;

	public unsafe override void UpdateTarget(ThemeData theme)
	{
		//IL_0226: Expected O, but got Ref
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
			object obj9 = default(object);
			Sprite sprite = activeVariant2.GetSprite((Guid)(&obj9));
			((UnityEvent<object>)(object)Event).Invoke((object)sprite);
		}
	}

	private void Reset()
	{
		ThemeId = Guid.Empty;
		VariantId = Guid.Empty;
		PropertyId = Guid.Empty;
		if (Event == null)
		{
			SpriteEvent spriteEvent = (SpriteEvent)new UnityEventBase();
			_ = 0;
			Event = spriteEvent;
		}
	}

	private void UpdateReference()
	{
		if (Event == null)
		{
			SpriteEvent spriteEvent = (SpriteEvent)new UnityEventBase();
			_ = 0;
			Event = spriteEvent;
		}
	}
}
