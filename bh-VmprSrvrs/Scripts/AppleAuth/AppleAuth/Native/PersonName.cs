using System;
using AppleAuth.Interfaces;
using UnityEngine;

namespace AppleAuth.Native
{
	[Serializable]
	internal class PersonName : IPersonName, ISerializationCallbackReceiver
	{
		public string _namePrefix;

		public string _givenName;

		public string _middleName;

		public string _familyName;

		public string _nameSuffix;

		public string _nickname;

		public string NamePrefix => null;

		public string GivenName => null;

		public string MiddleName => null;

		public string FamilyName => null;

		public string NameSuffix => null;

		public string Nickname => null;

		public IPersonName PhoneticRepresentation => null;

		public void OnBeforeSerialize()
		{
		}

		public virtual void OnAfterDeserialize()
		{
		}
	}
}
