using System;
using M4.Session;

namespace PajamaLlama
{
	[Serializable]
	public class EarlyAccesRequirement : IPlatformRequirement
	{
		public bool IsMet()
		{
			return Session.Profile.IsEarlyAccesOwner();
		}
	}
}
