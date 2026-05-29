using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using FluffyUnderware.DevTools;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace FluffyUnderware.Curvy
{
	[ExecuteInEditMode]
	[HelpURL("https://curvyeditor.com/doclink/curvyconnection")]
	public class CurvyConnection : DTVersionedMonoBehaviour, ISerializationCallbackReceiver
	{
		private class TransformSynchronizer
		{
			[NotNull]
			private readonly CurvyConnection connection;

			[CanBeNull]
			private TransformMonitor connectionMonitor;

			[NotNull]
			private readonly Dictionary<CurvySplineSegment, (Vector3, Quaternion)> monitoredCPCoordinated;

			[NotNull]
			private TransformMonitor ConnectionMonitor => null;

			private bool IsCPsMonitorValid => false;

			public TransformSynchronizer([NotNull] CurvyConnection connection)
			{
			}

			public void OnControlPointsUpdated()
			{
			}

			public void OnUpdate()
			{
			}

			private void EnsureCPsMonitorIsValid()
			{
			}

			private void GetMonitorChanges(out Vector3? positionChange, out Quaternion? rotationChange)
			{
				positionChange = null;
				rotationChange = null;
			}

			private bool GetConnectionMonitorChanges(out Vector3? positionChange, out Quaternion? rotationChange)
			{
				positionChange = null;
				rotationChange = null;
				return false;
			}

			private void GetCPsMonitorChanges(out Vector3? position, out Quaternion? rotation)
			{
				position = null;
				rotation = null;
			}

			private void GetCPMonitorChanges([NotNull] CurvySplineSegment controlPoint, out Vector3? position, out Quaternion? rotation)
			{
				position = null;
				rotation = null;
			}

			private void IsCPTriggeringTransformChange([NotNull] CurvySplineSegment controlPoint, out bool syncPosition, out bool syncRotation)
			{
				syncPosition = default(bool);
				syncRotation = default(bool);
			}

			public void ApplyTransform(Vector3 position, Quaternion rotation)
			{
			}

			private void ApplyTransformToConnection(Vector3 position, Quaternion rotation)
			{
			}

			private void ApplyTransformToCPs(Vector3 referencePosition, Quaternion referenceRotation)
			{
			}

			public void ResetMonitoring()
			{
			}

			[UsedImplicitly]
			private void ResetConnectionMonitoring()
			{
			}

			[UsedImplicitly]
			private void ResetCPsMonitoring()
			{
			}
		}

		private class UndoFixer
		{
			private readonly CurvyConnection curvyConnection;

			public UndoFixer(CurvyConnection curvyConnection)
			{
			}

			public void FixIssuesIntroducedByUndoing()
			{
			}
		}

		[SerializeField]
		[Hide]
		private List<CurvySplineSegment> m_ControlPoints;

		private ReadOnlyCollection<CurvySplineSegment> readOnlyControlPoints;

		[NotNull]
		private readonly TransformSynchronizer transformSynchronizer;

		[NotNull]
		private readonly UndoFixer undoFixer;

		public ReadOnlyCollection<CurvySplineSegment> ControlPointsList => null;

		public int Count => 0;

		public CurvySplineSegment this[int idx] => null;

		protected override void OnEnable()
		{
		}

		protected override void OnDisable()
		{
		}

		[UsedImplicitly]
		private void Update()
		{
		}

		[UsedImplicitly]
		private void LateUpdate()
		{
		}

		[UsedImplicitly]
		private void FixedUpdate()
		{
		}

		[UsedImplicitly]
		private void OnDestroy()
		{
		}

		public static CurvyConnection Create(params CurvySplineSegment[] controlPoints)
		{
			return null;
		}

		public void AddControlPoints(params CurvySplineSegment[] controlPoints)
		{
		}

		public void AutoSetFollowUp()
		{
		}

		public void RemoveControlPoint(CurvySplineSegment controlPoint, bool destroySelfIfEmpty = true)
		{
		}

		public void Delete()
		{
		}

		[Obsolete("Inline the method's body if needed")]
		public List<CurvySplineSegment> OtherControlPoints(CurvySplineSegment source)
		{
			return null;
		}

		public void SetSynchronisationPositionAndRotation(Vector3 referencePosition, Quaternion referenceRotation)
		{
		}

		public void OnBeforeSerialize()
		{
		}

		public void OnAfterDeserialize()
		{
		}

		private void RemoveNullCPs()
		{
		}

		private void DoUpdate()
		{
		}

		private void OnSceneLoaded(Scene arg0, LoadSceneMode arg1)
		{
		}

		protected override void ResetOnEnable()
		{
		}
	}
}
