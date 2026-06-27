using System;
using UnityEngine;

namespace Rewired.Data.Mapping
{
	public abstract class HardwareControllerTemplateMap : ScriptableObject
	{
		internal struct bSeoxkAXPAPaGzvxBXEzIEDOfGVn
		{
			public int IXbDKpkworjxGkKfmAYbfacKYqUUb;

			public int ojQcqIwMmLIApwnAFTEyeaehbiPgA;

			public int nbcDRvDAJjDCEKArIlwvEcAhvVWGB;

			public bool xzgpMsWquQjTpZXtZbFzRPnkXcDp;
		}

		public abstract Guid Guid { get; }

		public abstract string Key { get; }

		[CustomObfuscation(rename = false)]
		public abstract ControllerTemplateElementIdentifier GetElementIdentifier(int id);

		[CustomObfuscation(rename = false)]
		public abstract bool ContainsElementIdentifier(int id);
	}
}
