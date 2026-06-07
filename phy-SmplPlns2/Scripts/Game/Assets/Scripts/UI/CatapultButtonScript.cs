using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.UI
{
	public class CatapultButtonScript : MonoBehaviour
	{
		public enum CatapultButtonMode
		{
			Hidden = 0,
			Connect = 1,
			Launch = 2
		}

		private static List<CatapultButtonScript> _catapultButtons = new List<CatapultButtonScript>();

		private static CatapultButtonMode Mode;

		private GameObject _arrows;

		private GameObject _hook;

		private CatapultButtonMode _mode;

		public static Action OnCatapultButtonClicked { get; set; }

		public static void SetCurrentMode(CatapultButtonMode mode)
		{
			Mode = mode;
			foreach (CatapultButtonScript catapultButton in _catapultButtons)
			{
				catapultButton.SetMode(mode);
			}
		}

		public void OnClicked()
		{
			OnCatapultButtonClicked?.Invoke();
		}

		protected virtual void Awake()
		{
			_catapultButtons.Add(this);
			_arrows = base.transform.Find("Arrows").gameObject;
			_hook = base.transform.Find("Hook").gameObject;
			SetMode(Mode);
		}

		protected virtual void OnDestroy()
		{
			_catapultButtons.Remove(this);
			if (_catapultButtons.Count == 0 && Mode != CatapultButtonMode.Hidden)
			{
				SetCurrentMode(CatapultButtonMode.Hidden);
			}
		}

		private void SetMode(CatapultButtonMode mode)
		{
			if (_mode != mode)
			{
				base.gameObject.SetActive(mode != CatapultButtonMode.Hidden);
				_arrows.SetActive(mode == CatapultButtonMode.Launch);
				_hook.SetActive(mode == CatapultButtonMode.Connect);
				_mode = mode;
			}
		}
	}
}
