using System;
using Cpp2ILInjected;
using UnityEngine;

namespace Doozy.Engine.Themes;

public class ColorTargetSpriteRenderer : ThemeTarget
{
	public SpriteRenderer SpriteRenderer;

	public bool OverrideAlpha;

	public float Alpha;

	private float m_previousAlphaValue = -1f;

	private void Update()
	{
		if (OverrideAlpha)
		{
			bool flag = Alpha == m_previousAlphaValue;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000182C05A5Ch\"");
			if (!flag)
			{
				SetAlpha(Alpha);
				m_previousAlphaValue = Alpha;
			}
		}
	}

	public unsafe override void UpdateTarget(ThemeData theme)
	{
		//IL_0261: Expected O, but got Ref
		//IL_032b->IL0285: Incompatible stack heights: 1 vs 0
		//IL_0285->IL0285: Incompatible stack heights: 1 vs 0
		SpriteRenderer spriteRenderer = SpriteRenderer;
		if ((object)SpriteRenderer == null || ((UnityEngine.Object)spriteRenderer).m_CachedPtr == (IntPtr)0 || (object)theme == null || ((UnityEngine.Object)theme).m_CachedPtr == (IntPtr)0)
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
			object spriteRenderer2 = SpriteRenderer;
			ThemeVariantData activeVariant2 = theme.ActiveVariant;
			float value = default(float);
			Color color = activeVariant2.GetColor((Guid)(&value));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v136 @ rsi_v4 (System.Object)+10]");
			bool flag = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v136 @ rsi_v4 (System.Object)+10]");
			SpriteRenderer.set_color_Injected((IntPtr)0, ref *(Color*)(&value));
			if (OverrideAlpha)
			{
				SetAlpha(Alpha);
			}
		}
	}

	public void SetAlpha(float value)
	{
		//IL_0121->IL0096: Incompatible stack heights: 3 vs 0
		SpriteRenderer spriteRenderer = SpriteRenderer;
		if ((object)SpriteRenderer != null && ((UnityEngine.Object)spriteRenderer).m_CachedPtr != (IntPtr)0)
		{
			SpriteRenderer spriteRenderer2 = SpriteRenderer;
			Alpha = value;
			bool flag = ((UnityEngine.Object)spriteRenderer2).m_CachedPtr == (IntPtr)0;
			SpriteRenderer.get_color_Injected(((UnityEngine.Object)spriteRenderer2).m_CachedPtr, out Color _);
			SpriteRenderer spriteRenderer3 = SpriteRenderer;
			bool flag2 = (object)SpriteRenderer == null;
			bool flag3 = ((UnityEngine.Object)spriteRenderer3).m_CachedPtr == (IntPtr)0;
			Color value2 = default(Color);
			SpriteRenderer.set_color_Injected(((UnityEngine.Object)spriteRenderer3).m_CachedPtr, ref value2);
		}
	}

	private void Reset()
	{
		ThemeId = Guid.Empty;
		VariantId = Guid.Empty;
		PropertyId = Guid.Empty;
		SpriteRenderer spriteRenderer = SpriteRenderer;
		if ((object)SpriteRenderer == null || ((UnityEngine.Object)spriteRenderer).m_CachedPtr == (IntPtr)0)
		{
			SpriteRenderer component = GetComponent<SpriteRenderer>();
			SpriteRenderer = component;
		}
	}

	private void UpdateReference()
	{
		SpriteRenderer spriteRenderer = SpriteRenderer;
		if ((object)SpriteRenderer == null || ((UnityEngine.Object)spriteRenderer).m_CachedPtr == (IntPtr)0)
		{
			SpriteRenderer component = GetComponent<SpriteRenderer>();
			SpriteRenderer = component;
		}
	}
}
