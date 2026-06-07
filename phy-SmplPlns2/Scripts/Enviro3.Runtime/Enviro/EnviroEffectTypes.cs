using System;
using UnityEngine;

namespace Enviro
{
	[Serializable]
	public class EnviroEffectTypes
	{
		public ParticleSystem mySystem;

		public string name;

		public GameObject prefab;

		public Vector3 localPositionOffset;

		public Vector3 localRotationOffset;

		public float emissionRate;

		public float maxEmission;
	}
}
