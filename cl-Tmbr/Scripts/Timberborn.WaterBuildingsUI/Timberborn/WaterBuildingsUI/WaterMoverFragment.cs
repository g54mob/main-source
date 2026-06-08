using Timberborn.BaseComponentSystem;
using Timberborn.CoreUI;
using Timberborn.EntityPanelSystem;
using Timberborn.WaterBuildings;
using UnityEngine.UIElements;

namespace Timberborn.WaterBuildingsUI
{
	internal class WaterMoverFragment : IEntityPanelFragment
	{
		private readonly VisualElementLoader _visualElementLoader;

		private readonly WaterMoverToggleFactory _waterMoverToggleFactory;

		private VisualElement _root;

		private WaterMoverToggle _waterMoverToggle;

		public WaterMoverFragment(VisualElementLoader visualElementLoader, WaterMoverToggleFactory waterMoverToggleFactory)
		{
			_visualElementLoader = visualElementLoader;
			_waterMoverToggleFactory = waterMoverToggleFactory;
		}

		public VisualElement InitializeFragment()
		{
			string elementName = "Game/EntityPanel/WaterMoverFragment";
			_root = _visualElementLoader.LoadVisualElement(elementName);
			_waterMoverToggle = _waterMoverToggleFactory.Create(_root);
			_root.ToggleDisplayStyle(visible: false);
			return _root;
		}

		public void ShowFragment(BaseComponent entity)
		{
			WaterMover component = entity.GetComponent<WaterMover>();
			if (component != null)
			{
				_waterMoverToggle.Show(component);
				_root.ToggleDisplayStyle(visible: true);
			}
		}

		public void ClearFragment()
		{
			_waterMoverToggle.Clear();
			_root.ToggleDisplayStyle(visible: false);
		}

		public void UpdateFragment()
		{
			_waterMoverToggle.Update();
		}
	}
}
