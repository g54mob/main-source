using System.Collections;
using DG.Tweening;
using UnityEngine;

public class GiantCrop : MonoBehaviour
{
	[SerializeField]
	private CropSO crop;

	[SerializeField]
	private Transform visual;

	[SerializeField]
	private ParticleSystem particles;

	[SerializeField]
	private Transform center;

	[SerializeField]
	private AudioClip[] popSounds;

	public CropSlot[] affectedCropSlots;

	private int numberOfClicksToHarvest = 12;

	private bool bufferOn;

	private float buffer = 0.15f;

	[Header("Hover over")]
	[SerializeField]
	private Vector2 hoverSize = new Vector2(2f, 3f);

	[SerializeField]
	private Vector2 hoverOffset = new Vector2(0f, 0f);

	[Header("Shiny Override")]
	public CropType newCropType;

	[SerializeField]
	private bool shiny;

	[SerializeField]
	private AudioClip[] metalDing;

	private void Start()
	{
		if (shiny)
		{
			numberOfClicksToHarvest *= 3;
		}
	}

	private void Update()
	{
		if (Input.GetMouseButtonDown(0) && mouseIsInsideHoverOverArea())
		{
			HarvestGiantCropOnce();
		}
	}

	private bool mouseIsInsideHoverOverArea()
	{
		bool result = false;
		Vector2 mousePositionInWorld = GameManager.ins.mousePositionInWorld;
		if (mousePositionInWorld.x < center.position.x + hoverOffset.x + hoverSize.x / 2f && mousePositionInWorld.x > center.position.x + hoverOffset.x - hoverSize.x / 2f && mousePositionInWorld.y < center.position.y + hoverOffset.y + hoverSize.y / 2f && mousePositionInWorld.y > center.position.y + hoverOffset.y - hoverSize.y / 2f)
		{
			result = true;
		}
		return result;
	}

	private void HarvestGiantCropOnce()
	{
		if (shiny)
		{
			particles.gameObject.transform.position = GameManager.ins.mousePositionInWorld;
			particles.Play();
			SoundManager.ins.PlaySound(metalDing);
		}
		if (bufferOn)
		{
			return;
		}
		bufferOn = true;
		numberOfClicksToHarvest--;
		if (numberOfClicksToHarvest <= 0)
		{
			for (int i = 0; i < affectedCropSlots.Length; i++)
			{
				if ((bool)affectedCropSlots[i])
				{
					affectedCropSlots[i].RemoveCropNoSound();
				}
			}
			StartCoroutine(BurstVisual());
			return;
		}
		if (!shiny)
		{
			SoundManager.ins.PlaySound(GameManager.ins.tickAudio);
			visual.DOComplete();
			visual.localScale = new Vector3(1.125f, 1.125f);
			visual.DOScale(1f, buffer).SetEase(Ease.OutBack);
		}
		Invoke("TurnOffBuffer", buffer);
	}

	private void TurnOffBuffer()
	{
		bufferOn = false;
	}

	private IEnumerator BurstVisual()
	{
		visual.DOComplete();
		visual.DOScale(0f, 0.1f * (float)affectedCropSlots.Length).SetEase(Ease.InBack);
		WaitForSeconds wait = new WaitForSeconds(0.1f);
		for (int j = 0; j < 2; j++)
		{
			for (int i = 0; i < affectedCropSlots.Length; i++)
			{
				SoundManager.ins.PlaySound(popSounds);
				Inventory.ins.AddToCropInventory(crop.cropType, 2);
				if ((bool)affectedCropSlots[i])
				{
					GameManager.ins.SpawnIconPopUp(affectedCropSlots[i].transform.position, crop.cropSprite, 2);
				}
				yield return wait;
			}
		}
		Object.Destroy(base.gameObject);
	}

	private void OnDrawGizmos()
	{
		Gizmos.DrawWireCube(center.position + (Vector3)hoverOffset, hoverSize);
	}
}
