using System.Collections.Immutable;
using Timberborn.BaseComponentSystem;
using Timberborn.BlockSystem;
using Timberborn.NeedSpecs;

namespace Timberborn.RangedEffectSystem
{
	internal class ContinuousEffectBuilding : BaseComponent, IAwakableComponent, IFinishedStateListener
	{
		private ContinuousEffectBuildingSpec _continuousEffectBuildingSpec;

		private RangedEffectBuilding _rangedEffectBuilding;

		public ImmutableArray<ContinuousEffectSpec> Effects => _continuousEffectBuildingSpec.Effects;

		public void Awake()
		{
			_continuousEffectBuildingSpec = GetComponent<ContinuousEffectBuildingSpec>();
			_rangedEffectBuilding = GetComponent<RangedEffectBuilding>();
		}

		public void OnEnterFinishedState()
		{
			ImmutableArray<ContinuousEffectSpec>.Enumerator enumerator = Effects.GetEnumerator();
			while (enumerator.MoveNext())
			{
				ContinuousEffectSpec current = enumerator.Current;
				_rangedEffectBuilding.AddEffect(current);
			}
		}

		public void OnExitFinishedState()
		{
			ImmutableArray<ContinuousEffectSpec>.Enumerator enumerator = Effects.GetEnumerator();
			while (enumerator.MoveNext())
			{
				ContinuousEffectSpec current = enumerator.Current;
				_rangedEffectBuilding.RemoveEffect(current);
			}
		}
	}
}
