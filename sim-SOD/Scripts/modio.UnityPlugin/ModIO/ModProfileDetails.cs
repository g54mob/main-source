using System.Collections.Generic;
using UnityEngine;

namespace ModIO
{
	public class ModProfileDetails
	{
		public ModId? modId;

		public bool? visible;

		public Texture2D logo;

		public Texture2D[] images;

		public string name;

		public string name_id;

		public string summary;

		public string description;

		public string homepage_url;

		public int? maxSubscribers;

		public ContentWarnings? contentWarning;

		public string metadata;

		public string[] tags;

		public CommunityOptions? communityOptions;

		internal byte[] GetLogo()
		{
			return null;
		}

		internal List<byte[]> GetGalleryImages()
		{
			return null;
		}
	}
}
