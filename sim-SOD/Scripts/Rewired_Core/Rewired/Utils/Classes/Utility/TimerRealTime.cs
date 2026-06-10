using System;
using UnityEngine;

namespace Rewired.Utils.Classes.Utility
{
	[Serializable]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal class TimerRealTime
	{
		public bool running;

		[SerializeField]
		private double cRntfIPGqFLCEUzmUqPwCQylFQD;

		public double length;

		public TimerRealTime()
		{
		}

		public TimerRealTime(double inLength)
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
