using System;
using UniGLTF;
using UniJSON;

namespace VRM
{
	[Serializable]
	[JsonSchema(Title = "vrm.meta")]
	public class glTF_VRM_Meta : JsonSerializableBase
	{
		[JsonSchema(Description = "Title of VRM model")]
		public string title;

		[JsonSchema(Description = "Version of VRM model")]
		public string version;

		[JsonSchema(Description = "Author of VRM model")]
		public string author;

		[JsonSchema(Description = "Contact Information of VRM model author")]
		public string contactInformation;

		[JsonSchema(Description = "Reference of VRM model")]
		public string reference;

		[JsonSchema(Description = "Thumbnail of VRM model", Minimum = 0.0, ExplicitIgnorableValue = -1)]
		public int texture = -1;

		[JsonSchema(Required = true, Description = "A person who can perform with this avatar ", EnumValues = new object[] { "OnlyAuthor", "ExplicitlyLicensedPerson", "Everyone" }, EnumSerializationType = EnumSerializationType.AsString)]
		public string allowedUserName = "OnlyAuthor";

		[JsonSchema(Required = true, Description = "Permission to perform violent acts with this avatar", EnumValues = new object[] { "Disallow", "Allow" }, EnumSerializationType = EnumSerializationType.AsString)]
		public string violentUssageName = "Disallow";

		[JsonSchema(Required = true, Description = "Permission to perform sexual acts with this avatar", EnumValues = new object[] { "Disallow", "Allow" }, EnumSerializationType = EnumSerializationType.AsString)]
		public string sexualUssageName = "Disallow";

		[JsonSchema(Required = true, Description = "For commercial use", EnumValues = new object[] { "Disallow", "Allow" }, EnumSerializationType = EnumSerializationType.AsString)]
		public string commercialUssageName = "Disallow";

		[JsonSchema(Description = "If there are any conditions not mentioned above, put the URL link of the license document here.")]
		public string otherPermissionUrl;

		[JsonSchema(Required = true, Description = "License type", EnumValues = new object[] { "Redistribution_Prohibited", "CC0", "CC_BY", "CC_BY_NC", "CC_BY_SA", "CC_BY_NC_SA", "CC_BY_ND", "CC_BY_NC_ND", "Other" }, EnumSerializationType = EnumSerializationType.AsString)]
		public string licenseName = "Redistribution_Prohibited";

		[JsonSchema(Description = "If “Other” is selected, put the URL link of the license document here.")]
		public string otherLicenseUrl;

		public AllowedUser allowedUser
		{
			get
			{
				return CacheEnum.TryParseOrDefault(allowedUserName, ignoreCase: true, AllowedUser.OnlyAuthor);
			}
			set
			{
				allowedUserName = value.ToString();
			}
		}

		public UssageLicense violentUssage
		{
			get
			{
				return FromString(violentUssageName);
			}
			set
			{
				violentUssageName = value.ToString();
			}
		}

		public UssageLicense sexualUssage
		{
			get
			{
				return FromString(sexualUssageName);
			}
			set
			{
				sexualUssageName = value.ToString();
			}
		}

		public UssageLicense commercialUssage
		{
			get
			{
				return FromString(commercialUssageName);
			}
			set
			{
				commercialUssageName = value.ToString();
			}
		}

		public LicenseType licenseType
		{
			get
			{
				return CacheEnum.TryParseOrDefault(licenseName, ignoreCase: true, LicenseType.Redistribution_Prohibited);
			}
			set
			{
				licenseName = value.ToString();
			}
		}

		private static UssageLicense FromString(string src)
		{
			return CacheEnum.TryParseOrDefault(src, ignoreCase: true, UssageLicense.Disallow);
		}

		protected override void SerializeMembers(GLTFJsonFormatter f)
		{
			f.KeyValue(() => version);
			f.KeyValue(() => author);
			f.KeyValue(() => contactInformation);
			f.KeyValue(() => reference);
			f.KeyValue(() => title);
			f.KeyValue(() => texture);
			f.KeyValue(() => allowedUserName);
			f.KeyValue(() => violentUssageName);
			f.KeyValue(() => sexualUssageName);
			f.KeyValue(() => commercialUssageName);
			f.KeyValue(() => otherPermissionUrl);
			f.KeyValue(() => licenseName);
			f.KeyValue(() => otherLicenseUrl);
		}
	}
}
