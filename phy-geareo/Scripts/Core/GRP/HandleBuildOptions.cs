using System;
using Rhizomatic.Reactive;
using UnityEngine;

namespace GRP
{
	public class HandleBuildOptions
	{
		public Part part;

		public bool usePosition;

		public Func<float> getValue;

		public Action<float> setValue;

		public Func<Vector3> getPosition;

		public Action<Vector3> setPosition;

		public Func<Vector3> getDirection;

		public Func<string> getGuideText;

		public bool gridless;

		public float min;

		public float max;

		public float baseSnap;

		public bool angular;

		public float snapMultiplier;

		public float distanceMultiplier;

		public Action<HandleBuildContext> clamp;

		public static HandleBuildOptions FromPartPosition(Part part, State<float> state, Vector3 direction, float min = -1f, float max = -1f, Action<HandleBuildContext> clamp = null)
		{
			return null;
		}

		public static HandleBuildOptions FromPartRadius(Part part, State<float> state, float min = -1f, float max = -1f, Action<HandleBuildContext> clamp = null)
		{
			return null;
		}
	}
}
