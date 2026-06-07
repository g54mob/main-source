using System;
using System.Collections.Generic;
using System.Xml.Linq;
using ModApi.Craft.Parts;
using UnityEngine;

namespace ModApi.Craft
{
	public class BodyData
	{
		public IBodyScript BodyScript { get; set; }

		public Vector3 CenterOfMass { get; set; }

		public int Id { get; set; }

		public bool IsDestroyed { get; private set; }

		public float Mass { get; set; }

		public List<PartData> Parts { get; private set; }

		public Vector3 Position { get; private set; }

		public Vector3 Rotation { get; private set; }

		public BodyData(Vector3 position, Vector3 rotation, float mass)
		{
			Id = 0;
			Parts = new List<PartData>();
			Position = position;
			Rotation = rotation;
			Mass = mass;
			CenterOfMass = Vector3.zero;
		}

		public BodyData(XElement xml, Assembly assembly)
		{
			Parts = new List<PartData>();
			string value = xml.Attribute("partIds").Value;
			if (!string.IsNullOrWhiteSpace(value))
			{
				string[] array = value.Split(new char[1] { ',' });
				foreach (string text in array)
				{
					PartData partById = assembly.GetPartById(DataIO.ParseInt(text));
					if (partById != null)
					{
						Parts.Add(partById);
					}
					else
					{
						Debug.LogError("Could not find part with ID=" + text);
					}
				}
			}
			Id = (int)xml.Attribute("id");
			Position = Utilities.ParseVector3(xml.Attribute("position").Value);
			Rotation = Utilities.ParseVector3(xml.Attribute("rotation").Value);
			Mass = (float)xml.Attribute("mass");
			CenterOfMass = Utilities.GetVectorAttribute(xml, "centerOfMass", Vector3.zero);
		}

		public XElement GenerateXml(Transform craftTransform)
		{
			Synchronize(craftTransform);
			string text = string.Empty;
			foreach (PartData part in Parts)
			{
				text = text + part.Id + ",";
			}
			text = text.Trim(',');
			return new XElement("Body", new XAttribute("id", Id), new XAttribute("partIds", text), new XAttribute("mass", Mass), new XAttribute("position", Utilities.Vector3ToString(Position)), new XAttribute("rotation", Utilities.Vector3ToString(Rotation)), new XAttribute("centerOfMass", Utilities.Vector3ToString(CenterOfMass)));
		}

		public void OnBodyDestroyed()
		{
			if (!IsDestroyed)
			{
				IsDestroyed = true;
				return;
			}
			Debug.LogErrorFormat("Body {0} is already destroyed.", Id);
		}

		private void Synchronize(Transform craftTransform)
		{
			if (BodyScript != null)
			{
				BodyScript.RecalculateMass();
				Position = BodyScript.Transform.localPosition;
				Rotation = BodyScript.Transform.localRotation.eulerAngles;
			}
		}
	}
}
