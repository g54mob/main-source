using System.Linq;
using Data.Shapes;
using Presentation.FactoryFloor.Toolbar;

namespace Presentation.FactoryFloor.PinnedBar
{
	public class PinnedModuleButton : ModuleButton
	{
		public void Show(ShapeData data, ModuleViewerData moduleViewerData, int shapeIndex)
		{
			SetModuleIcon(data.GridIcon, moduleViewerData, shapeIndex);
			SetAmount(moduleViewerData.Modules.ElementAt(shapeIndex).Amount);
		}
	}
}
