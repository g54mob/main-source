using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers.Propulsion.Propeller
{
	public class BladeAssembly
	{
		public Transform Blade { get; private set; }

		public Transform BladeMesh => BladePrefabRoot.GetComponentInChildren<MeshRenderer>().transform;

		public Transform BladePrefabRoot { get; private set; }

		public Transform Grip { get; private set; }

		public Transform Root { get; private set; }

		public BladeAssembly(Transform root)
		{
			Root = root;
			Grip = Root.Find("Grip");
			Blade = Root.Find("Blade");
			BladePrefabRoot = Blade.Find("Mesh");
			if (Blade.localEulerAngles.y != 0f)
			{
				Debug.LogWarning("The Blade transform in bladed engines must have localEulerAngles.y equal to zero for pitch adjustments to work");
			}
		}
	}
}
