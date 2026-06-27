using System;
using DG.Tweening;
using Mandragora.Utils;
using UnityEngine;

namespace Restory.Utils.UserInterfaceUtils.TweenSequencesUtils.Elements
{
	[Serializable]
	public abstract class TweenSequenceElement
	{
		protected static class SequenceElementStyle
		{
			public const string Time = "Time And Duration Settings";
		}

		[SerializeField]
		[BoolButton(20, 0, Red = false)]
		private bool overrideTimeMeasuringUnit;

		[SerializeField]
		private RealTimeMeasuringUnit timeMeasuringUnitOverride;

		[SerializeField]
		private float duration;

		private RealTimeMeasuringUnit timeMeasuringUnit;

		protected float sequenceElementDuration => (overrideTimeMeasuringUnit ? timeMeasuringUnitOverride : timeMeasuringUnit) switch
		{
			RealTimeMeasuringUnit.Seconds => duration, 
			RealTimeMeasuringUnit.Milliseconds => duration * 0.001f, 
			_ => throw new ArgumentOutOfRangeException(), 
		};

		public abstract Sequence AddToSequence(Sequence sequence);

		public void SetTimeMeasuringUnit(RealTimeMeasuringUnit timeMeasuringUnit)
		{
			this.timeMeasuringUnit = timeMeasuringUnit;
		}
	}
}
