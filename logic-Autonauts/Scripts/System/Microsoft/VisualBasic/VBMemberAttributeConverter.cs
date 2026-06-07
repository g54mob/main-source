using System.CodeDom;
using System.Runtime.CompilerServices;

namespace Microsoft.VisualBasic
{
	internal sealed class VBMemberAttributeConverter : VBModifierAttributeConverter
	{
		[CompilerGenerated]
		private static readonly VBMemberAttributeConverter _003CDefault_003Ek__BackingField = new VBMemberAttributeConverter();

		[CompilerGenerated]
		private readonly string[] _003CNames_003Ek__BackingField = new string[5] { "Public", "Protected", "Protected Friend", "Friend", "Private" };

		[CompilerGenerated]
		private readonly object[] _003CValues_003Ek__BackingField = new object[5]
		{
			MemberAttributes.Public,
			MemberAttributes.Family,
			MemberAttributes.FamilyOrAssembly,
			MemberAttributes.Assembly,
			MemberAttributes.Private
		};

		public static VBMemberAttributeConverter Default
		{
			[CompilerGenerated]
			get
			{
				return _003CDefault_003Ek__BackingField;
			}
		}

		protected override string[] Names
		{
			[CompilerGenerated]
			get
			{
				return _003CNames_003Ek__BackingField;
			}
		}

		protected override object[] Values
		{
			[CompilerGenerated]
			get
			{
				return _003CValues_003Ek__BackingField;
			}
		}

		protected override object DefaultValue
		{
			get
			{
				return MemberAttributes.Private;
			}
		}

		private VBMemberAttributeConverter()
		{
		}
	}
}
