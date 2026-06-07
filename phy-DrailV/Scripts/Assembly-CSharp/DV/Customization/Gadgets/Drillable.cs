using System;
using System.Collections.Generic;
using DV.JObjectExtstensions;
using DV.Utils;
using Newtonsoft.Json.Linq;
using UnityEngine;

namespace DV.Customization.Gadgets
{
	[RequireComponent(typeof(GadgetBase))]
	public class Drillable : GadgetComponent
	{
		public const float POINT_CYLINDER_RADIUS = 0.025f;

		public const float POINT_MAX_DEPTH = 0.02f;

		private const string KEY_HOLE_DATA = "holes";

		private const string KEY_HOLE_STATE = "state";

		private const string KEY_HOLE_ON_GLASS = "onGlass";

		private readonly List<MountPoint> mountPoints = new List<MountPoint>();

		private readonly List<Vector3> mountPointPositions = new List<Vector3>();

		public int AttachedPointCount { get; private set; }

		public int FirmlyAttachedPointCount { get; private set; }

		public int MountPointCount => mountPoints.Count;

		public event Action OnMountPointStateChanged;

		public override GadgetBase.GadgetRemovalMethod GetValidRemovalMethodsMask()
		{
			GadgetBase.GadgetRemovalMethod gadgetRemovalMethod = GadgetBase.GadgetRemovalMethod.Any;
			if (AttachedPointCount > 0)
			{
				gadgetRemovalMethod &= ~GadgetBase.GadgetRemovalMethod.EmptyHand;
			}
			return gadgetRemovalMethod;
		}

		protected override void Awake()
		{
			base.Awake();
			GetComponentsInChildren(includeInactive: true, mountPoints);
			int num = 0;
			foreach (MountPoint mountPoint in mountPoints)
			{
				mountPoint.Drillable = this;
				mountPoint.Index = num++;
				mountPointPositions.Add(base.transform.InverseTransformPoint(mountPoint.transform.position));
			}
			base.ThisGadget.BeforeUnlinked += OnBeforeUnlinked;
		}

		public Vector3 GetMountPointLocalPosition(int index)
		{
			return new Vector3(mountPointPositions[index].x, mountPointPositions[index].y, base.ThisGadget.Bounds.max.z / 2f);
		}

		public Vector3 GetMountPointWorldPosition(int index)
		{
			return base.transform.TransformPoint(mountPointPositions[index].x, mountPointPositions[index].y, base.ThisGadget.Bounds.max.z / 2f);
		}

		public MountPoint.States GetMountPointState(int index)
		{
			return mountPoints[index].State;
		}

		public MountPoint GetMountPoint(int index)
		{
			return mountPoints[index];
		}

		public void SetMountPointState(int index, MountPoint.States newState)
		{
			if (mountPoints[index].State != newState)
			{
				mountPoints[index].State = newState;
				UpdateMountPointStates();
				this.OnMountPointStateChanged?.Invoke();
			}
		}

		public bool CheckIfCanChangeToState(int index, MountPoint.States desiredState, out bool failedDueToSurfaceConditions)
		{
			failedDueToSurfaceConditions = false;
			if (mountPoints[index].State == desiredState)
			{
				return false;
			}
			if (desiredState == MountPoint.States.None)
			{
				return true;
			}
			if (mountPoints[index].State == MountPoint.States.Mounted)
			{
				return false;
			}
			failedDueToSurfaceConditions = true;
			if (mountPoints[index].IsOnGlass && base.ThisGadget.IsGlassBroken)
			{
				return false;
			}
			CustomizationPlacementMeshes.EnsurePlacingMeshesAreActive();
			PhysicsQueryBuilder.QueryResults queryResults = from h in PhysicsQueryBuilder.OverlapSphere(GetMountPointWorldPosition(index), 0.02f, (Layers.DVLayerMask.Default | Layers.DVLayerMask.Terrain | Layers.DVLayerMask.Train_Interior | Layers.DVLayerMask.Interactable | Layers.DVLayerMask.Gadget_Mesh_Placing).ToLayerMask(), QueryTriggerInteraction.Collide)
				where !GadgetInteractor.TryGetTarget(h, out var result) || result.gameObject != base.gameObject
				select h;
			RaycastHitDV hit;
			switch (desiredState)
			{
			case MountPoint.States.Mounted:
				if (!mountPoints[index].IsOnGlass && queryResults.Length != 0)
				{
					return !queryResults.Where((RaycastHitDV h) => !DrillingDisabler.IsDrillable(h.collider) || GadgetInteractor.TryGetTarget(h, out var _)).TryGetFirst(out hit);
				}
				return false;
			case MountPoint.States.Taped:
				if (queryResults.Length != 0)
				{
					return !queryResults.Where((RaycastHitDV h) => GadgetInteractor.TryGetTarget(h, out var _)).TryGetFirst(out hit);
				}
				return false;
			default:
				return false;
			}
		}

		private void OnBeforeUnlinked(object _, object __)
		{
			for (int i = 0; i < mountPoints.Count; i++)
			{
				if (mountPoints[i].State == MountPoint.States.Mounted)
				{
					ProduceHoleAt(i);
				}
				SetMountPointState(i, MountPoint.States.None);
			}
		}

		protected internal override void GeneratePlacementData(Collider placedOnto)
		{
			base.ThisGadget.IsOnGlass = false;
			for (int i = 0; i < mountPoints.Count; i++)
			{
				PhysicsQueryBuilder.QueryResults queryResults = from h in PhysicsQueryBuilder.OverlapSphere(GetMountPointWorldPosition(i), 0.02f, Layers.DVLayerMask.Gadget_Mesh_Placing.ToLayerMask())
					where h.collider.GetComponentInParent<LocoWindowMesh>() != null
					select h;
				mountPoints[i].IsOnGlass = queryResults.Length != 0;
			}
		}

		protected internal override void OnGlassBroken()
		{
			foreach (MountPoint mountPoint in mountPoints)
			{
				if (mountPoint.IsOnGlass)
				{
					mountPoint.State = MountPoint.States.None;
				}
			}
			UpdateMountPointStates();
			if (AttachedPointCount == 0)
			{
				base.ThisGadget.ForceRemove();
			}
		}

		private void UpdateMountPointStates()
		{
			AttachedPointCount = 0;
			FirmlyAttachedPointCount = 0;
			for (int i = 0; i < mountPoints.Count; i++)
			{
				if (mountPoints[i].State != MountPoint.States.None)
				{
					AttachedPointCount++;
					if (mountPoints[i].State == MountPoint.States.Mounted)
					{
						FirmlyAttachedPointCount++;
					}
				}
			}
		}

		private void ProduceHoleAt(int pointIndex)
		{
			if (!(base.ThisGadget.Custom == null))
			{
				Vector3 mountPointWorldPosition = GetMountPointWorldPosition(pointIndex);
				Transform parentingTransform = base.ThisGadget.Custom.GetParentingTransform();
				Vector3 localPosition = parentingTransform.InverseTransformPoint(mountPointWorldPosition);
				Vector3 localNormal = parentingTransform.InverseTransformDirection(-base.transform.forward);
				if (base.ThisGadget.Custom.FindHole(localPosition, 0.02f, out var holeCollider))
				{
					base.ThisGadget.Custom.MoveHole(holeCollider, localPosition, localNormal);
				}
				else
				{
					base.ThisGadget.Custom.AddHole(localPosition, localNormal);
				}
			}
		}

		public int GetMountPointAtWorldPoint(Vector3 worldPoint)
		{
			Vector3 vector = base.transform.InverseTransformPoint(worldPoint);
			for (int i = 0; i < mountPoints.Count; i++)
			{
				Vector3 vector2 = mountPointPositions[i] - vector;
				vector2.z = 0f;
				if (vector2.sqrMagnitude < 0.00062500004f)
				{
					return i;
				}
			}
			return -1;
		}

		public int GetMountPointUsingWorldRay(Vector3 worldPoint, Vector3 worldDirection)
		{
			Vector3 vector = base.transform.InverseTransformPoint(worldPoint);
			Vector3 vector2 = base.transform.InverseTransformDirection(worldDirection);
			float num = 1f / vector2.sqrMagnitude;
			int result = -1;
			float num2 = 0.00062500004f;
			for (int i = 0; i < mountPoints.Count; i++)
			{
				float num3 = Vector3.Dot(vector2, mountPointPositions[i] - vector) * num;
				float sqrMagnitude = (vector + vector2 * num3 - mountPointPositions[i]).sqrMagnitude;
				if (!(num2 < sqrMagnitude))
				{
					num2 = sqrMagnitude;
					result = i;
				}
			}
			return result;
		}

		protected internal override void SaveDataRequested(JObject dst)
		{
			if (!(base.ThisGadget.Custom == null))
			{
				PooledArray<JObject> pooledArray = ArrayPool<JObject>.New(mountPoints.Count);
				for (int i = 0; i < pooledArray.Length; i++)
				{
					pooledArray[i] = new JObject();
					pooledArray[i].SetInt("state", (int)mountPoints[i].State);
					pooledArray[i].SetBool("onGlass", mountPoints[i].IsOnGlass);
				}
				dst.SetJObjectArray("holes", pooledArray);
				pooledArray.Dispose();
			}
		}

		protected internal override void SaveDataLoaded(JObject src)
		{
			if (base.ThisGadget.Custom == null)
			{
				return;
			}
			JObject[] jObjectArray = src.GetJObjectArray("holes");
			if (jObjectArray == null)
			{
				Debug.LogError("[CUSTOMIZATION] Drillable hole data missing!");
				return;
			}
			for (int i = 0; i < jObjectArray.Length && i < mountPoints.Count; i++)
			{
				MountPoint.States states = (MountPoint.States)(jObjectArray[i].GetInt("state") ?? 0);
				if (Enum.IsDefined(typeof(MountPoint.States), states))
				{
					mountPoints[i].State = states;
				}
				mountPoints[i].IsOnGlass = jObjectArray[i].GetBool("onGlass") ?? false;
			}
			UpdateMountPointStates();
		}

		private void OnDrawGizmosSelected()
		{
			MountPoint[] componentsInChildren = GetComponentsInChildren<MountPoint>(includeInactive: true);
			Gizmos.matrix = base.transform.localToWorldMatrix;
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				Vector3 to = base.transform.InverseTransformPoint(componentsInChildren[i].transform.position);
				Gizmos.color = Color.yellow;
				Gizmos.DrawLine(new Vector3(to.x - 0.05f, to.y, to.z), new Vector3(to.x + 0.05f, to.y, to.z));
				Gizmos.DrawLine(new Vector3(to.x, to.y - 0.05f, to.z), new Vector3(to.x, to.y + 0.05f, to.z));
				Gizmos.color = Color.white;
				Gizmos.DrawLine(new Vector3(to.x, to.y, to.z - 0.2f), to);
			}
		}
	}
}
