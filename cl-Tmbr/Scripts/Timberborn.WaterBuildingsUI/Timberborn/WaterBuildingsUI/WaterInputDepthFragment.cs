using System;
using Timberborn.BaseComponentSystem;
using Timberborn.CoreUI;
using Timberborn.EntityPanelSystem;
using Timberborn.Localization;
using Timberborn.UIFormatters;
using Timberborn.WaterBuildings;
using UnityEngine.UIElements;

namespace Timberborn.WaterBuildingsUI
{
	internal class WaterInputDepthFragment : IEntityPanelFragment
	{
		private readonly VisualElementLoader _visualElementLoader;

		private readonly ILoc _loc;

		private WaterInputCoordinates _waterInputCoordinates;

		private WaterInputSpec _waterInputSpec;

		private VisualElement _root;

		private Label _depth;

		private Label _limit;

		private Button _increaseDepth;

		private Button _decreaseDepth;

		private Toggle _useDepthLimit;

		private readonly Phrase _limitPhrase = Phrase.New("WaterInputCoordinates.Depth").FormatDistance<int>();

		private readonly Phrase _depthPhrase = Phrase.New("WaterInputCoordinates.Limit").FormatDistance<int>();

		public WaterInputDepthFragment(VisualElementLoader visualElementLoader, ILoc loc)
		{
			_visualElementLoader = visualElementLoader;
			_loc = loc;
		}

		public VisualElement InitializeFragment()
		{
			string elementName = "Game/EntityPanel/WaterInputDepthFragment";
			_root = _visualElementLoader.LoadVisualElement(elementName);
			_root.ToggleDisplayStyle(visible: false);
			_depth = _root.Q<Label>("Depth");
			_limit = _root.Q<Label>("Limit");
			_increaseDepth = _root.Q<Button>("IncreaseDepth");
			_increaseDepth.RegisterCallback<ClickEvent>(IncreaseDepth);
			_decreaseDepth = _root.Q<Button>("DecreaseDepth");
			_decreaseDepth.RegisterCallback<ClickEvent>(DecreaseDepth);
			_useDepthLimit = _root.Q<Toggle>("UseDepthLimit");
			_useDepthLimit.RegisterCallback<ClickEvent>(ToggleDepthLimit);
			return _root;
		}

		public void ShowFragment(BaseComponent entity)
		{
			_waterInputSpec = entity.GetComponent<WaterInputSpec>();
			if (_waterInputSpec != null)
			{
				_waterInputCoordinates = entity.GetComponent<WaterInputCoordinates>();
				_root.ToggleDisplayStyle(visible: true);
			}
		}

		public void ClearFragment()
		{
			_waterInputCoordinates = null;
			_waterInputSpec = null;
			_root.ToggleDisplayStyle(visible: false);
		}

		public void UpdateFragment()
		{
			if (_waterInputSpec != null)
			{
				bool useDepthLimit = _waterInputCoordinates.UseDepthLimit;
				int depthLimit = _waterInputCoordinates.DepthLimit;
				_increaseDepth.SetEnabled(useDepthLimit && depthLimit < _waterInputSpec.MaxDepth);
				_decreaseDepth.SetEnabled(useDepthLimit && depthLimit > 0);
				_limit.SetEnabled(useDepthLimit);
				_limit.text = _loc.T(_limitPhrase, _waterInputCoordinates.DepthLimit);
				_depth.text = _loc.T(_depthPhrase, _waterInputCoordinates.Depth);
				_useDepthLimit.SetValueWithoutNotify(useDepthLimit);
			}
		}

		private void IncreaseDepth(ClickEvent evt)
		{
			int depthLimit = Math.Min(_waterInputSpec.MaxDepth, _waterInputCoordinates.DepthLimit + 1);
			_waterInputCoordinates.SetDepthLimit(depthLimit);
		}

		private void DecreaseDepth(ClickEvent evt)
		{
			int depthLimit = Math.Max(0, _waterInputCoordinates.DepthLimit - 1);
			_waterInputCoordinates.SetDepthLimit(depthLimit);
		}

		private void ToggleDepthLimit(ClickEvent evt)
		{
			if (_waterInputCoordinates.UseDepthLimit)
			{
				_waterInputCoordinates.DisableDepthLimit();
			}
			else
			{
				_waterInputCoordinates.SetDepthLimit(_waterInputCoordinates.Depth);
			}
		}
	}
}
