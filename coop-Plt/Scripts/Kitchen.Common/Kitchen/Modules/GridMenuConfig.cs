using KitchenData;
using UnityEngine;

namespace Kitchen.Modules
{
	public abstract class GridMenuConfig : KitchenObject
	{
		public Texture2D Icon;

		public abstract GridMenu Instantiate(Transform container, int player, bool has_back);
	}
}
