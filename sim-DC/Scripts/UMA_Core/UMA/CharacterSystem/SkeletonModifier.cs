using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace UMA.CharacterSystem
{
	[Serializable]
	public class SkeletonModifier
	{
		public enum SkeletonPropType
		{
			Position = 0,
			Rotation = 1,
			Scale = 2
		}

		[Serializable]
		public class spVal
		{
			[Serializable]
			public class spValValue
			{
				[Serializable]
				public class spValModifier
				{
					public enum spValModifierType
					{
						Add = 0,
						Subtract = 1,
						Multiply = 2,
						Divide = 3,
						AddDNA = 4,
						SubtractDNA = 5,
						MultiplyDNA = 6,
						DivideDNA = 7
					}

					[FormerlySerializedAs("modifier")]
					[SerializeField]
					private spValModifierType _modifier;

					[FormerlySerializedAs("DNATypeName")]
					[SerializeField]
					private string _DNATypeName;

					[FormerlySerializedAs("modifierValue")]
					[SerializeField]
					private float _modifierValue;

					public spValModifierType modifier
					{
						get
						{
							return default(spValModifierType);
						}
						set
						{
						}
					}

					public string DNATypeName
					{
						get
						{
							return null;
						}
						set
						{
						}
					}

					public float modifierValue
					{
						get
						{
							return 0f;
						}
						set
						{
						}
					}
				}

				[FormerlySerializedAs("value")]
				[SerializeField]
				private float _value;

				[FormerlySerializedAs("modifiers")]
				[SerializeField]
				private List<spValModifier> _modifiers;

				[SerializeField]
				[DNAEvaluatorList.Config(DNAEvaluatorList.ConfigAttribute.LabelOptions.drawExpandedWithLabel)]
				[Tooltip("A list of dna that will be used to modify the bone on this axis. Usually you use 'Cumulative' so that the initial value for the axis is modified by each line here in turn.")]
				private DNAEvaluatorList _modifyingDNA;

				public float value
				{
					get
					{
						return 0f;
					}
					set
					{
					}
				}

				[Obsolete("Will be removed in future version. Please use 'modifyingDNA' instead")]
				public List<spValModifier> modifiers
				{
					get
					{
						return null;
					}
					set
					{
					}
				}

				public DNAEvaluatorList modifyingDNA
				{
					get
					{
						return null;
					}
					set
					{
					}
				}

				public float CalculateValue(UMADnaBase umaDNA)
				{
					return 0f;
				}

				private float CalculateLegacyModifiers(float startingVal, List<spValModifier> _modifiers, UMADnaBase umaDNA)
				{
					return 0f;
				}

				public float GetUmaDNAValue(string DNATypeName, UMADnaBase umaDnaIn)
				{
					return 0f;
				}

				public void ConvertToDNAEvaluators()
				{
				}
			}

			[FormerlySerializedAs("val")]
			[SerializeField]
			private spValValue _val;

			[FormerlySerializedAs("min")]
			[SerializeField]
			private float _min;

			[FormerlySerializedAs("max")]
			[SerializeField]
			private float _max;

			public spValValue val
			{
				get
				{
					return null;
				}
				set
				{
				}
			}

			public float min
			{
				get
				{
					return 0f;
				}
				set
				{
				}
			}

			public float max
			{
				get
				{
					return 0f;
				}
				set
				{
				}
			}

			public spVal()
			{
			}

			public spVal(Vector3 startingVals)
			{
			}

			public spVal(spVal importedSpVal)
			{
			}

			public Vector3 CalculateValue(UMADnaBase umaDNA)
			{
				return default(Vector3);
			}
		}

		[FormerlySerializedAs("hashName")]
		[SerializeField]
		private string _hashName;

		[FormerlySerializedAs("hash")]
		[SerializeField]
		private int _hash;

		[FormerlySerializedAs("property")]
		[SerializeField]
		private SkeletonPropType _property;

		[FormerlySerializedAs("valuesX")]
		[SerializeField]
		private spVal _valuesX;

		[FormerlySerializedAs("valuesY")]
		[SerializeField]
		private spVal _valuesY;

		[FormerlySerializedAs("valuesZ")]
		[SerializeField]
		private spVal _valuesZ;

		[FormerlySerializedAs("umaDNA")]
		[SerializeField]
		private UMADnaBase _umaDNA;

		public static Dictionary<SkeletonPropType, Vector3> skelAddDefaults;

		public string hashName
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public int hash
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public SkeletonPropType property
		{
			get
			{
				return default(SkeletonPropType);
			}
			set
			{
			}
		}

		public spVal valuesX
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public spVal valuesY
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public spVal valuesZ
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public UMADnaBase umaDNA
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		[Obsolete("Please use CalculateValueX((UMADnaBase umaDNA) instead")]
		public Vector3 ValueX => default(Vector3);

		[Obsolete("Please use CalculateValueY((UMADnaBase umaDNA) instead")]
		public Vector3 ValueY => default(Vector3);

		[Obsolete("Please use CalculateValueZ((UMADnaBase umaDNA) instead")]
		public Vector3 ValueZ => default(Vector3);

		public SkeletonModifier()
		{
		}

		public SkeletonModifier(string _hashName, int _hash, SkeletonPropType _propType)
		{
		}

		public SkeletonModifier(SkeletonModifier importedModifier, bool doUpgrade = false)
		{
		}

		public void UpgradeToDNAEvaluators()
		{
		}

		public Vector3 CalculateValueX(UMADnaBase umaDNA)
		{
			return default(Vector3);
		}

		public Vector3 CalculateValueY(UMADnaBase umaDNA)
		{
			return default(Vector3);
		}

		public Vector3 CalculateValueZ(UMADnaBase umaDNA)
		{
			return default(Vector3);
		}
	}
}
