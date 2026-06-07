using System;
using UnityEngine;

namespace Motorways.Views
{
	[Serializable]
	public struct NodeConnection
	{
		public float duration;

		public MenuScreenNode startNode;

		public Vector3 entryHandle;

		public Vector3 exitHandle;

		public MenuScreenNode endNode;

		public TransitionCameraControl cameraControl;

		public Vector3 StartPosition => startNode.transform.position;

		public Vector3 EndPosition => endNode.transform.position;
	}
}
