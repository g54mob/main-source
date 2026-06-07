using System;
using System.Collections.Generic;

[Serializable]
public class TrafficCityIntersectionLightStage
{
	public bool view;

	public List<TrafficCityIntersectionLightComponent> Lights;

	public List<bool> isGreen;
}
