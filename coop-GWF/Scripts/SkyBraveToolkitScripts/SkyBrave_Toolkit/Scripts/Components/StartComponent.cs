using UnityEngine;
using UnityEngine.Events;

namespace SkyBrave_Toolkit.Scripts.Components
{
	public class StartComponent : MonoBehaviour
	{
		[SerializeField]
		private UnityEvent _onStart;

		private void Start()
		{
			_onStart.Invoke();
		}
	}
}
