using System.Collections.Generic;
using UnityEngine;

namespace Computer.Sites.SellOrWaste
{
	[CreateAssetMenu(menuName = "Computer/Sites/SellOrWaste/Products Config")]
	public class ProductsConfig : ScriptableObject
	{
		public List<ProductObjectConfig> Products;
	}
}
