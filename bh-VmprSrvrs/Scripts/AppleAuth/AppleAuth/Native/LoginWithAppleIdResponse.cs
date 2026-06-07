using System;
using AppleAuth.Interfaces;
using UnityEngine;

namespace AppleAuth.Native
{
	[Serializable]
	internal class LoginWithAppleIdResponse : ILoginWithAppleIdResponse, ISerializationCallbackReceiver
	{
		public bool _success;

		public bool _hasAppleIdCredential;

		public bool _hasPasswordCredential;

		public bool _hasError;

		public AppleIDCredential _appleIdCredential;

		public PasswordCredential _passwordCredential;

		public AppleError _error;

		public bool Success => false;

		public IAppleError Error => null;

		public IAppleIDCredential AppleIDCredential => null;

		public IPasswordCredential PasswordCredential => null;

		public void OnBeforeSerialize()
		{
		}

		public void OnAfterDeserialize()
		{
		}
	}
}
