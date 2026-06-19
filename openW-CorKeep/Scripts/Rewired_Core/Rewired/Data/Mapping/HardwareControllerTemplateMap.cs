using System;
using UnityEngine;

namespace Rewired.Data.Mapping
{
	public abstract class HardwareControllerTemplateMap : ScriptableObject
	{
		internal struct ovLXoyvOyAIvHyJVxtrGqFYCplsV
		{
			public int FQOSDpPXXnNWZLBRQeHUYkfMPKzJ;

			public int bYpzkMPSFPGymboibgiFAaddbFyZ;

			public int cFDyVzugujGkRDPPmMOAGANpygzsA;

			public bool yKFMkklFGCzKqCZHbbGAdkukBlog;
		}

		public abstract Guid Guid { get; }

		public abstract string Key { get; }

		[CustomObfuscation(rename = false)]
		public abstract ControllerTemplateElementIdentifier GetElementIdentifier(int id);

		[CustomObfuscation(rename = false)]
		public abstract bool ContainsElementIdentifier(int id);
	}
}
