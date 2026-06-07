using System.Reflection;
using System.Runtime.CompilerServices;

namespace Microsoft.VisualBasic
{
	internal sealed class VBTypeAttributeConverter : VBModifierAttributeConverter
	{
		[CompilerGenerated]
		private static readonly VBTypeAttributeConverter _003CDefault_003Ek__BackingField = new VBTypeAttributeConverter();

		[CompilerGenerated]
		private readonly string[] _003CNames_003Ek__BackingField = new string[2] { "Public", "Friend" };

		[CompilerGenerated]
		private readonly object[] _003CValues_003Ek__BackingField = new object[2]
		{
			TypeAttributes.Public,
			TypeAttributes.NotPublic
		};

		public static VBTypeAttributeConverter Default
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
				return TypeAttributes.Public;
			}
		}

		private VBTypeAttributeConverter()
		{
		}
	}
}
