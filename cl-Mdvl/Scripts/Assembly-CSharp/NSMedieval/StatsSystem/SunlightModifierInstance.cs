using NSEipix.Base;
using NSMedieval.Manager;
using NSMedieval.State;

namespace NSMedieval.StatsSystem
{
	public class SunlightModifierInstance : CustomAttributeModifierInstance
	{
		public SunlightModifierInstance(AttributeType attributeType, float value, string tag, bool negativeStacking = false)
			: base(attributeType, value, tag, negativeStacking)
		{
		}

		public override void Apply()
		{
			if (attributeInstance != null && MonoSingleton<WeatherManager>.IsInstantiated())
			{
				ILightReceiver lightReceiver = (ILightReceiver)base.Owner.Owner;
				attributeInstance.SetMultiplier(lightReceiver.GetSunlightLossMultiplier());
			}
		}
	}
}
