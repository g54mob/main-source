using System;

namespace Coherence
{
	[Serializable]
	public class ComponentMemberDescription
	{
		public string variableName;

		public string cSharpVariableName;

		public string typeName;

		public string cSharpTypeName;

		public string bitMask;

		public int fieldOffset;

		public DictionaryOfStringString overrides;

		public ComponentMemberDescription(string variableName, string cSharpVariableName, string typeName, string cSharpTypeName, string bitMask, int fieldOffset, DictionaryOfStringString overrides = null)
		{
		}

		public ComponentMemberDescription(ComponentMemberDescription other)
		{
		}
	}
}
