using System;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UI;

namespace Doozy.Engine.Themes;

public class TextureTargetRawImage : ThemeTarget
{
	public RawImage Image;

	public unsafe override void UpdateTarget(ThemeData theme)
	{
		//IL_0257: Expected O, but got Ref
		RawImage image = Image;
		if ((object)Image == null || ((UnityEngine.Object)image).m_CachedPtr == (IntPtr)0 || (object)theme == null || ((UnityEngine.Object)theme).m_CachedPtr == (IntPtr)0)
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
			Texture texture = activeVariant2.GetTexture((Guid)(&obj9));
			Image.texture = texture;
		}
	}

	private void Reset()
	{
		ThemeId = Guid.Empty;
		VariantId = Guid.Empty;
		PropertyId = Guid.Empty;
		RawImage image = Image;
		if ((object)Image == null || ((UnityEngine.Object)image).m_CachedPtr == (IntPtr)0)
		{
			RawImage component = GetComponent<RawImage>();
			Image = component;
		}
	}

	private void UpdateReference()
	{
		RawImage image = Image;
		if ((object)Image == null || ((UnityEngine.Object)image).m_CachedPtr == (IntPtr)0)
		{
			RawImage component = GetComponent<RawImage>();
			Image = component;
		}
	}
}
