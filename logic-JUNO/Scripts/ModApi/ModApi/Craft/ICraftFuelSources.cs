using System.Collections.Generic;
using ModApi.Craft.Parts;

namespace ModApi.Craft
{
	public interface ICraftFuelSources
	{
		IReadOnlyList<IFuelSource> FuelSources { get; }

		event FuelDelegate FuelUsed;
	}
}
