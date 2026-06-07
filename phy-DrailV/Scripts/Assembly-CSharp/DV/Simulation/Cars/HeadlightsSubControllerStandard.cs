using UnityEngine;
using VLB;

namespace DV.Simulation.Cars
{
	public class HeadlightsSubControllerStandard : HeadlightsSubControllerBase
	{
		public override void UpdateHeadlights(HeadlightsMainController.HeadlightSetting setting)
		{
			if (!HoseConnectionAllowsHeadlights() || !MUAllowsHeadlight())
			{
				setting = HeadlightsMainController.HeadlightSetting.Off;
			}
			bool flag2;
			bool flag3;
			bool flag = (flag2 = (flag3 = setting == HeadlightsMainController.HeadlightSetting.HeadlightSetting02 || setting == HeadlightsMainController.HeadlightSetting.HeadlightSetting03));
			bool flag4 = flag3 || setting == HeadlightsMainController.HeadlightSetting.HeadlightSetting01;
			Headlight[] array = headlights;
			foreach (Headlight obj in array)
			{
				obj.ToggleBeam(flag, flag && base.OptimizerAllowsBeams);
				VolumetricLightBeam beam = obj.beamData.beam;
				if (beam != null)
				{
					optimizer.UpdateDynamicBeam(beam.gameObject, flag);
				}
				obj.ToggleGlare(flag2 && base.OptimizerAllowsGlares);
				GameObject glare = obj.glare;
				if (glare != null)
				{
					optimizer.UpdateDynamicGlare(glare, flag2);
				}
				obj.ToggleEmission(flag4);
			}
			Light[] array2 = lightSources;
			foreach (Light light in array2)
			{
				if (!(light == null))
				{
					light.enabled = flag3;
					optimizer.UpdateDynamicHeadlights(light.gameObject, flag3);
				}
			}
		}
	}
}
