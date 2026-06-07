using System;
using UnityEngine;

namespace WaveHarmonic.Crest
{
	[Serializable]
	public struct FloatingObjectProbe
	{
		[SerializeField]
		public float _Weight;

		[SerializeField]
		public Vector3 _Position;
	}
}
