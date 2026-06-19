using Aggro.Core;
using Aggro.Core.Networking;
using UnityEngine;

public class FaultyWiringLight : EntityBehaviourBase
{
	private Light _light;

	protected override void OnEntityCreated()
	{
		_light = GetComponent<Light>();
	}

	protected override void OnUpdatePresentation()
	{
		if (GameUtil.isRun && NetworkAggroManagerBase<ModifierManager>.instance.currentModifier != null && NetworkAggroManagerBase<ModifierManager>.instance.currentModifier is ModifierFaultyWiring)
		{
			ModifierFaultyWiring modifierFaultyWiring = NetworkAggroManagerBase<ModifierManager>.instance.currentModifier as ModifierFaultyWiring;
			_light.enabled = modifierFaultyWiring.lightsOffValue > 0.8f;
		}
		else
		{
			_light.enabled = false;
		}
	}
}
