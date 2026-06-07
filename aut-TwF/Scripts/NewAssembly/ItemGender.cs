using System;
using UnityEngine.Localization.Metadata;
using UnityEngine.Localization.SmartFormat.Core.Extensions;
using UnityEngine.Localization.SmartFormat.PersistentVariables;

[Serializable]
[Metadata(AllowedTypes = MetadataType.StringTableEntry)]
public class ItemGender : IMetadata, IMetadataVariable, IVariable
{
	public enum Gender
	{
		None = 0,
		Female = 1,
		Male = 2
	}

	public Gender gender;

	public string VariableName => "gender";

	public object GetSourceValue(ISelectorInfo _)
	{
		return gender;
	}
}
