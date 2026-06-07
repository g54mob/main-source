using System;
using Brewery.Minigames;
using UnityEngine;

namespace Brewery.Controls3D
{
	[Serializable]
	public struct ArrowSnapPoint
	{
		[Tooltip("Local rotation angle (degrees) for this snap position.")]
		public float angle;

		[Tooltip("Which exit gate this angle points to.")]
		public SortDirection direction;
	}
}
