using Unity.Burst;

public struct EnvironmentEventFunctions
{
	public FunctionPointer<EnvironmentEventBase.ShouldActivateEvent> shouldActivateEvent;

	public FunctionPointer<EnvironmentEventBase.InitEvent> initEvent;

	public FunctionPointer<EnvironmentEventBase.ExecuteEvent> executeEvent;
}
