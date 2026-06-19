using System;
using System.Collections.Generic;
using AssembleSystem.Utils;

namespace AssembleSystem
{
	public interface IAssembleSystemService
	{
		Action<AssembleObjectParent, bool, int> CheckBasePartsInInventory { get; set; }

		Dictionary<AssembleObjectParent, List<PartConfig>> ItemsToBasePartsDictionary { get; }

		bool AnyPartsInInventoryOf(AssembleObjectParent config);
	}
}
