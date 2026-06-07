using System;
using System.Xml.Linq;
using ModApi;
using UnityEngine;

namespace Assets.Scripts.Menu
{
	public class JundrooNotification
	{
		public const int ClientNotificationsVersion = 1;

		public string ButtonText { get; set; }

		public string ClickId { get; set; }

		public string Id { get; set; }

		public Texture2D Image { get; set; }

		public string ImageUrl { get; set; }

		public string Link { get; set; }

		public int NumApplicationRuns { get; set; }

		public string Text { get; set; }

		public string Title { get; set; }

		internal static JundrooNotification Create(string xml)
		{
			try
			{
				JundrooNotification jundrooNotification = new JundrooNotification();
				XElement xElement = XElement.Parse(xml);
				if (Utilities.GetBoolAttribute(xElement, "Enabled", defaultValue: false))
				{
					jundrooNotification.Id = xElement.Attribute("Id").Value;
					jundrooNotification.ClickId = xElement.Attribute("ClickId").Value;
					jundrooNotification.Title = xElement.Attribute("Title").Value;
					jundrooNotification.Text = xElement.Value;
					jundrooNotification.Link = xElement.Attribute("Link").Value;
					jundrooNotification.ButtonText = xElement.Attribute("ButtonText").Value;
					jundrooNotification.ImageUrl = xElement.Attribute("ImageUrl").Value;
					jundrooNotification.NumApplicationRuns = Utilities.GetIntAttribute(xElement, "NumApplicationRuns", 0);
					return jundrooNotification;
				}
			}
			catch (Exception)
			{
			}
			return null;
		}
	}
}
