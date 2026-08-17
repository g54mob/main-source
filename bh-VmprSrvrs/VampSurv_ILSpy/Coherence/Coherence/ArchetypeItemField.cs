using System;

namespace Coherence;

[Serializable]
public class ArchetypeItemField(string fieldName, DictionaryOfStringString overrides)
{
	public string fieldName = fieldName;

	public DictionaryOfStringString overrides = overrides;
}
