using System;
using NSEipix.Base;
using UnityEngine;

namespace NSMedieval.Construction
{
	[Serializable]
	public class Stability : NSEipix.Base.Model
	{
		[SerializeField]
		private string id;

		[SerializeField]
		private byte minStability;

		[SerializeField]
		private byte maxStability;

		[SerializeField]
		private int minBeamLength;

		[SerializeField]
		private int maxBeamLength;

		public byte MinStability => minStability;

		public byte MaxStability => maxStability;

		public int MinBeamLength => minBeamLength;

		public int MaxBeamLength => maxBeamLength;

		public override string GetID()
		{
			return id;
		}
	}
}
