using UnityEngine;

[CreateAssetMenu(menuName = "DLC/Ice Cream/IceCreamFlavour")]
public class IceCreamFlavour : ScriptableObject
{
	[SerializeField]
	private Material m_Material;

	[SerializeField]
	private int m_ID;

	[SerializeField]
	private Sprite m_Icon;

	[SerializeField]
	private Color m_Color;

	[SerializeField]
	private ProductSO m_Product;

	[SerializeField]
	private IceCreamBucket m_BucketPrefab;

	public Material Material => null;

	public int ID => 0;

	public Sprite Icon => null;

	public Color Color => default(Color);

	public ProductSO Product => null;

	public IceCreamBucket BucketPrefab => null;
}
