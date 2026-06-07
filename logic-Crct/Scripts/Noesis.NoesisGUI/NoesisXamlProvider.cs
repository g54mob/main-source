using System;
using System.Collections.Generic;
using System.IO;
using Noesis;

public class NoesisXamlProvider : XamlProvider
{
	public struct Value
	{
		public int refs;

		public NoesisXaml xaml;
	}

	public static NoesisXamlProvider instance;

	private Dictionary<string, Value> _xamls;

	private NoesisXamlProvider()
		: base((IntPtr)0, cMemoryOwn: false)
	{
	}

	public void Register(string uri, NoesisXaml xaml)
	{
	}

	public void Unregister(string uri)
	{
	}

	public override Stream LoadXaml(Uri uri)
	{
		return null;
	}

	public void ReloadXaml(string uri)
	{
	}
}
