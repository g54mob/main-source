using System.Collections.Generic;
using UnityEngine;

namespace DV.Items
{
	public class TrainItemBoundingBox : MonoBehaviour
	{
		private const string CUSTOM_EXTENSIONS_PARENT_TRANSFORM_PATH = "[item_bounding_box_extension_points]";

		private static readonly Vector3 BOUNDS_HEIGHT_TWEAK = new Vector3(0f, 0.1f, 0f);

		private List<Vector3> customExtensionPoints = new List<Vector3>();

		private TrainCar car;

		private TrainCarColliders trainCarColliders;

		private bool initialized;

		public Bounds BoundingBox { get; private set; }

		public void OnCreated(TrainCar car, TrainCarColliders trainCarColliders)
		{
			this.car = car;
			if (car == null)
			{
				Debug.LogError("TrainItemBoundingBox: TrainCar is null. This should not happen. Aborting initialization", this);
				return;
			}
			this.trainCarColliders = trainCarColliders;
			if (trainCarColliders == null)
			{
				Debug.LogError("TrainItemBoundingBox: TrainCarColliders is null. This should not happen. Aborting initialization", this);
				return;
			}
			Transform transform = car.transform.Find("[item_bounding_box_extension_points]");
			if (transform != null)
			{
				for (int i = 0; i < transform.childCount; i++)
				{
					Transform child = transform.GetChild(i);
					if (!(child == null))
					{
						Vector3 position = child.position;
						Vector3 item = car.transform.InverseTransformPoint(position);
						customExtensionPoints.Add(item);
					}
				}
			}
			UpdateItemsBoundingBox(hasCargo: false);
			trainCarColliders.CargoCollidersChanged += UpdateItemsBoundingBox;
			initialized = true;
		}

		private void UpdateItemsBoundingBox(bool hasCargo)
		{
			Bounds bounds = car.Bounds;
			if (hasCargo)
			{
				Transform cargoCollision = trainCarColliders.GetCargoCollision();
				if (cargoCollision != null)
				{
					BoxCollider[] componentsInChildren = cargoCollision.GetComponentsInChildren<BoxCollider>();
					if (componentsInChildren.Length != 0)
					{
						Bounds bounds2 = BoundsUtil.BoxColliderAABB(componentsInChildren[0], car.transform);
						for (int i = 1; i < componentsInChildren.Length; i++)
						{
							Bounds bounds3 = BoundsUtil.BoxColliderAABB(componentsInChildren[i], car.transform);
							bounds2.Encapsulate(bounds3);
						}
						bounds.Encapsulate(bounds2);
					}
				}
			}
			bounds.Expand(BOUNDS_HEIGHT_TWEAK);
			bounds.center += BOUNDS_HEIGHT_TWEAK * 0.5f;
			foreach (Vector3 customExtensionPoint in customExtensionPoints)
			{
				bounds.Encapsulate(customExtensionPoint);
			}
			BoundingBox = bounds;
		}

		public void ResetToInitialState()
		{
			UpdateItemsBoundingBox(hasCargo: false);
		}
	}
}
