using System.Collections.Generic;
using UnityEngine;

public class LeafSpawner : MonoBehaviour
{
	public GameObject leafBurst;

	public GameObject finalLeafBurst;

	public GameObject finalLeafBurstDeath;

	public List<GameObject> clusterVariations;

	public List<GameObject> clusterColliderVariations;

	private int chosenCluster;

	private float leafRate = 0.5f;

	private float currentRateTimer;

	private float leafTotal = 10f;

	private float maxLeaves = 10f;

	private List<Collider> chosenColliders = new List<Collider>();

	private void Awake()
	{
		ChooseCluster();
	}

	private void Update()
	{
		if (currentRateTimer > 0f)
		{
			currentRateTimer -= Time.deltaTime;
		}
		if (!(base.transform.localScale.x > 0f))
		{
			return;
		}
		bool flag = false;
		for (int i = 0; i < chosenColliders.Count; i++)
		{
			if (!chosenColliders[i].enabled)
			{
				flag = true;
				chosenColliders[i].enabled = true;
			}
		}
		if (flag)
		{
			currentRateTimer = 0f;
			leafTotal = maxLeaves;
		}
	}

	private void OnCollisionEnter(Collision collision)
	{
		TrySpawnLeafs();
	}

	private void TrySpawnLeafs()
	{
		if (base.transform.parent == null)
		{
			Object.Instantiate(finalLeafBurstDeath, base.transform.position, Quaternion.identity);
			Object.Destroy(base.gameObject);
		}
		else
		{
			if (currentRateTimer > 0f || base.transform.localScale.x <= 0f)
			{
				return;
			}
			currentRateTimer = leafRate;
			Object.Instantiate(leafBurst, base.transform.position, Quaternion.identity);
			leafTotal -= 1f;
			if (leafTotal <= 0f)
			{
				Object.Instantiate(finalLeafBurst, base.transform.position, Quaternion.identity);
				base.transform.localScale = Vector3.zero;
				for (int i = 0; i < chosenColliders.Count; i++)
				{
					chosenColliders[i].enabled = false;
				}
			}
		}
	}

	private void ChooseCluster()
	{
		SetCluster(Random.Range(0, clusterVariations.Count));
	}

	public int GetCluster()
	{
		return chosenCluster;
	}

	public void SetCluster(int index)
	{
		chosenCluster = index;
		for (int i = 0; i < clusterVariations.Count; i++)
		{
			clusterVariations[i].SetActive(i == chosenCluster);
			clusterColliderVariations[i].SetActive(i == chosenCluster);
		}
		chosenColliders.Clear();
		chosenColliders.AddRange(clusterColliderVariations[chosenCluster].GetComponents<Collider>());
	}
}
