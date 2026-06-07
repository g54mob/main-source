using UnityEngine;

public class BiofuelSlot : MonoBehaviour, ICropSlot
{
	public enum State
	{
		Empty = 0,
		Filled = 1,
		MarkedForStock = 2
	}

	public State state;

	public BiofuelConverter converterScript;

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
		if (cropType != CropType.None)
		{
			AddCropToBiofuelSlot(cropType, multiplier);
		}
	}

	public void AddCropToBiofuelSlot(CropType type, int multi)
	{
		cropType = type;
		multiplier = multi;
		state = State.Filled;
		Sprite cropSprite = GameManager.ins.getCropSprite(cropType);
		for (int i = 0; i < multiplier; i++)
		{
			sr[i].sprite = cropSprite;
		}
		converterScript.TryToStartConversion();
	}

	public void RemoveCropFromSlot()
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
