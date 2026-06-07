using UnityEngine;
using UnityEngine.EventSystems;

namespace MoreMountains.Tools
{
	[AddComponentMenu("More Mountains/Tools/GUI/MM Get Focus On Enable")]
	public class MMGetFocusOnEnable : MonoBehaviour
	{
		protected virtual void OnEnable()
		{
			EventSystem.current.SetSelectedGameObject(base.gameObject, null);
		}
	}
}
