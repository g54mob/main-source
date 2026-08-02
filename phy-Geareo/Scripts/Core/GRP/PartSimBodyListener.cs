using System;
using UnityEngine;

namespace GRP
{
	public class PartSimBodyListener : MonoBehaviour
	{
		public Action<Collision> handleCollision;

		private void OnCollisionEnter(Collision collision)
		{
		}

		private void OnCollisionStay(Collision collision)
		{
		}
	}
}
