using System;
using Cpp2ILInjected;
using UnityEngine;

namespace Doozy.Engine.Themes;

[Serializable]
public abstract class ThemeTarget : MonoBehaviour, ISerializationCallbackReceiver
{
	public Guid ThemeId;

	public Guid VariantId;

	public Guid PropertyId;

	private byte[] ThemeIdSerializedGuid;

	private byte[] VariantIdSerializedGuid;

	private byte[] PropertyIdSerializedGuid;

	protected unsafe virtual void OnValidate()
	{
		//IL_01a5: Expected O, but got Ref
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
		ThemesDatabase database = ThemesSettings.Database;
		object obj9 = default(object);
		ThemeData themeData = database.GetThemeData((Guid)(&obj9));
		UpdateTarget(themeData);
	}

	public virtual void Awake()
	{
	}

	public virtual void OnEnable()
	{
		ThemeManager.RegisterTarget(this);
	}

	public virtual void OnDisable()
	{
		ThemeManager.UnregisterTarget(this);
	}

	public virtual void OnBeforeSerialize()
	{
		byte[] themeIdSerializedGuid;
		if ((object)ThemeId == (object)Guid.Empty)
		{
			object obj = (object)ThemeId >> 32;
			object obj2 = (object)Guid.Empty >> 32;
			if (obj == obj2)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm1,8\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm2,8\"");
				if ((object)ThemeId == (object)Guid.Empty)
				{
					object obj3 = (object)ThemeId >> 32;
					object obj4 = (object)Guid.Empty >> 32;
					if (obj3 == obj4)
					{
						themeIdSerializedGuid = null;
						goto IL_00d3;
					}
				}
			}
		}
		Guid guid = default(Guid);
		themeIdSerializedGuid = guid.ToByteArray();
		goto IL_00d3;
		IL_02fe:
		byte[] propertyIdSerializedGuid;
		PropertyIdSerializedGuid = propertyIdSerializedGuid;
		return;
		IL_00d3:
		ThemeIdSerializedGuid = themeIdSerializedGuid;
		byte[] variantIdSerializedGuid;
		if ((object)VariantId == (object)Guid.Empty)
		{
			object obj5 = (object)VariantId >> 32;
			object obj6 = (object)Guid.Empty >> 32;
			if (obj5 == obj6)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm1,8\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm2,8\"");
				if ((object)VariantId == (object)Guid.Empty)
				{
					object obj7 = (object)VariantId >> 32;
					object obj8 = (object)Guid.Empty >> 32;
					if (obj7 == obj8)
					{
						variantIdSerializedGuid = null;
						goto IL_01b5;
					}
				}
			}
		}
		Guid guid2 = default(Guid);
		variantIdSerializedGuid = guid2.ToByteArray();
		goto IL_01b5;
		IL_01b5:
		VariantIdSerializedGuid = variantIdSerializedGuid;
		if ((object)PropertyId == (object)Guid.Empty)
		{
			object obj9 = (object)PropertyId >> 32;
			object obj10 = (object)Guid.Empty >> 32;
			if (obj9 == obj10)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm1,8\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm2,8\"");
				if ((object)PropertyId == (object)Guid.Empty)
				{
					object obj11 = (object)PropertyId >> 32;
					object obj12 = (object)Guid.Empty >> 32;
					bool flag = obj11 == obj12;
					propertyIdSerializedGuid = null;
					if (flag)
					{
						goto IL_02fe;
					}
				}
			}
		}
		byte[] array = guid2.ToByteArray();
		propertyIdSerializedGuid = array;
		goto IL_02fe;
	}

	public unsafe virtual void OnAfterDeserialize()
	{
		//IL_00f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f5: Expected O, but got Unknown
		//IL_0103: Unknown result type (might be due to invalid IL or missing references)
		//IL_0108: Expected O, but got Unknown
		//IL_0111: Unknown result type (might be due to invalid IL or missing references)
		//IL_0116: Expected O, but got Unknown
		//IL_0132: Expected native int or pointer, but got O
		//IL_0147: Expected O, but got I
		//IL_0176: Unknown result type (might be due to invalid IL or missing references)
		//IL_017b: Expected O, but got Unknown
		//IL_0189: Unknown result type (might be due to invalid IL or missing references)
		//IL_018e: Expected O, but got Unknown
		//IL_0197: Unknown result type (might be due to invalid IL or missing references)
		//IL_019c: Expected O, but got Unknown
		//IL_01b8: Expected native int or pointer, but got O
		//IL_01cd: Expected O, but got I
		//IL_01fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0201: Expected O, but got Unknown
		//IL_020f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0214: Expected O, but got Unknown
		//IL_021d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0222: Expected O, but got Unknown
		//IL_023e: Expected native int or pointer, but got O
		//IL_0253: Expected O, but got I
		byte[] themeIdSerializedGuid = ThemeIdSerializedGuid;
		object obj2 = default(object);
		Guid themeId;
		if (ThemeIdSerializedGuid != null && themeIdSerializedGuid.Length == 16)
		{
			_ = 0;
			_ = 0;
			object obj = ThemeIdSerializedGuid + 32;
			ReadOnlySpan<byte> b = (ReadOnlySpan<byte>)(obj2 - 32);
			Guid guid = (Guid)(obj2 - 16);
			_ = themeIdSerializedGuid.Length;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp-20]");
			_ = 0;
			*(Guid*)(nint)guid = new Guid(b);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp-10]");
			themeId = (Guid)0;
		}
		else
		{
			themeId = Guid.Empty;
		}
		byte[] variantIdSerializedGuid = VariantIdSerializedGuid;
		ThemeId = themeId;
		Guid variantId;
		if (VariantIdSerializedGuid != null && variantIdSerializedGuid.Length == 16)
		{
			_ = 0;
			_ = 0;
			object obj3 = VariantIdSerializedGuid + 32;
			ReadOnlySpan<byte> b2 = (ReadOnlySpan<byte>)(obj2 - 32);
			Guid guid2 = (Guid)(obj2 - 16);
			_ = variantIdSerializedGuid.Length;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp-20]");
			_ = 0;
			*(Guid*)(nint)guid2 = new Guid(b2);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp-10]");
			variantId = (Guid)0;
		}
		else
		{
			variantId = Guid.Empty;
		}
		byte[] propertyIdSerializedGuid = PropertyIdSerializedGuid;
		VariantId = variantId;
		Guid propertyId;
		if (PropertyIdSerializedGuid != null && propertyIdSerializedGuid.Length == 16)
		{
			_ = 0;
			_ = 0;
			object obj4 = PropertyIdSerializedGuid + 32;
			ReadOnlySpan<byte> b3 = (ReadOnlySpan<byte>)(obj2 - 32);
			Guid guid3 = (Guid)(obj2 - 16);
			_ = propertyIdSerializedGuid.Length;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp-20]");
			_ = 0;
			*(Guid*)(nint)guid3 = new Guid(b3);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp-10]");
			propertyId = (Guid)0;
		}
		else
		{
			propertyId = Guid.Empty;
		}
		PropertyId = propertyId;
	}

	public virtual void UpdateTarget(ThemeData theme)
	{
	}

	protected ThemeTarget()
	{
		//IL_003b: Expected I, but got O
		ThemeId = Guid.Empty;
		VariantId = Guid.Empty;
		PropertyId = Guid.Empty;
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ rcx_v5 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
