using UnityEngine;

namespace Rewired
{
	public struct ControllerPollingInfo
	{
		private bool TSZXbPaFxlfZyHfLqiedBpdWBvxi;

		private int RaKAiTTihElhDTpWAKsQdvaqmEJ;

		private int OAqYXyYxxoyErUWWGBOiLsNcUok;

		private string fPeCHJWqXKSqAmjEuafacIshxPW;

		private ControllerType ODiTVfklXHDoeIfdJEahPbsrzhzs;

		private ControllerElementType DrkpMynFKskCazTIBMExCEDbtdM;

		private int HaIFwVJpONuFeABKLoTBEXiGngk;

		private Pole chbZOrXkuNWoqIMbPNdvPSZlZDo;

		private string PhtdAzyxfOojsYIYgNOGQVuqHbF;

		private int BJqiDuSJeKPbAfDKAGDMBJQFjpkO;

		private KeyCode GJeToslGtRgKfxfJpqXxlgoTqIO;

		public bool success
		{
			get
			{
				return false;
			}
			internal set
			{
			}
		}

		public int playerId
		{
			get
			{
				return 0;
			}
			internal set
			{
			}
		}

		public int controllerId
		{
			get
			{
				return 0;
			}
			internal set
			{
			}
		}

		public string controllerName
		{
			get
			{
				return null;
			}
			internal set
			{
			}
		}

		public ControllerType controllerType
		{
			get
			{
				return default(ControllerType);
			}
			internal set
			{
			}
		}

		public ControllerElementType elementType
		{
			get
			{
				return default(ControllerElementType);
			}
			internal set
			{
			}
		}

		public int elementIndex
		{
			get
			{
				return 0;
			}
			internal set
			{
			}
		}

		public Pole axisPole
		{
			get
			{
				return default(Pole);
			}
			internal set
			{
			}
		}

		public string elementIdentifierName
		{
			get
			{
				return null;
			}
			internal set
			{
			}
		}

		public int elementIdentifierId
		{
			get
			{
				return 0;
			}
			internal set
			{
			}
		}

		public KeyCode keyboardKey
		{
			get
			{
				return default(KeyCode);
			}
			internal set
			{
			}
		}

		public Player player => null;

		public Controller controller => null;

		public ControllerElementIdentifier elementIdentifier => null;

		internal ControllerPollingInfo(bool success, int playerId, int controllerId, string controllerName, ControllerType controllerType, ControllerElementType elementType, int elementIndex, Pole axisPole, string elementIdentifierName, int elementIdentifierId, KeyCode keyboardKey)
		{
			TSZXbPaFxlfZyHfLqiedBpdWBvxi = false;
			RaKAiTTihElhDTpWAKsQdvaqmEJ = 0;
			OAqYXyYxxoyErUWWGBOiLsNcUok = 0;
			fPeCHJWqXKSqAmjEuafacIshxPW = null;
			ODiTVfklXHDoeIfdJEahPbsrzhzs = default(ControllerType);
			DrkpMynFKskCazTIBMExCEDbtdM = default(ControllerElementType);
			HaIFwVJpONuFeABKLoTBEXiGngk = 0;
			chbZOrXkuNWoqIMbPNdvPSZlZDo = default(Pole);
			PhtdAzyxfOojsYIYgNOGQVuqHbF = null;
			BJqiDuSJeKPbAfDKAGDMBJQFjpkO = 0;
			GJeToslGtRgKfxfJpqXxlgoTqIO = default(KeyCode);
		}

		internal ControllerPollingInfo(ControllerPollingInfo source)
		{
			TSZXbPaFxlfZyHfLqiedBpdWBvxi = false;
			RaKAiTTihElhDTpWAKsQdvaqmEJ = 0;
			OAqYXyYxxoyErUWWGBOiLsNcUok = 0;
			fPeCHJWqXKSqAmjEuafacIshxPW = null;
			ODiTVfklXHDoeIfdJEahPbsrzhzs = default(ControllerType);
			DrkpMynFKskCazTIBMExCEDbtdM = default(ControllerElementType);
			HaIFwVJpONuFeABKLoTBEXiGngk = 0;
			chbZOrXkuNWoqIMbPNdvPSZlZDo = default(Pole);
			PhtdAzyxfOojsYIYgNOGQVuqHbF = null;
			BJqiDuSJeKPbAfDKAGDMBJQFjpkO = 0;
			GJeToslGtRgKfxfJpqXxlgoTqIO = default(KeyCode);
		}

		internal static ControllerPollingInfo LvYEAzguQVpkpKhtZqkHuUOWyaNt()
		{
			return default(ControllerPollingInfo);
		}
	}
}
