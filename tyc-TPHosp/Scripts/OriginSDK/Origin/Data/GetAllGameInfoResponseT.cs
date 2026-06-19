using System.Xml.Serialization;

namespace Origin.Data
{
	public class GetAllGameInfoResponseT
	{
		[XmlAttribute]
		public bool UpToDate;

		[XmlAttribute]
		public string Languages;

		[XmlAttribute]
		public bool FreeTrial;

		[XmlAttribute]
		public bool FullGamePurchased;

		[XmlAttribute]
		public bool FullGameReleased;

		[XmlAttribute]
		public string FullGameReleaseDate;

		[XmlAttribute]
		public string Expiration;

		[XmlAttribute]
		public string SystemTime;

		[XmlAttribute]
		public bool HasExpiration;

		[XmlAttribute]
		public string InstalledVersion;

		[XmlAttribute]
		public string InstalledLanguage;

		[XmlAttribute]
		public string AvailableVersion;

		[XmlAttribute]
		public string DisplayName;

		[XmlAttribute]
		public int MaxGroupSize;
	}
}
