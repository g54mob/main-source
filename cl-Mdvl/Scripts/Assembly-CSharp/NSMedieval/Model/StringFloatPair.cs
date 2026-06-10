using System;
using UnityEngine;

namespace NSMedieval.Model
{
	[Serializable]
	public struct StringFloatPair
	{
		[SerializeField]
		private string key;

		[SerializeField]
		private float value;

		public string Key => key;

		public float Value => value;

		public StringFloatPair(string key, float value)
		{
			this.key = key;
			this.value = value;
		}
	}
}
