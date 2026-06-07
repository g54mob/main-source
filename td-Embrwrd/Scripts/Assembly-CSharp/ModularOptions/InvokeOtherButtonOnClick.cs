using UnityEngine;
using UnityEngine.UI;

namespace ModularOptions
{
	[RequireComponent(typeof(Button))]
	[AddComponentMenu("Modular Options/Button/Invoke Other Button")]
	public class InvokeOtherButtonOnClick : MonoBehaviour
	{
		public Button buttonToInvoke;

		private void Awake()
		{
		}
	}
}
