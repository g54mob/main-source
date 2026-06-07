using UnityEngine;
using UnityEngine.Events;

namespace SkyBrave_Toolkit.Scripts.Components
{
	public class ListenMouseInputComponent : MonoBehaviour
	{
		[SerializeField]
		private UnityEvent onMouseButtonLeftClicked;

		private void Update()
		{
			if (Input.GetMouseButtonDown(0))
			{
				onMouseButtonLeftClicked.Invoke();
			}
		}
	}
}
