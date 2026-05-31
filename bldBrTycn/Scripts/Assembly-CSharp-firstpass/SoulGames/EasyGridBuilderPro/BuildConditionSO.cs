using UnityEngine;

namespace SoulGames.EasyGridBuilderPro
{
	[CreateAssetMenu(menuName = "SoulGames/Easy Grid Builder Pro/BuildConditionSO", order = 200)]
	public class BuildConditionSO : ScriptableObject
	{
		[Tooltip("Should wood consumed after build is complete. If not only check weather wood amount is in inventory and do not consume.")]
		[TextArea(4, 5)]
		public string tooltipContent;

		[Tooltip("Food amount should be in inventory to build.")]
		public int foodAmount;

		[Tooltip("Should food consumed after build is complete. If not only check weather food amount is in inventory and do not consume.")]
		public bool consumeFoodOnBuild;

		[Tooltip("Metal amount should be in inventory to build.")]
		public int metalAmount;

		[Tooltip("Should metal consumed after build is complete. If not only check weather metal amount is in inventory and do not consume.")]
		public bool consumeMetalOnBuild;

		[Tooltip("Wood amount should be in inventory to build.")]
		public int woodAmount;

		[Tooltip("Should wood consumed after build is complete. If not only check weather wood amount is in inventory and do not consume.")]
		public bool consumeWoodOnBuild;
	}
}
