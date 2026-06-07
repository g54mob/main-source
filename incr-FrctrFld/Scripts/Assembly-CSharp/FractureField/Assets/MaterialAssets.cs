using System;
using UnityEngine;

namespace FractureField.Assets
{
	[Serializable]
	public class MaterialAssets
	{
		[SerializeField]
		private Material _grayscale;

		[SerializeField]
		private Material _spriteDefault;

		[SerializeField]
		private Material _buttonClick;

		[SerializeField]
		private Material _spriteNoOverride;

		[SerializeField]
		private Material _uiNoOverride;

		[SerializeField]
		private Material _transparentOverlay;

		[SerializeField]
		private Material _darkOverlay;

		public static Material Grayscale => null;

		public static Material SpriteDefault => null;

		public static Material ButtonClick => null;

		public static Material SpriteNoOverride => null;

		public static Material UINoOverride => null;

		public static Material TransparentOverlay => null;

		public static Material DarkOverlay => null;
	}
}
