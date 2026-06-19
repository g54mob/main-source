using System.Collections.Generic;
using Pug.Conversion;
using UnityEngine;
using UnityEngine.Events;

namespace Interaction
{
	public class LocalInteractableConverter : SingleAuthoringComponentConverter<LocalInteractableAuthoring>
	{
		protected override void Convert(LocalInteractableAuthoring authoring)
		{
			EntityMonoBehaviourData component = authoring.GetComponent<EntityMonoBehaviourData>();
			List<PrefabInfo> list = ((!(component != null)) ? null : component.objectInfo?.prefabInfos);
			if (list == null)
			{
				list = new List<PrefabInfo>
				{
					new PrefabInfo
					{
						prefab = authoring.GetComponent<ObjectAuthoring>()?.graphicalPrefab?.GetComponent<MonoBehaviour>()
					}
				};
			}
			InteractableObject interactableObject = list[0].prefab.GetComponentsInChildren<InteractableObject>(includeInactive: true)[0];
			bool flag = HasAnyRegisteredInteraction(interactableObject.onUseActions, authoring.gameObject);
			bool flag2 = HasAnyRegisteredInteraction(interactableObject.onTriggerExitActions, authoring.gameObject);
			if (!flag && !flag2)
			{
				Debug.LogError("No local interaction events registered on entity. " + authoring.gameObject.name, authoring.gameObject);
				return;
			}
			if (flag)
			{
				((Converter)this).EnsureHasBuffer<TriggerUseInteractionBuffer>();
				((Converter)this).EnsureHasComponent<LocalUseInteractionTriggerCD>(false);
			}
			if (flag2)
			{
				((Converter)this).EnsureHasBuffer<TriggerExitInteractionBuffer>();
				((Converter)this).EnsureHasComponent<LocalExitInteractionTriggerCD>(false);
			}
		}

		private bool HasAnyRegisteredInteraction(List<UnityEvent> interactableOnUseActions, GameObject gameObject)
		{
			foreach (UnityEvent interactableOnUseAction in interactableOnUseActions)
			{
				if (interactableOnUseAction.GetPersistentEventCount() > 0)
				{
					return true;
				}
			}
			return false;
		}
	}
}
