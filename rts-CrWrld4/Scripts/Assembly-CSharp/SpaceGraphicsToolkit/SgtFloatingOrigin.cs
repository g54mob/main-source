using System;
using UnityEngine;

namespace SpaceGraphicsToolkit
{
	[ExecuteInEditMode]
	public class SgtFloatingOrigin : SgtLinkedBehaviour<SgtFloatingOrigin>
	{
		public static bool currentPointSet;

		public static SgtFloatingPoint currentPoint;

		[NonSerialized]
		private SgtFloatingPoint cachedPoint;

		public static SgtFloatingPoint CurrentPoint => null;

		public static void Create()
		{
		}

		protected override void OnEnable()
		{
		}

		protected override void OnDisable()
		{
		}
	}
}
