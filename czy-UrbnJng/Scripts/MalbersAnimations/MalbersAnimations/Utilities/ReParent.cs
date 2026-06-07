using UnityEngine;

namespace MalbersAnimations.Utilities
{
	[AddComponentMenu("Malbers/Utilities/Tools/Parent")]
	public class ReParent : MonoBehaviour
	{
		[Tooltip("Reparent this gameObject to a new Transform. Use this to have more organized GameObjects on the hierarchy")]
		[ContextMenuItem("Use Bone Name", "SetUseName")]
		public Transform newParent;

		[Tooltip("Reparent this gameObject to a new Transform. Use this to have more organized GameObjects on the hierarchy")]
		[ContextMenuItem("Use Transform", "SetUseTransform")]
		public string NewParentName;

		public bool ResetLocal;

		[SerializeField]
		[HideInInspector]
		private bool UseName;

		private void OnEnable()
		{
			if (UseName)
			{
				newParent = base.transform.FindObjectCore().FindGrandChild(NewParentName);
				base.transform.SetParent(newParent, worldPositionStays: true);
			}
			else if (newParent == null)
			{
				base.transform.parent = null;
			}
			else
			{
				base.transform.SetParent(newParent, worldPositionStays: true);
			}
			if (ResetLocal)
			{
				base.transform.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);
			}
		}

		private void Reset()
		{
			newParent = base.transform.parent;
		}

		private void SetUseName()
		{
			UseName = true;
		}

		private void SetUseTransform()
		{
			UseName = false;
		}
	}
}
