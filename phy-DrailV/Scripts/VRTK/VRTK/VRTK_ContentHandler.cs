using System;
using UnityEngine;

namespace VRTK
{
	[Obsolete("`VRTK_ContentHandler` has been deprecated. This script will be removed in a future version of VRTK.")]
	public class VRTK_ContentHandler : MonoBehaviour
	{
		[Tooltip("The 3D control responsible for the content.")]
		public VRTK_Control control;

		[Tooltip("The transform containing the meshes or colliders that define the inside of the control.")]
		public Transform inside;

		[Tooltip("Any transform that will act as the parent while the object is not inside the control.")]
		public Transform outside;

		protected virtual void Start()
		{
			if (!(GetComponent<VRTK_InteractableObject>() == null))
			{
				return;
			}
			VRTK_InteractableObject[] componentsInChildren = GetComponentsInChildren<VRTK_InteractableObject>();
			foreach (VRTK_InteractableObject vRTK_InteractableObject in componentsInChildren)
			{
				if (vRTK_InteractableObject.GetComponent<VRTK_ContentHandler>() == null)
				{
					VRTK_ContentHandler vRTK_ContentHandler = vRTK_InteractableObject.gameObject.AddComponent<VRTK_ContentHandler>();
					vRTK_ContentHandler.control = control;
					vRTK_ContentHandler.inside = inside;
					vRTK_ContentHandler.outside = outside;
				}
			}
		}

		protected virtual void OnCollisionEnter(Collision collision)
		{
			if (control != null)
			{
				Bounds bounds = VRTK_SharedMethods.GetBounds(inside, null, control.GetContent().transform);
				if (VRTK_SharedMethods.GetBounds(base.transform).Intersects(bounds))
				{
					base.transform.SetParent(control.GetContent().transform);
				}
				else
				{
					base.transform.SetParent(outside);
				}
			}
		}
	}
}
