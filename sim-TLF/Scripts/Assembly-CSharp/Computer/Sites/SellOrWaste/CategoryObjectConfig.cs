using System.Collections.Generic;
using UnityEngine;

namespace Computer.Sites.SellOrWaste
{
	[CreateAssetMenu(menuName = "Computer/Sites/SellOrWaste/Objects/Category")]
	public class CategoryObjectConfig : ScriptableObject
	{
		public Sprite CategoryIcon;

		public string CategoryName;

		public List<ProductObjectConfig> Products;
	}
}
