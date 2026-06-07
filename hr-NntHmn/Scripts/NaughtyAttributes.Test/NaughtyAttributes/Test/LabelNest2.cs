using System;
using UnityEngine;

namespace NaughtyAttributes.Test
{
	[Serializable]
	public class LabelNest2
	{
		[Label("Label 2")]
		[MinMaxSlider(0f, 1f)]
		public Vector2 vector2;
	}
}
