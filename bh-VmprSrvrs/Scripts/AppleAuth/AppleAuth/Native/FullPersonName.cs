using System;
using AppleAuth.Interfaces;

namespace AppleAuth.Native
{
	[Serializable]
	internal class FullPersonName : PersonName, IPersonName
	{
		public bool _hasPhoneticRepresentation;

		public PersonName _phoneticRepresentation;

		public new IPersonName PhoneticRepresentation => null;

		public override void OnAfterDeserialize()
		{
		}
	}
}
