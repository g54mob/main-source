using System.Collections.Generic;
using System.Linq;
using Data.FactoryFloor;
using Data.FactoryFloor.PlacementValidators;
using Events.FactoryFloor.BluePrint;
using Events.UI;
using Logic.Factory.Blueprint;
using Presentation.FactoryFloor.Toolbar;
using Presentation.Locators;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Logic.FactoryTools
{
	public abstract class FactoryTool : ScriptableObject
	{
		[Header("General")]
		[SerializeField]
		protected SetCursorEvent _setCursorEvent;

		[SerializeField]
		protected SetCursorTextEvent _setCursorTextEvent;

		[SerializeField]
		protected Texture2D _cursorTexture;

		[SerializeField]
		protected Vector2 _cursorOffset;

		[SerializeField]
		protected string _cursorTextKey;

		[SerializeField]
		protected ValidatorFailReasonEvent _failReasonEvent;

		[SerializeField]
		private string _breadcrumbId;

		[Header("Tooltip")]
		[SerializeField]
		protected GameplayTooltipEventSO _gameplayTooltipSO;

		[SerializeField]
		protected string _tooltipLocalizationKey;

		[SerializeField]
		protected InputActionReference[] _tooltipInputActions;

		[Header("Audio")]
		[SerializeField]
		protected AudioManagerLocator _audioManagerLocator;

		[Header("Demo")]
		[SerializeField]
		protected FactoryObjectBlockedInDemoDatabase _factoryObjectBlockedInDemoDatabase;

		private readonly List<FactoryObjectPlacementValidator.ValidatorFailReason> _failReasons = new List<FactoryObjectPlacementValidator.ValidatorFailReason>();

		public virtual string BreadcrumbId => _breadcrumbId;

		public abstract bool CanAutoSwapAwayFrom { get; }

		public abstract void UpdateTool(Vector3Int gridPosition, Vector3 mousePos);

		public abstract void OnActionIntent(Vector3Int gridPosition, Vector3 mousePos);

		public abstract void DoAction(Vector3Int gridPosition, Vector3 mousePos);

		public abstract void CancelAction();

		public virtual void SelectTool(Blueprint blueprint)
		{
			SetCursor();
			bool flag = string.IsNullOrEmpty(_tooltipLocalizationKey);
			if (!flag)
			{
				_gameplayTooltipSO.SetLocalizationKey(_tooltipLocalizationKey, _tooltipInputActions);
			}
			_gameplayTooltipSO.SetActiveState(!flag);
		}

		public void SetCursor(Texture2D customCursor = null)
		{
			if (_setCursorEvent != null)
			{
				string item = (string.IsNullOrEmpty(_cursorTextKey) ? string.Empty : LocalizationUtility.GetLocalizedText(_cursorTextKey));
				_setCursorEvent.Fire(((customCursor != null) ? customCursor : _cursorTexture, item, _cursorOffset));
			}
		}

		public virtual void DoAction(FactoryObject factoryObject)
		{
		}

		public virtual void DeSelectTool()
		{
			_gameplayTooltipSO.SetActiveState(isActive: false);
		}

		public virtual void Rotate(int rotation)
		{
		}

		public virtual void Mirror()
		{
		}

		protected void HandleFailReasonEvent(FactoryObjectPlacementValidator.ValidatorFailReason failReason)
		{
			_failReasons.Add(failReason);
		}

		protected void ShowFailReasons()
		{
			if (_failReasons.Count == 0)
			{
				_setCursorTextEvent.Fire(string.Empty);
				return;
			}
			string text = _failReasons.First().Reason;
			for (int i = 1; i < _failReasons.Count; i++)
			{
				FactoryObjectPlacementValidator.ValidatorFailReason validatorFailReason = _failReasons[i];
				if (!text.Contains(validatorFailReason.Reason))
				{
					text = text + "\n \n" + validatorFailReason.Reason;
				}
			}
			_setCursorTextEvent.Fire(text);
			_failReasons.Clear();
		}
	}
}
