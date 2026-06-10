using NSEipix;
using NSEipix.Base;
using NSMedieval;
using UnityEngine;

namespace Effects
{
	public class FoxyPointLightManager : MonoSingleton<FoxyPointLightManager>
	{
		private readonly SwapBackArray<FoxyPointLight> lights = new SwapBackArray<FoxyPointLight>(2048);

		private void Update()
		{
			if (!MonoSingleton<RtsCamera>.IsInstantiated())
			{
				return;
			}
			Vector3 b = MonoSingleton<RtsCamera>.Instance.transform.position;
			for (int i = 0; i < lights.Count; i++)
			{
				FoxyPointLight foxyPointLight = lights[i];
				while (foxyPointLight == null && i < lights.Count)
				{
					lights.RemoveAt(i);
					foxyPointLight = lights[i];
				}
				if ((object)foxyPointLight?.Light != null)
				{
					foxyPointLight.Light.enabled = foxyPointLight.transform.position.DistanceSquared(in b) < (float)foxyPointLight.MaxRenderDistanceSquared;
				}
			}
		}

		public void AddLight(FoxyPointLight light)
		{
			using (ProfilerSampleJanitor.Begin("AddLight"))
			{
				lights.Add(in light);
			}
		}

		public void RemoveLight(FoxyPointLight light)
		{
			using (ProfilerSampleJanitor.Begin("RemoveLight"))
			{
				for (int i = 0; i < lights.Count; i++)
				{
					if (lights[i] == light)
					{
						lights.RemoveAt(i);
						break;
					}
				}
			}
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();
			lights.Clear();
		}
	}
}
