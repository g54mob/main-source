using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security;
using System.Security.Permissions;
using LitMotion;
using LitMotion.Adapters;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine;

[assembly: RegisterGenericJobType(typeof(MotionUpdateJob<FixedString32Bytes, StringOptions, FixedString32BytesMotionAdapter>))]
[assembly: RegisterGenericJobType(typeof(MotionUpdateJob<FixedString64Bytes, StringOptions, FixedString64BytesMotionAdapter>))]
[assembly: RegisterGenericJobType(typeof(MotionUpdateJob<FixedString128Bytes, StringOptions, FixedString128BytesMotionAdapter>))]
[assembly: RegisterGenericJobType(typeof(MotionUpdateJob<FixedString512Bytes, StringOptions, FixedString512BytesMotionAdapter>))]
[assembly: RegisterGenericJobType(typeof(MotionUpdateJob<FixedString4096Bytes, StringOptions, FixedString4096BytesMotionAdapter>))]
[assembly: RegisterGenericJobType(typeof(MotionUpdateJob<float, NoOptions, FloatMotionAdapter>))]
[assembly: RegisterGenericJobType(typeof(MotionUpdateJob<double, NoOptions, DoubleMotionAdapter>))]
[assembly: RegisterGenericJobType(typeof(MotionUpdateJob<int, IntegerOptions, IntMotionAdapter>))]
[assembly: RegisterGenericJobType(typeof(MotionUpdateJob<long, IntegerOptions, LongMotionAdapter>))]
[assembly: RegisterGenericJobType(typeof(MotionUpdateJob<float, PunchOptions, FloatPunchMotionAdapter>))]
[assembly: RegisterGenericJobType(typeof(MotionUpdateJob<Vector2, PunchOptions, Vector2PunchMotionAdapter>))]
[assembly: RegisterGenericJobType(typeof(MotionUpdateJob<Vector3, PunchOptions, Vector3PunchMotionAdapter>))]
[assembly: RegisterGenericJobType(typeof(MotionUpdateJob<float, ShakeOptions, FloatShakeMotionAdapter>))]
[assembly: RegisterGenericJobType(typeof(MotionUpdateJob<Vector2, ShakeOptions, Vector2ShakeMotionAdapter>))]
[assembly: RegisterGenericJobType(typeof(MotionUpdateJob<Vector3, ShakeOptions, Vector3ShakeMotionAdapter>))]
[assembly: RegisterGenericJobType(typeof(MotionUpdateJob<Vector2, NoOptions, Vector2MotionAdapter>))]
[assembly: RegisterGenericJobType(typeof(MotionUpdateJob<Vector3, NoOptions, Vector3MotionAdapter>))]
[assembly: RegisterGenericJobType(typeof(MotionUpdateJob<Vector4, NoOptions, Vector4MotionAdapter>))]
[assembly: RegisterGenericJobType(typeof(MotionUpdateJob<Quaternion, NoOptions, QuaternionMotionAdapter>))]
[assembly: RegisterGenericJobType(typeof(MotionUpdateJob<Color, NoOptions, ColorMotionAdapter>))]
[assembly: RegisterGenericJobType(typeof(MotionUpdateJob<Rect, NoOptions, RectMotionAdapter>))]
[assembly: InternalsVisibleTo("LitMotion.Sequences")]
[assembly: InternalsVisibleTo("LitMotion.Extensions")]
[assembly: InternalsVisibleTo("LitMotion.Animation")]
[assembly: InternalsVisibleTo("LitMotion.Editor")]
[assembly: InternalsVisibleTo("LitMotion.Tests.Runtime")]
[assembly: InternalsVisibleTo("LitMotion.Tests.Benchmark")]
[assembly: AssemblyVersion("0.0.0.0")]
