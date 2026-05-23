using System;
using System.Linq;
using UnityEngine;

namespace Barmetler.RoadSystem
{
	[SelectionBase]
	public class Intersection : MonoBehaviour
	{
		[SerializeField]
		[HideInInspector]
		private RoadAnchor[] anchorPoints = Array.Empty<RoadAnchor>();

		[SerializeField]
		[HideInInspector]
		private float radius;

		public RoadAnchor[] AnchorPoints => anchorPoints;

		public float Radius => radius;

		private void OnValidate()
		{
			anchorPoints = GetComponentsInChildren<RoadAnchor>();
			radius = Mathf.Sqrt((anchorPoints.Length != 0) ? anchorPoints.Select((RoadAnchor e) => (e.transform.position - base.transform.position).sqrMagnitude).Max() : 0f);
		}

		private void Awake()
		{
			OnValidate();
		}

		public void Invalidate(bool updateMesh = true)
		{
			OnValidate();
			RoadAnchor[] array = anchorPoints;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].Invalidate();
			}
		}
	}
}
