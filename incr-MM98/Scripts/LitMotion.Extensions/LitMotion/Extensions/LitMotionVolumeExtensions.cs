using UnityEngine.Rendering;

namespace LitMotion.Extensions
{
	public static class LitMotionVolumeExtensions
	{
		public static MotionHandle BindToWeight<TOptions, TAdapter>(this MotionBuilder<float, TOptions, TAdapter> builder, Volume volume) where TOptions : unmanaged, IMotionOptions where TAdapter : unmanaged, IMotionAdapter<float, TOptions>
		{
			Error.IsNull(volume);
			return builder.Bind(volume, delegate(float x, Volume volume2)
			{
				volume2.weight = x;
			});
		}
	}
}
