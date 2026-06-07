using System;
using Lightbug.Utilities;
using UnityEngine;

namespace Assets.Scripts.Character.State
{
	[Serializable]
	public class VerticalMovementParameters
	{
		public enum UnstableJumpMode
		{
			Vertical = 0,
			GroundNormal = 1
		}

		[Tooltip("The gravity magnitude and the jump speed will be automatically calculated based on the jump apex height and duration. Set this to false if you want to manually set those values.")]
		[SerializeField]
		private bool _autoCalculate = true;

		[Min(0f)]
		[Tooltip("Number of jumps available for the character in the air.")]
		[SerializeField]
		private int _availableNotGroundedJumps = 1;

		[Tooltip("When canceling the jump (releasing the action), if the jump time is less than this value (and greater than the \"min time\") the velocity will be affected.")]
		[SerializeField]
		private float _cancelJumpMaxTime = 0.3f;

		[Tooltip("When canceling the jump (releasing the action), if the jump time is less than this value nothing is going to happen. Only when the timer is greater than this \"min time\" the jump will be affected.")]
		[SerializeField]
		private float _cancelJumpMinTime = 0.1f;

		[Tooltip("How much the vertical velocity is reduced when canceling the jump (0 = no effect, 1 = zero velocity).")]
		[Range(0f, 1f)]
		[SerializeField]
		private float _cancelJumpMultiplier = 0.5f;

		[Tooltip("Reduces the vertical velocity when the jump action is canceled.")]
		[SerializeField]
		private bool _cancelJumpOnRelease = true;

		[SerializeField]
		private bool _canJump = true;

		[SerializeField]
		private bool _canJumpDown = true;

		[SerializeField]
		private bool _canJumpOnUnstableGround;

		[SerializeField]
		private bool _filterByTag;

		[Condition("autoCalculate", ConditionAttribute.ConditionType.IsFalse, ConditionAttribute.VisibilityType.NotEditable, 0f)]
		[SerializeField]
		private float _gravity = 9.81f;

		[Condition("autoCalculate", ConditionAttribute.ConditionType.IsTrue, ConditionAttribute.VisibilityType.NotEditable, 0f)]
		[Tooltip("The amount of time to reach the \"base height\" (apex).")]
		[Min(0f)]
		[SerializeField]
		private float _jumpApexDuration = 0.5f;

		[Condition("autoCalculate", ConditionAttribute.ConditionType.IsTrue, ConditionAttribute.VisibilityType.NotEditable, 0f)]
		[Tooltip("The height reached at the apex of the jump. The maximum height will depend on the \"jumpCancellationMode\".")]
		[Min(0f)]
		[SerializeField]
		private float _jumpApexHeight = 2.25f;

		[Min(0f)]
		[SerializeField]
		private float _jumpDownDistance = 0.05f;

		private string _jumpDownTag = "JumpDown";

		[Min(0f)]
		[SerializeField]
		private float _jumpDownVerticalVelocity = 0.5f;

		[Condition("autoCalculate", ConditionAttribute.ConditionType.IsFalse, ConditionAttribute.VisibilityType.NotEditable, 0f)]
		[SerializeField]
		private float _jumpSpeed = 10f;

		[Tooltip("If the character is not grounded, and the \"not grounded time\" is less or equal than this value, the jump action will be performed as a grounded jump. This is also known as \"coyote time\".")]
		[Min(0f)]
		[SerializeField]
		private float _postGroundedJumpTime = 0.1f;

		[Tooltip("This will help to perform the jump action after the actual input has been started. This value determines the maximum time between input and ground detection.")]
		[Min(0f)]
		[SerializeField]
		private float _preGroundedJumpTime = 0.2f;

		[Tooltip("It enables/disables gravity. The gravity value is calculated based on the jump apex height and duration.")]
		[SerializeField]
		private bool _useGravity = true;

		public bool AutoCalculate
		{
			get
			{
				return _autoCalculate;
			}
			set
			{
				_autoCalculate = value;
			}
		}

		public int AvailableNotGroundedJumps
		{
			get
			{
				return _availableNotGroundedJumps;
			}
			set
			{
				_availableNotGroundedJumps = value;
			}
		}

		public float CancelJumpMinTime
		{
			get
			{
				return _cancelJumpMinTime;
			}
			set
			{
				_cancelJumpMinTime = value;
			}
		}

		public float CancelJumpMultiplier
		{
			get
			{
				return _cancelJumpMultiplier;
			}
			set
			{
				_cancelJumpMultiplier = value;
			}
		}

		public bool CancelJumpOnRelease
		{
			get
			{
				return _cancelJumpOnRelease;
			}
			set
			{
				_cancelJumpOnRelease = value;
			}
		}

		public float CancelJumpMaxTime
		{
			get
			{
				return _cancelJumpMaxTime;
			}
			set
			{
				_cancelJumpMaxTime = value;
			}
		}

		public bool CanJump
		{
			get
			{
				return _canJump;
			}
			set
			{
				_canJump = value;
			}
		}

		public bool CanJumpDown
		{
			get
			{
				return _canJumpDown;
			}
			set
			{
				_canJumpDown = value;
			}
		}

		public bool CanJumpOnUnstableGround
		{
			get
			{
				return _canJumpOnUnstableGround;
			}
			set
			{
				_canJumpOnUnstableGround = value;
			}
		}

		public bool FilterByTag
		{
			get
			{
				return _filterByTag;
			}
			set
			{
				_filterByTag = value;
			}
		}

		public float Gravity
		{
			get
			{
				return _gravity;
			}
			set
			{
				_gravity = value;
			}
		}

		public float JumpApexDuration
		{
			get
			{
				return _jumpApexDuration;
			}
			set
			{
				_jumpApexDuration = value;
			}
		}

		public float JumpApexHeight
		{
			get
			{
				return _jumpApexHeight;
			}
			set
			{
				_jumpApexHeight = value;
			}
		}

		public float JumpDownDistance
		{
			get
			{
				return _jumpDownDistance;
			}
			set
			{
				_jumpDownDistance = value;
			}
		}

		public string JumpDownTag
		{
			get
			{
				return _jumpDownTag;
			}
			set
			{
				_jumpDownTag = value;
			}
		}

		public float JumpDownVerticalVelocity
		{
			get
			{
				return _jumpDownVerticalVelocity;
			}
			set
			{
				_jumpDownVerticalVelocity = value;
			}
		}

		public float JumpSpeed
		{
			get
			{
				return _jumpSpeed;
			}
			set
			{
				_jumpSpeed = value;
			}
		}

		public float PostGroundedJumpTime
		{
			get
			{
				return _postGroundedJumpTime;
			}
			set
			{
				_postGroundedJumpTime = value;
			}
		}

		public float PreGroundedJumpTime
		{
			get
			{
				return _preGroundedJumpTime;
			}
			set
			{
				_preGroundedJumpTime = value;
			}
		}

		public bool UseGravity
		{
			get
			{
				return _useGravity;
			}
			set
			{
				_useGravity = value;
			}
		}

		public void OnValidate()
		{
			if (_autoCalculate)
			{
				_gravity = 2f * _jumpApexHeight / Mathf.Pow(_jumpApexDuration, 2f);
				_jumpSpeed = _gravity * _jumpApexDuration;
			}
			else
			{
				_jumpApexDuration = _jumpSpeed / _gravity;
				_jumpApexHeight = _gravity * Mathf.Pow(_jumpApexDuration, 2f) / 2f;
			}
		}

		public void UpdateParameters()
		{
			if (_autoCalculate)
			{
				_gravity = 2f * _jumpApexHeight / Mathf.Pow(_jumpApexDuration, 2f);
				_jumpSpeed = _gravity * _jumpApexDuration;
			}
		}
	}
}
