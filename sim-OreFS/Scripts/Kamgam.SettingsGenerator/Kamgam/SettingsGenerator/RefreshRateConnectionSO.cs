using UnityEngine;

namespace Kamgam.SettingsGenerator
{
	[CreateAssetMenu(fileName = "RefreshRateConnection", menuName = "SettingsGenerator/Connection/RefreshRateConnection", order = 4)]
	public class RefreshRateConnectionSO : OptionConnectionSO
	{
		[Tooltip("Disable if the resolutions change very often.")]
		public bool CacheRefreshRates = true;

		[Tooltip("Refresh rate in Hz. Refresh rates below this are ignored. Equal rates are still included.")]
		public int MinRate;

		[Tooltip("Refresh rate in Hz. Refresh rates above this are ignored. Equal rates are still included.")]
		public int MaxRate = 1000;

		[Tooltip("If enabled then only those refresh rates which are usable with the current resolution are listed. That list may be much shorter than the full list (often just one).")]
		public bool LimitToCurrentResolution;

		protected RefreshRateConnection _connection;

		public override IConnectionWithOptions<string> GetConnection()
		{
			if (_connection == null)
			{
				Create();
			}
			return _connection;
		}

		public void Create()
		{
			_connection = new RefreshRateConnection();
			_connection.CacheRefreshRates = CacheRefreshRates;
			_connection.MinRate = MinRate;
			_connection.MaxRate = MaxRate;
			_connection.LimitToCurrentResolution = LimitToCurrentResolution;
		}

		public override void DestroyConnection()
		{
			if (_connection != null)
			{
				_connection.Destroy();
			}
			_connection = null;
		}
	}
}
