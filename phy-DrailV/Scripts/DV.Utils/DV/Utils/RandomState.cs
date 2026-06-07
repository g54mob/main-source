using System;

namespace DV.Utils
{
	public struct RandomState
	{
		public readonly byte[] State;

		public RandomState(byte[] state)
		{
			State = state;
		}

		public RandomState(string b64)
		{
			State = Convert.FromBase64String(b64);
		}

		public string ToBase64()
		{
			return Convert.ToBase64String(State);
		}
	}
}
