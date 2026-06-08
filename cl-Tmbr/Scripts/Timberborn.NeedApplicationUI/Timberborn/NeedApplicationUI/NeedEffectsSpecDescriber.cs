using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;
using Timberborn.BaseComponentSystem;
using Timberborn.Common;
using Timberborn.CoreUI;
using Timberborn.EntityPanelSystem;
using Timberborn.GameFactionSystem;
using Timberborn.Localization;
using Timberborn.NeedApplication;
using Timberborn.NeedSpecs;

namespace Timberborn.NeedApplicationUI
{
	internal class NeedEffectsSpecDescriber : BaseComponent, IEntityDescriber, IAwakableComponent
	{
		private readonly EffectProbabilityService _effectProbabilityService;

		private readonly FactionNeedService _factionNeedService;

		private readonly NeedSpecFormatter _needSpecFormatter;

		private readonly ILoc _loc;

		private INeedEffectsSpec _spec;

		private readonly StringBuilder _descriptionBuilder = new StringBuilder();

		public NeedEffectsSpecDescriber(EffectProbabilityService effectProbabilityService, FactionNeedService factionNeedService, NeedSpecFormatter needSpecFormatter, ILoc loc)
		{
			_effectProbabilityService = effectProbabilityService;
			_factionNeedService = factionNeedService;
			_needSpecFormatter = needSpecFormatter;
			_loc = loc;
		}

		public void Awake()
		{
			_spec = GetComponent<INeedEffectsSpec>();
		}

		public IEnumerable<EntityDescription> DescribeEntity()
		{
			if (_effectProbabilityService.CanApplyEffects)
			{
				_descriptionBuilder.Clear();
				ImmutableArray<NeedApplierEffectSpec>.Enumerator enumerator = _spec.Effects.GetEnumerator();
				while (enumerator.MoveNext())
				{
					NeedApplierEffectSpec current = enumerator.Current;
					NeedSpec beaverOrBotNeedById = _factionNeedService.GetBeaverOrBotNeedById(current.NeedId);
					string param = _needSpecFormatter.ColorizeNeedByEffect(beaverOrBotNeedById);
					string displayName = ProbabilityDescriptionHelper.GetDisplayName(current.Probability);
					string text = _loc.T(displayName, param);
					_descriptionBuilder.AppendLine(SpecialStrings.RowStarter + text);
				}
				yield return EntityDescription.CreateTextSection(_descriptionBuilder.ToStringWithoutNewLineEndAndClean(), 3000);
			}
		}
	}
}
