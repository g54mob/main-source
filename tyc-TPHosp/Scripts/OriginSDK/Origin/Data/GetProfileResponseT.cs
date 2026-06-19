using System.Xml.Serialization;

namespace Origin.Data
{
	public class GetProfileResponseT
	{
		[XmlAttribute]
		public int UserIndex;

		[XmlAttribute]
		public ulong UserId;

		[XmlAttribute]
		public ulong PersonaId;

		[XmlAttribute]
		public string Persona;

		[XmlAttribute]
		public string AvatarId;

		[XmlAttribute]
		public string Country;

		[XmlAttribute]
		public bool IsUnderAge;

		[XmlAttribute]
		public bool IsSubscriber;

		[XmlAttribute]
		public bool IsTrialSubscriber;

		[XmlAttribute]
		public int SubscriberLevel;

		[XmlAttribute]
		public string GeoCountry;

		[XmlAttribute]
		public string CommerceCountry;

		[XmlAttribute]
		public string CommerceCurrency;
	}
}
