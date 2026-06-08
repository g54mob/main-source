using System.Collections.Generic;
using UnityEngine;

namespace GRP
{
	public class RattleScene : MonoBehaviour
	{
		public float timeScale;

		public RattleConfig config;

		public AudioSource audioSourcePrefab;

		public Dictionary<RattleTouchKey, RattleTouch> waitingTouches;

		public List<RattleTouch> newTouches;

		public Dictionary<RattleKey, RattleContact> contacts;

		public Dictionary<RattleEmitterConfig, List<RattleEmitter>> emitters;

		private List<GameObject> toDestroy;

		private int lastContactId;

		private void Start()
		{
		}

		private void LateUpdate()
		{
		}

		public void ProcessEmitters()
		{
		}

		public void ProcessContacts()
		{
		}

		public void DoDestroy(GameObject obj, float t = 0f)
		{
		}

		public void Clear()
		{
		}

		private void OnDisable()
		{
		}

		public void HandleCollision(Rigidbody rb, Collision collision)
		{
		}

		public void HandleContact(Rigidbody rb, Collision collision, ContactPoint contact)
		{
		}

		private void OnDrawGizmos()
		{
		}

		private void Vec(Vector3 point, Vector3 vec)
		{
		}
	}
}
