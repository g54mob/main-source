using System;
using System.Collections.Generic;
using System.Xml.Linq;
using ModApi.Craft;
using ModApi.Craft.Parts;
using ModApi.Design;
using UnityEngine;

namespace Assets.Scripts.Design
{
	public class SymmetryGroup : ISymmetryGroup
	{
		public AttachPoint AttachPoint { get; private set; }

		public int Count { get; private set; }

		public IPartScript RootPart { get; private set; }

		public List<ISymmetrySlice> Slices { get; private set; } = new List<ISymmetrySlice>();

		public SymmetryMode SymmetryMode { get; private set; }

		public SymmetryGroup(SymmetryMode symmetryMode, AttachPoint attachPoint, int customCount)
		{
			AttachPoint = attachPoint;
			RootPart = attachPoint.AttachPointScript.PartScript;
			SymmetryMode = symmetryMode;
			float num = 0f;
			float num3;
			int num2;
			switch (symmetryMode)
			{
			case SymmetryMode.None:
				throw new Exception("Invalid symmetry mode for symmetry group.");
			case SymmetryMode.Mirror:
				num3 = 0f;
				num2 = 2;
				break;
			case SymmetryMode.Custom:
				num2 = customCount;
				num3 = 360f / (float)num2;
				break;
			default:
				num2 = (int)symmetryMode;
				num3 = 360 / num2;
				break;
			}
			Count = num2;
			for (int i = 0; i < num2; i++)
			{
				Slices.Add(new SymmetrySlice(this, num));
				num += num3;
			}
		}

		private SymmetryGroup()
		{
		}

		public static void LoadSymmetryGroup(XElement xml, Assembly assembly)
		{
			SymmetryGroup symmetryGroup = new SymmetryGroup();
			try
			{
				symmetryGroup.SymmetryMode = (SymmetryMode)Enum.Parse(typeof(SymmetryMode), xml.Attribute("mode").Value, ignoreCase: true);
				int partId = (int)xml.Attribute("rootPartId");
				symmetryGroup.RootPart = assembly.GetPartById(partId).PartScript;
				int index = (int)xml.Attribute("attachPointId");
				symmetryGroup.AttachPoint = symmetryGroup.RootPart.Data.AttachPoints[index];
				int num = 0;
				foreach (XElement item in xml.Elements("Slice"))
				{
					num++;
					float angle = (float)item.Attribute("angle");
					SymmetrySlice symmetrySlice = new SymmetrySlice(symmetryGroup, angle);
					symmetryGroup.Slices.Add(symmetrySlice);
					int partId2 = (int)item.Attribute("rootPartId");
					symmetrySlice.SliceRootPart = assembly.GetPartById(partId2);
					symmetrySlice.SliceRootPart.SymmetryMode = symmetryGroup.SymmetryMode;
					string[] array = item.Attribute("parts").Value.Split(new char[1] { ',' });
					for (int i = 0; i < array.Length; i++)
					{
						int num2 = DataIO.ParseInt(array[i]);
						PartData partById = assembly.GetPartById(num2);
						if (partById != null)
						{
							if (partById.SymmetryId.HasValue)
							{
								symmetrySlice.Parts.Add(partById);
								continue;
							}
							Debug.LogErrorFormat("Symmetry slice claims to own part (id={0}), but part has no symmetry ID. Removing part from Symmetry.", partById.Id);
						}
						else
						{
							Debug.LogErrorFormat("Could not find part with id={0} for symmetry slice.", num2);
						}
					}
				}
				symmetryGroup.Count = num;
				Dictionary<int, bool> dictionary = new Dictionary<int, bool>();
				foreach (ISymmetrySlice slice in symmetryGroup.Slices)
				{
					foreach (PartData part in slice.Parts)
					{
						if (!dictionary.ContainsKey(part.Id))
						{
							part.PartScript.SymmetrySlice = slice;
							dictionary[part.Id] = true;
							continue;
						}
						throw new Exception($"Symmetry Group has same part (id={part.Id}) in multiple slices");
					}
				}
			}
			catch (Exception message)
			{
				Debug.LogError(message);
				Symmetry.RemoveSymmetryGroup(symmetryGroup);
			}
		}

		public XElement GenerateXml()
		{
			XElement xElement = new XElement("Group");
			xElement.Add(new XAttribute("mode", SymmetryMode));
			xElement.Add(new XAttribute("rootPartId", AttachPoint.AttachPointScript.PartScript.Data.Id));
			xElement.Add(new XAttribute("attachPointId", AttachPoint.Id));
			foreach (ISymmetrySlice slice in Slices)
			{
				XElement xElement2 = new XElement("Slice");
				xElement2.Add(new XAttribute("angle", slice.Angle));
				xElement2.Add(new XAttribute("rootPartId", slice.SliceRootPart.Id));
				string text = string.Empty;
				foreach (PartData part in slice.Parts)
				{
					text = text + DataIO.ToString(part.Id) + ",";
				}
				text = text.TrimEnd(',');
				xElement2.Add(new XAttribute("parts", text));
				xElement.Add(xElement2);
			}
			return xElement;
		}
	}
}
