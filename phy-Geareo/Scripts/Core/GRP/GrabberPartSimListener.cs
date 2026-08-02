using System;
using UnityEngine;

namespace GRP
{
	public class GrabberPartSimListener : MonoBehaviour
	{
		public Action<Collider> onTrigger;

		private void OnTriggerEnter(Collider other)
		{
		}
	}
}
