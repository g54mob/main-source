using TinyGiantStudio.Modules;
using UnityEngine;

namespace TinyGiantStudio.Layout
{
	[CreateAssetMenu(menuName = "Tiny Giant Studio/Modular 3D Layouts/Element Updater/Navmesh")]
	public class NavMeshElementUpdater : LayoutElementModule
	{
		public override void UpdateLocalTransform(Transform transform, VariableHolder[] variableHolders, Vector3 localPosition, Quaternion localRotation)
		{
		}

		public override void UpdateLocalPosition(Transform transform, VariableHolder[] variableHolders, Vector3 localPosition)
		{
		}

		public override void UpdateLocalRotation(Transform transform, VariableHolder[] variableHolders, Quaternion localRotation)
		{
		}

		public override void UpdateWorldTransform(Transform transform, VariableHolder[] variableHolders, Vector3 position, Quaternion rotation)
		{
		}

		public override void UpdateWorldPosition(Transform transform, VariableHolder[] variableHolders, Vector3 position)
		{
		}

		public override void UpdateWorldRotation(Transform transform, VariableHolder[] variableHolders, Quaternion rotation)
		{
		}

		private void AddAnimatorIfRequired(Transform transform)
		{
		}

		public override string VariableWarnings(VariableHolder[] variableHolders)
		{
			return null;
		}
	}
}
