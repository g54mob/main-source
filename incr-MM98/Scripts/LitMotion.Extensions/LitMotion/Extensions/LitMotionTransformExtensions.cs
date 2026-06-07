using UnityEngine;

namespace LitMotion.Extensions
{
	public static class LitMotionTransformExtensions
	{
		public static MotionHandle BindToPosition<TOptions, TAdapter>(this MotionBuilder<Vector3, TOptions, TAdapter> builder, Transform transform) where TOptions : unmanaged, IMotionOptions where TAdapter : unmanaged, IMotionAdapter<Vector3, TOptions>
		{
			Error.IsNull(transform);
			return builder.Bind(transform, delegate(Vector3 x, Transform t)
			{
				t.position = x;
			});
		}

		public static MotionHandle BindToPositionX<TOptions, TAdapter>(this MotionBuilder<float, TOptions, TAdapter> builder, Transform transform) where TOptions : unmanaged, IMotionOptions where TAdapter : unmanaged, IMotionAdapter<float, TOptions>
		{
			Error.IsNull(transform);
			return builder.Bind(transform, delegate(float x, Transform t)
			{
				Vector3 position = t.position;
				position.x = x;
				t.position = position;
			});
		}

		public static MotionHandle BindToPositionY<TOptions, TAdapter>(this MotionBuilder<float, TOptions, TAdapter> builder, Transform transform) where TOptions : unmanaged, IMotionOptions where TAdapter : unmanaged, IMotionAdapter<float, TOptions>
		{
			Error.IsNull(transform);
			return builder.Bind(transform, delegate(float x, Transform t)
			{
				Vector3 position = t.position;
				position.y = x;
				t.position = position;
			});
		}

		public static MotionHandle BindToPositionZ<TOptions, TAdapter>(this MotionBuilder<float, TOptions, TAdapter> builder, Transform transform) where TOptions : unmanaged, IMotionOptions where TAdapter : unmanaged, IMotionAdapter<float, TOptions>
		{
			Error.IsNull(transform);
			return builder.Bind(transform, delegate(float x, Transform t)
			{
				Vector3 position = t.position;
				position.z = x;
				t.position = position;
			});
		}

		public static MotionHandle BindToPositionXY<TOptions, TAdapter>(this MotionBuilder<Vector2, TOptions, TAdapter> builder, Transform transform) where TOptions : unmanaged, IMotionOptions where TAdapter : unmanaged, IMotionAdapter<Vector2, TOptions>
		{
			Error.IsNull(transform);
			return builder.Bind(transform, delegate(Vector2 x, Transform t)
			{
				Vector3 position = t.position;
				position.x = x.x;
				position.y = x.y;
				t.position = position;
			});
		}

		public static MotionHandle BindToPositionXZ<TOptions, TAdapter>(this MotionBuilder<Vector2, TOptions, TAdapter> builder, Transform transform) where TOptions : unmanaged, IMotionOptions where TAdapter : unmanaged, IMotionAdapter<Vector2, TOptions>
		{
			Error.IsNull(transform);
			return builder.Bind(transform, delegate(Vector2 x, Transform t)
			{
				Vector3 position = t.position;
				position.x = x.x;
				position.z = x.y;
				t.position = position;
			});
		}

		public static MotionHandle BindToPositionYZ<TOptions, TAdapter>(this MotionBuilder<Vector2, TOptions, TAdapter> builder, Transform transform) where TOptions : unmanaged, IMotionOptions where TAdapter : unmanaged, IMotionAdapter<Vector2, TOptions>
		{
			Error.IsNull(transform);
			return builder.Bind(transform, delegate(Vector2 x, Transform t)
			{
				Vector3 position = t.position;
				position.y = x.x;
				position.z = x.y;
				t.position = position;
			});
		}

		public static MotionHandle BindToLocalPosition<TOptions, TAdapter>(this MotionBuilder<Vector3, TOptions, TAdapter> builder, Transform transform) where TOptions : unmanaged, IMotionOptions where TAdapter : unmanaged, IMotionAdapter<Vector3, TOptions>
		{
			Error.IsNull(transform);
			return builder.Bind(transform, delegate(Vector3 x, Transform t)
			{
				t.localPosition = x;
			});
		}

		public static MotionHandle BindToLocalPositionX<TOptions, TAdapter>(this MotionBuilder<float, TOptions, TAdapter> builder, Transform transform) where TOptions : unmanaged, IMotionOptions where TAdapter : unmanaged, IMotionAdapter<float, TOptions>
		{
			Error.IsNull(transform);
			return builder.Bind(transform, delegate(float x, Transform t)
			{
				Vector3 localPosition = t.localPosition;
				localPosition.x = x;
				t.localPosition = localPosition;
			});
		}

		public static MotionHandle BindToLocalPositionY<TOptions, TAdapter>(this MotionBuilder<float, TOptions, TAdapter> builder, Transform transform) where TOptions : unmanaged, IMotionOptions where TAdapter : unmanaged, IMotionAdapter<float, TOptions>
		{
			Error.IsNull(transform);
			return builder.Bind(transform, delegate(float x, Transform t)
			{
				Vector3 localPosition = t.localPosition;
				localPosition.y = x;
				t.localPosition = localPosition;
			});
		}

		public static MotionHandle BindToLocalPositionZ<TOptions, TAdapter>(this MotionBuilder<float, TOptions, TAdapter> builder, Transform transform) where TOptions : unmanaged, IMotionOptions where TAdapter : unmanaged, IMotionAdapter<float, TOptions>
		{
			Error.IsNull(transform);
			return builder.Bind(transform, delegate(float x, Transform t)
			{
				Vector3 localPosition = t.localPosition;
				localPosition.z = x;
				t.localPosition = localPosition;
			});
		}

		public static MotionHandle BindToLocalPositionXY<TOptions, TAdapter>(this MotionBuilder<Vector2, TOptions, TAdapter> builder, Transform transform) where TOptions : unmanaged, IMotionOptions where TAdapter : unmanaged, IMotionAdapter<Vector2, TOptions>
		{
			Error.IsNull(transform);
			return builder.Bind(transform, delegate(Vector2 x, Transform t)
			{
				Vector3 localPosition = t.localPosition;
				localPosition.x = x.x;
				localPosition.y = x.y;
				t.localPosition = localPosition;
			});
		}

		public static MotionHandle BindToLocalPositionXZ<TOptions, TAdapter>(this MotionBuilder<Vector2, TOptions, TAdapter> builder, Transform transform) where TOptions : unmanaged, IMotionOptions where TAdapter : unmanaged, IMotionAdapter<Vector2, TOptions>
		{
			Error.IsNull(transform);
			return builder.Bind(transform, delegate(Vector2 x, Transform t)
			{
				Vector3 localPosition = t.localPosition;
				localPosition.x = x.x;
				localPosition.z = x.y;
				t.localPosition = localPosition;
			});
		}

		public static MotionHandle BindToLocalPositionYZ<TOptions, TAdapter>(this MotionBuilder<Vector2, TOptions, TAdapter> builder, Transform transform) where TOptions : unmanaged, IMotionOptions where TAdapter : unmanaged, IMotionAdapter<Vector2, TOptions>
		{
			Error.IsNull(transform);
			return builder.Bind(transform, delegate(Vector2 x, Transform t)
			{
				Vector3 localPosition = t.localPosition;
				localPosition.y = x.x;
				localPosition.z = x.y;
				t.localPosition = localPosition;
			});
		}

		public static MotionHandle BindToRotation<TOptions, TAdapter>(this MotionBuilder<Quaternion, TOptions, TAdapter> builder, Transform transform) where TOptions : unmanaged, IMotionOptions where TAdapter : unmanaged, IMotionAdapter<Quaternion, TOptions>
		{
			Error.IsNull(transform);
			return builder.Bind(transform, delegate(Quaternion x, Transform t)
			{
				t.rotation = x;
			});
		}

		public static MotionHandle BindToLocalRotation<TOptions, TAdapter>(this MotionBuilder<Quaternion, TOptions, TAdapter> builder, Transform transform) where TOptions : unmanaged, IMotionOptions where TAdapter : unmanaged, IMotionAdapter<Quaternion, TOptions>
		{
			Error.IsNull(transform);
			return builder.Bind(transform, delegate(Quaternion x, Transform t)
			{
				t.localRotation = x;
			});
		}

		public static MotionHandle BindToEulerAngles<TOptions, TAdapter>(this MotionBuilder<Vector3, TOptions, TAdapter> builder, Transform transform) where TOptions : unmanaged, IMotionOptions where TAdapter : unmanaged, IMotionAdapter<Vector3, TOptions>
		{
			Error.IsNull(transform);
			return builder.Bind(transform, delegate(Vector3 x, Transform t)
			{
				t.eulerAngles = x;
			});
		}

		public static MotionHandle BindToEulerAnglesX<TOptions, TAdapter>(this MotionBuilder<float, TOptions, TAdapter> builder, Transform transform) where TOptions : unmanaged, IMotionOptions where TAdapter : unmanaged, IMotionAdapter<float, TOptions>
		{
			Error.IsNull(transform);
			return builder.Bind(transform, delegate(float x, Transform t)
			{
				Vector3 eulerAngles = t.eulerAngles;
				eulerAngles.x = x;
				t.eulerAngles = eulerAngles;
			});
		}

		public static MotionHandle BindToEulerAnglesY<TOptions, TAdapter>(this MotionBuilder<float, TOptions, TAdapter> builder, Transform transform) where TOptions : unmanaged, IMotionOptions where TAdapter : unmanaged, IMotionAdapter<float, TOptions>
		{
			Error.IsNull(transform);
			return builder.Bind(transform, delegate(float x, Transform t)
			{
				Vector3 eulerAngles = t.eulerAngles;
				eulerAngles.y = x;
				t.eulerAngles = eulerAngles;
			});
		}

		public static MotionHandle BindToEulerAnglesZ<TOptions, TAdapter>(this MotionBuilder<float, TOptions, TAdapter> builder, Transform transform) where TOptions : unmanaged, IMotionOptions where TAdapter : unmanaged, IMotionAdapter<float, TOptions>
		{
			Error.IsNull(transform);
			return builder.Bind(transform, delegate(float x, Transform t)
			{
				Vector3 eulerAngles = t.eulerAngles;
				eulerAngles.z = x;
				t.eulerAngles = eulerAngles;
			});
		}

		public static MotionHandle BindToEulerAnglesXY<TOptions, TAdapter>(this MotionBuilder<Vector2, TOptions, TAdapter> builder, Transform transform) where TOptions : unmanaged, IMotionOptions where TAdapter : unmanaged, IMotionAdapter<Vector2, TOptions>
		{
			Error.IsNull(transform);
			return builder.Bind(transform, delegate(Vector2 x, Transform t)
			{
				Vector3 eulerAngles = t.eulerAngles;
				eulerAngles.x = x.x;
				eulerAngles.y = x.y;
				t.eulerAngles = eulerAngles;
			});
		}

		public static MotionHandle BindToEulerAnglesXZ<TOptions, TAdapter>(this MotionBuilder<Vector2, TOptions, TAdapter> builder, Transform transform) where TOptions : unmanaged, IMotionOptions where TAdapter : unmanaged, IMotionAdapter<Vector2, TOptions>
		{
			Error.IsNull(transform);
			return builder.Bind(transform, delegate(Vector2 x, Transform t)
			{
				Vector3 eulerAngles = t.eulerAngles;
				eulerAngles.x = x.x;
				eulerAngles.z = x.y;
				t.eulerAngles = eulerAngles;
			});
		}

		public static MotionHandle BindToEulerAnglesYZ<TOptions, TAdapter>(this MotionBuilder<Vector2, TOptions, TAdapter> builder, Transform transform) where TOptions : unmanaged, IMotionOptions where TAdapter : unmanaged, IMotionAdapter<Vector2, TOptions>
		{
			Error.IsNull(transform);
			return builder.Bind(transform, delegate(Vector2 x, Transform t)
			{
				Vector3 eulerAngles = t.eulerAngles;
				eulerAngles.y = x.x;
				eulerAngles.z = x.y;
				t.eulerAngles = eulerAngles;
			});
		}

		public static MotionHandle BindToLocalEulerAngles<TOptions, TAdapter>(this MotionBuilder<Vector3, TOptions, TAdapter> builder, Transform transform) where TOptions : unmanaged, IMotionOptions where TAdapter : unmanaged, IMotionAdapter<Vector3, TOptions>
		{
			Error.IsNull(transform);
			return builder.Bind(transform, delegate(Vector3 x, Transform t)
			{
				t.localEulerAngles = x;
			});
		}

		public static MotionHandle BindToLocalEulerAnglesX<TOptions, TAdapter>(this MotionBuilder<float, TOptions, TAdapter> builder, Transform transform) where TOptions : unmanaged, IMotionOptions where TAdapter : unmanaged, IMotionAdapter<float, TOptions>
		{
			Error.IsNull(transform);
			return builder.Bind(transform, delegate(float x, Transform t)
			{
				Vector3 localEulerAngles = t.localEulerAngles;
				localEulerAngles.x = x;
				t.localEulerAngles = localEulerAngles;
			});
		}

		public static MotionHandle BindToLocalEulerAnglesY<TOptions, TAdapter>(this MotionBuilder<float, TOptions, TAdapter> builder, Transform transform) where TOptions : unmanaged, IMotionOptions where TAdapter : unmanaged, IMotionAdapter<float, TOptions>
		{
			Error.IsNull(transform);
			return builder.Bind(transform, delegate(float x, Transform t)
			{
				Vector3 localEulerAngles = t.localEulerAngles;
				localEulerAngles.y = x;
				t.localEulerAngles = localEulerAngles;
			});
		}

		public static MotionHandle BindToLocalEulerAnglesZ<TOptions, TAdapter>(this MotionBuilder<float, TOptions, TAdapter> builder, Transform transform) where TOptions : unmanaged, IMotionOptions where TAdapter : unmanaged, IMotionAdapter<float, TOptions>
		{
			Error.IsNull(transform);
			return builder.Bind(transform, delegate(float x, Transform t)
			{
				Vector3 localEulerAngles = t.localEulerAngles;
				localEulerAngles.z = x;
				t.localEulerAngles = localEulerAngles;
			});
		}

		public static MotionHandle BindToLocalEulerAnglesXY<TOptions, TAdapter>(this MotionBuilder<Vector2, TOptions, TAdapter> builder, Transform transform) where TOptions : unmanaged, IMotionOptions where TAdapter : unmanaged, IMotionAdapter<Vector2, TOptions>
		{
			Error.IsNull(transform);
			return builder.Bind(transform, delegate(Vector2 x, Transform t)
			{
				Vector3 localEulerAngles = t.localEulerAngles;
				localEulerAngles.x = x.x;
				localEulerAngles.y = x.y;
				t.localEulerAngles = localEulerAngles;
			});
		}

		public static MotionHandle BindToLocalEulerAnglesXZ<TOptions, TAdapter>(this MotionBuilder<Vector2, TOptions, TAdapter> builder, Transform transform) where TOptions : unmanaged, IMotionOptions where TAdapter : unmanaged, IMotionAdapter<Vector2, TOptions>
		{
			Error.IsNull(transform);
			return builder.Bind(transform, delegate(Vector2 x, Transform t)
			{
				Vector3 localEulerAngles = t.localEulerAngles;
				localEulerAngles.x = x.x;
				localEulerAngles.z = x.y;
				t.localEulerAngles = localEulerAngles;
			});
		}

		public static MotionHandle BindToLocalEulerAnglesYZ<TOptions, TAdapter>(this MotionBuilder<Vector2, TOptions, TAdapter> builder, Transform transform) where TOptions : unmanaged, IMotionOptions where TAdapter : unmanaged, IMotionAdapter<Vector2, TOptions>
		{
			Error.IsNull(transform);
			return builder.Bind(transform, delegate(Vector2 x, Transform t)
			{
				Vector3 localEulerAngles = t.localEulerAngles;
				localEulerAngles.y = x.x;
				localEulerAngles.z = x.y;
				t.localEulerAngles = localEulerAngles;
			});
		}

		public static MotionHandle BindToLocalScale<TOptions, TAdapter>(this MotionBuilder<Vector3, TOptions, TAdapter> builder, Transform transform) where TOptions : unmanaged, IMotionOptions where TAdapter : unmanaged, IMotionAdapter<Vector3, TOptions>
		{
			Error.IsNull(transform);
			return builder.Bind(transform, delegate(Vector3 x, Transform t)
			{
				t.localScale = x;
			});
		}

		public static MotionHandle BindToLocalScaleX<TOptions, TAdapter>(this MotionBuilder<float, TOptions, TAdapter> builder, Transform transform) where TOptions : unmanaged, IMotionOptions where TAdapter : unmanaged, IMotionAdapter<float, TOptions>
		{
			Error.IsNull(transform);
			return builder.Bind(transform, delegate(float x, Transform t)
			{
				Vector3 localScale = t.localScale;
				localScale.x = x;
				t.localScale = localScale;
			});
		}

		public static MotionHandle BindToLocalScaleY<TOptions, TAdapter>(this MotionBuilder<float, TOptions, TAdapter> builder, Transform transform) where TOptions : unmanaged, IMotionOptions where TAdapter : unmanaged, IMotionAdapter<float, TOptions>
		{
			Error.IsNull(transform);
			return builder.Bind(transform, delegate(float x, Transform t)
			{
				Vector3 localScale = t.localScale;
				localScale.y = x;
				t.localScale = localScale;
			});
		}

		public static MotionHandle BindToLocalScaleZ<TOptions, TAdapter>(this MotionBuilder<float, TOptions, TAdapter> builder, Transform transform) where TOptions : unmanaged, IMotionOptions where TAdapter : unmanaged, IMotionAdapter<float, TOptions>
		{
			Error.IsNull(transform);
			return builder.Bind(transform, delegate(float x, Transform t)
			{
				Vector3 localScale = t.localScale;
				localScale.z = x;
				t.localScale = localScale;
			});
		}

		public static MotionHandle BindToLocalScaleXY<TOptions, TAdapter>(this MotionBuilder<Vector2, TOptions, TAdapter> builder, Transform transform) where TOptions : unmanaged, IMotionOptions where TAdapter : unmanaged, IMotionAdapter<Vector2, TOptions>
		{
			Error.IsNull(transform);
			return builder.Bind(transform, delegate(Vector2 x, Transform t)
			{
				Vector3 localScale = t.localScale;
				localScale.x = x.x;
				localScale.y = x.y;
				t.localScale = localScale;
			});
		}

		public static MotionHandle BindToLocalScaleXZ<TOptions, TAdapter>(this MotionBuilder<Vector2, TOptions, TAdapter> builder, Transform transform) where TOptions : unmanaged, IMotionOptions where TAdapter : unmanaged, IMotionAdapter<Vector2, TOptions>
		{
			Error.IsNull(transform);
			return builder.Bind(transform, delegate(Vector2 x, Transform t)
			{
				Vector3 localScale = t.localScale;
				localScale.x = x.x;
				localScale.z = x.y;
				t.localScale = localScale;
			});
		}

		public static MotionHandle BindToLocalScaleYZ<TOptions, TAdapter>(this MotionBuilder<Vector2, TOptions, TAdapter> builder, Transform transform) where TOptions : unmanaged, IMotionOptions where TAdapter : unmanaged, IMotionAdapter<Vector2, TOptions>
		{
			Error.IsNull(transform);
			return builder.Bind(transform, delegate(Vector2 x, Transform t)
			{
				Vector3 localScale = t.localScale;
				localScale.y = x.x;
				localScale.z = x.y;
				t.localScale = localScale;
			});
		}
	}
}
