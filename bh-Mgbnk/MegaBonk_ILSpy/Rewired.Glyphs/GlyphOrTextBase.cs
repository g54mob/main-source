using System;
using Cpp2ILInjected;
using UnityEngine;

namespace Rewired.Glyphs;

public abstract class GlyphOrTextBase : MonoBehaviour
{
	protected enum TypeFlags
	{
		None = 0,
		Glyph = 1,
		Text = 2,
		All = -1
	}

	protected abstract string textString { get; set; }

	public abstract void ShowText(string text);

	public abstract void ShowGlyph(object glyph);

	public virtual void Hide()
	{
		//IL_000f: Expected I4, but got I8
		Hide(TypeFlags.All);
	}

	protected abstract void Hide(TypeFlags flags);
}
public abstract class GlyphOrTextBase<TGlyphComponent, TGlyphGraphic, TTextComponent> : GlyphOrTextBase where TGlyphComponent : Behaviour where TGlyphGraphic : class where TTextComponent : Behaviour
{
	private TTextComponent _textComponent;

	private TGlyphComponent _glyphComponent;

	public TTextComponent textComponent
	{
		get
		{
			//IL_000d: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Rewired.Glyphs.GlyphOrTextBase`3<TGlyphComponent, TGlyphGraphic, TTextComponent>)+20]");
			return (TTextComponent)0;
		}
		set
		{
		}
	}

	public TGlyphComponent glyphComponent
	{
		get
		{
			//IL_000d: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Rewired.Glyphs.GlyphOrTextBase`3<TGlyphComponent, TGlyphGraphic, TTextComponent>)+28]");
			return (TGlyphComponent)0;
		}
		set
		{
		}
	}

	protected abstract TGlyphGraphic glyphGraphic { get; set; }

	public override void ShowText(string text)
	{
		//IL_0017: Expected O, but got I
		//IL_0077: Expected O, but got I
		//IL_00ac: Expected O, but got I
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Rewired.Glyphs.GlyphOrTextBase`3<TGlyphComponent, TGlyphGraphic, TTextComponent>)+20]");
		if (!((UnityEngine.Object)0 != null))
		{
			return;
		}
		string a = base.textString;
		if (!string.Equals(a, text, StringComparison.Ordinal))
		{
			base.textString = text;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Rewired.Glyphs.GlyphOrTextBase`3<TGlyphComponent, TGlyphGraphic, TTextComponent>)+20]");
		GameObject gameObject = ((Component)0).gameObject;
		if (!gameObject.activeSelf)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Rewired.Glyphs.GlyphOrTextBase`3<TGlyphComponent, TGlyphGraphic, TTextComponent>)+20]");
			GameObject gameObject2 = ((Component)0).gameObject;
			gameObject2.SetActive(value: true);
			GameObject gameObject3 = base.gameObject;
			if (!gameObject3.activeSelf)
			{
				GameObject gameObject4 = base.gameObject;
				gameObject4.SetActive(value: true);
			}
		}
		Hide(TypeFlags.Glyph);
	}

	public override void ShowGlyph(object glyph)
	{
		//IL_0056: Expected O, but got I
		if (glyph != null)
		{
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj = default(object);
			if (obj == null)
			{
				nint num2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v126 @ rbx_v4 (Il2CppRgctx<Rewired.Glyphs.GlyphOrTextBase`3>)+20]");
				Type typeFromHandle = Type.GetTypeFromHandle((RuntimeTypeHandle)0);
				string text = typeFromHandle.Name;
				string message = "Rewired: Glyph does not implement " + text + ".";
				Debug.LogError(message);
				return;
			}
		}
		nint num3 = 0;
		TGlyphGraphic glyph2;
		if (glyph == null)
		{
			glyph2 = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			TGlyphGraphic val = default(TGlyphGraphic);
			bool flag = val == null;
			glyph2 = val;
			if (flag)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
				throw new NullReferenceException();
			}
		}
		((GlyphOrTextBase<, , >)(object)this).ShowGlyph(glyph2);
	}

	public virtual void ShowGlyph(TGlyphGraphic glyph)
	{
		//IL_0017: Expected O, but got I
		//IL_002e: Expected I, but got O
		//IL_0079: Expected O, but got I
		//IL_0059: Expected I, but got O
		//IL_00ae: Expected O, but got I
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Rewired.Glyphs.GlyphOrTextBase`3<TGlyphComponent, TGlyphGraphic, TTextComponent>)+28]");
		if (!((UnityEngine.Object)0 != null))
		{
			return;
		}
		nint num = (nint)this;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v62 @ rax_v5 (Il2CppClass<Rewired.Glyphs.GlyphOrTextBase`3<TGlyphComponent, TGlyphGraphic, TTextComponent>>)+1D8] (should have been resolved before IL gen)");
		object obj = default(object);
		if (obj != glyph)
		{
			nint num2 = (nint)this;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v109 @ rax_v21 (Il2CppClass<Rewired.Glyphs.GlyphOrTextBase`3<TGlyphComponent, TGlyphGraphic, TTextComponent>>)+1E8] (should have been resolved before IL gen)");
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Rewired.Glyphs.GlyphOrTextBase`3<TGlyphComponent, TGlyphGraphic, TTextComponent>)+28]");
		GameObject gameObject = ((Component)0).gameObject;
		if (!gameObject.activeSelf)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Rewired.Glyphs.GlyphOrTextBase`3<TGlyphComponent, TGlyphGraphic, TTextComponent>)+28]");
			GameObject gameObject2 = ((Component)0).gameObject;
			gameObject2.SetActive(value: true);
			GameObject gameObject3 = base.gameObject;
			if (!gameObject3.activeSelf)
			{
				GameObject gameObject4 = base.gameObject;
				gameObject4.SetActive(value: true);
			}
		}
		Hide(TypeFlags.Text);
	}

	protected override void Hide(TypeFlags flags)
	{
		//IL_0017: Expected O, but got I
		//IL_00e3: Expected O, but got I
		//IL_0042: Expected O, but got I4
		//IL_01af: Expected O, but got I
		//IL_010e: Expected O, but got I4
		//IL_0070: Expected O, but got I
		//IL_01d2: Expected O, but got I
		//IL_013c: Expected O, but got I
		//IL_020d: Expected O, but got I
		//IL_00b0: Expected O, but got I
		//IL_0230: Expected O, but got I
		//IL_017c: Expected O, but got I
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Rewired.Glyphs.GlyphOrTextBase`3<TGlyphComponent, TGlyphGraphic, TTextComponent>)+20]");
		if ((UnityEngine.Object)0 != null)
		{
			object obj = flags & TypeFlags.Text;
			if (obj != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Rewired.Glyphs.GlyphOrTextBase`3<TGlyphComponent, TGlyphGraphic, TTextComponent>)+20]");
				GameObject gameObject = ((Component)0).gameObject;
				if (gameObject.activeSelf)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Rewired.Glyphs.GlyphOrTextBase`3<TGlyphComponent, TGlyphGraphic, TTextComponent>)+20]");
					GameObject gameObject2 = ((Component)0).gameObject;
					gameObject2.SetActive(value: false);
				}
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Rewired.Glyphs.GlyphOrTextBase`3<TGlyphComponent, TGlyphGraphic, TTextComponent>)+28]");
		if ((UnityEngine.Object)0 != null)
		{
			object obj2 = flags & TypeFlags.Glyph;
			if (obj2 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Rewired.Glyphs.GlyphOrTextBase`3<TGlyphComponent, TGlyphGraphic, TTextComponent>)+28]");
				GameObject gameObject3 = ((Component)0).gameObject;
				if (gameObject3.activeSelf)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Rewired.Glyphs.GlyphOrTextBase`3<TGlyphComponent, TGlyphGraphic, TTextComponent>)+28]");
					GameObject gameObject4 = ((Component)0).gameObject;
					gameObject4.SetActive(value: false);
				}
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Rewired.Glyphs.GlyphOrTextBase`3<TGlyphComponent, TGlyphGraphic, TTextComponent>)+28]");
		if ((UnityEngine.Object)0 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Rewired.Glyphs.GlyphOrTextBase`3<TGlyphComponent, TGlyphGraphic, TTextComponent>)+28]");
			GameObject gameObject5 = ((Component)0).gameObject;
			if (gameObject5.activeSelf)
			{
				return;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Rewired.Glyphs.GlyphOrTextBase`3<TGlyphComponent, TGlyphGraphic, TTextComponent>)+20]");
		if ((UnityEngine.Object)0 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Rewired.Glyphs.GlyphOrTextBase`3<TGlyphComponent, TGlyphGraphic, TTextComponent>)+20]");
			GameObject gameObject6 = ((Component)0).gameObject;
			if (gameObject6.activeSelf)
			{
				return;
			}
		}
		GameObject gameObject7 = base.gameObject;
		gameObject7.SetActive(value: false);
	}
}
