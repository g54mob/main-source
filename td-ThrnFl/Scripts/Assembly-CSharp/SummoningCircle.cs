using System.Collections.Generic;
using UnityEngine;

public class SummoningCircle : MonoBehaviour, ISaveLoad
{
	[SerializeField]
	private List<Spawn> spawnsToAdd;

	[SerializeField]
	[BalancingParameter(BalancingParameter.EType.Default)]
	private int goldStat;

	[SerializeField]
	[BalancingParameter(BalancingParameter.EType.Default)]
	private int unitCount;

	private bool hasBeenUsedAlready;

	private void OnEnable()
	{
		ManualLoad(GetComponentInParent<SaveLoadEntity>().GUID);
		if (!hasBeenUsedAlready)
		{
			EnemySpawner.GetNextWave().spawns.AddRange(spawnsToAdd);
			EnemySpawner.instance.DestroyMarkers();
			EnemySpawner.instance.PlaceMarkersForNextWave();
			hasBeenUsedAlready = true;
		}
	}

	public void OnSave(string guid)
	{
		MatchSaveLoadHandler.SaveValue(guid, base.transform.parent.gameObject.name + "_" + base.gameObject.name + "_used", hasBeenUsedAlready);
	}

	private void ManualLoad(string guid)
	{
		if (MatchSaveLoadHandler.IsLoadingPermitted)
		{
			hasBeenUsedAlready = MatchSaveLoadHandler.TryLoadValue(guid, base.transform.parent.gameObject.name + "_" + base.gameObject.name + "_used", ref hasBeenUsedAlready);
		}
	}

	public void OnBeforeMainLoadPass(string guid)
	{
	}

	public void OnLoad(string guid)
	{
	}

	public void OnAfterMainLoadPass(string guid)
	{
	}
}
