using System.Collections.Generic;
using UnityEngine;

namespace MoreMountains.Feedbacks
{
	[AddComponentMenu("More Mountains/Feedbacks/Shakers/Various/MMBlink")]
	public class MMBlink : MonoBehaviour
	{
		public enum States
		{
			On = 0,
			Off = 1
		}

		public enum Methods
		{
			SetGameObjectActive = 0,
			MaterialAlpha = 1,
			MaterialEmissionIntensity = 2,
			ShaderFloatValue = 3
		}

		[Header("Blink Method")]
		[Tooltip("the selected method to blink the target object")]
		public Methods Method;

		[Tooltip("the object to set active/inactive if that method was chosen")]
		[MMFEnumCondition("Method", new int[] { 0 })]
		public GameObject TargetGameObject;

		[MMFEnumCondition("Method", new int[] { 1, 2, 3 })]
		[Tooltip("the target renderer to work with")]
		public Renderer TargetRenderer;

		[MMFEnumCondition("Method", new int[] { 1, 2, 3 })]
		[Tooltip("the shader property to alter a float on")]
		public string ShaderPropertyName;

		[Tooltip("the value to apply when blinking is off")]
		[MMFEnumCondition("Method", new int[] { 1, 2, 3 })]
		public float OffValue;

		[Tooltip("the value to apply when blinking is on")]
		[MMFEnumCondition("Method", new int[] { 1, 2, 3 })]
		public float OnValue;

		[Tooltip("whether to lerp these values or not")]
		[MMFEnumCondition("Method", new int[] { 1, 2, 3 })]
		public bool LerpValue;

		[Tooltip("the curve to apply to the lerping")]
		[MMFEnumCondition("Method", new int[] { 1, 2, 3 })]
		public AnimationCurve Curve;

		[Tooltip("if this is true, this component will use material property blocks instead of working on an instance of the material.")]
		public bool UseMaterialPropertyBlocks;

		[Header("State")]
		[Tooltip("whether the object should blink or not")]
		public bool Blinking;

		[Tooltip("whether or not to force a certain state on exit")]
		public bool ForceStateOnExit;

		[Tooltip("the state to apply on exit")]
		[MMFCondition("ForceStateOnExit", true)]
		public States StateOnExit;

		[Tooltip("whether or not this MMBlink should operate on unscaled time")]
		[Header("Timescale")]
		public TimescaleModes TimescaleMode;

		[Tooltip("how many times the sequence should repeat (-1 : infinite)")]
		[Header("Sequence")]
		public int RepeatCount;

		[Tooltip("The list of phases to apply blinking with")]
		public List<BlinkPhase> Phases;

		[Tooltip("Test button")]
		[MMFInspectorButton("ToggleBlinking")]
		[Header("Debug")]
		public bool ToggleBlinkingButton;

		[MMFInspectorButton("StartBlinking")]
		[Tooltip("Test button")]
		public bool StartBlinkingButton;

		[Tooltip("Test button")]
		[MMFInspectorButton("StopBlinking")]
		public bool StopBlinkingButton;

		[Tooltip("is the blinking object in an active state right now?")]
		[MMFReadOnly]
		public bool Active;

		[Tooltip("the index of the phase we're currently in")]
		[MMFReadOnly]
		public int CurrentPhaseIndex;

		protected float _lastBlinkAt;

		protected float _currentPhaseStartedAt;

		protected float _currentBlinkDuration;

		protected float _currentLerpDuration;

		protected int _propertyID;

		protected float _initialShaderFloatValue;

		protected Color _initialColor;

		protected Color _currentColor;

		protected int _repeatCount;

		protected MaterialPropertyBlock _propertyBlock;

		public virtual float Duration => 0f;

		public virtual float GetTime()
		{
			return 0f;
		}

		public virtual float GetDeltaTime()
		{
			return 0f;
		}

		public virtual void ToggleBlinking()
		{
		}

		public virtual void StartBlinking()
		{
		}

		public virtual void StopBlinking()
		{
		}

		protected virtual void Update()
		{
		}

		protected virtual void DetermineState()
		{
		}

		protected virtual void Blink()
		{
		}

		protected virtual void ApplyBlink(bool active, float value)
		{
		}

		protected virtual void DetermineCurrentPhase()
		{
		}

		protected virtual void OnEnable()
		{
		}

		protected virtual void InitializeBlinkProperties()
		{
		}

		protected virtual void ResetBlinkProperties()
		{
		}

		protected void OnDisable()
		{
		}
	}
}
