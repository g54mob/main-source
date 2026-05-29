using System.Collections.Generic;
using TMPro;
using UI.InitParam;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UI
{
	public class ChoiceMenuCtrl : MonoBehaviour
	{
		public ScrollRect scrollArea;

		public RectTransform content;

		public TMP_Text choiceTitle;

		public TMP_Text choiceDesc;

		[Header("デバッグ用")]
		public ChoiceMenuButton prefab;

		private bool _initialized;

		private List<ChoiceMenuButtonBase> _choiceButtons;

		private UnityAction<int> _cb;

		private ChoiceMenuButtonBase CreateChild(ChoiceMenuButtonBase prefab)
		{
			return null;
		}

		private void Start()
		{
		}

		public void InitComponet(string titleText, string descText, (string title, string desc)[] items, UnityAction<int> cb, ChoiceMenuButtonBase buttonPrefab = null)
		{
		}

		public void InitComponet(ChoiceMenuInit init)
		{
		}

		private void OnClickAction(ChoiceMenuButtonBase choiceMenuButtonBase)
		{
		}
	}
}
