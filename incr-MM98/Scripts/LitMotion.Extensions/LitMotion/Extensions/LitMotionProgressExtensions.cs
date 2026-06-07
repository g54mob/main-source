using System;

namespace LitMotion.Extensions
{
	public static class LitMotionProgressExtensions
	{
		public static MotionHandle BindToProgress<TValue, TOptions, TAdapter>(this MotionBuilder<TValue, TOptions, TAdapter> builder, IProgress<TValue> progress) where TValue : unmanaged where TOptions : unmanaged, IMotionOptions where TAdapter : unmanaged, IMotionAdapter<TValue, TOptions>
		{
			Error.IsNull(progress);
			return builder.Bind(progress, delegate(TValue x, IProgress<TValue> progress2)
			{
				progress2.Report(x);
			});
		}
	}
}
