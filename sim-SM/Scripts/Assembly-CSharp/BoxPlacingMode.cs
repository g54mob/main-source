using MyBox;
using UnityEngine;

public class BoxPlacingMode : IPlacingMode
{
	[Separator("Box", false)]
	[SerializeField]
	private GameObject m_ProductsParent;

	[SerializeField]
	private GameObject m_IconCanvas;

	[SerializeField]
	private Box m_Box;

	public override void PlacingMode(bool value, Material hologramMaterial = null)
	{
	}

	public void ClearTriggers()
	{
	}
}
