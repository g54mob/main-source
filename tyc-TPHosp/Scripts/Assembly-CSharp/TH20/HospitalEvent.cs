using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public abstract class HospitalEvent
	{
		[UsedImplicitly(ImplicitUseTargetFlags.Members)]
		public abstract class Config
		{
			[SerializeField]
			public int _durationInMonths = 12;

			[SerializeField]
			public LocalisedString _iconTooltip;

			protected Level _level;

			public abstract void RegisterEvents(Level level, bool restoreFromSave);

			public abstract void UnregisterEvents();
		}

		public GameDate Date;

		protected Config _config;

		public virtual bool HasExpired(GameDate currentDate)
		{
			if (_config != null)
			{
				return currentDate.DaysSince(Date) >= _config._durationInMonths * 31;
			}
			return true;
		}

		public abstract Sprite GetEventIcon();

		public abstract string GetDescription();

		public string GetDateString()
		{
			return $"{GameDate.GetMonthShortNameUppercase(Date.Month)} {StringUtils.FormatNumericDay(Date.Day)}";
		}

		public string GetIconTooltip()
		{
			if (_config != null && !_config._iconTooltip.IsNull())
			{
				return _config._iconTooltip.Translation;
			}
			return string.Empty;
		}
	}
}
