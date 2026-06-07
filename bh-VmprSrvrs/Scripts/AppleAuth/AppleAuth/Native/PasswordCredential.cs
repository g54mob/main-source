using System;
using AppleAuth.Interfaces;
using UnityEngine;

namespace AppleAuth.Native
{
	[Serializable]
	internal class PasswordCredential : IPasswordCredential, ICredential, ISerializationCallbackReceiver
	{
		public string _user;

		public string _password;

		public string User => null;

		public string Password => null;

		public void OnBeforeSerialize()
		{
		}

		public void OnAfterDeserialize()
		{
		}
	}
}
