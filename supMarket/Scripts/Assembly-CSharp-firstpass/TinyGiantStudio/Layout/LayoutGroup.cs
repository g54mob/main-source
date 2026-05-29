using System.Collections.Generic;
using UnityEngine;

namespace TinyGiantStudio.Layout
{
	[DisallowMultipleComponent]
	[ExecuteAlways]
	[HelpURL("https://ferdowsur.gitbook.io/modular-3d-text/layout-group")]
	public abstract class LayoutGroup : MonoBehaviour
	{
		[Tooltip("This is an experimental feature. In text, this bool is ignored, turn it on from the text itself. \nIf the child element has a Layout Element component attached, this value is derived by that layout element component.")]
		public bool autoItemSize;

		[Tooltip("For performance, it's better to leave it to false and call UpdateLayout() after making changes.\nTurn this on if you are in a hurry or testing stuff.")]
		public bool alwaysUpdateInPlayMode;

		[Tooltip("For performance, it's better to leave it to false and call GetAllChildBounds() when a bound(size of an element) changes")]
		public bool alwaysUpdateBounds;

		public LayoutElementModuleContainer elementUpdater;

		[Tooltip("Auto updated with the layout. Visible for debugging purposes.")]
		public Bounds[] bounds;

		public bool showSceneViewGizmo;

		[ExecuteInEditMode]
		private void Update()
		{
		}

		public abstract void UpdateLayout(int startRepositioningFrom = 0);

		public abstract List<MeshLayout> GetPositions(List<MeshLayout> meshLayouts);

		public int TotalActiveChildCount()
		{
			return 0;
		}

		public Bounds GetBound(Transform target)
		{
			return default(Bounds);
		}

		public Bounds GetBound(MeshLayout meshLayout)
		{
			return default(Bounds);
		}

		public Bounds[] GetAllChildBounds()
		{
			return null;
		}

		public Bounds[] GetAllChildBounds(List<MeshLayout> meshLayouts)
		{
			return null;
		}

		public bool IgnoreChildBound(Bounds[] bounds, int i)
		{
			return false;
		}

		public bool IgnoreChildBoundAndLineBreak(Bounds[] bounds, int i)
		{
			return false;
		}

		public Vector3 RemoveNaNErrorIfAny(Vector3 vector3)
		{
			return default(Vector3);
		}

		public void OnDrawGizmosSelected()
		{
		}

		private Vector3 Multiply(Vector3 first, Vector3 second)
		{
			return default(Vector3);
		}
	}
}
