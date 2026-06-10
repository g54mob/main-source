using System;
using UnityEngine;

namespace NSMedieval.Managers
{
	[Serializable]
	public struct WebLink
	{
		[SerializeField]
		public string linkKey;

		[SerializeField]
		public string linkURL;
	}
}
