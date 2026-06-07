using System;
using GameCreator.Runtime.Characters;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	public abstract class TGetLocationTrackLocation : PropertyTypeGetLocation
	{
		[Flags]
		private enum Axis
		{
			X = 1,
			Y = 2,
			Z = 4
		}

		private enum Rotation
		{
			None = 0,
			TowardsTarget = 1,
			AwayFromTarget = 2,
			SameAsTarget = 3,
			OppositeOfTarget = 4
		}

		[SerializeField]
		private PropertyGetDecimal m_Distance = GetDecimalDecimal.Create(1f);

		[SerializeField]
		private Axis m_Axis = Axis.X | Axis.Z;

		[SerializeField]
		private bool m_TrackTarget;

		[SerializeField]
		private Rotation m_Rotation;

		public override Location Get(Args args)
		{
			GameObject gameObject = GetFrom(args);
			GameObject to = GetTo(args);
			return m_Rotation switch
			{
				Rotation.None => GetLocation(gameObject, to, args, Vector3.zero), 
				Rotation.TowardsTarget => GetLocationTowards(gameObject, to, args, Vector3.zero), 
				Rotation.AwayFromTarget => GetLocationAway(gameObject, to, args, Vector3.zero), 
				Rotation.SameAsTarget => GetLocationSame(gameObject, to, args, Vector3.zero), 
				Rotation.OppositeOfTarget => GetLocationOpposite(gameObject, to, args, Vector3.zero), 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}

		protected abstract GameObject GetFrom(Args args);

		protected abstract GameObject GetTo(Args args);

		private Location GetLocation(GameObject from, GameObject to, Args args, Vector3 offset)
		{
			return new Location(GetPosition(from, to, args, offset), default(RotationNone));
		}

		private Location GetLocationTowards(GameObject from, GameObject to, Args args, Vector3 offset)
		{
			return new Location(GetPosition(from, to, args, offset), GetRotation(from, to, args, towards: true));
		}

		private Location GetLocationAway(GameObject from, GameObject to, Args args, Vector3 offset)
		{
			return new Location(GetPosition(from, to, args, offset), GetRotation(from, to, args, towards: false));
		}

		private Location GetLocationSame(GameObject from, GameObject to, Args args, Vector3 offset)
		{
			return new Location(GetPosition(from, to, args, offset), GetMimicRotation(from, to, args, towards: true));
		}

		private Location GetLocationOpposite(GameObject from, GameObject to, Args args, Vector3 offset)
		{
			return new Location(GetPosition(from, to, args, offset), GetMimicRotation(from, to, args, towards: false));
		}

		private IRotation GetRotation(GameObject from, GameObject to, Args args, bool towards)
		{
			if (from == null)
			{
				return default(RotationNone);
			}
			if (to == null)
			{
				return default(RotationNone);
			}
			if (m_TrackTarget)
			{
				if (!towards)
				{
					return new RotationAway(to.transform);
				}
				return new RotationTowards(to.transform);
			}
			Vector3 vector = to.transform.position - from.transform.position;
			if (from.Get<Character>() != null)
			{
				vector = Vector3.Scale(vector, Vector3Plane.NormalUp);
			}
			return towards ? new RotationConstant(Quaternion.LookRotation(vector)) : new RotationConstant(Quaternion.LookRotation(-vector));
		}

		private IRotation GetMimicRotation(GameObject from, GameObject to, Args args, bool towards)
		{
			if (from == null)
			{
				return default(RotationNone);
			}
			if (to == null)
			{
				return default(RotationNone);
			}
			if (m_TrackTarget)
			{
				if (!towards)
				{
					return new RotationOpposite(to.transform);
				}
				return new RotationSame(to.transform);
			}
			return towards ? new RotationConstant(to.transform.rotation) : new RotationConstant(to.transform.rotation * Quaternion.Euler(0f, 180f, 0f));
		}

		private IPosition GetPosition(GameObject from, GameObject to, Args args, Vector3 offset)
		{
			if (from == null)
			{
				return default(PositionNone);
			}
			if (to == null)
			{
				return default(PositionNone);
			}
			float num = (float)m_Distance.Get(args);
			Vector3 axis = new Vector3(m_Axis.HasFlag(Axis.X) ? 1f : 0f, m_Axis.HasFlag(Axis.Y) ? 1f : 0f, m_Axis.HasFlag(Axis.Z) ? 1f : 0f);
			if (m_TrackTarget)
			{
				return new PositionTowards(to.transform, axis, offset, num);
			}
			Vector3 vector = to.transform.TransformPoint(offset);
			if (num > 0f)
			{
				Vector3 normalized = (vector - from.transform.position).normalized;
				vector -= normalized * num;
			}
			return new PositionConstant(new Vector3((axis.x >= 0.5f) ? vector.x : from.transform.position.x, (axis.y >= 0.5f) ? vector.y : from.transform.position.y, (axis.z >= 0.5f) ? vector.z : from.transform.position.z));
		}
	}
}
