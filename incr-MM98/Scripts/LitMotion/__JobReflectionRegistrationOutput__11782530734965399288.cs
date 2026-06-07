using System;
using LitMotion;
using LitMotion.Adapters;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine;

[Unity.Jobs.DOTSCompilerGenerated]
internal class __JobReflectionRegistrationOutput__11782530734965399288
{
	public static void CreateJobReflectionData()
	{
		try
		{
			IJobParallelForExtensions.EarlyJobInit<MotionUpdateJob<FixedString32Bytes, StringOptions, FixedString32BytesMotionAdapter>>();
			IJobParallelForExtensions.EarlyJobInit<MotionUpdateJob<FixedString64Bytes, StringOptions, FixedString64BytesMotionAdapter>>();
			IJobParallelForExtensions.EarlyJobInit<MotionUpdateJob<FixedString128Bytes, StringOptions, FixedString128BytesMotionAdapter>>();
			IJobParallelForExtensions.EarlyJobInit<MotionUpdateJob<FixedString512Bytes, StringOptions, FixedString512BytesMotionAdapter>>();
			IJobParallelForExtensions.EarlyJobInit<MotionUpdateJob<FixedString4096Bytes, StringOptions, FixedString4096BytesMotionAdapter>>();
			IJobParallelForExtensions.EarlyJobInit<MotionUpdateJob<float, NoOptions, FloatMotionAdapter>>();
			IJobParallelForExtensions.EarlyJobInit<MotionUpdateJob<double, NoOptions, DoubleMotionAdapter>>();
			IJobParallelForExtensions.EarlyJobInit<MotionUpdateJob<int, IntegerOptions, IntMotionAdapter>>();
			IJobParallelForExtensions.EarlyJobInit<MotionUpdateJob<long, IntegerOptions, LongMotionAdapter>>();
			IJobParallelForExtensions.EarlyJobInit<MotionUpdateJob<float, PunchOptions, FloatPunchMotionAdapter>>();
			IJobParallelForExtensions.EarlyJobInit<MotionUpdateJob<Vector2, PunchOptions, Vector2PunchMotionAdapter>>();
			IJobParallelForExtensions.EarlyJobInit<MotionUpdateJob<Vector3, PunchOptions, Vector3PunchMotionAdapter>>();
			IJobParallelForExtensions.EarlyJobInit<MotionUpdateJob<float, ShakeOptions, FloatShakeMotionAdapter>>();
			IJobParallelForExtensions.EarlyJobInit<MotionUpdateJob<Vector2, ShakeOptions, Vector2ShakeMotionAdapter>>();
			IJobParallelForExtensions.EarlyJobInit<MotionUpdateJob<Vector3, ShakeOptions, Vector3ShakeMotionAdapter>>();
			IJobParallelForExtensions.EarlyJobInit<MotionUpdateJob<Vector2, NoOptions, Vector2MotionAdapter>>();
			IJobParallelForExtensions.EarlyJobInit<MotionUpdateJob<Vector3, NoOptions, Vector3MotionAdapter>>();
			IJobParallelForExtensions.EarlyJobInit<MotionUpdateJob<Vector4, NoOptions, Vector4MotionAdapter>>();
			IJobParallelForExtensions.EarlyJobInit<MotionUpdateJob<Quaternion, NoOptions, QuaternionMotionAdapter>>();
			IJobParallelForExtensions.EarlyJobInit<MotionUpdateJob<Color, NoOptions, ColorMotionAdapter>>();
			IJobParallelForExtensions.EarlyJobInit<MotionUpdateJob<Rect, NoOptions, RectMotionAdapter>>();
		}
		catch (Exception ex)
		{
			EarlyInitHelpers.JobReflectionDataCreationFailed(ex);
		}
	}

	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterAssembliesLoaded)]
	public static void EarlyInit()
	{
		CreateJobReflectionData();
	}
}
