using System;
using System.Collections.Immutable;
using Timberborn.BaseComponentSystem;
using Timberborn.EntitySystem;
using Timberborn.NeedSpecs;
using Timberborn.NeedSystem;

namespace Timberborn.BeaverContaminationSystem
{
	internal class ContaminationNeedEnabler : BaseComponent, IAwakableComponent, IInitializableEntity
	{
		private static readonly string ShelterNeedId = "Shelter";

		private static readonly string AntidoteNeedId = "Antidote";

		private NeedManager _needManager;

		private Contaminable _contaminable;

		public void Awake()
		{
			_needManager = GetComponent<NeedManager>();
			_contaminable = GetComponent<Contaminable>();
			_contaminable.ContaminationChanged += OnContaminationChanged;
		}

		public void InitializeEntity()
		{
			UpdateNeeds();
		}

		private void OnContaminationChanged(object sender, EventArgs e)
		{
			UpdateNeeds();
		}

		private void UpdateNeeds()
		{
			ImmutableArray<NeedSpec>.Enumerator enumerator = _needManager.NeedSpecs.GetEnumerator();
			while (enumerator.MoveNext())
			{
				NeedSpec current = enumerator.Current;
				if (ShouldBeEnabled(current))
				{
					_needManager.EnableNeed(current.Id);
					continue;
				}
				_needManager.ResetNeed(current.Id);
				_needManager.DisableNeed(current.Id);
			}
		}

		private bool ShouldBeEnabled(NeedSpec needSpec)
		{
			if (IsEnabledOnlyWhenContaminated(needSpec))
			{
				return _contaminable.IsContaminated;
			}
			if (IsDisabledWhenContaminated(needSpec))
			{
				return !_contaminable.IsContaminated;
			}
			return true;
		}

		private static bool IsEnabledOnlyWhenContaminated(NeedSpec needSpec)
		{
			return needSpec.Id == AntidoteNeedId;
		}

		private static bool IsDisabledWhenContaminated(NeedSpec needSpec)
		{
			if (!needSpec.HasSpec<CriticalNeedSpec>())
			{
				return needSpec.Id != ShelterNeedId;
			}
			return false;
		}
	}
}
