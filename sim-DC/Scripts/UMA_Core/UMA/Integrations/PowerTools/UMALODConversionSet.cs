using System;
using UnityEngine;

namespace UMA.Integrations.PowerTools
{
	[Serializable]
	public class UMALODConversionSet : ScriptableObject
	{
		public UMALODConversionEntry[] Conversions;
	}
}
