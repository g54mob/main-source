using Assets.Nimbatus.Scripts.GalaxyMap;
using Assets.Nimbatus.Scripts.GalaxyMap.Locations;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.World.Terrain.ClimateZone;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.Controls
{
	public class SkyBackground : MonoBehaviour
	{
		private Gradient _activeGradient;

		public void Start()
		{
			SetStartSky();
		}

		public void SetStartSky()
		{
			BossfightLocationData bossfightLocationData;
			if ((bossfightLocationData = SerializableMonobehaviour<GalaxyMapManager, GalaxyMapSaveData>.Instance.CurrentLocation as BossfightLocationData) != null)
			{
				SetGradient(bossfightLocationData.Fight.SkyGradient);
				SetOffset(bossfightLocationData.Fight.SkyOffsetX, bossfightLocationData.Fight.SkyOffsetY);
			}
			else if (SerializableMonobehaviour<NimbatusClimateZoneManager, ClimateZoneManagerSaveData>.Instance.ActiveClimateZone != null)
			{
				SetGradient(SerializableMonobehaviour<NimbatusClimateZoneManager, ClimateZoneManagerSaveData>.Instance.ActiveClimateZone.SkyGradient);
			}
			else
			{
				SetGradient(SerializableMonobehaviour<NimbatusClimateZoneManager, ClimateZoneManagerSaveData>.Instance.SpaceSkyGradient);
			}
		}

		public void SetGradient(Gradient gradient)
		{
			if (_activeGradient == gradient)
			{
				return;
			}
			_activeGradient = gradient;
			Renderer component = GetComponent<Renderer>();
			int num = ((SerializableMonobehaviour<NimbatusClimateZoneManager, ClimateZoneManagerSaveData>.Instance.ActiveClimateZone != null) ? SerializableMonobehaviour<NimbatusClimateZoneManager, ClimateZoneManagerSaveData>.Instance.ActiveClimateZone.SelectedSettings.PlanetSize : 400);
			component.material.SetFloat("_GradientRadiusInner", num);
			component.material.SetFloat("_GradientRadiusOuter", (float)num * 2.5f);
			if (gradient.colorKeys.Length == 5)
			{
				for (int i = 0; i < 5; i++)
				{
					Color color = gradient.colorKeys[i].color;
					float time = gradient.colorKeys[i].time;
					component.material.SetColor("_GradientColor" + i, color);
					if (i > 0 && i < 4)
					{
						component.material.SetFloat("_GradientColorPosition" + i, time);
					}
				}
				return;
			}
			float num2 = 0f;
			for (int j = 0; j < 5; j++)
			{
				component.material.SetColor("_GradientColor" + j, gradient.Evaluate(num2));
				if (j > 0 && j < 4)
				{
					component.material.SetFloat("_GradientColorPosition" + j, num2);
				}
				num2 += 0.25f;
			}
		}

		public void SetOffset(float x, float y)
		{
			Renderer component = GetComponent<Renderer>();
			component.material.SetFloat("_PositionOffsetX", x);
			component.material.SetFloat("_PositionOffsetY", y);
		}
	}
}
