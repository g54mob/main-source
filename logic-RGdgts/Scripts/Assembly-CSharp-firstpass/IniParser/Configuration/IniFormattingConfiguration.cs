namespace IniParser.Configuration
{
	public class IniFormattingConfiguration : IDeepCloneable<IniFormattingConfiguration>
	{
		public enum ENewLine
		{
			Windows = 0,
			Unix_Mac = 1
		}

		private uint _numSpacesBetweenKeyAndAssigment;

		private uint _numSpacesBetweenAssigmentAndValue;

		public string NewLineString => null;

		public ENewLine NewLineType { get; set; }

		public uint NumSpacesBetweenKeyAndAssigment
		{
			set
			{
			}
		}

		public string SpacesBetweenKeyAndAssigment { get; private set; }

		public uint NumSpacesBetweenAssigmentAndValue
		{
			set
			{
			}
		}

		public string SpacesBetweenAssigmentAndValue { get; private set; }

		public bool NewLineBeforeSection { get; set; }

		public bool NewLineAfterSection { get; set; }

		public bool NewLineAfterProperty { get; set; }

		public bool NewLineBeforeProperty { get; set; }

		public IniFormattingConfiguration DeepClone()
		{
			return null;
		}
	}
}
