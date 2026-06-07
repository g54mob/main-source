using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Assets.Scripts.Craft.Parts.Styles;
using Assets.Scripts.Design;
using Jundroo.ModTools;
using ModApi.Craft.Parts;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts
{
	public static class PartLoader
	{
		public static void LoadDesignerParts(IEnumerable<string> designerPartXml, ILoadedMod mod)
		{
			try
			{
				List<XDocument> list = new List<XDocument>();
				foreach (string item2 in designerPartXml)
				{
					try
					{
						XDocument item = XDocument.Parse(item2);
						list.Add(item);
					}
					catch (Exception exception)
					{
						Debug.LogException(exception);
						Debug.LogError((mod == null) ? "An error occurred trying to load designer part XML." : ("An error occurred trying to load designer part XML from mod '" + mod.ModInfo.Name + "'."));
					}
				}
				LoadDesignerParts(list, mod);
			}
			catch (Exception exception2)
			{
				Debug.LogException(exception2);
				Debug.LogError((mod == null) ? "An error occurred trying to load designer parts." : ("An error occurred trying to load designer parts from mod '" + mod.ModInfo.Name + "'."));
			}
		}

		public static void LoadParts(IEnumerable<string> partXml, ILoadedMod mod)
		{
			try
			{
				List<XDocument> list = new List<XDocument>();
				List<XDocument> list2 = new List<XDocument>();
				foreach (string item in partXml)
				{
					try
					{
						XDocument xDocument = XDocument.Parse(item);
						switch (xDocument.Root.Name.LocalName)
						{
						case "Part":
							list.Add(xDocument);
							break;
						case "DesignerParts":
						case "DesignerPart":
							list2.Add(xDocument);
							break;
						default:
							Debug.LogError((mod == null) ? "An error occurred trying to load part XML because it did not contain one of the expected root elements." : ("An error occurred trying to load part XML from mod '" + mod.ModInfo.Name + "' because it did not contain one of the expected root elements."));
							break;
						}
					}
					catch (Exception exception)
					{
						Debug.LogException(exception);
						Debug.LogError((mod == null) ? "An error occurred trying to load part XML." : ("An error occurred trying to load part XML from mod '" + mod.ModInfo.Name + "'."));
					}
				}
				PartTypeList partTypes = Game.Instance.PartTypes;
				PartStyleManagerScript partStyleManagerScript = (PartStyleManagerScript)Game.Instance.PartStyleManager;
				foreach (XDocument item2 in list)
				{
					XElement xElement = item2.Root?.Element("PartType");
					if (xElement == null)
					{
						Debug.LogError((mod == null) ? "An error occurred trying to load a part because the part XML does not contain a PartType element." : ("An error occurred trying to load a part from mod '" + mod.ModInfo.Name + "' because the part XML does not contain a PartType element."));
						continue;
					}
					string text = (string)xElement.Attribute("id");
					try
					{
						text = partTypes.Add(xElement, mod).Id;
					}
					catch (Exception exception2)
					{
						Debug.LogException(exception2);
						Debug.LogError((mod == null) ? ("An error occurred trying to load a part type '" + text + "'.") : ("An error occurred trying to load a part type '" + text + "' from mod '" + mod.ModInfo.Name + "'."));
						continue;
					}
					XElement xElement2 = item2.Root.Element("PartStyles");
					if (xElement2 == null)
					{
						Debug.LogError((mod == null) ? ("Part styles could not be found for part '" + text + "'.") : ("Part styles could not be found for part '" + text + "' from mod '" + mod.ModInfo.Name + "'."));
					}
					if (xElement2 != null)
					{
						try
						{
							partStyleManagerScript.LoadPartStyles(text, xElement2);
						}
						catch (Exception exception3)
						{
							Debug.LogException(exception3);
							Debug.LogError((mod == null) ? ("An error occurred loading part styles for part '" + text + "'.") : ("An error occurred loading part styles for part '" + text + "' from mod '" + mod.ModInfo.Name + "'."));
						}
					}
					List<XElement> list3 = item2.Root.Elements("DesignerParts").Elements("DesignerPart").ToList();
					if (list3.Count == 0)
					{
						Debug.LogError((mod == null) ? ("Designer parts could not be found for part '" + text + "'.") : ("Designer parts could not be found for part '" + text + "' from mod '" + mod.ModInfo.Name + "'."));
					}
					LoadDesignerParts(list3, text, mod);
				}
				LoadDesignerParts(list2, mod);
			}
			catch (Exception exception4)
			{
				Debug.LogException(exception4);
				Debug.LogError((mod == null) ? "An error occurred trying to load parts." : ("An error occurred trying to load parts from mod '" + mod.ModInfo.Name + "'."));
			}
		}

		private static void LoadDesignerParts(IEnumerable<XDocument> designerPartXml, ILoadedMod mod)
		{
			foreach (XDocument item in designerPartXml)
			{
				List<XElement> list = item.Root.Elements("DesignerPart").ToList();
				if (item.Root.Name.LocalName == "DesignerPart")
				{
					list.Add(item.Root);
				}
				if (list.Count == 0)
				{
					Debug.LogError((mod == null) ? "Designer parts could not be found in designer part XML." : ("Designer parts could not be found in designer part XML from mod '" + mod.ModInfo.Name + "'."));
				}
				LoadDesignerParts(list, null, mod);
			}
		}

		private static void LoadDesignerParts(IEnumerable<XElement> designerParts, string partId, ILoadedMod mod)
		{
			DesignerPartList cachedDesignerParts = Game.Instance.CachedDesignerParts;
			foreach (XElement designerPart in designerParts)
			{
				try
				{
					if (!((((string)designerPart.Attribute("category")) ?? "Unknown") == "Sub Assemblies") || mod != null)
					{
						DesignerPart item = cachedDesignerParts.LoadDesignerPart(designerPart, mod);
						cachedDesignerParts.Parts.Add(item);
					}
				}
				catch (Exception exception)
				{
					string text = (string.IsNullOrWhiteSpace(partId) ? ("'" + (((string)designerPart?.Attribute("name")) ?? "Unknown") + "'") : ("for part '" + partId + "'"));
					Debug.LogException(exception);
					Debug.LogError((mod == null) ? ("An error occurred loading a designer part " + text + ".") : ("An error occurred loading a designer part " + text + " from mod '" + mod.ModInfo.Name + "'."));
				}
			}
		}
	}
}
