using System;
using UnityEngine;
using UnityEngine.UI;

namespace SpaceGraphicsToolkit
{
	[ExecuteInEditMode]
	public class SgtFloatingSpeedometer : SgtLinkedBehaviour<SgtFloatingSpeedometer>
	{
		public SgtFloatingPoint Point;

		public Text Title;

		[NonSerialized]
		private SgtFloatingObject cachedObject;

		[NonSerialized]
		private SgtPosition expectedPosition;

		[NonSerialized]
		private bool expectedPositionSet;

		protected virtual void Update()
		{
		}
	}
}
