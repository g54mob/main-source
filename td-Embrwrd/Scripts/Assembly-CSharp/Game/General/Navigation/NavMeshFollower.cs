using System;
using UnityEngine;
using UnityEngine.AI;

namespace Game.General.Navigation
{
	public class NavMeshFollower : MonoBehaviour
	{
		public Action<NavMeshFollower> OnArrive;

		public NavMeshAgent Agent;

		[SerializeField]
		private Transform target;

		public Transform Target
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		private void Update()
		{
		}
	}
}
