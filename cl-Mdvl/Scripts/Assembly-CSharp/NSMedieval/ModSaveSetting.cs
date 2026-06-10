using System;
using UnityEngine;

namespace NSMedieval
{
	[Serializable]
	public class ModSaveSetting
	{
		[SerializeField]
		private string id;

		[SerializeField]
		private bool enabled;

		public string Id => id;

		public bool Enabled => enabled;

		public ModSaveSetting(string id, bool enabled)
		{
			this.id = id;
			this.enabled = enabled;
		}

		public void SetEnabled(bool enabled)
		{
			this.enabled = enabled;
		}
	}
}
