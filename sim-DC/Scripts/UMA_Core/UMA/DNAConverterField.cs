using System;
using UnityEngine;

namespace UMA
{
	[Serializable]
	public class DNAConverterField
	{
		[SerializeField]
		private UnityEngine.Object _converter;

		public IDNAConverter Value
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		private void Validate()
		{
		}
	}
}
