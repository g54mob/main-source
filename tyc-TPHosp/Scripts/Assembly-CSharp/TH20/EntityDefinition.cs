using FullInspector;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class EntityDefinition : IEntityDefinition
	{
		[SerializeField]
		[InspectorTooltip("Components to add to this entity")]
		private EntityComponent[] _components;

		public EntityComponent[] Components => _components;
	}
}
