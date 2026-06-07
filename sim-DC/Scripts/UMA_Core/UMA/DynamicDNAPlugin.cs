using System;
using System.Collections.Generic;
using UnityEngine;

namespace UMA
{
	[Serializable]
	public abstract class DynamicDNAPlugin : ScriptableObject
	{
		public enum ApplyPassOpts
		{
			PrePass = 0,
			Standard = 1,
			PostPass = 2
		}

		[Serializable]
		public class MasterWeight
		{
			public enum MasterWeightType
			{
				UseGlobalValue = 0,
				UseDNAValue = 1
			}

			[Tooltip("Choose whether to use a global value for all characters that use this converter, or a dnaValue that characters can change.")]
			[SerializeField]
			private MasterWeightType _masterWeightType;

			[Tooltip("The global weight to use for this set of converters. Applies to all characters that use the converter behaviour this resides in. Override this with DNAForWeight for 'per character' control")]
			[Range(0f, 1f)]
			[SerializeField]
			private float _globalWeight;

			[Tooltip("If set, the weight value will be controlled by the given dna on the character.")]
			[SerializeField]
			[DNAEvaluator.Config(true, true)]
			private DNAEvaluator _DNAForWeight;

			public MasterWeightType masterWeightType
			{
				get
				{
					return default(MasterWeightType);
				}
				set
				{
				}
			}

			public float globalWeight
			{
				get
				{
					return 0f;
				}
				set
				{
				}
			}

			public string dnaName
			{
				get
				{
					return null;
				}
				set
				{
				}
			}

			public DNAEvaluationGraph dnaEvaluationGraph
			{
				get
				{
					return null;
				}
				set
				{
				}
			}

			public float dnaMultiplier
			{
				get
				{
					return 0f;
				}
				set
				{
				}
			}

			public MasterWeight()
			{
			}

			public MasterWeight(MasterWeight other)
			{
			}

			public MasterWeight(MasterWeightType masterWeightType = MasterWeightType.UseGlobalValue, float defaultWeight = 1f, string dnaForWeightName = "", DNAEvaluationGraph dnaForWeightGraph = null, float dnaForWeightMultiplier = 1f)
			{
			}

			public float GetWeight(UMADnaBase umaDna = null)
			{
				return 0f;
			}

			public UMADnaBase GetWeightedDNA(UMADnaBase incomingDna)
			{
				return null;
			}
		}

		[Tooltip("The master weight controls how much all the converters in this group are applied. You can disable a set of converters by making the master weight zero. Or you can hook the master weight up to a characters dna so the converters only apply when that dna has a certain value.")]
		[SerializeField]
		public MasterWeight masterWeight;

		[SerializeField]
		private DynamicDNAConverterController _converterController;

		private static readonly Type baseDynamicDNAPluginType;

		private static List<Type> _pluginTypes;

		public abstract Dictionary<string, List<int>> IndexesForDnaNames { get; }

		public DynamicDNAConverterController converterController
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public DynamicUMADnaAsset DNAAsset => null;

		public virtual ApplyPassOpts ApplyPass => default(ApplyPassOpts);

		public abstract void ApplyDNA(UMAData umaData, UMASkeleton skeleton, int dnaTypeHash);

		public virtual void Reset()
		{
		}

		public static List<Type> GetAvailablePluginTypes()
		{
			return null;
		}

		public static bool IsValidPluginType(Type type)
		{
			return false;
		}

		public static bool IsValidPlugin(UnityEngine.Object asset)
		{
			return false;
		}

		private static bool PluginDerivesFromBase(Type type)
		{
			return false;
		}

		private static void CompilePluginTypesList()
		{
		}
	}
}
