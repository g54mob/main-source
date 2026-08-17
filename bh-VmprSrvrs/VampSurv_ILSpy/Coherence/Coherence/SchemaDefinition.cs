using System;
using System.Collections.Generic;

namespace Coherence;

[Serializable]
public class SchemaDefinition
{
	public string SchemaId;

	public List<ComponentDefinition> ComponentDefinitions;

	public List<CommandDefinition> CommandDefinitions;

	public List<ArchetypeDefinition> ArchetypeDefinitions;

	public List<InputDefinition> InputDefinitions;

	public SchemaDefinition()
	{
		List<ComponentDefinition> componentDefinitions = new List<ComponentDefinition>();
		ComponentDefinitions = componentDefinitions;
		List<CommandDefinition> commandDefinitions = new List<CommandDefinition>();
		CommandDefinitions = commandDefinitions;
		List<ArchetypeDefinition> archetypeDefinitions = new List<ArchetypeDefinition>();
		ArchetypeDefinitions = archetypeDefinitions;
		List<InputDefinition> inputDefinitions = new List<InputDefinition>();
		InputDefinitions = inputDefinitions;
	}
}
