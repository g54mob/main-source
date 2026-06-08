using System;
using System.Collections.Immutable;
using Timberborn.BaseComponentSystem;
using Timberborn.NeedSpecs;
using Timberborn.RangedEffectSystem;

namespace Timberborn.Wonders
{
	internal class WonderEffectController : BaseComponent, IAwakableComponent
	{
		private RangedEffectBuilding _rangedEffectBuilding;

		private Wonder _wonder;

		private WonderEffectControllerSpec _wonderEffectControllerSpec;

		public ImmutableArray<ContinuousEffectSpec> Effects => _wonderEffectControllerSpec.Effects;

		public void Awake()
		{
			_rangedEffectBuilding = GetComponent<RangedEffectBuilding>();
			_wonder = GetComponent<Wonder>();
			_wonderEffectControllerSpec = GetComponent<WonderEffectControllerSpec>();
			_wonder.WonderActivated += OnWonderActivated;
			_wonder.WonderDeactivated += OnWonderDeactivated;
		}

		private void EnableEffects()
		{
			ImmutableArray<ContinuousEffectSpec>.Enumerator enumerator = Effects.GetEnumerator();
			while (enumerator.MoveNext())
			{
				ContinuousEffectSpec current = enumerator.Current;
				_rangedEffectBuilding.AddEffect(current);
			}
		}

		private void DisableEffects()
		{
			ImmutableArray<ContinuousEffectSpec>.Enumerator enumerator = Effects.GetEnumerator();
			while (enumerator.MoveNext())
			{
				ContinuousEffectSpec current = enumerator.Current;
				_rangedEffectBuilding.RemoveEffect(current);
			}
		}

		private void OnWonderActivated(object sender, EventArgs e)
		{
			EnableEffects();
		}

		private void OnWonderDeactivated(object sender, EventArgs e)
		{
			DisableEffects();
		}
	}
}
