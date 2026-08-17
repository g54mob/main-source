using System;
using Cpp2ILInjected;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Rewired.Glyphs.UnityUI;

public class UnityUIGlyphOrTextTMPro : GlyphOrTextBase<Image, Sprite, TMP_Text>
{
	protected override string textString
	{
		get
		{
			//IL_0017: Expected O, but got I
			//IL_0090: Expected O, but got I
			//IL_00a0: Expected O, but got I
			//IL_0044: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Rewired.Glyphs.UnityUI.UnityUIGlyphOrTextTMPro)+20]");
			if ((UnityEngine.Object)0 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Rewired.Glyphs.UnityUI.UnityUIGlyphOrTextTMPro)+20]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Rewired.Glyphs.UnityUI.UnityUIGlyphOrTextTMPro)+20]");
				if ((nint)0 != 0)
				{
					object obj2 = obj;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v76 @ rax_v8+548] (should have been resolved before IL gen)");
					string result = default(string);
					return result;
				}
				return (string)(object)new NullReferenceException();
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183185B70]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v71 @ rax_v4+B8]");
			return (string)0;
		}
		set
		{
			//IL_0017: Expected O, but got I
			//IL_0039: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Rewired.Glyphs.UnityUI.UnityUIGlyphOrTextTMPro)+20]");
			if ((UnityEngine.Object)0 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Rewired.Glyphs.UnityUI.UnityUIGlyphOrTextTMPro)+20]");
				object obj = 0;
				object obj2 = obj;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v95 @ rax_v6+558] (should have been resolved before IL gen)");
			}
		}
	}

	protected override Sprite glyphGraphic
	{
		get
		{
			//IL_0017: Expected O, but got I
			//IL_0044: Expected O, but got I
			//IL_0076: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Rewired.Glyphs.UnityUI.UnityUIGlyphOrTextTMPro)+28]");
			if ((UnityEngine.Object)0 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Rewired.Glyphs.UnityUI.UnityUIGlyphOrTextTMPro)+28]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Rewired.Glyphs.UnityUI.UnityUIGlyphOrTextTMPro)+28]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v60 @ rax_v5+E0]");
					return (Sprite)0;
				}
				return (Sprite)(object)new NullReferenceException();
			}
			return null;
		}
		set
		{
			//IL_0017: Expected O, but got I
			//IL_003e: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Rewired.Glyphs.UnityUI.UnityUIGlyphOrTextTMPro)+28]");
			if ((UnityEngine.Object)0 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Rewired.Glyphs.UnityUI.UnityUIGlyphOrTextTMPro)+28]");
				((Image)0).sprite = value;
			}
		}
	}
}
