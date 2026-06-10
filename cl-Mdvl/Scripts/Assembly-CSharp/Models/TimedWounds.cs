using System;
using System.Collections.Generic;
using UnityEngine;

namespace Models
{
	[Serializable]
	public class TimedWounds
	{
		[SerializeField]
		private float time;

		[SerializeField]
		private List<string> wounds;

		public float Time => time;

		public List<string> Wounds => wounds;
	}
}
