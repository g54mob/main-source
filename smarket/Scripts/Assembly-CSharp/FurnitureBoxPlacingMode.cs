using MyBox;
using UnityEngine;

public class FurnitureBoxPlacingMode : IPlacingMode
{
	[Separator("Furniture Box", false)]
	[SerializeField]
	private GameObject m_IconCanvas;

	[SerializeField]
	private FurnitureBox m_Box;

	public override void PlacingMode(bool value, Material hologramMaterial = null)
	{
	}
}
