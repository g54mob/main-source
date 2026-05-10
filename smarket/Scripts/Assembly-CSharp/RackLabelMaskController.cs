using UnityEngine;

public class RackLabelMaskController : MonoBehaviour
{
	[SerializeField]
	private RackSlot[] m_RackSlot;

	[SerializeField]
	private Renderer m_Renderer;

	public void UpdateLabelMask()
	{
	}

	private int CalculateIconIndex(int x, int y)
	{
		return 0;
	}

	public void UpdateIcon()
	{
	}
}
