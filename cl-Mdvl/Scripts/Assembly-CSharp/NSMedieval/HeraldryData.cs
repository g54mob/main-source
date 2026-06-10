using System;
using UnityEngine;

namespace NSMedieval
{
	[Serializable]
	public class HeraldryData
	{
		[SerializeField]
		private int layer;

		[SerializeField]
		private int symbol;

		[SerializeField]
		private int color;

		[SerializeField]
		private HeraldryTransforms layerTransforms;

		public int Layer
		{
			get
			{
				return layer;
			}
			set
			{
				layer = value;
			}
		}

		public int Symbol
		{
			get
			{
				return symbol;
			}
			set
			{
				symbol = value;
			}
		}

		public int Color
		{
			get
			{
				return color;
			}
			set
			{
				color = value;
			}
		}

		public HeraldryTransforms LayerTransforms
		{
			get
			{
				return layerTransforms;
			}
			set
			{
				layerTransforms = value;
			}
		}
	}
}
