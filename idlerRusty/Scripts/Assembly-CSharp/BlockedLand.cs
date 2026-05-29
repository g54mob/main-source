using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BlockedLand : MonoBehaviour
{
	public enum State
	{
		Blocked = 0,
		MarkedForClearing = 1,
		IsClearing = 2,
		Cleared = 3
	}

	public int positionInList;

	public State state;

	public List<GameObject> objectsToClear;

	[SerializeField]
	private SpriteRenderer sr;

	[SerializeField]
	private GameObject markedForClearingVisual;

	[SerializeField]
	private TMP_Text costText;

	[SerializeField]
	private ParticleSystem particles;

	[SerializeField]
	private GameObject leafParticles;

	public GameObject button;

	[SerializeField]
	private Vector2Int coord;

	[SerializeField]
	private Vector2Int size = new Vector2Int(14, 8);

	[SerializeField]
	private int cost;

	[Space]
	[SerializeField]
	private GameObject[] extraObjects;

	private void Start()
	{
		state = GameManager.ins.blockedLands[positionInList];
		GameManager.ins.blockedLandObjects[positionInList] = this;
		cost = GameManager.ins.blockedLandCosts[positionInList];
		if (SaveData.ins.checkIfCrossover(out var crossover) && crossover == CrossoverFarmType.Balatro)
		{
			cost *= 2;
		}
		costText.text = "<sprite index=0>" + cost;
		if (state == State.Blocked || state == State.MarkedForClearing || state == State.IsClearing)
		{
			StartCoroutine(BlockLands());
		}
		if (state == State.MarkedForClearing || state == State.IsClearing)
		{
			markedForClearingVisual.SetActive(value: true);
			button.SetActive(value: false);
			ChangeStateTo(State.MarkedForClearing);
		}
		if (state == State.Cleared)
		{
			if ((bool)leafParticles)
			{
				leafParticles.SetActive(value: true);
			}
			if ((bool)leafParticles)
			{
				leafParticles.transform.parent = null;
			}
			if ((bool)leafParticles)
			{
				leafParticles.transform.localScale = Vector3.one;
			}
			UnlockExtraObjects();
			button.SetActive(value: false);
			base.gameObject.SetActive(value: false);
			GameManager.ins.CheckUnlockedMapsOnStart();
		}
	}

	private IEnumerator BlockLands()
	{
		yield return new WaitForEndOfFrame();
		Debug.Log("Block land " + positionInList);
		GridSystem.ins.MarkTilesAsOccupied(coord, size, occupiedState: true);
	}

	public void ClickedMarkForClearing()
	{
		if (!DoesPlayerHaveResources())
		{
			SoundManager.ins.PlaySound(GameManager.ins.errorAudio);
			TooltipSystem.HideIcontip();
		}
		else
		{
			AreYouSure.ins.SpawnOn(this);
			SoundManager.ins.PlaySound(GameManager.ins.tickAudio);
		}
	}

	public void MarkForClearing()
	{
		if (!DoesPlayerHaveResources())
		{
			SoundManager.ins.PlaySound(GameManager.ins.errorAudio);
			TooltipSystem.HideIcontip();
			return;
		}
		Inventory.ins.AddSpareParts(-cost);
		SoundManager.ins.PlaySound(GameManager.ins.tickAudio);
		markedForClearingVisual.SetActive(value: true);
		button.SetActive(value: false);
		ChangeStateTo(State.MarkedForClearing);
	}

	private bool DoesPlayerHaveResources()
	{
		if (Inventory.ins.spareParts < cost)
		{
			return false;
		}
		return true;
	}

	public GameObject getClosestDebrisTo(Vector2 workerPos)
	{
		if (objectsToClear.Count == 1)
		{
			return objectsToClear[0];
		}
		objectsToClear.Sort((GameObject a, GameObject b) => Vector2.Distance(workerPos, a.transform.position).CompareTo(Vector2.Distance(workerPos, b.transform.position)));
		return objectsToClear[0];
	}

	public void RemoveDebrisFromList(GameObject obj)
	{
		GameManager.ins.SpawnSparePartsPopUp(obj.transform.position, 1);
		Inventory.ins.AddSpareParts(1);
		Object.Destroy(obj);
		objectsToClear.Remove(obj);
	}

	public void FinishClearingLand()
	{
		ChangeStateTo(State.Cleared);
		GameManager.ins.UnlockNextMap();
		sr.enabled = false;
		markedForClearingVisual.SetActive(value: false);
		GridSystem.ins.MarkTilesAsOccupied(coord, size, occupiedState: false);
		GameManager.ins.MarkAllWaterTilesAsOccupied();
		GameManager.ins.MarkAllTreeTilesAsOccupied();
		particles.Play();
		if ((bool)leafParticles)
		{
			leafParticles.SetActive(value: true);
		}
		if ((bool)leafParticles)
		{
			leafParticles.transform.localScale = Vector3.one;
		}
		UnlockExtraObjects();
	}

	private void UnlockExtraObjects()
	{
		if (extraObjects.Length == 0)
		{
			return;
		}
		GameObject[] array = extraObjects;
		foreach (GameObject gameObject in array)
		{
			if ((bool)gameObject)
			{
				gameObject.SetActive(value: true);
				gameObject.transform.localScale = Vector3.one;
				gameObject.transform.localScale = Vector3.one;
			}
		}
	}

	public void ChangeStateTo(State newState)
	{
		state = newState;
		GameManager.ins.blockedLands[positionInList] = newState;
	}

	public void EnableButton()
	{
		button.SetActive(value: true);
	}
}
