using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BerryBush : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	public enum State
	{
		Empty = 0,
		NeedsHarvest = 1,
		MarkedForHarvest = 2
	}

	public State state;

	[SerializeField]
	private Decoration parentDecorationObject;

	public CropSO cropSO;

	[SerializeField]
	private GameObject emptyBush;

	[SerializeField]
	private GameObject fullBush;

	private float growTimer;

	public List<Transform> occupants;

	private float deltaTime;

	private void Start()
	{
		GameManager.ins.berryBushes.Add(this);
		growTimer = (float)parentDecorationObject.statProgress + 1f;
		if (growTimer > cropSO.growingDays * 60f)
		{
			state = State.NeedsHarvest;
		}
		UpdateVisuals();
	}

	private void Update()
	{
		if (state != State.Empty)
		{
			return;
		}
		if (growTimer > cropSO.growingDays * 60f)
		{
			state = State.NeedsHarvest;
			UpdateVisuals();
		}
		else
		{
			deltaTime = Time.deltaTime;
			if (SaveData.ins.focusMode)
			{
				deltaTime *= 0.5f;
			}
			growTimer += deltaTime;
		}
		UpdateParentStatProgress();
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		if (GameManager.ins.state == GameManager.State.CanInspectCrops && (bool)cropSO)
		{
			TooltipSystem.Show(LocalizationSystem.GetLocalizedValue(cropSO.cropName));
		}
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		TooltipSystem.Hide();
	}

	private void OnDestroy()
	{
		GameManager.ins.berryBushes.Remove(this);
	}

	public void Harvest()
	{
		Inventory.ins.AddToCropInventory(cropSO.cropType, 1);
		SaveData.ins.AddTotalCropsHarvested(1);
		growTimer = 0f;
		UpdateParentStatProgress();
		state = State.Empty;
		UpdateVisuals();
	}

	public void Pollinate()
	{
		growTimer += 5f;
	}

	public void AddOccupant(Transform beeButterfly)
	{
		occupants.Add(beeButterfly);
	}

	public void RemoveOccupant(Transform beeButterfly)
	{
		occupants.Remove(beeButterfly);
	}

	private void UpdateParentStatProgress()
	{
		parentDecorationObject.statProgress = (int)growTimer;
	}

	private void UpdateVisuals()
	{
		emptyBush.SetActive(state == State.Empty);
		fullBush.SetActive(state != State.Empty);
	}
}
