using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CityEditorStreetEdit : MonoBehaviour
{
	[Header("References")]
	public GameObject streetListElementPrefab;

	public GameObject streetSelectionDisplayPrefab;

	public GameObject streetMouseOverDisplayPrefab;

	public RectTransform streetListContentRect;

	public VerticalLayoutGroup listLayout;

	[Header("State")]
	public StreetController currentlySelectedStreet;

	public StreetController currentlyMousedOverStreet;

	private StreetController previouslyMousedOverStreet;

	private List<CityEditorStreetsEditListElement> spawnedStreetListElements;

	private List<GameObject> spawnedStreetSelectionObjects;

	private List<GameObject> spawnedStreetMouseOverObjects;

	private void OnEnable()
	{
	}

	private void Update()
	{
	}

	public void ResetStreets()
	{
	}

	private StreetController TryGetStreet()
	{
		return null;
	}

	public void SetSelectedStreet(StreetController newSt)
	{
	}

	private void DrawStreetSelection(StreetController street, bool isMouseOver)
	{
	}

	private void RemoveStreetSelection(bool isMouseOver)
	{
	}

	public void RenameSelectedStreet(string newStreetName)
	{
	}

	private void ResetSelection()
	{
	}

	public void OnGenerateNewCityMap()
	{
	}

	public void RepopulateStreetList()
	{
	}

	private void OnDisable()
	{
	}
}
