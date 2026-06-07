using System;

namespace Coherence
{
	[Serializable]
	public class ArchetypeItemField
	{
		public string fieldName;

		public DictionaryOfStringString overrides;

		public ArchetypeItemField(string fieldName, DictionaryOfStringString overrides)
		{
		}
	}
}
