using System;
using UnityEngine;

namespace Restory.Data.PC
{
	[Serializable]
	public class ConnectionSettings
	{
		[Header("Output")]
		[SerializeField]
		[Range(10f, 200f)]
		[Tooltip("Amount of symbols outputted every second.")]
		private float outputSymbolsPerSecond = 30f;

		public float OutputSymbolsPerSecond => outputSymbolsPerSecond;
	}
}
