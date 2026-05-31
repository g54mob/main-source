using System.Collections.Generic;
using CTS.Core;
using PixelCrushers.DialogueSystem;
using UnityEngine;

namespace CTS
{
	public class DialogueActorSpineLinker : MonoBehaviour
	{
		[SerializeField]
		private SerializableDictionary<Transform, GameObject> _actors = new SerializableDictionary<Transform, GameObject>();

		[SerializeField]
		private GameObject[] _defaultPortaitImages;

		private void OnDisable()
		{
			DialogueManager.instance.conversationStarted -= OnconversationStarted;
			DialogueManager.instance.conversationEnded -= Instance_conversationEnded;
		}

		private void OnEnable()
		{
			HideAll();
			DialogueManager.instance.conversationStarted += OnconversationStarted;
			DialogueManager.instance.conversationEnded += Instance_conversationEnded;
		}

		private void Instance_conversationEnded(Transform t)
		{
			HideAll();
		}

		private void OnconversationStarted(Transform t)
		{
			HideAll();
			if (_actors.ContainsKey(DialogueManager.instance.currentConversant))
			{
				_actors[DialogueManager.instance.currentConversant].SetActive(value: true);
				return;
			}
			GameObject[] defaultPortaitImages = _defaultPortaitImages;
			for (int i = 0; i < defaultPortaitImages.Length; i++)
			{
				defaultPortaitImages[i].SetActive(value: true);
			}
		}

		public void HideAll()
		{
			GameObject[] defaultPortaitImages = _defaultPortaitImages;
			for (int i = 0; i < defaultPortaitImages.Length; i++)
			{
				defaultPortaitImages[i].SetActive(value: false);
			}
			foreach (KeyValuePair<Transform, GameObject> actor in _actors)
			{
				actor.Value.SetActive(value: false);
			}
		}
	}
}
