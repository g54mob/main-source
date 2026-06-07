using System.Collections;
using UnityEngine;

public class Beacon : GameplayObject, ISelectable, ISavable
{
	[SerializeField]
	protected GameObject fowAreaPrefab;

	[Savable("hasBeenActivated", true, false)]
	protected bool hasBeenActivated;

	protected PlacementComponent placementComponent;

	private Coroutine selectionCoroutine;

	protected virtual void Awake()
	{
		placementComponent = GetComponent<PlacementComponent>();
		placementComponent.onPlace += OnPlace;
	}

	protected virtual void OnPlace(PlacementComponent component)
	{
		InstantiateFogOfWarPrefab();
		FogOfWarController.instance.UpdateFogOfWar();
	}

	protected virtual void InstantiateFogOfWarPrefab()
	{
		Object.Instantiate(fowAreaPrefab, placementComponent.GetCenter() + Vector3.up * 5f, base.transform.rotation, base.transform);
	}

	public void Select()
	{
		this.StartCoroutineCheckingVar(SelectionCoroutine(), ref selectionCoroutine);
	}

	public void Deselect()
	{
		this.StopCoroutineCheckingVar(ref selectionCoroutine);
		LTFunctionLibrary.GetLTGameManager().HideRangeIndicator();
	}

	private IEnumerator SelectionCoroutine()
	{
		while (true)
		{
			ShowRangeIndicator();
			yield return null;
		}
	}

	protected virtual void ShowRangeIndicator()
	{
	}
}
