using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace TriLib.Samples
{
	public class AnimationText : MonoBehaviour, ISelectHandler, IEventSystemHandler
	{
		public string Text
		{
			get
			{
				return GetComponent<Text>().text;
			}
			set
			{
				GetComponent<Text>().text = value;
			}
		}

		public void OnSelect(BaseEventData eventData)
		{
			AssetLoaderWindow.Instance.HandleEvent(Text);
		}
	}
}
