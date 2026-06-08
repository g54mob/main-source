using System;

[Serializable]
internal class CanceledStateContext
{
	public DeveloperInitiatedCancellation? developerInitiatedCancellation;

	public ReplacementCancellation? replacementCancellation;

	public SystemInitiatedCancellation? systemInitiatedCancellation;

	public UserInitiatedCancellation? userInitiatedCancellation;
}
