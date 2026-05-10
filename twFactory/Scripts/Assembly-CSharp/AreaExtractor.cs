using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaExtractor : Extractor, ISelectable
{
	[Header("UI")]
	[SerializeField]
	private ReachableSourceIndicator reachableSourceIndicatorPrefab;

	private Coroutine selectionCoroutine;

	private List<ReachableSourceIndicator> reachableSourceIndicators;

	public float AreaRadius
	{
		get
		{
			float num = base.StatsComponent.GetStat(EStats.Range);
			if (!base.PlacementComponent.IsPlaced && !LTFunctionLibrary.GetPlayerData().PlayerBuildings.Contains(this))
			{
				List<GameplayEffectData> gameplayEffectDatasToApplyToBuilding = LTFunctionLibrary.GetGameplayEffectDatasToApplyToBuilding(GetComponent<GameplayObject>().ObjectData);
				if (gameplayEffectDatasToApplyToBuilding != null)
				{
					foreach (GameplayEffectData item in gameplayEffectDatasToApplyToBuilding)
					{
						if (!(item is GE_StatModifierData))
						{
							continue;
						}
						GE_StatModifierData gE_StatModifierData = item as GE_StatModifierData;
						if (gE_StatModifierData.Stat == EStats.Range)
						{
							switch (gE_StatModifierData.ModifierOperation)
							{
							case ModifierOperation.Additive:
								num += gE_StatModifierData.StatValue;
								break;
							case ModifierOperation.Multiplicative:
								num += base.StatsComponent.GetStatBase(EStats.Range) * gE_StatModifierData.StatValue;
								break;
							}
						}
					}
				}
			}
			return num;
		}
		set
		{
			base.StatsComponent.SetStat(EStats.Range, value);
		}
	}

	protected override void OnDestroy()
	{
		base.OnDestroy();
		if (selectionCoroutine != null)
		{
			Deselect();
		}
	}

	private void ExtractFromNearestSource()
	{
		base.CurrentSource = GetNearestSource();
	}

	private Source GetNearestSource()
	{
		Vector3 transformCenter = base.PlacementComponent.GetCenter();
		List<Collider> list = FunctionLibrary.OverlapSphereCheckingTag(transformCenter, AreaRadius, LayerMask.GetMask("Gameplay"), "Source");
		if (list.Count == 0)
		{
			return null;
		}
		list.Sort((Collider x, Collider y) => (x.transform.position - transformCenter).sqrMagnitude.CompareTo((y.transform.position - transformCenter).sqrMagnitude));
		foreach (Collider item in list)
		{
			Source component = item.attachedRigidbody.GetComponent<Source>();
			if (IsSourceValid(component))
			{
				return component;
			}
		}
		return null;
	}

	protected override void OnCurrentSourceDepleted()
	{
		base.OnCurrentSourceDepleted();
		ExtractFromNearestSource();
	}

	public override int GetTotalUnitsLeft()
	{
		int num = 0;
		foreach (Collider item in FunctionLibrary.OverlapSphereCheckingTag(base.PlacementComponent.GetCenter(), AreaRadius, LayerMask.GetMask("Gameplay"), "Source"))
		{
			Source component = item.attachedRigidbody.GetComponent<Source>();
			if (IsSourceValid(component))
			{
				num += component.CurrentAmount;
			}
		}
		return num;
	}

	protected override void OnPlace(PlacementComponent placementComponent)
	{
		base.OnPlace(placementComponent);
		if (!base.CurrentSource)
		{
			ExtractFromNearestSource();
		}
		FogOfWarController.instance.onFogOfWarUpdated += OnFogOfWarUpdatedCallback;
	}

	protected override void OnUnplace(PlacementComponent placementComponent)
	{
		base.OnUnplace(placementComponent);
		base.CurrentSource = null;
		FogOfWarController.instance.onFogOfWarUpdated -= OnFogOfWarUpdatedCallback;
	}

	public void Select()
	{
		reachableSourceIndicators = new List<ReachableSourceIndicator>();
		this.StartCoroutineCheckingVar(SelectionCoroutine(), ref selectionCoroutine);
	}

	public void Deselect()
	{
		this.StopCoroutineCheckingVar(ref selectionCoroutine);
		LTFunctionLibrary.GetLTGameManager().HideRangeIndicator();
		reachableSourceIndicators.ForEach(delegate(ReachableSourceIndicator x)
		{
			Object.Destroy(x.gameObject);
		});
	}

	private IEnumerator SelectionCoroutine()
	{
		while (true)
		{
			if (!LTFunctionLibrary.GetFogOfWarController().IsPositionVisible(base.transform.position))
			{
				LTFunctionLibrary.GetLTGameManager().HideRangeIndicator();
				for (int num = reachableSourceIndicators.Count - 1; num >= 0; num--)
				{
					Object.Destroy(reachableSourceIndicators[num].gameObject);
					reachableSourceIndicators.RemoveAt(num);
				}
			}
			else
			{
				LTFunctionLibrary.GetLTGameManager().ShowCircleRangeIndicator(base.PlacementComponent.GetCenter(), AreaRadius, 0f);
				List<Collider> list = FunctionLibrary.OverlapSphereCheckingTag(base.PlacementComponent.GetCenter(), AreaRadius, LayerMask.GetMask("Gameplay"), "Source");
				for (int num2 = reachableSourceIndicators.Count - 1; num2 >= 0; num2--)
				{
					bool flag = false;
					foreach (Collider item in list)
					{
						if ((bool)reachableSourceIndicators[num2].Source && item.attachedRigidbody.gameObject == reachableSourceIndicators[num2].Source.gameObject)
						{
							flag = true;
							break;
						}
					}
					if (!flag)
					{
						Object.Destroy(reachableSourceIndicators[num2].gameObject);
						reachableSourceIndicators.RemoveAt(num2);
					}
				}
				foreach (Collider item2 in list)
				{
					Source component = item2.attachedRigidbody.GetComponent<Source>();
					bool flag2 = false;
					if (!IsSourceValid(component))
					{
						continue;
					}
					foreach (ReachableSourceIndicator reachableSourceIndicator in reachableSourceIndicators)
					{
						if (reachableSourceIndicator.Source.gameObject == component.gameObject)
						{
							flag2 = true;
							break;
						}
					}
					if (!flag2)
					{
						ReachableSourceIndicator component2 = Object.Instantiate(reachableSourceIndicatorPrefab.gameObject, base.transform).GetComponent<ReachableSourceIndicator>();
						component2.Setup(base.PlacementComponent, component);
						reachableSourceIndicators.Add(component2);
					}
				}
			}
			yield return null;
		}
	}

	private bool IsSourceValid(Source source)
	{
		if (base.ValidSources != null && base.ValidSources.Contains(source.ObjectData) && !source.IsDepleted())
		{
			return source.PlacementComponent.IsVisible();
		}
		return false;
	}

	private void OnFogOfWarUpdatedCallback(bool importantUpdate)
	{
		if (importantUpdate && !base.CurrentSource)
		{
			ExtractFromNearestSource();
		}
	}
}
