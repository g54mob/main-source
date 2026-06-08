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

		public bool excludeFromPolling => _excludeFromPolling;

		public bool isPressureSensitive => _isPressureSensitive;

		public HardwareButtonInfo()
		{
			while (true)
			{
				int num = -1401371597;
				while (true)
				{
					switch (num ^ -1401371598)
					{
					case 0:
						break;
					default:
						return;
					case 1:
						goto IL_0024;
					case 2:
						return;
					}
					break;
					IL_0024:
					_excludeFromPolling = false;
					_isPressureSensitive = false;
					num = -1401371600;
				}
			}
		}

		[CustomObfuscation(rename = false)]
		internal HardwareButtonInfo(bool excludeFromPolling, bool isPressureSensitive)
		{
			_excludeFromPolling = excludeFromPolling;
			_isPressureSensitive = isPressureSensitive;
		}

		public object DeepClone()
		{
			return new HardwareButtonInfo(_excludeFromPolling, _isPressureSensitive);
		}
	}
}
