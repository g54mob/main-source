using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Range")]
	[Category("Light/Range")]
	[Image(typeof(IconLight), ColorTheme.Type.Yellow)]
	[Description("The range of a Light source")]
	[Keywords(new string[] { "Light", "Lux" })]
	public class GetDecimalLightRange : PropertyTypeGetDecimal
	{
		[SerializeField]
		private PropertyGetGameObject m_Light = GetGameObjectInstance.Create();

		public override string String => $"{m_Light}[Range]";

		public override double Get(Args args)
		{
			Light light = m_Light.Get<Light>(args);
			return (light != null) ? light.range : 0f;
		}
	}
}
