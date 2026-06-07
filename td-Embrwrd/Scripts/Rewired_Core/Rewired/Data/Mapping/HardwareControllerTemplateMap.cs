using System;
using UnityEngine;

namespace Rewired.Data.Mapping
{
	public abstract class HardwareControllerTemplateMap : ScriptableObject
	{
		internal struct mplGGTyQiUHloFPOvtXcGcfxCYKC
		{
			public int TSmjkUAjhdDfukmHUXewehBnjwVFA;

			public int hUREdnGbIPWbLEHqdgNpkHFAeIAI;

			public int kadzIAlALhAIsaPzuCKwcfzKXPXc;

			public bool yonycNmKdKNNJdjJxWfyDkABzcQU;
		}

		public abstract Guid Guid { get; }

		public abstract string Key { get; }

		[CustomObfuscation(rename = false)]
		public abstract ControllerTemplateElementIdentifier GetElementIdentifier(int id);

		[CustomObfuscation(rename = false)]
		public abstract bool ContainsElementIdentifier(int id);
	}
}
