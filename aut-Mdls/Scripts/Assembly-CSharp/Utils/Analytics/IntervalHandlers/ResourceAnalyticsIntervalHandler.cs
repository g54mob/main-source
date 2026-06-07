using Data.Variables;
using Events.Analytics;
using UnityEngine;

namespace Utils.Analytics.IntervalHandlers
{
	public class ResourceAnalyticsIntervalHandler : AbstractAnalyticsIntervalHandler
	{
		[SerializeField]
		private IntVariableSO _currentCurrency;

		[SerializeField]
		private AnalyticsDesignEvent _analyticsDesignEvent;

		private int _cachedCurrentCurrency;

		protected override void Initialize()
		{
			CacheValues();
			base.Initialize();
		}

		private void CacheValues()
		{
			_cachedCurrentCurrency = _currentCurrency.Value;
		}

		public override void TrySendAnalytics()
		{
			_analyticsDesignEvent.Fire(("Currency_Balance", _currentCurrency.Value - _cachedCurrentCurrency));
			_cachedCurrentCurrency = _currentCurrency.Value;
		}
	}
}
