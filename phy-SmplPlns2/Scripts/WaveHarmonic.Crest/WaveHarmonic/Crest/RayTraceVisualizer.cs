using System;
using UnityEngine;
using WaveHarmonic.Crest.Internal;
using WaveHarmonic.Crest.Utility;

namespace WaveHarmonic.Crest
{
	[AddComponentMenu("Crest/Debug/Crest Ray Cast Visualizer")]
	internal sealed class RayTraceVisualizer : ManagedBehaviour<WaterRenderer>
	{
		private readonly RayCastHelper _RayCast = new RayCastHelper(50f);

		private protected override Action<WaterRenderer> OnUpdateMethod => OnUpdate;

		private void OnUpdate(WaterRenderer water)
		{
			if (water.AnimatedWavesLod.Provider != null)
			{
				if (_RayCast.RayCast(base.transform.position, base.transform.forward, out var distance))
				{
					Vector3 vector = base.transform.position + base.transform.forward * distance;
					Debug.DrawLine(base.transform.position, vector, Color.green);
					DebugUtility.DrawCross(Debug.DrawLine, vector, 2f, Color.green);
				}
				else
				{
					Debug.DrawLine(base.transform.position, base.transform.position + base.transform.forward * 50f, Color.red);
				}
			}
		}
	}
}
