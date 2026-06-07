using System;
using System.Collections.Generic;
using UnityEngine;

namespace UMA
{
	[Serializable]
	public class DNAConverterList
	{
		[SerializeField]
		private List<DynamicDNAConverterController> _converters;

		public DynamicDNAConverterController this[int key]
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public int Length => 0;

		public int Count => 0;

		public DNAConverterList()
		{
		}

		public DNAConverterList(DNAConverterList other)
		{
		}

		public DNAConverterList(DynamicDNAConverterController[] dnaConverters)
		{
		}

		public DNAConverterList(List<DynamicDNAConverterController> dnaConverters)
		{
		}

		private void Validate()
		{
		}

		public void Add(DynamicDNAConverterController converter)
		{
		}

		public void AddRange(IEnumerable<DynamicDNAConverterController> converters)
		{
		}

		public bool Contains(DynamicDNAConverterController converter)
		{
			return false;
		}

		public void Clear()
		{
		}

		public int IndexOf(UnityEngine.Object converter)
		{
			return 0;
		}

		public DynamicDNAConverterController[] ToArray()
		{
			return null;
		}
	}
}
