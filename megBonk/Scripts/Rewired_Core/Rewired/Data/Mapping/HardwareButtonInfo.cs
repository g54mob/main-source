using System;
using Rewired.Utils.Interfaces;
using UnityEngine;

namespace Rewired.Data.Mapping
{
	[Serializable]
	public class HardwareButtonInfo : IDeepCloneable
	{
		[SerializeField]
		internal bool _excludeFromPolling;

		[SerializeField]
		internal bool _isPressureSensitive;

		public bool excludeFromPolling => false;

		public bool isPressureSensitive => false;

		public HardwareButtonInfo()
		{
		}

		[CustomObfuscation(rename = false)]
		internal HardwareButtonInfo(bool P_0, bool P_1)
		{
		}

		public object DeepClone()
		{
			return null;
		}
	}
}
