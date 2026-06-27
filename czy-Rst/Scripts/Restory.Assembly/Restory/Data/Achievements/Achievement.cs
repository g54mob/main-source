using Restory.Achievements;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Restory.Data.Achievements
{
	[CreateAssetMenu(fileName = "Achievement", menuName = "Restory/Achievements/Achievement")]
	public class Achievement : SerializedScriptableObject
	{
		[SerializeField]
		private AchievementId id;

		[SerializeField]
		private Sprite iconUnlocked;

		[SerializeField]
		private Sprite iconLocked;

		[SerializeField]
		private string nameKey;

		[SerializeField]
		private string descriptionKey;

		[SerializeField]
		private bool isCounter;

		[SerializeField]
		private float minValue;

		[SerializeField]
		private float maxValue;

		public AchievementId Id => id;

		public Sprite IconUnlocked => iconUnlocked;

		public Sprite IconLocked => iconLocked;

		public string NameKey => nameKey;

		public string DescriptionKey => descriptionKey;

		public bool IsCounter => isCounter;

		public float MinValue => minValue;

		public float MaxValue => maxValue;
	}
}
