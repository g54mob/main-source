using System;
using System.Collections.Generic;
using NSEipix.Model;
using UnityEngine;
using UnityEngine.Serialization;

namespace NSMedieval.Model
{
	[Serializable]
	public class RangeBasedEffector
	{
		[SerializeField]
		private string category;

		[FormerlySerializedAs("ageRange")]
		[SerializeField]
		private IntRange range;

		[SerializeField]
		private List<string> effectors;

		public IntRange Range => range;

		public List<string> Effectors => effectors;

		public string Category => category;
	}
}
