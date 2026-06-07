using System.Collections.Generic;

namespace ModApi.Craft.Parts.Styles
{
	public interface IPartTextureStyleProvider
	{
		IReadOnlyList<IPartTextureStyle> GetAvailablePartTextureStyles(string partTypeId, int subpartIndex, string partStyleId);
	}
}
