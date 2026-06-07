using System.IO;
using System.Xml.Linq;
using ModApi.Common.Extensions;

namespace Assets.Scripts.Career.Contracts
{
	public class Customer
	{
		public string HelloText { get; }

		public string Id { get; }

		public string LargeProfileImage { get; set; }

		public string LongBio { get; set; }

		public string Name { get; set; }

		public string SmallProfileImage { get; set; }

		public Customer(XElement xml, string imagePath)
		{
			Id = xml.GetStringAttribute("id");
			Name = xml.GetStringAttribute("name");
			LongBio = xml.GetStringAttribute("longBio");
			SmallProfileImage = Path.Combine(imagePath, xml.GetStringAttribute("smallImage"));
			LargeProfileImage = Path.Combine(imagePath, xml.GetStringAttribute("largeImage"));
			HelloText = xml.GetStringAttribute("hello");
		}
	}
}
