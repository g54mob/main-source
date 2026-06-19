using Pug.UnityExtensions;
using Unity.Entities;

public struct ActivatedByElectricityStateCD : IComponentData, IQueryTypeParameter
{
	public enum State
	{
		Initializing = 0,
		Activating = 1,
		Active = 2,
		Deactivating = 3,
		Deactivated = 4
	}

	public float activationTime;

	public float deactivationTime;

	public bool changeVariationOnActivate;

	public int variationToChangeTo;

	public ThreadSafeTimerSimple internalTimer;

	public State internalState;
}
