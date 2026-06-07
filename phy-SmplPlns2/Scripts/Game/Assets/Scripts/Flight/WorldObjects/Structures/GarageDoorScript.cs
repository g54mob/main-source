using System;
using DG.Tweening;
using UnityEngine;

namespace Assets.Scripts.Flight.WorldObjects.Structures
{
	public class GarageDoorScript : MonoBehaviour, INetworkTriggerStateTarget
	{
		private int _state;

		public bool IsOpen { get; private set; }

		public event Action Opened;

		public void SetState(int state, bool initialState)
		{
			if (_state != state)
			{
				_state = state;
				if (_state == 1)
				{
					Open();
				}
				else
				{
					Close();
				}
			}
		}

		private void Close()
		{
			base.transform.DOLocalRotate(new Vector3(0f, 0f, 0f), 2f);
			IsOpen = false;
		}

		private void Open()
		{
			base.transform.DOLocalRotate(new Vector3(0f, 0f, 90f), 2f);
			IsOpen = true;
			this.Opened?.Invoke();
		}
	}
}
