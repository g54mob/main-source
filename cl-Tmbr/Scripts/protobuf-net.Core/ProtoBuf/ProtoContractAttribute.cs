using System;
using System.Diagnostics.CodeAnalysis;
using ProtoBuf.Internal;

namespace ProtoBuf
{
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Enum | AttributeTargets.Interface, AllowMultiple = false, Inherited = false)]
	public sealed class ProtoContractAttribute : Attribute
	{
		[Flags]
		private enum TypeOptions : ushort
		{
			InferTagFromName = 1,
			InferTagFromNameHasValue = 2,
			UseProtoMembersOnly = 4,
			SkipConstructor = 8,
			IgnoreListHandling = 0x10,
			IsGroup = 0x100,
			IgnoreUnknownSubTypes = 0x200
		}

		internal const string ReferenceDynamicDisabled = "Reference-tracking and dynamic-type are not currently implemented in this build; they may be reinstated later; this is partly due to doubts over whether the features are adviseable, and partly over confidence in testing all the scenarios (it takes time; that time hasn't get happened); feedback is invited";

		private int implicitFirstTag;

		private TypeOptions flags;

		public string Name { get; set; }

		public string Origin { get; set; }

		public int ImplicitFirstTag
		{
			get
			{
				return implicitFirstTag;
			}
			set
			{
				if (value < 1)
				{
					ThrowHelper.ThrowArgumentOutOfRangeException("ImplicitFirstTag");
				}
				implicitFirstTag = value;
			}
		}

		public bool UseProtoMembersOnly
		{
			get
			{
				return HasFlag(TypeOptions.UseProtoMembersOnly);
			}
			set
			{
				SetFlag(TypeOptions.UseProtoMembersOnly, value);
			}
		}

		public bool IgnoreListHandling
		{
			get
			{
				return HasFlag(TypeOptions.IgnoreListHandling);
			}
			set
			{
				SetFlag(TypeOptions.IgnoreListHandling, value);
			}
		}

		public ImplicitFields ImplicitFields { get; set; }

		public bool InferTagFromName
		{
			get
			{
				return HasFlag(TypeOptions.InferTagFromName);
			}
			set
			{
				SetFlag(TypeOptions.InferTagFromName, value);
				SetFlag(TypeOptions.InferTagFromNameHasValue, value: true);
			}
		}

		internal bool InferTagFromNameHasValue => HasFlag(TypeOptions.InferTagFromNameHasValue);

		public int DataMemberOffset { get; set; }

		public bool SkipConstructor
		{
			get
			{
				return HasFlag(TypeOptions.SkipConstructor);
			}
			set
			{
				SetFlag(TypeOptions.SkipConstructor, value);
			}
		}

		public bool AsReferenceDefault
		{
			get
			{
				return false;
			}
			[Obsolete("Reference-tracking and dynamic-type are not currently implemented in this build; they may be reinstated later; this is partly due to doubts over whether the features are adviseable, and partly over confidence in testing all the scenarios (it takes time; that time hasn't get happened); feedback is invited", true)]
			set
			{
				if (value != AsReferenceDefault)
				{
					ThrowHelper.ThrowNotSupportedException();
				}
			}
		}

		public bool IsGroup
		{
			get
			{
				return HasFlag(TypeOptions.IsGroup);
			}
			set
			{
				SetFlag(TypeOptions.IsGroup, value);
			}
		}

		public bool IgnoreUnknownSubTypes
		{
			get
			{
				return HasFlag(TypeOptions.IgnoreUnknownSubTypes);
			}
			set
			{
				SetFlag(TypeOptions.IgnoreUnknownSubTypes, value);
			}
		}

		[Obsolete("Enum value maps have been deprecated and are no longer supported; all enums are now effectively pass-thru; custom maps should be applied via shadow properties; in C#, lambda-based 'switch expressions' make for very convenient shadow properties", true)]
		public bool EnumPassthru
		{
			get
			{
				return true;
			}
			set
			{
				if (!value)
				{
					ThrowHelper.ThrowInvalidOperationException("EnumPassthru is not longer supported, and is always considered true");
				}
			}
		}

		public Type Surrogate { get; set; }

		[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicParameterlessConstructor | DynamicallyAccessedMemberTypes.PublicMethods)]
		public Type Serializer { get; set; }

		private bool HasFlag(TypeOptions flag)
		{
			return (flags & flag) == flag;
		}

		private void SetFlag(TypeOptions flag, bool value)
		{
			if (value)
			{
				flags |= flag;
			}
			else
			{
				flags &= (TypeOptions)(ushort)(~(int)flag);
			}
		}
	}
}
