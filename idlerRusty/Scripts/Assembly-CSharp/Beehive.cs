using System.Collections.Generic;
using UnityEngine;

public class Beehive : MonoBehaviour
{
	[SerializeField]
	private Building buildingScript;

	[SerializeField]
	private Animator anim;

	[SerializeField]
	private int biofuelMultiplier = 2;

	[SerializeField]
	private int nectarAmount;

	private int threshold = 32;

	[SerializeField]
	private SpriteRenderer progressBar;

	public bool markedForHarvest;

	public bool readyForHarvest;

	[SerializeField]
	private GameObject readyForHarvestObj;

	[SerializeField]
	private GameObject markedForHarvestObj;

	[SerializeField]
	private GameObject selectedObj;

	[SerializeField]
	private LineRenderer lr;

	private Transform forbic;

	[Header("Bees")]
	public List<BulbletAI> beesList;

	private void Start()
	{
		GameManager.ins.beehives.Add(this);
		GameManager.ins.DistributeBees();
		nectarAmount = buildingScript.capacityLevel;
		UpdateProgressBar(nectarAmount);
		if (nectarAmount > threshold)
		{
			readyForHarvest = true;
		}
		readyForHarvestObj.SetActive(readyForHarvest);
		markedForHarvestObj.SetActive(value: false);
		selectedObj.SetActive(value: false);
		AchievementManager.ins.PlaceBulbHives();
	}

	private void OnDestroy()
	{
		GameManager.ins.beehives.Remove(this);
		GameManager.ins.DistributeBees();
	}

	private void Update()
	{
		if (readyForHarvest && GameManager.ins.checkIfMouseIsInBoxArea(base.transform.position + Vector3.up * 0.75f, new Vector3(1f, 2f)))
		{
			selectedObj.SetActive(value: true);
			if (Input.GetMouseButtonDown(0))
			{
				MarkForHarvest();
			}
		}
		else
		{
			selectedObj.SetActive(value: false);
		}
		if (GameManager.ins.checkIfMouseIsInBoxArea(base.transform.position + Vector3.up * 0.75f, new Vector3(1f, 2f)))
		{
			if (markedForHarvest)
			{
				SetLine();
			}
		}
		else
		{
			DisableLine();
		}
	}

	private void MarkForHarvest()
	{
		readyForHarvest = false;
		readyForHarvestObj.SetActive(value: false);
		markedForHarvest = true;
		markedForHarvestObj.SetActive(value: true);
		SoundManager.ins.PlaySound(GameManager.ins.tickAudio);
	}

	public void HarvestBiofuel()
	{
		Inventory.ins.AddBiofuel(nectarAmount * biofuelMultiplier);
		SaveData.ins.statsPanel.AddBiofuelProduction(nectarAmount * biofuelMultiplier, GameManager.ins.timeElapsed);
		GameManager.ins.SpawnBiofuelPopUp(base.transform.position + Vector3.up * 1.5f, nectarAmount * biofuelMultiplier);
		nectarAmount = 0;
		UpdateProgressBar(nectarAmount);
		buildingScript.capacityLevel = nectarAmount;
		anim.Play("Shake");
		markedForHarvest = false;
		markedForHarvestObj.SetActive(value: false);
	}

	public void AddNectarToHive()
	{
		nectarAmount++;
		UpdateProgressBar(nectarAmount);
		buildingScript.capacityLevel = nectarAmount;
		if (!markedForHarvest && nectarAmount >= threshold)
		{
			readyForHarvest = true;
			readyForHarvestObj.SetActive(value: true);
		}
	}

	private void UpdateProgressBar(int amount)
	{
		if (amount > threshold)
		{
			amount = threshold;
		}
		float num = 0.25f;
		progressBar.size = new Vector2((float)amount * 0.0625f * num, progressBar.size.y);
		progressBar.transform.localPosition = new Vector2(-0.25f + (float)amount * 0.0625f * num * 0.5f, progressBar.transform.localPosition.y);
	}

	public void AddBeeToHive(BulbletAI bee)
	{
		beesList.Add(bee);
		beesList.RemoveAll((BulbletAI item) => item == null);
	}

	private void SetLine()
	{
		if (!forbic)
		{
			forbic = Object.FindObjectOfType<BeekeeperAI>().transform;
		}
		if ((bool)lr)
		{
			lr.enabled = true;
		}
		if ((bool)lr)
		{
			lr.SetPosition(1, base.transform.position);
		}
		if ((bool)lr && (bool)forbic)
		{
			lr.SetPosition(0, forbic.position);
		}
	}

	private void DisableLine()
	{
		if ((bool)lr && lr.enabled)
		{
			lr.enabled = false;
		}
	}

	private void OnDrawGizmos()
	{
		Gizmos.DrawWireCube(base.transform.position + Vector3.up * 0.75f, new Vector3(1f, 2f));
	}
}
