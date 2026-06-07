using System;
using System.Collections.Generic;
using Rewired.Utils.Attributes;
using UnityEngine;

namespace Rewired.ControllerExtensions
{
	[Serializable]
	[Preserve]
	public struct DualSenseTriggerEffectPositionValueSet
	{
		public const int Count = 10;

		[SerializeField]
		private byte _position0;

		[SerializeField]
		private byte _position1;

		[SerializeField]
		private byte _position2;

		[SerializeField]
		private byte _position3;

		[SerializeField]
		private byte _position4;

		[SerializeField]
		private byte _position5;

		[SerializeField]
		private byte _position6;

		[SerializeField]
		private byte _position7;

		[SerializeField]
		private byte _position8;

		[SerializeField]
		private byte _position9;

		public byte this[int index]
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public DualSenseTriggerEffectPositionValueSet(IList<byte> P_0)
		{
			_position0 = 0;
			_position1 = 0;
			_position2 = 0;
			_position3 = 0;
			_position4 = 0;
			_position5 = 0;
			_position6 = 0;
			_position7 = 0;
			_position8 = 0;
			_position9 = 0;
		}

		public byte[] ToArray()
		{
			return null;
		}

		public void CopyTo(byte[] destination)
		{
		}

		internal void kNqfudiGnPATxtgbALgdCGjIGpYTb(byte P_0, byte P_1)
		{
		}
	}
}
