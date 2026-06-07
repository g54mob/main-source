using System.Collections.Generic;
using UnityEngine;

namespace VampireSurvivors.Framework
{
	public class GlimmerTechniqueCarousel : MonoBehaviour
	{
		[SerializeField]
		private GlimmerTechniqueCarouselItem m_GlimmerTechniqueCarouselItemPrefab;

		[SerializeField]
		private Transform m_OffScreenTransform;

		private List<GlimmerTechniqueCarouselItem> m_CurrentlyShowingGlimmmerTechniques;

		private List<GlimmerTechniqueCarouselItem> m_GlimmmerTechniquesToBeReturnedToPool;

		private List<GlimmerTechniqueCarouselItem> m_GlimmmerTechniquePool;

		[SerializeField]
		private float m_SlideToFillGapSpeed;

		private int m_TechniquePoolSize;

		private float m_GapBetweenTechniques;

		private float m_MaximumHeight;

		private float m_AgeToEndIntroSwish;

		private float m_AgeToStartExit;

		private float m_AgeToDie;

		private void Start()
		{
		}

		private void Update()
		{
		}

		private void ProcessReturningGlimmmerTechniquesToPool()
		{
		}

		private void SpawnNewTestTechnique()
		{
		}

		public void SpawnGlimmerTechnique(string techniqueText)
		{
		}
	}
}
