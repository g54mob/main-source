using UnityEngine;

public abstract class DisplayProductTransformCalculator
{
	protected ProductSO ProductSo { get; private set; }

	public void SetProductSo(ProductSO productSo)
	{
	}

	public abstract Vector3 GetPosition(int index);

	public abstract Quaternion GetRotation(int index);
}
