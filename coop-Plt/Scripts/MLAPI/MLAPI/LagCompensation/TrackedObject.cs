using System.Collections.Generic;
using MLAPI.Collections;
using UnityEngine;

namespace MLAPI.LagCompensation
{
	[AddComponentMenu("MLAPI/TrackedObject", -98)]
	public class TrackedObject : MonoBehaviour
	{
		internal Dictionary<float, TrackedPointData> FrameData = new Dictionary<float, TrackedPointData>();

		internal FixedQueue<float> Framekeys;

		private Vector3 savedPosition;

		private Quaternion savedRotation;

		public int TotalPoints
		{
			get
			{
				if (Framekeys == null)
				{
					return 0;
				}
				return Framekeys.Count;
			}
		}

		public float AvgTimeBetweenPointsMs
		{
			get
			{
				if (Framekeys == null || Framekeys.Count == 0)
				{
					return 0f;
				}
				return (Framekeys.ElementAt(Framekeys.Count - 1) - Framekeys.ElementAt(0)) / (float)Framekeys.Count * 1000f;
			}
		}

		public float TotalTimeHistory
		{
			get
			{
				if (Framekeys == null)
				{
					return 0f;
				}
				return Framekeys.ElementAt(Framekeys.Count - 1) - Framekeys.ElementAt(0);
			}
		}

		private int maxPoints => (int)((float)NetworkingManager.Singleton.NetworkConfig.SecondsHistory / (1f / (float)NetworkingManager.Singleton.NetworkConfig.EventTickrate));

		internal void ReverseTransform(float secondsAgo)
		{
			savedPosition = base.transform.position;
			savedRotation = base.transform.rotation;
			float networkTime = NetworkingManager.Singleton.NetworkTime;
			float num = networkTime - secondsAgo;
			float num2 = 0f;
			float num3 = 0f;
			for (int i = 0; i < Framekeys.Count; i++)
			{
				if (num2 <= num && Framekeys.ElementAt(i) >= num)
				{
					num3 = Framekeys.ElementAt(i);
					break;
				}
				num2 = Framekeys.ElementAt(i);
			}
			float num4 = num3 - num2;
			float num5 = networkTime - num2;
			float t = num5 / num4;
			base.transform.position = Vector3.Lerp(FrameData[num2].position, FrameData[num3].position, t);
			base.transform.rotation = Quaternion.Slerp(FrameData[num2].rotation, FrameData[num3].rotation, t);
		}

		internal void ResetStateTransform()
		{
			base.transform.position = savedPosition;
			base.transform.rotation = savedRotation;
		}

		private void Start()
		{
			Framekeys = new FixedQueue<float>(maxPoints);
			Framekeys.Enqueue(0f);
			LagCompensationManager.SimulationObjects.Add(this);
		}

		private void OnDestroy()
		{
			LagCompensationManager.SimulationObjects.Remove(this);
		}

		internal void AddFrame()
		{
			if (Framekeys.Count == maxPoints)
			{
				FrameData.Remove(Framekeys.Dequeue());
			}
			FrameData.Add(NetworkingManager.Singleton.NetworkTime, new TrackedPointData
			{
				position = base.transform.position,
				rotation = base.transform.rotation
			});
			Framekeys.Enqueue(NetworkingManager.Singleton.NetworkTime);
		}
	}
}
