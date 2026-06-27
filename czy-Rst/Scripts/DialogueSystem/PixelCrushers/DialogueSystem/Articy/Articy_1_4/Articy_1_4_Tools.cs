using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using UnityEngine;

namespace PixelCrushers.DialogueSystem.Articy.Articy_1_4
{
	public static class Articy_1_4_Tools
	{
		public static bool IsSchema(string xmlFilename)
		{
			return ArticyTools.DataContainsSchemaId(xmlFilename, "http://www.nevigo.com/schemas/articydraft/1.4/XmlContentExport_FullProject.xsd");
		}

		public static ArticyData LoadArticyDataFromXmlData(string xmlData, Encoding encoding)
		{
			return ConvertExportToArticyData(LoadFromXmlData(xmlData, encoding));
		}

		public static ExportType LoadFromXmlData(string xmlData, Encoding encoding)
		{
			return new XmlSerializer(typeof(ExportType)).Deserialize(new StringReader(xmlData)) as ExportType;
		}

		public static bool IsExportValid(ExportType export)
		{
			if (export != null && export.Content != null)
			{
				return export.Content.Items != null;
			}
			return false;
		}

		public static ArticyData ConvertExportToArticyData(ExportType export)
		{
			if (!IsExportValid(export))
			{
				return null;
			}
			ArticyData articyData = new ArticyData();
			articyData.project.createdOn = export.CreatedOn.ToString();
			articyData.project.creatorTool = export.CreatorTool;
			articyData.project.creatorVersion = export.CreatorVersion;
			object[] items = export.Content.Items;
			foreach (object obj in items)
			{
				ConvertProject(articyData, obj as ProjectType);
				ConvertEntity(articyData, obj as EntityType, export);
				ConvertLocation(articyData, obj as LocationType);
				ConvertFlowFragment(articyData, obj as FlowFragmentType);
				ConvertDialog(articyData, obj as DialogType);
				ConvertDialogFragment(articyData, obj as DialogFragmentType);
				ConvertHub(articyData, obj as HubType);
				ConvertJump(articyData, obj as JumpType);
				ConvertConnection(articyData, obj as ConnectionType);
			}
			ConvertHierarchy(articyData, export.Hierarchy);
			return articyData;
		}

		private static void ConvertProject(ArticyData articyData, ProjectType project)
		{
			if (project != null)
			{
				articyData.project.displayName = project.DisplayName;
			}
		}

		private static void ConvertEntity(ArticyData articyData, EntityType entity, ExportType export)
		{
			if (entity != null)
			{
				articyData.entities.Add(entity.Guid, new ArticyData.Entity(entity.Guid, entity.TechnicalName, ConvertLocalizableText(entity.DisplayName), ConvertLocalizableText(entity.Text), new ArticyData.Features(), Vector2.zero, GetPictureFilename(export, entity.PreviewImage)));
			}
		}

		private static void ConvertLocation(ArticyData articyData, LocationType location)
		{
			if (location != null)
			{
				articyData.locations.Add(location.Guid, new ArticyData.Location(location.Guid, location.TechnicalName, ConvertLocalizableText(location.DisplayName), ConvertLocalizableText(location.Text), new ArticyData.Features(), Vector2.zero));
			}
		}

		private static void ConvertFlowFragment(ArticyData articyData, FlowFragmentType flowFragment)
		{
			if (flowFragment != null)
			{
				articyData.flowFragments.Add(flowFragment.Guid, new ArticyData.FlowFragment(flowFragment.Guid, flowFragment.TechnicalName, ConvertLocalizableText(flowFragment.DisplayName), ConvertLocalizableText(flowFragment.Text), new ArticyData.Features(), Vector2.zero, ConvertPins(flowFragment.Pins)));
			}
		}

		private static void ConvertDialog(ArticyData articyData, DialogType dialogue)
		{
			if (dialogue != null)
			{
				articyData.dialogues.Add(dialogue.Guid, new ArticyData.Dialogue(dialogue.Guid, dialogue.TechnicalName, ConvertLocalizableText(dialogue.DisplayName), ConvertLocalizableText(dialogue.Text), new ArticyData.Features(), Vector2.zero, ConvertPins(dialogue.Pins), ConvertReferences(dialogue.References)));
			}
		}

		private static void ConvertDialogFragment(ArticyData articyData, DialogFragmentType dialogueFragment)
		{
			if (dialogueFragment != null)
			{
				articyData.dialogueFragments.Add(dialogueFragment.Guid, new ArticyData.DialogueFragment(dialogueFragment.Guid, dialogueFragment.TechnicalName, ConvertLocalizableText(dialogueFragment.DisplayName), ConvertLocalizableText(dialogueFragment.Text), new ArticyData.Features(), Vector2.zero, ConvertLocalizableText(dialogueFragment.PreviewText), ConvertLocalizableText(dialogueFragment.StageDirections), ConvertIdRef(dialogueFragment.Entity), ConvertPins(dialogueFragment.Pins)));
			}
		}

		private static void ConvertHub(ArticyData articyData, HubType hub)
		{
			if (hub != null)
			{
				articyData.hubs.Add(hub.Guid, new ArticyData.Hub(hub.Guid, hub.TechnicalName, ConvertLocalizableText(hub.DisplayName), ConvertLocalizableText(hub.Text), new ArticyData.Features(), Vector2.zero, ConvertPins(hub.Pins)));
			}
		}

		private static void ConvertJump(ArticyData articyData, JumpType jump)
		{
			if (jump != null)
			{
				articyData.jumps.Add(jump.Guid, new ArticyData.Jump(jump.Guid, jump.TechnicalName, ConvertLocalizableText(jump.DisplayName), ConvertLocalizableText(jump.Text), new ArticyData.Features(), Vector2.zero, ConvertConnectionRef(jump.Target), ConvertPins(jump.Pins)));
			}
		}

		private static void ConvertConnection(ArticyData articyData, ConnectionType connection)
		{
			if (connection != null)
			{
				articyData.connections.Add(connection.Guid, new ArticyData.Connection(connection.Guid, string.Empty, ConvertConnectionRef(connection.Source), ConvertConnectionRef(connection.Target)));
			}
		}

		private static ArticyData.ConnectionRef ConvertConnectionRef(ConnectionRefType connectionRef)
		{
			if (connectionRef == null)
			{
				return new ArticyData.ConnectionRef();
			}
			return new ArticyData.ConnectionRef(connectionRef.GuidRef, connectionRef.PinRef);
		}

		private static ArticyData.LocalizableText ConvertLocalizableText(LocalizableTextType localizableText)
		{
			ArticyData.LocalizableText localizableText2 = new ArticyData.LocalizableText();
			if (localizableText != null && localizableText.LocalizedString != null)
			{
				LocalizedStringType[] localizedString = localizableText.LocalizedString;
				foreach (LocalizedStringType localizedStringType in localizedString)
				{
					localizableText2.localizedString.Add(localizedStringType.Lang, ArticyTools.RemoveHtml(localizedStringType.Value));
				}
			}
			return localizableText2;
		}

		private static ArticyData.LocalizableText ConvertLocalizableText(string s)
		{
			return new ArticyData.LocalizableText
			{
				localizedString = { 
				{
					string.Empty,
					ArticyTools.RemoveHtml(s)
				} }
			};
		}

		private static List<string> ConvertReferences(ReferencesType references)
		{
			List<string> list = new List<string>();
			if (references != null && references.Reference != null)
			{
				ReferenceType[] reference = references.Reference;
				foreach (ReferenceType reference2 in reference)
				{
					list.Add(ConvertIdRef(reference2));
				}
			}
			return list;
		}

		private static string ConvertIdRef(ReferenceType reference)
		{
			if (reference == null)
			{
				return string.Empty;
			}
			return reference.GuidRef;
		}

		private static List<ArticyData.Pin> ConvertPins(PinsType pins)
		{
			List<ArticyData.Pin> list = new List<ArticyData.Pin>();
			if (pins != null && pins.Pin != null)
			{
				PinType[] pin = pins.Pin;
				foreach (PinType pinType in pin)
				{
					list.Add(new ArticyData.Pin(pinType.Guid, pinType.Index, ConvertSemanticType(pinType.Semantic), pinType.Expression));
				}
			}
			return list;
		}

		private static ArticyData.SemanticType ConvertSemanticType(SemanticType semanticType)
		{
			switch (semanticType)
			{
			case SemanticType.Input:
				return ArticyData.SemanticType.Input;
			case SemanticType.Output:
				return ArticyData.SemanticType.Output;
			default:
				Debug.LogWarning(string.Format("{0}: Unexpected semantic type {1}", "Dialogue System", semanticType.ToString()));
				return ArticyData.SemanticType.Input;
			}
		}

		private static string GetPictureFilename(ExportType export, PreviewImageType previewImage)
		{
			if (previewImage != null)
			{
				object[] items = export.Content.Items;
				foreach (object obj in items)
				{
					if (obj is AssetType)
					{
						AssetType assetType = obj as AssetType;
						if (string.Equals(assetType.Guid, previewImage.GuidRef))
						{
							return assetType.AssetFilename;
						}
					}
				}
			}
			return null;
		}

		private static void ConvertHierarchy(ArticyData articyData, HierarchyType hierarchy)
		{
			articyData.hierarchy.node = ConvertNode(hierarchy.Node, "  ");
		}

		private static ArticyData.Node ConvertNode(NodeType node, string indent)
		{
			ArticyData.Node node2 = new ArticyData.Node();
			if (node != null)
			{
				node2.id = node.Guid;
				node2.type = ConvertNodeType(node.Type);
				if (node.Node != null)
				{
					NodeType[] node3 = node.Node;
					foreach (NodeType node4 in node3)
					{
						node2.nodes.Add(ConvertNode(node4, "  " + indent));
					}
				}
			}
			return node2;
		}

		private static ArticyData.NodeType ConvertNodeType(string nodeType)
		{
			if (string.Equals(nodeType, "Dialog"))
			{
				return ArticyData.NodeType.Dialogue;
			}
			if (string.Equals(nodeType, "DialogFragment"))
			{
				return ArticyData.NodeType.DialogueFragment;
			}
			if (string.Equals(nodeType, "Hub"))
			{
				return ArticyData.NodeType.Hub;
			}
			if (string.Equals(nodeType, "Jump"))
			{
				return ArticyData.NodeType.Jump;
			}
			if (string.Equals(nodeType, "Connection"))
			{
				return ArticyData.NodeType.Connection;
			}
			return ArticyData.NodeType.Other;
		}
	}
}
