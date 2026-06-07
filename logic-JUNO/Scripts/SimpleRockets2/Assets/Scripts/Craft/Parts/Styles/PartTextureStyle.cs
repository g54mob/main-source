using ModApi.Craft.Parts.Styles;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Styles
{
	public class PartTextureStyle : IPartTextureStyle
	{
		public string DetailTextureId { get; private set; }

		public string DisplayName { get; private set; }

		public string Id { get; private set; }

		public string NormalMapTextureId { get; private set; }

		public PartTextureStyleOptions Options { get; private set; }

		public PartTextureStyle(string id, string displayName, PartTextureStyleOptions options, string detailTextureId, string normalMapTextureId)
		{
			Id = id;
			DisplayName = displayName;
			Options = options;
			DetailTextureId = detailTextureId;
			NormalMapTextureId = normalMapTextureId;
		}

		internal void Update(string displayName, PartTextureStyleOptions options, string detailTextureId, string normalMapTextureId)
		{
			if (DisplayName != displayName && !string.IsNullOrWhiteSpace(displayName))
			{
				Debug.Log("Overriding display name for texture style '" + Id + "'. '" + DisplayName + "' --> '" + displayName + "'");
				DisplayName = displayName;
			}
			if (Options != options)
			{
				Debug.Log($"Overriding options for texture style '{Id}'. '{Options}' --> '{options}'");
				Options = options;
			}
			if (DetailTextureId != detailTextureId)
			{
				Debug.Log("Overriding detail texture id for texture style '" + Id + "'. '" + DetailTextureId + "' --> '" + detailTextureId + "'");
				DetailTextureId = detailTextureId;
			}
			if (NormalMapTextureId != normalMapTextureId)
			{
				Debug.Log("Overriding normal map texture id for texture style '" + Id + "'. '" + NormalMapTextureId + "' --> '" + normalMapTextureId + "'");
				NormalMapTextureId = normalMapTextureId;
			}
		}
	}
}
