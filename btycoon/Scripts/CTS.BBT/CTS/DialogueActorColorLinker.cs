using CTS.Core;
using PixelCrushers.DialogueSystem;
using UnityEngine;
using UnityEngine.UI;

namespace CTS
{
	public class DialogueActorColorLinker : MonoBehaviour
	{
		[SerializeField]
		private ActorsColorData _actorsColorData;

		[SerializeField]
		private SerializableDictionary<Transform, EActors> _actors = new SerializableDictionary<Transform, EActors>();

		[SerializeField]
		private Image[] _images;

		private void OnDisable()
		{
			DialogueManager.instance.conversationStarted -= OnconversationStarted;
		}

		private void OnEnable()
		{
			DialogueManager.instance.conversationStarted += OnconversationStarted;
		}

		private void OnconversationStarted(Transform t)
		{
			Image[] images = _images;
			foreach (Image image in images)
			{
				image.color = new Color
				{
					r = _actorsColorData.Actors[_actors[DialogueManager.instance.currentConversant]].r,
					g = _actorsColorData.Actors[_actors[DialogueManager.instance.currentConversant]].g,
					b = _actorsColorData.Actors[_actors[DialogueManager.instance.currentConversant]].b,
					a = image.color.a
				};
			}
		}
	}
}
