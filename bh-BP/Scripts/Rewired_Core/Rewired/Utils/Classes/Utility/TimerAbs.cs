using System;
using UnityEngine;

namespace Rewired.Utils.Classes.Utility
{
	[Serializable]
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal class TimerAbs
	{
		public bool running;

		[SerializeField]
		private double dSrHeiGxySThoueCiXhWfaiUGQui;

		public double length;

		public TimerAbs()
		{
		}

		public TimerAbs(double P_0)
		{
		}

		public void Start()
		{
		}

		public void Start(double inLength)
		{
		}

		public bool Update()
		{
			return false;
		}

		public void Clear()
		{
		}

		public void SetLength(double inLength)
		{
		}

		public TimerAbs Clone()
		{
			return null;
		}
	}
}
