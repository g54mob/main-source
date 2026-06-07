using System;
using Assets.Nimbatus.Scripts.Persistence;
using UnityEngine;

namespace Assets.Nimbatus.GUI.MainMenu
{
	public class LoadResolutions : MonoBehaviour
	{
		private UIPopupList _dropDownList;

		public void Start()
		{
			_dropDownList = GetComponent<UIPopupList>();
			OnLoadResolutions();
			EventDelegate.Add(_dropDownList.onChange, ResolutionChanged, false);
		}

		public void OnDisable()
		{
			EventDelegate.Remove(_dropDownList.onChange, ResolutionChanged);
		}

		private void OnLoadResolutions()
		{
			_dropDownList.items.Clear();
			Resolution[] resolutions = Screen.resolutions;
			for (int i = 0; i < resolutions.Length; i++)
			{
				Resolution resolution = resolutions[i];
				string item = resolution.width + "x" + resolution.height;
				if (!_dropDownList.items.Contains(item))
				{
					_dropDownList.items.Add(item);
				}
			}
			_dropDownList.value = RuntimeGlobals.Settings.ScreenWidth + "x" + RuntimeGlobals.Settings.ScreenHeight;
		}

		public void ResolutionChanged()
		{
			RuntimeGlobals.Settings.ScreenHeight = Convert.ToInt32(UIPopupList.current.value.Split('x')[1]);
			RuntimeGlobals.Settings.ScreenWidth = Convert.ToInt32(UIPopupList.current.value.Split('x')[0]);
		}
	}
}
