using System;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

namespace ModApi.Craft.Parts
{
	public class PartConnection
	{
		public delegate void PartConnectionDelegate(PartConnection partConnection);

		public class Attachment
		{
			public AttachPoint AttachPointA { get; set; }

			public AttachPoint AttachPointB { get; set; }

			public AttachPoint GetOtherAttachPoint(AttachPoint attachPoint)
			{
				if (attachPoint != AttachPointA)
				{
					return AttachPointA;
				}
				return AttachPointB;
			}
		}

		private Assembly _assembly;

		private List<Attachment> _attachments;

		public bool AllowManualDelete { get; set; } = true;

		public IReadOnlyList<Attachment> Attachments => _attachments;

		public BodyJointData BodyJointData { get; set; }

		public bool BreakOnStart { get; private set; }

		public bool Invalid { get; }

		public bool IsDestroyed { get; private set; }

		public bool IsPhysicsJoint { get; private set; }

		public PartData PartA { get; private set; }

		public PartData PartB { get; private set; }

		public Guid? SymmetryId { get; set; }

		public event PartConnectionDelegate Destroyed;

		public PartConnection(PartData partA, PartData partB)
		{
			Initialize(partA, partB);
		}

		public PartConnection(XElement xml, Assembly assembly)
		{
			int num = (int)xml.Attribute("partA");
			int num2 = (int)xml.Attribute("partB");
			SymmetryId = Utilities.GetGuidAttribute(xml, "symmetryId", null);
			PartData partById = assembly.GetPartById(num);
			PartData partById2 = assembly.GetPartById(num2);
			Initialize(partById, partById2);
			string[] array = xml.Attribute("attachPointsA").Value.Split(new char[1] { ',' });
			string[] array2 = xml.Attribute("attachPointsB").Value.Split(new char[1] { ',' });
			if (array.Length != array2.Length)
			{
				Debug.LogError("PartConnection: Unequal number of attach points between part A and part B.");
				Invalid = true;
				return;
			}
			for (int i = 0; i < array.Length; i++)
			{
				int num3 = DataIO.ParseInt(array[i]);
				int num4 = DataIO.ParseInt(array2[i]);
				if (num3 < PartA.AttachPoints.Count && num4 < PartB.AttachPoints.Count)
				{
					AddAttachment(PartA.AttachPoints[num3], PartB.AttachPoints[num4]);
					continue;
				}
				Debug.LogError($"Could not add attachment between part {num} (attachment {num3}) and part {num2} (attachment {num4})");
				Invalid = true;
				return;
			}
			if (Game.InFlightScene)
			{
				XElement xElement = xml.Element("BodyJoint");
				if (xElement != null)
				{
					BodyJointData = new BodyJointData(xElement, assembly);
				}
			}
		}

		public static List<PartConnection> GetPartConnectionsBetweenParts(PartData partA, PartData partB)
		{
			List<PartConnection> list = new List<PartConnection>();
			foreach (PartConnection partConnection in partA.PartConnections)
			{
				if (partConnection.GetOtherPart(partA) == partB)
				{
					list.Add(partConnection);
				}
			}
			return list;
		}

		public void AddAttachment(AttachPoint attachPointA, AttachPoint attachPointB)
		{
			if (!attachPointA.PartConnections.Contains(this))
			{
				attachPointA.PartConnections.Add(this);
			}
			if (!attachPointB.PartConnections.Contains(this))
			{
				attachPointB.PartConnections.Add(this);
			}
			IsPhysicsJoint = IsPhysicsJoint || attachPointA.JointType != JointType.Fused || attachPointB.JointType != JointType.Fused;
			if (attachPointA.JointType == JointType.Designer || attachPointB.JointType == JointType.Designer)
			{
				BreakOnStart = true;
			}
			Attachment item = new Attachment
			{
				AttachPointA = attachPointA,
				AttachPointB = attachPointB
			};
			_attachments.Add(item);
		}

		public void DestroyAttachment(Attachment attachment)
		{
			DestroyAttachment(attachment, removeFromList: true);
		}

		public void DestroyConnection()
		{
			_assembly?.RemovePartConnection(this);
			PartA.PartConnections.Remove(this);
			PartB.PartConnections.Remove(this);
			foreach (Attachment attachment in _attachments)
			{
				DestroyAttachment(attachment, removeFromList: false);
			}
			_attachments.Clear();
			IsDestroyed = true;
			BodyJointData = null;
			if (this.Destroyed != null)
			{
				this.Destroyed(this);
				this.Destroyed = null;
			}
		}

		public XElement GenerateXml()
		{
			string text = string.Empty;
			string text2 = string.Empty;
			foreach (Attachment attachment in Attachments)
			{
				text = text + DataIO.ToString(attachment.AttachPointA.Id) + ",";
				text2 = text2 + DataIO.ToString(attachment.AttachPointB.Id) + ",";
			}
			text = text.TrimEnd(',');
			text2 = text2.TrimEnd(',');
			XElement xElement = new XElement("Connection", new XAttribute("partA", PartA.Id), new XAttribute("partB", PartB.Id), new XAttribute("attachPointsA", text), new XAttribute("attachPointsB", text2));
			if (SymmetryId.HasValue)
			{
				xElement.Add(new XAttribute("symmetryId", SymmetryId.Value));
			}
			if (BodyJointData != null)
			{
				xElement.Add(BodyJointData.GenerateXml());
			}
			return xElement;
		}

		public PartData GetOtherPart(PartData part)
		{
			if (PartA != part)
			{
				return PartA;
			}
			return PartB;
		}

		public void SetAssembly(Assembly assembly)
		{
			_assembly = assembly;
		}

		private void DestroyAttachment(Attachment attachment, bool removeFromList)
		{
			attachment.AttachPointA.RemoveConnection(this);
			attachment.AttachPointB.RemoveConnection(this);
			if (removeFromList)
			{
				_attachments.Remove(attachment);
			}
			if (Game.InDesignerScene)
			{
				attachment.AttachPointA.AttachPointScript?.PartScript?.OnAttachmentDestroyed(attachment);
				attachment.AttachPointB.AttachPointScript?.PartScript?.OnAttachmentDestroyed(attachment);
			}
		}

		private void Initialize(PartData partA, PartData partB)
		{
			if (partA == partB)
			{
				throw new Exception("PartConnection: PartA and PartB cannot be the same part.");
			}
			PartA = partA;
			PartB = partB;
			PartA.PartConnections.Add(this);
			PartB.PartConnections.Add(this);
			_attachments = new List<Attachment>();
		}
	}
}
