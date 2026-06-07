using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace Web.Client.Models.SimplePlanes
{
	public class PostsModel
	{
		public class Post
		{
			public string Author { get; set; }

			public int CommentCount { get; set; }

			public DateTime CreatedDateTime { get; set; }

			public long PostId { get; set; }

			public string ThumbnailUrl { get; set; }

			public string Title { get; set; }

			public string UrlId { get; set; }

			public int VoteCount { get; set; }

			public Post()
			{
			}

			public Post(XElement xml)
			{
				Author = xml.Attribute("Author").Value;
				CommentCount = (int)xml.Attribute("CommentCount");
				CreatedDateTime = (DateTime)xml.Attribute("CreatedDateTime");
				PostId = (long)xml.Attribute("PostId");
				ThumbnailUrl = xml.Attribute("ThumbnailUrl").Value;
				Title = xml.Attribute("Title").Value;
				UrlId = xml.Attribute("UrlId").Value;
				VoteCount = (int)xml.Attribute("VoteCount");
			}

			public XElement GenerateXml()
			{
				XElement xElement = new XElement("Post");
				xElement.SetAttributeValue("Author", Author);
				xElement.SetAttributeValue("CommentCount", CommentCount);
				xElement.SetAttributeValue("CreatedDateTime", CreatedDateTime);
				xElement.SetAttributeValue("PostId", PostId);
				xElement.SetAttributeValue("ThumbnailUrl", ThumbnailUrl);
				xElement.SetAttributeValue("Title", Title);
				xElement.SetAttributeValue("UrlId", UrlId);
				xElement.SetAttributeValue("VoteCount", VoteCount);
				return xElement;
			}
		}

		public DateTime GeneratedDateTime { get; set; }

		public List<Post> Posts { get; private set; } = new List<Post>();

		public PostsModel()
		{
		}

		public PostsModel(string xmlString)
			: this(XElement.Parse(xmlString))
		{
		}

		public PostsModel(ClientResponse clientResponse)
			: this(clientResponse.XmlResult.Element("Posts"))
		{
		}

		public PostsModel(XElement xml)
			: this()
		{
			IEnumerable<XElement> enumerable = xml.Elements();
			GeneratedDateTime = (DateTime)xml.Attribute("GeneratedDateTime");
			foreach (XElement item in enumerable)
			{
				Posts.Add(new Post(item));
			}
		}

		public XElement GenerateXml()
		{
			XElement xElement = new XElement("Posts");
			xElement.SetAttributeValue("GeneratedDateTime", GeneratedDateTime);
			foreach (Post post in Posts)
			{
				xElement.Add(post.GenerateXml());
			}
			return xElement;
		}
	}
}
