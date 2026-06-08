using System.Collections.Generic;
using Timberborn.BaseComponentSystem;
using Timberborn.CoreUI;
using Timberborn.EntityPanelSystem;
using Timberborn.Localization;
using Timberborn.UIFormatters;
using Timberborn.WaterBuildings;

namespace Timberborn.WaterBuildingsUI
{
	internal class WaterInputSpecDescriber : BaseComponent, IAwakableComponent, IEntityDescriber
	{
		private readonly ILoc _loc;

		private WaterInputSpec _waterInputSpec;

		private readonly Phrase _maxDepthPhrase = Phrase.New("Work.MaxDepth").FormatDistance<int>();

		public WaterInputSpecDescriber(ILoc loc)
		{
			_loc = loc;
		}

		public void Awake()
		{
			_waterInputSpec = GetComponent<WaterInputSpec>();
		}

		public IEnumerable<EntityDescription> DescribeEntity()
		{
			string content = SpecialStrings.RowStarter + _loc.T(_maxDepthPhrase, _waterInputSpec.MaxDepth);
			yield return EntityDescription.CreateTextSection(content, 80);
		}
	}
}
