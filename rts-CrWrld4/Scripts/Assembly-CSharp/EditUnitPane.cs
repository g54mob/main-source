using UnityEngine;
using UnityEngine.UI;

public class EditUnitPane : MonoBehaviour
{
	public GameObject inspector;

	private UnitEditor unitEditor;

	public InputField unitGUIDInputField;

	public GameObject scriptsPane;

	public GameObject scriptContainer;

	public GameObject cmodUnitScriptRowPrefab;

	public GameObject appliedText;

	public CModUnitEditorPane cmodUnitEditorPane;

	private UnitManager um;

	public void CloseEditor()
	{
	}

	public void Update()
	{
	}

	public void OnDisable()
	{
	}

	public void ShowEditor(UnitManager um)
	{
	}

	public void Apply()
	{
	}

	public static void DestroyChildren(Transform transform)
	{
	}

	public static InspectorInt CreateIntInspector(Transform p, string propertyName)
	{
		return null;
	}

	public static InspectorFloat CreateFloatInspector(Transform p, string propertyName)
	{
		return null;
	}

	public static InspectorBool CreateBoolInspector(Transform p, string propertyName)
	{
		return null;
	}

	public static InspectorChoice CreateChoiceInspector(Transform p, string propertyName)
	{
		return null;
	}

	public static InspectorTime CreateTimeInspector(Transform p, string propertyName)
	{
		return null;
	}

	public static InspectorButton CreateButtonInspector(Transform p, string buttonName)
	{
		return null;
	}

	public static InspectorString CreateStringInspector(Transform p, string propertyName)
	{
		return null;
	}

	public static InspectorVector3 CreateVector3Inspector(Transform p, string propertyName)
	{
		return null;
	}

	public static InspectorVector2 CreateVector2Inspector(Transform p, string propertyName)
	{
		return null;
	}
}
