using System;
using System.Collections.Generic;
using Jundroo.ModTools;
using UnityEngine;

namespace ModApi.Craft.Parts.Styles
{
	public interface IPartStyleManager
	{
		IPartStyle DefaultStyle { get; }

		IPartTextureStyle DefaultTextureStyle { get; }

		Texture2DArray DetailTextures { get; }

		bool DetailTexturesEnabled { get; }

		bool ModTexturesLoaded { get; }

		bool NormalMapsEnabled { get; }

		Texture2DArray NormalMapTextures { get; }

		bool SupportsModTextures { get; }

		event EventHandler TextureArraysChanged;

		int GetDetailTextureIndex(string textureId);

		int GetNormalMapTextureIndex(string textureId);

		IPartStyle GetStyle(string partId, int subpartIndex, string styleId);

		IReadOnlyList<IPartStyle> GetStyles(string partId, int subpartIndex);

		IPartTextureStyle GetTextureStyle(string id);

		IReadOnlyList<IPartTextureStyle> GetTextureStyles(string partId, int subpartIndex, string styleId);

		void LoadPartStyleExtensions(string xml);

		void LoadTextureStyles(string xml, ILoadedMod mod);

		void RebuildTextureArrays();

		void RebuildTextureArraysIfNecessary();
	}
}
