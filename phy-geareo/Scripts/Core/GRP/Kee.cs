using UnityEngine.InputSystem;

namespace GRP
{
	public class Kee
	{
		public class Game
		{
			private Kee k;

			public bool noSnap => false;

			public bool noSnapRotation => false;

			public bool symmetricalResize => false;

			public bool duplicate => false;

			public bool flip => false;

			public bool delete => false;

			public bool exhibit => false;

			public bool blockCamera => false;

			public Game(Kee kee)
			{
			}
		}

		public static Kee _instance;

		public Game _game;

		public static Kee instance => null;

		public static Game game => null;

		private Keyboard keyboard => null;

		public bool isAlt => false;

		public bool isCtrl => false;

		public bool isShift => false;

		public bool GetKey(Key key)
		{
			return false;
		}

		public bool GetKeyDown(Key key)
		{
			return false;
		}

		public bool GetCtrlKey(Key key)
		{
			return false;
		}

		public bool GetCtrlKeyDown(Key key)
		{
			return false;
		}

		public bool GetMouse()
		{
			return false;
		}
	}
}
