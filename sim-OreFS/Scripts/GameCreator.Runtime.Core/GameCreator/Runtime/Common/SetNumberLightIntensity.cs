using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Intensity")]
	[Category("Light/Intensity")]
	[Image(typeof(IconLight), ColorTheme.Type.Yellow)]
	[Description("The intensity of a Light source component")]
	public class SetNumberLightIntensity : PropertyTypeSetNumber
	{
		[SerializeField]
		private PropertyGetGameObject m_Light = GetGameObjectInstance.Create();

		public override string String => $"{m_Light}[Intensity]";

		public override void Set(double value, Args args)
		{
			Light light = m_Light.Get<Light>(args);
			if (light != null)
			{
				light.intensity = (float)value;
			}
		}

		public override double Get(Args args)
		{
			Light light = m_Light.Get<Light>(args);
			return (light != null) ? light.intensity : 0f;
		}
	}
}
