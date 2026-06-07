using System.Collections.Generic;

namespace ModApi.Craft.Parts.Styles
{
	public interface IPartStyle
	{
		IReadOnlyDictionary<string, string> Data { get; }

		string DisplayName { get; }

		bool Hidden { get; }

		string Id { get; }

		bool Invalid { get; }

		string PartId { get; }

		int SubpartIndex { get; }

		IReadOnlyList<IPartTextureStyle> Textures { get; }

		T GetData<T>(string key, T defaultValue, bool logErrors = true);
	}
}
