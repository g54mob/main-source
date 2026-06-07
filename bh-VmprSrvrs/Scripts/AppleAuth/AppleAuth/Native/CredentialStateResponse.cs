using System;
using AppleAuth.Enums;
using AppleAuth.Interfaces;
using UnityEngine;

namespace AppleAuth.Native
{
	[Serializable]
	internal class CredentialStateResponse : ICredentialStateResponse, ISerializationCallbackReceiver
	{
		public bool _success;

		public bool _hasCredentialState;

		public bool _hasError;

		public int _credentialState;

		public AppleError _error;

		public bool Success => false;

		public CredentialState CredentialState => default(CredentialState);

		public IAppleError Error => null;

		public void OnBeforeSerialize()
		{
		}

		public void OnAfterDeserialize()
		{
		}
	}
}
