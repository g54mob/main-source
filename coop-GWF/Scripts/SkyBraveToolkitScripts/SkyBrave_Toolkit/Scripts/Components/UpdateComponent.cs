using UnityEngine;
using UnityEngine.Events;

namespace SkyBrave_Toolkit.Scripts.Components
{
	public class UpdateComponent : MonoBehaviour
	{
		[SerializeField]
		private UnityEvent _onUpdate;

		private void Update()
		{
			_onUpdate?.Invoke();
		}
	}
}
