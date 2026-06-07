using System.Collections;
using System.Collections.Generic;
using CTS.Core;
using UnityEngine;
using UnityEngine.UI;

namespace CTS
{
	public class UI_SandboxList : CTSBehaviour, IRepaint
	{
		[SerializeField]
		private UI_SandboxToggle _togglePrefab;

		[SerializeField]
		[Inject(false)]
		private ToggleGroup _toggleGroup;

		[SerializeField]
		private int _toggleCount;

		[SerializeField]
		private Transform _toggleContainer;

		private readonly List<UI_SandboxToggle> _toggles = new List<UI_SandboxToggle>();

		protected override void OnEnabled()
		{
			base.OnEnabled();
		}

		private void Start()
		{
			Repaint();
		}

		public void Repaint()
		{
			while (_toggles.Count < _toggleCount)
			{
				UI_SandboxToggle uI_SandboxToggle = CTSFactory.Instantiate(_togglePrefab, _toggleContainer, instantiateInWorldSpace: false, true);
				uI_SandboxToggle.ProfileName = _toggles.Count.ToString("D3");
				uI_SandboxToggle.Group = _toggleGroup;
				_toggles.Add(uI_SandboxToggle);
			}
			StopAllCoroutines();
			StartCoroutine(LoadToggles());
		}

		private IEnumerator LoadToggles()
		{
			foreach (UI_SandboxToggle toggle in _toggles)
			{
				toggle.SetLoading();
			}
			foreach (UI_SandboxToggle toggle2 in _toggles)
			{
				toggle2.Load();
				yield return null;
			}
		}
	}
}
