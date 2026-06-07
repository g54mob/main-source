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

			public Vector3 rotation = Vector3.zero;

			public RotationKey(Vector3 rotation, double f, double t)
				: base(f, t)
			{
				this.rotation = rotation;
			}
		}

		public RotationKey[] keys = new RotationKey[0];

		public RotationModifier()
		{
			keys = new RotationKey[0];
		}

		public override List<Key> GetKeys()
		{
			return new List<Key>(keys);
		}

		public override void SetKeys(List<Key> input)
		{
			keys = new RotationKey[input.Count];
			for (int i = 0; i < input.Count; i++)
			{
				keys[i] = (RotationKey)input[i];
			}
			base.SetKeys(input);
		}

		public void AddKey(Vector3 rotation, double f, double t)
		{
			ArrayUtility.Add(ref keys, new RotationKey(rotation, f, t));
		}

		public override void Apply(ref SplineSample result)
		{
			if (keys.Length == 0)
			{
				return;
			}
			base.Apply(ref result);
			Quaternion quaternion = Quaternion.identity;
			Quaternion quaternion2 = result.rotation;
			for (int i = 0; i < keys.Length; i++)
			{
				if (keys[i].useLookTarget && keys[i].target != null)
				{
					Quaternion b = Quaternion.LookRotation(keys[i].target.position - result.position);
					quaternion2 = Quaternion.Slerp(quaternion2, b, keys[i].Evaluate(result.percent) * blend);
				}
				else
				{
					Quaternion quaternion3 = Quaternion.Euler(keys[i].rotation.x, keys[i].rotation.y, keys[i].rotation.z);
					quaternion = Quaternion.Slerp(quaternion, quaternion * quaternion3, keys[i].Evaluate(result.percent) * blend);
				}
			}
			Quaternion quaternion4 = quaternion2 * quaternion;
			Vector3 vector = Quaternion.Inverse(result.rotation) * result.up;
			result.forward = quaternion4 * Vector3.forward;
			result.up = quaternion4 * vector;
		}
	}
}
