using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class LanguageComponentScript : MonoBehaviour
{
	public List<Component> Components;

	private void Reset()
	{
	}

	public void UpdateComponents()
	{
	}

	public void GetComponents()
	{
	}

	public bool FindComponentInList(MonoBehaviour component)
	{
		return false;
	}

	public bool FindComponentInObject(MonoBehaviour componentToFind)
	{
		return false;
	}

	private void SortComponents(MonoBehaviour[] components)
	{
	}

	private void GetVariableFromComponent()
	{
	}

	public bool FindVariableInComponent(Component component, FieldInfo variable)
	{
		return false;
	}

	public List<Variable> DeepCopyVariables(List<Variable> original)
	{
		return null;
	}

	public void Translate()
	{
	}

	private void UpdateFieldValues()
	{
	}
}
