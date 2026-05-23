using Libs;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
	public class ExpCtrl : SingletonMonoBehaviour<ExpCtrl>
	{
		[SerializeField]
		private Image expBar;

		[SerializeField]
		private TMP_Text levelText;

		[SerializeField]
		private TMP_Text expText;

		private void Awake()
		{
		}

		public void Init()
		{
		}

		public void UpdateExpView(int level, int value, bool isMaxLevel, int? nextExp)
		{
		}
	}
}
