using NaughtyAttributes;
using UnityEngine;

namespace Motorways
{
	[CreateAssetMenu(menuName = "Motorways/TutorialConstants")]
	public class TutorialConstantsData : ScriptableObject
	{
		private const string GeneralGroup = "General";

		[FoldoutGroup("General")]
		public Vector2 UnanchoredMessageOffset = new Vector2(0f, 0.7f);

		[FoldoutGroup("General")]
		public Vector2 UpgradeScreenMessageOffset = new Vector2(0f, 0.7f);

		private const string DrawDeleteGroup = "Draw Delete Stage";

		[FoldoutGroup("Draw Delete Stage")]
		public Vector2Int LockedEditModePosition = new Vector2Int(0, 0);

		[FoldoutGroup("Draw Delete Stage")]
		public Vector2 DrawRoadIdleHintStartPosition = new Vector2(-25f, -6f);

		[FoldoutGroup("Draw Delete Stage")]
		public Vector2 DrawRoadIdleHintEndPosition = new Vector2(-10f, -6f);

		public int DefaultConcreteForUpgradePair = 15;

		private const string TutorialEndStage = "Tutorial End Stage";

		[FoldoutGroup("Tutorial End Stage")]
		public int AdditionalScoreToGet = 50;

		[FoldoutGroup("Tutorial End Stage")]
		public int AdditionalScoreToGetRounding = 50;
	}
}
