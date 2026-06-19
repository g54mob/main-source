using System.Collections.Generic;
using UnityEngine;

namespace Computer.Sites.SellOrWaste
{
	[CreateAssetMenu(menuName = "Computer/Sites/SellOrWaste/Categories Config")]
	public class CategoriesConfig : ScriptableObject
	{
		public List<CategoryObjectConfig> Categories;
	}
}
