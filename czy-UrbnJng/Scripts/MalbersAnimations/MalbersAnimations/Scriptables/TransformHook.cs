using UnityEngine;

namespace MalbersAnimations.Scriptables
{
	[DefaultExecutionOrder(-500)]
	[AddComponentMenu("Malbers/Runtime Vars/Transform Hook")]
	[HelpURL("https://malbersanimations.gitbook.io/animal-controller/global-components/scriptables/transform-hook")]
	public class TransformHook : MonoBehaviour
	{
		[Tooltip("Transform that it will be saved on the Transform var asset")]
		public Transform Reference;

		[Tooltip("Transform Scritable var that will store at runtime a transform")]
		[CreateScriptableAsset]
		public TransformVar Hook;

		private void OnEnable()
		{
			if (Reference == null)
			{
				Reference = base.transform;
			}
			UpdateHook();
		}

		private void OnDisable()
		{
			if (Hook.Value == Reference)
			{
				DisableHook();
			}
		}

		private void OnValidate()
		{
			if (Reference == null)
			{
				Reference = base.transform;
			}
		}

		public virtual void UpdateHook()
		{
			Hook.Value = Reference;
		}

		public virtual void SetByName(string name)
		{
			IObjectCore objectCore = this.FindInterface<IObjectCore>();
			if (objectCore != null)
			{
				Hook.Value = objectCore.transform.FindGrandChild(name);
			}
		}

		public virtual void DisableHook()
		{
			Hook.Value = null;
		}

		public virtual void RemoveHook()
		{
			Hook.Value = null;
		}

		public virtual void RemoveHook(Transform val)
		{
			if (Hook.Value == val)
			{
				Hook.Value = null;
			}
		}
	}
}
