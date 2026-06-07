using UMA.CharacterSystem;
using UnityEngine;

namespace UMA
{
	public class ItemEffector : MonoBehaviour
	{
		public IItemSelector itemSelector;

		public UMAWardrobeRecipe recipe;

		public void Setup(IItemSelector itemSelector, UMAWardrobeRecipe recipe)
		{
		}

		public void ImageClicked()
		{
		}
	}
}
