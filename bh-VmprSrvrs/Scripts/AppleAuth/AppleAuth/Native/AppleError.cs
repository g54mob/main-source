using System;
using AppleAuth.Interfaces;
using UnityEngine;

namespace AppleAuth.Native
{
	[Serializable]
	internal class AppleError : IAppleError, ISerializationCallbackReceiver
	{
		public int _code;

		public string _domain;

		public string _localizedDescription;

		public string[] _localizedRecoveryOptions;

		public string _localizedRecoverySuggestion;

		public string _localizedFailureReason;

		public int Code => 0;

		public string Domain => null;

		public string LocalizedDescription => null;

		public string[] LocalizedRecoveryOptions => null;

		public string LocalizedRecoverySuggestion => null;

		public string LocalizedFailureReason => null;

		public void OnBeforeSerialize()
		{
		}

		public void OnAfterDeserialize()
		{
		}
	}
}
