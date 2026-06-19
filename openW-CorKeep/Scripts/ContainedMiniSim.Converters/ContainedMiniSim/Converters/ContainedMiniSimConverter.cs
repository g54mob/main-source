using ContainedMiniSim.Authoring;
using ContainedMiniSim.Components;
using Pug.Conversion;

namespace ContainedMiniSim.Converters
{
	public class ContainedMiniSimConverter : SingleAuthoringComponentConverter<ContainedMiniSimAuthoring>
	{
		protected override void Convert(ContainedMiniSimAuthoring authoring)
		{
			AddComponentData(new ContainedMiniSimDimensionsCD
			{
				simulateAreaMinMaxWidth = authoring.simulateAreaMinMaxWidth,
				simulateAreaMinMaxHeight = authoring.simulateAreaMinMaxHeight,
				simulateAreaMinMaxLength = authoring.simulateAreaMinMaxLength
			});
			AddComponentData(new ContainedMiniSimContainerCD
			{
				maxNumberOfSimulatedElements = authoring.maxNumberOfSimulatedElements,
				simulatedEntity = GetPrefabDependency(authoring.simulatedEntity.gameObject)
			});
			EnsureHasComponent<ContainedMiniSimInitialized>(componentIsEnabled: false);
			EnsureHasBuffer<ContainedMiniSimElementBuffer>();
			EnsureHasBuffer<ContainedMiniSimElementVisualBuffer>();
			EnsureHasBuffer<ContainedMiniSimElementLastVisualBuffer>();
			ContainedMiniSimElementAuthoring simulatedEntity = authoring.simulatedEntity;
			if (!(simulatedEntity == null))
			{
				if (simulatedEntity.TryGetComponent<TerrariumCritterMovementAuthoring>(out var _))
				{
					EnsureHasComponent<TerrariumTagCD>();
				}
				if (simulatedEntity.TryGetComponent<AquariumFishMovementAuthoring>(out var _))
				{
					EnsureHasComponent<AquariumTagCD>();
				}
			}
		}
	}
}
