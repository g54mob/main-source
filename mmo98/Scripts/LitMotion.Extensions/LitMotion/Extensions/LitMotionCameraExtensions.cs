using UnityEngine;

namespace LitMotion.Extensions
{
	public static class LitMotionCameraExtensions
	{
		public static MotionHandle BindToAspect<TOptions, TAdapter>(this MotionBuilder<float, TOptions, TAdapter> builder, Camera camera) where TOptions : unmanaged, IMotionOptions where TAdapter : unmanaged, IMotionAdapter<float, TOptions>
		{
			Error.IsNull(camera);
			return builder.Bind(camera, delegate(float x, Camera camera2)
			{
				camera2.aspect = x;
			});
		}

		public static MotionHandle BindToNearClipPlane<TOptions, TAdapter>(this MotionBuilder<float, TOptions, TAdapter> builder, Camera camera) where TOptions : unmanaged, IMotionOptions where TAdapter : unmanaged, IMotionAdapter<float, TOptions>
		{
			Error.IsNull(camera);
			return builder.Bind(camera, delegate(float x, Camera camera2)
			{
				camera2.nearClipPlane = x;
			});
		}

		public static MotionHandle BindToFarClipPlane<TOptions, TAdapter>(this MotionBuilder<float, TOptions, TAdapter> builder, Camera camera) where TOptions : unmanaged, IMotionOptions where TAdapter : unmanaged, IMotionAdapter<float, TOptions>
		{
			Error.IsNull(camera);
			return builder.Bind(camera, delegate(float x, Camera camera2)
			{
				camera2.farClipPlane = x;
			});
		}

		public static MotionHandle BindToFieldOfView<TOptions, TAdapter>(this MotionBuilder<float, TOptions, TAdapter> builder, Camera camera) where TOptions : unmanaged, IMotionOptions where TAdapter : unmanaged, IMotionAdapter<float, TOptions>
		{
			Error.IsNull(camera);
			return builder.Bind(camera, delegate(float x, Camera camera2)
			{
				camera2.fieldOfView = x;
			});
		}

		public static MotionHandle BindToOrthographicSize<TOptions, TAdapter>(this MotionBuilder<float, TOptions, TAdapter> builder, Camera camera) where TOptions : unmanaged, IMotionOptions where TAdapter : unmanaged, IMotionAdapter<float, TOptions>
		{
			Error.IsNull(camera);
			return builder.Bind(camera, delegate(float x, Camera camera2)
			{
				camera2.orthographicSize = x;
			});
		}

		public static MotionHandle BindToRect<TOptions, TAdapter>(this MotionBuilder<Rect, TOptions, TAdapter> builder, Camera camera) where TOptions : unmanaged, IMotionOptions where TAdapter : unmanaged, IMotionAdapter<Rect, TOptions>
		{
			Error.IsNull(camera);
			return builder.Bind(camera, delegate(Rect x, Camera camera2)
			{
				camera2.rect = x;
			});
		}

		public static MotionHandle BindToPixelRect<TOptions, TAdapter>(this MotionBuilder<Rect, TOptions, TAdapter> builder, Camera camera) where TOptions : unmanaged, IMotionOptions where TAdapter : unmanaged, IMotionAdapter<Rect, TOptions>
		{
			Error.IsNull(camera);
			return builder.Bind(camera, delegate(Rect x, Camera camera2)
			{
				camera2.pixelRect = x;
			});
		}

		public static MotionHandle BindToBackgroundColor<TOptions, TAdapter>(this MotionBuilder<Color, TOptions, TAdapter> builder, Camera camera) where TOptions : unmanaged, IMotionOptions where TAdapter : unmanaged, IMotionAdapter<Color, TOptions>
		{
			Error.IsNull(camera);
			return builder.Bind(camera, delegate(Color x, Camera camera2)
			{
				camera2.backgroundColor = x;
			});
		}
	}
}
