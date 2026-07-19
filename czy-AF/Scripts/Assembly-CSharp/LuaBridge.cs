using System;
using MoonSharp.Interpreter;

public class LuaBridge
{
	public Script script;

	public LuaBridge()
	{
		UserData.RegisterAssembly();
		script = new Script();
	}

	public void AddObject(string addAs, object obj)
	{
		script.Globals[addAs] = obj;
	}

	public void AddFunction(string addAs, Delegate func)
	{
		script.Globals[addAs] = func;
	}

	public void ExecuteCode(string code)
	{
		script.DoString(code);
	}
}
