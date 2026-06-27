using UnityEngine;

namespace Alekrus.UnivarsalPlatform.EOS
{
	public class EOS_Params : ScriptableObject
	{
		private static EOS_Params _instance;

		[SerializeField]
		private LoginType _loginType = LoginType.Developer;

		[SerializeField]
		private bool _allowLoginAccountPortal;

		[SerializeField]
		private string _devHost = "localhost:7777";

		[SerializeField]
		private string _devUserName = string.Empty;

		public static EOS_Params Instance
		{
			get
			{
				if (_instance != null)
				{
					return _instance;
				}
				_instance = LoadOrCreateParams();
				return _instance;
			}
		}

		public LoginType LoginType => _loginType;

		public bool AllowLoginAccountPortal => _allowLoginAccountPortal;

		public string DevHost => _devHost;

		public string DevUserName => _devUserName;

		public void ResetParams()
		{
			_loginType = LoginType.Developer;
			_allowLoginAccountPortal = false;
			_devHost = "localhost:7777";
			_devUserName = string.Empty;
		}

		private static string GetNameAsset()
		{
			return typeof(EOS_Params).Name;
		}

		private static EOS_Params LoadOrCreateParams()
		{
			EOS_Params eOS_Params = Resources.Load<EOS_Params>("Alekrus/UnivarsalPlatform/EOS/" + GetNameAsset());
			if (eOS_Params != null)
			{
				return eOS_Params;
			}
			return ScriptableObject.CreateInstance<EOS_Params>();
		}
	}
}
