using CTS.Core;
using UnityEngine;
using UnityEngine.UI;

namespace CTS
{
	public class UIFloors : MonoBehaviour
	{
		[SerializeField]
		private Toggle[] _toggles;

		private void Awake()
		{
		}

		private void OnEnable()
		{
			FloorsManager.ChangingFloor += OnChangingFloor;
		}

		private void OnDisable()
		{
			FloorsManager.ChangingFloor -= OnChangingFloor;
		}

		private void OnChangingFloor(Floor newFloor)
		{
			if (newFloor.FloorID < _toggles.Length)
			{
				_toggles[newFloor.FloorID].isOn = true;
			}
		}

		public void ChangeFloor(int p_floor)
		{
			if (FloorsManager.CurrentFloor.FloorID != p_floor)
			{
				MonoSingleton<FloorsManager>.Instance.ChangeCurrentFloor(p_floor);
			}
		}
	}
}
