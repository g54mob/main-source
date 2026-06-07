using MalbersAnimations.Scriptables;
using UnityEngine;

namespace MalbersAnimations
{
	[AddComponentMenu("Malbers/Utilities/Effects - Audio/FireBreath")]
	public class FireBreath : MonoBehaviour
	{
		public bool onStart;

		public float rateOverTime = 500f;

		public ParticleSystem[] m_Particles;

		private bool currentState;

		private void Awake()
		{
			if (m_Particles == null)
			{
				m_Particles = GetComponentsInChildren<ParticleSystem>();
			}
			if (m_Particles != null && m_Particles.Length != 0)
			{
				ParticleSystem[] particles = m_Particles;
				for (int i = 0; i < particles.Length; i++)
				{
					ParticleSystem.EmissionModule emission = particles[i].emission;
					emission.rateOverTime = new ParticleSystem.MinMaxCurve(0f);
				}
			}
			else
			{
				Object.Destroy(this);
			}
		}

		private void OnEnable()
		{
			if (onStart)
			{
				Activate(value: true);
			}
		}

		public void Activate(bool value)
		{
			if (currentState != value)
			{
				currentState = value;
				ParticleSystem[] particles = m_Particles;
				for (int i = 0; i < particles.Length; i++)
				{
					ParticleSystem.EmissionModule emission = particles[i].emission;
					emission.rateOverTime = new ParticleSystem.MinMaxCurve(value ? rateOverTime : 0f);
				}
			}
		}

		public void FireBreathColor(Color newcolor)
		{
			ParticleSystem[] particles = m_Particles;
			for (int i = 0; i < particles.Length; i++)
			{
				ParticleSystem.MainModule main = particles[i].main;
				main.startColor = new ParticleSystem.MinMaxGradient(newcolor);
			}
		}

		public void FireBreathColor(ColorVar newcolor)
		{
			FireBreathColor(newcolor.Value);
		}
	}
}
