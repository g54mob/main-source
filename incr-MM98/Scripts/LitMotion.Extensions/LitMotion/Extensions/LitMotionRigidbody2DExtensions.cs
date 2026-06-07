using UnityEngine;

namespace LitMotion.Extensions
{
	public static class LitMotionRigidbody2DExtensions
	{
		public static MotionHandle BindToPosition<TOptions, TAdapter>(this MotionBuilder<Vector2, TOptions, TAdapter> builder, Rigidbody2D rigidbody2d, bool useMovePosition = true) where TOptions : unmanaged, IMotionOptions where TAdapter : unmanaged, IMotionAdapter<Vector2, TOptions>
		{
			Error.IsNull(rigidbody2d);
			if (useMovePosition)
			{
				return builder.Bind(rigidbody2d, delegate(Vector2 x, Rigidbody2D rigidbody2D)
				{
					rigidbody2D.MovePosition(x);
				});
			}
			return builder.Bind(rigidbody2d, delegate(Vector2 x, Rigidbody2D rigidbody2D)
			{
				rigidbody2D.position = x;
			});
		}

		public static MotionHandle BindToPositionX<TOptions, TAdapter>(this MotionBuilder<float, TOptions, TAdapter> builder, Rigidbody2D rigidbody2d, bool useMovePosition = true) where TOptions : unmanaged, IMotionOptions where TAdapter : unmanaged, IMotionAdapter<float, TOptions>
		{
			Error.IsNull(rigidbody2d);
			if (useMovePosition)
			{
				return builder.Bind(rigidbody2d, delegate(float x, Rigidbody2D rigidbody2D)
				{
					Vector2 position = rigidbody2D.position;
					position.x = x;
					rigidbody2D.MovePosition(position);
				});
			}
			return builder.Bind(rigidbody2d, delegate(float x, Rigidbody2D rigidbody2D)
			{
				Vector2 position = rigidbody2D.position;
				position.x = x;
				rigidbody2D.position = position;
			});
		}

		public static MotionHandle BindToPositionY<TOptions, TAdapter>(this MotionBuilder<float, TOptions, TAdapter> builder, Rigidbody2D rigidbody2d, bool useMovePosition = true) where TOptions : unmanaged, IMotionOptions where TAdapter : unmanaged, IMotionAdapter<float, TOptions>
		{
			Error.IsNull(rigidbody2d);
			if (useMovePosition)
			{
				return builder.Bind(rigidbody2d, delegate(float y, Rigidbody2D rigidbody2D)
				{
					Vector2 position = rigidbody2D.position;
					position.y = y;
					rigidbody2D.MovePosition(position);
				});
			}
			return builder.Bind(rigidbody2d, delegate(float y, Rigidbody2D rigidbody2D)
			{
				Vector2 position = rigidbody2D.position;
				position.y = y;
				rigidbody2D.position = position;
			});
		}

		public static MotionHandle BindToRotation<TOptions, TAdapter>(this MotionBuilder<float, TOptions, TAdapter> builder, Rigidbody2D rigidbody2d, bool useMovePosition = true) where TOptions : unmanaged, IMotionOptions where TAdapter : unmanaged, IMotionAdapter<float, TOptions>
		{
			Error.IsNull(rigidbody2d);
			if (useMovePosition)
			{
				return builder.Bind(rigidbody2d, delegate(float x, Rigidbody2D rigidbody2D)
				{
					rigidbody2D.MoveRotation(x);
				});
			}
			return builder.Bind(rigidbody2d, delegate(float x, Rigidbody2D rigidbody2D)
			{
				rigidbody2D.rotation = x;
			});
		}
	}
}
