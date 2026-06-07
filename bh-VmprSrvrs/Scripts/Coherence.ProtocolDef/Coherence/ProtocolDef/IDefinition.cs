using Coherence.Entities;

namespace Coherence.ProtocolDef
{
	public interface IDefinition : ISchemaSpecificComponentDeserialize, ISchemaSpecificComponentSerialize, IAuthorityManagement, IBuiltInComponentAccess, IComponentInfo
	{
	}
}
