using UnityEngine;
using UnityEngine.UI;

public class FabricatorPane : MonoBehaviour
{
	public GameObject wareContentTextPrefab;

	public GameObject storageItemControlPrefab;

	public GameObject planRequirementsContainer;

	public GameObject storageContainer;

	public Dropdown planDropDown;

	public FabricatorPaneCell[] cells;

	public Text wareNameText;

	public GameObject buttonContainer;

	public FabricatorSection[] sections;

	private Fabricator fabricator;

	private int[] dropdownMap;

	private int lastProducedWareCount;

	private int[] storedWareCounts;

	public void SetFabricator(Fabricator fabricator)
	{
	}

	public Fabricator GetFabricator()
	{
		return null;
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void Update()
	{
	}

	private void LateUpdate()
	{
	}

	private void RefreshStorage()
	{
	}

	public void OnDropDownChanged(int val)
	{
	}

	public void OnApplyClicked()
	{
	}

	public void OnCancelClicked()
	{
	}

	private void SetWareDef(int wareNum)
	{
	}

	private int GetDropdownPosFromWare(int wareType)
	{
		return 0;
	}
}
