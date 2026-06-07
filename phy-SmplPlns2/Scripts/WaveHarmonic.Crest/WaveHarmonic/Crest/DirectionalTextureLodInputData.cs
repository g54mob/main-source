using System;
using UnityEngine;

namespace WaveHarmonic.Crest
{
	[Serializable]
	public abstract class DirectionalTextureLodInputData : TextureLodInputData
	{
		[Tooltip("Whether the texture supports negative values.")]
		[SerializeField]
		internal bool _NegativeValues;

		public bool NegativeValues
		{
			get
			{
				return _NegativeValues;
			}
			set
			{
				_NegativeValues = value;
			}
		}
	}
}
