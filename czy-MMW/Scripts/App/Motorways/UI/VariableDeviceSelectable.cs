using System.Collections.Generic;
using Factory;
using Motorways.Audio;
using Motorways.UI.NewContentIndicators;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Motorways.UI
{
	public class VariableDeviceSelectable : Selectable, InputState.IObserver, ISubmitHandler, IEventSystemHandler
	{
		protected IAudioSystem _audioSystem;

		[SerializeField]
		protected UIAudioProfile _audioProfile = UIAudioProfile.Generic;

		[SerializeField]
		private Transform _newContentIndicatorParent;

		[SerializeField]
		private string _newContentId;

		[SerializeField]
		private List<string> _containedNewContentIds;

		[SerializeField]
		protected bool _dontUpdateContentIDOnPointer;

		protected InputState _inputState;

		private NewContentIndicator _newContentIndicator;

		private bool _hasSubscribedToNewContentSeenEvent;

		protected MenuNavigation menuNavigation;

		protected HapticFeedbackGenerator _feedbackGenerator;

		private IScope _scope;

		public virtual string NewContentId => _newContentId;

		protected virtual bool BypassNewContentData { get; private set; }

		public virtual bool IsManuallyTriggered { get; private set; }

		public List<string> ContainedNewContentIds => _containedNewContentIds;

		public DeviceInputType DeviceInputType { get; private set; }

		public bool IsInitialized { get; private set; }

		public void SetNewContentID(string newContentId, bool bypassNewContent = false, bool isManuallyTriggered = false)
		{
			_newContentId = newContentId;
			BypassNewContentData = bypassNewContent;
			IsManuallyTriggered = isManuallyTriggered;
		}

		public override void OnPointerEnter(PointerEventData eventData)
		{
			base.OnPointerEnter(eventData);
			if (_newContentIndicator != null && !string.IsNullOrWhiteSpace(NewContentId) && !_dontUpdateContentIDOnPointer)
			{
				SetNewContentSeen(_scope);
				if (!IsNewContent(_scope))
				{
					PlayNewContentIndicatorExit();
				}
			}
		}

		public override void OnSelect(BaseEventData eventData)
		{
			base.OnSelect(eventData);
			if (_newContentIndicator != null && !string.IsNullOrWhiteSpace(NewContentId))
			{
				SetNewContentSeen(_scope);
				if (!IsNewContent(_scope))
				{
					PlayNewContentIndicatorExit();
				}
			}
		}

		public virtual void DoPressedAnimation()
		{
		}

		public virtual void OnActivate()
		{
		}

		public virtual void OnSubmit(BaseEventData eventData)
		{
		}

		public void Initialize(IScope scope)
		{
			_scope = scope;
			menuNavigation = scope.Get<MenuNavigation>();
			IsInitialized = true;
			_inputState = scope.Get<InputState>();
			_inputState.Subscribe(this);
			RegisterWithDeviceInputType(_inputState.CurrentDeviceInputType);
			_audioSystem = scope.Get<IAudioSystem>();
			_feedbackGenerator = scope.Get<HapticFeedbackGenerator>();
		}

		public void RegisterWithDeviceInputType(DeviceInputType newInputType)
		{
			DeviceInputType = newInputType;
		}

		public void Unregister()
		{
		}

		protected override void OnEnable()
		{
			base.OnEnable();
			if (_newContentIndicator != null && !IsNewContent(_scope))
			{
				Object.Destroy(_newContentIndicator.gameObject);
				_newContentIndicator = null;
			}
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();
			if (_inputState != null)
			{
				_inputState.Unsubscribe(this);
			}
		}

		public void OnCurrentDeviceInputTypeChanged(DeviceInputType newInputType)
		{
			Unregister();
			RegisterWithDeviceInputType(newInputType);
		}

		public bool ShowNewContentIndicatorIfNeeded(bool playIntro)
		{
			if (IsNewContent(_scope))
			{
				return ShowNewContentIndicator(playIntro);
			}
			return false;
		}

		protected void SetNewContentSeen(IScope appScope)
		{
			if (!string.IsNullOrWhiteSpace(NewContentId))
			{
				appScope.Get<NewContentData>().SetNewContentSeen(NewContentId);
			}
		}

		public virtual bool IsNewContentItem(IScope appScope)
		{
			if (string.IsNullOrWhiteSpace(NewContentId))
			{
				return false;
			}
			NewContentData newContentData = appScope.Get<NewContentData>();
			if (!string.IsNullOrEmpty(NewContentId) && newContentData.IsNewContent(NewContentId, BypassNewContentData))
			{
				return true;
			}
			_newContentId = null;
			return false;
		}

		public bool IsNewContentContainer(IScope appScope)
		{
			NewContentData newContentData = appScope.Get<NewContentData>();
			foreach (string containedNewContentId in _containedNewContentIds)
			{
				if (!string.IsNullOrWhiteSpace(containedNewContentId) && newContentData.IsNewContent(containedNewContentId))
				{
					if (!_hasSubscribedToNewContentSeenEvent)
					{
						newContentData.onNewContentSeen += OnNewContentSeen;
						_hasSubscribedToNewContentSeenEvent = true;
					}
					return true;
				}
			}
			return false;
		}

		protected bool IsNewContent(IScope appScope)
		{
			if (!IsNewContentItem(appScope))
			{
				return IsNewContentContainer(appScope);
			}
			return true;
		}

		private void OnNewContentSeen(string newContentId)
		{
			if (!IsNewContent(_scope))
			{
				PlayNewContentIndicatorExit();
				_scope.Get<NewContentData>().onNewContentSeen -= OnNewContentSeen;
				_hasSubscribedToNewContentSeenEvent = false;
			}
		}

		private bool InitNewContentIndicatorIfNeeded()
		{
			if (_newContentIndicator == null)
			{
				_newContentIndicator = _scope.Get<NewContentIndicator>();
				_newContentIndicator.transform.SetParent(_newContentIndicatorParent, worldPositionStays: false);
				return true;
			}
			return _newContentIndicator.IsHidden;
		}

		private bool ShowNewContentIndicator(bool playIntro)
		{
			if (InitNewContentIndicatorIfNeeded() && playIntro)
			{
				_newContentIndicator.PlayIntro();
				return true;
			}
			_newContentIndicator.PlayIdle();
			return false;
		}

		protected void PlayNewContentIndicatorExit()
		{
			if (_newContentIndicator != null)
			{
				_newContentIndicator.PlayExit();
			}
		}

		public new Selectable FindSelectable(Vector3 desiredDirection)
		{
			desiredDirection = desiredDirection.normalized;
			Vector2 vector = base.transform.position;
			float num = float.NegativeInfinity;
			Selectable result = null;
			for (int i = 0; i < Selectable.allSelectablesArray.Length; i++)
			{
				Selectable selectable = Selectable.allSelectablesArray[i];
				if (!(selectable != this) || !(selectable != null) || !selectable.IsInteractable() || selectable.navigation.mode == Navigation.Mode.None)
				{
					continue;
				}
				Vector2 vector2 = selectable.transform.position;
				Vector2 vector3 = vector2 - vector;
				float num2 = Vector3.Dot(desiredDirection, vector3);
				Debug.DrawLine(vector, vector2, Color.blue, 1f);
				if (num2 > 0f)
				{
					float num3 = num2 / vector3.sqrMagnitude;
					if (num3 > num)
					{
						num = num3;
						result = selectable;
					}
				}
			}
			return result;
		}

		public override Selectable FindSelectableOnLeft()
		{
			if (base.navigation.mode == Navigation.Mode.Explicit)
			{
				return base.navigation.selectOnLeft;
			}
			if ((base.navigation.mode & Navigation.Mode.Horizontal) != Navigation.Mode.None)
			{
				return FindSelectable(base.transform.rotation * Vector3.left);
			}
			return null;
		}

		public override Selectable FindSelectableOnRight()
		{
			if (base.navigation.mode == Navigation.Mode.Explicit)
			{
				return base.navigation.selectOnRight;
			}
			if ((base.navigation.mode & Navigation.Mode.Horizontal) != Navigation.Mode.None)
			{
				return FindSelectable(base.transform.rotation * Vector3.right);
			}
			return null;
		}

		public override Selectable FindSelectableOnUp()
		{
			if (base.navigation.mode == Navigation.Mode.Explicit)
			{
				return base.navigation.selectOnUp;
			}
			if ((base.navigation.mode & Navigation.Mode.Vertical) != Navigation.Mode.None)
			{
				return FindSelectable(base.transform.rotation * Vector3.up);
			}
			return null;
		}

		public override Selectable FindSelectableOnDown()
		{
			if (base.navigation.mode == Navigation.Mode.Explicit)
			{
				return base.navigation.selectOnDown;
			}
			if ((base.navigation.mode & Navigation.Mode.Vertical) != Navigation.Mode.None)
			{
				return FindSelectable(base.transform.rotation * Vector3.down);
			}
			return null;
		}
	}
}
