using System.Xml.Linq;
using ModApi.Craft.Parts;
using UnityEngine;

namespace ModApi.Craft
{
	public class BodyJointData
	{
		public enum BodyJointType
		{
			Normal = 0,
			Hinge = 1,
			Docking = 2,
			Motor = 3
		}

		public Vector3 Axis { get; set; }

		public BodyData Body { get; set; }

		public float BreakForce { get; set; }

		public float BreakTorque { get; set; }

		public BodyData ConnectedBody { get; set; }

		public Vector3? ConnectedBodyNeutralPosition { get; set; }

		public Vector3? ConnectedBodyNeutralRotation { get; set; }

		public Vector3 ConnectedPosition { get; set; }

		public BodyJointType JointType { get; set; }

		public PartConnection PartConnection { get; private set; }

		public Vector3 Position { get; set; }

		public Vector3 SecondaryAxis { get; set; }

		public BodyJointData(PartConnection partConnection)
		{
			PartConnection = partConnection;
		}

		public BodyJointData(XElement xml, Assembly assembly)
		{
			Axis = Utilities.ParseVector3(xml.Attribute("axis").Value);
			SecondaryAxis = Utilities.GetVectorAttribute(xml, "secondaryAxis", Vector3.up);
			JointType = Utilities.GetEnumAttribute(xml, "jointType", BodyJointType.Normal);
			Body = assembly.GetBodyById((int)xml.Attribute("body"));
			Position = Utilities.ParseVector3(xml.Attribute("position").Value);
			ConnectedBody = assembly.GetBodyById((int)xml.Attribute("connectedBody"));
			ConnectedPosition = Utilities.ParseVector3(xml.Attribute("connectedPosition").Value);
			ConnectedBodyNeutralPosition = Utilities.GetVectorAttribute(xml, "connectedBodyNeutralPosition", null);
			ConnectedBodyNeutralRotation = Utilities.GetVectorAttribute(xml, "connectedBodyNeutralRotation", null);
			BreakTorque = Utilities.GetFloatAttribute(xml, "breakTorque", 0f);
			BreakForce = Utilities.GetFloatAttribute(xml, "breakForce", 0f);
		}

		public XElement GenerateXml()
		{
			return new XElement("BodyJoint", new XAttribute("body", Body.Id), new XAttribute("connectedBody", ConnectedBody.Id), ConnectedBodyNeutralPosition.HasValue ? new XAttribute("connectedBodyNeutralPosition", Utilities.Vector3ToString(ConnectedBodyNeutralPosition.Value)) : null, ConnectedBodyNeutralRotation.HasValue ? new XAttribute("connectedBodyNeutralRotation", Utilities.Vector3ToString(ConnectedBodyNeutralRotation.Value)) : null, new XAttribute("breakTorque", BreakTorque), new XAttribute("breakForce", BreakForce), new XAttribute("jointType", JointType), new XAttribute("position", Utilities.Vector3ToString(Position)), new XAttribute("connectedPosition", Utilities.Vector3ToString(ConnectedPosition)), new XAttribute("axis", Utilities.Vector3ToString(Axis)), new XAttribute("secondaryAxis", Utilities.Vector3ToString(SecondaryAxis)));
		}
	}
}
