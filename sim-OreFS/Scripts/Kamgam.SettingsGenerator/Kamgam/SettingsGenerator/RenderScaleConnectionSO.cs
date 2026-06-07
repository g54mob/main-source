using UnityEngine;

namespace Kamgam.SettingsGenerator
{
	[CreateAssetMenu(fileName = "RenderScaleConnection", menuName = "SettingsGenerator/Connection/RenderScaleConnection", order = 4)]
	public class RenderScaleConnectionSO : FloatConnectionSO
	{
		public bool ReapplyOnQualityChange;

		public float DefaultRenderScale = 1f;

		protected RenderScaleConnection _connection;

		public override IConnection<float> GetConnection()
		{
			if (_connection == null)
			{
				Create();
			}
			return _connection;
		}

		public void Create()
		{
			_connection = new RenderScaleConnection();
			_connection.ReapplyOnQualityChange = ReapplyOnQualityChange;
			_connection.DefaultRenderScale = DefaultRenderScale;
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
