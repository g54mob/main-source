namespace RoslynCSharp
{
	public interface IScriptEventProxy
	{
		ScriptEventHandler this[string name] { get; }

		ScriptEventHandler GetEvent(string name);
	}
}
