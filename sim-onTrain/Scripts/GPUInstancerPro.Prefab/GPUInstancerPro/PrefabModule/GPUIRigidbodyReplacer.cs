using System;
using UnityEngine;

namespace GPUInstancerPro.PrefabModule
{
	[DefaultExecutionOrder(-100)]
	[RequireComponent(typeof(GPUIPrefab))]
	public class GPUIRigidbodyReplacer : GPUIPrefabExtension
	{
		[Serializable]
		public class GPUIRigidbodyData
		{
			public bool useGravity;

			public float angularDrag;

			public float mass;

			public RigidbodyConstraints constraints;

			public float drag;

			public bool isKinematic;

			public RigidbodyInterpolation interpolation;

			public GPUIRigidbodyData(Rigidbody rigidbody)
			{
				useGravity = rigidbody.useGravity;
				angularDrag = rigidbody.angularDrag;
				mass = rigidbody.mass;
				constraints = rigidbody.constraints;
				drag = rigidbody.drag;
				isKinematic = rigidbody.isKinematic;
				interpolation = rigidbody.interpolation;
			}

			public void SetValuesToRigidbody(Rigidbody rigidbody)
			{
				rigidbody.useGravity = useGravity;
				rigidbody.angularDrag = angularDrag;
				rigidbody.mass = mass;
				rigidbody.constraints = constraints;
				rigidbody.detectCollisions = true;
				rigidbody.drag = drag;
				rigidbody.isKinematic = isKinematic;
				rigidbody.interpolation = interpolation;
			}
		}

		[SerializeField]
		public GPUIRigidbodyData rigidbodyData;

		protected override void Start()
		{
			base.Start();
			GPUIRigidbodySimulator.InitializeInstance(this);
		}

		internal void ReplaceRigidbody(Rigidbody rigidbody)
		{
			if (rigidbodyData == null)
			{
				rigidbodyData = new GPUIRigidbodyData(rigidbody);
			}
			UnityEngine.Object.Destroy(rigidbody);
		}

		internal void AddRigidbody()
		{
			if (rigidbodyData != null && !base.gameObject.HasComponent<Rigidbody>())
			{
				rigidbodyData.SetValuesToRigidbody(base.gameObject.AddComponent<Rigidbody>());
			}
		}
	}
}
