using System;
using System.Collections.Generic;
using UnityEngine;

namespace UMA
{
	[Serializable]
	public class DNARangeAsset : ScriptableObject
	{
		[SerializeField]
		[Tooltip("The DNA converter for which the ranges apply. Accepts a DNAConverterController asset or a legacy DNAConverterBehaviour prefab.")]
		private DNAConverterField _dnaConverter;

		public float[] means;

		public float[] deviations;

		public float[] spreads;

		private float[] values;

		private string[] dnaNames;

		public IDNAConverter dnaConverter
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public int EntryCount => 0;

		private Dictionary<int, int> GetMatchingIndexes(IDNAConverter originalConverter, IDNAConverter replacingConverter)
		{
			return null;
		}

		public bool ContainsDNARange(int index, string name)
		{
			return false;
		}

		public bool ContainsDNARange(string name)
		{
			return false;
		}

		public int IndexForDNAName(string name)
		{
			return 0;
		}

		public bool ValueInRange(int index, float value)
		{
			return false;
		}

		public Dictionary<string, DnaSetter> GetDNA(UMAData umaData, IDNAConverter dcb, string[] dbNames)
		{
			return null;
		}

		public void RandomizeDNA(UMAData data)
		{
		}

		public void RandomizeDNAGaussian(UMAData data)
		{
		}
	}
}
