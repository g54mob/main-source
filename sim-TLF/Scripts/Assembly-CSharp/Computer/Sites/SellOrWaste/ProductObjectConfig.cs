using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Computer.Sites.SellOrWaste
{
	[CreateAssetMenu(menuName = "Computer/Sites/SellOrWaste/Objects/Product")]
	public class ProductObjectConfig : ScriptableObject
	{
		public Sprite ProductIcon;

		public AssetReference AssetReference;

		public string ProductName;

		public float ProductPrice;
	}
}
