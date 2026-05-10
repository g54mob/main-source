using System;
using UnityEngine;

namespace EPOOutline
{
	[ExecuteAlways]
	public class OnPreRenderEventTransferer : MonoBehaviour
	{
		private Camera attachedCamera;

		public Action<Camera> OnPreRenderEvent;

		private void Awake()
		{
		}

		private void OnPreRender()
		{
		}
	}
}
