using System;
using System.Collections.Generic;
using UnityEngine;

namespace UMA
{
	[Serializable]
	public class DNAEvaluatorList
	{
		public enum AggregationMethodOpts
		{
			Average = 0,
			Cumulative = 1,
			Minimum = 2,
			Maximum = 3
		}

		[AttributeUsage(AttributeTargets.Field)]
		public class ConfigAttribute : Attribute
		{
			public enum LabelOptions
			{
				drawLabelAsFoldout = 0,
				drawExpandedWithLabel = 1,
				drawExpandedNoLabel = 2
			}

			public LabelOptions labelOption;

			public DNAEvaluationGraph defaultGraph;

			public ConfigAttribute(LabelOptions labelOption)
			{
			}
		}

		[SerializeField]
		private List<DNAEvaluator> _dnaEvaluators;

		[SerializeField]
		[Tooltip("How the evaluated results of each entry are combined and returned. When 'Cumulative' is selected you can choose how each line will be combined with the preceeding one.")]
		private AggregationMethodOpts _aggregationMethod;

		public AggregationMethodOpts aggregationMethod
		{
			get
			{
				return default(AggregationMethodOpts);
			}
			set
			{
			}
		}

		public List<string> UsedDNANames => null;

		public DNAEvaluator this[int key]
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public int Count => 0;

		public DNAEvaluatorList()
		{
		}

		public DNAEvaluatorList(DNAEvaluatorList other)
		{
		}

		public DNAEvaluatorList(List<DNAEvaluator> evaluators, AggregationMethodOpts aggregationMethod = AggregationMethodOpts.Average)
		{
		}

		public DNAEvaluatorList(AggregationMethodOpts aggregationMethod)
		{
		}

		public float Evaluate(UMADnaBase dna)
		{
			return 0f;
		}

		public float ApplyDNAToValue(UMADnaBase umaDna, float startingValue)
		{
			return 0f;
		}

		private float GetAggregateValueNew(UMADnaBase dna, float result = 0f)
		{
			return 0f;
		}

		private float GetAggregateValue(List<float> vals)
		{
			return 0f;
		}

		public void Add(DNAEvaluator evaluator)
		{
		}

		public void AddRange(IEnumerable<DNAEvaluator> evaluators)
		{
		}

		public bool Contains(DNAEvaluator evaluator)
		{
			return false;
		}

		public void Clear()
		{
		}

		public int IndexOf(DNAEvaluator evaluator)
		{
			return 0;
		}

		public void Insert(int index, DNAEvaluator evaluator)
		{
		}

		public void InsertRange(int index, IEnumerable<DNAEvaluator> evaluators)
		{
		}

		public void Remove(DNAEvaluator evaluator)
		{
		}

		public void RemoveAt(int index)
		{
		}

		public void RemoveRange(int index, int count)
		{
		}

		public DNAEvaluator[] ToArray()
		{
			return null;
		}
	}
}
