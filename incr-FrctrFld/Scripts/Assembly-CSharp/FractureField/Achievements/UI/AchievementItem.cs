using Reactivity.Unity.Components;
using UnityEngine;

namespace FractureField.Achievements.UI
{
	public class AchievementItem : RComponent
	{
		[Header("References")]
		[SerializeField]
		private RectTransform _rect;

		[SerializeField]
		private RImage _iconImage;

		[SerializeField]
		private RImage _backgroundImage;

		private readonly Color _green;

		private readonly Color _gray;

		public Achievement Achievement { get; private set; }

		public void Setup(Achievement achievement)
		{
		}
	}
}
