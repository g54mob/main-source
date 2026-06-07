using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace Web.Client.Models.SimplePlanes
{
	public class DetailsModel
	{
		public enum CuratedStatusType
		{
			None = 0,
			Approved = 1,
			Rejected = 2,
			Pending = 3
		}

		public class TagModel
		{
			public int Id { get; set; }

			public string Name { get; set; }

			public TagModel(int id, string name)
			{
				Id = id;
				Name = name;
			}
		}

		public List<string> ImageUrls = new List<string>();

		public bool CanFavorite { get; set; }

		public bool CanUpvote { get; set; }

		public bool Curated { get; set; }

		public CuratedStatusType CuratedStatus { get; set; }

		public string Description { get; set; }

		public FormatType DescriptionFormat { get; set; }

		public int DownloadCount { get; set; }

		public bool Favorite { get; set; }

		public DateTime GeneratedDateTime { get; set; }

		public bool IsCraft { get; set; }

		public int PartCount { get; set; }

		public float PerformanceCost { get; set; }

		public PostsModel.Post Post { get; set; }

		public List<TagModel> Tags { get; private set; } = new List<TagModel>();

		public bool Upvoted { get; set; }

		public string UserName { get; set; }

		public int UserPoints { get; set; }

		public int XmlRevision { get; set; }

		public DetailsModel()
		{
		}

		public DetailsModel(string xmlString)
			: this(XElement.Parse(xmlString))
		{
		}

		public DetailsModel(ClientResponse clientResponse)
			: this(clientResponse.XmlResult.Element("Details"))
		{
		}

		public DetailsModel(XElement xml)
			: this()
		{
			CanFavorite = (bool?)xml.Attribute("CanFavorite") == true;
			CanUpvote = (bool?)xml.Attribute("CanUpvote") == true;
			Curated = (bool?)xml.Attribute("Curated") == true;
			CuratedStatus = Utilities.ParseEnum(xml.Attribute("CuratedStatus")?.Value, CuratedStatusType.None);
			Description = xml.Attribute("Description")?.Value;
			DescriptionFormat = Utilities.ParseEnum(xml.Attribute("DescriptionFormat")?.Value, FormatType.Text);
			DownloadCount = ((int?)xml.Attribute("DownloadCount")).GetValueOrDefault();
			Favorite = (bool?)xml.Attribute("Favorite") == true;
			GeneratedDateTime = (DateTime)xml.Attribute("GeneratedDateTime");
			IsCraft = (bool?)xml.Attribute("IsCraft") == true;
			PartCount = ((int?)xml.Attribute("PartCount")).GetValueOrDefault();
			PerformanceCost = ((float?)xml.Attribute("PerformanceCost")).GetValueOrDefault();
			Upvoted = (bool?)xml.Attribute("Upvoted") == true;
			UserName = xml.Attribute("UserName")?.Value;
			UserPoints = ((int?)xml.Attribute("UserPoints")).GetValueOrDefault();
			XmlRevision = ((int?)xml.Attribute("XmlRevision")).GetValueOrDefault();
			Post = new PostsModel.Post(xml.Element("Post"));
			foreach (XElement item2 in xml.Element("Images")?.Elements())
			{
				ImageUrls.Add(item2.Attribute("url")?.Value);
			}
			IEnumerable<XElement> enumerable = xml.Element("Tags")?.Elements();
			if (enumerable == null)
			{
				return;
			}
			foreach (XElement item3 in enumerable)
			{
				TagModel item = new TagModel(((int?)item3.Attribute("Id")).GetValueOrDefault(), item3.Attribute("Name")?.Value ?? string.Empty);
				Tags.Add(item);
			}
		}

		public XElement GenerateXml()
		{
			XElement xElement = new XElement("Details");
			xElement.SetAttributeValue("CanFavorite", CanFavorite);
			xElement.SetAttributeValue("CanUpvote", CanUpvote);
			xElement.SetAttributeValue("Curated", Curated);
			xElement.SetAttributeValue("CuratedStatus", CuratedStatus);
			xElement.SetAttributeValue("Description", Description);
			xElement.SetAttributeValue("DescriptionFormat", DescriptionFormat);
			xElement.SetAttributeValue("DownloadCount", DownloadCount);
			xElement.SetAttributeValue("Favorite", Favorite);
			xElement.SetAttributeValue("GeneratedDateTime", GeneratedDateTime);
			xElement.SetAttributeValue("IsCraft", IsCraft);
			xElement.SetAttributeValue("PartCount", PartCount);
			xElement.SetAttributeValue("PerformanceCost", PerformanceCost);
			xElement.SetAttributeValue("Upvoted", Upvoted);
			xElement.SetAttributeValue("UserName", UserName);
			xElement.SetAttributeValue("UserPoints", UserPoints);
			xElement.SetAttributeValue("XmlRevision", XmlRevision);
			xElement.Add(Post.GenerateXml());
			XElement xElement2 = new XElement("Images");
			xElement.Add(xElement2);
			foreach (string imageUrl in ImageUrls)
			{
				xElement2.Add(new XElement("Image", new XAttribute("url", imageUrl)));
			}
			XElement xElement3 = new XElement("Tags");
			xElement.Add(xElement3);
			foreach (TagModel tag in Tags)
			{
				xElement3.Add(new XElement("Tag", new XAttribute("Id", tag.Id), new XAttribute("Name", tag.Name)));
			}
			return xElement;
		}
	}
}
