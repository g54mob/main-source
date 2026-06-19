using System;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class AttachActorToCharacterComponent : EntityComponent
	{
		private AdditionalActorDefinition _actorDefinition;

		[DontSave]
		private GameObject _actor;

		protected override Type ValidEntityType()
		{
			return typeof(Character);
		}

		public void Attach(AdditionalActorDefinition actorDefinition)
		{
			Detach();
			Transform parent = GetOwner<Character>().Visual.RigGameObject.transform.FindChildRecursively(actorDefinition._socketName);
			_actor = actorDefinition.SpawnActor(parent);
			_actorDefinition = actorDefinition;
		}

		private void Detach()
		{
			if (_actor != null)
			{
				UnityEngine.Object.Destroy(_actor);
			}
		}

		public override void Destroy()
		{
			Detach();
			base.Destroy();
		}

		internal override void RestoreComponentFromSave()
		{
			base.RestoreComponentFromSave();
			Attach(_actorDefinition);
		}
	}
}
