using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace VampireSurvivors.UI;

internal class SecretObscurer
{
	private bool _shouldObscure = true;

	private readonly Dictionary<Secret, string> _secrets;

	public void Toggle()
	{
		bool shouldObscure = !_shouldObscure;
		_shouldObscure = shouldObscure;
	}

	public void AddSecret(Secret key, string plaintext)
	{
		int num = ((Dictionary<System.Int32Enum, object>)(object)_secrets).FindEntry((System.Int32Enum)key);
		System.Collections.Generic.InsertionBehavior behavior = ((num >= 0) ? System.Collections.Generic.InsertionBehavior.OverwriteExisting : System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		bool flag = ((Dictionary<System.Int32Enum, object>)(object)_secrets).TryInsert((System.Int32Enum)key, (object)plaintext, behavior);
	}

	public string Get(Secret key)
	{
		if (_shouldObscure)
		{
			if (_secrets != null)
			{
				object input = ((Dictionary<System.Int32Enum, object>)(object)_secrets).get_Item((System.Int32Enum)key);
				return Regex.Replace((string)input, ".", "*");
			}
		}
		else if (_secrets != null)
		{
			return (string)((Dictionary<System.Int32Enum, object>)(object)_secrets).get_Item((System.Int32Enum)key);
		}
		return (string)(object)new NullReferenceException();
	}

	private string GetPlaintext(Secret key)
	{
		if (_secrets != null)
		{
			return (string)((Dictionary<System.Int32Enum, object>)(object)_secrets).get_Item((System.Int32Enum)key);
		}
		return (string)(object)new NullReferenceException();
	}

	private string GetObscured(Secret key)
	{
		if (_secrets != null)
		{
			object input = ((Dictionary<System.Int32Enum, object>)(object)_secrets).get_Item((System.Int32Enum)key);
			return Regex.Replace((string)input, ".", "*");
		}
		return (string)(object)new NullReferenceException();
	}

	public SecretObscurer()
	{
		Dictionary<Secret, string> secrets = new Dictionary<Secret, string>();
		_secrets = secrets;
	}
}
