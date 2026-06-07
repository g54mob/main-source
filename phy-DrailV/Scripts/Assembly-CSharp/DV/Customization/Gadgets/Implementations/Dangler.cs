using System;
using System.Collections.Generic;
using DV.CabControls;
using DV.Items;
using DV.Items.Snapping;
using DV.Utils;
using UnityEngine;

namespace DV.Customization.Gadgets.Implementations
{
	public class Dangler : MonoBehaviour
	{
		public TrainCarCustomization.TrainCarCustomizerBase attachedCustomizer;

		public SnapPointGadget snapPointGadget;

		public float angularDrag;

		public float gravityMult;

		public float trainMult;

		public bool lockOntoZAxis;

		private Vector3 lastPointVelocity;

		private List<IHangerEffect> hangerEffects = new List<IHangerEffect>();

		[NonSerialized]
		public Vector3 angularVelocity;

		private void Awake()
		{
			if (snapPointGadget != null)
			{
				snapPointGadget.ItemSnappedChanged += OnSnap;
				OnSnap(null, null, snapPointGadget.SnappedItem != null, forced: false);
			}
		}

		private void OnSnap(ItemSnapPointBase point, ItemBase item, bool snapped, bool forced)
		{
			base.enabled = snapped;
			if (!item)
			{
				return;
			}
			item.GetComponents(hangerEffects);
			foreach (IHangerEffect hangerEffect in hangerEffects)
			{
				hangerEffect.SetHanging(snapped);
			}
			if (snapped)
			{
				if (VRManager.IsVREnabled())
				{
					base.transform.rotation = item.transform.rotation;
				}
				else
				{
					base.transform.rotation = PlayerManager.ActiveCamera.transform.rotation * Quaternion.AngleAxis(180f, Vector3.up);
				}
				if (attachedCustomizer.IsOnTrainCar)
				{
					Rigidbody rb = attachedCustomizer.TrainCar.rb;
					lastPointVelocity = rb.GetPointVelocity(base.transform.position) * trainMult;
				}
			}
		}

		private void LateUpdate()
		{
			if (SingletonBehaviour<AppUtil>.Instance.IsTimePausedSafer)
			{
				return;
			}
			Quaternion rotation = base.transform.rotation;
			Vector3 vector = rotation * Vector3.down;
			if (snapPointGadget != null && Vector3.Dot(vector, Vector3.down) < 0f)
			{
				snapPointGadget.UnsnapItem(forced: true);
				return;
			}
			Vector3 vector2 = vector;
			angularVelocity.x += vector2.z * Time.deltaTime * gravityMult;
			angularVelocity.z -= vector2.x * Time.deltaTime * gravityMult;
			angularVelocity *= 1f - Time.deltaTime * angularDrag;
			if (attachedCustomizer.IsOnTrainCar)
			{
				Vector3 vector3 = attachedCustomizer.TrainCar.rb.GetPointVelocity(base.transform.position) * trainMult;
				Vector3 vector4 = vector3 - lastPointVelocity;
				float num = Vector3.Dot(vector, Vector3.down);
				float num2 = Vector3.Dot(vector, Vector3.forward);
				float num3 = Vector3.Dot(vector, Vector3.right);
				angularVelocity.x += vector4.z * num;
				angularVelocity.x += vector4.y * num2;
				angularVelocity.y += vector4.x * num2;
				angularVelocity.y -= vector4.z * num3;
				angularVelocity.z -= vector4.y * num3;
				angularVelocity.z -= vector4.x * num;
				lastPointVelocity = vector3;
			}
			rotation = Quaternion.Euler(angularVelocity * Time.deltaTime) * rotation;
			if (lockOntoZAxis)
			{
				rotation = Quaternion.LookRotation(base.transform.forward, rotation * Vector3.up);
			}
			base.transform.rotation = rotation;
		}
	}
}
