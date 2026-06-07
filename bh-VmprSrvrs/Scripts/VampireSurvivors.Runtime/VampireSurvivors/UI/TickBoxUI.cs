using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace VampireSurvivors.UI
{
	public class TickBoxUI : MonoBehaviour, ISelectableUI, IUIObject
	{
		[SerializeField]
		private GameObject _On;

		[SerializeField]
		private GameObject _Off;

		[SerializeField]
		private UnityEvent<bool> OnToggle;

		private bool isOn;

		public bool IsOn => false;

		private void Start()
		{
		}

		public void Toggle()
		{
		}

		public void SetOn()
		{
		}

		public void SetOff()
		{
		}

		public void PlaySound(bool b)
		{
		}

		public void InitialSet(bool b)
		{
		}

		public void Initialize(bool _isOn)
		{
		}

		public void AddOnToggle(Action<bool> cb)
		{
		}

		public void SetInteractive(bool isInteractive)
		{
		}

		public Selectable GetSelectable()
		{
			return null;
		}

		public GameObject GetGameObject()
		{
			return null;
		}

		public void UpdateNavigation(Selectable up, Selectable down, Selectable left, Selectable right)
		{
		}

		public void MakeVisuallyDisabled()
		{
		}

		public void MakeVisuallyEnabled()
		{
		}
	}
}
