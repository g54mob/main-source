using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using Assets.Scripts.Craft.CraftFiles;
using UnityEngine;
using Web.Client.Models.SimplePlanes;

namespace Assets.Scripts.Menu.LevelMenuVR.ListView
{
	public class TrackedCraftList
	{
		public class StockCraftInfo
		{
			public bool IsDefault { get; private set; }

			public bool IsDefaultOpponent { get; private set; }

			public string Name { get; private set; }

			public string UrlID { get; private set; }

			public StockCraftInfo(string name, string urlID, bool isDefault = false, bool isDefaultOpponent = false)
			{
				Name = name;
				UrlID = urlID;
				IsDefault = isDefault;
				IsDefaultOpponent = isDefaultOpponent;
			}
		}

		public class TrackedCraft
		{
			public string Author { get; set; }

			public bool IsSelected { get; set; }

			public bool IsStarred => StarredDateTime.HasValue;

			public bool IsStock { get; set; }

			public DateTime LastAccess { get; set; }

			public DateTime LastUpdated { get; set; }

			public DateTime? StarredDateTime { get; set; }

			public ResourceLocation ThumbnailLocation { get; set; }

			public string ThumbnailPath { get; set; }

			public string Title { get; set; }

			public bool TrackingEnabled { get; set; } = true;

			public string UrlId { get; set; }

			public ResourceLocation XmlLocation { get; set; }

			public string XmlPath { get; set; }

			public int XmlRevision { get; set; }

			public string XmlUrl => Game.GetDownloadAircraftUrl(UrlId, XmlRevision);

			public TrackedCraft(XElement e)
			{
				Author = e.Attribute("Author")?.Value;
				StarredDateTime = ((DateTime?)e.Attribute("starred")) ?? ((DateTime?)e.Attribute("favorited"));
				IsStock = (bool)e.Attribute("IsStock");
				IsSelected = (bool?)e.Attribute("selected") == true;
				LastAccess = ((DateTime?)e.Attribute("lastAccess")) ?? DateTime.UtcNow;
				ThumbnailLocation = e.GetEnumAttribute("ThumbnailLocation", ResourceLocation.Web);
				ThumbnailPath = e.Attribute("ThumbnailPath")?.Value;
				Title = e.Attribute("Title").Value;
				UrlId = e.Attribute("UrlId")?.Value;
				XmlLocation = e.GetEnumAttribute("XmlLocation", ResourceLocation.Web);
				XmlPath = e.Attribute("XmlPath")?.Value;
				XmlRevision = ((int?)e.Attribute("XmlRevision")).GetValueOrDefault();
				LastUpdated = ((DateTime?)e.Attribute("LastUpdated")) ?? DateTime.UtcNow;
			}

			public TrackedCraft()
			{
			}

			public TrackedCraft(PostsModel.Post post, DateTime lastUpdatedDateTime)
			{
				LastUpdated = lastUpdatedDateTime;
				Author = post.Author;
				ThumbnailLocation = ResourceLocation.Web;
				ThumbnailPath = post.ThumbnailUrl;
				Title = post.Title;
				UrlId = post.UrlId;
				XmlLocation = ResourceLocation.Web;
				XmlPath = null;
			}

			public XElement SaveXml()
			{
				XElement xElement = new XElement("Craft");
				xElement.SetAttributeValue("Author", Author);
				xElement.SetAttributeValue("IsStock", IsStock);
				xElement.SetAttributeValue("ThumbnailLocation", ThumbnailLocation);
				xElement.SetAttributeValue("ThumbnailPath", ThumbnailPath);
				xElement.SetAttributeValue("Title", Title);
				xElement.SetAttributeValue("UrlId", UrlId);
				xElement.SetAttributeValue("XmlLocation", XmlLocation);
				xElement.SetAttributeValue("XmlPath", XmlPath);
				xElement.SetAttributeValue("XmlRevision", XmlRevision);
				xElement.SetAttributeValue("LastUpdated", LastUpdated);
				xElement.SetAttributeValue("lastAccess", LastAccess);
				if (IsSelected)
				{
					xElement.SetAttributeValue("selected", true);
				}
				if (StarredDateTime.HasValue)
				{
					xElement.SetAttributeValue("starred", StarredDateTime.Value);
				}
				return xElement;
			}

			public void SetStarred(bool starred)
			{
				if (starred)
				{
					StarredDateTime = DateTime.UtcNow;
				}
				else
				{
					StarredDateTime = null;
				}
			}
		}

		public static StockCraftInfo[] StockCraftInfos = new StockCraftInfo[12]
		{
			new StockCraftInfo("Bush Plane", "K2zN7X", isDefault: true),
			new StockCraftInfo("Gator 2", "1m1682"),
			new StockCraftInfo("Hellkeska", "NC39L7"),
			new StockCraftInfo("Kicking Fish", "CYJU2n"),
			new StockCraftInfo("Little Bugger", "rlkpAd"),
			new StockCraftInfo("P-51-B", "G8BduR"),
			new StockCraftInfo("P-51-D", "nQA34M", isDefault: false, isDefaultOpponent: true),
			new StockCraftInfo("Pigpen", "SvcLDC"),
			new StockCraftInfo("Sea Plane", "DN88S1"),
			new StockCraftInfo("Twin Prop", "a25YuV"),
			new StockCraftInfo("Vertigo", "B9KM23"),
			new StockCraftInfo("Wasp", "9P965i")
		};

		private List<TrackedCraft> _crafts = new List<TrackedCraft>();

		private string _path;

		private TrackedCraft _selected;

		public IReadOnlyList<TrackedCraft> Crafts => _crafts;

		public TrackedCraft Default { get; private set; }

		public TrackedCraft DefaultOpponent { get; private set; }

		public TrackedCraft Selected
		{
			get
			{
				return _selected;
			}
			set
			{
				if (_selected != null)
				{
					_selected.IsSelected = false;
				}
				_selected = value;
				if (_selected != null)
				{
					_selected.IsSelected = true;
				}
			}
		}

		public TrackedCraftList(string path)
		{
			_path = path;
			Load();
		}

		public void AddOrUpdateCraft(TrackedCraft craft)
		{
			if (craft.TrackingEnabled && !UpdateCraft(craft))
			{
				_crafts.Add(craft);
			}
		}

		public void Prune(int maxRecentCrafts)
		{
			List<TrackedCraft> list = (from x in _crafts
				where !x.IsStock && !x.IsStarred
				orderby x.LastAccess
				select x).ToList();
			int num = list.Count - maxRecentCrafts;
			if (num > 0)
			{
				for (int num2 = 0; num2 < num; num2++)
				{
					TrackedCraft trackedCraft = list[num2];
					_crafts.Remove(trackedCraft);
					Debug.Log("Pruning " + trackedCraft.Title);
				}
			}
		}

		public void Save()
		{
			try
			{
				XElement xElement = new XElement("Crafts");
				foreach (TrackedCraft craft in _crafts)
				{
					xElement.Add(craft.SaveXml());
				}
				XDocument xDocument = new XDocument();
				xDocument.Add(xElement);
				xDocument.Save(_path);
			}
			catch (Exception innerException)
			{
				Debug.LogException(new Exception("Unable to save craft list from " + _path, innerException));
			}
		}

		public bool UpdateCraft(TrackedCraft craft)
		{
			TrackedCraft trackedCraft = null;
			trackedCraft = ((!craft.IsStock) ? _crafts.Where((TrackedCraft x) => x.UrlId == craft.UrlId).FirstOrDefault() : _crafts.Where((TrackedCraft x) => x.IsStock && x.Title == craft.Title).FirstOrDefault());
			if (trackedCraft != null)
			{
				int index = _crafts.IndexOf(trackedCraft);
				craft.StarredDateTime = trackedCraft.StarredDateTime;
				_crafts[index] = craft;
				return true;
			}
			return false;
		}

		private void AddStockCrafts()
		{
			StockCraftInfo[] stockCraftInfos = StockCraftInfos;
			foreach (StockCraftInfo stockCraftInfo in stockCraftInfos)
			{
				TrackedCraft trackedCraft = AddUpdateStock(stockCraftInfo.Name, stockCraftInfo.UrlID);
				if (stockCraftInfo.IsDefault)
				{
					Default = trackedCraft;
				}
				else if (stockCraftInfo.IsDefaultOpponent)
				{
					DefaultOpponent = trackedCraft;
				}
			}
		}

		private TrackedCraft AddUpdateStock(string title, string urlId)
		{
			TrackedCraft trackedCraft = _crafts.Where((TrackedCraft x) => x.IsStock && x.Title == title).FirstOrDefault();
			if (trackedCraft == null)
			{
				trackedCraft = new TrackedCraft();
				_crafts.Add(trackedCraft);
			}
			trackedCraft.Title = title;
			trackedCraft.IsStock = true;
			trackedCraft.UrlId = urlId;
			trackedCraft.Author = "Jundroo";
			trackedCraft.ThumbnailLocation = ResourceLocation.Resource;
			trackedCraft.ThumbnailPath = "Menu/Thumbnails/Craft/" + title;
			trackedCraft.XmlLocation = ResourceLocation.File;
			CraftFileInfo craftFileInfo = new CraftFileInfo(title);
			trackedCraft.XmlPath = craftFileInfo.FullFilePath;
			trackedCraft.XmlRevision = 0;
			trackedCraft.LastUpdated = DateTime.UtcNow;
			return trackedCraft;
		}

		private void Load()
		{
			try
			{
				if (File.Exists(_path))
				{
					foreach (XElement item in XDocument.Load(_path).Root.Elements())
					{
						_crafts.Add(new TrackedCraft(item));
					}
					Selected = _crafts.FirstOrDefault((TrackedCraft x) => x.IsSelected);
				}
			}
			catch (Exception innerException)
			{
				Debug.LogException(new Exception("Unable to load craft list from " + _path, innerException));
				_crafts.Clear();
			}
			AddStockCrafts();
		}
	}
}
