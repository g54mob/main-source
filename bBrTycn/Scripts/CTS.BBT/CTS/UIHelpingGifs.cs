using System.Collections;
using System.Collections.Generic;
using CTS.Core;
using CTS.UI;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.UI;

namespace CTS
{
	public class UIHelpingGifs : CTSSingleton<UIHelpingGifs>
	{
		[SerializeField]
		private CanvasGroupController _canvasGroupController;

		[SerializeField]
		private UIHelpListToggle _prefab;

		[SerializeField]
		private PaletteData _clearColor;

		[SerializeField]
		private PaletteData _darkColor;

		[SerializeField]
		private HelpGifsOdrerSO _gifs;

		[SerializeField]
		private Transform _container;

		[SerializeField]
		private ToggleGroup _group;

		[SerializeField]
		private Scrollbar _scrollBar;

		[SerializeField]
		private StaticOpenHelp _openHelp;

		private UIGifsListSO[] _helpList;

		private List<UIHelpListToggle> _uIHelpListToggles = new List<UIHelpListToggle>();

		protected override void SingletonAwake()
		{
			_helpList = _gifs.HelpGifsList.ToArray();
		}

		protected override void OnSingletonDestroy()
		{
		}

		private void Start()
		{
			Populate();
			StartCoroutine(DelayScrollPosition());
		}

		private IEnumerator DelayScrollPosition()
		{
			yield return new WaitForSeconds(0.1f);
			_scrollBar.value = 1f;
		}

		public void Open()
		{
			_canvasGroupController.QuickShow();
		}

		public void Close()
		{
			_canvasGroupController.QuickHide();
		}

		private void Populate()
		{
			for (int i = 0; i < _helpList.Length; i++)
			{
				UIHelpListToggle uIHelpListToggle = Object.Instantiate(_prefab, _container);
				uIHelpListToggle.gameObject.SetActive(value: true);
				uIHelpListToggle.Init((i % 2 == 0) ? _darkColor.GetColor() : _clearColor.GetColor(), _helpList[i]);
				uIHelpListToggle.Toggle.group = _group;
				_uIHelpListToggles.Add(uIHelpListToggle);
			}
		}

		[Button(null, EButtonEnableMode.Always)]
		public void RandomHint()
		{
			_openHelp.OpenHelp();
			int index = Random.Range(0, _uIHelpListToggles.Count);
			_uIHelpListToggles[index].Toggle.isOn = true;
		}

		public void ChooseHelpList(UIGifsListSO uIGifsListSO)
		{
			foreach (UIHelpListToggle uIHelpListToggle in _uIHelpListToggles)
			{
				if (uIHelpListToggle.GifsList == uIGifsListSO)
				{
					uIHelpListToggle.Toggle.isOn = true;
					_openHelp.OpenHelp();
					break;
				}
			}
		}
	}
}
