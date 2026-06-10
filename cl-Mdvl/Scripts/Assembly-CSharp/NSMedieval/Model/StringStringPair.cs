using System;
using NSEipix.Base;
using UnityEngine;

namespace NSMedieval.Model
{
	[Serializable]
	public class StringStringPair : NSEipix.Base.Model
	{
		[SerializeField]
		private string key;

		[SerializeField]
		private string value;

		public string Key => key;

		public string Value => value;

		public StringStringPair(string key, string value)
		{
			this.key = key;
			this.value = value;
		}

		public override string GetID()
		{
			return key ?? string.Empty;
		}
	}
}
