using System;

[Serializable]
public class CheckoutData
{
	public TransformData Transform;

	public int FurnitureID;

	public bool IsOpen;

	public CheckoutData()
	{
	}

	public CheckoutData(TransformData Transform, int FurnitureID, bool IsOpen)
	{
	}
}
