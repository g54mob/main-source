using System;
using System.Collections.Generic;
using UnityEngine;

namespace Dreamteck.Splines
{
	[Serializable]
	public class RotationModifier : SplineSampleModifier
	{
		[Serializable]
		public class RotationKey : Key
		{
			public bool useLookTarget;

			public Transform target;

			public Vector3 rotation;

			public RotationKey(Vector3 rotation, double f, double t)
				: base(0.0, 0.0)
			{
			}
		}

		public RotationKey[] keys;

		public override List<Key> GetKeys()
		{
			return null;
		}

		public override void SetKeys(List<Key> input)
		{
		}

		public void AddKey(Vector3 rotation, double f, double t)
		{
		}

		public override void Apply(ref SplineSample result)
		{
		}
	}
}
