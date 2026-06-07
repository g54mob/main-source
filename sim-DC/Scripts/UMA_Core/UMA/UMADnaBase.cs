using System;
using UnityEngine;

namespace UMA
{
	[Serializable]
	public class UMADnaBase
	{
		[SerializeField]
		protected int dnaTypeHash;

		public virtual int Count { get; }

		public virtual float[] Values { get; set; }

		public virtual string[] Names { get; }

		public virtual int DNATypeHash
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public virtual float GetValue(int idx)
		{
			return 0f;
		}

		public virtual void SetValue(int idx, float value)
		{
		}
	}
}
