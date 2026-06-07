using System.Runtime.CompilerServices;
using ATL.AudioData;

namespace ATL
{
	public class MetaFieldInfo
	{
		private static string[] reservedNativePrefix;

		[CompilerGenerated]
		private object _003CSpecificData_003Ek__BackingField;

		public MetaDataIOFactory.TagType TagType { get; set; }

		public string NativeFieldCode { get; set; }

		public ushort StreamNumber { get; set; }

		public string Language { get; set; }

		public string Value { get; set; }

		public string Zone { get; set; }

		public object SpecificData
		{
			[CompilerGenerated]
			set
			{
				_003CSpecificData_003Ek__BackingField = value;
			}
		}

		public MetaFieldInfo(MetaDataIOFactory.TagType tagType, string nativeFieldCode, string value = "", ushort streamNumber = 0, string language = "", string zone = "")
		{
		}

		public override string ToString()
		{
			return null;
		}

		public override int GetHashCode()
		{
			return 0;
		}

		public override bool Equals(object obj)
		{
			return false;
		}
	}
}
