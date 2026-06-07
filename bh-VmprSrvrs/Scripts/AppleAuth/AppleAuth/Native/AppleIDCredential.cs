using System;
using AppleAuth.Enums;
using AppleAuth.Interfaces;
using UnityEngine;

namespace AppleAuth.Native
{
	[Serializable]
	internal class AppleIDCredential : IAppleIDCredential, ICredential, ISerializationCallbackReceiver
	{
		public string _base64IdentityToken;

		public string _base64AuthorizationCode;

		public string _state;

		public string _user;

		public string[] _authorizedScopes;

		public bool _hasFullName;

		public FullPersonName _fullName;

		public string _email;

		public int _realUserStatus;

		private byte[] _identityToken;

		private byte[] _authorizationCode;

		public byte[] IdentityToken => null;

		public byte[] AuthorizationCode => null;

		public string State => null;

		public string User => null;

		public string[] AuthorizedScopes => null;

		public IPersonName FullName => null;

		public string Email => null;

		public RealUserStatus RealUserStatus => default(RealUserStatus);

		public void OnBeforeSerialize()
		{
		}

		public void OnAfterDeserialize()
		{
		}
	}
}
