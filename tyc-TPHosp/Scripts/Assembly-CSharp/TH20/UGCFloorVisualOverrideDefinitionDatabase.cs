using System.Collections.Generic;
using UnityEngine;

namespace TH20
{
	[DontSave]
	public class UGCFloorVisualOverrideDefinitionDatabase
	{
		private Dictionary<string, Texture2D> _diffuseTextures = new Dictionary<string, Texture2D>();

		public void SetDiffuseTexture(string contentID, Texture2D texture)
		{
			_diffuseTextures[contentID] = texture;
		}

		public bool TryGetDiffuseTexture(string contentID, out Texture2D texture)
		{
			return _diffuseTextures.TryGetValue(contentID, out texture);
		}
	}
}
