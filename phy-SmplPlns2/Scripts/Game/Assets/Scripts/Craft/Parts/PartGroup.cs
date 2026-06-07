using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Craft.Parts.Modifiers;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts
{
	public class PartGroup
	{
		public static void BuildGlassPartGroup(PartData part, TransparencyData modifier, List<PartData> remainingParts, GlassGroupScript partGroup, int maxPartsPerGroup)
		{
			if (part.IsCockpit)
			{
				if (partGroup.Parts.Count == 0)
				{
					part.PartScript.transform.parent = partGroup.transform;
					part.PartScript.PartGroup = partGroup;
					partGroup.Parts.Add(part.PartScript);
					partGroup.TransparencyModifiers.Add(modifier);
					remainingParts.Remove(part);
				}
				return;
			}
			part.PartScript.transform.parent = partGroup.transform;
			part.PartScript.PartGroup = partGroup;
			partGroup.Parts.Add(part.PartScript);
			partGroup.TransparencyModifiers.Add(modifier);
			remainingParts.Remove(part);
			if (modifier?.Fuselage == null)
			{
				return;
			}
			TransparencyData connectedFront = modifier.ConnectedFront;
			if (connectedFront != null)
			{
				PartData part2 = connectedFront.Part;
				if (partGroup.IsCompatibleWith(part2, connectedFront) && remainingParts.Contains(part2))
				{
					BuildGlassPartGroup(part2, connectedFront, remainingParts, partGroup, maxPartsPerGroup);
				}
			}
			connectedFront = modifier.ConnectedBack;
			if (connectedFront != null)
			{
				PartData part3 = connectedFront.Part;
				if (partGroup.IsCompatibleWith(part3, connectedFront) && remainingParts.Contains(part3))
				{
					BuildGlassPartGroup(part3, connectedFront, remainingParts, partGroup, maxPartsPerGroup);
				}
			}
		}

		public static void BuildPartGroup(PartData part, List<PartData> remainingParts, PartGroupScript partGroup, int maxPartsPerGroup)
		{
			if (part.IsCockpit)
			{
				if (partGroup.Parts.Count == 0)
				{
					part.PartScript.transform.parent = partGroup.transform;
					part.PartScript.PartGroup = partGroup;
					partGroup.Parts.Add(part.PartScript);
					remainingParts.Remove(part);
				}
				return;
			}
			part.PartScript.transform.parent = partGroup.transform;
			part.PartScript.PartGroup = partGroup;
			partGroup.Parts.Add(part.PartScript);
			remainingParts.Remove(part);
			IEnumerable<PartData> enumerable2;
			if (part.PartConnections.Count != 1)
			{
				IEnumerable<PartData> enumerable = from x in part.PartConnections
					select x.GetOtherPart(part) into x
					orderby x.PartConnections.Count
					select x;
				enumerable2 = enumerable;
			}
			else
			{
				IEnumerable<PartData> enumerable = new PartData[1] { part.PartConnections[0].GetOtherPart(part) };
				enumerable2 = enumerable;
			}
			foreach (PartData item in enumerable2)
			{
				TransparencyData modifier;
				if ((partGroup.Parts.Count < maxPartsPerGroup || item.PartConnections.Count == 1) && remainingParts.Contains(item) && ((modifier = item.GetModifier<TransparencyData>()) == null || !modifier.IsTransparent))
				{
					BuildPartGroup(item, remainingParts, partGroup, maxPartsPerGroup);
				}
			}
		}

		public static void CreatePartGroups(BodyScript body, List<PartData> parts, ref int partGroupId)
		{
			List<PartData> list = new List<PartData>(parts.OrderByDescending((PartData x) => x.PartConnections.Count));
			int num = 5;
			int num2 = list.Count / num;
			if (num2 < 5)
			{
				num2 = 5;
			}
			while (list.Count > 0)
			{
				PartData partData = list[0];
				if (partData.PartScript.PartGroup != null)
				{
					Debug.LogError($"Unable to add part '{partData.Name} (ID: {partData.Id})' to body '{body.name}' " + "because the part already belongs to part group '" + partData.PartScript.PartGroup.name + "' in body '" + partData.PartScript.PartGroup.Body.name + "'.");
					list.RemoveAt(0);
					continue;
				}
				TransparencyData modifier = partData.GetModifier<TransparencyData>();
				if (modifier != null && modifier.IsTransparent && modifier.Fuselage != null)
				{
					GlassGroupScript glassGroupScript = new GameObject("GlassPartGroup-" + partGroupId)
					{
						layer = 21
					}.AddComponent<GlassGroupScript>();
					glassGroupScript.Id = partGroupId++;
					glassGroupScript.Body = body;
					glassGroupScript.transform.parent = body.transform;
					glassGroupScript.transform.localPosition = Vector3.zero;
					glassGroupScript.transform.localScale = Vector3.one;
					glassGroupScript.transform.rotation = Quaternion.identity;
					glassGroupScript.InitFrom(partData, modifier);
					BuildGlassPartGroup(partData, modifier, list, glassGroupScript, num2);
					body.PartGroups.Add(glassGroupScript);
				}
				else
				{
					PartGroupScript partGroupScript = new GameObject("PartGroup")
					{
						layer = 21
					}.AddComponent<PartGroupScript>();
					partGroupScript.gameObject.name = "PartGroup-" + partGroupId;
					partGroupScript.Id = partGroupId++;
					partGroupScript.Body = body;
					partGroupScript.transform.parent = body.transform;
					partGroupScript.transform.localPosition = Vector3.zero;
					partGroupScript.transform.localScale = Vector3.one;
					partGroupScript.transform.rotation = Quaternion.identity;
					BuildPartGroup(partData, list, partGroupScript, num2);
					body.PartGroups.Add(partGroupScript);
				}
				body.Aircraft.RegisterPartGroup(partData.PartScript.PartGroup);
			}
		}
	}
}
