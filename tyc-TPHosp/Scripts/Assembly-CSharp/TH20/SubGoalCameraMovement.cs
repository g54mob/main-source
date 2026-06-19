using System;
using I2.Loc;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.WithMembers)]
	public class SubGoalCameraMovement : LevelObjectiveSubGoal
	{
		[DontSave]
		private SubGoalDefinitionCameraMovement _definition;

		private float _score;

		public SubGoalCameraMovement(Objective owner, SubGoalDefinitionCameraMovement definition)
			: base(owner, definition)
		{
			_definition = definition;
		}

		public override bool IsDefinitionValid()
		{
			return base.Definition is SubGoalDefinitionCameraMovement;
		}

		public override void RestoreFromSave()
		{
			base.RestoreFromSave();
			_definition = (SubGoalDefinitionCameraMovement)base.Definition;
			if (Owner.State == Objective.ObjectiveState.Active)
			{
				switch (_definition.MovementType)
				{
				case SubGoalDefinitionCameraMovement.Type.Pan:
				{
					CameraEvents cameraEvents4 = Level.CameraEvents;
					cameraEvents4.OnCameraPan = (Action<float>)Delegate.Combine(cameraEvents4.OnCameraPan, new Action<float>(OnCameraPanned));
					break;
				}
				case SubGoalDefinitionCameraMovement.Type.Rotate:
				{
					CameraEvents cameraEvents3 = Level.CameraEvents;
					cameraEvents3.OnCameraRotate = (Action<float>)Delegate.Combine(cameraEvents3.OnCameraRotate, new Action<float>(OnCameraRotated));
					break;
				}
				case SubGoalDefinitionCameraMovement.Type.Zoom:
				{
					CameraEvents cameraEvents2 = Level.CameraEvents;
					cameraEvents2.OnCameraZoom = (Action<float>)Delegate.Combine(cameraEvents2.OnCameraZoom, new Action<float>(OnCameraZoomed));
					break;
				}
				case SubGoalDefinitionCameraMovement.Type.Pitch:
				{
					CameraEvents cameraEvents = Level.CameraEvents;
					cameraEvents.OnCameraPitch = (Action<float>)Delegate.Combine(cameraEvents.OnCameraPitch, new Action<float>(OnCameraPitched));
					break;
				}
				}
			}
		}

		protected override void OnStart()
		{
			base.OnStart();
			switch (_definition.MovementType)
			{
			case SubGoalDefinitionCameraMovement.Type.Pan:
			{
				CameraEvents cameraEvents4 = Level.CameraEvents;
				cameraEvents4.OnCameraPan = (Action<float>)Delegate.Combine(cameraEvents4.OnCameraPan, new Action<float>(OnCameraPanned));
				break;
			}
			case SubGoalDefinitionCameraMovement.Type.Rotate:
			{
				CameraEvents cameraEvents3 = Level.CameraEvents;
				cameraEvents3.OnCameraRotate = (Action<float>)Delegate.Combine(cameraEvents3.OnCameraRotate, new Action<float>(OnCameraRotated));
				break;
			}
			case SubGoalDefinitionCameraMovement.Type.Zoom:
			{
				CameraEvents cameraEvents2 = Level.CameraEvents;
				cameraEvents2.OnCameraZoom = (Action<float>)Delegate.Combine(cameraEvents2.OnCameraZoom, new Action<float>(OnCameraZoomed));
				break;
			}
			case SubGoalDefinitionCameraMovement.Type.Pitch:
			{
				CameraEvents cameraEvents = Level.CameraEvents;
				cameraEvents.OnCameraPitch = (Action<float>)Delegate.Combine(cameraEvents.OnCameraPitch, new Action<float>(OnCameraPitched));
				break;
			}
			}
		}

		protected override void OnEnd()
		{
			switch (_definition.MovementType)
			{
			case SubGoalDefinitionCameraMovement.Type.Pan:
			{
				CameraEvents cameraEvents4 = Level.CameraEvents;
				cameraEvents4.OnCameraPan = (Action<float>)Delegate.Remove(cameraEvents4.OnCameraPan, new Action<float>(OnCameraPanned));
				break;
			}
			case SubGoalDefinitionCameraMovement.Type.Rotate:
			{
				CameraEvents cameraEvents3 = Level.CameraEvents;
				cameraEvents3.OnCameraRotate = (Action<float>)Delegate.Remove(cameraEvents3.OnCameraRotate, new Action<float>(OnCameraRotated));
				break;
			}
			case SubGoalDefinitionCameraMovement.Type.Zoom:
			{
				CameraEvents cameraEvents2 = Level.CameraEvents;
				cameraEvents2.OnCameraZoom = (Action<float>)Delegate.Remove(cameraEvents2.OnCameraZoom, new Action<float>(OnCameraZoomed));
				break;
			}
			case SubGoalDefinitionCameraMovement.Type.Pitch:
			{
				CameraEvents cameraEvents = Level.CameraEvents;
				cameraEvents.OnCameraPitch = (Action<float>)Delegate.Remove(cameraEvents.OnCameraPitch, new Action<float>(OnCameraPitched));
				break;
			}
			}
			base.OnEnd();
		}

		private void OnCameraPanned(float amount)
		{
			if (_definition.MovementType == SubGoalDefinitionCameraMovement.Type.Pan)
			{
				_score += amount;
				UpdateProgress();
			}
		}

		private void OnCameraRotated(float amount)
		{
			if (_definition.MovementType == SubGoalDefinitionCameraMovement.Type.Rotate)
			{
				_score += Mathf.Abs(amount);
				UpdateProgress();
			}
		}

		private void OnCameraZoomed(float amount)
		{
			if (_definition.MovementType == SubGoalDefinitionCameraMovement.Type.Zoom)
			{
				_score += Mathf.Abs(amount);
				UpdateProgress();
			}
		}

		private void OnCameraPitched(float amount)
		{
			if (_definition.MovementType == SubGoalDefinitionCameraMovement.Type.Pitch)
			{
				_score += Mathf.Abs(amount);
				UpdateProgress();
			}
		}

		protected override bool HasCompleted()
		{
			return _score >= _definition.Threshold;
		}

		public override float PercentComplete()
		{
			return _score / _definition.Threshold;
		}

		public override int Score()
		{
			return (int)_score;
		}

		public override string ProgressText()
		{
			if (!Completed())
			{
				return string.Empty;
			}
			return ScriptLocalization.Challenges_SubGoals.Done_CS;
		}
	}
}
