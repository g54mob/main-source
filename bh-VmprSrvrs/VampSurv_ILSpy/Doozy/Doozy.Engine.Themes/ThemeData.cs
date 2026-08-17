using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using Doozy.Engine.Utils;
using UnityEngine;

namespace Doozy.Engine.Themes;

[Serializable]
public class ThemeData : ScriptableObject, ISerializationCallbackReceiver
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Func<ThemeVariantData, string> _003C_003E9__62_0;

		public static Func<ThemeVariantData, string> _003C_003E9__64_0;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal string _003CSort_003Eb__62_0(ThemeVariantData variant)
		{
			if (variant != null)
			{
				return variant.m_variantName;
			}
			return (string)(object)new NullReferenceException();
		}

		internal string _003CUpdateVariantsNames_003Eb__64_0(ThemeVariantData variant)
		{
			if (variant != null)
			{
				return variant.m_variantName;
			}
			return (string)(object)new NullReferenceException();
		}
	}

	private sealed class _003C_003Ec__DisplayClass38_0
	{
		public Guid propertyId;

		internal bool _003CContainsColorProperty_003Eb__0(LabelId colorLabel)
		{
			if ((object)propertyId == (object)colorLabel.m_id)
			{
				object obj = (object)colorLabel.m_id >> 32;
				object obj2 = (object)propertyId >> 32;
				if (obj2 == obj)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm1,8\"");
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm2,8\"");
					if ((object)propertyId == (object)colorLabel.m_id)
					{
						object obj3 = (object)propertyId >> 32;
						object obj4 = (object)colorLabel.m_id >> 32;
						object obj5 = obj3 - obj4;
						return obj5 == null;
					}
				}
			}
			return false;
		}
	}

	private sealed class _003C_003Ec__DisplayClass39_0
	{
		public Guid propertyId;

		internal bool _003CContainsSpriteProperty_003Eb__0(LabelId spriteLabel)
		{
			if ((object)propertyId == (object)spriteLabel.m_id)
			{
				object obj = (object)spriteLabel.m_id >> 32;
				object obj2 = (object)propertyId >> 32;
				if (obj2 == obj)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm1,8\"");
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm2,8\"");
					if ((object)propertyId == (object)spriteLabel.m_id)
					{
						object obj3 = (object)propertyId >> 32;
						object obj4 = (object)spriteLabel.m_id >> 32;
						object obj5 = obj3 - obj4;
						return obj5 == null;
					}
				}
			}
			return false;
		}
	}

	private sealed class _003C_003Ec__DisplayClass40_0
	{
		public Guid propertyId;

		internal bool _003CContainsTextureProperty_003Eb__0(LabelId textureLabel)
		{
			if ((object)propertyId == (object)textureLabel.m_id)
			{
				object obj = (object)textureLabel.m_id >> 32;
				object obj2 = (object)propertyId >> 32;
				if (obj2 == obj)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm1,8\"");
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm2,8\"");
					if ((object)propertyId == (object)textureLabel.m_id)
					{
						object obj3 = (object)propertyId >> 32;
						object obj4 = (object)textureLabel.m_id >> 32;
						object obj5 = obj3 - obj4;
						return obj5 == null;
					}
				}
			}
			return false;
		}
	}

	private sealed class _003C_003Ec__DisplayClass41_0
	{
		public Guid propertyId;

		internal bool _003CContainsFontProperty_003Eb__0(LabelId fontLabel)
		{
			if ((object)propertyId == (object)fontLabel.m_id)
			{
				object obj = (object)fontLabel.m_id >> 32;
				object obj2 = (object)propertyId >> 32;
				if (obj2 == obj)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm1,8\"");
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm2,8\"");
					if ((object)propertyId == (object)fontLabel.m_id)
					{
						object obj3 = (object)propertyId >> 32;
						object obj4 = (object)fontLabel.m_id >> 32;
						object obj5 = obj3 - obj4;
						return obj5 == null;
					}
				}
			}
			return false;
		}
	}

	private sealed class _003C_003Ec__DisplayClass42_0
	{
		public Guid propertyId;

		internal bool _003CContainsFontAssetProperty_003Eb__0(LabelId fontAssetLabel)
		{
			if ((object)propertyId == (object)fontAssetLabel.m_id)
			{
				object obj = (object)fontAssetLabel.m_id >> 32;
				object obj2 = (object)propertyId >> 32;
				if (obj2 == obj)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm1,8\"");
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm2,8\"");
					if ((object)propertyId == (object)fontAssetLabel.m_id)
					{
						object obj3 = (object)propertyId >> 32;
						object obj4 = (object)fontAssetLabel.m_id >> 32;
						object obj5 = obj3 - obj4;
						return obj5 == null;
					}
				}
			}
			return false;
		}
	}

	private sealed class _003C_003Ec__DisplayClass43_0
	{
		public Guid variantGuid;

		internal bool _003CContainsVariant_003Eb__0(ThemeVariantData variant)
		{
			//IL_0117: Expected I4, but got O
			if (variant != null)
			{
				if ((object)variantGuid == (object)variant.m_id)
				{
					object obj = (object)variant.m_id >> 32;
					object obj2 = (object)variantGuid >> 32;
					if (obj2 == obj)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm1,8\"");
						Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm2,8\"");
						if ((object)variantGuid == (object)variant.m_id)
						{
							object obj3 = (object)variantGuid >> 32;
							object obj4 = (object)variant.m_id >> 32;
							object obj5 = obj3 - obj4;
							return obj5 == null;
						}
					}
				}
				return false;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	private sealed class _003C_003Ec__DisplayClass44_0
	{
		public string variantName;

		internal unsafe bool _003CContainsVariant_003Eb__0(ThemeVariantData variant)
		{
			//IL_012f: Expected I4, but got O
			//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d1: Expected Ref, but got Unknown
			//IL_00e8: Expected I8, but got I4
			//IL_00f6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00fb: Expected Ref, but got Unknown
			if (variant != null)
			{
				string text = variant.m_variantName;
				if (variant.m_variantName != null)
				{
					string text2 = variantName;
					if ((object)variant.m_variantName != variantName)
					{
						if (variantName != null && text._stringLength == text2._stringLength)
						{
							ref byte second = ref *(byte*)(variantName + 20);
							ulong length = (ulong)(text._stringLength + text._stringLength);
							return System.SpanHelpers.SequenceEqual(ref *(byte*)(variant.m_variantName + 20), ref second, length);
						}
						return false;
					}
					return true;
				}
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	private sealed class _003C_003Ec__DisplayClass45_0
	{
		public Guid variantId;

		internal bool _003CGetVariant_003Eb__0(ThemeVariantData variant)
		{
			//IL_0117: Expected I4, but got O
			if (variant != null)
			{
				if ((object)variantId == (object)variant.m_id)
				{
					object obj = (object)variant.m_id >> 32;
					object obj2 = (object)variantId >> 32;
					if (obj2 == obj)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm1,8\"");
						Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm2,8\"");
						if ((object)variantId == (object)variant.m_id)
						{
							object obj3 = (object)variantId >> 32;
							object obj4 = (object)variant.m_id >> 32;
							object obj5 = obj3 - obj4;
							return obj5 == null;
						}
					}
				}
				return false;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	private sealed class _003C_003Ec__DisplayClass46_0
	{
		public string variantName;

		internal unsafe bool _003CGetVariant_003Eb__0(ThemeVariantData variant)
		{
			//IL_012f: Expected I4, but got O
			//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d1: Expected Ref, but got Unknown
			//IL_00e8: Expected I8, but got I4
			//IL_00f6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00fb: Expected Ref, but got Unknown
			if (variant != null)
			{
				string text = variant.m_variantName;
				if (variant.m_variantName != null)
				{
					string text2 = variantName;
					if ((object)variant.m_variantName != variantName)
					{
						if (variantName != null && text._stringLength == text2._stringLength)
						{
							ref byte second = ref *(byte*)(variantName + 20);
							ulong length = (ulong)(text._stringLength + text._stringLength);
							return System.SpanHelpers.SequenceEqual(ref *(byte*)(variant.m_variantName + 20), ref second, length);
						}
						return false;
					}
					return true;
				}
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	public const string UNNAMED_THEME_NAME = "Unnamed Theme";

	public const string UNNAMED_VARIANT_NAME = "Unnamed Variant";

	public const string UNNAMED_PROPERTY = "Unnamed Property";

	public const string DEFAULT_VARIANT_NAME = "Default";

	private string m_themeName;

	private byte[] SerializedGuid;

	private Guid m_id;

	private ThemeVariantData m_activeVariant;

	public List<LabelId> ColorLabels;

	public List<LabelId> SpriteLabels;

	public List<LabelId> TextureLabels;

	public List<LabelId> FontLabels;

	public List<LabelId> FontAssetLabels;

	public List<string> VariantsNames;

	public List<ThemeVariantData> Variants;

	private const string COLOR_DEFAULT_COLOR_LABEL_1 = "Primary";

	private const string COLOR_DEFAULT_COLOR_LABEL_2 = "Secondary";

	private const string COLOR_DEFAULT_COLOR_LABEL_3 = "Accent 1";

	private const string COLOR_DEFAULT_COLOR_LABEL_4 = "Accent 2";

	private const string COLOR_DEFAULT_COLOR_LABEL_5 = "Text";

	private const string COLOR_DEFAULT_COLOR_LABEL_6 = "Disabled";

	private static UILanguagePack UILabels => UILanguagePack.Instance;

	public ThemeVariantData ActiveVariant
	{
		get
		{
			if (m_activeVariant == null)
			{
				List<ThemeVariantData> variants = Variants;
				if (variants._size == 0)
				{
					bool flag = AddDefaultVariant();
				}
				List<ThemeVariantData> variants2 = Variants;
				if (variants2._size <= 0)
				{
					System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
					ThemeVariantData result = default(ThemeVariantData);
					return result;
				}
				ThemeVariantData[] items = variants2._items;
				m_activeVariant = items[0];
				DoozyUtils.SetDirty(this, saveAssets: false);
			}
			return m_activeVariant;
		}
	}

	public unsafe Guid Id
	{
		get
		{
			//IL_000f: Expected I4, but got O
			//IL_000a: Expected native int or pointer, but got O
			Guid guid = default(Guid);
			((Guid*)(nint)guid)->_a = (int)m_id;
			return guid;
		}
	}

	public string ThemeName
	{
		get
		{
			return m_themeName;
		}
		set
		{
			m_themeName = value;
		}
	}

	public unsafe bool IsGeneralTheme
	{
		get
		{
			//IL_010f: Expected I4, but got O
			//IL_00af: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b4: Expected Ref, but got Unknown
			//IL_00cb: Expected I8, but got I4
			//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00db: Expected Ref, but got Unknown
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899809A9]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			string themeName = m_themeName;
			if (m_themeName != null)
			{
				object obj = "General";
				if ((object)m_themeName != "General")
				{
					if ("General" != null)
					{
						int stringLength = themeName._stringLength;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rdx_v1+10]");
						if ((nint)stringLength == 0)
						{
							ref byte second = ref *(byte*)("General" + 20);
							ulong length = (ulong)(themeName._stringLength + themeName._stringLength);
							return System.SpanHelpers.SequenceEqual(ref *(byte*)(m_themeName + 20), ref second, length);
						}
					}
					return false;
				}
				return true;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	public unsafe ThemeData()
	{
		//IL_00fb: Expected O, but got I4
		m_themeName = "Unnamed Theme";
		ColorLabels = new List<LabelId>();
		SpriteLabels = new List<LabelId>();
		TextureLabels = new List<LabelId>();
		FontLabels = new List<LabelId>();
		FontAssetLabels = new List<LabelId>();
		VariantsNames = new List<string>();
		Variants = new List<ThemeVariantData>();
		base._002Ector();
		object obj = default(object);
		global::Interop.GetRandomBytes((byte*)(&obj), 16);
		m_id = (Guid)0;
	}

	public void OnBeforeSerialize()
	{
		byte[] serializedGuid;
		if ((object)m_id == (object)Guid.Empty)
		{
			object obj = (object)m_id >> 32;
			object obj2 = (object)Guid.Empty >> 32;
			if (obj == obj2)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm1,8\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm2,8\"");
				if ((object)m_id == (object)Guid.Empty)
				{
					object obj3 = (object)m_id >> 32;
					object obj4 = (object)Guid.Empty >> 32;
					if (obj3 == obj4)
					{
						serializedGuid = null;
						goto IL_00d3;
					}
				}
			}
		}
		Guid guid = default(Guid);
		serializedGuid = guid.ToByteArray();
		goto IL_00d3;
		IL_00d3:
		SerializedGuid = serializedGuid;
	}

	public unsafe void OnAfterDeserialize()
	{
		//IL_006e: Expected O, but got Ref
		byte[] serializedGuid = SerializedGuid;
		if (SerializedGuid == null || serializedGuid.Length != 16)
		{
			m_id = Guid.Empty;
			return;
		}
		object obj = default(object);
		Guid id = new Guid((ReadOnlySpan<byte>)(&obj));
		m_id = id;
	}

	public void ActivateVariant(ThemeVariantData variant)
	{
		if (variant != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049B860");
			object obj = default(object);
			if (obj != null)
			{
				m_activeVariant = variant;
				SetDirty(saveAssets: false);
			}
		}
	}

	public unsafe void ActivateVariant(Guid variantId)
	{
		//IL_00c7: Expected O, but got Ref
		//IL_00ee: Expected O, but got Ref
		if (variantId._a == (nint)Guid.Empty)
		{
			object obj = (object)Guid.Empty >> 32;
			int num = variantId._a >> 32;
			if (num == (nint)obj)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm3,8\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm2,8\"");
				if (variantId._a == (nint)Guid.Empty)
				{
					object obj2 = (object)Guid.Empty >> 32;
					int num2 = variantId._a >> 32;
					if (num2 == (nint)obj2)
					{
						return;
					}
				}
			}
		}
		int num3 = default(int);
		if (ContainsVariant((Guid)(&num3)))
		{
			ThemeVariantData variant = GetVariant((Guid)(&num3));
			m_activeVariant = variant;
			SetDirty(saveAssets: false);
		}
	}

	public void ActivateVariant(string variantName)
	{
		if (variantName != null && variantName._stringLength > 0)
		{
			ThemeVariantData variant = GetVariant(variantName);
			m_activeVariant = variant;
			DoozyUtils.SetDirty(this, saveAssets: false);
		}
	}

	public unsafe void AddColorProperty(bool performUndo, bool saveAssets = false)
	{
		//IL_007e: Expected O, but got Ref
		//IL_00d5: Expected O, but got I
		//IL_010c: Expected O, but got I
		//IL_0147: Expected O, but got I
		//IL_01a2: Expected O, but got I4
		//IL_01aa: Expected O, but got Ref
		if (performUndo)
		{
			UILanguagePack instance = UILanguagePack.Instance;
			if ((object)instance == null)
			{
				throw new NullReferenceException();
			}
			DoozyUtils.UndoRecordObject(this, instance.AddItem);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182C02A00");
		bool flag = ColorLabels == null;
		object obj = default(object);
		List<LabelId> list = (List<LabelId>)(&obj);
		if (!flag)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180496E20");
			list = ColorLabels;
			if (ColorLabels != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v208 @ rcx_v10 (System.Collections.Generic.List`1<Doozy.Engine.Themes.LabelId>)+18]");
				object obj2 = -1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v208 @ rcx_v10 (System.Collections.Generic.List`1<Doozy.Engine.Themes.LabelId>)+18]");
				if ((nint)obj2 >= 0)
				{
					System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
					return;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v208 @ rcx_v10 (System.Collections.Generic.List`1<Doozy.Engine.Themes.LabelId>)+10]");
				list = (List<LabelId>)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v208 @ rcx_v10 (System.Collections.Generic.List`1<Doozy.Engine.Themes.LabelId>)+10]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v208 @ rcx_v10 (System.Collections.Generic.List`1<Doozy.Engine.Themes.LabelId>)+18]");
					object obj3 = -1;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v208 @ rcx_v10 (System.Collections.Generic.List`1<Doozy.Engine.Themes.LabelId>)+18]");
					if ((nint)obj3 >= 0)
					{
						throw new IndexOutOfRangeException();
					}
					if (Variants != null)
					{
						List<ThemeVariantData>.Enumerator enumerator = default(List<ThemeVariantData>.Enumerator);
						if (enumerator.MoveNext())
						{
							object obj4 = 0;
							List<ThemeVariantData>.Enumerator enumerator2 = (List<ThemeVariantData>.Enumerator)(&enumerator);
							throw new NullReferenceException();
						}
						DoozyUtils.SetDirty(this, saveAssets);
						return;
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public unsafe void AddSpriteProperty(bool performUndo, bool saveAssets = false)
	{
		//IL_003c: Expected O, but got I4
		//IL_00d7: Expected O, but got I
		//IL_010e: Expected O, but got I
		//IL_0149: Expected O, but got I
		//IL_019d: Expected O, but got I4
		//IL_01a5: Expected O, but got Ref
		if (performUndo)
		{
			UILanguagePack instance = UILanguagePack.Instance;
			bool flag = (object)instance == null;
			List<ThemeVariantData>.Enumerator enumerator = (List<ThemeVariantData>.Enumerator)0;
			if (flag)
			{
				throw new NullReferenceException();
			}
			DoozyUtils.UndoRecordObject(this, instance.AddItem);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182C02A00");
		if (SpriteLabels != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180496E20");
			List<LabelId> spriteLabels = SpriteLabels;
			if (SpriteLabels != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v210 @ rdx_v10 (System.Collections.Generic.List`1<Doozy.Engine.Themes.LabelId>)+18]");
				object obj = -1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v210 @ rdx_v10 (System.Collections.Generic.List`1<Doozy.Engine.Themes.LabelId>)+18]");
				if ((nint)obj >= 0)
				{
					System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
					return;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v210 @ rdx_v10 (System.Collections.Generic.List`1<Doozy.Engine.Themes.LabelId>)+10]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v210 @ rdx_v10 (System.Collections.Generic.List`1<Doozy.Engine.Themes.LabelId>)+10]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v210 @ rdx_v10 (System.Collections.Generic.List`1<Doozy.Engine.Themes.LabelId>)+18]");
					object obj3 = -1;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v211 @ rdx_v11+18]");
					if ((nint)obj3 >= 0)
					{
						throw new IndexOutOfRangeException();
					}
					if (Variants != null)
					{
						List<ThemeVariantData>.Enumerator enumerator2 = default(List<ThemeVariantData>.Enumerator);
						if (enumerator2.MoveNext())
						{
							object obj4 = 0;
							List<ThemeVariantData>.Enumerator enumerator = (List<ThemeVariantData>.Enumerator)(&enumerator2);
							throw new NullReferenceException();
						}
						DoozyUtils.SetDirty(this, saveAssets);
						return;
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public unsafe void AddTextureProperty(bool performUndo, bool saveAssets = false)
	{
		//IL_003c: Expected O, but got I4
		//IL_00d7: Expected O, but got I
		//IL_010e: Expected O, but got I
		//IL_0149: Expected O, but got I
		//IL_019d: Expected O, but got I4
		//IL_01a5: Expected O, but got Ref
		if (performUndo)
		{
			UILanguagePack instance = UILanguagePack.Instance;
			bool flag = (object)instance == null;
			List<ThemeVariantData>.Enumerator enumerator = (List<ThemeVariantData>.Enumerator)0;
			if (flag)
			{
				throw new NullReferenceException();
			}
			DoozyUtils.UndoRecordObject(this, instance.AddItem);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182C02A00");
		if (TextureLabels != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180496E20");
			List<LabelId> textureLabels = TextureLabels;
			if (TextureLabels != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v210 @ rdx_v10 (System.Collections.Generic.List`1<Doozy.Engine.Themes.LabelId>)+18]");
				object obj = -1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v210 @ rdx_v10 (System.Collections.Generic.List`1<Doozy.Engine.Themes.LabelId>)+18]");
				if ((nint)obj >= 0)
				{
					System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
					return;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v210 @ rdx_v10 (System.Collections.Generic.List`1<Doozy.Engine.Themes.LabelId>)+10]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v210 @ rdx_v10 (System.Collections.Generic.List`1<Doozy.Engine.Themes.LabelId>)+10]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v210 @ rdx_v10 (System.Collections.Generic.List`1<Doozy.Engine.Themes.LabelId>)+18]");
					object obj3 = -1;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v211 @ rdx_v11+18]");
					if ((nint)obj3 >= 0)
					{
						throw new IndexOutOfRangeException();
					}
					if (Variants != null)
					{
						List<ThemeVariantData>.Enumerator enumerator2 = default(List<ThemeVariantData>.Enumerator);
						if (enumerator2.MoveNext())
						{
							object obj4 = 0;
							List<ThemeVariantData>.Enumerator enumerator = (List<ThemeVariantData>.Enumerator)(&enumerator2);
							throw new NullReferenceException();
						}
						DoozyUtils.SetDirty(this, saveAssets);
						return;
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public unsafe void AddFontProperty(bool performUndo, bool saveAssets = false)
	{
		//IL_003c: Expected O, but got I4
		//IL_00d7: Expected O, but got I
		//IL_010e: Expected O, but got I
		//IL_0149: Expected O, but got I
		//IL_019d: Expected O, but got I4
		//IL_01a5: Expected O, but got Ref
		if (performUndo)
		{
			UILanguagePack instance = UILanguagePack.Instance;
			bool flag = (object)instance == null;
			List<ThemeVariantData>.Enumerator enumerator = (List<ThemeVariantData>.Enumerator)0;
			if (flag)
			{
				throw new NullReferenceException();
			}
			DoozyUtils.UndoRecordObject(this, instance.AddItem);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182C02A00");
		if (FontLabels != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180496E20");
			List<LabelId> fontLabels = FontLabels;
			if (FontLabels != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v210 @ rdx_v10 (System.Collections.Generic.List`1<Doozy.Engine.Themes.LabelId>)+18]");
				object obj = -1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v210 @ rdx_v10 (System.Collections.Generic.List`1<Doozy.Engine.Themes.LabelId>)+18]");
				if ((nint)obj >= 0)
				{
					System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
					return;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v210 @ rdx_v10 (System.Collections.Generic.List`1<Doozy.Engine.Themes.LabelId>)+10]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v210 @ rdx_v10 (System.Collections.Generic.List`1<Doozy.Engine.Themes.LabelId>)+10]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v210 @ rdx_v10 (System.Collections.Generic.List`1<Doozy.Engine.Themes.LabelId>)+18]");
					object obj3 = -1;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v211 @ rdx_v11+18]");
					if ((nint)obj3 >= 0)
					{
						throw new IndexOutOfRangeException();
					}
					if (Variants != null)
					{
						List<ThemeVariantData>.Enumerator enumerator2 = default(List<ThemeVariantData>.Enumerator);
						if (enumerator2.MoveNext())
						{
							object obj4 = 0;
							List<ThemeVariantData>.Enumerator enumerator = (List<ThemeVariantData>.Enumerator)(&enumerator2);
							throw new NullReferenceException();
						}
						DoozyUtils.SetDirty(this, saveAssets);
						return;
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public void AddFontAssetProperty(bool performUndo, bool saveAssets = false)
	{
	}

	public void AddVariant(bool performUndo, bool saveAssets = false)
	{
		if (performUndo)
		{
			UILanguagePack instance = UILanguagePack.Instance;
			DoozyUtils.UndoRecordObject(this, instance.NewThemeVariant);
		}
		List<LabelId> colorLabels = new List<LabelId>(ColorLabels);
		List<LabelId> spriteLabels = new List<LabelId>(SpriteLabels);
		List<LabelId> list = new List<LabelId>(TextureLabels);
		List<LabelId> list2 = new List<LabelId>(FontLabels);
		List<LabelId> list3 = new List<LabelId>(FontAssetLabels);
		List<LabelId> textureLabels = default(List<LabelId>);
		List<LabelId> fontLabels = default(List<LabelId>);
		List<LabelId> fontAssetLabels = default(List<LabelId>);
		ThemeVariantData themeVariantData = new ThemeVariantData("Unnamed Variant", colorLabels, spriteLabels, textureLabels, fontLabels, fontAssetLabels);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049B8D0");
		DoozyUtils.SetDirty(this, saveAssets);
	}

	public bool ContainsColorProperty(Guid propertyId)
	{
		//IL_0080: Expected I4, but got O
		//IL_0017: Expected O, but got I4
		_003C_003Ec__DisplayClass38_0 obj = new _003C_003Ec__DisplayClass38_0();
		if (obj != null)
		{
			obj.propertyId = (Guid)propertyId._a;
			if (ColorLabels == null)
			{
				return false;
			}
			Func<LabelId, bool> func = null;
			bool flag = ((_003C_003Ec__DisplayClass38_0)(object)func)._003CContainsColorProperty_003Eb__0((LabelId)obj);
			return Enumerable.Any(ColorLabels, func);
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	public bool ContainsSpriteProperty(Guid propertyId)
	{
		//IL_0080: Expected I4, but got O
		//IL_0017: Expected O, but got I4
		_003C_003Ec__DisplayClass39_0 obj = new _003C_003Ec__DisplayClass39_0();
		if (obj != null)
		{
			obj.propertyId = (Guid)propertyId._a;
			if (SpriteLabels == null)
			{
				return false;
			}
			Func<LabelId, bool> func = null;
			bool flag = ((_003C_003Ec__DisplayClass39_0)(object)func)._003CContainsSpriteProperty_003Eb__0((LabelId)obj);
			return Enumerable.Any(SpriteLabels, func);
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	public bool ContainsTextureProperty(Guid propertyId)
	{
		//IL_0080: Expected I4, but got O
		//IL_0017: Expected O, but got I4
		_003C_003Ec__DisplayClass40_0 obj = new _003C_003Ec__DisplayClass40_0();
		if (obj != null)
		{
			obj.propertyId = (Guid)propertyId._a;
			if (TextureLabels == null)
			{
				return false;
			}
			Func<LabelId, bool> func = null;
			bool flag = ((_003C_003Ec__DisplayClass40_0)(object)func)._003CContainsTextureProperty_003Eb__0((LabelId)obj);
			return Enumerable.Any(TextureLabels, func);
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	public bool ContainsFontProperty(Guid propertyId)
	{
		//IL_0080: Expected I4, but got O
		//IL_0017: Expected O, but got I4
		_003C_003Ec__DisplayClass41_0 obj = new _003C_003Ec__DisplayClass41_0();
		if (obj != null)
		{
			obj.propertyId = (Guid)propertyId._a;
			if (FontLabels == null)
			{
				return false;
			}
			Func<LabelId, bool> func = null;
			bool flag = ((_003C_003Ec__DisplayClass41_0)(object)func)._003CContainsFontProperty_003Eb__0((LabelId)obj);
			return Enumerable.Any(FontLabels, func);
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	public bool ContainsFontAssetProperty(Guid propertyId)
	{
		//IL_0080: Expected I4, but got O
		//IL_0017: Expected O, but got I4
		_003C_003Ec__DisplayClass42_0 obj = new _003C_003Ec__DisplayClass42_0();
		if (obj != null)
		{
			obj.propertyId = (Guid)propertyId._a;
			if (FontAssetLabels == null)
			{
				return false;
			}
			Func<LabelId, bool> func = null;
			bool flag = ((_003C_003Ec__DisplayClass42_0)(object)func)._003CContainsFontAssetProperty_003Eb__0((LabelId)obj);
			return Enumerable.Any(FontAssetLabels, func);
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	public bool ContainsVariant(Guid variantGuid)
	{
		//IL_007e: Expected I4, but got O
		//IL_0017: Expected O, but got I4
		_003C_003Ec__DisplayClass43_0 CS_0024_003C_003E8__locals6 = new _003C_003Ec__DisplayClass43_0();
		if (CS_0024_003C_003E8__locals6 != null)
		{
			CS_0024_003C_003E8__locals6.variantGuid = (Guid)variantGuid._a;
			if (Variants == null)
			{
				return false;
			}
			Func<ThemeVariantData, bool> predicate = delegate(ThemeVariantData variant)
			{
				//IL_0117: Expected I4, but got O
				if (variant == null)
				{
					NullReferenceException ex2 = new NullReferenceException();
					return (byte)(int)ex2 != 0;
				}
				if ((object)CS_0024_003C_003E8__locals6.variantGuid == (object)variant.m_id)
				{
					object obj = (object)variant.m_id >> 32;
					object obj2 = (object)CS_0024_003C_003E8__locals6.variantGuid >> 32;
					if (obj2 == obj)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm1,8\"");
						Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm2,8\"");
						if ((object)CS_0024_003C_003E8__locals6.variantGuid == (object)variant.m_id)
						{
							object obj3 = (object)CS_0024_003C_003E8__locals6.variantGuid >> 32;
							object obj4 = (object)variant.m_id >> 32;
							object obj5 = obj3 - obj4;
							return obj5 == null;
						}
					}
				}
				return false;
			};
			return Enumerable.Any(Variants, predicate);
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	public unsafe bool ContainsVariant(string variantName)
	{
		//IL_007e: Expected I4, but got O
		_003C_003Ec__DisplayClass44_0 CS_0024_003C_003E8__locals6 = new _003C_003Ec__DisplayClass44_0();
		if (CS_0024_003C_003E8__locals6 != null)
		{
			CS_0024_003C_003E8__locals6.variantName = variantName;
			if (Variants == null)
			{
				return false;
			}
			Func<ThemeVariantData, bool> predicate = delegate(ThemeVariantData variant)
			{
				//IL_012f: Expected I4, but got O
				//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
				//IL_00d1: Expected Ref, but got Unknown
				//IL_00e8: Expected I8, but got I4
				//IL_00f6: Unknown result type (might be due to invalid IL or missing references)
				//IL_00fb: Expected Ref, but got Unknown
				if (variant != null)
				{
					string variantName2 = variant.m_variantName;
					if (variant.m_variantName != null)
					{
						string variantName3 = CS_0024_003C_003E8__locals6.variantName;
						if ((object)variant.m_variantName != CS_0024_003C_003E8__locals6.variantName)
						{
							if (CS_0024_003C_003E8__locals6.variantName != null && variantName2._stringLength == variantName3._stringLength)
							{
								ref byte second = ref *(byte*)(CS_0024_003C_003E8__locals6.variantName + 20);
								ulong length = (ulong)(variantName2._stringLength + variantName2._stringLength);
								return System.SpanHelpers.SequenceEqual(ref *(byte*)(variant.m_variantName + 20), ref second, length);
							}
							return false;
						}
						return true;
					}
				}
				NullReferenceException ex2 = new NullReferenceException();
				return (byte)(int)ex2 != 0;
			};
			return Enumerable.Any(Variants, predicate);
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	public ThemeVariantData GetVariant(Guid variantId)
	{
		//IL_0017: Expected O, but got I4
		_003C_003Ec__DisplayClass45_0 CS_0024_003C_003E8__locals6 = new _003C_003Ec__DisplayClass45_0();
		if (CS_0024_003C_003E8__locals6 != null)
		{
			CS_0024_003C_003E8__locals6.variantId = (Guid)variantId._a;
			Func<ThemeVariantData, bool> predicate = delegate(ThemeVariantData variant)
			{
				//IL_0117: Expected I4, but got O
				if (variant == null)
				{
					NullReferenceException ex = new NullReferenceException();
					return (byte)(int)ex != 0;
				}
				if ((object)CS_0024_003C_003E8__locals6.variantId == (object)variant.m_id)
				{
					object obj = (object)variant.m_id >> 32;
					object obj2 = (object)CS_0024_003C_003E8__locals6.variantId >> 32;
					if (obj2 == obj)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm1,8\"");
						Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm2,8\"");
						if ((object)CS_0024_003C_003E8__locals6.variantId == (object)variant.m_id)
						{
							object obj3 = (object)CS_0024_003C_003E8__locals6.variantId >> 32;
							object obj4 = (object)variant.m_id >> 32;
							object obj5 = obj3 - obj4;
							return obj5 == null;
						}
					}
				}
				return false;
			};
			return (ThemeVariantData)Enumerable.FirstOrDefault(Variants, (Func<object, bool>)predicate);
		}
		return (ThemeVariantData)(object)new NullReferenceException();
	}

	public unsafe ThemeVariantData GetVariant(string variantName)
	{
		_003C_003Ec__DisplayClass46_0 CS_0024_003C_003E8__locals6 = new _003C_003Ec__DisplayClass46_0();
		if (CS_0024_003C_003E8__locals6 != null)
		{
			CS_0024_003C_003E8__locals6.variantName = variantName;
			Func<ThemeVariantData, bool> predicate = delegate(ThemeVariantData variant)
			{
				//IL_012f: Expected I4, but got O
				//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
				//IL_00d1: Expected Ref, but got Unknown
				//IL_00e8: Expected I8, but got I4
				//IL_00f6: Unknown result type (might be due to invalid IL or missing references)
				//IL_00fb: Expected Ref, but got Unknown
				if (variant != null)
				{
					string variantName2 = variant.m_variantName;
					if (variant.m_variantName != null)
					{
						string variantName3 = CS_0024_003C_003E8__locals6.variantName;
						if ((object)variant.m_variantName != CS_0024_003C_003E8__locals6.variantName)
						{
							if (CS_0024_003C_003E8__locals6.variantName != null && variantName2._stringLength == variantName3._stringLength)
							{
								ref byte second = ref *(byte*)(CS_0024_003C_003E8__locals6.variantName + 20);
								ulong length = (ulong)(variantName2._stringLength + variantName2._stringLength);
								return System.SpanHelpers.SequenceEqual(ref *(byte*)(variant.m_variantName + 20), ref second, length);
							}
							return false;
						}
						return true;
					}
				}
				NullReferenceException ex = new NullReferenceException();
				return (byte)(int)ex != 0;
			};
			return (ThemeVariantData)Enumerable.FirstOrDefault(Variants, (Func<object, bool>)predicate);
		}
		return (ThemeVariantData)(object)new NullReferenceException();
	}

	public unsafe int GetColorPropertyIndex(Guid id)
	{
		//IL_000f: Expected O, but got Ref
		object obj = default(object);
		return GetPropertyIndex((Guid)(&obj), ColorLabels);
	}

	public unsafe int GetSpritePropertyIndex(Guid id)
	{
		//IL_000f: Expected O, but got Ref
		object obj = default(object);
		return GetPropertyIndex((Guid)(&obj), SpriteLabels);
	}

	public unsafe int GetTexturePropertyIndex(Guid id)
	{
		//IL_000f: Expected O, but got Ref
		object obj = default(object);
		return GetPropertyIndex((Guid)(&obj), TextureLabels);
	}

	public unsafe int GetFontPropertyIndex(Guid id)
	{
		//IL_000f: Expected O, but got Ref
		object obj = default(object);
		return GetPropertyIndex((Guid)(&obj), FontLabels);
	}

	public unsafe int GetFontAssetPropertyIndex(Guid id)
	{
		//IL_000f: Expected O, but got Ref
		object obj = default(object);
		return GetPropertyIndex((Guid)(&obj), FontAssetLabels);
	}

	public int GetVariantIndex(Guid id)
	{
		//IL_025f: Expected I4, but got I8
		if (id._a == (nint)Guid.Empty)
		{
			object obj = (object)Guid.Empty >> 32;
			int num = id._a >> 32;
			if (num == (nint)obj)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm3,8\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm2,8\"");
				if (id._a == (nint)Guid.Empty)
				{
					object obj2 = (object)Guid.Empty >> 32;
					int num2 = id._a >> 32;
					if (num2 == (nint)obj2)
					{
						goto IL_0252;
					}
				}
			}
		}
		List<ThemeVariantData> variants = Variants;
		int num3 = 0;
		int num4 = 0;
		int result = default(int);
		while (num4 < variants._size)
		{
			if (num3 < variants._size)
			{
				ThemeVariantData[] items = variants._items;
				ThemeVariantData themeVariantData = items[num3];
				if (id._a == (nint)themeVariantData.m_id)
				{
					object obj3 = (object)themeVariantData.m_id >> 32;
					int num5 = id._a >> 32;
					if (num5 == (nint)obj3)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm1,8\"");
						Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm2,8\"");
						if (id._a == (nint)themeVariantData.m_id)
						{
							object obj4 = (object)themeVariantData.m_id >> 32;
							int num6 = id._a >> 32;
							if (num6 != (nint)obj4)
							{
								num3++;
								num4 = num3;
								continue;
							}
							goto IL_0293;
						}
					}
				}
				num3++;
				num4 = num3;
				continue;
			}
			System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
			return result;
		}
		goto IL_0252;
		IL_0252:
		num3 = -1;
		goto IL_0293;
		IL_0293:
		return num3;
	}

	public unsafe void Init(bool showProgress, bool saveAssets)
	{
		//IL_001e: Expected O, but got Ref
		RefreshThemeVariants(showProgress, performUndo: false, saveAssets);
		ThemeVariantData activeVariant = ActiveVariant;
		if (activeVariant != null)
		{
			ThemeVariantData activeVariant2 = ActiveVariant;
			object obj = default(object);
			if (ContainsVariant((Guid)(&obj)))
			{
				return;
			}
		}
		List<ThemeVariantData> variants = Variants;
		if (variants._size > 0)
		{
			ThemeVariantData[] items = variants._items;
			m_activeVariant = items[0];
		}
		else
		{
			System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		}
	}

	public unsafe void RemoveColorProperty(Guid deleteGuid, bool performUndo, bool saveAssets)
	{
		//IL_006f: Expected O, but got Ref
		//IL_026f: Expected I, but got O
		//IL_009e: Expected O, but got I4
		//IL_00a6: Expected O, but got Ref
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899809BD]");
		bool flag = (nint)0 != 0;
		if (performUndo)
		{
			UILanguagePack instance = UILanguagePack.Instance;
			if ((object)instance == null)
			{
				goto IL_0221;
			}
			nint num = (nint)typeof(DoozyUtils);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v188 @ rcx_v33 (Il2CppClass<Doozy.Engine.Utils.DoozyUtils>)+E4]");
			flag = (nint)0 != 0;
			DoozyUtils.UndoRecordObject(this, instance.RemoveItem);
		}
		int num2 = default(int);
		RemoveProperty((Guid)(&num2), ColorLabels);
		if (Variants != null)
		{
			List<ThemeVariantData>.Enumerator enumerator = default(List<ThemeVariantData>.Enumerator);
			if (enumerator.MoveNext())
			{
				object obj = 0;
				List<ColorId> list = (List<ColorId>)(&enumerator);
				throw new NullReferenceException();
			}
			DoozyUtils.SetDirty(this, saveAssets);
			return;
		}
		goto IL_0221;
		IL_0221:
		throw new NullReferenceException();
	}

	public unsafe void RemoveSpriteProperty(Guid deleteGuid, bool performUndo, bool saveAssets)
	{
		//IL_006f: Expected O, but got Ref
		//IL_026f: Expected I, but got O
		//IL_009e: Expected O, but got I4
		//IL_00a6: Expected O, but got Ref
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899809BE]");
		bool flag = (nint)0 != 0;
		if (performUndo)
		{
			UILanguagePack instance = UILanguagePack.Instance;
			if ((object)instance == null)
			{
				goto IL_0221;
			}
			nint num = (nint)typeof(DoozyUtils);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v186 @ rcx_v33 (Il2CppClass<Doozy.Engine.Utils.DoozyUtils>)+E4]");
			flag = (nint)0 != 0;
			DoozyUtils.UndoRecordObject(this, instance.RemoveItem);
		}
		int num2 = default(int);
		RemoveProperty((Guid)(&num2), SpriteLabels);
		if (Variants != null)
		{
			List<ThemeVariantData>.Enumerator enumerator = default(List<ThemeVariantData>.Enumerator);
			if (enumerator.MoveNext())
			{
				object obj = 0;
				List<SpriteId> list = (List<SpriteId>)(&enumerator);
				throw new NullReferenceException();
			}
			DoozyUtils.SetDirty(this, saveAssets);
			return;
		}
		goto IL_0221;
		IL_0221:
		throw new NullReferenceException();
	}

	public unsafe void RemoveTextureProperty(Guid deleteGuid, bool performUndo, bool saveAssets)
	{
		//IL_006f: Expected O, but got Ref
		//IL_026f: Expected I, but got O
		//IL_009e: Expected O, but got I4
		//IL_00a6: Expected O, but got Ref
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899809BF]");
		bool flag = (nint)0 != 0;
		if (performUndo)
		{
			UILanguagePack instance = UILanguagePack.Instance;
			if ((object)instance == null)
			{
				goto IL_0221;
			}
			nint num = (nint)typeof(DoozyUtils);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v186 @ rcx_v33 (Il2CppClass<Doozy.Engine.Utils.DoozyUtils>)+E4]");
			flag = (nint)0 != 0;
			DoozyUtils.UndoRecordObject(this, instance.RemoveItem);
		}
		int num2 = default(int);
		RemoveProperty((Guid)(&num2), TextureLabels);
		if (Variants != null)
		{
			List<ThemeVariantData>.Enumerator enumerator = default(List<ThemeVariantData>.Enumerator);
			if (enumerator.MoveNext())
			{
				object obj = 0;
				List<TextureId> list = (List<TextureId>)(&enumerator);
				throw new NullReferenceException();
			}
			DoozyUtils.SetDirty(this, saveAssets);
			return;
		}
		goto IL_0221;
		IL_0221:
		throw new NullReferenceException();
	}

	public unsafe void RemoveFontProperty(Guid deleteGuid, bool performUndo, bool saveAssets)
	{
		//IL_006f: Expected O, but got Ref
		//IL_026f: Expected I, but got O
		//IL_009e: Expected O, but got I4
		//IL_00a6: Expected O, but got Ref
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899809C0]");
		bool flag = (nint)0 != 0;
		if (performUndo)
		{
			UILanguagePack instance = UILanguagePack.Instance;
			if ((object)instance == null)
			{
				goto IL_0221;
			}
			nint num = (nint)typeof(DoozyUtils);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v186 @ rcx_v33 (Il2CppClass<Doozy.Engine.Utils.DoozyUtils>)+E4]");
			flag = (nint)0 != 0;
			DoozyUtils.UndoRecordObject(this, instance.RemoveItem);
		}
		int num2 = default(int);
		RemoveProperty((Guid)(&num2), FontLabels);
		if (Variants != null)
		{
			List<ThemeVariantData>.Enumerator enumerator = default(List<ThemeVariantData>.Enumerator);
			if (enumerator.MoveNext())
			{
				object obj = 0;
				List<FontId> list = (List<FontId>)(&enumerator);
				throw new NullReferenceException();
			}
			DoozyUtils.SetDirty(this, saveAssets);
			return;
		}
		goto IL_0221;
		IL_0221:
		throw new NullReferenceException();
	}

	public unsafe void RemoveFontAssetProperty(Guid deleteGuid, bool performUndo, bool saveAssets)
	{
		//IL_006f: Expected O, but got Ref
		//IL_026f: Expected I, but got O
		//IL_009e: Expected O, but got I4
		//IL_00a6: Expected O, but got Ref
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899809C1]");
		bool flag = (nint)0 != 0;
		if (performUndo)
		{
			UILanguagePack instance = UILanguagePack.Instance;
			if ((object)instance == null)
			{
				goto IL_0221;
			}
			nint num = (nint)typeof(DoozyUtils);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v187 @ rcx_v33 (Il2CppClass<Doozy.Engine.Utils.DoozyUtils>)+E4]");
			flag = (nint)0 != 0;
			DoozyUtils.UndoRecordObject(this, instance.RemoveItem);
		}
		int num2 = default(int);
		RemoveProperty((Guid)(&num2), FontAssetLabels);
		if (Variants != null)
		{
			List<ThemeVariantData>.Enumerator enumerator = default(List<ThemeVariantData>.Enumerator);
			if (enumerator.MoveNext())
			{
				object obj = 0;
				List<FontAssetId> list = (List<FontAssetId>)(&enumerator);
				throw new NullReferenceException();
			}
			DoozyUtils.SetDirty(this, saveAssets);
			return;
		}
		goto IL_0221;
		IL_0221:
		throw new NullReferenceException();
	}

	public void RefreshThemeVariants(bool showProgress, bool performUndo, bool saveAssets)
	{
		//IL_017c: Expected I, but got O
		//IL_022c: Expected I, but got O
		//IL_02d4: Expected I, but got O
		//IL_0372: Expected I, but got O
		if (showProgress)
		{
			UILanguagePack instance = UILanguagePack.Instance;
			string text = instance.ThemeName + ": " + m_themeName;
			UILanguagePack instance2 = UILanguagePack.Instance;
		}
		if (performUndo)
		{
			UILanguagePack instance3 = UILanguagePack.Instance;
			DoozyUtils.UndoRecordObject(this, instance3.RefreshDatabase);
		}
		if (showProgress)
		{
			UILanguagePack instance4 = UILanguagePack.Instance;
			string text2 = instance4.ThemeName + ": " + m_themeName;
			UILanguagePack instance5 = UILanguagePack.Instance;
		}
		List<LabelId> colorLabels = ColorLabels;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v198 @ rax_v7 (System.Collections.Generic.List`1<Doozy.Engine.Themes.LabelId>)+18]");
		if ((nint)0 == 0)
		{
			AddDefaultColorLabels();
		}
		if (showProgress)
		{
			UILanguagePack instance6 = UILanguagePack.Instance;
			string text3 = instance6.ThemeName + ": " + m_themeName;
			UILanguagePack instance7 = UILanguagePack.Instance;
			nint num = (nint)typeof(DoozyUtils);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v501 @ rcx_v37 (Il2CppClass<Doozy.Engine.Utils.DoozyUtils>)+E4]");
			if ((nint)0 == 0)
			{
				bool flag = AddDefaultVariant();
				goto IL_01e5;
			}
		}
		bool flag2 = AddDefaultVariant();
		if (showProgress)
		{
			goto IL_01e5;
		}
		goto IL_0269;
		IL_02f0:
		bool flag3;
		if (!flag3)
		{
			DoozyUtils.SetDirty(this, saveAssets);
		}
		if (showProgress)
		{
			UILanguagePack instance8 = UILanguagePack.Instance;
			string text4 = instance8.ThemeName + ": " + m_themeName;
			UILanguagePack instance9 = UILanguagePack.Instance;
			nint num2 = (nint)typeof(DoozyUtils);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v709 @ rcx_v13 (Il2CppClass<Doozy.Engine.Utils.DoozyUtils>)+E4]");
			if ((nint)0 != 0)
			{
			}
		}
		return;
		IL_0269:
		UpdateVariantsNames(saveAssets: false);
		flag3 = !showProgress;
		if (!flag3)
		{
			goto IL_028d;
		}
		goto IL_02f0;
		IL_028d:
		UILanguagePack instance10 = UILanguagePack.Instance;
		string text5 = instance10.ThemeName + ": " + m_themeName;
		UILanguagePack instance11 = UILanguagePack.Instance;
		nint num3 = (nint)typeof(DoozyUtils);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v624 @ rcx_v23 (Il2CppClass<Doozy.Engine.Utils.DoozyUtils>)+E4]");
		flag3 = (nint)0 == 0;
		goto IL_02f0;
		IL_01e5:
		UILanguagePack instance12 = UILanguagePack.Instance;
		string text6 = instance12.ThemeName + ": " + m_themeName;
		UILanguagePack instance13 = UILanguagePack.Instance;
		nint num4 = (nint)typeof(DoozyUtils);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v563 @ rcx_v30 (Il2CppClass<Doozy.Engine.Utils.DoozyUtils>)+E4]");
		if ((nint)0 != 0)
		{
			goto IL_0269;
		}
		UpdateVariantsNames(saveAssets: false);
		goto IL_028d;
	}

	public bool RemoveVariant(ThemeVariantData data, bool performUndo = false, bool showDialog = false, bool saveAssets = false)
	{
		//IL_022e: Expected I4, but got O
		if (data != null)
		{
			if (Variants != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049B860");
				object obj = default(object);
				if (obj == null)
				{
					goto IL_01f5;
				}
				List<ThemeVariantData> variants = Variants;
				bool flag = (nint)Variants < 0;
				if (Variants != null)
				{
					int num = variants._size - 1;
					if (flag)
					{
						goto IL_0147;
					}
					List<ThemeVariantData> variants2 = Variants;
					while (true)
					{
						if (num < variants2._size)
						{
							ThemeVariantData[] items = variants2._items;
							if (variants2._items == null)
							{
								break;
							}
							if (items[num] != data)
							{
								int num2 = num - 1;
								ThemeVariantData themeVariantData = items[num];
								bool flag2 = System.Runtime.CompilerServices.Unsafe.As<ThemeVariantData, UIntPtr>(ref themeVariantData) >= System.Runtime.CompilerServices.Unsafe.As<ThemeVariantData, UIntPtr>(ref data);
								num = num2;
								if (flag2)
								{
									continue;
								}
							}
							else
							{
								if (performUndo)
								{
									UILanguagePack instance = UILanguagePack.Instance;
									if ((object)instance == null)
									{
										break;
									}
									UndoRecord(instance.RemovedEntry);
								}
								if (Variants == null)
								{
									break;
								}
								Variants.RemoveAt(num);
							}
							goto IL_0147;
						}
						System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
						break;
					}
				}
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
		goto IL_01f5;
		IL_01f5:
		return false;
		IL_0147:
		UpdateVariantsNames(saveAssets: false);
		bool dirty = default(bool);
		SetDirty(dirty);
		return true;
	}

	public void SetDirty(bool saveAssets)
	{
		DoozyUtils.SetDirty(this, saveAssets);
	}

	public void Sort(bool performUndo, bool saveAssets)
	{
		Func<ThemeVariantData, string> keySelector = _003C_003Ec._003C_003E9__62_0;
		if (_003C_003Ec._003C_003E9__62_0 == null)
		{
			keySelector = (_003C_003Ec._003C_003E9__62_0 = (ThemeVariantData variant) => (string)((variant != null) ? ((object)variant.m_variantName) : ((object)new NullReferenceException())));
		}
		IOrderedEnumerable<ThemeVariantData> orderedEnumerable = Enumerable.OrderBy(Variants, keySelector);
		if (orderedEnumerable != null)
		{
			List<object> variants = new List<object>(orderedEnumerable);
			Variants = (List<ThemeVariantData>)(object)variants;
			Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 256 Invalid \"Jump target not found in method: 0x182C0F3D0\"");
		}
		Exception ex = System.Linq.Error.ArgumentNull("source");
		throw ex;
	}

	public void UndoRecord(string undoMessage)
	{
		DoozyUtils.UndoRecordObject(this, undoMessage);
	}

	public void UpdateVariantsNames(bool saveAssets)
	{
		List<string> variantsNames = VariantsNames;
		int version = variantsNames._version + 1;
		variantsNames._version = version;
		variantsNames._size = 0;
		if (variantsNames._size > 0)
		{
			Array.Clear(variantsNames._items, 0, variantsNames._size);
		}
		Func<ThemeVariantData, string> selector = _003C_003Ec._003C_003E9__64_0;
		if (_003C_003Ec._003C_003E9__64_0 == null)
		{
			selector = (_003C_003Ec._003C_003E9__64_0 = (ThemeVariantData variant) => (string)((variant != null) ? ((object)variant.m_variantName) : ((object)new NullReferenceException())));
		}
		IEnumerable<string> enumerable = Enumerable.Select(Variants, selector);
		if (enumerable != null)
		{
			List<object> list = new List<object>(enumerable);
			list.Sort();
			List<object> variantsNames2 = (List<object>)(object)VariantsNames;
			((List<object>)(object)VariantsNames).InsertRange(variantsNames2._size, (IEnumerable<object>)list);
			DoozyUtils.SetDirty(this, saveAssets);
			return;
		}
		Exception ex = System.Linq.Error.ArgumentNull("source");
		throw ex;
	}

	private unsafe void AddDefaultColorLabels()
	{
		//IL_0008: Expected O, but got Ref
		//IL_0196: Expected O, but got Ref
		//IL_002a: Expected O, but got Ref
		//IL_0038: Expected O, but got Ref
		//IL_0070: Expected O, but got Ref
		//IL_007e: Expected O, but got Ref
		//IL_00b6: Expected O, but got Ref
		//IL_00c4: Expected O, but got Ref
		//IL_00fc: Expected O, but got Ref
		//IL_010a: Expected O, but got Ref
		//IL_0142: Expected O, but got Ref
		//IL_0150: Expected O, but got Ref
		//IL_0187: Expected O, but got Ref
		object obj2 = default(object);
		object obj = (object)(&obj2);
		object obj3 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 105));
		_ = 0;
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182C02A00");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-59]");
		_ = 0;
		object obj4 = default(object);
		ColorLabels.Add((LabelId)(&obj4));
		object obj5 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 73));
		_ = 0;
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182C02A00");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-39]");
		_ = 0;
		ColorLabels.Add((LabelId)(&obj4));
		object obj6 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
		_ = 0;
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182C02A00");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-19]");
		_ = 0;
		ColorLabels.Add((LabelId)(&obj4));
		object obj7 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 9));
		_ = 0;
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182C02A00");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+7]");
		_ = 0;
		ColorLabels.Add((LabelId)(&obj4));
		object obj8 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 23));
		_ = 0;
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182C02A00");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+27]");
		_ = 0;
		ColorLabels.Add((LabelId)(&obj4));
		object obj9 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 55));
		_ = 0;
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182C02A00");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+47]");
		_ = 0;
		ColorLabels.Add((LabelId)(&obj4));
	}

	private unsafe bool AddDefaultVariant(bool saveAssets = false)
	{
		//IL_0155: Expected I4, but got O
		List<ThemeVariantData> variants = Variants;
		if (Variants != null)
		{
			if (variants._size > 0)
			{
				goto IL_0139;
			}
			_003C_003Ec__DisplayClass44_0 CS_0024_003C_003E8__locals6 = new _003C_003Ec__DisplayClass44_0();
			if (CS_0024_003C_003E8__locals6 != null)
			{
				CS_0024_003C_003E8__locals6.variantName = "Default";
				if (Variants != null)
				{
					Func<ThemeVariantData, bool> predicate = delegate(ThemeVariantData variant)
					{
						//IL_012f: Expected I4, but got O
						//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
						//IL_00d1: Expected Ref, but got Unknown
						//IL_00e8: Expected I8, but got I4
						//IL_00f6: Unknown result type (might be due to invalid IL or missing references)
						//IL_00fb: Expected Ref, but got Unknown
						if (variant != null)
						{
							string variantName = variant.m_variantName;
							if (variant.m_variantName != null)
							{
								string variantName2 = CS_0024_003C_003E8__locals6.variantName;
								if ((object)variant.m_variantName != CS_0024_003C_003E8__locals6.variantName)
								{
									if (CS_0024_003C_003E8__locals6.variantName != null && variantName._stringLength == variantName2._stringLength)
									{
										ref byte second = ref *(byte*)(CS_0024_003C_003E8__locals6.variantName + 20);
										ulong length = (ulong)(variantName._stringLength + variantName._stringLength);
										return System.SpanHelpers.SequenceEqual(ref *(byte*)(variant.m_variantName + 20), ref second, length);
									}
									return false;
								}
								return true;
							}
						}
						NullReferenceException ex2 = new NullReferenceException();
						return (byte)(int)ex2 != 0;
					};
					if (Enumerable.Any(Variants, predicate))
					{
						goto IL_0139;
					}
				}
				if (VariantsNames != null)
				{
					VariantsNames.Add("Default");
					List<LabelId> textureLabels = default(List<LabelId>);
					List<LabelId> fontLabels = default(List<LabelId>);
					List<LabelId> fontAssetLabels = default(List<LabelId>);
					ThemeVariantData themeVariantData = new ThemeVariantData("Default", ColorLabels, SpriteLabels, textureLabels, fontLabels, fontAssetLabels);
					if (Variants != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049B8D0");
						SetDirty(saveAssets);
						return true;
					}
				}
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
		IL_0139:
		return false;
	}

	private static int GetPropertyIndex(Guid id, List<LabelId> propertyList)
	{
		//IL_0259: Expected I4, but got I8
		//IL_011f: Expected O, but got I
		//IL_0132: Expected O, but got I4
		//IL_0182: Expected O, but got I
		//IL_020a: Expected O, but got I
		if (id._a == (nint)Guid.Empty)
		{
			object obj = (object)Guid.Empty >> 32;
			int num = id._a >> 32;
			if (num == (nint)obj)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm3,8\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm2,8\"");
				if (id._a == (nint)Guid.Empty)
				{
					object obj2 = (object)Guid.Empty >> 32;
					int num2 = id._a >> 32;
					if (num2 == (nint)obj2)
					{
						goto IL_024c;
					}
				}
			}
		}
		int num3;
		if (propertyList != null)
		{
			num3 = 0;
			int result = default(int);
			while (true)
			{
				int num4 = num3;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [propertyList @ rdx (System.Collections.Generic.List`1<Doozy.Engine.Themes.LabelId>)+18]");
				if ((nint)num4 >= (nint)0)
				{
					break;
				}
				int num5 = num3;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [propertyList @ rdx (System.Collections.Generic.List`1<Doozy.Engine.Themes.LabelId>)+18]");
				if ((nint)num5 < (nint)0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [propertyList @ rdx (System.Collections.Generic.List`1<Doozy.Engine.Themes.LabelId>)+10]");
					object obj3 = 0;
					object obj4 = num3 + 1;
					object obj5 = obj4 << 5;
					int a = id._a;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v297 @ rcx_v11+10+v258 @ rdx_v5]");
					if ((nint)a != 0)
					{
						goto IL_0239;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v297 @ rcx_v11+10+v258 @ rdx_v5]");
					object obj6 = (nint)0 >> 32;
					int num6 = id._a >> 32;
					if (num6 != (nint)obj6)
					{
						goto IL_0239;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm1,8\"");
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm2,8\"");
					int a2 = id._a;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v297 @ rcx_v11+10+v258 @ rdx_v5]");
					if ((nint)a2 != 0)
					{
						goto IL_0239;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v297 @ rcx_v11+10+v258 @ rdx_v5]");
					object obj7 = (nint)0 >> 32;
					int num7 = id._a >> 32;
					if (num7 != (nint)obj7)
					{
						goto IL_0239;
					}
					goto IL_028d;
				}
				System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
				return result;
				IL_0239:
				num3++;
			}
		}
		goto IL_024c;
		IL_028d:
		return num3;
		IL_024c:
		num3 = -1;
		goto IL_028d;
	}

	private static void RemoveProperty(Guid deleteGuid, List<LabelId> propertyList)
	{
		//IL_001b: Expected O, but got I
		//IL_0039: Expected O, but got I
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Expected O, but got Unknown
		//IL_0074: Expected O, but got I
		//IL_01e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01eb: Expected O, but got Unknown
		//IL_01f6: Expected O, but got I4
		//IL_00c5: Expected O, but got I
		//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e5: Expected O, but got Unknown
		//IL_0141: Expected O, but got I
		//IL_0192: Expected O, but got I
		//IL_01ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b2: Expected O, but got Unknown
		bool flag = (nint)propertyList < 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [propertyList @ rdx (System.Collections.Generic.List`1<Doozy.Engine.Themes.LabelId>)+18]");
		object obj = -1;
		if (flag)
		{
			return;
		}
		while (true)
		{
			object obj2 = obj;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [propertyList @ rdx (System.Collections.Generic.List`1<Doozy.Engine.Themes.LabelId>)+18]");
			if ((nint)obj2 >= 0)
			{
				break;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [propertyList @ rdx (System.Collections.Generic.List`1<Doozy.Engine.Themes.LabelId>)+10]");
			object obj3 = 0;
			object obj4 = obj + 1;
			object obj5 = obj4 << 5;
			int a = deleteGuid._a;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v227 @ rax_v12+10+v61 @ rcx_v8]");
			object obj6 = (nint)a - (nint)0;
			bool flag2 = (nint)obj6 < 0;
			int a2 = deleteGuid._a;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v227 @ rax_v12+10+v61 @ rcx_v8]");
			if ((nint)a2 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v227 @ rax_v12+10+v61 @ rcx_v8]");
				object obj7 = (nint)0 >> 32;
				int num = deleteGuid._a >> 32;
				object obj8 = num - obj7;
				flag2 = (nint)obj8 < 0;
				if (num == (nint)obj7)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm1,8\"");
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm2,8\"");
					int a3 = deleteGuid._a;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v227 @ rax_v12+10+v61 @ rcx_v8]");
					object obj9 = (nint)a3 - (nint)0;
					flag2 = (nint)obj9 < 0;
					int a4 = deleteGuid._a;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v227 @ rax_v12+10+v61 @ rcx_v8]");
					if ((nint)a4 == 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v227 @ rax_v12+10+v61 @ rcx_v8]");
						object obj10 = (nint)0 >> 32;
						int num2 = deleteGuid._a >> 32;
						object obj11 = num2 - obj10;
						flag2 = (nint)obj11 < 0;
						if (num2 == (nint)obj10)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049BFE0");
							return;
						}
					}
				}
			}
			obj--;
			object obj12 = !flag2;
			if (obj12 == null)
			{
				return;
			}
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}
}
