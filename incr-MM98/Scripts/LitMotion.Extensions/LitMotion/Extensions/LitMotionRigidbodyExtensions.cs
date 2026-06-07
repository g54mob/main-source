using UnityEngine;

namespace LitMotion.Extensions
{
	public static class LitMotionRigidbodyExtensions
	{
		public static MotionHandle BindToPosition<TOptions, TAdapter>(this MotionBuilder<Vector3, TOptions, TAdapter> builder, Rigidbody rigidbody, bool useMovePosition = true) where TOptions : unmanaged, IMotionOptions where TAdapter : unmanaged, IMotionAdapter<Vector3, TOptions>
		{
			Error.IsNull(rigidbody);
			if (useMovePosition)
			{
				return builder.Bind(rigidbody, delegate(Vector3 x, Rigidbody rigidbody2)
				{
					rigidbody2.MovePosition(x);
				});
			}
			return builder.Bind(rigidbody, delegate(Vector3 x, Rigidbody rigidbody2)
			{
				rigidbody2.position = x;
			});
		}

		public static MotionHandle BindToPositionX<TOptions, TAdapter>(this MotionBuilder<float, TOptions, TAdapter> builder, Rigidbody rigidbody, bool useMovePosition = true) where TOptions : unmanaged, IMotionOptions where TAdapter : unmanaged, IMotionAdapter<float, TOptions>
		{
			Error.IsNull(rigidbody);
			if (useMovePosition)
			{
				return builder.Bind(rigidbody, delegate(float x, Rigidbody rigidbody2)
				{
					Vector3 position = rigidbody2.position;
					position.x = x;
					rigidbody2.MovePosition(position);
				});
			}
			return builder.Bind(rigidbody, delegate(float x, Rigidbody rigidbody2)
			{
				Vector3 position = rigidbody2.position;
				position.x = x;
				rigidbody2.position = position;
			});
		}

		public static MotionHandle BindToPositionY<TOptions, TAdapter>(this MotionBuilder<float, TOptions, TAdapter> builder, Rigidbody rigidbody, bool useMovePosition = true) where TOptions : unmanaged, IMotionOptions where TAdapter : unmanaged, IMotionAdapter<float, TOptions>
		{
			Error.IsNull(rigidbody);
			if (useMovePosition)
			{
				return builder.Bind(rigidbody, delegate(float y, Rigidbody rigidbody2)
				{
					Vector3 position = rigidbody2.position;
					position.y = y;
					rigidbody2.MovePosition(position);
				});
			}
			return builder.Bind(rigidbody, delegate(float y, Rigidbody rigidbody2)
			{
				Vector3 position = rigidbody2.position;
				position.y = y;
				rigidbody2.position = position;
			});
		}

		public static MotionHandle BindToPositionZ<TOptions, TAdapter>(this MotionBuilder<float, TOptions, TAdapter> builder, Rigidbody rigidbody, bool useMovePosition = true) where TOptions : unmanaged, IMotionOptions where TAdapter : unmanaged, IMotionAdapter<float, TOptions>
		{
			Error.IsNull(rigidbody);
			if (useMovePosition)
			{
				return builder.Bind(rigidbody, delegate(float z, Rigidbody rigidbody2)
				{
					Vector3 position = rigidbody2.position;
					position.z = z;
					rigidbody2.MovePosition(position);
				});
			}
			return builder.Bind(rigidbody, delegate(float z, Rigidbody rigidbody2)
			{
				Vector3 position = rigidbody2.position;
				position.z = z;
				rigidbody2.position = position;
			});
		}

		public static MotionHandle BindToPositionXY<TOptions, TAdapter>(this MotionBuilder<Vector2, TOptions, TAdapter> builder, Rigidbody rigidbody, bool useMovePosition = true) where TOptions : unmanaged, IMotionOptions where TAdapter : unmanaged, IMotionAdapter<Vector2, TOptions>
		{
			Error.IsNull(rigidbody);
			if (useMovePosition)
			{
				return builder.Bind(rigidbody, delegate(Vector2 x, Rigidbody rigidbody2)
				{
					Vector3 position = rigidbody2.position;
					position.x = x.x;
					position.y = x.y;
					rigidbody2.MovePosition(position);
				});
			}
			return builder.Bind(rigidbody, delegate(Vector2 x, Rigidbody rigidbody2)
			{
				Vector3 position = rigidbody2.position;
				position.x = x.x;
				position.y = x.y;
				rigidbody2.position = position;
			});
		}

		public static MotionHandle BindToPositionYZ<TOptions, TAdapter>(this MotionBuilder<Vector2, TOptions, TAdapter> builder, Rigidbody rigidbody, bool useMovePosition = true) where TOptions : unmanaged, IMotionOptions where TAdapter : unmanaged, IMotionAdapter<Vector2, TOptions>
		{
			Error.IsNull(rigidbody);
			if (useMovePosition)
			{
				return builder.Bind(rigidbody, delegate(Vector2 x, Rigidbody rigidbody2)
				{
					Vector3 position = rigidbody2.position;
					position.y = x.x;
					position.z = x.y;
					rigidbody2.MovePosition(position);
				});
			}
			return builder.Bind(rigidbody, delegate(Vector2 x, Rigidbody rigidbody2)
			{
				Vector3 position = rigidbody2.position;
				position.y = x.x;
				position.z = x.y;
				rigidbody2.position = position;
			});
		}

		public static MotionHandle BindToPositionXZ<TOptions, TAdapter>(this MotionBuilder<Vector2, TOptions, TAdapter> builder, Rigidbody rigidbody, bool useMovePosition = true) where TOptions : unmanaged, IMotionOptions where TAdapter : unmanaged, IMotionAdapter<Vector2, TOptions>
		{
			Error.IsNull(rigidbody);
			if (useMovePosition)
			{
				return builder.Bind(rigidbody, delegate(Vector2 x, Rigidbody rigidbody2)
				{
					Vector3 position = rigidbody2.position;
					position.x = x.x;
					position.z = x.y;
					rigidbody2.MovePosition(position);
				});
			}
			return builder.Bind(rigidbody, delegate(Vector2 x, Rigidbody rigidbody2)
			{
				Vector3 position = rigidbody2.position;
				position.x = x.x;
				position.z = x.y;
				rigidbody2.position = position;
			});
		}

		public static MotionHandle BindToRotation<TOptions, TAdapter>(this MotionBuilder<Quaternion, TOptions, TAdapter> builder, Rigidbody rigidbody, bool useMoveRotation = true) where TOptions : unmanaged, IMotionOptions where TAdapter : unmanaged, IMotionAdapter<Quaternion, TOptions>
		{
			Error.IsNull(rigidbody);
			if (useMoveRotation)
			{
				return builder.Bind(rigidbody, delegate(Quaternion x, Rigidbody rigidbody2)
				{
					rigidbody2.MoveRotation(x);
				});
			}
			return builder.Bind(rigidbody, delegate(Quaternion x, Rigidbody rigidbody2)
			{
				rigidbody2.rotation = x;
			});
		}
	}
}
