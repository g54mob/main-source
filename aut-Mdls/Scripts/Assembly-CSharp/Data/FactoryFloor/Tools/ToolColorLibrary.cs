using UnityEngine;

namespace Data.FactoryFloor.Tools
{
	[CreateAssetMenu(menuName = "Factory/Tools/ToolColorLibrary", fileName = "ToolColorLibrary", order = 0)]
	public class ToolColorLibrary : ScriptableObject
	{
		public Color SelectToolColor;

		public Color MoveToolColor;

		public Color DuplicateToolColor;

		public Color CleanConveyorsToolColor;

		public Color DeleteToolColor;

		public Color CreateBlueprintToolColor;

		public Color ValidPlacementColor;

		public Color InvalidPlacementColor;
	}
}
