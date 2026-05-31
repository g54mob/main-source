using UnityEngine;

namespace CTS
{
	[CreateAssetMenu(fileName = "Cocktails Element", menuName = "BBT/Cocktails Element")]
	public class CraftVisualElement : ScriptableObject
	{
		public enum E_CocktailElements
		{
			Glass = 0,
			Decoration = 1
		}

		[SerializeField]
		private GameObject _prefab;
	}
}
