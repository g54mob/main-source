using System;
using RootMotion.FinalIK;
using UnityEngine;

public class bmu : MonoBehaviour
{
	[Serializable]
	public class CharacterPosition
	{
		public bool use;

		public Vector2 offset;

		[Range(-180f, 180f)]
		public float angleOffset;

		[Range(0f, 180f)]
		public float maxAngle;

		public float radius;

		public bool orbit;

		public bool fixYAxis;

		public Vector3 xsl => default(Vector3);

		public Vector3 xsm => default(Vector3);

		public bool kuy(Transform a, Transform b, out float c)
		{
			c = default(float);
			return false;
		}
	}

	[Serializable]
	public class CameraPosition
	{
		public Collider lookAtTarget;

		public Vector3 direction;

		public float maxDistance;

		[Range(0f, 180f)]
		public float maxAngle;

		public bool fixYAxis;

		public Quaternion kuz()
		{
			return default(Quaternion);
		}

		public bool kva(Transform a, RaycastHit b, Transform c, out float d)
		{
			d = default(float);
			return false;
		}
	}

	[Serializable]
	public class Range
	{
		[Serializable]
		public class Interaction
		{
			public bms interactionObject;

			public FullBodyBipedEffector[] effectors;
		}

		[HideInInspector]
		public string name;

		[HideInInspector]
		public bool show;

		public CharacterPosition characterPosition;

		public CameraPosition cameraPosition;

		public Interaction[] interactions;

		public bool kvb(Transform a, Transform b, RaycastHit c, Transform d, out float e)
		{
			e = default(float);
			return false;
		}
	}

	public Range[] ranges;

	public int kvh(Transform a, Transform b, RaycastHit c)
	{
		return 0;
	}

	private void kvg()
	{
	}

	public int yx(Transform a, Transform b, RaycastHit c)
	{
		return 0;
	}

	private void kve()
	{
	}

	private void kvc()
	{
	}

	private void kvf()
	{
	}

	private void kvd()
	{
	}
}
