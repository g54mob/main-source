namespace RoslynCSharp
{
	public interface IScriptDataProxy
	{
		object this[string name] { get; set; }

		void SetValue(string name, object value);

		object GetValue(string name);
	}
}
