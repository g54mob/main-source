using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Rewired.UI.ControlMapper
{
	[AddComponentMenu(null)]
	public abstract class UIElementInfo : MonoBehaviour, ISelectHandler, IEventSystemHandler
	{
		public string identifier;

		public int intData;

		public Text text;

		public event Action<GameObject> OnSelectedEvent
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public void OnSelect(BaseEventData eventData)
		{
		}
	}
}
