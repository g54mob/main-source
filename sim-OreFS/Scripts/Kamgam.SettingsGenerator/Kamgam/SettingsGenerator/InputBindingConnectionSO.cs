using UnityEngine;
using UnityEngine.InputSystem;

namespace Kamgam.SettingsGenerator
{
	[CreateAssetMenu(fileName = "InputBindingConnection", menuName = "SettingsGenerator/Connection/InputBindingConnection", order = 4)]
	public class InputBindingConnectionSO : StringConnectionSO
	{
		public InputActionAsset InputActionAsset;

		public string BindingId;

		protected InputBindingConnection _connection;

		public override IConnection<string> GetConnection()
		{
			if (_connection == null)
			{
				Create();
			}
			return _connection;
		}

		public void Create()
		{
			_connection = new InputBindingConnection();
			_connection.SetInputActionAsset(InputActionAsset);
			_connection.SetBindingId(BindingId);
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
