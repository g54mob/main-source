public interface IRetroDebuggerListener
{
	void OnDebugStateChange();

	void OnDebugBreak(ModuleId cpuId, LuaStacktrace stacktrace);
}
