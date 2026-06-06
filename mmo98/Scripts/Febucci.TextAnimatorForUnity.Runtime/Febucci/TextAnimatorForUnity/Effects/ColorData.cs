using System;
using Febucci.TextAnimatorCore.BuiltIn;
using UnityEngine;

namespace Febucci.TextAnimatorForUnity.Effects
{
	[Serializable]
	internal class ColorData
	{
		public Febucci.TextAnimatorCore.BuiltIn.ColorMode mode;

		public Color color = new Color(1f, 0f, 0f, 1f);
	}
}
