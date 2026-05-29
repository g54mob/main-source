using JetBrains.Annotations;
using UnityEngine;

namespace FluffyUnderware.Curvy
{
	public class TransformMonitor
	{
		[NotNull]
		private readonly Transform transform;

		private Vector3 lastCheckedPosition;

		private Quaternion lastCheckedRotation;

		private Vector3 lastCheckedScale;

		private readonly bool monitorPosition;

		private readonly bool monitorRotation;

		private readonly bool monitorScale;

		public bool HasChanged { get; private set; }

		public TransformMonitor([NotNull] Transform transformToTrack, bool monitorPosition, bool monitorRotation, bool monitorScale)
		{
		}

		public void ResetMonitoring()
		{
		}

		public bool CheckForChanges()
		{
			return false;
		}

		private bool HaveGlobalCoordinatesChanged()
		{
			return false;
		}

		private void MarkCurrentTransformAsChecked()
		{
		}
	}
}
