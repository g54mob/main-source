using System.Collections.Generic;
using UnityEngine;

public class ModelBrowser : MonoBehaviour
{
	public GameObject modelBrowserButtonPrefab;

	public Transform buttonContainer;

	public ObjEditor objEditor;

	private List<ModelBrowserButton> buttons;

	public void Awake()
	{
	}

	public void UnselectAll()
	{
	}

	public void SelectButton(string meshName)
	{
	}

	public void OnClick(string meshName)
	{
	}

	public void OnToggleEnabled()
	{
	}
}
