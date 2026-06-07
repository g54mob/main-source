using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf.Collections;

namespace Google.Protobuf.Reflection
{
	[DebuggerDisplay("{ToString(),nq}")]
	public sealed class FileOptions : IExtendableMessage<FileOptions>, IMessage<FileOptions>, IMessage, IEquatable<FileOptions>, IDeepCloneable<FileOptions>, IBufferMessage
	{
		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public static class Types
		{
			public enum OptimizeMode
			{
				[OriginalName("SPEED")]
				Speed = 1,
				[OriginalName("CODE_SIZE")]
				CodeSize = 2,
				[OriginalName("LITE_RUNTIME")]
				LiteRuntime = 3
			}
		}

		private static readonly MessageParser<FileOptions> _parser;

		private UnknownFieldSet _unknownFields;

		internal ExtensionSet<FileOptions> _extensions;

		private int _hasBits0;

		public const int JavaPackageFieldNumber = 1;

		private static readonly string JavaPackageDefaultValue;

		private string javaPackage_;

		public const int JavaOuterClassnameFieldNumber = 8;

		private static readonly string JavaOuterClassnameDefaultValue;

		private string javaOuterClassname_;

		public const int JavaMultipleFilesFieldNumber = 10;

		private static readonly bool JavaMultipleFilesDefaultValue;

		private bool javaMultipleFiles_;

		public const int JavaGenerateEqualsAndHashFieldNumber = 20;

		private static readonly bool JavaGenerateEqualsAndHashDefaultValue;

		private bool javaGenerateEqualsAndHash_;

		public const int JavaStringCheckUtf8FieldNumber = 27;

		private static readonly bool JavaStringCheckUtf8DefaultValue;

		private bool javaStringCheckUtf8_;

		public const int OptimizeForFieldNumber = 9;

		private static readonly Types.OptimizeMode OptimizeForDefaultValue;

		private Types.OptimizeMode optimizeFor_;

		public const int GoPackageFieldNumber = 11;

		private static readonly string GoPackageDefaultValue;

		private string goPackage_;

		public const int CcGenericServicesFieldNumber = 16;

		private static readonly bool CcGenericServicesDefaultValue;

		private bool ccGenericServices_;

		public const int JavaGenericServicesFieldNumber = 17;

		private static readonly bool JavaGenericServicesDefaultValue;

		private bool javaGenericServices_;

		public const int PyGenericServicesFieldNumber = 18;

		private static readonly bool PyGenericServicesDefaultValue;

		private bool pyGenericServices_;

		public const int PhpGenericServicesFieldNumber = 42;

		private static readonly bool PhpGenericServicesDefaultValue;

		private bool phpGenericServices_;

		public const int DeprecatedFieldNumber = 23;

		private static readonly bool DeprecatedDefaultValue;

		private bool deprecated_;

		public const int CcEnableArenasFieldNumber = 31;

		private static readonly bool CcEnableArenasDefaultValue;

		private bool ccEnableArenas_;

		public const int ObjcClassPrefixFieldNumber = 36;

		private static readonly string ObjcClassPrefixDefaultValue;

		private string objcClassPrefix_;

		public const int CsharpNamespaceFieldNumber = 37;

		private static readonly string CsharpNamespaceDefaultValue;

		private string csharpNamespace_;

		public const int SwiftPrefixFieldNumber = 39;

		private static readonly string SwiftPrefixDefaultValue;

		private string swiftPrefix_;

		public const int PhpClassPrefixFieldNumber = 40;

		private static readonly string PhpClassPrefixDefaultValue;

		private string phpClassPrefix_;

		public const int PhpNamespaceFieldNumber = 41;

		private static readonly string PhpNamespaceDefaultValue;

		private string phpNamespace_;

		public const int PhpMetadataNamespaceFieldNumber = 44;

		private static readonly string PhpMetadataNamespaceDefaultValue;

		private string phpMetadataNamespace_;

		public const int RubyPackageFieldNumber = 45;

		private static readonly string RubyPackageDefaultValue;

		private string rubyPackage_;

		public const int FeaturesFieldNumber = 50;

		private FeatureSet features_;

		public const int UninterpretedOptionFieldNumber = 999;

		private static readonly FieldCodec<UninterpretedOption> _repeated_uninterpretedOption_codec;

		private readonly RepeatedField<UninterpretedOption> uninterpretedOption_;

		private ExtensionSet<FileOptions> _Extensions => null;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public static MessageParser<FileOptions> Parser => null;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public static MessageDescriptor Descriptor => null;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		MessageDescriptor IMessage.Descriptor => null;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public string JavaPackage
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public bool HasJavaPackage => false;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public string JavaOuterClassname
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public bool HasJavaOuterClassname => false;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public bool JavaMultipleFiles
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public bool HasJavaMultipleFiles => false;

		[Obsolete]
		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public bool JavaGenerateEqualsAndHash
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		[Obsolete]
		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public bool HasJavaGenerateEqualsAndHash => false;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public bool JavaStringCheckUtf8
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public bool HasJavaStringCheckUtf8 => false;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public Types.OptimizeMode OptimizeFor
		{
			get
			{
				return default(Types.OptimizeMode);
			}
			set
			{
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public bool HasOptimizeFor => false;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public string GoPackage
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public bool HasGoPackage => false;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public bool CcGenericServices
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public bool HasCcGenericServices => false;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public bool JavaGenericServices
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public bool HasJavaGenericServices => false;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public bool PyGenericServices
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public bool HasPyGenericServices => false;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public bool PhpGenericServices
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public bool HasPhpGenericServices => false;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public bool Deprecated
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public bool HasDeprecated => false;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public bool CcEnableArenas
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public bool HasCcEnableArenas => false;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public string ObjcClassPrefix
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public bool HasObjcClassPrefix => false;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public string CsharpNamespace
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public bool HasCsharpNamespace => false;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public string SwiftPrefix
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public bool HasSwiftPrefix => false;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public string PhpClassPrefix
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public bool HasPhpClassPrefix => false;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public string PhpNamespace
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public bool HasPhpNamespace => false;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public string PhpMetadataNamespace
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public bool HasPhpMetadataNamespace => false;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public string RubyPackage
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public bool HasRubyPackage => false;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public FeatureSet Features
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public RepeatedField<UninterpretedOption> UninterpretedOption => null;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public FileOptions()
		{
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public FileOptions(FileOptions other)
		{
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public FileOptions Clone()
		{
			return null;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public void ClearJavaPackage()
		{
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public void ClearJavaOuterClassname()
		{
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public void ClearJavaMultipleFiles()
		{
		}

		[Obsolete]
		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public void ClearJavaGenerateEqualsAndHash()
		{
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public void ClearJavaStringCheckUtf8()
		{
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public void ClearOptimizeFor()
		{
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public void ClearGoPackage()
		{
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public void ClearCcGenericServices()
		{
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public void ClearJavaGenericServices()
		{
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public void ClearPyGenericServices()
		{
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public void ClearPhpGenericServices()
		{
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public void ClearDeprecated()
		{
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public void ClearCcEnableArenas()
		{
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public void ClearObjcClassPrefix()
		{
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public void ClearCsharpNamespace()
		{
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public void ClearSwiftPrefix()
		{
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public void ClearPhpClassPrefix()
		{
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public void ClearPhpNamespace()
		{
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public void ClearPhpMetadataNamespace()
		{
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public void ClearRubyPackage()
		{
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public override bool Equals(object other)
		{
			return false;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public bool Equals(FileOptions other)
		{
			return false;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public override int GetHashCode()
		{
			return 0;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public override string ToString()
		{
			return null;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public void WriteTo(CodedOutputStream output)
		{
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		void IBufferMessage.InternalWriteTo(ref WriteContext output)
		{
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public int CalculateSize()
		{
			return 0;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public void MergeFrom(FileOptions other)
		{
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public void MergeFrom(CodedInputStream input)
		{
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		void IBufferMessage.InternalMergeFrom(ref ParseContext input)
		{
		}

		public TValue GetExtension<TValue>(Extension<FileOptions, TValue> extension)
		{
			return default(TValue);
		}

		public RepeatedField<TValue> GetExtension<TValue>(RepeatedExtension<FileOptions, TValue> extension)
		{
			return null;
		}

		public RepeatedField<TValue> GetOrInitializeExtension<TValue>(RepeatedExtension<FileOptions, TValue> extension)
		{
			return null;
		}

		public void SetExtension<TValue>(Extension<FileOptions, TValue> extension, TValue value)
		{
		}

		public bool HasExtension<TValue>(Extension<FileOptions, TValue> extension)
		{
			return false;
		}

		public void ClearExtension<TValue>(Extension<FileOptions, TValue> extension)
		{
		}

		public void ClearExtension<TValue>(RepeatedExtension<FileOptions, TValue> extension)
		{
		}
	}
}
