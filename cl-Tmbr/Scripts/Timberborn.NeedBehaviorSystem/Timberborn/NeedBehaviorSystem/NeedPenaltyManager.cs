using System.Collections.Immutable;
using Timberborn.BaseComponentSystem;
using Timberborn.BonusSystem;
using Timberborn.NeedSpecs;
using Timberborn.NeedSystem;

namespace Timberborn.NeedBehaviorSystem
{
	public class NeedPenaltyManager : BaseComponent, IAwakableComponent, IStartableComponent
	{
		private BonusManager _bonusManager;

		private NeedManager _needManager;

		public void Awake()
		{
			_bonusManager = GetComponent<BonusManager>();
		}

		public void Start()
		{
			_needManager = GetComponent<NeedManager>();
			_needManager.NeedChangedIsFavorable += delegate(object _, NeedChangedIsFavorableEventArgs e)
			{
				UpdatePenalties(e.NeedSpec);
			};
			ImmutableArray<NeedSpec>.Enumerator enumerator = _needManager.NeedSpecs.GetEnumerator();
			while (enumerator.MoveNext())
			{
				NeedSpec current = enumerator.Current;
				PunitiveNeedSpec spec = current.GetSpec<PunitiveNeedSpec>();
				if ((object)spec != null && !_needManager.NeedIsFavorable(current.Id))
				{
					AddPenalties(spec);
				}
			}
		}

		private void UpdatePenalties(NeedSpec needSpec)
		{
			PunitiveNeedSpec spec = needSpec.GetSpec<PunitiveNeedSpec>();
			if ((object)spec != null)
			{
				if (!_needManager.NeedIsFavorable(needSpec.Id))
				{
					AddPenalties(spec);
				}
				else
				{
					RemovePenalties(spec);
				}
			}
		}

		private void AddPenalties(PunitiveNeedSpec punitiveNeedSpec)
		{
			ImmutableArray<BonusSpec>.Enumerator enumerator = punitiveNeedSpec.Penalties.GetEnumerator();
			while (enumerator.MoveNext())
			{
				BonusSpec current = enumerator.Current;
				_bonusManager.AddBonus(current.Id, current.MultiplierDelta);
			}
		}

		private void RemovePenalties(PunitiveNeedSpec punitiveNeedSpec)
		{
			ImmutableArray<BonusSpec>.Enumerator enumerator = punitiveNeedSpec.Penalties.GetEnumerator();
			while (enumerator.MoveNext())
			{
				BonusSpec current = enumerator.Current;
				_bonusManager.RemoveBonus(current.Id, current.MultiplierDelta);
			}
		}
	}
}
