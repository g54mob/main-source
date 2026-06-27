using UnityEngine;

namespace DistantLands.Cozy
{
	[ExecuteAlways]
	public class CozySetMoonDirection : MonoBehaviour
	{
		private CozyWeather weatherSphere;

		private void Update()
		{
			if (weatherSphere == null)
			{
				weatherSphere = CozyWeather.instance;
			}
			weatherSphere.moonDirection = -base.transform.forward;
			Shader.SetGlobalVector("CZY_MoonDirection", -base.transform.forward);
		}
	}
}
