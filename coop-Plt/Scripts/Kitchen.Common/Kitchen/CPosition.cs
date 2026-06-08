using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace Kitchen
{
	public struct CPosition : IComponentData
	{
		public Vector3 Position;

		public quaternion Rotation;

		public bool ForceSnap;

		public static CPosition Hidden => new CPosition(new Vector3(-1000f, -1000f, -1000f));

		public readonly Vector3 ForwardPosition => Position + Forward(1f);

		public readonly Vector3 BackwardPosition => Position + Forward(-1f);

		public CPosition(Vector3 position, quaternion rotation)
		{
			Position = position;
			Rotation = rotation;
			ForceSnap = true;
		}

		public CPosition(Vector3 position)
		{
			Position = position;
			Rotation = quaternion.identity;
			ForceSnap = true;
		}

		public CPosition(float x, float y, float z = 0f)
		{
			Position = new Vector3(x, y, z);
			Rotation = quaternion.identity;
			ForceSnap = true;
		}

		public static CPosition Rounded(Vector3 position)
		{
			return new CPosition(math.round(position));
		}

		public readonly Vector3 Forward(float amount)
		{
			return math.mul(Rotation, new float3(0f, 0f, amount));
		}

		public readonly Vector3 Right(float amount)
		{
			return math.mul(Rotation, new float3(amount, 0f, 0f));
		}

		public static implicit operator CPosition(Vector2 pos)
		{
			return new CPosition(new Vector3(pos.x, 0f, pos.y));
		}

		public static implicit operator Vector2(CPosition pos)
		{
			return new Vector2(pos.Position.x, pos.Position.z);
		}

		public static implicit operator CPosition(Vector3 pos)
		{
			return new CPosition(pos);
		}

		public static implicit operator Vector3(CPosition pos)
		{
			return pos.Position;
		}

		public static implicit operator CPosition(quaternion rot)
		{
			return new CPosition
			{
				Rotation = rot
			};
		}

		public static implicit operator quaternion(CPosition pos)
		{
			return pos.Rotation;
		}
	}
}
