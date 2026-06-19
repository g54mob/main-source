using UnityEngine;

namespace MateoRyhr
{
	public class InputEnabler : MonoBehaviour
	{
		private BasicInput _input;

		private void Awake()
		{
			_input = GetComponent<BasicInput>();
		}

		private void OnEnable()
		{
			if ((bool)_input)
			{
				_input.SuscribeInputs();
			}
			else
			{
				Debug.Log("Warning: A component InputEnabler must exist in the same game object that a BasicInput type", this);
			}
		}

		private void OnDisable()
		{
			if ((bool)_input)
			{
				_input.UnsubscribeInputs();
			}
			else
			{
				Debug.Log("Warning: A component InputEnabler must exist in the same game object that a BasicInput type", this);
			}
		}
	}
}
