using System;
using System.Xml.Linq;
using Assets.Scripts.State;
using ModApi.Common.Extensions;

namespace Assets.Scripts.Menu.ListView.Career
{
	public class CareerSelectorDetails
	{
		private DetailsPropertyScript _author;

		private DetailsTextScript _description;

		public bool IsValidCareer { get; private set; }

		public CareerSelectorDetails(ListViewDetailsScript listViewDetails)
		{
			_author = listViewDetails.Widgets.AddProperty("Author");
			listViewDetails.Widgets.AddHeader("Description");
			_description = listViewDetails.Widgets.AddText(string.Empty);
			listViewDetails.Widgets.AddSpacer();
		}

		public void UpdateDetails(string folderName)
		{
			try
			{
				XElement careerInfoXml = CareerState.GetCareerInfoXml(folderName);
				_description.Text = careerInfoXml.GetStringAttribute("description");
				_author.ValueText = careerInfoXml.GetStringAttribute("author");
				IsValidCareer = true;
			}
			catch (Exception)
			{
				IsValidCareer = false;
				_author.ValueText = string.Empty;
				_description.Text = "Error reading career information";
			}
		}
	}
}
