using System;
using System.Reflection;
using UnityEngine;

namespace FIMSpace.FProceduralAnimation
{
	[DefaultExecutionOrder(50)]
	[AddComponentMenu("FImpossible Creations/Ragdoll Animator/Transfer Joint To Ragdoll Bone", 111)]
	public class RA2CopyJointToDummyBone : MonoBehaviour
	{
		public Joint ToCopy;

		public bool DestroyObjectAfterCopying;

		[Space(3f)]
		[Tooltip("Reading physical dummy bones out of the ragdoll animator")]
		public GameObject ObjectWithRagdollAnimator;

		[Space(5f)]
		[Tooltip("Transform with rigidbody to assign as 'ConnectedBody' of selected joint")]
		[HideInInspector]
		public Transform TargetParent;

		private IRagdollAnimator2HandlerOwner handler;

		private void FixedUpdate()
		{
			if (ObjectWithRagdollAnimator == null && TargetParent == null)
			{
				base.enabled = false;
				return;
			}
			if (ObjectWithRagdollAnimator != null)
			{
				handler = ObjectWithRagdollAnimator.GetComponent<IRagdollAnimator2HandlerOwner>();
				if (handler == null)
				{
					handler = GetComponent<IRagdollAnimator2HandlerOwner>();
					ObjectWithRagdollAnimator = base.gameObject;
				}
			}
			if (handler == null)
			{
				if (TargetParent == null)
				{
					base.enabled = false;
					return;
				}
				if (TargetParent.GetComponent<Rigidbody>() == null)
				{
					base.enabled = false;
					return;
				}
			}
			else
			{
				TargetParent = handler.GetRagdollHandler.User_GetBoneSetupBySourceAnimatorBone(TargetParent).PhysicalDummyBone;
			}
			if (TargetParent == null)
			{
				base.enabled = false;
				return;
			}
			Rigidbody rigidbody = TargetParent.GetComponent<Rigidbody>();
			if (rigidbody == null)
			{
				rigidbody = TargetParent.GetComponentInChildren<Rigidbody>();
			}
			if (rigidbody == null)
			{
				base.enabled = false;
				return;
			}
			Joint copyOf = GetCopyOf(TargetParent.gameObject.AddComponent(ToCopy.GetType()), ToCopy);
			copyOf.connectedBody = ToCopy.connectedBody;
			copyOf.autoConfigureConnectedAnchor = ToCopy.autoConfigureConnectedAnchor;
			base.enabled = false;
			if (DestroyObjectAfterCopying)
			{
				UnityEngine.Object.Destroy(base.gameObject);
			}
		}

		public static T GetCopyOf<T>(Component comp, T other) where T : Component
		{
			Type type = comp.GetType();
			if (type != other.GetType())
			{
				return null;
			}
			BindingFlags bindingAttr = BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;
			PropertyInfo[] properties = type.GetProperties(bindingAttr);
			foreach (PropertyInfo propertyInfo in properties)
			{
				if (propertyInfo.CanWrite)
				{
					try
					{
						propertyInfo.SetValue(comp, propertyInfo.GetValue(other, null), null);
					}
					catch
					{
					}
				}
			}
			FieldInfo[] fields = type.GetFields(bindingAttr);
			foreach (FieldInfo fieldInfo in fields)
			{
				fieldInfo.SetValue(comp, fieldInfo.GetValue(other));
			}
			return comp as T;
		}
	}
}
