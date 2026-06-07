using System;
using Lightbug.CharacterControllerPro.Core;
using Lightbug.Utilities;
using UnityEngine;

namespace Assets.Scripts.Character.State
{
	[Serializable]
	public class CrouchParameters
	{
		[SerializeField]
		private bool _enableCrouch = true;

		[Tooltip("This multiplier represents the crouch ratio relative to the default height.")]
		[Condition("_enableCrouch", ConditionAttribute.ConditionType.IsTrue, ConditionAttribute.VisibilityType.NotEditable, 0f)]
		[Min(0f)]
		[SerializeField]
		private float _heightRatio = 0.75f;

		[Tooltip("\"Toggle\" will activate/deactivate the action when the input is \"pressed\". \"Hold\" will activate the action when the input is pressed, and deactivate it when the input is \"released\".")]
		[Condition("_enableCrouch", ConditionAttribute.ConditionType.IsTrue, ConditionAttribute.VisibilityType.NotEditable, 0f)]
		[SerializeField]
		private InputMode _inputMode = InputMode.Hold;

		[SerializeField]
		private bool _notGroundedCrouch;

		[Tooltip("This field determines an anchor point in space (top, center or bottom) that can be used as a reference during size changes. For instance, by using \"top\" as a reference, the character will shrink/grow my moving only the bottom part of the body.")]
		[SerializeField]
		private CharacterActor.SizeReferenceType _notGroundedReference;

		[Min(0f)]
		[SerializeField]
		private float _sizeLerpSpeed = 8f;

		[Tooltip("How much the crouch action affects the movement speed?.")]
		[Condition("_enableCrouch", ConditionAttribute.ConditionType.IsTrue, ConditionAttribute.VisibilityType.NotEditable, 0f)]
		[Min(0f)]
		[SerializeField]
		private float _speedMultiplier = 0.3f;

		public bool EnableCrouch
		{
			get
			{
				return _enableCrouch;
			}
			set
			{
				_enableCrouch = value;
			}
		}

		public float HeightRatio
		{
			get
			{
				return _heightRatio;
			}
			set
			{
				_heightRatio = value;
			}
		}

		public InputMode InputMode
		{
			get
			{
				return _inputMode;
			}
			set
			{
				_inputMode = value;
			}
		}

		public bool NotGroundedCrouch
		{
			get
			{
				return _notGroundedCrouch;
			}
			set
			{
				_notGroundedCrouch = value;
			}
		}

		public CharacterActor.SizeReferenceType NotGroundedReference
		{
			get
			{
				return _notGroundedReference;
			}
			set
			{
				_notGroundedReference = value;
			}
		}

		public float SizeLerpSpeed
		{
			get
			{
				return _sizeLerpSpeed;
			}
			set
			{
				_sizeLerpSpeed = value;
			}
		}

		public float SpeedMultiplier
		{
			get
			{
				return _speedMultiplier;
			}
			set
			{
				_speedMultiplier = value;
			}
		}
	}
}
