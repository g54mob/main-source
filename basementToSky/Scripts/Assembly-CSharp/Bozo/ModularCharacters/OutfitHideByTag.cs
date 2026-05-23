using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Bozo.ModularCharacters
{
	public class OutfitHideByTag : MonoBehaviour
	{
		[Serializable]
		private struct HideSettings
		{
			public SkinnedMeshRenderer renderer;

			public string tag;
		}

		private OutfitSystem system;

		[SerializeField]
		private HideSettings[] settings;

		public void OnEnable()
		{
			system = GetComponentInParent<OutfitSystem>(includeInactive: true);
			OutfitSystem outfitSystem = system;
			outfitSystem.OnTagsChanged = (UnityAction<List<string>>)Delegate.Combine(outfitSystem.OnTagsChanged, new UnityAction<List<string>>(SetHide));
		}

		public void OnDisable()
		{
			system = GetComponentInParent<OutfitSystem>(includeInactive: true);
			OutfitSystem outfitSystem = system;
			outfitSystem.OnTagsChanged = (UnityAction<List<string>>)Delegate.Remove(outfitSystem.OnTagsChanged, new UnityAction<List<string>>(SetHide));
		}

		private void SetHide(List<string> tags)
		{
			HideSettings[] array = settings;
			for (int i = 0; i < array.Length; i++)
			{
				HideSettings hideSettings = array[i];
				if (system.ContainsTag(hideSettings.tag))
				{
					hideSettings.renderer.gameObject.SetActive(value: false);
				}
				else
				{
					hideSettings.renderer.gameObject.SetActive(value: true);
				}
			}
		}
	}
}
