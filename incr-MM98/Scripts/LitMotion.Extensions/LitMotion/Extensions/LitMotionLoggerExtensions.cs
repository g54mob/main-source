using Cysharp.Text;
using UnityEngine;

namespace LitMotion.Extensions
{
	public static class LitMotionLoggerExtensions
	{
		public static MotionHandle BindToUnityLogger<TValue, TOptions, TAdapter>(this MotionBuilder<TValue, TOptions, TAdapter> builder) where TValue : unmanaged where TOptions : unmanaged, IMotionOptions where TAdapter : unmanaged, IMotionAdapter<TValue, TOptions>
		{
			return builder.Bind(delegate(TValue x)
			{
				Debug.unityLogger.Log(x);
			});
		}

		public static MotionHandle BindToUnityLogger<TValue, TOptions, TAdapter>(this MotionBuilder<TValue, TOptions, TAdapter> builder, string format) where TValue : unmanaged where TOptions : unmanaged, IMotionOptions where TAdapter : unmanaged, IMotionAdapter<TValue, TOptions>
		{
			return builder.Bind(format, delegate(TValue x, string format2)
			{
				string message = ZString.Format(format2, x);
				Debug.unityLogger.Log(message);
			});
		}

		public static MotionHandle BindToUnityLogger<TValue, TOptions, TAdapter>(this MotionBuilder<TValue, TOptions, TAdapter> builder, ILogger logger) where TValue : unmanaged where TOptions : unmanaged, IMotionOptions where TAdapter : unmanaged, IMotionAdapter<TValue, TOptions>
		{
			Error.IsNull(logger);
			return builder.Bind(logger, delegate(TValue x, ILogger logger2)
			{
				logger2.Log(x);
			});
		}

		public static MotionHandle BindToUnityLogger<TValue, TOptions, TAdapter>(this MotionBuilder<TValue, TOptions, TAdapter> builder, ILogger logger, string format) where TValue : unmanaged where TOptions : unmanaged, IMotionOptions where TAdapter : unmanaged, IMotionAdapter<TValue, TOptions>
		{
			Error.IsNull(logger);
			return builder.Bind(logger, format, delegate(TValue x, ILogger logger2, string format2)
			{
				string message = ZString.Format(format2, x);
				logger2.Log(message);
			});
		}
	}
}
