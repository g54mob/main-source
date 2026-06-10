using System.Collections.Generic;
using NSMedieval.UI.Utils;

namespace NSMedieval.UI
{
	public class EnemyAttributesExtraPanel : AttributesExtraPanelBase
	{
		protected override IEnumerable<AttributeLocalized> GetAttributes()
		{
			return AttributeUtils.GetAllLocalized(base.Humanoid);
		}
	}
}
