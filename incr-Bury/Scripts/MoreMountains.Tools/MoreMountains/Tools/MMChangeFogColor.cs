using UnityEngine;

namespace MoreMountains.Tools
{
	[ExecuteAlways]
	[AddComponentMenu("More Mountains/Tools/Particles/MM Change Fog Color")]
	public class MMChangeFogColor : MonoBehaviour
	{
		[MMInformation("Adds this class to a UnityStandardAssets.ImageEffects.GlobalFog to change its color", MMInformationAttribute.InformationType.Info, false)]
		public Color FogColor;

		protected virtual void SetupFogColor()
		{
			RenderSettings.fogColor = FogColor;
			RenderSettings.fog = true;
		}

		protected virtual void Start()
		{
			SetupFogColor();
		}

		protected virtual void OnValidate()
		{
			SetupFogColor();
		}
	}
}
