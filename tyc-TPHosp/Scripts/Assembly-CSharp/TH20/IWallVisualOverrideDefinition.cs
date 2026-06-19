using UnityEngine;

namespace TH20
{
	public interface IWallVisualOverrideDefinition : ISilverUnlockable
	{
		Sprite Icon { get; }

		string Name { get; }

		string Description { get; }

		Texture2D GetDiffuseTexture();

		string GetContentID();
	}
}
