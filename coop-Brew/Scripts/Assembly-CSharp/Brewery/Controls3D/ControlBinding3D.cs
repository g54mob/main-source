using System;
using UnityEngine;

namespace Brewery.Controls3D
{
	[Serializable]
	public class ControlBinding3D
	{
		[Tooltip("Index in the preset's controlDefs[] array (0-based)")]
		public int controlIndex;

		[Header("Assign exactly one")]
		public Slider3D slider;

		public Toggle3D toggle;

		public Button3D button;

		public Dial3D dial;
	}
}
