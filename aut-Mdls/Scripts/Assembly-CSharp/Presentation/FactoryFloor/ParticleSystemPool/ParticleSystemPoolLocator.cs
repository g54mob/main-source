using UnityEngine;

namespace Presentation.FactoryFloor.ParticleSystemPool
{
	[CreateAssetMenu(menuName = "Locators/ParticleSystemPoolLocator", fileName = "ParticleSystemPoolLocator", order = 0)]
	public class ParticleSystemPoolLocator : ScriptableObject
	{
		public ParticleSystemPool Pool { get; set; }
	}
}
