using UnityEngine;

namespace ModApi.PlanetStudio
{
	public abstract class PlanetStudioBase : MonoBehaviour, IPlanetStudio
	{
		public static IPlanetStudio Instance { get; private set; }

		public abstract ICelestialBodyDesigner CelestialBodyDesigner { get; }

		public abstract IPlanetarySystemDesigner PlanetarySystemDesigner { get; }

		public abstract IPlanetStudioUI PlanetStudioUI { get; }

		protected virtual void Awake()
		{
			Instance = this;
		}

		protected virtual void OnDestroy()
		{
			Instance = null;
		}
	}
}
