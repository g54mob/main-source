using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UI;

namespace Doozy.Engine.Themes;

public class SpriteTargetSelectable : ThemeTarget
{
	public Guid HighlightedSpritePropertyId = Guid.Empty;

	public Guid PressedSpritePropertyId = Guid.Empty;

	public Guid SelectedSpritePropertyId = Guid.Empty;

	public Guid DisabledSpritePropertyId = Guid.Empty;

	public Selectable Selectable;

	private byte[] HighlightedPropertyIdSerializedGuid;

	private byte[] PressedPropertyIdSerializedGuid;

	private byte[] SelectedPropertyIdSerializedGuid;

	private byte[] DisabledPropertyIdSerializedGuid;

	protected unsafe override void OnValidate()
	{
		//IL_0418: Expected O, but got Ref
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
		if ((object)HighlightedSpritePropertyId == (object)Guid.Empty)
		{
			object obj5 = (object)Guid.Empty >> 32;
			object obj6 = (object)HighlightedSpritePropertyId >> 32;
			if (obj6 == obj5)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm3,8\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm2,8\"");
				if ((object)HighlightedSpritePropertyId == (object)Guid.Empty)
				{
					object obj7 = (object)Guid.Empty >> 32;
					object obj8 = (object)HighlightedSpritePropertyId >> 32;
					if (obj8 == obj7)
					{
						return;
					}
				}
			}
		}
		if ((object)PressedSpritePropertyId == (object)Guid.Empty)
		{
			object obj9 = (object)Guid.Empty >> 32;
			object obj10 = (object)PressedSpritePropertyId >> 32;
			if (obj10 == obj9)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm3,8\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm2,8\"");
				if ((object)PressedSpritePropertyId == (object)Guid.Empty)
				{
					object obj11 = (object)Guid.Empty >> 32;
					object obj12 = (object)PressedSpritePropertyId >> 32;
					if (obj12 == obj11)
					{
						return;
					}
				}
			}
		}
		if ((object)SelectedSpritePropertyId == (object)Guid.Empty)
		{
			object obj13 = (object)Guid.Empty >> 32;
			object obj14 = (object)SelectedSpritePropertyId >> 32;
			if (obj14 == obj13)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm3,8\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm2,8\"");
				if ((object)SelectedSpritePropertyId == (object)Guid.Empty)
				{
					object obj15 = (object)Guid.Empty >> 32;
					object obj16 = (object)SelectedSpritePropertyId >> 32;
					if (obj16 == obj15)
					{
						return;
					}
				}
			}
		}
		if ((object)DisabledSpritePropertyId == (object)Guid.Empty)
		{
			object obj17 = (object)Guid.Empty >> 32;
			object obj18 = (object)DisabledSpritePropertyId >> 32;
			if (obj18 == obj17)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm3,8\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm2,8\"");
				if ((object)DisabledSpritePropertyId == (object)Guid.Empty)
				{
					object obj19 = (object)Guid.Empty >> 32;
					object obj20 = (object)DisabledSpritePropertyId >> 32;
					if (obj20 == obj19)
					{
						return;
					}
				}
			}
		}
		ThemesDatabase database = ThemesSettings.Database;
		object obj21 = default(object);
		ThemeData themeData = database.GetThemeData((Guid)(&obj21));
		UpdateTarget(themeData);
	}

	public override void OnBeforeSerialize()
	{
		base.OnBeforeSerialize();
		byte[] highlightedPropertyIdSerializedGuid;
		if ((object)HighlightedSpritePropertyId == (object)Guid.Empty)
		{
			object obj = (object)HighlightedSpritePropertyId >> 32;
			object obj2 = (object)Guid.Empty >> 32;
			if (obj == obj2)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm1,8\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm2,8\"");
				if ((object)HighlightedSpritePropertyId == (object)Guid.Empty)
				{
					object obj3 = (object)HighlightedSpritePropertyId >> 32;
					object obj4 = (object)Guid.Empty >> 32;
					if (obj3 == obj4)
					{
						highlightedPropertyIdSerializedGuid = null;
						goto IL_00d9;
					}
				}
			}
		}
		Guid guid = default(Guid);
		highlightedPropertyIdSerializedGuid = guid.ToByteArray();
		goto IL_00d9;
		IL_00d9:
		HighlightedPropertyIdSerializedGuid = highlightedPropertyIdSerializedGuid;
		byte[] pressedPropertyIdSerializedGuid;
		if ((object)PressedSpritePropertyId == (object)Guid.Empty)
		{
			object obj5 = (object)PressedSpritePropertyId >> 32;
			object obj6 = (object)Guid.Empty >> 32;
			if (obj5 == obj6)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm1,8\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm2,8\"");
				if ((object)PressedSpritePropertyId == (object)Guid.Empty)
				{
					object obj7 = (object)PressedSpritePropertyId >> 32;
					object obj8 = (object)Guid.Empty >> 32;
					if (obj7 == obj8)
					{
						pressedPropertyIdSerializedGuid = null;
						goto IL_01bb;
					}
				}
			}
		}
		Guid guid2 = default(Guid);
		pressedPropertyIdSerializedGuid = guid2.ToByteArray();
		goto IL_01bb;
		IL_0408:
		byte[] disabledPropertyIdSerializedGuid;
		DisabledPropertyIdSerializedGuid = disabledPropertyIdSerializedGuid;
		return;
		IL_01bb:
		PressedPropertyIdSerializedGuid = pressedPropertyIdSerializedGuid;
		byte[] selectedPropertyIdSerializedGuid;
		if ((object)SelectedSpritePropertyId == (object)Guid.Empty)
		{
			object obj9 = (object)SelectedSpritePropertyId >> 32;
			object obj10 = (object)Guid.Empty >> 32;
			if (obj9 == obj10)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm1,8\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm2,8\"");
				if ((object)SelectedSpritePropertyId == (object)Guid.Empty)
				{
					object obj11 = (object)SelectedSpritePropertyId >> 32;
					object obj12 = (object)Guid.Empty >> 32;
					if (obj11 == obj12)
					{
						selectedPropertyIdSerializedGuid = null;
						goto IL_029d;
					}
				}
			}
		}
		selectedPropertyIdSerializedGuid = guid2.ToByteArray();
		goto IL_029d;
		IL_029d:
		SelectedPropertyIdSerializedGuid = selectedPropertyIdSerializedGuid;
		if ((object)DisabledSpritePropertyId == (object)Guid.Empty)
		{
			object obj13 = (object)DisabledSpritePropertyId >> 32;
			object obj14 = (object)Guid.Empty >> 32;
			if (obj13 == obj14)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm1,8\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm2,8\"");
				if ((object)DisabledSpritePropertyId == (object)Guid.Empty)
				{
					object obj15 = (object)DisabledSpritePropertyId >> 32;
					object obj16 = (object)Guid.Empty >> 32;
					bool flag = obj15 == obj16;
					disabledPropertyIdSerializedGuid = null;
					if (flag)
					{
						goto IL_0408;
					}
				}
			}
		}
		byte[] array = guid2.ToByteArray();
		disabledPropertyIdSerializedGuid = array;
		goto IL_0408;
	}

	public unsafe override void OnAfterDeserialize()
	{
		//IL_0131: Unknown result type (might be due to invalid IL or missing references)
		//IL_0136: Expected O, but got Unknown
		//IL_0144: Unknown result type (might be due to invalid IL or missing references)
		//IL_0149: Expected O, but got Unknown
		//IL_0152: Unknown result type (might be due to invalid IL or missing references)
		//IL_0157: Expected O, but got Unknown
		//IL_0173: Expected native int or pointer, but got O
		//IL_0188: Expected O, but got I
		//IL_01b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bc: Expected O, but got Unknown
		//IL_01ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cf: Expected O, but got Unknown
		//IL_01d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01dd: Expected O, but got Unknown
		//IL_01f9: Expected native int or pointer, but got O
		//IL_020e: Expected O, but got I
		//IL_023d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0242: Expected O, but got Unknown
		//IL_0250: Unknown result type (might be due to invalid IL or missing references)
		//IL_0255: Expected O, but got Unknown
		//IL_025e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0263: Expected O, but got Unknown
		//IL_027f: Expected native int or pointer, but got O
		//IL_0294: Expected O, but got I
		//IL_02c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c8: Expected O, but got Unknown
		//IL_02d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02db: Expected O, but got Unknown
		//IL_02e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e9: Expected O, but got Unknown
		//IL_0305: Expected native int or pointer, but got O
		//IL_031a: Expected O, but got I
		base.OnAfterDeserialize();
		byte[] highlightedPropertyIdSerializedGuid = HighlightedPropertyIdSerializedGuid;
		object obj2 = default(object);
		Guid highlightedSpritePropertyId;
		if (HighlightedPropertyIdSerializedGuid != null && highlightedPropertyIdSerializedGuid.Length == 16)
		{
			_ = 0;
			_ = 0;
			object obj = HighlightedPropertyIdSerializedGuid + 32;
			ReadOnlySpan<byte> b = (ReadOnlySpan<byte>)(obj2 - 32);
			Guid guid = (Guid)(obj2 - 16);
			_ = highlightedPropertyIdSerializedGuid.Length;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rsp-20]");
			_ = 0;
			*(Guid*)(nint)guid = new Guid(b);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rsp-10]");
			highlightedSpritePropertyId = (Guid)0;
		}
		else
		{
			highlightedSpritePropertyId = Guid.Empty;
		}
		byte[] pressedPropertyIdSerializedGuid = PressedPropertyIdSerializedGuid;
		HighlightedSpritePropertyId = highlightedSpritePropertyId;
		Guid pressedSpritePropertyId;
		if (PressedPropertyIdSerializedGuid != null && pressedPropertyIdSerializedGuid.Length == 16)
		{
			_ = 0;
			_ = 0;
			object obj3 = PressedPropertyIdSerializedGuid + 32;
			ReadOnlySpan<byte> b2 = (ReadOnlySpan<byte>)(obj2 - 32);
			Guid guid2 = (Guid)(obj2 - 16);
			_ = pressedPropertyIdSerializedGuid.Length;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rsp-20]");
			_ = 0;
			*(Guid*)(nint)guid2 = new Guid(b2);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rsp-10]");
			pressedSpritePropertyId = (Guid)0;
		}
		else
		{
			pressedSpritePropertyId = Guid.Empty;
		}
		byte[] selectedPropertyIdSerializedGuid = SelectedPropertyIdSerializedGuid;
		PressedSpritePropertyId = pressedSpritePropertyId;
		Guid selectedSpritePropertyId;
		if (SelectedPropertyIdSerializedGuid != null && selectedPropertyIdSerializedGuid.Length == 16)
		{
			_ = 0;
			_ = 0;
			object obj4 = SelectedPropertyIdSerializedGuid + 32;
			ReadOnlySpan<byte> b3 = (ReadOnlySpan<byte>)(obj2 - 32);
			Guid guid3 = (Guid)(obj2 - 16);
			_ = selectedPropertyIdSerializedGuid.Length;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rsp-20]");
			_ = 0;
			*(Guid*)(nint)guid3 = new Guid(b3);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rsp-10]");
			selectedSpritePropertyId = (Guid)0;
		}
		else
		{
			selectedSpritePropertyId = Guid.Empty;
		}
		byte[] disabledPropertyIdSerializedGuid = DisabledPropertyIdSerializedGuid;
		SelectedSpritePropertyId = selectedSpritePropertyId;
		Guid disabledSpritePropertyId;
		if (DisabledPropertyIdSerializedGuid != null && disabledPropertyIdSerializedGuid.Length == 16)
		{
			_ = 0;
			_ = 0;
			object obj5 = DisabledPropertyIdSerializedGuid + 32;
			ReadOnlySpan<byte> b4 = (ReadOnlySpan<byte>)(obj2 - 32);
			Guid guid4 = (Guid)(obj2 - 16);
			_ = disabledPropertyIdSerializedGuid.Length;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rsp-20]");
			_ = 0;
			*(Guid*)(nint)guid4 = new Guid(b4);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rsp-10]");
			disabledSpritePropertyId = (Guid)0;
		}
		else
		{
			disabledSpritePropertyId = Guid.Empty;
		}
		DisabledSpritePropertyId = disabledSpritePropertyId;
	}

	public unsafe override void UpdateTarget(ThemeData theme)
	{
		//IL_027b: Expected O, but got Ref
		//IL_0284: Expected I, but got O
		//IL_0383: Expected O, but got Ref
		//IL_038c: Expected I, but got O
		//IL_04bd: Expected O, but got Ref
		//IL_04c6: Expected I, but got O
		//IL_04e0: Expected O, but got I
		//IL_05cd: Expected O, but got Ref
		//IL_05d6: Expected I, but got O
		//IL_0711: Unknown result type (might be due to invalid IL or missing references)
		//IL_0716: Expected O, but got Unknown
		//IL_0489: Expected O, but got I
		//IL_0499: Expected O, but got I
		//IL_060f: Expected I, but got O
		Selectable selectable = Selectable;
		if ((object)Selectable == null || ((UnityEngine.Object)selectable).m_CachedPtr == (IntPtr)0 || (object)theme == null || ((UnityEngine.Object)theme).m_CachedPtr == (IntPtr)0)
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
		ThemeVariantData activeVariant = theme.ActiveVariant;
		if (activeVariant == null)
		{
			return;
		}
		Selectable selectable2 = Selectable;
		Sprite spriteState;
		if ((object)HighlightedSpritePropertyId == (object)Guid.Empty)
		{
			object obj5 = (object)Guid.Empty >> 32;
			object obj6 = (object)HighlightedSpritePropertyId >> 32;
			if (obj6 == obj5)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm3,8\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm2,8\"");
				if ((object)HighlightedSpritePropertyId == (object)Guid.Empty)
				{
					object obj7 = (object)Guid.Empty >> 32;
					object obj8 = (object)HighlightedSpritePropertyId >> 32;
					if (obj8 == obj7)
					{
						spriteState = (Sprite)selectable2.m_SpriteState;
						goto IL_06b0;
					}
				}
			}
		}
		ThemeVariantData activeVariant2 = theme.ActiveVariant;
		object obj9 = default(object);
		spriteState = activeVariant2.GetSprite((Guid)(&obj9));
		nint num = unchecked((nint)null);
		goto IL_06b0;
		IL_06b0:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181BF4FF0");
		Guid guid;
		Sprite spriteState2;
		if ((object)PressedSpritePropertyId == (object)Guid.Empty)
		{
			object obj10 = (object)Guid.Empty >> 32;
			object obj11 = (object)PressedSpritePropertyId >> 32;
			if (obj11 == obj10)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm3,8\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm2,8\"");
				if ((object)PressedSpritePropertyId == (object)Guid.Empty)
				{
					object obj12 = (object)Guid.Empty >> 32;
					object obj13 = (object)PressedSpritePropertyId >> 32;
					if (obj13 == obj12)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm4,8\"");
						guid = (Guid)selectable2.m_SpriteState;
						spriteState2 = (Sprite)selectable2.m_SpriteState;
						goto IL_039b;
					}
				}
			}
		}
		ThemeVariantData activeVariant3 = theme.ActiveVariant;
		Sprite sprite = default(Sprite);
		spriteState2 = activeVariant3.GetSprite((Guid)(&sprite));
		num = unchecked((nint)null);
		guid = PressedSpritePropertyId;
		goto IL_039b;
		IL_05e5:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181BA83C0");
		object obj14 = selectable2 + 176;
		EqualityComparer<SpriteState> equalityComparer = EqualityComparer<SpriteState>.Default;
		nint num2 = (nint)equalityComparer;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v996 @ r9_v6 (Il2CppClass<System.Collections.Generic.EqualityComparer`1<UnityEngine.UI.SpriteState>>)+1B8] (should have been resolved before IL gen)");
		object obj15 = default(object);
		if (obj15 == null)
		{
			object obj16 = default(object);
			obj14 = obj16;
			_ = 0;
			selectable2.OnSetProperty();
		}
		return;
		IL_039b:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181BF5D90");
		Sprite sprite2;
		Sprite sprite3;
		if ((object)SelectedSpritePropertyId == (object)Guid.Empty)
		{
			object obj17 = (object)Guid.Empty >> 32;
			object obj18 = (object)SelectedSpritePropertyId >> 32;
			if (obj18 == obj17)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm3,8\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm2,8\"");
				if ((object)SelectedSpritePropertyId == (object)Guid.Empty)
				{
					object obj19 = (object)Guid.Empty >> 32;
					object obj20 = (object)SelectedSpritePropertyId >> 32;
					if (obj20 == obj19)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v480 @ rax_v17 (UnityEngine.UI.Selectable)+C0]");
						sprite2 = (Sprite)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v480 @ rax_v17 (UnityEngine.UI.Selectable)+C0]");
						sprite3 = (Sprite)0;
						goto IL_06dc;
					}
				}
			}
		}
		ThemeVariantData activeVariant4 = theme.ActiveVariant;
		sprite3 = activeVariant4.GetSprite((Guid)(&guid));
		num = unchecked((nint)null);
		guid = SelectedSpritePropertyId;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v480 @ rax_v17 (UnityEngine.UI.Selectable)+C0]");
		sprite2 = (Sprite)0;
		goto IL_06dc;
		IL_06dc:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181BA8A50");
		Sprite sprite4;
		if ((object)DisabledSpritePropertyId == (object)Guid.Empty)
		{
			object obj21 = (object)Guid.Empty >> 32;
			object obj22 = (object)DisabledSpritePropertyId >> 32;
			if (obj22 == obj21)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm3,8\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm2,8\"");
				if ((object)DisabledSpritePropertyId == (object)Guid.Empty)
				{
					object obj23 = (object)Guid.Empty >> 32;
					object obj24 = (object)DisabledSpritePropertyId >> 32;
					if (obj24 == obj23)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm4,8\"");
						sprite4 = sprite2;
						goto IL_05e5;
					}
				}
			}
		}
		ThemeVariantData activeVariant5 = theme.ActiveVariant;
		sprite4 = activeVariant5.GetSprite((Guid)(&guid));
		num = unchecked((nint)null);
		guid = DisabledSpritePropertyId;
		goto IL_05e5;
	}

	private void Reset()
	{
		ThemeId = Guid.Empty;
		VariantId = Guid.Empty;
		PropertyId = Guid.Empty;
		HighlightedSpritePropertyId = Guid.Empty;
		PressedSpritePropertyId = Guid.Empty;
		SelectedSpritePropertyId = Guid.Empty;
		DisabledSpritePropertyId = Guid.Empty;
		Selectable selectable = Selectable;
		if ((object)Selectable == null || ((UnityEngine.Object)selectable).m_CachedPtr == (IntPtr)0)
		{
			Selectable component = GetComponent<Selectable>();
			Selectable = component;
		}
	}

	private void UpdateReference()
	{
		Selectable selectable = Selectable;
		if ((object)Selectable == null || ((UnityEngine.Object)selectable).m_CachedPtr == (IntPtr)0)
		{
			Selectable component = GetComponent<Selectable>();
			Selectable = component;
		}
	}
}
