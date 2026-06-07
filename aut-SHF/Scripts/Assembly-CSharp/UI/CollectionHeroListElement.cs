using System;
using UnityEngine;

namespace UI
{
	public class CollectionHeroListElement : CollectionListElement
	{
		[Serializable]
		private class LevelStar
		{
			public GameObject offStar;

			public GameObject onStar;
		}

		[SerializeField]
		private GameObject starArea;

		[SerializeField]
		private StarCounter starCounter;

		private int level;

		public int Level => 0;

		public override void InitComponent(ChoiceMenuButtonInitBase init)
		{
		}

		public void SetLevelStarMax()
		{
		}

		public void CheckLevelStar(bool isHero = false)
		{
		}

		public void UpdateLevelStarUI()
		{
		}
	}
}
