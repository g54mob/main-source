using System;
using UnityEngine;
using UnityEngine.Events;

namespace Cainos.Common
{
	public class TriggerEventReceiver2D : MonoBehaviour
	{
		[Serializable]
		public class TriggerEvent2D : UnityEvent<Collider2D>
		{
		}

		public bool useLayerMask;

		public LayerMask layerMask;

		[Space]
		public bool useTag;

		public new string tag;

		[Space]
		public TriggerEvent2D onTriggerEnter2D;

		public TriggerEvent2D onTriggerExit2D;

		private void OnTriggerEnter2D(Collider2D collision)
		{
		}

		private void OnTriggerExit2D(Collider2D collision)
		{
		}
	}
}
