using LitJson;
using UnityEngine;

namespace Gh.Tk
{
	public static class ParticleSystemDataExtensions
	{
		public static ParticleSystemData ToData(this ParticleSystem particleSystem)
		{
			return default(ParticleSystemData);
		}

		public static void FromJson(this ParticleSystem particleSystem, JsonData data)
		{
		}

		public static void ApplyToObject(this ParticleSystemData data, ParticleSystem particleSystem)
		{
		}
	}
}
