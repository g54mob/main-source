using Rhizomatic.Reactive;
using UnityEngine;

namespace GRP.Net
{
	public class NetProjectPlayerView : View<NetProjectPlayerViewable>
	{
		public Transform head;

		public Transform cursor;

		public Transform selected;

		public GameObject move;

		public GameObject rotate;

		public GameObject moveAxisX;

		public GameObject moveAxisY;

		public GameObject moveAxisZ;

		public GameObject moveAxisNX;

		public GameObject moveAxisNY;

		public GameObject moveAxisNZ;

		public GameObject[] rotateAxisX;

		public GameObject[] rotateAxisY;

		public GameObject[] rotateAxisZ;

		public MeshRenderer[] meshRenderers;

		public float smooth;

		private MaterialPropertyBlock materialBlock;

		private ulong lastId;

		private Part selectedPart;

		protected override void OnViewCreated()
		{
		}

		protected override void Update()
		{
		}
	}
}
