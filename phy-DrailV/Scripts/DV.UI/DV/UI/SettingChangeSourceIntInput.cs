using System.Collections;
using DV.UIFramework;
using DV.Utils;
using TMPro;
using UnityEngine;

namespace DV.UI
{
	public class SettingChangeSourceIntInput : SettingChangeSource<int>
	{
		private const float VALIDATION_TIMEOUT = 0.4f;

		[NullCheck]
		[SerializeField]
		private TMP_InputField inputField;

		[SerializeField]
		private bool clamp;

		[SerializeField]
		private Vector2Int clampRange = new Vector2Int(0, 0);

		private float lastModificationTime;

		private Coroutine saveLaterCoroutine;

		private bool isSynced = true;

		protected override void Awake()
		{
			base.Awake();
			inputField.onValueChanged.AddListener(OnValueChanged);
			inputField.onSelect.AddListener(OnSelect);
			inputField.onEndEdit.AddListener(OnDeselect);
		}

		private void OnDestroy()
		{
			inputField.onValueChanged.RemoveListener(OnValueChanged);
			inputField.onSelect.RemoveListener(OnSelect);
			inputField.onEndEdit.RemoveListener(OnDeselect);
		}

		private void OnDisable()
		{
			if (!isSynced)
			{
				ApplyValue();
			}
			StopSaveLaterCoro();
		}

		private void OnSelect(string text)
		{
			SingletonBehaviour<APlatformProvider>.Instance.RequestTextInput(new APlatformProvider.TextInputRequest(inputField, isMultiLine: false, labelTMPro.text, delegate(APlatformProvider.TextInputResult result)
			{
				if (result.SaveText)
				{
					inputField.text = result.Text;
					inputField.caretPosition = int.MaxValue;
				}
				if (result.IsFinished)
				{
					inputField.DeactivateInputField();
				}
			}));
		}

		private void OnDeselect(string arg0)
		{
			SingletonBehaviour<APlatformProvider>.Instance.FinishTextInput();
		}

		private void OnValueChanged(string value)
		{
			isSynced = false;
			if (!clamp || !inputField.isFocused)
			{
				ApplyValue();
				return;
			}
			lastModificationTime = Time.unscaledTime;
			if (saveLaterCoroutine == null)
			{
				saveLaterCoroutine = StartCoroutine(SaveLater());
			}
		}

		private IEnumerator SaveLater()
		{
			while (lastModificationTime + 0.4f > Time.unscaledTime)
			{
				yield return null;
			}
			ApplyValue();
			saveLaterCoroutine = null;
		}

		private void ApplyValue()
		{
			int.TryParse(inputField.text, out var result);
			int newValue = (clamp ? Mathf.Clamp(result, clampRange.x, clampRange.y) : result);
			string text = newValue.ToString();
			if (text != inputField.text)
			{
				inputField.SetTextWithoutNotify(text);
			}
			isSynced = true;
			UpdateAndFireEvent(newValue);
		}

		protected override void OnResetOrApplied()
		{
			if (base.gameObject.activeSelf)
			{
				StopSaveLaterCoro();
				inputField.text = GetLatestValueFromProvider().ToString();
				isSynced = true;
				base.OnResetOrApplied();
			}
		}

		private void StopSaveLaterCoro()
		{
			if (saveLaterCoroutine != null)
			{
				StopCoroutine(saveLaterCoroutine);
				saveLaterCoroutine = null;
			}
		}
	}
}
