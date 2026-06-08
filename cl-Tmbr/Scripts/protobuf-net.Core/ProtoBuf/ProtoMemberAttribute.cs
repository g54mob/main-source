using System;
using System.Reflection;
using ProtoBuf.Internal;

namespace ProtoBuf
{
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
	public class ProtoMemberAttribute : Attribute, IComparable, IComparable<ProtoMemberAttribute>
	{
		internal MemberInfo Member;

		internal MemberInfo BackingMember;

		internal bool TagIsPinned;

		private string name;

		private DataFormat dataFormat;

		private int tag;

		private MemberSerializationOptions options;

		public string Name
		{
			get
			{
				return name;
			}
			set
			{
				name = value;
			}
		}

		public DataFormat DataFormat
		{
			get
			{
				return dataFormat;
			}
			set
			{
				dataFormat = value;
			}
		}

		public int Tag => tag;

		public bool IsRequired
		{
			get
			{
				return (options & MemberSerializationOptions.Required) == MemberSerializationOptions.Required;
			}
			set
			{
				if (value)
				{
					options |= MemberSerializationOptions.Required;
				}
				else
				{
					options &= ~MemberSerializationOptions.Required;
				}
			}
		}

		public bool IsPacked
		{
			get
			{
				return (options & MemberSerializationOptions.Packed) == MemberSerializationOptions.Packed;
			}
			set
			{
				if (value)
				{
					options |= MemberSerializationOptions.Packed;
				}
				else
				{
					options &= ~MemberSerializationOptions.Packed;
				}
			}
		}

		public bool OverwriteList
		{
			get
			{
				return (options & MemberSerializationOptions.OverwriteList) == MemberSerializationOptions.OverwriteList;
			}
			set
			{
				if (value)
				{
					options |= MemberSerializationOptions.OverwriteList;
				}
				else
				{
					options &= ~MemberSerializationOptions.OverwriteList;
				}
			}
		}

		[Obsolete("Reference-tracking and dynamic-type are not currently implemented in this build; they may be reinstated later; this is partly due to doubts over whether the features are adviseable, and partly over confidence in testing all the scenarios (it takes time; that time hasn't get happened); feedback is invited", true)]
		public bool AsReference
		{
			get
			{
				return (options & MemberSerializationOptions.AsReference) == MemberSerializationOptions.AsReference;
			}
			set
			{
				if (value)
				{
					options |= MemberSerializationOptions.AsReference;
				}
				else
				{
					options &= ~MemberSerializationOptions.AsReference;
				}
				options |= MemberSerializationOptions.AsReferenceHasValue;
			}
		}

		[Obsolete("Reference-tracking and dynamic-type are not currently implemented in this build; they may be reinstated later; this is partly due to doubts over whether the features are adviseable, and partly over confidence in testing all the scenarios (it takes time; that time hasn't get happened); feedback is invited", true)]
		internal bool AsReferenceHasValue
		{
			get
			{
				return (options & MemberSerializationOptions.AsReferenceHasValue) == MemberSerializationOptions.AsReferenceHasValue;
			}
			set
			{
				if (value)
				{
					options |= MemberSerializationOptions.AsReferenceHasValue;
				}
				else
				{
					options &= ~MemberSerializationOptions.AsReferenceHasValue;
				}
			}
		}

		[Obsolete("Reference-tracking and dynamic-type are not currently implemented in this build; they may be reinstated later; this is partly due to doubts over whether the features are adviseable, and partly over confidence in testing all the scenarios (it takes time; that time hasn't get happened); feedback is invited", true)]
		public bool DynamicType
		{
			get
			{
				return (options & MemberSerializationOptions.DynamicType) == MemberSerializationOptions.DynamicType;
			}
			set
			{
				if (value)
				{
					options |= MemberSerializationOptions.DynamicType;
				}
				else
				{
					options &= ~MemberSerializationOptions.DynamicType;
				}
			}
		}

		public MemberSerializationOptions Options
		{
			get
			{
				return options;
			}
			set
			{
				options = value;
			}
		}

		public int CompareTo(object other)
		{
			return CompareTo(other as ProtoMemberAttribute);
		}

		public int CompareTo(ProtoMemberAttribute other)
		{
			if (other == null)
			{
				return -1;
			}
			if (this == other)
			{
				return 0;
			}
			int num = tag.CompareTo(other.tag);
			if (num == 0)
			{
				num = string.CompareOrdinal(name, other.name);
			}
			return num;
		}

		public ProtoMemberAttribute(int tag)
			: this(tag, forced: false)
		{
		}

		internal ProtoMemberAttribute(int tag, bool forced)
		{
			if (tag <= 0 && !forced)
			{
				ThrowHelper.ThrowArgumentOutOfRangeException("tag");
			}
			this.tag = tag;
		}

		internal void Rebase(int tag)
		{
			this.tag = tag;
		}
	}
}
