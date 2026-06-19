using System;
using Items;
using JSAM;
using MyBox;
using UnityEngine;
using UnityEngine.Events;

namespace WorldEnvironment.FunctionalObjects
{
	public class EnablerSwitch : MonoBehaviour, IUsable
	{
		public UnityEvent OnActivate;

		public UnityEvent OnDeactivate;

		[SerializeField]
		private SoundFileObject _switchSoundObject;

		[SerializeField]
		private bool _isActivated;

		[SerializeField]
		private GameObject[] _objectsToEnable;

		[SerializeField]
		private bool _interactable;

		public bool Interactable
		{
			get
			{
				return _interactable;
			}
			set
			{
				_interactable = value;
			}
		}

		protected event Action<bool> StateChanged;

		void IUsable.UnUse()
		{
		}

		void IUsable.Use()
		{
			if (!_isActivated)
			{
				_objectsToEnable.ForEach(delegate(GameObject obj)
				{
					obj.SetActive(value: true);
				});
				_isActivated = true;
				AudioManager.PlaySound(_switchSoundObject);
				this.StateChanged?.Invoke(_isActivated);
				if (_interactable)
				{
					OnActivate?.Invoke();
				}
			}
			else
			{
				_objectsToEnable.ForEach(delegate(GameObject obj)
				{
					obj.SetActive(value: false);
				});
				_isActivated = false;
				AudioManager.PlaySound(_switchSoundObject);
				this.StateChanged?.Invoke(_isActivated);
				if (_interactable)
				{
					OnDeactivate?.Invoke();
				}
			}
		}

		public void UpdateState()
		{
			if (_isActivated)
			{
				OnActivate?.Invoke();
			}
			else
			{
				OnDeactivate?.Invoke();
			}
		}
	}
}
