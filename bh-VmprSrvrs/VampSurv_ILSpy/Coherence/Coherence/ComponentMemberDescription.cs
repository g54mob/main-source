using System;
using System.Collections.Generic;

namespace Coherence;

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
		this.variableName = variableName;
		this.cSharpVariableName = cSharpVariableName;
		this.typeName = typeName;
		string text = default(string);
		this.cSharpTypeName = text;
		string text2 = default(string);
		this.bitMask = text2;
		int num = default(int);
		this.fieldOffset = num;
		DictionaryOfStringString dictionaryOfStringString = default(DictionaryOfStringString);
		this.overrides = dictionaryOfStringString;
	}

	public ComponentMemberDescription(ComponentMemberDescription other)
	{
		variableName = other.variableName;
		typeName = other.typeName;
		cSharpTypeName = other.cSharpTypeName;
		bitMask = other.bitMask;
		fieldOffset = other.fieldOffset;
		DictionaryOfStringString dictionaryOfStringString = new DictionaryOfStringString();
		overrides = dictionaryOfStringString;
		Dictionary<object, object>.Enumerator enumerator = default(Dictionary<object, object>.Enumerator);
		object value = default(object);
		while (true)
		{
			if (enumerator.MoveNext())
			{
				if (overrides == null)
				{
					break;
				}
				bool flag = ((Dictionary<object, object>)(object)overrides).TryInsert((object)null, value, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
				continue;
			}
			return;
		}
		throw new NullReferenceException();
	}
}
