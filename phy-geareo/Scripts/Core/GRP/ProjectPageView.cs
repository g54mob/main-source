using System.Collections.Generic;
using GRP.Net;
using Rhizomatic;
using UnityEngine;

namespace GRP
{
	public class ProjectPageView : PageView<ProjectPage>
	{
		public WorldPointablePort port;

		public ProjectView project;

		public NetProjectView netProject;

		public ListLoader toolViews;

		public CameraCenter cameraCenter;

		public RectTransform frustumRect;

		public FrustumShape frustumShape;

		private BuildTool buildTool;

		protected override void OnViewCreated()
		{
		}

		public void SelectFrustum(Vector2 position, Vector2 size, HashSet<Part> keepSelection)
		{
		}

		protected override void Setup()
		{
		}

		protected override void OnViewClose()
		{
		}

		public void UpdateCameraCenter()
		{
		}

		protected override void OnRender()
		{
		}

		protected override void Update()
		{
		}

		public void DeleteGlues()
		{
		}
	}
}
