using UnityEngine;

namespace MG_BlocksEngine2.Core
{
	public class BE2_MainEventsManager : MonoBehaviour
	{
		private static BE2_EventsManager _instance;

		public static BE2_EventsManager Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new BE2_EventsManager();
				}
				return _instance;
			}
		}

		private void Init()
		{
			if (_instance == null)
			{
				_instance = new BE2_EventsManager();
			}
		}

		private void Awake()
		{
			Init();
		}
	}
}
