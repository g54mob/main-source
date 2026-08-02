using Rhizomatic;
using Rhizomatic.Reactive;
using UnityEngine;

namespace GRP
{
	public class ToasterView : View<ToasterViewable>
	{
		public Transform anchor;

		public NavigatorView navigator;

		public CameraCenter cameraCenter;

		private Vector3[] corners;

		private RectTransform camCenterRect;

		protected override void Start()
		{
		}

		protected override void Update()
		{
		}

		protected override void OnViewOpen()
		{
		}

		protected override void OnViewClose()
		{
		}

		public void UpdateCameraCenter()
		{
		}
	}
}
