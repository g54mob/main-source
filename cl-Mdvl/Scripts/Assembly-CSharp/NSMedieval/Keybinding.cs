using System;
using NSMedieval.Enums;
using UnityEngine;

namespace NSMedieval
{
	[Serializable]
	public class Keybinding
	{
		[SerializeField]
		private string group;

		[SerializeField]
		private KeyInputEvent keyInputEvent;

		[SerializeField]
		private KeyCode primaryKey;

		[SerializeField]
		private KeyCode alternativeKey;

		public KeyInputEvent KeyInputEvent => keyInputEvent;

		public KeyCode PrimaryKey => primaryKey;

		public KeyCode AlternativeKey => alternativeKey;

		public string Group => group;

		public Keybinding(KeyInputEvent keyInputEvent, KeyCode primaryKey, KeyCode alternativeKey, string group)
		{
			this.keyInputEvent = keyInputEvent;
			this.primaryKey = primaryKey;
			this.alternativeKey = alternativeKey;
			this.group = group;
		}

		public void SetPrimaryKey(KeyCode key)
		{
			primaryKey = key;
		}

		public void SetAlternativeKey(KeyCode key)
		{
			alternativeKey = key;
		}

		public Keybinding Clone()
		{
			return new Keybinding(keyInputEvent, primaryKey, alternativeKey, group);
		}
	}
}
