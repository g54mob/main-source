using System;
using UnityEngine;
using WaveHarmonic.Crest.Internal;

namespace WaveHarmonic.Crest
{
	public sealed class SampleCollisionHelper : SampleHelper
	{
		private enum QueryType
		{
			Displacement = 0,
			Height = 1
		}

		[Flags]
		private enum QueryOptions
		{
			None = 0,
			Velocity = 1,
			Normal = 2,
			All = 3
		}

		private readonly Vector3[] _QueryResultNormal = new Vector3[1];

		private readonly Vector3[] _QueryResultVelocity = new Vector3[1];

		private bool Sample(int id, Vector3 position, out Vector3 displacement, out float height, out Vector3 velocity, out Vector3 normal, QueryType type, QueryOptions options, CollisionLayer layer = CollisionLayer.Everything, float minimumLength = 0f, bool allowMultipleCallsPerFrame = false)
		{
			WaterRenderer instance = ManagerBehaviour<WaterRenderer>.Instance;
			ICollisionProvider collisionProvider = ((instance == null) ? null : instance.AnimatedWavesLod.Provider);
			height = 0f;
			displacement = Vector3.zero;
			velocity = Vector3.zero;
			normal = Vector3.up;
			if (collisionProvider == null)
			{
				return false;
			}
			bool flag = type == QueryType.Height;
			bool flag2 = type == QueryType.Displacement;
			bool flag3 = (options & QueryOptions.Velocity) == QueryOptions.Velocity;
			bool flag4 = (options & QueryOptions.Normal) == QueryOptions.Normal;
			_QueryPosition[0] = position;
			int status = collisionProvider.Query(id, minimumLength, _QueryPosition, _QueryResult, flag4 ? _QueryResultNormal : null, flag3 ? _QueryResultVelocity : null, layer, position);
			if (!collisionProvider.RetrieveSucceeded(status))
			{
				height = instance.SeaLevel;
				return false;
			}
			if (flag)
			{
				height = _QueryResult[0].y + instance.SeaLevel;
			}
			if (flag2)
			{
				displacement = _QueryResult[0];
			}
			if (flag3)
			{
				velocity = _QueryResultVelocity[0];
			}
			if (flag4)
			{
				normal = _QueryResultNormal[0];
			}
			return true;
		}

		internal bool SampleHeight(int id, Vector3 position, out float height, CollisionLayer layer = CollisionLayer.Everything, float minimumLength = 0f, bool allowMultipleCallsPerFrame = false)
		{
			Vector3 displacement;
			Vector3 velocity;
			Vector3 normal;
			return Sample(id, position, out displacement, out height, out velocity, out normal, QueryType.Height, QueryOptions.None, layer, minimumLength, allowMultipleCallsPerFrame);
		}

		internal bool SampleHeight(int id, Vector3 position, out float height, out Vector3 velocity, CollisionLayer layer = CollisionLayer.Everything, float minimumLength = 0f, bool allowMultipleCallsPerFrame = false)
		{
			Vector3 displacement;
			Vector3 normal;
			return Sample(id, position, out displacement, out height, out velocity, out normal, QueryType.Height, QueryOptions.Velocity, layer, minimumLength, allowMultipleCallsPerFrame);
		}

		internal bool SampleHeight(int id, Vector3 position, out float height, out Vector3 velocity, out Vector3 normal, CollisionLayer layer = CollisionLayer.Everything, float minimumLength = 0f, bool allowMultipleCallsPerFrame = false)
		{
			Vector3 displacement;
			return Sample(id, position, out displacement, out height, out velocity, out normal, QueryType.Height, QueryOptions.All, layer, minimumLength, allowMultipleCallsPerFrame);
		}

		internal bool SampleDisplacement(int id, Vector3 position, out Vector3 displacement, out Vector3 velocity, out Vector3 normal, CollisionLayer layer = CollisionLayer.Everything, float minimumLength = 0f, bool allowMultipleCallsPerFrame = false)
		{
			float height;
			return Sample(id, position, out displacement, out height, out velocity, out normal, QueryType.Displacement, QueryOptions.All, layer, minimumLength, allowMultipleCallsPerFrame);
		}

		internal bool SampleDisplacement(int id, Vector3 position, out Vector3 displacement, out Vector3 velocity, CollisionLayer layer = CollisionLayer.Everything, float minimumLength = 0f, bool allowMultipleCallsPerFrame = false)
		{
			float height;
			Vector3 normal;
			return Sample(id, position, out displacement, out height, out velocity, out normal, QueryType.Displacement, QueryOptions.Velocity, layer, minimumLength, allowMultipleCallsPerFrame);
		}

		internal bool SampleDisplacement(int id, Vector3 position, out Vector3 displacement, CollisionLayer layer = CollisionLayer.Everything, float minimumLength = 0f, bool allowMultipleCallsPerFrame = false)
		{
			float height;
			Vector3 velocity;
			Vector3 normal;
			return Sample(id, position, out displacement, out height, out velocity, out normal, QueryType.Displacement, QueryOptions.None, layer, minimumLength, allowMultipleCallsPerFrame);
		}

		private bool Sample(Vector3 position, float height, Vector3 displacement, Vector3 normal, Vector3 velocity, float minimumLength = 0f, CollisionLayer layer = CollisionLayer.Everything)
		{
			return false;
		}

		[Obsolete("Please use SampleDisplacement instead. Be wary that the new API has switch the normal parameter with velocity.")]
		public bool Sample(Vector3 position, out Vector3 displacement, out Vector3 normal, out Vector3 velocity, float minimumLength = 0f, CollisionLayer layer = CollisionLayer.Everything)
		{
			return SampleDisplacement(GetHashCode(), position, out displacement, out velocity, out normal, layer, minimumLength);
		}

		[Obsolete("Please use SampleHeight instead. Be wary that the new API has switch the normal parameter with velocity.")]
		public bool Sample(Vector3 position, out float height, out Vector3 normal, out Vector3 velocity, float minimumLength = 0f, CollisionLayer layer = CollisionLayer.Everything)
		{
			return SampleHeight(GetHashCode(), position, out height, out velocity, out normal, layer, minimumLength);
		}

		[Obsolete("Please use SampleHeight instead. Be wary that the new API has switch the normal parameter with velocity.")]
		public bool Sample(Vector3 position, out float height, out Vector3 normal, float minimumLength = 0f, CollisionLayer layer = CollisionLayer.Everything)
		{
			Vector3 velocity;
			return SampleHeight(GetHashCode(), position, out height, out velocity, out normal, layer, minimumLength);
		}

		[Obsolete("Please use SampleHeight instead. Be wary that the new API has switch the normal parameter with velocity.")]
		public bool Sample(Vector3 position, out float height, float minimumLength = 0f, CollisionLayer layer = CollisionLayer.Everything)
		{
			return SampleHeight(GetHashCode(), position, out height, layer, minimumLength);
		}

		public bool SampleDisplacement(Vector3 position, out Vector3 displacement, out Vector3 velocity, out Vector3 normal, float minimumLength = 0f, CollisionLayer layer = CollisionLayer.Everything)
		{
			return SampleDisplacement(GetHashCode(), position, out displacement, out velocity, out normal, layer, minimumLength);
		}

		public bool SampleDisplacement(Vector3 position, out Vector3 displacement, out Vector3 velocity, float minimumLength = 0f, CollisionLayer layer = CollisionLayer.Everything)
		{
			return SampleDisplacement(GetHashCode(), position, out displacement, out velocity, layer, minimumLength);
		}

		public bool SampleDisplacement(Vector3 position, out Vector3 displacement, float minimumLength = 0f, CollisionLayer layer = CollisionLayer.Everything)
		{
			return SampleDisplacement(GetHashCode(), position, out displacement, layer, minimumLength);
		}

		public bool SampleHeight(Vector3 position, out float height, out Vector3 velocity, out Vector3 normal, float minimumLength = 0f, CollisionLayer layer = CollisionLayer.Everything)
		{
			return SampleHeight(GetHashCode(), position, out height, out velocity, out normal, layer, minimumLength);
		}

		public bool SampleHeight(Vector3 position, out float height, out Vector3 velocity, float minimumLength = 0f, CollisionLayer layer = CollisionLayer.Everything)
		{
			return SampleHeight(GetHashCode(), position, out height, out velocity, layer, minimumLength);
		}

		public bool SampleHeight(Vector3 position, out float height, float minimumLength = 0f, CollisionLayer layer = CollisionLayer.Everything)
		{
			return SampleHeight(GetHashCode(), position, out height, layer, minimumLength);
		}
	}
}
