using System.Collections.Generic;
using UnityEngine;

namespace VRM
{
	public class VRMMetaObject : ScriptableObject
	{
		[SerializeField]
		public string ExporterVersion;

		[SerializeField]
		public string Title;

		[SerializeField]
		public string Version;

		[SerializeField]
		public string Author;

		[SerializeField]
		public string ContactInformation;

		[SerializeField]
		public string Reference;

		[SerializeField]
		public Texture2D Thumbnail;

		[SerializeField]
		[Tooltip("A person who can perform with this avatar")]
		public AllowedUser AllowedUser;

		[SerializeField]
		[Tooltip("Violent acts using this avatar")]
		public UssageLicense ViolentUssage;

		[SerializeField]
		[Tooltip("Sexuality acts using this avatar")]
		public UssageLicense SexualUssage;

		[SerializeField]
		[Tooltip("For commercial use")]
		public UssageLicense CommercialUssage;

		[SerializeField]
		[Tooltip("Other License Url")]
		public string OtherPermissionUrl;

		[SerializeField]
		public LicenseType LicenseType;

		[SerializeField]
		public string OtherLicenseUrl;

		public IEnumerable<Validation> Validate()
		{
			if (string.IsNullOrEmpty(Title))
			{
				yield return Validation.Error("Require Title. ");
			}
			if (string.IsNullOrEmpty(Version))
			{
				yield return Validation.Error("Require Version. ");
			}
			if (string.IsNullOrEmpty(Author))
			{
				yield return Validation.Error("Require Author. ");
			}
		}
	}
}
