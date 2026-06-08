using System.Collections.Generic;
using Timberborn.BaseComponentSystem;
using Timberborn.CoreUI;
using Timberborn.EntityPanelSystem;
using Timberborn.Localization;

namespace Timberborn.WondersUI
{
	internal class WonderDescriber : BaseComponent, IEntityDescriber
	{
		private static readonly string WonderLocKey = "Buildings.Wonder";

		private readonly ILoc _loc;

		public WonderDescriber(ILoc loc)
		{
			_loc = loc;
		}

		public IEnumerable<EntityDescription> DescribeEntity()
		{
			string content = SpecialStrings.RowStarter + _loc.T(WonderLocKey);
			yield return EntityDescription.CreateTextSection(content, 2040);
		}
	}
}
