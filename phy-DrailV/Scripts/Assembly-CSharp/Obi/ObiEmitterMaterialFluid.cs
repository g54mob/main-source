using UnityEngine;

namespace Obi
{
	public class ObiEmitterMaterialFluid : ObiEmitterMaterial
	{
		public float smoothing = 1.5f;

		public float viscosity = 0.05f;

		public float surfaceTension = 0.1f;

		public float buoyancy = -1f;

		public float atmosphericDrag;

		public float atmosphericPressure;

		public float vorticity;

		public void OnValidate()
		{
			resolution = Mathf.Max(0.001f, resolution);
			restDensity = Mathf.Max(0.001f, restDensity);
			smoothing = Mathf.Max(1f, smoothing);
			viscosity = Mathf.Max(0f, viscosity);
			atmosphericDrag = Mathf.Max(0f, atmosphericDrag);
		}

		public override Oni.FluidMaterial GetEquivalentOniMaterial(Oni.SolverParameters.Mode mode)
		{
			return new Oni.FluidMaterial
			{
				smoothingRadius = GetParticleSize(mode) * smoothing,
				restDensity = restDensity,
				viscosity = viscosity,
				surfaceTension = surfaceTension,
				buoyancy = buoyancy,
				atmosphericDrag = atmosphericDrag,
				atmosphericPressure = atmosphericPressure,
				vorticity = vorticity
			};
		}
	}
}
