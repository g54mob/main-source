using System;
using UnityEngine;

namespace NSMedieval.Model
{
	[Serializable]
	public class HitEffector
	{
		[SerializeField]
		private float threshold;

		[SerializeField]
		private string effector;

		public float Threshold
		{
			get
			{
				return threshold;
			}
			set
			{
				threshold = value;
			}
		}

		public string Effector
		{
			get
			{
				return effector;
			}
			set
			{
				effector = value;
			}
		}
	}
}
