using System.Collections.Generic;
using UI.ThreeDimensional;
using UnityEngine;
using UnityEngine.UI;

public class StockMeshDialog : MonoBehaviour
{
	public GameObject stockMeshListRowPrefab;

	public InputField nameInputField;

	public Text message;

	public Transform listContainer;

	public UIObject3D uiObject3D;

	private StockObjectPreview stockObjectPreview;

	private List<StockMeshListRow> stockMeshListRows;

	private string _selectedMeshID;

	public string selectedMeshID
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public void Awake()
	{
	}

	public void Start()
	{
	}

	public void OnEnable()
	{
	}

	private void PopulateList()
	{
	}

	private void Select(string name)
	{
	}

	private void UpdatePreview(string name)
	{
	}

	public void OnAdd()
	{
	}

	public static void DestroyChildren(Transform transform)
	{
	}
}
