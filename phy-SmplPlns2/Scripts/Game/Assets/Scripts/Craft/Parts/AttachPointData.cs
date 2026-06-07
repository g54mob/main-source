using System;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts
{
	[Serializable]
	public class AttachPointData
	{
		[field: SerializeField]
		public bool[] AdaptiveHardEdges { get; set; }

		[field: SerializeField]
		public bool AdaptiveIgnore { get; set; }

		public bool AllowManualConnection { get; private set; }

		[field: SerializeField]
		public bool AllowMultipleManualConnections { get; }

		[field: SerializeField]
		public bool AllowRotation { get; set; }

		public AttachPointScript AttachPointScript { get; set; }

		[field: SerializeField]
		public bool BodyIslandBoundary { get; set; }

		[field: SerializeField]
		public bool DetachAtCenterOfMass { get; set; }

		[field: SerializeField]
		public float DetachForceScale { get; private set; }

		[field: SerializeField]
		public bool Display { get; set; }

		[field: SerializeField]
		public bool DisplayWhenDragged { get; set; }

		public AttachPointConnectionType ExcludeType { get; private set; }

		[field: SerializeField]
		public bool FuselageConnection { get; set; }

		[field: SerializeField]
		public int Id { get; set; }

		[field: SerializeField]
		public bool IgnoreGrid { get; set; }

		[field: SerializeField]
		public bool IgnoreNormalAlignment { get; private set; }

		[field: SerializeField]
		public bool IgnoreSurfaces { get; set; }

		public bool IsAvailable
		{
			get
			{
				if (NumPartConnections != 0)
				{
					return IsSurfaceAttachPoint;
				}
				return true;
			}
		}

		public bool IsSurfaceAttachPoint => !string.IsNullOrEmpty(Surface);

		[field: SerializeField]
		public Vector3 JointAxis { get; set; }

		[field: SerializeField]
		public Vector3? JointPosition { get; set; }

		[field: SerializeField]
		public JointType JointType { get; set; }

		[field: SerializeField]
		public int MirrorId { get; set; }

		[field: SerializeField]
		public Vector3 Normal { get; set; }

		public int NumPartConnections => PartConnections.Count;

		[field: SerializeField]
		public List<PartConnection> PartConnections { get; private set; }

		[field: SerializeField]
		public Vector3 Position { get; set; }

		[field: SerializeField]
		public bool PreferUpwardsOrientation { get; private set; }

		[field: SerializeField]
		public bool PreventInertiaTensorDiffusion { get; private set; }

		[field: SerializeField]
		public AttachPointConnectionType ReceiveType { get; private set; }

		[field: SerializeField]
		public bool RequiresPhysicsJoint { get; set; }

		[field: SerializeField]
		public AttachPointConnectionType SeekType { get; private set; }

		[field: SerializeField]
		public string Surface { get; set; }

		public AttachPointData(int id, XElement element)
		{
			PartConnections = new List<PartConnection>();
			Id = id;
			Position = element.GetVector3Attribute("position", Vector3.zero);
			JointAxis = element.GetVector3Attribute("jointAxis", new Vector3(0f, 1f, 0f));
			if (element.Attribute("jointPosition") != null)
			{
				JointPosition = element.GetVector3Attribute("jointPosition", Vector3.zero);
			}
			else
			{
				JointPosition = null;
			}
			Normal = element.GetVector3Attribute("normal", Vector3.up);
			AllowManualConnection = element.GetBoolAttribute("allowManualConnection", defaultValue: true);
			AllowMultipleManualConnections = element.GetBoolAttribute("allowMultipleManualConnections");
			AllowRotation = element.GetBoolAttribute("allowRotation");
			Surface = element.GetStringAttribute("surface", string.Empty);
			AdaptiveIgnore = element.GetBoolAttribute("adaptiveIgnore");
			Display = element.GetBoolAttribute("display");
			DisplayWhenDragged = element.GetBoolAttribute("displayWhenDragged");
			IgnoreGrid = element.GetBoolAttribute("ignoreGrid");
			IgnoreSurfaces = element.GetBoolAttribute("ignoreSurfaces");
			FuselageConnection = element.GetBoolAttribute("fuselageConnection");
			DetachAtCenterOfMass = element.GetBoolAttribute("comDetach");
			DetachForceScale = element.GetFloatAttribute("detachForceScale", 1f);
			PreferUpwardsOrientation = element.GetBoolAttribute("preferUpwardsOrientation");
			PreventInertiaTensorDiffusion = element.GetBoolAttribute("preventInertiaTensorDiffusion");
			BodyIslandBoundary = element.GetBoolAttribute("bodyIslandBoundary");
			IgnoreNormalAlignment = element.GetBoolAttribute("ignoreNormalAlignment");
			MirrorId = element.GetIntAttribute("mirrorId", -1);
			JointType = element.GetEnumAttribute("jointType", JointType.Fixed);
			if (IsSurfaceAttachPoint)
			{
				SeekType = AttachPointConnectionType.None;
			}
			else
			{
				SeekType = GetAttachPointTypeBitmask(element, "seekType");
			}
			ReceiveType = GetAttachPointTypeBitmask(element, "receiveType");
			ExcludeType = GetAttachPointTypeBitmask(element, "excludeType", AttachPointConnectionType.None);
			RequiresPhysicsJoint = element.GetBoolAttribute("requiresPhysicsJoint");
			string stringAttribute = element.GetStringAttribute("a", string.Empty);
			AdaptiveHardEdges = new bool[4];
			if (stringAttribute == string.Empty || stringAttribute == "1")
			{
				for (int i = 0; i < AdaptiveHardEdges.Length; i++)
				{
					AdaptiveHardEdges[i] = true;
				}
			}
			else if (stringAttribute == "0")
			{
				for (int j = 0; j < AdaptiveHardEdges.Length; j++)
				{
					AdaptiveHardEdges[j] = false;
				}
			}
			else if (stringAttribute.Length == 4)
			{
				for (int k = 0; k < AdaptiveHardEdges.Length; k++)
				{
					AdaptiveHardEdges[k] = stringAttribute[k] == '1';
				}
			}
		}

		public bool CanReceive(AttachPointData seekingAttachPoint)
		{
			bool num = (ReceiveType & seekingAttachPoint.SeekType) != 0;
			bool flag = (ExcludeType & seekingAttachPoint.SeekType) != 0;
			bool flag2 = (seekingAttachPoint.ExcludeType & ReceiveType) != 0;
			if (num && !flag)
			{
				return !flag2;
			}
			return false;
		}

		public void RemoveConnection(PartConnection partConnection)
		{
			PartConnections.Remove(partConnection);
		}

		public void SetConnectionTypes(AttachPointConnectionType seekType, AttachPointConnectionType receiveType)
		{
			SeekType = seekType;
			ReceiveType = receiveType;
			AttachPointScript?.RefreshGizmos();
		}

		private AttachPointConnectionType GetAttachPointTypeBitmask(XElement element, string attributeName, AttachPointConnectionType defaultValue = AttachPointConnectionType.Normal)
		{
			List<AttachPointConnectionType> enumListAttribute = element.GetEnumListAttribute(attributeName, defaultValue);
			AttachPointConnectionType attachPointConnectionType = AttachPointConnectionType.None;
			foreach (AttachPointConnectionType item in enumListAttribute)
			{
				attachPointConnectionType |= item;
			}
			return attachPointConnectionType;
		}
	}
}
