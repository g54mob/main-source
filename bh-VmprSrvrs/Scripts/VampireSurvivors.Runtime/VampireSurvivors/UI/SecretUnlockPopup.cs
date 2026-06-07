using System;
using System.Collections.Generic;
using I2.Loc;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VampireSurvivors.Data;
using Zenject;

namespace VampireSurvivors.UI
{
	public class SecretUnlockPopup : MonoBehaviour
	{
		[SerializeField]
		private Localize _SecretUnlock;

		[SerializeField]
		private Image _Icon;

		[SerializeField]
		private RectTransform _Panel;

		[SerializeField]
		private TextMeshProUGUI _PageCount;

		[SerializeField]
		private GameObject _UnlocksCircle;

		[SerializeField]
		private TextMeshProUGUI _UnlockText;

		[SerializeField]
		private CanvasGroup _CircleGroup;

		private List<SecretUnlockInfo> _secretsToShow;

		private int _currentSecretIndex;

		private DataManager _dataManager;

		private Dictionary<SecretType, SecretData> _secrets;

		private Action _onComplete;

		[Inject]
		private void Construct(DataManager data)
		{
		}

		public void SetSecrets(List<SecretUnlockInfo> unlocks, Action onComplete)
		{
		}

		private void StartShowLoop()
		{
		}
	}
}
