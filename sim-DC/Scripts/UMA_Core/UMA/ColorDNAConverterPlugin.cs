using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace UMA
{
	public class ColorDNAConverterPlugin : DynamicDNAPlugin
	{
		[Serializable]
		public class DNAColorSet
		{
			public enum Mode
			{
				Overlay = 0,
				SharedColor = 1
			}

			[Serializable]
			public class DNAColorComponent
			{
				[Tooltip("Change this component of the color")]
				public bool enable;

				[Tooltip("If Absolute the setting overrides the value of the component of the color. If Adjust, the setting is added to the value of the component of the color. Use BlendFactor to completely fade a texture in and out")]
				public OverlayData.ColorComponentAdjuster.AdjustmentType adjustmentType;

				[Tooltip("If true the evaluated DNA value will be used when setting the color value for this component of the color")]
				public bool useDNAValue;

				[Tooltip("The value for this component of the color")]
				[Range(0f, 1f)]
				public float value;

				[Tooltip("The amount to adjust this component of the color by. This can be negative, for example value of -0.5 on the red component would turn an incoming color of (1,1,1,1) into (0.5f,1,1,1)")]
				[Range(-1f, 1f)]
				public float adjustValue;

				[Tooltip("A multiplier to apply to the evaluated dnaValue. This allows you to use the same dna to affect components of the color by different amounts")]
				public float multiplier;

				public bool Additive => false;

				public bool Absolute => false;

				public DNAColorComponent()
				{
				}

				public DNAColorComponent(DNAColorComponent other)
				{
				}

				public float Evaluate(float dnaValue, float current)
				{
					return 0f;
				}

				public float EvaluateAdjustment(float dnaValue, float currentColor)
				{
					return 0f;
				}
			}

			[Serializable]
			public class DNAColorModifier
			{
				public DNAColorComponent R;

				public DNAColorComponent G;

				public DNAColorComponent B;

				public DNAColorComponent A;

				[SerializeField]
				private float _testDNAVal;

				public DNAColorModifier()
				{
				}

				public DNAColorModifier(DNAColorModifier other)
				{
				}
			}

			[Tooltip("A Color DNA Converter can target a specific overlay or a sharedColor")]
			public Mode mode;

			[Tooltip("The name of the overlay or shared color to target")]
			[FormerlySerializedAs("overlayEntryName")]
			public string targetName;

			[Tooltip("Texture Channel: For example PBR, 0 = Albedo, 1 = Normal, 2 = Metallic")]
			[FormerlySerializedAs("colorChannel")]
			public int textureChannel;

			[Tooltip("Define the dna that influence these changes. Note: If no dna is defined nothing will happen!")]
			public DNAEvaluatorList modifyingDNA;

			[Tooltip("Define how you want to change the colors used on this overlay")]
			public DNAColorModifier colorModifier;

			public List<string> UsedDNANames => null;

			public DNAColorSet()
			{
			}

			public DNAColorSet(DNAColorSet other)
			{
			}

			public bool EvaluateAndApplyAdjustments(UMADnaBase activeDNA, float masterWeight, List<OverlayData> targetOverlays)
			{
				return false;
			}
		}

		[FormerlySerializedAs("colorSets")]
		[SerializeField]
		private DNAColorSet[] _colorSets;

		[NonSerialized]
		private List<GameObject> _dnaAppliedTo;

		[NonSerialized]
		private List<GameObject> _listenersAddedTo;

		public DNAColorSet[] colorSets
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public override ApplyPassOpts ApplyPass => default(ApplyPassOpts);

		public override Dictionary<string, List<int>> IndexesForDnaNames => null;

		public void ResetOnCharaterUpdated(UMAData umaData)
		{
		}

		public override void Reset()
		{
		}

		public override void ApplyDNA(UMAData umaData, UMASkeleton skeleton, int dnaTypeHash)
		{
		}
	}
}
