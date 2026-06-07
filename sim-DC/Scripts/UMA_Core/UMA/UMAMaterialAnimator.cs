using System;
using System.Collections.Generic;
using UnityEngine;

namespace UMA
{
	public class UMAMaterialAnimator : MonoBehaviour
	{
		public enum MaterialAnimationType
		{
			Float = 0,
			Color = 1
		}

		[Serializable]
		public class MaterialAnimation
		{
			public MaterialAnimationType type;

			public string overlayTag;

			public string propertyName;

			public AnimationCurve curve;

			public bool useChannel;

			public int channelNumber;

			public float MinFloatValue;

			public float MaxFloatValue;

			public Color MinColorValue;

			public Color MaxColorValue;

			public override string ToString()
			{
				return null;
			}

			public void Apply(MaterialAnimationInstance instance, float time, int propertyIndex = 0)
			{
			}

			public void ApplyColor(MaterialAnimationInstance mat, float time, Color MinValue, Color MaxValue, int propertyIndex = 0)
			{
			}

			public void ApplyFloat(MaterialAnimationInstance mat, float time, float MinValue, float MaxValue, int propertyIndex = 0)
			{
			}
		}

		public class MaterialAnimationInstance
		{
			public MaterialAnimation animation;

			public Material material;

			public SlotData slot;

			public int layer;
		}

		public string slotTag;

		[SerializeField]
		public List<MaterialAnimation> animations;

		private bool initialized;

		private List<MaterialAnimationInstance> instances;

		private void Start()
		{
		}

		public void Initialize()
		{
		}

		private void OnCharacterUpdated(UMAData umaData)
		{
		}

		private void Update()
		{
		}
	}
}
