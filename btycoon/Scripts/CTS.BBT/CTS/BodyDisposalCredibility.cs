using System;
using CTS.Core;

namespace CTS
{
	public class BodyDisposalCredibility : CTSBehaviour
	{
		public const int MaxCredibility = 100;

		public const int MinCredibility = 1;

		public int Credibility { get; private set; }

		public event Action CredibilityChanged;

		public static event Action AnyCredibilityChanged;

		public void SetCredibility(int credibility)
		{
			credibility = Math.Clamp(credibility, 1, 100);
			if (credibility != Credibility)
			{
				Credibility = credibility;
				this.CredibilityChanged?.Invoke();
				BodyDisposalCredibility.AnyCredibilityChanged?.Invoke();
			}
		}
	}
}
