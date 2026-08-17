using System;
using System.Linq;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UI;

namespace Doozy.Engine.Themes;

public class FontTargetText : ThemeTarget
{
	public Text Text;

	public unsafe override void UpdateTarget(ThemeData theme)
	{
		//IL_02c7: Expected O, but got Ref
		Text text = Text;
		if ((object)Text == null || ((UnityEngine.Object)text).m_CachedPtr == (IntPtr)0 || (object)theme == null || ((UnityEngine.Object)theme).m_CachedPtr == (IntPtr)0)
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
			ThemeVariantData._003C_003Ec__DisplayClass41_0 obj9 = new ThemeVariantData._003C_003Ec__DisplayClass41_0();
			obj9.propertyId = PropertyId;
			Func<FontId, bool> func = null;
			bool flag = ((ThemeVariantData._003C_003Ec__DisplayClass41_0)(object)func)._003CContainsFont_003Eb__0((FontId)obj9);
			if (Enumerable.Any(activeVariant2.Fonts, func))
			{
				ThemeVariantData activeVariant3 = theme.ActiveVariant;
				Guid guid = default(Guid);
				Font font = activeVariant3.GetFont((Guid)(&guid));
				Text.font = font;
			}
		}
	}

	private void Reset()
	{
		ThemeId = Guid.Empty;
		VariantId = Guid.Empty;
		PropertyId = Guid.Empty;
		Text text = Text;
		if ((object)Text == null || ((UnityEngine.Object)text).m_CachedPtr == (IntPtr)0)
		{
			Text component = GetComponent<Text>();
			Text = component;
		}
	}

	private void UpdateReference()
	{
		Text text = Text;
		if ((object)Text == null || ((UnityEngine.Object)text).m_CachedPtr == (IntPtr)0)
		{
			Text component = GetComponent<Text>();
			Text = component;
		}
	}
}
