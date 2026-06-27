using System;
using UnityEngine;

namespace Restory.Remapping
{
	[Serializable]
	public struct InputButtonData
	{
		public KeyCode keyboardKeyCode;

		public int elementIdentifierId;

		public override bool Equals(object obj)
		{
			if (obj == null || GetType() != obj.GetType())
			{
				return false;
			}
			InputButtonData inputButtonData = (InputButtonData)obj;
			if (keyboardKeyCode == inputButtonData.keyboardKeyCode)
			{
				return elementIdentifierId == inputButtonData.elementIdentifierId;
			}
			return false;
		}

		public override int GetHashCode()
		{
			return keyboardKeyCode.GetHashCode() ^ elementIdentifierId.GetHashCode();
		}

		public override string ToString()
		{
			return $"{keyboardKeyCode},{elementIdentifierId}";
		}

		public static bool operator ==(InputButtonData a, InputButtonData b)
		{
			if (a.keyboardKeyCode == b.keyboardKeyCode)
			{
				return a.elementIdentifierId == b.elementIdentifierId;
			}
			return false;
		}

		public static bool operator !=(InputButtonData a, InputButtonData b)
		{
			if (a.keyboardKeyCode == b.keyboardKeyCode)
			{
				return a.elementIdentifierId != b.elementIdentifierId;
			}
			return true;
		}
	}
}
