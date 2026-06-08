namespace RoslynCSharp
{
	public interface IScriptMemberProxy
	{
		object this[string name] { get; set; }
	}
}
