using System.Collections.Generic;

namespace Brewery.Map
{
	public interface IMapIconHoverProvider
	{
		string GetHoverTitle();

		string GetHoverSubtitle();

		List<HoverInfoSection> GetHoverSections();

		bool ShouldShowHover();
	}
}
