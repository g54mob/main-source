using UnityEngine;

public class VendingMachineTransformCalculator
{
	private float m_SlotZScale;

	private float m_SlotXScale;

	protected ProductSO ProductSo { get; private set; }

	public void SetProductSo(ProductSO productSo)
	{
	}

	public Vector3 GetPosition(int index)
	{
		return default(Vector3);
	}

	public Quaternion GetRotation()
	{
		return default(Quaternion);
	}
}
