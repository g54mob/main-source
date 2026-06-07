using System;
using UnityEngine;

namespace FSG.MeshAnimator
{
	[Serializable]
	public class MeshAnimationEvent
	{
		public enum Mode : byte
		{
			Data = 0,
			String = 1,
			Float = 2
		}

		public string methodName;

		public int frame;

		public Mode eventType;

		public string stringValue;

		public float floatValue;

		public UnityEngine.Object data;

		public void FireEvent(GameObject eventReciever)
		{
		}
	}
}
