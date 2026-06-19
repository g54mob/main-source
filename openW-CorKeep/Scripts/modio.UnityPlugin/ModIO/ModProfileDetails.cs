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

		public CommunityOptions? communityOptions = CommunityOptions.AllowCommenting;

		internal byte[] GetLogo()
		{
			return logo.EncodeToPNG();
		}

		internal List<byte[]> GetGalleryImages()
		{
			List<byte[]> list = new List<byte[]>();
			Texture2D[] array = images;
			foreach (Texture2D tex in array)
			{
				list.Add(tex.EncodeToPNG());
			}
			return list;
		}
	}
}
