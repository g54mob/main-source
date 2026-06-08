using System.Collections.Generic;
using System.Linq;
using Timberborn.Common;
using Timberborn.CoreUI;
using Timberborn.Debugging;
using Timberborn.Effects;
using Timberborn.EntitySystem;
using Timberborn.Goods;
using Timberborn.ResourceCountingSystem;
using Timberborn.ResourceCountingSystemUI;
using Timberborn.SingletonSystem;
using Timberborn.Stockpiles;
using Timberborn.TemplateSystem;
using Timberborn.UIFormatters;
using UnityEngine.UIElements;

namespace Timberborn.StockpilesUI
{
	public class GoodStockpilesTooltipFactory : ILoadableSingleton
	{
		private static readonly string IconClass = "good-stockpile-tooltip__building-icon";

		private readonly TemplateService _templateService;

		private readonly VisualElementLoader _visualElementLoader;

		private readonly GoodEffectDescriber _goodEffectDescriber;

		private readonly ContextualResourceCountingService _contextualResourceCountingService;

		private readonly IGoodService _goodService;

		private readonly DevModeManager _devModeManager;

		private readonly Dictionary<string, List<LabeledEntitySpec>> _templates = new Dictionary<string, List<LabeledEntitySpec>>();

		public GoodStockpilesTooltipFactory(TemplateService templateService, VisualElementLoader visualElementLoader, GoodEffectDescriber goodEffectDescriber, ContextualResourceCountingService contextualResourceCountingService, IGoodService goodService, DevModeManager devModeManager)
		{
			_templateService = templateService;
			_visualElementLoader = visualElementLoader;
			_goodEffectDescriber = goodEffectDescriber;
			_contextualResourceCountingService = contextualResourceCountingService;
			_goodService = goodService;
			_devModeManager = devModeManager;
		}

		public void Load()
		{
			foreach (LabeledEntitySpec item in _templateService.GetAll<LabeledEntitySpec>().OrderBy(GetCapacity))
			{
				StockpileSpec spec = item.GetSpec<StockpileSpec>();
				if ((object)spec != null && !item.HasSpec<FixedStockpileSpec>())
				{
					_templates.GetOrAdd(spec.WhitelistedGoodType).Add(item);
				}
			}
		}

		public VisualElement Create(string goodId)
		{
			ResourceCount contextualResourceCount = _contextualResourceCountingService.GetContextualResourceCount(goodId);
			VisualElement visualElement = _visualElementLoader.LoadVisualElement("Game/GoodStockpilesTooltip");
			visualElement.Q<Label>("Name").text = _goodService.GetGood(goodId).PluralDisplayName.Value;
			visualElement.Q<Label>("StockpilesValue").text = NumberFormatter.FormatFullNumber(contextualResourceCount.StockpiledStock + contextualResourceCount.CarriedToStockpilesStock) + " / " + NumberFormatter.FormatFullNumber(contextualResourceCount.InputOutputCapacity);
			visualElement.Q<Label>("OutputsValue").text = NumberFormatter.FormatFullNumber(contextualResourceCount.BufferedOutputStock);
			visualElement.Q<Label>("InputsValue").text = NumberFormatter.FormatFullNumber(contextualResourceCount.BufferedInput + contextualResourceCount.CarriedToProcessors + contextualResourceCount.StockUnderProcessing);
			if (_devModeManager.Enabled)
			{
				FillDebugLabels(visualElement, contextualResourceCount);
				visualElement.Q("DebugTable").ToggleDisplayStyle(visible: true);
			}
			else
			{
				visualElement.Q("DebugTable").ToggleDisplayStyle(visible: false);
			}
			DescribeEffects(goodId, visualElement);
			AddIcons(visualElement.Q<VisualElement>("Icons"), _goodService.GetGood(goodId).GoodType);
			return visualElement;
		}

		private void FillDebugLabels(VisualElement root, ResourceCount resourceCount)
		{
			root.Q<Label>("DebugBufferedOutput").text = NumberFormatter.FormatFullNumber(resourceCount.BufferedOutputStock);
			root.Q<Label>("DebugCarriedToStockpiles").text = NumberFormatter.FormatFullNumber(resourceCount.CarriedToStockpilesStock);
			root.Q<Label>("DebugStockpiled").text = NumberFormatter.FormatFullNumber(resourceCount.StockpiledStock);
			root.Q<Label>("DebugAvailable").text = NumberFormatter.FormatFullNumber(resourceCount.AvailableStock);
			root.Q<Label>("DebugCarriedToProcessors").text = NumberFormatter.FormatFullNumber(resourceCount.CarriedToProcessors);
			root.Q<Label>("DebugBufferedInput").text = NumberFormatter.FormatFullNumber(resourceCount.BufferedInput);
			root.Q<Label>("DebugUnderProcessing").text = NumberFormatter.FormatFullNumber(resourceCount.StockUnderProcessing);
			root.Q<Label>("DebugAllStock").text = NumberFormatter.FormatFullNumber(resourceCount.AllStock);
		}

		private void DescribeEffects(string goodId, VisualElement root)
		{
			string text = _goodEffectDescriber.DescribeEffects(goodId);
			Label label = root.Q<Label>("Effects");
			label.text = text;
			label.ToggleDisplayStyle(!string.IsNullOrEmpty(text));
		}

		private void AddIcons(VisualElement parent, string goodType)
		{
			foreach (LabeledEntitySpec item in _templates[goodType])
			{
				Image image = new Image
				{
					name = item.DisplayNameLocKey,
					sprite = item.Icon.Asset
				};
				image.AddToClassList(IconClass);
				parent.Add(image);
			}
		}

		private static int GetCapacity(LabeledEntitySpec entitySpec)
		{
			return entitySpec.GetSpec<StockpileSpec>()?.MaxCapacity ?? 0;
		}
	}
}
