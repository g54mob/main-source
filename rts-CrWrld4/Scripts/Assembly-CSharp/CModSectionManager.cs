using UnityEngine;
using UnityEngine.UI;

public class CModSectionManager : MonoBehaviour
{
	public GameObject cModObjRowPrefab;

	public GameObject cModScriptRowPrefab;

	public InputField nameInput;

	public InputField guidInput;

	public GameObject objContainer;

	public ObjEditor objEditor;

	public GameObject scriptContainer;

	public GameObject previewContainer;

	public CModSettings cModSettings;

	public CModUI cModUI;

	public ScriptSettingsEditor scriptSettingsEditor;

	public void OnAdd()
	{
	}

	public void OnNameChanged(string val)
	{
	}

	public void OnWikiHelpClick()
	{
	}

	public void Refresh()
	{
	}

	public static void DestroyChildren(Transform transform)
	{
	}
}
