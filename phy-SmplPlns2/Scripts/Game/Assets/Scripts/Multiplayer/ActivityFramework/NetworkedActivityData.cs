using System;
using System.Xml.Linq;
using FishNet.Serializing;

namespace Assets.Scripts.Multiplayer.ActivityFramework
{
	public class NetworkedActivityData
	{
		public bool AllowPeacefulMode { get; private set; }

		public string Category { get; private set; }

		public string Description { get; private set; }

		public string DisplayName { get; private set; }

		public string Icon { get; private set; }

		public string Id { get; private set; }

		public bool IsSupportedInDemo { get; private set; }

		public string Prefab { get; private set; }

		public string RequiredLocation { get; private set; }

		public NetworkedActivityScoreTiers ScoreTiers { get; private set; }

		public NetworkedActivitySettings Settings { get; private set; }

		public XElement XmlData { get; private set; }

		public static NetworkedActivityData LoadFromNetwork(Reader reader)
		{
			NetworkedActivityData networkedActivityData = new NetworkedActivityData();
			networkedActivityData.SerializeRead(reader, includeDescription: false);
			return networkedActivityData;
		}

		public static NetworkedActivityData LoadFromXml(XElement xml)
		{
			NetworkedActivityData networkedActivityData = new NetworkedActivityData();
			networkedActivityData.SerializeRead(xml);
			return networkedActivityData;
		}

		public void SerializeRead(Reader reader, bool includeDescription)
		{
			Id = reader.ReadStringAllocated();
			DisplayName = reader.ReadStringAllocated();
			Category = reader.ReadStringAllocated();
			Icon = reader.ReadStringAllocated();
			Prefab = reader.ReadStringAllocated();
			IsSupportedInDemo = reader.ReadBoolean();
			AllowPeacefulMode = reader.ReadBoolean();
			RequiredLocation = reader.ReadStringAllocated();
			if (includeDescription)
			{
				Description = reader.ReadStringAllocated();
			}
			ScoreTiers = NetworkedActivityScoreTiers.LoadFromNetwork(reader);
			Settings = new NetworkedActivitySettings();
			Settings.SerializeRead(reader, valuesOnly: false);
			XmlData = XElement.Parse(reader.ReadStringAllocated());
		}

		public void SerializeRead(XElement xml)
		{
			Id = xml.GetStringAttributeOrNullIfEmpty("id") ?? throw new InvalidOperationException($"Activity data requires an 'id' attribute: {xml}");
			DisplayName = xml.GetStringAttributeOrNullIfEmpty("displayName") ?? throw new InvalidOperationException($"Activity data requires a 'displayName' attribute: {xml}");
			Category = xml.GetStringAttributeOrNullIfEmpty("category") ?? throw new InvalidOperationException($"Activity data requires a 'category' attribute: {xml}");
			Icon = xml.GetStringAttributeOrNullIfEmpty("icon") ?? throw new InvalidOperationException($"Activity data requires a 'icon' attribute: {xml}");
			Description = xml.GetStringAttributeOrNullIfEmpty("description") ?? throw new InvalidOperationException($"Activity data requires a 'description' attribute: {xml}");
			Prefab = xml.GetStringAttributeOrNullIfEmpty("prefab") ?? throw new InvalidOperationException($"Activity data requires a 'prefab' attribute: {xml}");
			IsSupportedInDemo = xml.GetBoolAttribute("isSupportedInDemo", defaultValue: true);
			AllowPeacefulMode = xml.GetBoolAttribute("allowPeacefulMode", defaultValue: true);
			RequiredLocation = xml.GetStringAttributeOrNullIfEmpty("requiredLocation");
			ScoreTiers = NetworkedActivityScoreTiers.LoadFromXml(xml.Element("ScoreTiers"));
			Settings = NetworkedActivitySettings.LoadFromXml(xml.Element("Settings"));
			XElement xElement = xml.Element("Data") ?? new XElement("Data");
			string stringAttribute = xElement.GetStringAttribute("resourceId");
			if (string.IsNullOrEmpty(stringAttribute))
			{
				XmlData = xElement;
			}
			else
			{
				XmlData = Game.Instance.ResourceLoader.LoadXml("Data/Activities/" + stringAttribute)?.Root ?? new XElement("Data");
			}
		}

		public void SerializeWrite(Writer writer, bool includeDescription)
		{
			writer.Write(Id);
			writer.Write(DisplayName);
			writer.Write(Category);
			writer.Write(Icon);
			writer.Write(Prefab);
			writer.Write(IsSupportedInDemo);
			writer.Write(AllowPeacefulMode);
			writer.Write(RequiredLocation);
			if (includeDescription)
			{
				writer.Write(Description);
			}
			ScoreTiers.SerializeWrite(writer);
			Settings.SerializeWrite(writer, valuesOnly: false);
			writer.Write(XmlData.ToString(SaveOptions.DisableFormatting));
		}
	}
}
