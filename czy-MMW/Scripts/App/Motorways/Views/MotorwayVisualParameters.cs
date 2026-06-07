using System;
using Easing;
using Rendering.RenderFeatures;
using UnityEngine;

namespace Motorways.Views
{
	[CreateAssetMenu(fileName = "New MotorwayVisualParameters", menuName = "MotorwayVisualParameters", order = 1000)]
	public class MotorwayVisualParameters : ScriptableObject
	{
		public float roadWidth = 0.1f;

		public float roadOutlineWidth = 0.2f;

		public int splineSegmentCount = 90;

		public float splineDistanceBetweenStripes = 2f;

		public float splineStripeRotationDegrees = 35f;

		public float splineEndFadeoutDistance = 1f;

		public float hazardStripeFadeoutOffset = 0.5f;

		public float hazardFadeoutDistance = 1f;

		public float maxHazardStripeWidth = 0.5f;

		public float hazardStripeInDuration = 0.35f;

		public float hazardStripeOutDuration = 0.35f;

		public Easings.Functions hazardStripeAnimationFunction = Easings.Functions.SineEaseInOut;

		[Tooltip("The time it takes to tween the hazard stripes to full opacity. This occurs when a drying motorway is mothballed.")]
		public float hazardStripeOpacityFactorFadeDuration = 0.3f;

		public float editModeOpacity = 0.75f;

		public float mothballedOpacity = 0.5f;

		public float viewModeOpacityInDuration = 0.5f;

		public float viewModeOpacityOutDuration = 0.5f;

		public Easings.Functions viewModeOpacityAnimationFunction = Easings.Functions.SineEaseInOut;

		public float blendingSize = 0.1f;

		[EnumTypedArray(typeof(ShadowTypeRenderPass.ShadowType))]
		[NonReorderable]
		public ShadowTypeFadeouts[] shadowFadeouts = new ShadowTypeFadeouts[Enum.GetNames(typeof(ShadowTypeRenderPass.ShadowType)).Length];

		public event Action OnParameterChanged;

		public void InvokeOnParameterChanged()
		{
			this.OnParameterChanged?.Invoke();
		}
	}
}
