public class SSNativeObject : StonescriptObject
{
	private static int _instances;

	private object source;

	public object Source => source;

	public SSNativeObject(object source)
		: base("native" + _instances++)
	{
		this.source = source;
		SSScriptableObject.Bind(source, this);
	}
}
public class SSNativeObject<T> : StonescriptObject
{
	private static int _instances;

	private T source;

	public T Source => source;

	public SSNativeObject(T source)
		: base("native" + _instances++)
	{
		this.source = source;
		SSScriptableObject.Bind(source, this);
	}
}
