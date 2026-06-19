using UnityEngine;
using UnityEngine.Events;

namespace MateoRyhr
{
	public class KeyInput : MonoBehaviour
	{
		[SerializeField]
		private string _inputKey;

		public UnityEvent OnPerformed;

		private void Update()
		{
			if (Input.GetKeyUp(_inputKey))
			{
				OnPerformed?.Invoke();
			}
		}
	}
}
