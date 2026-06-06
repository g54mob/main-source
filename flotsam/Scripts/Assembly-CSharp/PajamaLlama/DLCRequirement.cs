using System;
using M4.Session;
using UnityEngine;

namespace PajamaLlama
{
	[Serializable]
	public class DLCRequirement : IPlatformRequirement
	{
		[SerializeField]
		private PlatformId _platformId;

		public bool IsMet()
		{
			return Session.Profile.OwnsDLC(_platformId);
		}
	}
}
