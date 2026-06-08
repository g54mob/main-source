using Dorfromantik.UI;
using UnityEngine;
using UnityEngine.Serialization;

namespace Dorfromantik
{
	public class UiScalingLevelData : ScriptableObject
	{
		[FormerlySerializedAs("level")]
		public UiScalingLevelId levelId;

		public Vector2 challengeCardSize = new Vector2(263f, 475f);

		public float scalingValue = 1f;
	}
}
