using System;
using UnityEngine;

namespace HQFPSTemplate.UserInterface
{
	[Serializable]
	public struct UI_SpringForce
	{
		public Vector2 Force;

		[Range(1f, 20f)]
		public int Distribution;

		public UI_SpringForce(Vector2 force, int distribution)
		{
			Force = force;
			Distribution = Mathf.Max(distribution, 1);
		}
	}
}
