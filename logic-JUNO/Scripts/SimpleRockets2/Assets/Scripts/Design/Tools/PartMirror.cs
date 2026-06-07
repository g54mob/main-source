using System.Collections.Generic;
using Assets.Scripts.Craft;
using ModApi;
using ModApi.Craft;
using ModApi.Craft.Parts;
using ModApi.Design;
using UnityEngine;

namespace Assets.Scripts.Design.Tools
{
	public class PartMirror
	{
		private ICraftScript _craft;

		private Transform _mirrorPlane;

		public DesignerScript DesignerScript { get; }

		public List<PartData> PartsToDelete { get; private set; } = new List<PartData>();

		public List<PartData> PartsToMirror { get; private set; } = new List<PartData>();

		public PartMirror(Transform mirrorPlane, ICraftScript craft)
		{
			_mirrorPlane = mirrorPlane;
			_craft = craft;
		}

		public static PartDuplication DuplicateParts(IEnumerable<PartData> partsToDuplicate, ICraftScript craftScript)
		{
			PartDuplication partDuplication = new PartDuplication();
			foreach (PartData item in partsToDuplicate)
			{
				partDuplication.AddPart(item, CraftBuilder.DuplicatePart(item, craftScript, clearSymmetryIds: true, clearGroupIds: false));
			}
			Symmetry.RegenerateUniqueGroupIds(partDuplication.DuplicateParts);
			return partDuplication;
		}

		public static List<AttachPoint> MirrorPartConnections(ICraftScript craftScript, PartDuplication partDuplication, Quaternion mirrorPlaneRotation, Vector3 mirrorPlanePosition)
		{
			List<AttachPoint> list = new List<AttachPoint>();
			foreach (PartConnection sourcePartConnection in partDuplication.SourcePartConnections)
			{
				PartData partData = partDuplication.GetDuplicatePart(sourcePartConnection.PartA);
				PartData partData2 = partDuplication.GetDuplicatePart(sourcePartConnection.PartB);
				if (partData == null)
				{
					partData = FindMirroredSourcePart(sourcePartConnection.PartA, craftScript, mirrorPlaneRotation, mirrorPlanePosition);
					if (partData == null)
					{
						partData = sourcePartConnection.PartA;
					}
				}
				if (partData2 == null)
				{
					partData2 = FindMirroredSourcePart(sourcePartConnection.PartB, craftScript, mirrorPlaneRotation, mirrorPlanePosition);
					if (partData2 == null)
					{
						partData2 = sourcePartConnection.PartB;
					}
				}
				List<PartConnection.Attachment> list2 = new List<PartConnection.Attachment>();
				if (partData != null && partData2 != null)
				{
					foreach (PartConnection.Attachment attachment2 in sourcePartConnection.Attachments)
					{
						PartConnection.Attachment attachment = new PartConnection.Attachment();
						attachment.AttachPointA = FindMirroredAttachPoint(attachment2.AttachPointA, attachment2.AttachPointA.AttachPointScript.PartScript.Data, partData, mirrorPlaneRotation, mirrorPlanePosition);
						attachment.AttachPointB = FindMirroredAttachPoint(attachment2.AttachPointB, attachment2.AttachPointB.AttachPointScript.PartScript.Data, partData2, mirrorPlaneRotation, mirrorPlanePosition);
						if (attachment.AttachPointA != null && attachment.AttachPointB != null)
						{
							list2.Add(attachment);
						}
					}
				}
				if (list2.Count > 0)
				{
					PartConnection partConnection = new PartConnection(partData, partData2);
					foreach (PartConnection.Attachment item in list2)
					{
						partConnection.AddAttachment(item.AttachPointA, item.AttachPointB);
					}
					craftScript.Data.Assembly.AddPartConnection(partConnection);
					continue;
				}
				foreach (PartConnection.Attachment attachment3 in sourcePartConnection.Attachments)
				{
					list.Add(attachment3.AttachPointA);
					list.Add(attachment3.AttachPointB);
				}
			}
			return list;
		}

		public static void MirrorPartPositionAndRotation(IPartScript part, PartTypeMirrorConfig mirrorConfig, Quaternion sourceRotation, Vector3 sourcePosition, Quaternion mirrorPlaneRotation, Vector3 mirrorPlanePosition)
		{
			Quaternion quaternion = Quaternion.Inverse(mirrorPlaneRotation);
			part.Transform.position = CalculateMirroredPosition(sourcePosition, mirrorPlaneRotation, mirrorPlanePosition);
			if (mirrorConfig.HasRotationOffset)
			{
				Quaternion quaternion2 = sourceRotation * mirrorConfig.RotationOffset;
				Vector3 eulerAngles = (quaternion * quaternion2).eulerAngles;
				eulerAngles.y = 0f - eulerAngles.y;
				eulerAngles.z = 0f - eulerAngles.z;
				part.Transform.rotation = mirrorPlaneRotation * Quaternion.Euler(eulerAngles) * mirrorConfig.RotationOffsetInverse;
			}
			else
			{
				Vector3 eulerAngles2 = (quaternion * sourceRotation).eulerAngles;
				eulerAngles2.y = 0f - eulerAngles2.y;
				eulerAngles2.z = 0f - eulerAngles2.z;
				part.Transform.rotation = mirrorPlaneRotation * Quaternion.Euler(eulerAngles2);
			}
		}

		public static void MirrorParts(ICraftScript craftScript, PartDuplication partDuplication, Transform mirrorPlane, bool connectParts)
		{
			foreach (PartData duplicatePart2 in partDuplication.DuplicateParts)
			{
				PartData sourcePart = partDuplication.GetSourcePart(duplicatePart2);
				Quaternion rotation = sourcePart.PartScript.Transform.rotation;
				Vector3 position = sourcePart.PartScript.Transform.position;
				MirrorPartPositionAndRotation(duplicatePart2.PartScript, duplicatePart2.PartType.MirrorConfig, rotation, position, mirrorPlane.rotation, mirrorPlane.position);
				foreach (PartModifierScript modifier in duplicatePart2.PartScript.Modifiers)
				{
					modifier.OnSymmetry(SymmetryMode.Mirror, sourcePart.PartScript, created: true);
				}
			}
			if (!connectParts)
			{
				return;
			}
			List<AttachPoint> list = MirrorPartConnections(craftScript, partDuplication, mirrorPlane.rotation, mirrorPlane.position);
			List<AttachPointScript> list2 = new List<AttachPointScript>();
			foreach (AttachPoint item in list)
			{
				PartData duplicatePart = partDuplication.GetDuplicatePart(item.AttachPointScript.PartScript.Data);
				if (duplicatePart != null)
				{
					duplicatePart.GetAttachPoint(item.Id);
					list2.Clear();
					list2.AddRange(duplicatePart.PartScript.AttachPointScripts);
					_ = duplicatePart.PartScript;
					MovePartToolHelper.DetectAttachPointConnectionsAndConnect(list2);
				}
			}
		}

		public void EndMirror()
		{
			foreach (PartData item in PartsToMirror)
			{
				item.PartScript.PartMaterialScript.IsSelected = false;
			}
			foreach (PartData item2 in PartsToDelete)
			{
				item2.PartScript.PartMaterialScript.IsDisabled = false;
			}
			PartsToDelete.Clear();
			PartsToMirror.Clear();
		}

		public void IdentifyAffectedPartsFromMirrorPlane()
		{
			IReadOnlyList<PartData> parts = _craft.Data.Assembly.Parts;
			PartsToDelete.Clear();
			PartsToMirror.Clear();
			foreach (PartData item in parts)
			{
				item.PartScript.PartMaterialScript.IsSelected = false;
				item.PartScript.PartMaterialScript.IsDisabled = false;
				float x = _mirrorPlane.InverseTransformPoint(item.PartScript.Transform.position).x;
				if (x > 0.1f)
				{
					PartsToMirror.Add(item);
					item.PartScript.PartMaterialScript.IsSelected = true;
				}
				else if (x < -0.1f && item.PartScript != _craft.RootPart)
				{
					PartsToDelete.Add(item);
					item.PartScript.PartMaterialScript.IsDisabled = true;
				}
			}
		}

		public void MirrorSelectedParts()
		{
			if (PartsToDelete.Count > 0)
			{
				Symmetry.RemoveSymmetryGroupsAssociatedWithParts(PartsToDelete);
				foreach (PartData item in PartsToDelete)
				{
					_craft.DestroyPart(item, destroyPartGameObject: true);
				}
				PartsToDelete.Clear();
			}
			MirrorParts(_craft, PartsToMirror);
			Debug.LogFormat("Deleted {0} part(s) and mirrored {1} part(s)", PartsToDelete.Count, PartsToMirror.Count);
		}

		public void StartMirror()
		{
			PartsToDelete.Clear();
			PartsToMirror.Clear();
		}

		private static Vector3 CalculateMirroredPosition(Vector3 position, Quaternion mirrorPlaneRotation, Vector3 mirrorPlanePosition)
		{
			Vector3 planeNormal = mirrorPlaneRotation * Vector3.right;
			Vector3 vector = position - mirrorPlanePosition;
			Vector3 vector2 = Vector3.ProjectOnPlane(vector, planeNormal);
			return mirrorPlanePosition + vector + 2f * (vector2 - vector);
		}

		private static AttachPoint FindMirroredAttachPoint(AttachPoint sourceAttachPoint, PartData sourcePart, PartData mirroredPart, Quaternion mirrorPlaneRotation, Vector3 mirrorPlanePosition)
		{
			return mirroredPart.GetAttachPoint(sourceAttachPoint.Id);
		}

		private static PartData FindMirroredSourcePart(PartData originalPart, ICraftScript craft, Quaternion mirrorPlaneRotation, Vector3 mirrorPlanePosition)
		{
			Vector3 vec = CalculateMirroredPosition(originalPart.PartScript.Transform.position, mirrorPlaneRotation, mirrorPlanePosition);
			foreach (PartData part in craft.Data.Assembly.Parts)
			{
				if (part.PartType.Id == originalPart.PartType.Id && Utilities.CompareVector3s(part.PartScript.Transform.position, vec, 0.005f))
				{
					return part;
				}
			}
			return null;
		}

		private void MirrorParts(ICraftScript craft, IEnumerable<PartData> parts)
		{
			Symmetry.RemoveSymmetryGroupsAssociatedWithParts(parts);
			PartDuplication partDuplication = DuplicateParts(parts, craft);
			MirrorParts(craft, partDuplication, _mirrorPlane, connectParts: true);
		}
	}
}
