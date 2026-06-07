using System;
using UnityEngine;

namespace UMA
{
	[Serializable]
	public sealed class DNAEvaluator : ISerializationCallbackReceiver
	{
		public enum CalcOption
		{
			Add = 0,
			Subtract = 1,
			Multiply = 2,
			Divide = 3
		}

		[AttributeUsage(AttributeTargets.Field)]
		public class ConfigAttribute : Attribute
		{
			public bool drawLabels;

			public bool drawCalcOption;

			public bool alwaysExpanded;

			public ConfigAttribute(bool drawLabels)
			{
			}

			public ConfigAttribute(bool drawLabels, bool alwaysExpanded)
			{
			}

			public ConfigAttribute(bool drawLabels, bool alwaysExpanded, bool drawCalcOption)
			{
			}
		}

		[SerializeField]
		[Tooltip("Define how the evaluated value will be combined with the previous Evaluator in the list.")]
		private CalcOption _calcOption;

		[SerializeField]
		[Tooltip("The DNA entry name to evaluate")]
		private string _dnaName;

		[SerializeField]
		private int _dnaNameHash;

		[SerializeField]
		[Tooltip("Evaluates the incoming dna value using the given graph. Hover the options for info")]
		private DNAEvaluationGraph _evaluator;

		[SerializeField]
		[Tooltip("The evaluated value will be multiplied by this value before it is returned.")]
		private float _multiplier;

		[SerializeField]
		[HideInInspector]
		private bool _initialized;

		[NonSerialized]
		private int _lastIndex;

		public static readonly float defaultDNAValue;

		public CalcOption calcOption
		{
			get
			{
				return default(CalcOption);
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

		public int dnaNameHash => 0;

		public DNAEvaluationGraph evaluator
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public float multiplier
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public DNAEvaluator()
		{
		}

		public DNAEvaluator(string dnaName, DNAEvaluationGraph evaluator = null, float multiplier = 1f, CalcOption calcOption = CalcOption.Add)
		{
		}

		public DNAEvaluator(DNAEvaluator other)
		{
		}

		public float Evaluate(float dnaValue)
		{
			return 0f;
		}

		public float Evaluate(UMADnaBase dna)
		{
			return 0f;
		}

		public void OnAfterDeserialize()
		{
		}

		public void OnBeforeSerialize()
		{
		}
	}
}
