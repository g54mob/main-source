using UnityEngine;

namespace NSMedieval
{
	public class BleedingIntensity : MonoBehaviour
	{
		[SerializeField]
		private ParticleSystem[] ps;

		public ParticleSystem[] PS
		{
			get
			{
				return ps;
			}
			set
			{
				ps = value;
			}
		}

		public void SetIntensity(float intensity)
		{
			ParticleSystem[] array = ps;
			for (int i = 0; i < array.Length; i++)
			{
				ParticleSystem.MainModule main = array[i].main;
				main.startLifetimeMultiplier = intensity;
			}
		}
	}
}
