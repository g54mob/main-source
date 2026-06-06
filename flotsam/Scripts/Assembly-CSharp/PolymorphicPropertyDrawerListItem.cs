using System;
using UnityEngine;

public abstract class PolymorphicPropertyDrawerListItem : ScriptableObject
{
	public bool Remove => false;

	public void OnPropertyDrawerGUI(UnityEngine.Object target)
	{
	}

	protected abstract void OnGUI();

	protected void Header(string label, int fieldCount, Color backgroundColor)
	{
	}

	protected string EditorGUI_TextField(string label, string value)
	{
		return value;
	}

	protected int EditorGUI_IntField(string label, int value)
	{
		return value;
	}

	protected float EditorGUI_FloatField(string label, float value)
	{
		return value;
	}

	protected Enum EditorGUI_EnumField(string label, Enum selected)
	{
		return selected;
	}

	protected bool EditorGUI_Toggle(string label, bool value)
	{
		return value;
	}

	protected void EditorGUI_TogglHideFlags(string label)
	{
	}

	protected void EditorGUI_PropertyField(string relativePropertyPath, string label = null, bool includeChildren = true)
	{
	}

	protected void EditorGUI_HelpBox(string message, float height = 40f)
	{
	}
}
