using System;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Rewired.UI.ControlMapper
{
	[AddComponentMenu(null)]
	public abstract class UIElementInfo : MonoBehaviour, ISelectHandler, IEventSystemHandler
	{
		public string identifier;

		public int intData;

		public TMP_Text text;

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
