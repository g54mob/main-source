using System;
using Cpp2ILInjected;
using UnityEngine;

namespace Coherence;

[Serializable]
public sealed class SchemaAsset : ScriptableObject, IComparable<SchemaAsset>
{
	public string raw;

	public string identifier;

	public SchemaDefinition SchemaDefinition;

	public int CompareTo(SchemaAsset other)
	{
		//IL_0086: Expected I4, but got O
		if ((object)other != null && ((UnityEngine.Object)other).m_CachedPtr != (IntPtr)0)
		{
			if (identifier != null)
			{
				return identifier.CompareTo(other.identifier);
			}
			NullReferenceException ex = new NullReferenceException();
			return (int)ex;
		}
		return 0;
	}

	public SchemaAsset()
	{
		//IL_0010: Expected O, but got I
		//IL_0020: Expected O, but got I
		//IL_0046: Expected O, but got I
		//IL_0056: Expected O, but got I
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996AF00]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v0 @ rax_v1+B8]");
		raw = (string)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996AF00]");
		object obj2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ rax_v4+B8]");
		object obj3 = 0;
		identifier = (string)obj3;
		base._002Ector();
	}
}
