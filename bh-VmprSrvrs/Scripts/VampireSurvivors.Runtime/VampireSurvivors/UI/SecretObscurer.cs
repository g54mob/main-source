using System.Collections.Generic;

namespace VampireSurvivors.UI
{
	internal class SecretObscurer
	{
		private bool _shouldObscure;

		private readonly Dictionary<Secret, string> _secrets;

		public void Toggle()
		{
		}

		public void AddSecret(Secret key, string plaintext)
		{
		}

		public string Get(Secret key)
		{
			return null;
		}

		private string GetPlaintext(Secret key)
		{
			return null;
		}

		private string GetObscured(Secret key)
		{
			return null;
		}
	}
}
