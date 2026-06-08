using Rhizomatic;
using Rhizomatic.Reactive;
using UnityEngine;

namespace GRP
{
	public class ProjectView : View<ProjectViewable>
	{
		public OrbitCameraView camera;

		public ListLoader partViews;

		private Bounds boundsVisual;

		protected override void OnRender()
		{
		}

		public void FocusSelection()
		{
		}

		public PartView GetPartView(Id id)
		{
			return null;
		}

		private void OnDrawGizmos()
		{
		}
	}
}
