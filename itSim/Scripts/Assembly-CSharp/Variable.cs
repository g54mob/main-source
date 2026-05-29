using System;
using System.Reflection;
using UnityEngine;

[Serializable]
public class Variable
{
	public FieldInfo variable;

	public string fieldName;

	public string fieldValue;

	public string fieldValueOrginal;

	public string textID;

	public bool translate;

	[SerializeField]
	public LanguageComponentTextType Type;

	public bool viewList;
}
