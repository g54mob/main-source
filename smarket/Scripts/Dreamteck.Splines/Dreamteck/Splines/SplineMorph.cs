using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Dreamteck.Splines
{
	[AddComponentMenu("Dreamteck/Splines/Morph")]
	public class SplineMorph : MonoBehaviour
	{
		public enum CycleMode
		{
			Default = 0,
			Loop = 1,
			PingPong = 2
		}

		public enum UpdateMode
		{
			Update = 0,
			FixedUpdate = 1,
			LateUpdate = 2
		}

		[Serializable]
		public class Channel
		{
			public enum Interpolation
			{
				Linear = 0,
				Spherical = 1
			}

			[SerializeField]
			internal SplinePoint[] points;

			[SerializeField]
			internal float percent;

			public string name;

			public AnimationCurve curve;

			public Interpolation interpolation;
		}

		[HideInInspector]
		public SplineComputer.Space space;

		[HideInInspector]
		public bool cycle;

		[HideInInspector]
		public CycleMode cycleMode;

		[HideInInspector]
		public UpdateMode cycleUpdateMode;

		[HideInInspector]
		public float cycleDuration;

		[SerializeField]
		[HideInInspector]
		private SplineComputer _spline;

		private SplinePoint[] points;

		private float cycleValue;

		private short cycleDirection;

		[HideInInspector]
		[SerializeField]
		[FormerlySerializedAs("morphStates")]
		private Channel[] channels;

		public SplineComputer spline
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		private void Reset()
		{
		}

		private void Update()
		{
		}

		private void FixedUpdate()
		{
		}

		private void LateUpdate()
		{
		}

		private void RunUpdate()
		{
		}

		public void SetCycle(float value)
		{
		}

		public void SetWeight(int index, float weight)
		{
		}

		public void SetWeight(string name, float weight)
		{
		}

		public void SetWeight(float percent, bool loop = false)
		{
		}

		public void CaptureSnapshot(string name)
		{
		}

		public void CaptureSnapshot(int index)
		{
		}

		public void Clear()
		{
		}

		public SplinePoint[] GetSnapshot(int index)
		{
			return null;
		}

		public void SetSnapshot(int index, SplinePoint[] points)
		{
		}

		public SplinePoint[] GetSnapshot(string name)
		{
			return null;
		}

		public float GetWeight(int index)
		{
			return 0f;
		}

		public float GetWeight(string name)
		{
			return 0f;
		}

		public void AddChannel(string name)
		{
		}

		public void RemoveChannel(string name)
		{
		}

		public void RemoveChannel(int index)
		{
		}

		private int GetChannelIndex(string name)
		{
			return 0;
		}

		public int GetChannelCount()
		{
			return 0;
		}

		public Channel GetChannel(int index)
		{
			return null;
		}

		public Channel GetChannel(string name)
		{
			return null;
		}

		public void UpdateMorph()
		{
		}
	}
}
