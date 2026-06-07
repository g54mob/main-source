using System;
using UnityEngine;

namespace EasyRoads3Dv3
{
	[Serializable]
	public class ERCamNodes : ScriptableObject
	{
		[SerializeField]
		public float sleep = 0f;

		[SerializeField]
		public float speed = 0f;

		[SerializeField]
		public float easeOutDistance = 0f;

		[SerializeField]
		public float easeInDistance = 0f;

		[SerializeField]
		public GameObject startLookat;

		[SerializeField]
		public GameObject endLookat;
	}
}
