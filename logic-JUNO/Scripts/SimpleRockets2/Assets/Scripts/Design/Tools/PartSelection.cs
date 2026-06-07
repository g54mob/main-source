using System;
using System.Collections.Generic;
using Assets.Scripts.Craft.Parts;
using ModApi.Craft;
using ModApi.Craft.Parts;
using ModApi.Design;
using UnityEngine;

namespace Assets.Scripts.Design.Tools
{
	public class PartSelection
	{
		public class PartLimb
		{
			public IPartScript BasePart { get; }

			public List<IPartScript> Parts { get; private set; } = new List<IPartScript>();

			public List<PartConnection> RootSideConnections { get; private set; } = new List<PartConnection>();

			public PartLimb(IPartScript basePart)
			{
				BasePart = basePart;
			}
		}

		private PartCollisionDetector _collisionDetector;

		public ICollection<AttachPointScript> AllAttachPoints { get; set; }

		public ICollection<AttachPointScript> AvailableAttachPoints { get; set; }

		public int ConnectionMask { get; }

		public Transform ContainerParent { get; set; }

		public bool HasBeforeDepthMaskRenderQueue { get; }

		public PartCollisionDetector PartCollisionDetector => _collisionDetector;

		public List<IPartScript> Parts { get; set; }

		public bool PartsColliding { get; set; }

		public ICollection<ISymmetryGroup> SymmetryGroups { get; set; }

		public PartSelection(ICollection<IPartScript> partScripts, Vector3 containerPosition, Quaternion containerRotation)
		{
			Transform transform = new GameObject("MovingParts").transform;
			transform.SetPositionAndRotation(containerPosition, containerRotation);
			transform.localScale = new Vector3(1f, 1f, 1f);
			_collisionDetector = new PartCollisionDetector();
			List<IPartScript> list = new List<IPartScript>();
			AllAttachPoints = new List<AttachPointScript>();
			AvailableAttachPoints = new List<AttachPointScript>();
			SymmetryGroups = new List<ISymmetryGroup>();
			Parts = new List<IPartScript>();
			foreach (IPartScript partScript in partScripts)
			{
				Parts.Add(partScript);
				partScript.Transform.parent = transform;
				list.Add(partScript);
				_collisionDetector.AddPartSelection(partScript);
				if (partScript.Data.SymmetryId.HasValue)
				{
					ISymmetrySlice symmetrySlice = ((PartScript)partScript).SymmetrySlice;
					if (symmetrySlice != null && !SymmetryGroups.Contains(symmetrySlice.SymmetryGroup))
					{
						SymmetryGroups.Add(symmetrySlice.SymmetryGroup);
					}
				}
				HasBeforeDepthMaskRenderQueue = false;
				foreach (AttachPoint attachPoint in partScript.Data.AttachPoints)
				{
					HasBeforeDepthMaskRenderQueue = HasBeforeDepthMaskRenderQueue || attachPoint.RenderQueue == PartMeshRenderQueue.BeforeDepthMask;
					AllAttachPoints.Add(attachPoint.AttachPointScript);
					if (attachPoint.IsAvailable)
					{
						AvailableAttachPoints.Add(attachPoint.AttachPointScript);
					}
				}
			}
			List<ISymmetryGroup> list2 = new List<ISymmetryGroup>();
			foreach (ISymmetryGroup symmetryGroup in SymmetryGroups)
			{
				if (!list.Contains(symmetryGroup.RootPart))
				{
					continue;
				}
				foreach (ISymmetrySlice slice in symmetryGroup.Slices)
				{
					foreach (PartData part in slice.Parts)
					{
						if (!Parts.Contains(part.PartScript) && !list2.Contains(symmetryGroup))
						{
							list2.Add(symmetryGroup);
						}
						foreach (AttachPointScript attachPointScript in part.PartScript.AttachPointScripts)
						{
							AvailableAttachPoints.Remove(attachPointScript);
						}
					}
				}
			}
			foreach (ISymmetryGroup item in list2)
			{
				Symmetry.RemoveSymmetryGroup(item);
				SymmetryGroups?.Remove(item);
				Debug.Log($"Removing severed symmetry group (root part '{item.RootPart?.Data?.Name}' with ID '{item.RootPart?.Data?.Id}').");
			}
			HideScript[] componentsInChildren = transform.GetComponentsInChildren<HideScript>(includeInactive: true);
			foreach (HideScript hideScript in componentsInChildren)
			{
				if (hideScript.DisplayOnlyWhenDragged)
				{
					hideScript.gameObject.SetActive(value: true);
				}
			}
			foreach (AttachPointScript allAttachPoint in AllAttachPoints)
			{
				allAttachPoint.gameObject.layer = 2;
				ConnectionMask |= (int)allAttachPoint.AttachPoint.ConnectionType;
			}
			ContainerParent = transform;
			PartsColliding = false;
		}

		public static PartSelection CreatePartSelection(IPartScript basePart, bool preserveConnections, Quaternion? containerRotation = null, Vector3? containerPosition = null, bool selectSinglePart = false)
		{
			ICollection<IPartScript> collection = null;
			bool flag = false;
			if (selectSinglePart)
			{
				collection = new List<IPartScript>();
				List<PartConnection> list = new List<PartConnection>();
				if (basePart.Data.GroupId.HasValue)
				{
					WeldedPartGroup weldedPartGroup = new WeldedPartGroup(basePart.Data);
					list.AddRange(weldedPartGroup.BoundaryConnections);
					foreach (PartData part in weldedPartGroup.Parts)
					{
						collection.Add(part.PartScript);
					}
				}
				else
				{
					collection.Add(basePart);
					list.AddRange(basePart.Data.PartConnections);
				}
				if (!preserveConnections)
				{
					foreach (PartConnection item in list)
					{
						foreach (PartConnection.Attachment attachment in item.Attachments)
						{
							flag = flag || attachment.AttachPointA.RenderQueue == PartMeshRenderQueue.BeforeDepthMask || attachment.AttachPointB.RenderQueue == PartMeshRenderQueue.BeforeDepthMask;
						}
						item.DestroyConnection();
					}
				}
			}
			else
			{
				PartLimb partLimb = FindPartsToMove(basePart, preserveConnections);
				collection = partLimb.Parts;
				if (!preserveConnections)
				{
					foreach (PartConnection rootSideConnection in partLimb.RootSideConnections)
					{
						foreach (PartConnection.Attachment attachment2 in rootSideConnection.Attachments)
						{
							flag = flag || attachment2.AttachPointA.RenderQueue == PartMeshRenderQueue.BeforeDepthMask || attachment2.AttachPointB.RenderQueue == PartMeshRenderQueue.BeforeDepthMask;
						}
					}
				}
			}
			Quaternion containerRotation2 = ((!containerRotation.HasValue) ? basePart.Transform.rotation : containerRotation.Value);
			Vector3 containerPosition2 = ((!containerPosition.HasValue) ? basePart.Transform.position : containerPosition.Value);
			PartSelection partSelection = new PartSelection(collection, containerPosition2, containerRotation2);
			if (flag && !partSelection.HasBeforeDepthMaskRenderQueue)
			{
				foreach (IPartScript part2 in partSelection.Parts)
				{
					part2.Data.Config.RenderQueue = PartMeshRenderQueue.Default;
				}
			}
			return partSelection;
		}

		public static PartLimb FindPartLimb(IPartScript basePart, bool onlyIncludeGroupedParts = false)
		{
			if (basePart.Data.GroupId.HasValue)
			{
				return FindPartLimbFromWeldedPartGroup(new WeldedPartGroup(basePart.Data), onlyIncludeGroupedParts);
			}
			PartLimb partLimb = new PartLimb(basePart);
			foreach (PartConnection partConnection in basePart.Data.PartConnections)
			{
				if (new PartGraph(partConnection.GetOtherPart(basePart.Data), basePart.Data).HasRoot)
				{
					partLimb.RootSideConnections.Add(partConnection);
				}
			}
			foreach (PartData part in new PartGraph(basePart.Data, partLimb.RootSideConnections).Parts)
			{
				partLimb.Parts.Add(part.PartScript);
			}
			return partLimb;
		}

		public static PartLimb FindPartLimbFromWeldedPartGroup(WeldedPartGroup group, bool onlyIncludeGroupedParts)
		{
			PartLimb partLimb = new PartLimb(group.BasePart.PartScript);
			PartLookup partLookup = new PartLookup();
			foreach (PartData boundaryPart in group.BoundaryParts)
			{
				PartGraph partGraph = new PartGraph(boundaryPart, group.BoundaryConnections);
				if (partGraph.HasRoot)
				{
					foreach (PartConnection partConnection in boundaryPart.PartConnections)
					{
						PartData otherPart = partConnection.GetOtherPart(boundaryPart);
						Guid? groupId = otherPart.GroupId;
						Guid groupId2 = group.GroupId;
						if (groupId.HasValue && (!groupId.HasValue || groupId.GetValueOrDefault() == groupId2) && group.Parts.Contains(otherPart))
						{
							partLimb.RootSideConnections.Add(partConnection);
						}
					}
				}
				else
				{
					if (onlyIncludeGroupedParts)
					{
						continue;
					}
					foreach (PartData part in partGraph.Parts)
					{
						partLookup.AddPart(part);
					}
				}
			}
			foreach (PartData part2 in group.Parts)
			{
				partLookup.AddPart(part2);
			}
			foreach (PartData part3 in partLookup.Parts)
			{
				partLimb.Parts.Add(part3.PartScript);
			}
			return partLimb;
		}

		public void Deselect()
		{
			HideScript[] componentsInChildren = ContainerParent.GetComponentsInChildren<HideScript>(includeInactive: true);
			foreach (HideScript hideScript in componentsInChildren)
			{
				if (hideScript.DisplayOnlyWhenDragged)
				{
					hideScript.gameObject.SetActive(value: false);
				}
			}
			for (int num = ContainerParent.childCount - 1; num >= 0; num--)
			{
				ContainerParent.GetChild(num).parent = Game.Instance.Designer.CraftScript.Transform;
			}
			foreach (AttachPointScript allAttachPoint in AllAttachPoints)
			{
				allAttachPoint.UpdateLayer();
			}
			ContainerParent.gameObject.SetActive(value: false);
			UnityEngine.Object.Destroy(ContainerParent.gameObject);
		}

		public bool DetectCollisions()
		{
			return _collisionDetector.DetectCollisions(updateMaterials: false);
		}

		private static PartLimb FindPartsToMove(IPartScript selectedPart, bool preserveConnections)
		{
			PartLimb partLimb = FindPartLimb(selectedPart);
			if (!preserveConnections)
			{
				foreach (PartConnection rootSideConnection in partLimb.RootSideConnections)
				{
					Symmetry.RemovePartConnection(selectedPart, rootSideConnection);
					rootSideConnection.DestroyConnection();
				}
			}
			return partLimb;
		}
	}
}
