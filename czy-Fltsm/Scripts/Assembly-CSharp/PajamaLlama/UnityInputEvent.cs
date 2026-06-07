using UnityEngine;
using UnityEngine.Events;

namespace PajamaLlama
{
	public class UnityInputEvent : MonoBehaviour
	{
		[SerializeField]
		private KeyCode[] _keys;

		[SerializeField]
		public UnityEvent _onTriggered;

		public void Update()
		{
			int num = _keys.Length - 1;
			if (!Input.GetKeyDown(_keys[num]))
			{
				return;
			}
			int num2 = num;
			while (0 < num2--)
			{
				if (!Input.GetKey(_keys[num2]))
				{
					return;
				}
			}
			_onTriggered.Invoke();
		}
	}
}
