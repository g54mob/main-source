using System.Collections.Generic;

namespace IniParser.Model
{
	public class Property : IDeepCloneable<Property>
	{
		private List<string> _comments;

		public List<string> Comments
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public string Value { get; set; }

		public string Key { get; set; }

		public Property(string keyName, string value = "")
		{
		}

		public Property(Property ori)
		{
		}

		public Property DeepClone()
		{
			return null;
		}
	}
}
