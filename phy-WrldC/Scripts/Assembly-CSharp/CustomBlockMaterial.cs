using UnityEngine;

public class CustomBlockMaterial : MonoBehaviour
{
	[SerializeField]
	private Material normal;

	[SerializeField]
	private Material transparent;

	[SerializeField]
	private Material green;

	[SerializeField]
	private Material red;

	public Material Normal => normal;

	public Material Transparent => transparent;

	public Material Green => green;

	public Material Red => red;

	public void SetMaterials(Material normal, Material transparent, Material green, Material red)
	{
		this.normal = normal;
		this.transparent = transparent;
		this.green = green;
		this.red = red;
	}
}
