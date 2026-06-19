using Aggro.Core;
using UnityEngine;

public class PlacementHintVisuals : EntityBehaviourBase
{
	public GameObject hintObject;

	public GameObject hintCannotPlaceObject;

	protected override void OnUpdatePresentationEarly()
	{
		hintObject.SetActive(value: false);
		hintCannotPlaceObject.SetActive(value: false);
	}
}
