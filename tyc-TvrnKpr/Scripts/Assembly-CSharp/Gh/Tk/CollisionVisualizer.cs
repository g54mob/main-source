using System;
using System.Collections.Generic;
using UnityEngine;

namespace Gh.Tk
{
	[RequireComponent(typeof(CollisionDetector))]
	public class CollisionVisualizer : MonoBehaviour
	{
		private bool _collidingIsAllowed;

		private bool _isDirty;

		private readonly Dictionary<CollisionDetector, CollisionVisualizer> _createdVisualizers;

		private readonly List<GameObject> _obstructedWireframes;

		private CollisionDetector _collisionDetector;

		public bool ShouldAddCollisionVisualizerToCollidingObjects { get; set; }

		public void MarkDirty()
		{
		}

		private void UpdateCreatedVisualizers()
		{
		}

		private void ClearCreatedVisualizers()
		{
		}

		private void Start()
		{
		}

		private void OnCollisionsUpdated(object sender, EventArgs e)
		{
		}

		private void LateUpdate()
		{
		}

		private void Refresh()
		{
		}

		private void UpdateVisual()
		{
		}

		private void OnDestroy()
		{
		}

		private void InitVisual()
		{
		}
	}
}
