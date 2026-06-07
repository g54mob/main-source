using UnityEngine;

namespace Obi
{
	public class ObiEmitterMaterialGranular : ObiEmitterMaterial
	{
		public float randomness;

		public void OnValidate()
		{
			resolution = Mathf.Max(0.001f, resolution);
			restDensity = Mathf.Max(0.001f, restDensity);
			randomness = Mathf.Max(0f, randomness);
		}

		public override Oni.FluidMaterial GetEquivalentOniMaterial(Oni.SolverParameters.Mode mode)
		{
			return new Oni.FluidMaterial
			{
				smoothingRadius = GetParticleSize(mode),
				restDensity = restDensity,
				viscosity = 0f,
				surfaceTension = 0f,
				buoyancy = -1f,
				atmosphericDrag = 0f,
				atmosphericPressure = 0f,
				vorticity = 0f
			};
		}
	}
}
