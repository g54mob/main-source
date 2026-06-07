namespace IniParser.Configuration
{
	public class IniScheme : IDeepCloneable<IniScheme>
	{
		private string _commentString;

		private string _sectionStartString;

		private string _sectionEndString;

		private string _propertyAssigmentString;

		public string CommentString
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public string SectionStartString
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public string SectionEndString
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public string PropertyAssigmentString
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public IniScheme()
		{
		}

		private IniScheme(IniScheme ori)
		{
		}

		public IniScheme DeepClone()
		{
			return null;
		}
	}
}
