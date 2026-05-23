using System;
using System.Collections.Generic;
using DG.Tweening;
using Data.Breadcrumbs;
using Data.SaveData.PersistentSOs;
using Events.Breadcrumbs;
using NaughtyAttributes;
using UnityEngine;

namespace UI.Breadcrumbs
{
	public class BreadcrumbUI : MonoBehaviour
	{
		[Serializable]
		private class BreadcrumbState
		{
			[SerializeField]
			private BreadcrumbStateSO _stateName;

			[SerializeField]
			private GameObject _toggleGameObject;

			public BreadcrumbStateSO State => _stateName;

			public GameObject ToggleGameObject => _toggleGameObject;
		}

		public enum ListenType
		{
			Id = 0,
			Tags = 1,
			WaitToBeSet = 2
		}

		[SerializeField]
		protected BreadcrumbsPersistentSO _breadcrumbsPersistentSO;

		[SerializeField]
		private BreadcrumbEvent _breadcrumbUpdatedEvent;

		[SerializeField]
		protected ListenType _listenType;

		[SerializeField]
		[ShowIf("IsListeningToId")]
		private string _breadcrumbId = string.Empty;

		[SerializeField]
		[ShowIf("IsListeningToTags")]
		private List<string> _tags = new List<string>();

		[SerializeField]
		private BreadcrumbState[] _states;

		private BreadcrumbState _activeState;

		private bool IsListeningToId => _listenType == ListenType.Id;

		private bool IsListeningToTags => _listenType == ListenType.Tags;

		private void Awake()
		{
			BreadcrumbState[] states = _states;
			for (int i = 0; i < states.Length; i++)
			{
				states[i].ToggleGameObject.SetActive(value: false);
			}
		}

		private void OnEnable()
		{
			UpdateState();
			_breadcrumbUpdatedEvent.Register(OnBreadcrumbUpdated);
		}

		private void OnDisable()
		{
			_breadcrumbUpdatedEvent.UnRegister(OnBreadcrumbUpdated);
			SwitchActiveState(null);
		}

		private void OnBreadcrumbUpdated(Breadcrumb _)
		{
			UpdateState();
		}

		private void UpdateState()
		{
			switch (_listenType)
			{
			case ListenType.Id:
				UpdateIdState();
				break;
			case ListenType.Tags:
				UpdateTagState();
				break;
			}
		}

		private void UpdateIdState()
		{
			BreadcrumbState state = null;
			BreadcrumbState[] states = _states;
			foreach (BreadcrumbState breadcrumbState in states)
			{
				if (_breadcrumbsPersistentSO.GetBreadcrumbState(_breadcrumbId, breadcrumbState.State))
				{
					state = breadcrumbState;
					break;
				}
			}
			SwitchActiveState(state);
		}

		private void UpdateTagState()
		{
			BreadcrumbState state = null;
			BreadcrumbState[] states = _states;
			foreach (BreadcrumbState breadcrumbState in states)
			{
				bool flag = false;
				foreach (string tag in _tags)
				{
					flag = _breadcrumbsPersistentSO.GetTagState(tag, breadcrumbState.State);
					if (flag)
					{
						state = breadcrumbState;
						break;
					}
				}
				if (flag)
				{
					break;
				}
			}
			SwitchActiveState(state);
		}

		private void SwitchActiveState(BreadcrumbState state)
		{
			if (_activeState == state)
			{
				return;
			}
			if (_activeState != null && _activeState.ToggleGameObject != null)
			{
				_activeState.ToggleGameObject.SetActive(value: false);
			}
			_activeState = state;
			if (_activeState != null && _activeState.ToggleGameObject != null)
			{
				_activeState.ToggleGameObject.SetActive(value: true);
				if (_activeState.ToggleGameObject.transform is RectTransform target)
				{
					target.DOPunchScale(Vector3.one, 0.25f).SetDelay(0.25f);
				}
			}
		}

		public void SetBreadcrumbId(string breadcrumbId)
		{
			_breadcrumbId = breadcrumbId;
			if (string.IsNullOrEmpty(_breadcrumbId))
			{
				_listenType = ListenType.WaitToBeSet;
				SwitchActiveState(null);
			}
			else
			{
				_listenType = ListenType.Id;
				UpdateIdState();
			}
		}

		public void SetBreadcrumbTags(List<string> breadcrumbTags)
		{
			_tags = breadcrumbTags;
			_listenType = ListenType.Tags;
			UpdateTagState();
		}
	}
}
