using MoreMountains.Feedbacks;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;
using UnityEngine.VFX;

namespace MoreMountains.FeedbacksForThirdParty
{
	[AddComponentMenu("")]
	[FeedbackHelp("This feedback will let you set a property on a target VisualEffect")]
	[FeedbackPath("Particles/VisualEffectSetProperty")]
	[MovedFrom(false, null, "MoreMountains.Feedbacks.VisualEffectGraph", null)]
	public class MMF_VisualEffectSetProperty : MMF_Feedback
	{
		public enum PropertyTypes
		{
			AnimationCurve = 0,
			Bool = 1,
			Float = 2,
			Gradient = 3,
			Int = 4,
			Mesh = 5,
			Texture = 6,
			UInt = 7,
			Vector2 = 8,
			Vector3 = 9,
			Vector4 = 10
		}

		public static bool FeedbackTypeAuthorized = true;

		[MMFInspectorGroup("Visual Effect Property", true, 41, false, false)]
		[Tooltip("the duration for the player to consider. This won't impact your visual effect, but is a way to communicate to the MMF Player the duration of this feedback. Usually you'll want it to match your actual particle system, and setting it can be useful to have this feedback work with holding pauses.")]
		public float DeclaredDuration;

		[Tooltip("the visual effect on which to set a property")]
		public VisualEffect TargetVisualEffect;

		[Tooltip("the ID of the property to set, as exposed by the Visual Effect Graph")]
		public string PropertyID;

		[Tooltip("the type of the property to set")]
		public PropertyTypes PropertyType = PropertyTypes.Float;

		[Tooltip("if the property is an animation curve, the new animation curve to set")]
		[MMFEnumCondition("PropertyType", new int[] { 0 })]
		public AnimationCurve NewAnimationCurve = new AnimationCurve(new Keyframe(0f, 0f), new Keyframe(0.5f, 1f), new Keyframe(1f, 0f));

		[Tooltip("if the property is a bool, the new bool to set")]
		[MMFEnumCondition("PropertyType", new int[] { 1 })]
		public bool NewBool = true;

		[Tooltip("if the property is a float, the new float to set")]
		[MMFEnumCondition("PropertyType", new int[] { 2 })]
		public float NewFloat = 1f;

		[Tooltip("if the property is a gradient, the new gradient to set")]
		[MMFEnumCondition("PropertyType", new int[] { 3 })]
		[GradientUsage(true)]
		public Gradient NewGradient = new Gradient();

		[Tooltip("if the property is an int, the new int to set")]
		[MMFEnumCondition("PropertyType", new int[] { 4 })]
		public int NewInt;

		[Tooltip("if the property is a mesh, the new mesh to set")]
		[MMFEnumCondition("PropertyType", new int[] { 5 })]
		public Mesh NewMesh;

		[Tooltip("if the property is a texture, the new texture to set")]
		[MMFEnumCondition("PropertyType", new int[] { 6 })]
		public Texture NewTexture;

		[Tooltip("if the property is an unsigned int, the new unsigned int to set")]
		[MMFEnumCondition("PropertyType", new int[] { 7 })]
		public uint NewUInt;

		[Tooltip("if the property is a vector2, the new vector2 to set")]
		[MMFEnumCondition("PropertyType", new int[] { 8 })]
		public Vector2 NewVector2;

		[Tooltip("if the property is a vector3, the new vector3 to set")]
		[MMFEnumCondition("PropertyType", new int[] { 9 })]
		public Vector3 NewVector3;

		[Tooltip("if the property is a vector4, the new vector4 to set")]
		[MMFEnumCondition("PropertyType", new int[] { 10 })]
		public Vector4 NewVector4;

		protected int _propertyID;

		protected AnimationCurve _initialAnimationCurve;

		protected bool _initialBool;

		protected float _initialFloat;

		protected Gradient _initialGradient;

		protected int _initialInt;

		protected Mesh _initialMesh;

		protected Texture _initialTexture;

		protected uint _initialUInt;

		protected Vector2 _initialVector2;

		protected Vector3 _initialVector3;

		protected Vector4 _initialVector4;

		public override float FeedbackDuration
		{
			get
			{
				return ApplyTimeMultiplier(DeclaredDuration);
			}
			set
			{
				DeclaredDuration = value;
			}
		}

		public override bool HasChannel => true;

		public override bool HasRandomness => true;

		protected override void CustomInitialization(MMF_Player owner)
		{
			base.CustomInitialization(owner);
			_propertyID = Shader.PropertyToID(PropertyID);
			GetInitialValue();
		}

		protected virtual void GetInitialValue()
		{
			if (!(TargetVisualEffect == null))
			{
				switch (PropertyType)
				{
				case PropertyTypes.AnimationCurve:
					_initialAnimationCurve = TargetVisualEffect.GetAnimationCurve(_propertyID);
					break;
				case PropertyTypes.Bool:
					_initialBool = TargetVisualEffect.GetBool(_propertyID);
					break;
				case PropertyTypes.Float:
					_initialFloat = TargetVisualEffect.GetFloat(_propertyID);
					break;
				case PropertyTypes.Gradient:
					_initialGradient = TargetVisualEffect.GetGradient(_propertyID);
					break;
				case PropertyTypes.Int:
					_initialInt = TargetVisualEffect.GetInt(_propertyID);
					break;
				case PropertyTypes.Mesh:
					_initialMesh = TargetVisualEffect.GetMesh(_propertyID);
					break;
				case PropertyTypes.Texture:
					_initialTexture = TargetVisualEffect.GetTexture(_propertyID);
					break;
				case PropertyTypes.UInt:
					_initialUInt = TargetVisualEffect.GetUInt(_propertyID);
					break;
				case PropertyTypes.Vector2:
					_initialVector2 = TargetVisualEffect.GetVector2(_propertyID);
					break;
				case PropertyTypes.Vector3:
					_initialVector3 = TargetVisualEffect.GetVector3(_propertyID);
					break;
				case PropertyTypes.Vector4:
					_initialVector4 = TargetVisualEffect.GetVector4(_propertyID);
					break;
				}
			}
		}

		protected override void CustomPlayFeedback(Vector3 position, float attenuation = 1f)
		{
			if (Active && FeedbackTypeAuthorized && !(TargetVisualEffect == null))
			{
				switch (PropertyType)
				{
				case PropertyTypes.AnimationCurve:
					TargetVisualEffect.SetAnimationCurve(_propertyID, NewAnimationCurve);
					break;
				case PropertyTypes.Bool:
					TargetVisualEffect.SetBool(_propertyID, NewBool);
					break;
				case PropertyTypes.Float:
					TargetVisualEffect.SetFloat(_propertyID, NewFloat);
					break;
				case PropertyTypes.Gradient:
					TargetVisualEffect.SetGradient(_propertyID, NewGradient);
					break;
				case PropertyTypes.Int:
					TargetVisualEffect.SetInt(_propertyID, NewInt);
					break;
				case PropertyTypes.Mesh:
					TargetVisualEffect.SetMesh(_propertyID, NewMesh);
					break;
				case PropertyTypes.Texture:
					TargetVisualEffect.SetTexture(_propertyID, NewTexture);
					break;
				case PropertyTypes.UInt:
					TargetVisualEffect.SetUInt(_propertyID, NewUInt);
					break;
				case PropertyTypes.Vector2:
					TargetVisualEffect.SetVector2(_propertyID, NewVector2);
					break;
				case PropertyTypes.Vector3:
					TargetVisualEffect.SetVector3(_propertyID, NewVector3);
					break;
				case PropertyTypes.Vector4:
					TargetVisualEffect.SetVector4(_propertyID, NewVector4);
					break;
				}
			}
		}

		protected override void CustomRestoreInitialValues()
		{
			if (Active && FeedbackTypeAuthorized)
			{
				switch (PropertyType)
				{
				case PropertyTypes.AnimationCurve:
					TargetVisualEffect.SetAnimationCurve(_propertyID, _initialAnimationCurve);
					break;
				case PropertyTypes.Bool:
					TargetVisualEffect.SetBool(_propertyID, _initialBool);
					break;
				case PropertyTypes.Float:
					TargetVisualEffect.SetFloat(_propertyID, _initialFloat);
					break;
				case PropertyTypes.Gradient:
					TargetVisualEffect.SetGradient(_propertyID, _initialGradient);
					break;
				case PropertyTypes.Int:
					TargetVisualEffect.SetInt(_propertyID, _initialInt);
					break;
				case PropertyTypes.Mesh:
					TargetVisualEffect.SetMesh(_propertyID, _initialMesh);
					break;
				case PropertyTypes.Texture:
					TargetVisualEffect.SetTexture(_propertyID, _initialTexture);
					break;
				case PropertyTypes.UInt:
					TargetVisualEffect.SetUInt(_propertyID, _initialUInt);
					break;
				case PropertyTypes.Vector2:
					TargetVisualEffect.SetVector2(_propertyID, _initialVector2);
					break;
				case PropertyTypes.Vector3:
					TargetVisualEffect.SetVector3(_propertyID, _initialVector3);
					break;
				case PropertyTypes.Vector4:
					TargetVisualEffect.SetVector4(_propertyID, _initialVector4);
					break;
				}
			}
		}
	}
}
