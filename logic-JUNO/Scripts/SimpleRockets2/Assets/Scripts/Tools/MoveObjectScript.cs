using System;
using ModApi;
using UnityEngine;

namespace Assets.Scripts.Tools
{
	public class MoveObjectScript : MonoBehaviour
	{
		private Quaternion _currDestinationObjectRotation;

		private bool _lastFramePanning;

		private Quaternion _startingObjectRotation;

		private float _timeElapsedPanning;

		public Transform CameraTarget { get; set; }

		public Vector3? DestinationPanPosition { get; set; }

		public Vector3? DestinationPanUp { get; set; }

		public bool IsInterruptable { get; set; }

		public bool IsPanningFocusACameraTarget { get; set; }

		public bool ObjectIsPanning
		{
			get
			{
				if (DestinationPanPosition.HasValue)
				{
					if (Utilities.CompareVector3s(base.transform.position, DestinationPanPosition.Value, 0.01f))
					{
						return !Utilities.CompareQuaternions(Utilities.Abs(base.transform.rotation), Utilities.Abs(_currDestinationObjectRotation), 0.01f);
					}
					return true;
				}
				return false;
			}
		}

		public Action<MoveObjectScript> PanningCompleteAction { get; set; }

		public Vector3 PanningFocus { get; set; }

		public Vector3? StartingPanPosition { get; set; }

		public Vector3? StartingPanUp { get; set; }

		public float TimeToFinishPanning { get; set; }

		public float TimeToFinishPanningReset { get; set; }

		public Vector3? UpVectorWhenInterrupted { get; set; }

		public MoveObjectScript()
		{
			TimeToFinishPanningReset = 0.5f;
			DestinationPanUp = Vector3.up;
			StartingPanUp = Vector3.up;
		}

		public void ResetPanning()
		{
			if (!ObjectIsPanning || IsInterruptable)
			{
				StartingPanPosition = null;
				StartingPanUp = null;
				PanningCompleteAction = null;
				DestinationPanUp = null;
				CameraTarget = null;
				UpVectorWhenInterrupted = null;
				DestinationPanPosition = null;
				IsInterruptable = true;
				IsPanningFocusACameraTarget = false;
				_lastFramePanning = false;
				_currDestinationObjectRotation = Quaternion.identity;
				TimeToFinishPanning = 1f;
				TimeToFinishPanningReset = 1f;
				_timeElapsedPanning = 0f;
			}
		}

		public void Update()
		{
			if (ObjectIsPanning)
			{
				if (!_lastFramePanning)
				{
					if (IsPanningFocusACameraTarget)
					{
						UpdateCameraTarget();
					}
					if (!StartingPanPosition.HasValue)
					{
						StartingPanPosition = base.transform.position;
					}
					if (!StartingPanUp.HasValue)
					{
						StartingPanUp = base.transform.up;
					}
					if (!DestinationPanUp.HasValue)
					{
						DestinationPanUp = Vector3.up;
					}
					_startingObjectRotation = base.transform.rotation;
					base.transform.LookAt(PanningFocus, DestinationPanUp.Value);
					_currDestinationObjectRotation = base.transform.rotation;
					base.transform.rotation = _startingObjectRotation;
				}
				_timeElapsedPanning += Time.deltaTime;
				Vector3 position = Vector3.Lerp(StartingPanPosition.Value, DestinationPanPosition.Value, _timeElapsedPanning / TimeToFinishPanning);
				base.transform.LookAt(PanningFocus, DestinationPanUp.Value);
				_currDestinationObjectRotation = base.transform.rotation;
				Quaternion rotation = Quaternion.Lerp(_startingObjectRotation, _currDestinationObjectRotation, _timeElapsedPanning / TimeToFinishPanning);
				base.transform.rotation = rotation;
				base.transform.position = position;
				_lastFramePanning = true;
			}
			else if (_lastFramePanning)
			{
				if (PanningCompleteAction != null)
				{
					PanningCompleteAction(this);
				}
				ResetPanning();
			}
		}

		private void UpdateCameraTarget()
		{
			if (CameraTarget != null)
			{
				Vector3 position = base.transform.position;
				CameraTarget.position = PanningFocus;
				base.transform.position = position;
				return;
			}
			throw new InvalidOperationException("IsPanningFocusACameraTarget is true, but CameraTarget is null");
		}
	}
}
