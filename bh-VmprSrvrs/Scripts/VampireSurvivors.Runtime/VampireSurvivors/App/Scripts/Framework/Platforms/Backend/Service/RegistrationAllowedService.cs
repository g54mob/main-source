using System;

namespace VampireSurvivors.App.Scripts.Framework.Platforms.Backend.Service
{
	public class RegistrationAllowedService
	{
		private readonly string key;

		public bool CanRegister()
		{
			return false;
		}

		public void DisableRegistrationUntil(DateTime dob)
		{
		}
	}
}
