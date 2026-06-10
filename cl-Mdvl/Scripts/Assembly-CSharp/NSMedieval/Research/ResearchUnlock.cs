using System;
using UnityEngine;

namespace NSMedieval.Research
{
	[Serializable]
	public class ResearchUnlock
	{
		[SerializeField]
		private string unlockId;

		[SerializeField]
		private bool hideInUi;

		public string UnlockId => unlockId;

		public bool HideInUi => hideInUi;
	}
}
