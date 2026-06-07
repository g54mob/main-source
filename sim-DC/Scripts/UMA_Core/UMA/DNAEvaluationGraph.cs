using System;
using System.Collections.Generic;
using UnityEngine;

namespace UMA
{
	[Serializable]
	public sealed class DNAEvaluationGraph : IEquatable<DNAEvaluationGraph>
	{
		public class EditorHelper
		{
			private DNAEvaluationGraph _evaluationGraph;

			public DNAEvaluationGraph Target => null;

			public string _name
			{
				get
				{
					return null;
				}
				set
				{
				}
			}

			public AnimationCurve _graph
			{
				get
				{
					return null;
				}
				set
				{
				}
			}

			public EditorHelper()
			{
			}

			public EditorHelper(AnimationCurve graph, string name, string description)
			{
			}

			public EditorHelper(DNAEvaluationGraph dnaEasingCurve)
			{
			}
		}

		[SerializeField]
		private string _name;

		[SerializeField]
		private AnimationCurve _graph;

		public string name => null;

		public Keyframe[] GraphKeys => null;

		public static DNAEvaluationGraph Default => null;

		public static DNAEvaluationGraph DefaultInverted => null;

		public static DNAEvaluationGraph DefaultOne => null;

		public static DNAEvaluationGraph DefaultOneInverted => null;

		public static DNAEvaluationGraph ZeroZeroOne => null;

		public static DNAEvaluationGraph OneZeroZero => null;

		public static DNAEvaluationGraph ZeroOneZero => null;

		public static DNAEvaluationGraph OneZeroOne => null;

		public static DNAEvaluationGraph ZeroOneOne => null;

		public static DNAEvaluationGraph OneOneZero => null;

		public static DNAEvaluationGraph Raw => null;

		public static DNAEvaluationGraph RawInverted => null;

		public static string DefaultToolTip => null;

		public static string DefaultInvertedToolTip => null;

		public static string DefaultOneToolTip => null;

		public static string DefaultOneInvertedToolTip => null;

		public static string ZeroZeroOneToolTip => null;

		public static string OneZeroZeroToolTip => null;

		public static string ZeroOneZeroToolTip => null;

		public static string OneZeroOneToolTip => null;

		public static string ZeroOneOneToolTip => null;

		public static string OneOneZeroToolTip => null;

		public static string RawToolTip => null;

		public static string RawInvertedToolTip => null;

		public static Dictionary<DNAEvaluationGraph, string> Defaults => null;

		public DNAEvaluationGraph()
		{
		}

		public DNAEvaluationGraph(string name, AnimationCurve graph)
		{
		}

		public DNAEvaluationGraph(DNAEvaluationGraph other)
		{
		}

		public float Evaluate(float dnaValue)
		{
			return 0f;
		}

		public bool GraphMatches(DNAEvaluationGraph other)
		{
			return false;
		}

		public bool GraphMatches(AnimationCurve animCurve)
		{
			return false;
		}

		public static implicit operator bool(DNAEvaluationGraph obj)
		{
			return false;
		}

		public bool Equals(DNAEvaluationGraph other)
		{
			return false;
		}

		public override bool Equals(object other)
		{
			return false;
		}

		public static bool operator ==(DNAEvaluationGraph cd1, DNAEvaluationGraph cd2)
		{
			return false;
		}

		public static bool operator !=(DNAEvaluationGraph cd1, DNAEvaluationGraph cd2)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}

		private static int Compare(object x, object y)
		{
			return 0;
		}
	}
}
