using System;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UI;

namespace Doozy.Engine.Themes;

public class ColorTargetImage : ThemeTarget
{
	public Image Image;

	public bool OverrideAlpha;

	public float Alpha;

	private float m_previousAlphaValue = -1f;

	private void Update()
	{
		if (OverrideAlpha)
		{
			bool flag = Alpha == m_previousAlphaValue;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000182C02D0Ch\"");
			if (!flag)
			{
				SetAlpha(Alpha);
				m_previousAlphaValue = Alpha;
			}
		}
	}

	public unsafe override void UpdateTarget(ThemeData theme)
	{
		//IL_0258: Expected O, but got Ref
		//IL_0270: Expected O, but got Ref
		Image image = Image;
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
			Guid guid = default(Guid);
			Color color = activeVariant2.GetColor((Guid)(&guid));
			Image.color = (Color)(&guid);
			if (OverrideAlpha)
			{
				SetAlpha(Alpha);
			}
		}
	}

	public unsafe void SetAlpha(float value)
	{
		//IL_0068: Expected O, but got Ref
		Image image = Image;
		if ((object)Image != null && ((UnityEngine.Object)image).m_CachedPtr != (IntPtr)0)
		{
			Alpha = value;
			Color color = Image.color;
			object obj = default(object);
			Image.color = (Color)(&obj);
		}
	}

	private void Reset()
	{
		ThemeId = Guid.Empty;
		VariantId = Guid.Empty;
		PropertyId = Guid.Empty;
		Image image = Image;
		if ((object)Image == null || ((UnityEngine.Object)image).m_CachedPtr == (IntPtr)0)
		{
			Image component = GetComponent<Image>();
			Image = component;
		}
	}

	private void UpdateReference()
	{
		Image image = Image;
		if ((object)Image == null || ((UnityEngine.Object)image).m_CachedPtr == (IntPtr)0)
		{
			Image component = GetComponent<Image>();
			Image = component;
		}
	}
}
