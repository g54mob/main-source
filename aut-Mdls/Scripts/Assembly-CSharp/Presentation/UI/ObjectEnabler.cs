using UnityEngine;

namespace Presentation.UI
{
	public class ObjectEnabler : MonoBehaviour
	{
		[SerializeField]
		private GameObject[] _objectsToEnable;

		[SerializeField]
		private GameObject[] _objectsToDisable;

		private bool _isActive;

		public bool IsActive
		{
			get
			{
				return _isActive;
			}
			set
			{
				_isActive = value;
				if (_objectsToEnable != null && _objectsToEnable.Length != 0)
				{
					for (int i = 0; i < _objectsToEnable.Length; i++)
					{
						_objectsToEnable[i].SetActive(value);
					}
				}
				if (_objectsToDisable != null && _objectsToDisable.Length != 0)
				{
					for (int j = 0; j < _objectsToDisable.Length; j++)
					{
						_objectsToDisable[j].SetActive(!value);
					}
				}
			}
		}
	}
}
