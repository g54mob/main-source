using MyBox;
using UnityEngine;

public class LabelMaskController : MonoBehaviour
{
	[SerializeField]
	private DisplaySlot[] m_DisplaySlots;

	[SerializeField]
	private Renderer m_Renderer;

	[SerializeField]
	private int m_MaterialIndex;

	[SerializeField]
	private bool m_UsesDoublePrecision;

	public void UpdateDiscountMask()
	{
	}

	public void UpdateLabelMask()
	{
	}

	private static int ApplyMask(int mask, int labelPairIndex, int priceTagBit, int labelBit)
	{
		return 0;
	}

	private int CalculateIconIndex(int x, int y)
	{
		return 0;
	}

	[ButtonMethod(ButtonMethodDrawOrder.AfterInspector)]
	public void UpdateIcon()
	{
	}
}
