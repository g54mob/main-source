using System;
using NSEipix.Base;
using NSEipix.View.UI;
using NSMedieval.UI;
using UnityEngine;

namespace NSMedieval.Modding
{
	public class EulaManager : MonoSingleton<EulaManager>
	{
		private const int CurrentEulaVersion = 1;

		[SerializeField]
		private GameObject[] panels;

		[SerializeField]
		private SoundButton acceptButton;

		[SerializeField]
		private SoundButton doNotAcceptButton;

		public bool EulaAccepted => MonoSingleton<GlobalSaveController>.Instance.GlobalSettings.EulaVersionAccepted == 1;

		public event Action<bool> EulaStatusChangeEvent;

		private void Start()
		{
			GameObject[] array = panels;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].SetActive(value: false);
			}
			if (!EulaAccepted)
			{
				acceptButton.onClick.AddListener(OnAccepted);
				doNotAcceptButton.onClick.AddListener(OnNotAccepted);
			}
		}

		public void ShowPrompt()
		{
			GameObject[] array = panels;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].SetActive(value: true);
			}
		}

		private void OnAccepted()
		{
			MonoSingleton<OptionsController>.Instance.SetEulaVersion(1);
			MonoSingleton<GlobalSaveController>.Instance.Serialize();
			this.EulaStatusChangeEvent?.Invoke(obj: true);
			GameObject[] array = panels;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].SetActive(value: false);
			}
		}

		private void OnNotAccepted()
		{
			this.EulaStatusChangeEvent?.Invoke(obj: false);
			GameObject[] array = panels;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].SetActive(value: false);
			}
		}
	}
}
