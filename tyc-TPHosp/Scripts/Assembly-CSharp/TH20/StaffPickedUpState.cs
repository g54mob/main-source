using System;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature)]
	public class StaffPickedUpState : EntityTickComponent
	{
		private const string ExitState = "Exit";

		private const string ExitFlag = "Exit";

		private const string ImmediateFlag = "Immediate";

		private const float Gravity = -0.98f;

		private const float Mass = 4f;

		private const float ConstraintLength = 2f;

		private const float FixedTimeStep = 0.016f;

		private const float VelocityDamp = 0.95f;

		private const float PositionDampTime = 0.005f;

		private const float RotationDampTime = 40f;

		private Action _completeCallback;

		private bool _exiting;

		private float _remainingTime;

		private Vector3 _position;

		private Vector3 _lastPosition;

		private Vector3 _desiredPosition;

		private Quaternion _desiredRotation;

		private float _rotationDampTime;

		private Vector3 _positionDampVelocity = Vector3.zero;

		private float _dizzyTime;

		private DisableReactionsComponent _disableReactionsComponent;

		private Vector3 _originalPosition;

		private float _originalRotation;

		private bool _newCharacter;

		private StatusIcon.Type _statusIcon;

		public bool Exiting => _exiting;

		protected override Type ValidEntityType()
		{
			return typeof(Staff);
		}

		internal override void InitializeComponent()
		{
			base.InitializeComponent();
			Staff owner = GetOwner<Staff>();
			owner.Interrupt();
			if (owner.SatisfyNeedsComponent != null)
			{
				owner.SatisfyNeedsComponent.Interrupt();
			}
			owner.NavPath.RemoveFromNavWorld();
			owner.Interruptable = false;
			owner.RemoveComponents<LookAtComponent>();
			owner.RemoveComponents<StaffFailedToStartJobComponent>();
			_disableReactionsComponent = owner.AddComponent<DisableReactionsComponent>();
			owner.PushAnimationGraph(owner.GetPickedUpAnimGraph());
			owner.Animator.updateMode = AnimatorUpdateMode.UnscaledTime;
			owner.Level.CameraLogic.TrackObject(null);
			_originalPosition = owner.Position;
			_originalRotation = owner.RotationY;
			_statusIcon = base.Level.StatusIconManager.GetActiveStatusIconType(owner);
			if (_statusIcon != StatusIcon.Type.Invalid)
			{
				base.Level.StatusIconManager.DestroyStatusIcon(owner);
			}
			owner.Visual.RestoreCustomisationOptionOnHold(owner);
		}

		public void Start(Vector3 pickupPosition, bool immediate, Action completeCallback, bool newCharacter)
		{
			Staff owner = GetOwner<Staff>();
			owner.Visual.EnableUpdateWhenOffscreen();
			_completeCallback = completeCallback;
			if (immediate)
			{
				owner.GameObject.transform.position = pickupPosition;
			}
			_remainingTime = 0f;
			_desiredPosition = owner.GameObject.transform.position;
			_desiredRotation = owner.GameObject.transform.rotation;
			_lastPosition = _desiredPosition;
			SetPosition(pickupPosition);
			SetBool("Immediate", immediate);
			_newCharacter = newCharacter;
		}

		public void SetPosition(Vector3 position)
		{
			_position = position + Vector3.up * 2f;
		}

		private bool Finished()
		{
			Staff owner = GetOwner<Staff>();
			if (_exiting && owner.Animator.GetCurrentAnimatorStateInfo(0).IsName("Exit"))
			{
				owner.Visual.DisableUpdateWhenOffscreen();
				owner.GameObject.transform.position = _desiredPosition;
				owner.GameObject.transform.rotation = _desiredRotation;
				return true;
			}
			return false;
		}

		public void PlaceInWorld()
		{
			Staff staff = GetOwner<Staff>();
			if (staff == null)
			{
				return;
			}
			_disableReactionsComponent.Destroy();
			staff.Interruptable = true;
			staff.PopAnimationGraph(staff.GetPickedUpAnimGraph(), 0f);
			staff.Animator.updateMode = AnimatorUpdateMode.Normal;
			staff.Animator.Update(GameTime.unscaledDeltaTime);
			staff.NavPath.PutBackInNavWorld();
			staff.Resume();
			if (_statusIcon == StatusIcon.Type.Invalid)
			{
				return;
			}
			if (base.Level.StatusIconManager != null)
			{
				base.Level.StatusIconManager.ShowStatusIcon(staff, _statusIcon);
				return;
			}
			Level level = base.Level;
			level.PostConstruct = (Action)Delegate.Combine(level.PostConstruct, (Action)delegate
			{
				base.Level.StatusIconManager.ShowStatusIcon(staff, _statusIcon);
			});
		}

		public void RequestExit()
		{
			_exiting = true;
			_desiredPosition = _position - Vector3.up * 2f;
			SetBool("Exit", immediate: true);
		}

		public void CancelExit()
		{
			Staff owner = GetOwner<Staff>();
			_exiting = false;
			SetBool("Exit", immediate: false);
			SetBool("Immediate", immediate: false);
			_desiredPosition = owner.GameObject.transform.position;
			_desiredRotation = owner.GameObject.transform.rotation;
			_lastPosition = _desiredPosition;
		}

		private void SetBool(string flag, bool immediate)
		{
			Staff owner = GetOwner<Staff>();
			if (owner.Animator.HasParameter(flag))
			{
				owner.Animator.SetBool(flag, immediate);
			}
		}

		public override void Tick()
		{
			Staff owner = GetOwner<Staff>();
			StaffDefinition definition = owner.Definition;
			float num = Time.unscaledDeltaTime;
			float smoothTime = 0.005f;
			float num2 = 40f;
			if (_exiting)
			{
				num2 = 0f;
				_desiredRotation = Quaternion.Euler(0f, owner.RotationY, 0f);
				if (Finished())
				{
					if (_dizzyTime > definition.DizzyEffectTime && owner.Definition.DizzyStatusEffect != null && owner.ModifiersComponent != null)
					{
						owner.ModifiersComponent.AddStatusEffect(owner.Definition.DizzyStatusEffect.Instance);
					}
					PlaceInWorld();
					Destroy();
					_completeCallback.InvokeSafe();
					return;
				}
			}
			else
			{
				num += _remainingTime;
				int num3 = (int)Mathf.Floor(num / 0.016f);
				_remainingTime = num - (float)num3 * 0.016f;
				for (float num4 = 0f; num4 < (float)num3; num4 += 1f)
				{
					Vector3 vector = _desiredPosition - _position;
					float num5 = 2f - vector.magnitude;
					vector /= vector.magnitude;
					_desiredPosition += vector * num5;
					_desiredPosition.y = Mathf.Min(_desiredPosition.y, 2f);
					Vector3 vector2 = _desiredPosition - _lastPosition;
					vector2 *= 0.95f;
					vector2.y += -0.06272f;
					_lastPosition = _desiredPosition;
					_desiredPosition += vector2;
					if (vector2.magnitude > definition.DizzyVelocity)
					{
						_dizzyTime += definition.DizzyIncrement;
					}
				}
				_desiredRotation = Quaternion.FromToRotation(Vector3.up, Vector3.Normalize(_position - _desiredPosition));
				float y = MathUtils.YawRotation(Camera.main.transform.forward);
				_desiredRotation *= Quaternion.Euler(0f, y, 0f);
			}
			_rotationDampTime += (num2 - _rotationDampTime) * num;
			owner.GameObject.transform.position = Vector3.SmoothDamp(owner.GameObject.transform.position, _desiredPosition, ref _positionDampVelocity, smoothTime, float.PositiveInfinity, num);
			owner.GameObject.transform.rotation = Quaternion.Slerp(owner.GameObject.transform.rotation, _desiredRotation, _rotationDampTime * num);
			if (_dizzyTime > 0f)
			{
				_dizzyTime = Mathf.Max(_dizzyTime - definition.DizzyDecrement * num, 0f);
			}
		}

		public void AbortPickup()
		{
			Staff owner = GetOwner<Staff>();
			Level level = base.Level;
			if (_newCharacter)
			{
				level.CharacterManager.DestroyCharacter(owner);
				return;
			}
			Room roomAtWorldCoord = level.WorldState.GetRoomAtWorldCoord(_originalPosition, includeHospital: true, includeClosedPlots: false);
			owner.Position = _originalPosition;
			owner.RotationY = _originalRotation;
			owner.ForceUpdateRoomUsing(roomAtWorldCoord);
			PlaceInWorld();
			Destroy();
			level.CharacterEvents.OnStaffDrop.InvokeSafe(owner, roomAtWorldCoord, param3: false);
		}
	}
}
