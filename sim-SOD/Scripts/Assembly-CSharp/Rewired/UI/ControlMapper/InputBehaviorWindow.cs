using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Rewired.UI.ControlMapper
{
	[AddComponentMenu(null)]
	public class InputBehaviorWindow : Window
	{
		private class InputBehaviorInfo
		{
			private InputBehavior _inputBehavior;

			private UIControlSet _controlSet;

			private Dictionary<int, PropertyType> idToProperty;

			private InputBehavior copyOfOriginal;

			public InputBehavior inputBehavior => null;

			public UIControlSet controlSet => null;

			public InputBehaviorInfo(InputBehavior inputBehavior, UIControlSet controlSet, Dictionary<int, PropertyType> idToProperty)
			{
			}

			public void RestorePreviousData()
			{
			}

			public void RestoreDefaultData()
			{
			}

			public void RestoreData(PropertyType propertyType, int controlId)
			{
			}

			public void RefreshControls()
			{
			}
		}

		public enum ButtonIdentifier
		{
			Done = 0,
			Cancel = 1,
			Default = 2
		}

		private enum PropertyType
		{
			JoystickAxisSensitivity = 0,
			MouseXYAxisSensitivity = 1
		}

		private const float minSensitivity = 0.1f;

		[SerializeField]
		private RectTransform spawnTransform;

		[SerializeField]
		private Button doneButton;

		[SerializeField]
		private Button cancelButton;

		[SerializeField]
		private Button defaultButton;

		[SerializeField]
		private TMP_Text doneButtonLabel;

		[SerializeField]
		private TMP_Text cancelButtonLabel;

		[SerializeField]
		private TMP_Text defaultButtonLabel;

		[SerializeField]
		private GameObject uiControlSetPrefab;

		[SerializeField]
		private GameObject uiSliderControlPrefab;

		private List<InputBehaviorInfo> inputBehaviorInfo;

		private Dictionary<int, Action<int>> buttonCallbacks;

		private int playerId;

		public override void Initialize(int id, Func<int, bool> isFocusedCallback)
		{
		}

		public void SetData(int playerId, ControlMapper.InputBehaviorSettings[] data)
		{
		}

		public void SetButtonCallback(ButtonIdentifier buttonIdentifier, Action<int> callback)
		{
		}

		public override void Cancel()
		{
		}

		public void OnDone()
		{
		}

		public void OnCancel()
		{
		}

		public void OnRestoreDefault()
		{
		}

		private void JoystickAxisSensitivityValueChanged(int inputBehaviorId, int controlId, float value)
		{
		}

		private void MouseXYAxisSensitivityValueChanged(int inputBehaviorId, int controlId, float value)
		{
		}

		private void JoystickAxisSensitivityCanceled(int inputBehaviorId, int controlId)
		{
		}

		private void MouseXYAxisSensitivityCanceled(int inputBehaviorId, int controlId)
		{
		}

		public override void TakeInputFocus()
		{
		}

		private UIControlSet CreateControlSet()
		{
			return null;
		}

		private UISliderControl CreateSlider(UIControlSet set, int inputBehaviorId, string defaultTitle, string overrideTitle, Sprite icon, float minValue, float maxValue, Action<int, int, float> valueChangedCallback, Action<int, int> cancelCallback)
		{
			return null;
		}

		private InputBehavior GetInputBehavior(int id)
		{
			return null;
		}

		private InputBehaviorInfo GetInputBehaviorInfo(int inputBehaviorId)
		{
			return null;
		}
	}
}
