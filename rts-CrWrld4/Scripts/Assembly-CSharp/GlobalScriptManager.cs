using TMPro;
using UnityEngine;

public class GlobalScriptManager : MonoBehaviour
{
	public GameObject globalScriptRowPrefab;

	public GameObject preListContent;

	public GameObject postListContent;

	public TMP_Dropdown preDropdown;

	public TMP_Dropdown postDropdown;

	public GlobalScriptSectionManager globalScriptSection;

	private CPack.GlobalScript _activeGlobalScript;

	private int globalScriptDirtyCounter;

	public CPack.GlobalScript activeGlobalScript
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public void Update()
	{
	}

	public void OnAddPre()
	{
	}

	public void OnAddPost()
	{
	}

	private void SetDropdown(TMP_Dropdown dd)
	{
	}

	private void OnAddPre(string scriptName)
	{
	}

	private void OnAddPost(string scriptName)
	{
	}

	public void OnSelectRow(CPack.GlobalScript gs)
	{
	}

	public void Refresh()
	{
	}

	public static void DestroyChildren(Transform transform)
	{
	}
}
