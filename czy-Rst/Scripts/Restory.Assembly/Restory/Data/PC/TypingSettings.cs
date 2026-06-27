using System;
using UnityEngine;

namespace Restory.Data.PC
{
	[Serializable]
	public class TypingSettings
	{
		[Header("Typing")]
		[SerializeField]
		[Range(1f, 20f)]
		[Tooltip("Amount of symbols outputted for every button click.")]
		private int symbolsPerKeyDown = 4;

		public int SymbolsPerKeyDown => symbolsPerKeyDown;
	}
}
