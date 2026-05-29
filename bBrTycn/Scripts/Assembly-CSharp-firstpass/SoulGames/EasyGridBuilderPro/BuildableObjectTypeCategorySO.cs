using UnityEngine;

namespace SoulGames.EasyGridBuilderPro
{
	[CreateAssetMenu(menuName = "SoulGames/Easy Grid Builder Pro/BuildableObjectTypeCategorySO", order = 190)]
	public class BuildableObjectTypeCategorySO : ScriptableObject
	{
		[Space]
		[Tooltip("Category Name. This will be used in UI")]
		public string categoryName;

		[Tooltip("Category Icon/Image. This will be used in UI")]
		public Sprite categoryIcon;
	}
}
