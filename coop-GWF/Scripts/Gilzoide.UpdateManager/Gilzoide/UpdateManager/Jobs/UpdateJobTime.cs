using Unity.Burst;
using UnityEngine;

namespace Gilzoide.UpdateManager.Jobs
{
	public struct UpdateJobTime
	{
		internal static readonly SharedStatic<UpdateJobTime> SharedInstance = SharedStatic<UpdateJobTime>.GetOrCreateUnsafe(0u, 8184075581652636220L, 0L);

		public static float time => InstanceRef.Time;

		public static float deltaTime => InstanceRef.DeltaTime;

		public static float smoothDeltaTime => InstanceRef.SmoothDeltaTime;

		public static float unscaledDeltaTime => InstanceRef.UnscaledDeltaTime;

		public static float realtimeSinceStartup => InstanceRef.RealtimeSinceStartup;

		public static float timeSinceLevelLoad => InstanceRef.TimeSinceLevelLoad;

		public static int frameCount => InstanceRef.FrameCount;

		public float Time { get; private set; }

		public float DeltaTime { get; private set; }

		public float SmoothDeltaTime { get; private set; }

		public float UnscaledDeltaTime { get; private set; }

		public float RealtimeSinceStartup { get; private set; }

		public float TimeSinceLevelLoad { get; private set; }

		public int FrameCount { get; private set; }

		public static UpdateJobTime Instance => InstanceRef;

		internal static ref UpdateJobTime InstanceRef => ref SharedInstance.Data;

		internal void Refresh()
		{
			Time = UnityEngine.Time.time;
			DeltaTime = UnityEngine.Time.deltaTime;
			SmoothDeltaTime = UnityEngine.Time.smoothDeltaTime;
			UnscaledDeltaTime = UnityEngine.Time.unscaledDeltaTime;
			RealtimeSinceStartup = UnityEngine.Time.realtimeSinceStartup;
			TimeSinceLevelLoad = UnityEngine.Time.timeSinceLevelLoad;
			FrameCount = UnityEngine.Time.frameCount;
		}
	}
}
