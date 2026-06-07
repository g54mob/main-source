using System.Collections.Generic;
using UnityEngine;

public class UnitProductionSelector : MonoBehaviour
{
	[SerializeField]
	private Sprite unitSprite;

	[SerializeField]
	private GameObject selectUnitUIPrefab;

	[SerializeField]
	private Collider measureDistanceCollider;

	private float selectSpeed = 1f;

	private float deselectSpeed = 1.5f;

	public static List<UnitProductionSelector> allUnitProductionSelectors = new List<UnitProductionSelector>();

	private SelectUnitUI mySelectUnitUI;

	private float currentSelectProgress;

	public static void Clear()
	{
		allUnitProductionSelectors.Clear();
	}

	private void OnEnable()
	{
		allUnitProductionSelectors.Add(this);
		if (!mySelectUnitUI)
		{
			mySelectUnitUI = Object.Instantiate(selectUnitUIPrefab, base.transform).GetComponent<SelectUnitUI>();
			mySelectUnitUI.transform.position = base.transform.parent.position;
		}
	}

	private void OnDisable()
	{
		allUnitProductionSelectors.Add(this);
	}

	public static UnitProductionSelector FindClosestToPoint(Vector3 checkPosition, out float distanceFromCollider)
	{
		UnitProductionSelector result = null;
		distanceFromCollider = float.MaxValue;
		for (int num = allUnitProductionSelectors.Count - 1; num >= 0; num--)
		{
			if (allUnitProductionSelectors[num] == null)
			{
				allUnitProductionSelectors.RemoveAt(num);
			}
			else if (allUnitProductionSelectors[num].measureDistanceCollider.gameObject.activeInHierarchy)
			{
				float num2 = Vector3.Distance(checkPosition, allUnitProductionSelectors[num].measureDistanceCollider.ClosestPoint(checkPosition));
				if (num2 < distanceFromCollider)
				{
					distanceFromCollider = num2;
					result = allUnitProductionSelectors[num];
				}
			}
		}
		return result;
	}

	public static void CustomUpdate(UnitProductionSelector standingInSelectRangeOf, bool selectButtonPressed, bool _smartCommand)
	{
		foreach (UnitProductionSelector allUnitProductionSelector in allUnitProductionSelectors)
		{
			if (allUnitProductionSelector == null)
			{
				continue;
			}
			if (allUnitProductionSelector == standingInSelectRangeOf)
			{
				if (selectButtonPressed)
				{
					bool flag = allUnitProductionSelector.currentSelectProgress < 1f;
					allUnitProductionSelector.currentSelectProgress += allUnitProductionSelector.selectSpeed * Time.deltaTime;
					if (allUnitProductionSelector.currentSelectProgress >= 1f && flag)
					{
						allUnitProductionSelector.CommandAllMyUnits(_smartCommand);
					}
				}
				else
				{
					allUnitProductionSelector.currentSelectProgress -= allUnitProductionSelector.deselectSpeed * Time.deltaTime;
				}
				allUnitProductionSelector.currentSelectProgress = Mathf.Clamp(allUnitProductionSelector.currentSelectProgress, 0f, 1f);
				allUnitProductionSelector.mySelectUnitUI.UpdateState(visible: true, allUnitProductionSelector.unitSprite, allUnitProductionSelector.currentSelectProgress);
			}
			else
			{
				allUnitProductionSelector.currentSelectProgress = 0f;
				allUnitProductionSelector.mySelectUnitUI.UpdateState(visible: false, null, 0f);
			}
		}
	}

	private void CommandAllMyUnits(bool _smartCommand)
	{
		for (int i = 0; i < base.transform.childCount; i++)
		{
			Transform child = base.transform.GetChild(i);
			if (child.gameObject.activeInHierarchy)
			{
				TaggedObject component = child.GetComponent<TaggedObject>();
				CommandUnits.instance.OnUnitAdd(component, _smartCommand);
			}
		}
	}
}
