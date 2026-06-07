using System;

namespace VampireSurvivors.App.Scripts.Framework.Platforms.Backend.Service
{
	public class ResendVerificationEmailAllowedService
	{
		private readonly string key;

		public bool CanSend()
		{
			return false;
		}

		public void DisableUntil(DateTime dob)
		{
		}
	}
}
