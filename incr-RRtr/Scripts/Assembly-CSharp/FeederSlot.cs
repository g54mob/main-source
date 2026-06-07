using UnityEngine;

public class FeederSlot : MonoBehaviour, ICropSlot
{
	public enum State
	{
		Empty = 0,
		Filled = 1,
		MarkedForStock = 2,
		MarkedForConsumption = 3
	}

	public State state;

	public CropType cropType;

	public SpriteRenderer[] sr;

	public int multiplier = 1;

	public CropType _CropType
	{
		get
		{
			return cropType;
		}
		set
		{
			cropType = value;
		}
	}

	public int _CropState
	{
		get
		{
			return (int)state;
		}
		set
		{
			state = (State)value;
		}
	}

	public float _CropProgress { get; set; }

	public int _CropMultiplier
	{
		get
		{
			return multiplier;
		}
		set
		{
			multiplier = value;
		}
	}

	public float _CropFertilizer { get; set; }

	public bool _CropImproved { get; set; }

	public void ForceUpdateCropSlot()
	{
		if (cropType == CropType.None)
		{
			RemoveAllCropsFromSlot();
			return;
		}
		if (state == State.MarkedForConsumption || state == State.MarkedForStock)
		{
			state = State.Filled;
		}
		AddCropToFeederSlot(cropType, multiplier);
	}

	public void AddCropToFeederSlot(CropType type, int multi)
	{
		cropType = type;
		multiplier = multi;
		state = State.Filled;
		Sprite cropSprite = GameManager.ins.getCropSprite(cropType);
		for (int i = 0; i < multiplier; i++)
		{
			sr[i].sprite = cropSprite;
		}
	}

	public void RemoveOneCropFromSlot()
	{
		multiplier--;
		if (multiplier <= 0)
		{
			RemoveAllCropsFromSlot();
			return;
		}
		for (int i = multiplier; i < sr.Length; i++)
		{
			sr[i].sprite = null;
		}
		state = State.Filled;
	}

	private void RemoveAllCropsFromSlot()
	{
		state = State.Empty;
		cropType = CropType.None;
		multiplier = 1;
		for (int i = 0; i < sr.Length; i++)
		{
			sr[i].sprite = null;
		}
	}
}
