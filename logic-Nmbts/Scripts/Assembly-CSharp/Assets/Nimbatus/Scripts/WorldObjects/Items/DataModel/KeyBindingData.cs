using System;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.WorldObjects.Items.DataModel
{
	[Serializable]
	public class KeyBindingData
	{
		public string Name { get; set; }

		public KeyCode Key { get; set; }

		public bool HasBeenAssigned { get; set; }

		public string Tag { get; set; }
	}
}
