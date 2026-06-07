using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using I2.Loc;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Simulator
{
	public class InputHint : MonoBehaviour
	{
		[Serializable]
		public struct Data
		{
			public InputActionReference inputActionReference;

			[SerializeField]
			[TermsPopup("")]
			private string m_localizedDisplayText;

			[NonSerialized]
			public object formatArgs;

			public string DisplayText
			{
				get
				{
					if (string.IsNullOrWhiteSpace(m_localizedDisplayText))
					{
						return "No localized text";
					}
					string termTranslation = LocalizationManager.GetTermTranslation(m_localizedDisplayText);
					if (formatArgs == null)
					{
						return termTranslation;
					}
					try
					{
						return string.Format(termTranslation, formatArgs);
					}
					catch (Exception message)
					{
						Debug.LogError(message);
						return termTranslation;
					}
				}
			}
		}

		public struct DisplayData
		{
			private readonly InputsUISettings.Container[] m_inputContainers;

			public string ActionText { get; private set; }

			public ReadOnlyCollection<InputsUISettings.Container> InputContainers => new ReadOnlyCollection<InputsUISettings.Container>(m_inputContainers);

			public DisplayData(string actionText, InputsUISettings.Container[] inputContainers)
			{
				m_inputContainers = inputContainers;
				ActionText = actionText;
			}
		}

		[SerializeField]
		private Data[] m_datas;

		public DisplayData[] DisplayDatas { get; private set; }

		public IReadOnlyList<Data> Datas => m_datas;

		public static event Action<InputHint> OnEnableEvent;

		public static event Action<InputHint> OnDisableEvent;

		public static event Action<InputHint> OnRefreshEvent;

		private void Awake()
		{
			base.enabled = false;
		}

		private void OnEnable()
		{
			Refresh();
			InputHint.OnEnableEvent?.Invoke(this);
		}

		private void OnDisable()
		{
			Cleanup();
		}

		private DisplayData[] GenerateAllDisplayData()
		{
			Data[] datas = GetDatas();
			DisplayData[] array = new DisplayData[datas.Length];
			for (int i = 0; i < datas.Length; i++)
			{
				array[i] = GenerateDisplayData(datas[i]);
			}
			return array;
		}

		private DisplayData GenerateDisplayData(Data data)
		{
			InputsUISettings.Container[] settingsAll = data.inputActionReference.action.GetSettingsAll();
			return new DisplayData(data.DisplayText, settingsAll);
		}

		public virtual Data[] GetDatas()
		{
			return m_datas;
		}

		public void SetDatas(Data[] datas)
		{
			m_datas = datas;
		}

		public void Refresh()
		{
			DisplayDatas = GenerateAllDisplayData();
			if (base.enabled)
			{
				InputHint.OnRefreshEvent?.Invoke(this);
			}
		}

		private void Cleanup()
		{
			DisplayDatas = null;
			InputHint.OnDisableEvent?.Invoke(this);
		}
	}
}
