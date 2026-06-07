using System;
using UnityEngine;

namespace Rewired.Data.Mapping
{
	public abstract class HardwareControllerTemplateMap : ScriptableObject
	{
		internal struct byvytSemFeFKFEMsWeUwDcEJnxtsA
		{
			public int CqTmmupZoILJJWmnuPqhCQNfpfRt;

			public int aRDDcbvMGUVmqRZTrMtDGkFbwVmD;

			public int wFslXZcLONbhQOPqNQSMuPAUPBzD;

			public bool alaofQOBBmGCkqnSmFiJlcwVBlkbA;
		}

		public abstract Guid Guid { get; }

		public abstract string Key { get; }

		[CustomObfuscation(rename = false)]
		public abstract ControllerTemplateElementIdentifier GetElementIdentifier(int id);

		[CustomObfuscation(rename = false)]
		public abstract bool ContainsElementIdentifier(int id);
	}
}
