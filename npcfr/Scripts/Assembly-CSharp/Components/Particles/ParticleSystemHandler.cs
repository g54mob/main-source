using System;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Components.Particles
{
	[RequireComponent(typeof(ParticleSystem))]
	public class ParticleSystemHandler : g
	{
		[field: SerializeField]
		public ParticleSystem PS { get; private set; }

		public event Action tfo
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		private void OnParticleSystemStopped()
		{
		}

		private void OnValidate()
		{
		}

		private void jgd()
		{
		}

		private void jge()
		{
		}
	}
}
