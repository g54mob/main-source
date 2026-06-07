using System.Collections.Generic;
using UnityEngine;

namespace Gh.Tk
{
	[RequireComponent(typeof(Collider))]
	public class FloorYOffset : MonoBehaviour
	{
		public static readonly List<FloorYOffset> AllFloorYOffsets;

		public float yOffset;

		private Collider _collider;

		private void OnEnable()
		{
		}

		private void Start()
		{
		}

		private void OnDisable()
		{
		}

		public bool IsInsideCollider(Vector3 position)
		{
			return false;
		}
	}
}
