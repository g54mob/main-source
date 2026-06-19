using Unity.Entities;
using Unity.Mathematics;

public interface IMiniSimCritterPresenter
{
	void UpdateDisplayedObjects(DynamicBuffer<ContainedObjectsBuffer> containedObjectsBuffer);

	void UpdateSimulationPosition(int index, float3 position);

	void PlayAnimationForVisual(int index, int animationID, int orientationHash, bool flipX);
}
