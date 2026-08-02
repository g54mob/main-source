using System.Collections.Generic;
using Polarith.Utils;
using UnityEngine;

namespace Polarith.AI.Move
{
	public class SteeringPercept : IPercept<GameObject>
	{
		public readonly List<float> Values = new List<float>();

		public string Label;

		public float Significance;

		public float Radius;

		public Vector3 Position;

		public Vector3 Scale;

		public Vector3 Velocity;

		public Quaternion Rotation;

		public Matrix4x4 WorldToLocalMatrix;

		public Bounds ColliderBoundsAABB;

		public Bounds ColliderBoundsOBB;

		public Bounds VisualBounds;

		private static readonly string nullString = "";

		private static readonly Vector3 nullVelocity = Vector3.zero;

		private static readonly Bounds nullBounds = default(Bounds);

		private Vector3 colliCache;

		private Quaternion rot;

		private GameObject gameObject;

		private GameObject oldGameObject;

		private Transform trans;

		private Rigidbody2D body2D;

		private Rigidbody body;

		private Collider2D colli2D;

		private Collider colli;

		private SpriteRenderer spriteRenderer;

		private MeshRenderer meshRenderer;

		private AIMSteeringTag tag;

		private int i;

		private bool active;

		private bool received;

		public bool Active
		{
			get
			{
				return active;
			}
			set
			{
				active = value;
			}
		}

		public bool Received
		{
			get
			{
				return received;
			}
			set
			{
				received = value;
			}
		}

		public virtual void Receive(GameObject gameObject)
		{
			if (gameObject == null)
			{
				active = false;
				return;
			}
			if (gameObject.activeInHierarchy)
			{
				active = true;
			}
			else
			{
				active = false;
			}
			this.gameObject = gameObject;
			if (gameObject != oldGameObject)
			{
				trans = gameObject.transform;
				tag = trans.GetComponent<AIMSteeringTag>();
				body2D = trans.GetComponent<Rigidbody2D>();
				body = trans.GetComponent<Rigidbody>();
				colli2D = trans.GetComponent<Collider2D>();
				colli = trans.GetComponent<Collider>();
				spriteRenderer = trans.GetComponent<SpriteRenderer>();
				meshRenderer = trans.GetComponent<MeshRenderer>();
			}
			if (tag != null)
			{
				Label = tag.Label;
				Significance = tag.Significance;
				Radius = ((tag.Radius >= 0f) ? tag.Radius : 0f);
				Collections.ResizeList(Values, tag.Values.Count);
				for (i = 0; i < Values.Count; i++)
				{
					Values[i] = tag.Values[i];
				}
			}
			else
			{
				Label = nullString;
				Significance = 1f;
				Radius = 0f;
				if (Values.Count > 0)
				{
					Values.Clear();
				}
			}
			Position = trans.position;
			Scale = trans.lossyScale;
			if (tag != null && tag.TrackVelocity)
			{
				if (tag.Velocity.magnitude > 1E-06f)
				{
					Velocity = tag.Velocity;
				}
				if ((body2D != null && !body2D.isKinematic) || (body != null && !body.isKinematic))
				{
					Debug.LogWarning("(" + typeof(SteeringPercept).Name + ") " + gameObject.name + ": velocity tracked by 'SteeringTag' might overwrite velocity of non-kinematic rigidbody");
				}
			}
			else if (body2D != null)
			{
				if (body2D.velocity.magnitude > 1E-06f)
				{
					Velocity = body2D.velocity;
				}
			}
			else if (body != null)
			{
				if (body.velocity.magnitude > 1E-06f)
				{
					Velocity = body.velocity;
				}
			}
			else
			{
				Velocity = nullVelocity;
			}
			Rotation = trans.rotation;
			WorldToLocalMatrix = trans.worldToLocalMatrix;
			if (colli2D != null)
			{
				ColliderBoundsAABB = colli2D.bounds;
				ColliderBoundsOBB.center = colli2D.bounds.center;
				if ((gameObject != oldGameObject || (tag != null && tag.UpdateLocalBounds)) && (tag == null || !tag.IgnoreLocalBounds))
				{
					rot = trans.rotation;
					trans.rotation = Quaternion.identity;
					ColliderBoundsOBB.size = colli2D.bounds.size;
					trans.rotation = rot;
				}
			}
			else if (colli != null)
			{
				ColliderBoundsAABB = colli.bounds;
				ColliderBoundsOBB.center = colli.bounds.center;
				if ((gameObject != oldGameObject || (tag != null && tag.UpdateLocalBounds)) && (tag == null || !tag.IgnoreLocalBounds))
				{
					rot = trans.rotation;
					trans.rotation = Quaternion.identity;
					ColliderBoundsOBB.size = colli.bounds.size;
					trans.rotation = rot;
				}
			}
			else
			{
				ColliderBoundsAABB = nullBounds;
				if (gameObject != oldGameObject || (tag != null && tag.UpdateLocalBounds))
				{
					ColliderBoundsOBB = nullBounds;
				}
			}
			if (gameObject != oldGameObject || (tag != null && tag.UpdateLocalBounds))
			{
				if (spriteRenderer != null && spriteRenderer.sprite != null)
				{
					VisualBounds = spriteRenderer.sprite.bounds;
				}
				else if (!gameObject.isStatic && meshRenderer != null)
				{
					VisualBounds = meshRenderer.bounds;
				}
				else
				{
					VisualBounds = nullBounds;
				}
			}
			oldGameObject = gameObject;
		}

		public void Receive()
		{
			Receive(gameObject);
		}

		public virtual void Copy(SteeringPercept other)
		{
			Collections.ResizeList(Values, other.Values.Count);
			for (i = 0; i < Values.Count; i++)
			{
				Values[i] = other.Values[i];
			}
			Label = other.Label;
			Radius = other.Radius;
			Significance = other.Significance;
			Position = other.Position;
			Scale = other.Scale;
			Velocity = other.Velocity;
			Rotation = other.Rotation;
			WorldToLocalMatrix = other.WorldToLocalMatrix;
			ColliderBoundsAABB = other.ColliderBoundsAABB;
			ColliderBoundsOBB = other.ColliderBoundsOBB;
			VisualBounds = other.VisualBounds;
			gameObject = other.gameObject;
			oldGameObject = other.oldGameObject;
		}

		public void Project(VectorProjectionType VectorProjection)
		{
			switch (VectorProjection)
			{
			case VectorProjectionType.PlaneXY:
				Position.z = 0f;
				Velocity.z = 0f;
				colliCache = ColliderBoundsAABB.center;
				colliCache.z = 0f;
				ColliderBoundsAABB.center = colliCache;
				colliCache = ColliderBoundsAABB.size;
				colliCache.z = 0f;
				ColliderBoundsAABB.size = colliCache;
				colliCache = ColliderBoundsOBB.center;
				colliCache.z = 0f;
				ColliderBoundsOBB.center = colliCache;
				colliCache = Rotation * ColliderBoundsOBB.size;
				colliCache.z = 0f;
				ColliderBoundsOBB.size = Quaternion.Inverse(Rotation) * colliCache;
				ColliderBoundsOBB.size = new Vector3(Mathf.Abs(ColliderBoundsOBB.size.x), Mathf.Abs(ColliderBoundsOBB.size.y), Mathf.Abs(ColliderBoundsOBB.size.z));
				colliCache = VisualBounds.center;
				colliCache.z = 0f;
				VisualBounds.center = colliCache;
				colliCache = VisualBounds.size;
				colliCache.z = 0f;
				VisualBounds.size = colliCache;
				break;
			case VectorProjectionType.PlaneXZ:
				Position.y = 0f;
				Velocity.y = 0f;
				colliCache = ColliderBoundsAABB.center;
				colliCache.y = 0f;
				ColliderBoundsAABB.center = colliCache;
				colliCache = ColliderBoundsAABB.size;
				colliCache.y = 0f;
				ColliderBoundsAABB.size = colliCache;
				colliCache = ColliderBoundsOBB.center;
				colliCache.y = 0f;
				ColliderBoundsOBB.center = colliCache;
				colliCache = Rotation * ColliderBoundsOBB.size;
				colliCache.y = 0f;
				ColliderBoundsOBB.size = Quaternion.Inverse(Rotation) * colliCache;
				ColliderBoundsOBB.size = new Vector3(Mathf.Abs(ColliderBoundsOBB.size.x), Mathf.Abs(ColliderBoundsOBB.size.y), Mathf.Abs(ColliderBoundsOBB.size.z));
				colliCache = VisualBounds.center;
				colliCache.y = 0f;
				VisualBounds.center = colliCache;
				colliCache = VisualBounds.size;
				colliCache.y = 0f;
				VisualBounds.size = colliCache;
				break;
			}
		}

		public bool IsEqual(SteeringPercept percept)
		{
			return percept.gameObject == gameObject;
		}

		public bool IsEqual(GameObject gameObject)
		{
			return gameObject == this.gameObject;
		}

		public bool IsNearBounds(BoundsType type, Vector3 position, float radius)
		{
			float num = 0f;
			switch (type)
			{
			case BoundsType.ColliderAABB:
				num = Mathf.Max(Mathf.Max(ColliderBoundsAABB.extents.x, ColliderBoundsAABB.extents.y), ColliderBoundsAABB.extents.z);
				break;
			case BoundsType.ColliderOBB:
				num = Mathf.Max(Mathf.Max(ColliderBoundsOBB.extents.x, ColliderBoundsOBB.extents.y), ColliderBoundsOBB.extents.z);
				break;
			case BoundsType.Visual:
				num = Mathf.Max(Mathf.Max(VisualBounds.extents.x * Scale.x, VisualBounds.extents.y * Scale.y), VisualBounds.extents.z * Scale.z);
				break;
			}
			return (num + radius) * (num + radius) >= (Position - position).sqrMagnitude;
		}

		public float GetBoundsSqrDistance(Vector3 point, BoundsType bounds, VectorProjectionType vectorProjection = VectorProjectionType.None)
		{
			float result = 0f;
			if (bounds == BoundsType.ColliderAABB)
			{
				return ColliderBoundsAABB.SqrDistance(point);
			}
			Vector3 point2 = WorldToLocalMatrix.MultiplyPoint(point);
			point2.Scale(Scale);
			if (vectorProjection == VectorProjectionType.PlaneXY)
			{
				point2.z = 0f;
			}
			if (vectorProjection == VectorProjectionType.PlaneXZ)
			{
				point2.y = 0f;
			}
			if (bounds == BoundsType.ColliderOBB)
			{
				Vector3 center = ColliderBoundsOBB.center;
				ColliderBoundsOBB.center = Vector3.zero;
				result = ColliderBoundsOBB.SqrDistance(point2);
				ColliderBoundsOBB.center = center;
			}
			if (bounds == BoundsType.Visual)
			{
				VisualBounds.extents = Vector3.Scale(VisualBounds.extents, Scale);
				result = VisualBounds.SqrDistance(point2);
			}
			return result;
		}

		public void SetGameObject(GameObject gameObject)
		{
			this.gameObject = gameObject;
		}
	}
}
