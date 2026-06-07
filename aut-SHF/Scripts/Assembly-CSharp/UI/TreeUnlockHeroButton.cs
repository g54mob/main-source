using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UI
{
	public class TreeUnlockHeroButton : MonoBehaviour
	{
		public GameObject selectCursor;

		public Image mainIcon;

		public eLuggage Luggage { get; private set; }

		public event UnityAction OnClickAction
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

		public void InitComponent(eLuggage luggage, Sprite sprite, bool selected = false)
		{
		}

		public void OnClick()
		{
		}
	}
}
