using System;
using UnityEngine;

public class Battery : MonoBehaviour
{
	public const float BatterCapacityFactor = 1000f;

	public float MaxCapacity;

	[NonSerialized]
	public float CurrentCharge;

	[NonSerialized]
	private Furniture _furn;

	public bool Broken
	{
		get
		{
			return _furn.upg.Broken;
		}
	}

	private void Start()
	{
		if (!GameSettings.Instance.IsReferenceNull())
		{
			_furn = GetComponent<Furniture>();
			if (!_furn.isTemporary && _furn.Map == null)
			{
				GameSettings.Instance.Batteries.Add(this);
			}
		}
	}

	private void OnDestroy()
	{
		if (!GameSettings.Instance.IsReferenceNull())
		{
			GameSettings.Instance.Batteries.Remove(this);
		}
	}

	public float TakeCharge(float amount)
	{
		CurrentCharge -= amount / 30f;
		if (CurrentCharge < 0f)
		{
			amount += CurrentCharge * 30f;
			CurrentCharge = 0f;
		}
		return amount;
	}

	public float AddCharge(float amount)
	{
		CurrentCharge += amount / 30f;
		if (CurrentCharge > MaxCapacity)
		{
			amount -= (CurrentCharge - MaxCapacity) * 30f;
			CurrentCharge = MaxCapacity;
		}
		return amount;
	}

	public void Serialize(WriteDictionary d, GameReader.NewLoadMode mode)
	{
		if (mode.Is(GameReader.NewLoadMode.Full))
		{
			d["Charge"] = CurrentCharge;
		}
	}

	public void Deserialize(WriteDictionary d, bool loading)
	{
		CurrentCharge = d.Get("Charge", 0f);
	}
}
