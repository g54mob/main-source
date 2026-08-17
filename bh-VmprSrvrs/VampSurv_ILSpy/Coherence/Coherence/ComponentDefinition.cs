using System;
using System.Collections.Generic;
using Cpp2ILInjected;

namespace Coherence;

[Serializable]
public class ComponentDefinition : BaseDefinition
{
	public string bitMasks;

	public List<ComponentMemberDescription> members;

	public DictionaryOfStringString overrides;

	public int totalSize;

	public string baseComponentName;

	public bool generatedByArchetype;

	public string bakeConditional;

	public ComponentDefinition(string name, string bakeConditional = "")
	{
		//IL_006b: Expected O, but got I
		//IL_007b: Expected O, but got I
		DictionaryOfStringString dictionaryOfStringString = new DictionaryOfStringString();
		overrides = dictionaryOfStringString;
		base.name = name;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996AF00]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v167 @ rax_v6+B8]");
		object obj2 = 0;
		bitMasks = (string)obj2;
		List<ComponentMemberDescription> list = new List<ComponentMemberDescription>();
		members = list;
		this.bakeConditional = bakeConditional;
	}
}
