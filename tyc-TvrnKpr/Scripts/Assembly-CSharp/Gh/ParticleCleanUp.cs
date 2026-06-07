using System;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Gh
{
	public class ParticleCleanUp : MonoBehaviour
	{
		public enum CleanUpMethod
		{
			Destroy = 0,
			Disable = 1,
			DisableAndHandbackToPool = 2
		}

		public CleanUpMethod cleanUpMethod;

		public bool disableLoopingWarning;

		private ParticleSystem[] _oneShotParticleSystems;

		public event EventHandler ParticleCleaningUp
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

		private void Start()
		{
		}

		private void Update()
		{
		}

		public void CleanUp()
		{
		}
	}
}
