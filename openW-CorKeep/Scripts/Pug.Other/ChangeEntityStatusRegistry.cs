using Pug.UnityExtensions;
using Unity.Collections;
using Unity.Entities;

public struct ChangeEntityStatusRegistry : IComponentData, IQueryTypeParameter
{
	public NativeList<Entity> EntitiesToEnable;

	public NativeList<DisabledEntity> EntitiesToDisable;

	public NativeFreeList<DisabledEntity> DisabledInfoCollection;
}
