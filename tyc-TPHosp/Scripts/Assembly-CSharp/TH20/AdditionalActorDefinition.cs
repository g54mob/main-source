#define LOG_LEVEL_VERBOSE
using System;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[Serializable]
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class AdditionalActorDefinition
	{
		public GameObject _prefab;

		public RuntimeAnimatorController _animGraph;

		public string _socketName;

		public GameObject SpawnActor(Transform parent)
		{
			GameObject gameObject = UnityEngine.Object.Instantiate(_prefab);
			gameObject.transform.SetParent(parent, worldPositionStays: false);
			if (_animGraph != null)
			{
				Animator componentInChildren = gameObject.GetComponentInChildren<Animator>();
				if (componentInChildren != null)
				{
					componentInChildren.runtimeAnimatorController = _animGraph;
				}
				else
				{
					Logging.Error(LogChannels.Interaction, "Additional actor expected to have an Animator component");
				}
			}
			return gameObject;
		}
	}
}
