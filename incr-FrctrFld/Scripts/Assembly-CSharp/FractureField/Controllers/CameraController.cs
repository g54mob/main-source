using System.Collections.Generic;
using Reactivity;
using Reactivity.Unity.Components;
using UnityEngine;

namespace FractureField.Controllers
{
	public class CameraController : RComponent
	{
		[SerializeField]
		private RComponent _quarryCameraGO;

		public Camera QuarryCamera;

		[SerializeField]
		private RComponent _drillSiteCameraGO;

		public Camera DrillSiteCamera;

		public List<Canvas> SharedCanvases;

		private Ref<Camera> RActiveCamera { get; }

		public Camera ActiveCamera => null;

		protected override void Awake()
		{
		}
	}
}
