using System;
using System.Collections;
using MoreMountains.Tools;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace MoreMountains.Feedbacks
{
	[Serializable]
	[AddComponentMenu("")]
	[FeedbackHelp("This feedback will let you set a property on the target renderer's material")]
	[MovedFrom(false, null, "MoreMountains.Feedbacks", null)]
	[FeedbackPath("Renderer/Material Set Property")]
	public class MMF_MaterialSetProperty : MMF_Feedback
	{
		public enum PropertyTypes
		{
			Color = 0,
			Float = 1,
			Integer = 2,
			Texture = 3,
			TextureOffset = 4,
			TextureScale = 5,
			Vector = 6
		}

		public static bool FeedbackTypeAuthorized = true;

		[MMFInspectorGroup("Material", true, 12, true, false)]
		[Tooltip("the renderer to change the material on")]
		public Renderer TargetRenderer;

		[Tooltip("the ID of the material to target on the renderer")]
		public int MaterialID;

		[Tooltip("the ID of the property to set, as exposed by the Visual Effect Graph")]
		public string PropertyID;

		[Tooltip("the type of the property to set")]
		public PropertyTypes PropertyType = PropertyTypes.Float;

		[Tooltip("if the property is a color, the new color to set")]
		[MMFEnumCondition("PropertyType", new int[] { 0 })]
		public Color NewColor = Color.red;

		[Tooltip("if the property is a float, the new float to set")]
		[MMFEnumCondition("PropertyType", new int[] { 1 })]
		public float NewFloat = 1f;

		[Tooltip("if the property is an int, the new int to set")]
		[MMFEnumCondition("PropertyType", new int[] { 2 })]
		public int NewInt;

		[Tooltip("if the property is a texture, the new texture to set")]
		[MMFEnumCondition("PropertyType", new int[] { 3 })]
		public Texture NewTexture;

		[Tooltip("if the property is a texture offset, the new offset to set")]
		[MMFEnumCondition("PropertyType", new int[] { 4 })]
		public Vector2 NewOffset;

		[Tooltip("if the property is a texture scale, the new scale to set")]
		[MMFEnumCondition("PropertyType", new int[] { 5 })]
		public Vector2 NewScale;

		[Tooltip("if the property is a vector4, the new vector4 to set")]
		[MMFEnumCondition("PropertyType", new int[] { 6 })]
		public Vector4 NewVector;

		[Header("Interpolation")]
		[Tooltip("whether or not to interpolate the value over time. If set to false, the change will be instant")]
		public bool InterpolateValue;

		[Tooltip("the duration of the interpolation")]
		[MMFCondition("InterpolateValue", true)]
		public float Duration = 2f;

		[Tooltip("the curve over which to interpolate the value")]
		[MMFCondition("InterpolateValue", true)]
		public MMTweenType InterpolationCurve = new MMTweenType(new AnimationCurve(new Keyframe(0f, 0f), new Keyframe(0.3f, 1f), new Keyframe(1f, 0f)));

		protected int _propertyID;

		protected Color _initialColor;

		protected float _initialFloat;

		protected int _initialInt;

		protected Texture _initialTexture;

		protected Vector2 _initialOffset;

		protected Vector2 _initialScale;

		protected Vector4 _initialVector;

		protected Coroutine _coroutine;

		protected Color _newColor;

		protected Vector2 _newVector2;

		protected Vector2 _newVector4;

		protected bool _hasProperty;

		public override bool HasRandomness => true;

		public override bool HasCustomInspectors => true;

		public override bool HasAutomatedTargetAcquisition => true;

		public override float FeedbackDuration
		{
			get
			{
				if (!InterpolateValue)
				{
					return 0f;
				}
				return ApplyTimeMultiplier(Duration);
			}
			set
			{
				if (InterpolateValue)
				{
					Duration = value;
				}
			}
		}

		protected override void AutomateTargetAcquisition()
		{
			TargetRenderer = FindAutomatedTarget<Renderer>();
		}

		protected override void CustomInitialization(MMF_Player owner)
		{
			base.CustomInitialization(owner);
			_propertyID = Shader.PropertyToID(PropertyID);
			_hasProperty = TargetRenderer != null && MaterialID >= 0 && MaterialID < TargetRenderer.materials.Length && TargetRenderer.materials[MaterialID].HasProperty(_propertyID);
			if (Active && _hasProperty)
			{
				Material material = TargetRenderer.materials[MaterialID];
				switch (PropertyType)
				{
				case PropertyTypes.Color:
					_initialColor = material.GetColor(_propertyID);
					break;
				case PropertyTypes.Float:
					_initialFloat = material.GetFloat(_propertyID);
					break;
				case PropertyTypes.Integer:
					_initialInt = material.GetInt(_propertyID);
					break;
				case PropertyTypes.Texture:
					_initialTexture = material.GetTexture(_propertyID);
					break;
				case PropertyTypes.TextureOffset:
					_initialOffset = material.GetTextureOffset(_propertyID);
					break;
				case PropertyTypes.TextureScale:
					_initialScale = material.GetTextureScale(_propertyID);
					break;
				case PropertyTypes.Vector:
					_initialVector = material.GetVector(_propertyID);
					break;
				}
			}
		}

		protected override void CustomPlayFeedback(Vector3 position, float feedbacksIntensity = 1f)
		{
			if (!Active || !FeedbackTypeAuthorized || TargetRenderer == null || !_hasProperty)
			{
				return;
			}
			if (InterpolateValue)
			{
				Owner.StartCoroutine(InterpolationSequence(feedbacksIntensity));
				return;
			}
			switch (PropertyType)
			{
			case PropertyTypes.Color:
				TargetRenderer.materials[MaterialID].SetColor(_propertyID, NewColor);
				break;
			case PropertyTypes.Float:
				TargetRenderer.materials[MaterialID].SetFloat(_propertyID, NewFloat);
				break;
			case PropertyTypes.Integer:
				TargetRenderer.materials[MaterialID].SetInt(_propertyID, NewInt);
				break;
			case PropertyTypes.Texture:
				TargetRenderer.materials[MaterialID].SetTexture(_propertyID, NewTexture);
				break;
			case PropertyTypes.TextureOffset:
				TargetRenderer.materials[MaterialID].SetTextureOffset(_propertyID, NewOffset);
				break;
			case PropertyTypes.TextureScale:
				TargetRenderer.materials[MaterialID].SetTextureScale(_propertyID, NewScale);
				break;
			case PropertyTypes.Vector:
				TargetRenderer.materials[MaterialID].SetVector(_propertyID, NewVector);
				break;
			}
		}

		protected virtual IEnumerator InterpolationSequence(float intensityMultiplier)
		{
			IsPlaying = true;
			float journey = (NormalPlayDirection ? 0f : FeedbackDuration);
			while (journey >= 0f && journey <= FeedbackDuration && FeedbackDuration > 0f)
			{
				float t = MMFeedbacksHelpers.Remap(journey, 0f, FeedbackDuration, 0f, 1f);
				SetValueAtTime(t, intensityMultiplier);
				journey += (NormalPlayDirection ? FeedbackDeltaTime : (0f - FeedbackDeltaTime));
				yield return null;
			}
			SetValueAtTime(FinalNormalizedTime, intensityMultiplier);
			_coroutine = null;
			IsPlaying = false;
			yield return null;
		}

		protected virtual void SetValueAtTime(float t, float intensityMultiplier)
		{
			switch (PropertyType)
			{
			case PropertyTypes.Color:
			{
				float t2 = MMTween.Tween(t, 0f, 1f, _initialFloat, NewFloat, InterpolationCurve);
				_newColor = Color.Lerp(_initialColor, NewColor, t2);
				TargetRenderer.materials[MaterialID].SetColor(_propertyID, _newColor);
				break;
			}
			case PropertyTypes.Float:
			{
				float value2 = MMTween.Tween(t, 0f, 1f, _initialFloat, NewFloat, InterpolationCurve);
				TargetRenderer.materials[MaterialID].SetFloat(_propertyID, value2);
				break;
			}
			case PropertyTypes.Integer:
			{
				int value = (int)MMTween.Tween(t, 0f, 1f, _initialInt, NewInt, InterpolationCurve);
				TargetRenderer.materials[MaterialID].SetInt(_propertyID, value);
				break;
			}
			case PropertyTypes.Texture:
				TargetRenderer.materials[MaterialID].SetTexture(_propertyID, NewTexture);
				break;
			case PropertyTypes.TextureOffset:
				_newVector2 = MMTween.Tween(t, 0f, 1f, _initialOffset, NewOffset, InterpolationCurve);
				TargetRenderer.materials[MaterialID].SetTextureOffset(_propertyID, _newVector2);
				break;
			case PropertyTypes.TextureScale:
				_newVector2 = MMTween.Tween(t, 0f, 1f, _initialScale, NewScale, InterpolationCurve);
				TargetRenderer.materials[MaterialID].SetTextureScale(_propertyID, _newVector2);
				break;
			case PropertyTypes.Vector:
				_newVector4 = MMTween.Tween(t, 0f, 1f, _initialVector, NewVector, InterpolationCurve);
				TargetRenderer.materials[MaterialID].SetVector(_propertyID, _newVector4);
				break;
			}
		}

		protected override void CustomStopFeedback(Vector3 position, float feedbacksIntensity = 1f)
		{
			if (Active && FeedbackTypeAuthorized && _coroutine != null)
			{
				base.CustomStopFeedback(position, feedbacksIntensity);
				IsPlaying = false;
				Owner.StopCoroutine(_coroutine);
				_coroutine = null;
			}
		}

		protected override void CustomRestoreInitialValues()
		{
			if (Active && FeedbackTypeAuthorized && _hasProperty && !(TargetRenderer == null))
			{
				Material material = TargetRenderer.materials[MaterialID];
				switch (PropertyType)
				{
				case PropertyTypes.Color:
					material.SetColor(_propertyID, _initialColor);
					break;
				case PropertyTypes.Float:
					material.SetFloat(_propertyID, _initialFloat);
					break;
				case PropertyTypes.Integer:
					material.SetInt(_propertyID, _initialInt);
					break;
				case PropertyTypes.Texture:
					material.SetTexture(_propertyID, _initialTexture);
					break;
				case PropertyTypes.TextureOffset:
					material.SetTextureOffset(_propertyID, _initialOffset);
					break;
				case PropertyTypes.TextureScale:
					material.SetTextureScale(_propertyID, _initialScale);
					break;
				case PropertyTypes.Vector:
					material.SetVector(_propertyID, _initialVector);
					break;
				}
			}
		}
	}
}
