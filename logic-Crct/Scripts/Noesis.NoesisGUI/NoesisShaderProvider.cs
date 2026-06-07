using System.Collections.Generic;

public class NoesisShaderProvider
{
	public struct Value
	{
		public int refs;

		public NoesisShader shader;
	}

	public static NoesisShaderProvider instance;

	private Dictionary<string, Value> _shaders;

	private NoesisShaderProvider()
	{
	}

	public void Register(string uri, NoesisShader shader)
	{
	}

	public void Unregister(string uri)
	{
	}

	public NoesisShader GetShader(string uri)
	{
		return null;
	}
}
