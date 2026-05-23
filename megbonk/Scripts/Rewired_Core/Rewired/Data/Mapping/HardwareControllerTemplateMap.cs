using System;
using UnityEngine;

namespace Rewired.Data.Mapping
{
	public abstract class HardwareControllerTemplateMap : ScriptableObject
	{
		internal struct jKiaMLFrsZtqsedKIgXIoKaJmIXiA
		{
			public int IJniqAPeViBQwMvYpeOMeNDDjyKDA;

			public int eRMBIhaRZSpvVurrQCKDeoToYeBaA;

			public int dJyCtEJcqqfhoQAUDUmIwkbuxHWsA;

			public bool fBccWLdXkLgXRZWCIPKIXOnrqrTD;
		}

		public abstract Guid Guid { get; }

		public abstract string Key { get; }

		[CustomObfuscation(rename = false)]
		public abstract ControllerTemplateElementIdentifier GetElementIdentifier(int id);

		[CustomObfuscation(rename = false)]
		public abstract bool ContainsElementIdentifier(int id);
	}
}
