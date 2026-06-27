using System;

namespace Rewired
{
	public sealed class ControllerAssignmentChangedEventArgs : EventArgs
	{
		private bool reXMGsxTjpXMwatAnZiWzCnbDybu;

		private int CHTGoHbZXMdvxuVjgkArAupYwIGTA;

		private int jKkzcFXBRXGZTJhDmbOBkwdbVevHA;

		private ControllerType WEkFXMEosXdrnAhDvOeiAYbQRGfGA;

		public bool state => reXMGsxTjpXMwatAnZiWzCnbDybu;

		public Controller controller
		{
			get
			{
				if (!ReInput.isReady)
				{
					return null;
				}
				return ReInput.controllers.GetController(WEkFXMEosXdrnAhDvOeiAYbQRGfGA, jKkzcFXBRXGZTJhDmbOBkwdbVevHA);
			}
		}

		public Player player
		{
			get
			{
				if (!ReInput.isReady)
				{
					return null;
				}
				return ReInput.players.GetPlayer(CHTGoHbZXMdvxuVjgkArAupYwIGTA);
			}
		}

		internal ControllerAssignmentChangedEventArgs(int P_0, int P_1, ControllerType P_2, bool P_3)
		{
			reXMGsxTjpXMwatAnZiWzCnbDybu = P_3;
			CHTGoHbZXMdvxuVjgkArAupYwIGTA = P_0;
			jKkzcFXBRXGZTJhDmbOBkwdbVevHA = P_1;
			WEkFXMEosXdrnAhDvOeiAYbQRGfGA = P_2;
		}
	}
}
