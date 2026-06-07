namespace IniParser.Configuration
{
	public class IniParserConfiguration : IDeepCloneable<IniParserConfiguration>
	{
		public enum EDuplicatePropertiesBehaviour
		{
			DisallowAndStopWithError = 0,
			AllowAndKeepFirstValue = 1,
			AllowAndKeepLastValue = 2,
			AllowAndConcatenateValues = 3
		}

		public bool CaseInsensitive { get; set; }

		public bool AllowKeysWithoutSection { get; set; }

		public EDuplicatePropertiesBehaviour DuplicatePropertiesBehaviour { get; set; }

		public string ConcatenateDuplicatePropertiesString { get; set; }

		public bool ThrowExceptionsOnError { get; set; }

		public bool AllowDuplicateSections { get; set; }

		public bool SkipInvalidLines { get; set; }

		public bool TrimProperties { get; set; }

		public bool TrimSections { get; set; }

		public bool TrimComments { get; set; }

		public bool ParseComments { get; set; }

		public IniParserConfiguration()
		{
		}

		private IniParserConfiguration(IniParserConfiguration ori)
		{
		}

		public IniParserConfiguration DeepClone()
		{
			return null;
		}
	}
}
