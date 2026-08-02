using UnityEngine;

namespace JUTPS.PhysicsScripts
{
	[AddComponentMenu("JU TPS/Physics/Add Force")]
	public class AddForceAndAngularVelocity : MonoBehaviour
	{
		public Vector3 Force;

		public Vector3 AngularVelocity;

		public bool GenerateRandomForce;

		[Range(0f, 300f)]
		public float RandomForceRange;

		public bool GenerateRandomAngularVelocity;

		[Range(0f, 800f)]
		public float RandomAngularVelocityRange;

		private void Start()
		{
			Rigidbody component = GetComponent<Rigidbody>();
			if (GenerateRandomForce)
			{
				Force = new Vector3(Random.Range(0f - RandomForceRange, RandomForceRange), Random.Range(0f - RandomForceRange, RandomForceRange), Random.Range(0f - RandomForceRange, RandomForceRange));
			}
			if (GenerateRandomAngularVelocity)
			{
				AngularVelocity = new Vector3(Random.Range(0f - RandomAngularVelocityRange, RandomAngularVelocityRange), Random.Range(0f - RandomAngularVelocityRange, RandomAngularVelocityRange), Random.Range(0f - RandomAngularVelocityRange, RandomAngularVelocityRange));
			}
			component.AddRelativeForce(Force, ForceMode.Impulse);
			component.angularVelocity = AngularVelocity;
		}
	}
}
