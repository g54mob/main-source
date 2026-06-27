using Restory.Data.Tooltips;
using Restory.Gameplay.Disassemble.Tooltips;
using Restory.Gameplay.Elements;
using Restory.Gameplay.Tooltips;
using UnityEngine;
using Zenject;

namespace Restory.Infrastructure.SceneInstallers.GameMechanics
{
	public sealed class DisassembleTooltipServiceInstaller : MonoInstaller
	{
		[SerializeField]
		private TooltipProjectionHighlighter tooltipProjectionHighlighterPrefab;

		[SerializeField]
		private ElementConditionMarker elementConditionMarkerPrefab;

		[SerializeField]
		private ClearAndRepairTooltipSettings clearAndRepairTooltipSettings;

		public override void InstallBindings()
		{
			InstallTooltipProjectionHighlighter();
			InstallElementConditionMarkerPool();
			InstallDisassembleTooltipHandler();
			InstallCleanAndRepairTooltipHandler();
			InstallSmallElementTooltipHandler();
			InstallDisassembleTooltipService();
		}

		private void InstallTooltipProjectionHighlighter()
		{
			GameObject gameObject = base.Container.InstantiateAndQueueForInject(tooltipProjectionHighlighterPrefab.gameObject);
			base.Container.BindInterfacesAndSelfTo<TooltipProjectionHighlighter>().FromComponentOn(gameObject).AsSingle();
		}

		private void InstallElementConditionMarkerPool()
		{
			base.Container.Bind<ElementConditionMarkerPool>().FromNew().AsSingle()
				.WithArguments(elementConditionMarkerPrefab.gameObject);
		}

		private void InstallDisassembleTooltipHandler()
		{
			base.Container.BindInterfacesAndSelfTo<SimpleDisassembleTooltipHandler>().AsSingle().WhenInjectedInto<DisassembleTooltipService>();
		}

		private void InstallCleanAndRepairTooltipHandler()
		{
			base.Container.BindInterfacesAndSelfTo<CleanAndRepairTooltipHandler>().AsSingle().WithArguments(clearAndRepairTooltipSettings)
				.WhenInjectedInto<DisassembleTooltipService>();
		}

		private void InstallSmallElementTooltipHandler()
		{
			base.Container.BindInterfacesAndSelfTo<SmallElementTooltipHandler>().AsSingle();
		}

		private void InstallDisassembleTooltipService()
		{
			base.Container.BindInterfacesAndSelfTo<DisassembleTooltipService>().AsSingle();
		}
	}
}
