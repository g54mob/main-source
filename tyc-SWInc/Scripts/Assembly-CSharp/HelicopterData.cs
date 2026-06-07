using System;
using System.Collections.Generic;

[Serializable]
public class HelicopterData
{
	public const float MaxTime = 30f;

	public const float GetTime = 15f;

	public ProductPrintOrder Order;

	[NonSerialized]
	public Helicopter Actual;

	[NonSerialized]
	public ProductPallet Target;

	public uint TargetDID;

	public float CurrentTime;

	public int StartFloor;

	public int HeldBoxes;

	[NonSerialized]
	public bool IsRepped;

	public HelicopterData()
	{
	}

	public HelicopterData(ProductPallet target)
	{
		Target = target;
		TargetDID = target.Furn.DID;
		StartFloor = target.Furn.GetFloor() + 1;
	}

	public bool UpdateMe(float delta, BoxController c)
	{
		CurrentTime += delta / (float)GameSettings.DaysPerMonth;
		if (Target == null && Order == null)
		{
			if (Actual != null)
			{
				Actual.Destroy = true;
			}
			return true;
		}
		if (Order == null && CurrentTime >= 15f)
		{
			HeldBoxes = Target.CurrentAmount;
			int boxes;
			Order = Target.Take(out boxes, 999999, true);
			Target.BeingFetched = false;
		}
		if (CurrentTime >= 30f)
		{
			if (Order != null)
			{
				c.ApplyQueue.AddThreaded(new KeyValuePair<int, ProductPrintOrder>(HeldBoxes, Order));
				Order = null;
			}
			if (Actual != null)
			{
				Actual.Destroy = true;
			}
			return true;
		}
		return false;
	}
}
