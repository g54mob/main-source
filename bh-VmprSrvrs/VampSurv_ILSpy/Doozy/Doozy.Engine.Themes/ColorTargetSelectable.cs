using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UI;

namespace Doozy.Engine.Themes;

public class ColorTargetSelectable : ThemeTarget
{
	public Guid NormalColorPropertyId = Guid.Empty;

	public Guid HighlightedColorPropertyId = Guid.Empty;

	public Guid PressedColorPropertyId = Guid.Empty;

	public Guid SelectedColorPropertyId = Guid.Empty;

	public Guid DisabledColorPropertyId = Guid.Empty;

	public Selectable Selectable;

	private byte[] NormalPropertyIdSerializedGuid;

	private byte[] HighlightedPropertyIdSerializedGuid;

	private byte[] PressedPropertyIdSerializedGuid;

	private byte[] SelectedPropertyIdSerializedGuid;

	private byte[] DisabledPropertyIdSerializedGuid;

	protected unsafe override void OnValidate()
	{
		//IL_04e9: Expected O, but got Ref
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
		if ((object)NormalColorPropertyId == (object)Guid.Empty)
		{
			object obj5 = (object)Guid.Empty >> 32;
			object obj6 = (object)NormalColorPropertyId >> 32;
			if (obj6 == obj5)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm3,8\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm2,8\"");
				if ((object)NormalColorPropertyId == (object)Guid.Empty)
				{
					object obj7 = (object)Guid.Empty >> 32;
					object obj8 = (object)NormalColorPropertyId >> 32;
					if (obj8 == obj7)
					{
						return;
					}
				}
			}
		}
		if ((object)HighlightedColorPropertyId == (object)Guid.Empty)
		{
			object obj9 = (object)Guid.Empty >> 32;
			object obj10 = (object)HighlightedColorPropertyId >> 32;
			if (obj10 == obj9)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm3,8\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm2,8\"");
				if ((object)HighlightedColorPropertyId == (object)Guid.Empty)
				{
					object obj11 = (object)Guid.Empty >> 32;
					object obj12 = (object)HighlightedColorPropertyId >> 32;
					if (obj12 == obj11)
					{
						return;
					}
				}
			}
		}
		if ((object)PressedColorPropertyId == (object)Guid.Empty)
		{
			object obj13 = (object)Guid.Empty >> 32;
			object obj14 = (object)PressedColorPropertyId >> 32;
			if (obj14 == obj13)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm3,8\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm2,8\"");
				if ((object)PressedColorPropertyId == (object)Guid.Empty)
				{
					object obj15 = (object)Guid.Empty >> 32;
					object obj16 = (object)PressedColorPropertyId >> 32;
					if (obj16 == obj15)
					{
						return;
					}
				}
			}
		}
		if ((object)SelectedColorPropertyId == (object)Guid.Empty)
		{
			object obj17 = (object)Guid.Empty >> 32;
			object obj18 = (object)SelectedColorPropertyId >> 32;
			if (obj18 == obj17)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm3,8\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm2,8\"");
				if ((object)SelectedColorPropertyId == (object)Guid.Empty)
				{
					object obj19 = (object)Guid.Empty >> 32;
					object obj20 = (object)SelectedColorPropertyId >> 32;
					if (obj20 == obj19)
					{
						return;
					}
				}
			}
		}
		if ((object)DisabledColorPropertyId == (object)Guid.Empty)
		{
			object obj21 = (object)Guid.Empty >> 32;
			object obj22 = (object)DisabledColorPropertyId >> 32;
			if (obj22 == obj21)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm3,8\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm2,8\"");
				if ((object)DisabledColorPropertyId == (object)Guid.Empty)
				{
					object obj23 = (object)Guid.Empty >> 32;
					object obj24 = (object)DisabledColorPropertyId >> 32;
					if (obj24 == obj23)
					{
						return;
					}
				}
			}
		}
		ThemesDatabase database = ThemesSettings.Database;
		object obj25 = default(object);
		ThemeData themeData = database.GetThemeData((Guid)(&obj25));
		UpdateTarget(themeData);
	}

	public override void OnBeforeSerialize()
	{
		base.OnBeforeSerialize();
		byte[] normalPropertyIdSerializedGuid;
		if ((object)NormalColorPropertyId == (object)Guid.Empty)
		{
			object obj = (object)NormalColorPropertyId >> 32;
			object obj2 = (object)Guid.Empty >> 32;
			if (obj == obj2)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm1,8\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm2,8\"");
				if ((object)NormalColorPropertyId == (object)Guid.Empty)
				{
					object obj3 = (object)NormalColorPropertyId >> 32;
					object obj4 = (object)Guid.Empty >> 32;
					if (obj3 == obj4)
					{
						normalPropertyIdSerializedGuid = null;
						goto IL_00d9;
					}
				}
			}
		}
		Guid guid = default(Guid);
		normalPropertyIdSerializedGuid = guid.ToByteArray();
		goto IL_00d9;
		IL_01bb:
		byte[] highlightedPropertyIdSerializedGuid;
		HighlightedPropertyIdSerializedGuid = highlightedPropertyIdSerializedGuid;
		byte[] pressedPropertyIdSerializedGuid;
		if ((object)PressedColorPropertyId == (object)Guid.Empty)
		{
			object obj5 = (object)PressedColorPropertyId >> 32;
			object obj6 = (object)Guid.Empty >> 32;
			if (obj5 == obj6)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm1,8\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm2,8\"");
				if ((object)PressedColorPropertyId == (object)Guid.Empty)
				{
					object obj7 = (object)PressedColorPropertyId >> 32;
					object obj8 = (object)Guid.Empty >> 32;
					if (obj7 == obj8)
					{
						pressedPropertyIdSerializedGuid = null;
						goto IL_029d;
					}
				}
			}
		}
		Guid guid2 = default(Guid);
		pressedPropertyIdSerializedGuid = guid2.ToByteArray();
		goto IL_029d;
		IL_050c:
		byte[] disabledPropertyIdSerializedGuid;
		DisabledPropertyIdSerializedGuid = disabledPropertyIdSerializedGuid;
		return;
		IL_029d:
		PressedPropertyIdSerializedGuid = pressedPropertyIdSerializedGuid;
		byte[] selectedPropertyIdSerializedGuid;
		if ((object)SelectedColorPropertyId == (object)Guid.Empty)
		{
			object obj9 = (object)SelectedColorPropertyId >> 32;
			object obj10 = (object)Guid.Empty >> 32;
			if (obj9 == obj10)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm1,8\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm2,8\"");
				if ((object)SelectedColorPropertyId == (object)Guid.Empty)
				{
					object obj11 = (object)SelectedColorPropertyId >> 32;
					object obj12 = (object)Guid.Empty >> 32;
					if (obj11 == obj12)
					{
						selectedPropertyIdSerializedGuid = null;
						goto IL_037f;
					}
				}
			}
		}
		selectedPropertyIdSerializedGuid = guid2.ToByteArray();
		goto IL_037f;
		IL_00d9:
		NormalPropertyIdSerializedGuid = normalPropertyIdSerializedGuid;
		if ((object)HighlightedColorPropertyId == (object)Guid.Empty)
		{
			object obj13 = (object)HighlightedColorPropertyId >> 32;
			object obj14 = (object)Guid.Empty >> 32;
			if (obj13 == obj14)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm1,8\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm2,8\"");
				if ((object)HighlightedColorPropertyId == (object)Guid.Empty)
				{
					object obj15 = (object)HighlightedColorPropertyId >> 32;
					object obj16 = (object)Guid.Empty >> 32;
					if (obj15 == obj16)
					{
						highlightedPropertyIdSerializedGuid = null;
						goto IL_01bb;
					}
				}
			}
		}
		highlightedPropertyIdSerializedGuid = guid2.ToByteArray();
		goto IL_01bb;
		IL_037f:
		SelectedPropertyIdSerializedGuid = selectedPropertyIdSerializedGuid;
		if ((object)DisabledColorPropertyId == (object)Guid.Empty)
		{
			object obj17 = (object)DisabledColorPropertyId >> 32;
			object obj18 = (object)Guid.Empty >> 32;
			if (obj17 == obj18)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm1,8\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm2,8\"");
				if ((object)DisabledColorPropertyId == (object)Guid.Empty)
				{
					object obj19 = (object)DisabledColorPropertyId >> 32;
					object obj20 = (object)Guid.Empty >> 32;
					bool flag = obj19 == obj20;
					disabledPropertyIdSerializedGuid = null;
					if (flag)
					{
						goto IL_050c;
					}
				}
			}
		}
		byte[] array = guid2.ToByteArray();
		disabledPropertyIdSerializedGuid = array;
		goto IL_050c;
	}

	public unsafe override void OnAfterDeserialize()
	{
		//IL_016c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0171: Expected O, but got Unknown
		//IL_017f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0184: Expected O, but got Unknown
		//IL_018d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0192: Expected O, but got Unknown
		//IL_01ae: Expected native int or pointer, but got O
		//IL_01c3: Expected O, but got I
		//IL_01f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f7: Expected O, but got Unknown
		//IL_0205: Unknown result type (might be due to invalid IL or missing references)
		//IL_020a: Expected O, but got Unknown
		//IL_0213: Unknown result type (might be due to invalid IL or missing references)
		//IL_0218: Expected O, but got Unknown
		//IL_0234: Expected native int or pointer, but got O
		//IL_0249: Expected O, but got I
		//IL_0278: Unknown result type (might be due to invalid IL or missing references)
		//IL_027d: Expected O, but got Unknown
		//IL_028b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0290: Expected O, but got Unknown
		//IL_0299: Unknown result type (might be due to invalid IL or missing references)
		//IL_029e: Expected O, but got Unknown
		//IL_02ba: Expected native int or pointer, but got O
		//IL_02cf: Expected O, but got I
		//IL_02fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0303: Expected O, but got Unknown
		//IL_0311: Unknown result type (might be due to invalid IL or missing references)
		//IL_0316: Expected O, but got Unknown
		//IL_031f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0324: Expected O, but got Unknown
		//IL_0340: Expected native int or pointer, but got O
		//IL_0355: Expected O, but got I
		//IL_0384: Unknown result type (might be due to invalid IL or missing references)
		//IL_0389: Expected O, but got Unknown
		//IL_0397: Unknown result type (might be due to invalid IL or missing references)
		//IL_039c: Expected O, but got Unknown
		//IL_03a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_03aa: Expected O, but got Unknown
		//IL_03c6: Expected native int or pointer, but got O
		//IL_03db: Expected O, but got I
		base.OnAfterDeserialize();
		byte[] normalPropertyIdSerializedGuid = NormalPropertyIdSerializedGuid;
		object obj2 = default(object);
		Guid normalColorPropertyId;
		if (NormalPropertyIdSerializedGuid != null && normalPropertyIdSerializedGuid.Length == 16)
		{
			_ = 0;
			_ = 0;
			object obj = NormalPropertyIdSerializedGuid + 32;
			ReadOnlySpan<byte> b = (ReadOnlySpan<byte>)(obj2 - 32);
			Guid guid = (Guid)(obj2 - 16);
			_ = normalPropertyIdSerializedGuid.Length;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rsp-20]");
			_ = 0;
			*(Guid*)(nint)guid = new Guid(b);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rsp-10]");
			normalColorPropertyId = (Guid)0;
		}
		else
		{
			normalColorPropertyId = Guid.Empty;
		}
		byte[] highlightedPropertyIdSerializedGuid = HighlightedPropertyIdSerializedGuid;
		NormalColorPropertyId = normalColorPropertyId;
		Guid highlightedColorPropertyId;
		if (HighlightedPropertyIdSerializedGuid != null && highlightedPropertyIdSerializedGuid.Length == 16)
		{
			_ = 0;
			_ = 0;
			object obj3 = HighlightedPropertyIdSerializedGuid + 32;
			ReadOnlySpan<byte> b2 = (ReadOnlySpan<byte>)(obj2 - 32);
			Guid guid2 = (Guid)(obj2 - 16);
			_ = highlightedPropertyIdSerializedGuid.Length;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rsp-20]");
			_ = 0;
			*(Guid*)(nint)guid2 = new Guid(b2);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rsp-10]");
			highlightedColorPropertyId = (Guid)0;
		}
		else
		{
			highlightedColorPropertyId = Guid.Empty;
		}
		byte[] pressedPropertyIdSerializedGuid = PressedPropertyIdSerializedGuid;
		HighlightedColorPropertyId = highlightedColorPropertyId;
		Guid pressedColorPropertyId;
		if (PressedPropertyIdSerializedGuid != null && pressedPropertyIdSerializedGuid.Length == 16)
		{
			_ = 0;
			_ = 0;
			object obj4 = PressedPropertyIdSerializedGuid + 32;
			ReadOnlySpan<byte> b3 = (ReadOnlySpan<byte>)(obj2 - 32);
			Guid guid3 = (Guid)(obj2 - 16);
			_ = pressedPropertyIdSerializedGuid.Length;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rsp-20]");
			_ = 0;
			*(Guid*)(nint)guid3 = new Guid(b3);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rsp-10]");
			pressedColorPropertyId = (Guid)0;
		}
		else
		{
			pressedColorPropertyId = Guid.Empty;
		}
		byte[] selectedPropertyIdSerializedGuid = SelectedPropertyIdSerializedGuid;
		PressedColorPropertyId = pressedColorPropertyId;
		Guid selectedColorPropertyId;
		if (SelectedPropertyIdSerializedGuid != null && selectedPropertyIdSerializedGuid.Length == 16)
		{
			_ = 0;
			_ = 0;
			object obj5 = SelectedPropertyIdSerializedGuid + 32;
			ReadOnlySpan<byte> b4 = (ReadOnlySpan<byte>)(obj2 - 32);
			Guid guid4 = (Guid)(obj2 - 16);
			_ = selectedPropertyIdSerializedGuid.Length;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rsp-20]");
			_ = 0;
			*(Guid*)(nint)guid4 = new Guid(b4);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rsp-10]");
			selectedColorPropertyId = (Guid)0;
		}
		else
		{
			selectedColorPropertyId = Guid.Empty;
		}
		byte[] disabledPropertyIdSerializedGuid = DisabledPropertyIdSerializedGuid;
		SelectedColorPropertyId = selectedColorPropertyId;
		Guid disabledColorPropertyId;
		if (DisabledPropertyIdSerializedGuid != null && disabledPropertyIdSerializedGuid.Length == 16)
		{
			_ = 0;
			_ = 0;
			object obj6 = DisabledPropertyIdSerializedGuid + 32;
			ReadOnlySpan<byte> b5 = (ReadOnlySpan<byte>)(obj2 - 32);
			Guid guid5 = (Guid)(obj2 - 16);
			_ = disabledPropertyIdSerializedGuid.Length;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rsp-20]");
			_ = 0;
			*(Guid*)(nint)guid5 = new Guid(b5);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rsp-10]");
			disabledColorPropertyId = (Guid)0;
		}
		else
		{
			disabledColorPropertyId = Guid.Empty;
		}
		DisabledColorPropertyId = disabledColorPropertyId;
	}

	public unsafe override void UpdateTarget(ThemeData theme)
	{
		//IL_0008: Expected O, but got Ref
		//IL_018b: Expected F4, but got O
		//IL_019b: Expected F4, but got I
		//IL_01ab: Expected F4, but got I
		//IL_01bb: Expected F4, but got I
		//IL_01cb: Expected F4, but got I
		//IL_02d0: Expected O, but got Ref
		//IL_03e8: Expected O, but got Ref
		//IL_0500: Expected O, but got Ref
		//IL_0618: Expected O, but got Ref
		//IL_0730: Expected O, but got Ref
		//IL_0767: Expected O, but got Ref
		//IL_076f: Expected I, but got O
		//IL_07de: Expected O, but got F4
		object obj2 = default(object);
		object obj = (object)(&obj2);
		Selectable selectable = Selectable;
		if ((object)Selectable == null || ((UnityEngine.Object)selectable).m_CachedPtr == (IntPtr)0 || (object)theme == null || ((UnityEngine.Object)theme).m_CachedPtr == (IntPtr)0)
		{
			return;
		}
		if ((object)ThemeId == (object)Guid.Empty)
		{
			object obj3 = (object)Guid.Empty >> 32;
			object obj4 = (object)ThemeId >> 32;
			if (obj4 == obj3)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm3,8\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm2,8\"");
				if ((object)ThemeId == (object)Guid.Empty)
				{
					object obj5 = (object)Guid.Empty >> 32;
					object obj6 = (object)ThemeId >> 32;
					if (obj6 == obj5)
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
		float num = (float)selectable2.m_Colors;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v517 @ rax_v17 (UnityEngine.UI.Selectable)+64]");
		float num2 = 0f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v517 @ rax_v17 (UnityEngine.UI.Selectable)+74]");
		float num3 = 0f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v517 @ rax_v17 (UnityEngine.UI.Selectable)+84]");
		float num4 = 0f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v517 @ rax_v17 (UnityEngine.UI.Selectable)+94]");
		float num5 = 0f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v517 @ rax_v17 (UnityEngine.UI.Selectable)+A4]");
		_ = 0;
		if ((object)NormalColorPropertyId == (object)Guid.Empty)
		{
			object obj7 = (object)Guid.Empty >> 32;
			object obj8 = (object)NormalColorPropertyId >> 32;
			if (obj8 == obj7)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm3,8\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm2,8\"");
				if ((object)NormalColorPropertyId == (object)Guid.Empty)
				{
					object obj9 = (object)Guid.Empty >> 32;
					object obj10 = (object)NormalColorPropertyId >> 32;
					if (obj10 == obj9)
					{
						goto IL_02f0;
					}
				}
			}
		}
		ThemeVariantData activeVariant2 = theme.ActiveVariant;
		Guid guid = default(Guid);
		num = activeVariant2.GetColor((Guid)(&guid)).r;
		guid = NormalColorPropertyId;
		goto IL_02f0;
		IL_0408:
		if ((object)PressedColorPropertyId == (object)Guid.Empty)
		{
			object obj11 = (object)Guid.Empty >> 32;
			object obj12 = (object)PressedColorPropertyId >> 32;
			if (obj12 == obj11)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm3,8\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm2,8\"");
				if ((object)PressedColorPropertyId == (object)Guid.Empty)
				{
					object obj13 = (object)Guid.Empty >> 32;
					object obj14 = (object)PressedColorPropertyId >> 32;
					if (obj14 == obj13)
					{
						goto IL_0520;
					}
				}
			}
		}
		ThemeVariantData activeVariant3 = theme.ActiveVariant;
		num3 = activeVariant3.GetColor((Guid)(&guid)).r;
		guid = PressedColorPropertyId;
		goto IL_0520;
		IL_0520:
		if ((object)SelectedColorPropertyId == (object)Guid.Empty)
		{
			object obj15 = (object)Guid.Empty >> 32;
			object obj16 = (object)SelectedColorPropertyId >> 32;
			if (obj16 == obj15)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm3,8\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm2,8\"");
				if ((object)SelectedColorPropertyId == (object)Guid.Empty)
				{
					object obj17 = (object)Guid.Empty >> 32;
					object obj18 = (object)SelectedColorPropertyId >> 32;
					if (obj18 == obj17)
					{
						goto IL_0638;
					}
				}
			}
		}
		ThemeVariantData activeVariant4 = theme.ActiveVariant;
		num4 = activeVariant4.GetColor((Guid)(&guid)).r;
		guid = SelectedColorPropertyId;
		goto IL_0638;
		IL_074b:
		EqualityComparer<ColorBlock> equalityComparer = EqualityComparer<ColorBlock>.Default;
		object obj19 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 96));
		nint num6 = (nint)equalityComparer;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v517 @ rax_v17 (UnityEngine.UI.Selectable)+94]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v517 @ rax_v17 (UnityEngine.UI.Selectable)+A4]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1275 @ r9_v8 (Il2CppClass<System.Collections.Generic.EqualityComparer`1<UnityEngine.UI.ColorBlock>>)+1B8] (should have been resolved before IL gen)");
		object obj20 = default(object);
		if (obj20 == null)
		{
			selectable2.m_Colors = (ColorBlock)num;
			selectable2.OnSetProperty();
		}
		return;
		IL_02f0:
		if ((object)HighlightedColorPropertyId == (object)Guid.Empty)
		{
			object obj21 = (object)Guid.Empty >> 32;
			object obj22 = (object)HighlightedColorPropertyId >> 32;
			if (obj22 == obj21)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm3,8\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm2,8\"");
				if ((object)HighlightedColorPropertyId == (object)Guid.Empty)
				{
					object obj23 = (object)Guid.Empty >> 32;
					object obj24 = (object)HighlightedColorPropertyId >> 32;
					if (obj24 == obj23)
					{
						goto IL_0408;
					}
				}
			}
		}
		ThemeVariantData activeVariant5 = theme.ActiveVariant;
		num2 = activeVariant5.GetColor((Guid)(&guid)).r;
		guid = HighlightedColorPropertyId;
		goto IL_0408;
		IL_0638:
		if ((object)DisabledColorPropertyId == (object)Guid.Empty)
		{
			object obj25 = (object)Guid.Empty >> 32;
			object obj26 = (object)DisabledColorPropertyId >> 32;
			if (obj26 == obj25)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm3,8\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm2,8\"");
				if ((object)DisabledColorPropertyId == (object)Guid.Empty)
				{
					object obj27 = (object)Guid.Empty >> 32;
					object obj28 = (object)DisabledColorPropertyId >> 32;
					if (obj28 == obj27)
					{
						goto IL_074b;
					}
				}
			}
		}
		ThemeVariantData activeVariant6 = theme.ActiveVariant;
		num5 = activeVariant6.GetColor((Guid)(&guid)).r;
		goto IL_074b;
	}

	private void Reset()
	{
		ThemeId = Guid.Empty;
		VariantId = Guid.Empty;
		PropertyId = Guid.Empty;
		NormalColorPropertyId = Guid.Empty;
		HighlightedColorPropertyId = Guid.Empty;
		PressedColorPropertyId = Guid.Empty;
		SelectedColorPropertyId = Guid.Empty;
		DisabledColorPropertyId = Guid.Empty;
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
