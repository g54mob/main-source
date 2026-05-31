using System;
using UnityEngine;

namespace CTS.BBT.AI
{
	[Serializable]
	public abstract class GrabData
	{
		[Range(0f, 1f)]
		public float MaxWeight;

		public bool IsRightHand;
	}
}
