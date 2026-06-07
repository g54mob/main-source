using System;
using UnityEngine;

namespace PajamaLlama
{
	[CreateAssetMenu(fileName = "Color Palletes", menuName = "PajamaLlama/Utilities/Color Pallets")]
	public class ColorPalletes : ScriptableObject
	{
		[Serializable]
		public struct Pallete
		{
			public string Name;

			public Color[] Colors;
		}

		[SerializeField]
		private Pallete[] _palletes;

		public Pallete[] Palletes => _palletes;
	}
}
