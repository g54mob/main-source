using UnityEngine;

public class BuildSpot : MonoBehaviour
{
	public bool isBuiltOn;

	public bool isBonusSpot;

	public BuildableIdentity buildableIdentity;

	public GameObject gameObjectBuiltOnUs;

	public PlantBed plantBedBuiltOnUs;

	private void Start()
	{
		GameManager.Singleton.buildSpotsDict.Add(GameManager.Singleton.GetGridDictFromPos(base.gameObject.transform.position), this);
		if (isBonusSpot)
		{
			MakeBonusTile();
		}
		else if (!isBuiltOn)
		{
			GameManager.Singleton.availableBuildSpotsToBonusTileify.Add(this);
		}
	}

	private void OnDestroy()
	{
		GameManager.Singleton.buildSpotsDict.Remove(GameManager.Singleton.GetGridDictFromPos(base.gameObject.transform.position));
		GameManager.Singleton.availableBuildSpotsToBonusTileify.Remove(this);
	}

	public void MakeBonusTile()
	{
		isBonusSpot = true;
		GameObject gameObject = Object.Instantiate(GameManager.Singleton.prefabBank.bonusTileParticlesPrefab, base.transform);
		GameManager.Singleton.allSpawnedBonusTileParticles.Add(gameObject);
		gameObject.transform.localPosition = Vector3.zero;
		gameObject.transform.localRotation = Quaternion.identity;
		GameManager.Singleton.availableBuildSpotsToBonusTileify.Remove(this);
	}

	public void OnBuiltOn(BuildableIdentity _identity, GameObject _gameobjectBuiltOnUs)
	{
		buildableIdentity = _identity;
		isBuiltOn = true;
		gameObjectBuiltOnUs = _gameobjectBuiltOnUs;
		if (_identity == BuildableIdentity.DirtPatch)
		{
			plantBedBuiltOnUs = _gameobjectBuiltOnUs.gameObject.transform.root.gameObject.GetComponent<PlantBed>();
		}
		GameManager.Singleton.availableBuildSpotsToBonusTileify.Remove(this);
	}
}
