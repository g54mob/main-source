using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace TheKiwiCoder
{
	public class Context
	{
		public GameObject gameObject;

		public Transform transform;

		public Animator animator;

		public Rigidbody physics;

		public NavMeshAgent agent;

		public SphereCollider sphereCollider;

		public BoxCollider boxCollider;

		public CapsuleCollider capsuleCollider;

		public CharacterController characterController;

		public Dictionary<string, Node.State> tickResults;

		public float tickDelta;

		public static Context CreateFromGameObject(GameObject gameObject)
		{
			return new Context
			{
				gameObject = gameObject,
				transform = gameObject.transform,
				animator = gameObject.GetComponentInChildren<Animator>(),
				physics = gameObject.GetComponent<Rigidbody>(),
				agent = gameObject.GetComponent<NavMeshAgent>(),
				sphereCollider = gameObject.GetComponent<SphereCollider>(),
				boxCollider = gameObject.GetComponent<BoxCollider>(),
				capsuleCollider = gameObject.GetComponent<CapsuleCollider>(),
				characterController = gameObject.GetComponent<CharacterController>(),
				tickResults = new Dictionary<string, Node.State>()
			};
		}

		public T GetComponent<T>() where T : Component
		{
			return gameObject.GetComponent<T>();
		}
	}
}
