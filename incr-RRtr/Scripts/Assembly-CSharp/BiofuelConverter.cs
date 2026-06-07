using System.Collections;
using DG.Tweening;
using UnityEngine;

public class BiofuelConverter : MonoBehaviour
{
	[Header("Progress meter")]
	[SerializeField]
	private SpriteRenderer progressMeter;

	private Vector3 initialProgressMeterPos;

	private float progressMeterSize = 1f;

	private Tween inProgressTween;

	[Header("Crop slots")]
	public Transform rotateThisObject;

	public BiofuelSlot[] allSlots;

	public CropType[] slotTypes;

	public Transform[] slotTranforms;

	private int resultingYield;

	private void Start()
	{
		GameManager.ins.bioConverters.Add(this);
		if ((bool)progressMeter)
		{
			initialProgressMeterPos = progressMeter.transform.localPosition;
		}
		ResetProgressBar();
		AchievementManager.ins.BuildBiofuelConverters();
	}

	private void OnDestroy()
	{
		inProgressTween.Kill();
		rotateThisObject.DOKill();
		for (int i = 0; i < slotTranforms.Length; i++)
		{
			slotTranforms[i].DOKill();
		}
		GameManager.ins.bioConverters.Remove(this);
	}

	public void TryToStartConversion()
	{
		if (CheckIfSlotsAreFull())
		{
			for (int i = 0; i < allSlots.Length; i++)
			{
				slotTypes[i] = allSlots[i].cropType;
			}
			ProduceBiofuel();
		}
	}

	public bool CheckIfSlotsAreFull()
	{
		for (int i = 0; i < allSlots.Length; i++)
		{
			if (allSlots[i].state == BiofuelSlot.State.Empty)
			{
				return false;
			}
			if (allSlots[i].state == BiofuelSlot.State.MarkedForStock)
			{
				return false;
			}
		}
		return true;
	}

	private void ProduceBiofuel()
	{
		resultingYield = 0;
		int num = 0;
		for (int i = 0; i < slotTypes.Length; i++)
		{
			CropSO cropSO = GameManager.ins.getCropSO(slotTypes[i]);
			int num2 = cropSO.biofuelYield + GameManager.ins.GetCropGMO(cropSO).biofuel;
			resultingYield += num2 * allSlots[i].multiplier;
			num += allSlots[i].multiplier * 2;
		}
		float num3 = 12f + (float)num;
		if (SaveData.ins.focusMode)
		{
			num3 *= 2f;
		}
		StartConvert(num3);
	}

	private void StartConvert(float time)
	{
		StartCoroutine(AddBiofuelToInventory(time));
		time -= 0.1f;
		inProgressTween = DOVirtual.Float(0f, progressMeterSize, time, UpdateProgressBar);
		if ((bool)rotateThisObject)
		{
			rotateThisObject.DOLocalRotate(new Vector3(0f, 0f, 360f), time * 0.5f, RotateMode.FastBeyond360).SetLoops(2);
		}
		for (int i = 0; i < slotTranforms.Length; i++)
		{
			if ((bool)slotTranforms[i])
			{
				slotTranforms[i].DOLocalRotate(new Vector3(0f, 0f, -360f), time * 0.5f, RotateMode.FastBeyond360).SetLoops(2);
			}
		}
	}

	private void UpdateProgressBar(float newSize)
	{
		if ((bool)progressMeter)
		{
			progressMeter.size = new Vector2(progressMeterSize, newSize);
		}
		if ((bool)progressMeter)
		{
			progressMeter.transform.localPosition = new Vector3(initialProgressMeterPos.x, initialProgressMeterPos.y - progressMeterSize * 0.5f + newSize * 0.5f, 0f);
		}
	}

	private void ResetProgressBar()
	{
		if ((bool)progressMeter)
		{
			progressMeter.size = new Vector2(progressMeterSize, 0f);
		}
		if ((bool)progressMeter)
		{
			progressMeter.transform.localPosition = new Vector3(initialProgressMeterPos.x, initialProgressMeterPos.y - progressMeterSize * 0.5f, 0f);
		}
		if ((bool)rotateThisObject)
		{
			rotateThisObject.eulerAngles = new Vector3(0f, 0f, 0f);
		}
		for (int i = 0; i < slotTranforms.Length; i++)
		{
			if ((bool)slotTranforms[i])
			{
				slotTranforms[i].eulerAngles = new Vector3(0f, 0f, 0f);
			}
		}
	}

	private IEnumerator AddBiofuelToInventory(float afterTime)
	{
		yield return new WaitForSeconds(afterTime);
		Inventory.ins.AddBiofuel(resultingYield);
		SaveData.ins.statsPanel.AddBiofuelProduction(resultingYield, GameManager.ins.timeElapsed);
		GameManager.ins.SpawnBiofuelPopUp((Vector2)base.transform.position + Vector2.up, resultingYield);
		ResetProgressBar();
		for (int i = 0; i < allSlots.Length; i++)
		{
			allSlots[i].RemoveCropFromSlot();
			slotTypes[i] = CropType.None;
		}
	}
}
