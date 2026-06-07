using System;
using UnityEngine;

public class FileStructureStringAttribute : PropertyAttribute
{
	public enum FileAddressOptions
	{
		DEFAULT = 0,
		FOLDER_REFFERENCE_ONLY = 1,
		EXCLUDE_FILE_EXTENSION = 2,
		EDITOR_RESOURCE_ADDRESS = 3,
		COUNT = 4
	}

	public FileAddressOptions _faoFieldAddressOption;

	public Type _typTypeOfObjectToFilterFor;

	public bool _bAllowInheritance = true;

	public FileStructureStringAttribute()
	{
	}

	public FileStructureStringAttribute(FileAddressOptions faoFieldAddressOption)
	{
		_faoFieldAddressOption = faoFieldAddressOption;
	}

	public FileStructureStringAttribute(FileAddressOptions faoFieldAddressOption, Type typRequiredType)
	{
		_faoFieldAddressOption = faoFieldAddressOption;
		_typTypeOfObjectToFilterFor = typRequiredType;
	}

	public FileStructureStringAttribute(FileAddressOptions faoFieldAddressOption, Type typRequiredType, bool bAllowInheritance)
	{
		_faoFieldAddressOption = faoFieldAddressOption;
		_typTypeOfObjectToFilterFor = typRequiredType;
		_bAllowInheritance = bAllowInheritance;
	}
}
