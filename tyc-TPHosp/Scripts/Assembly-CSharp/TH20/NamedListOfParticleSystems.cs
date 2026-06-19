using System;
using System.Collections.Generic;
using UnityEngine;

namespace TH20
{
	[Serializable]
	public class NamedListOfParticleSystems
	{
		public string Name;

		public List<ParticleSystem> ParticleSystems;
	}
}
