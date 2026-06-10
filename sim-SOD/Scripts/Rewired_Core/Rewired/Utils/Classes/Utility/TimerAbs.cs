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
		private double cRntfIPGqFLCEUzmUqPwCQylFQD;

		public double length;

		public TimerAbs()
		{
		}

		public TimerAbs(double inLength)
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
