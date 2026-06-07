using UnityEngine;

public class EditorInspectorGUIFieldAttribute : PropertyAttribute
{
	public string Group { get; private set; }

	public int Order { get; private set; }

	public string Label { get; private set; }

	public EditorInspectorGUIFieldAttribute(string group, int order = 0, string label = null)
	{
		Group = group;
		Order = order;
		Label = label;
	}
}
