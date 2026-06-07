using System.Collections;
using CTS.Core;
using CTS.UI;
using CTS.Utilities;
using TMPro;
using UnityEngine;

namespace CTS
{
	public class UISaveTooltip : CTSBehaviour
	{
		[SerializeField]
		private float _disappearDuration = 3f;

		[SerializeField]
		private int _autoSaveSeconds = 5;

		[Header("References")]
		[SerializeField]
		private TMP_Text _autoSaveCounter;

		[SerializeField]
		[Inject(false)]
		private ObjectToggleByKey _visualToggle;

		[SerializeField]
		[Inject(false)]
		private CanvasGroupController _canvasGroup;

		[InjectScope(EGetScope.Singleton)]
		[SerializeField]
		[Inject(false)]
		private AutoSave _autoSave;

		private static readonly StringKey _toggleKeyAutoSave = "Autosave";

		private static readonly StringKey _toggleKeySaving = "Saving";

		private static readonly StringKey _toggleKeySaved = "Saved";

		private Coroutine _disappearRoutine;

		protected override void OnAwake()
		{
			base.OnAwake();
			if (_autoSave == null)
			{
				base.enabled = false;
			}
		}

		protected override void OnEnabled()
		{
			base.OnEnabled();
			ProfileManager.Saving += OnSaving;
			ProfileManager.Saved += OnSaved;
		}

		protected override void OnDisabled()
		{
			base.OnDisabled();
			ProfileManager.Saving -= OnSaving;
			ProfileManager.Saved -= OnSaved;
			StopDisappearRoutine();
		}

		private void Update()
		{
			if (_disappearRoutine != null)
			{
				return;
			}
			float num = 0f - (Time.unscaledTime - _autoSave.NextAutoSave);
			CanvasGroupController.CanvasGroupState state;
			if (num > (float)_autoSaveSeconds)
			{
				if (_visualToggle.LastDisplayedMode == _toggleKeyAutoSave)
				{
					state = _canvasGroup.State;
					if (state == CanvasGroupController.CanvasGroupState.Showing || state == CanvasGroupController.CanvasGroupState.Shown)
					{
						_canvasGroup.QuickHide();
					}
				}
				return;
			}
			state = _canvasGroup.State;
			if (state == CanvasGroupController.CanvasGroupState.Hidden || state == CanvasGroupController.CanvasGroupState.Hidding)
			{
				ShowCanvas(_toggleKeyAutoSave);
			}
			else if (_visualToggle.LastDisplayedMode != _toggleKeyAutoSave)
			{
				ShowCanvas(_toggleKeyAutoSave);
			}
			_autoSaveCounter.text = Mathf.CeilToInt(num).ToString();
		}

		private void OnSaving()
		{
			ShowCanvas(_toggleKeySaving);
		}

		private void OnSaved()
		{
			ShowCanvas(_toggleKeySaved);
			_disappearRoutine = StartCoroutine(DisappearRoutine());
		}

		private void ShowCanvas(StringKey key)
		{
			_canvasGroup.QuickShow();
			StopDisappearRoutine();
			_visualToggle.Swap(key);
		}

		private void StopDisappearRoutine()
		{
			if (_disappearRoutine != null)
			{
				StopCoroutine(_disappearRoutine);
				_disappearRoutine = null;
			}
		}

		private IEnumerator DisappearRoutine()
		{
			yield return Coroutines.WaitForSecondsRealtime(_disappearDuration);
			_canvasGroup.QuickHide();
			_disappearRoutine = null;
		}
	}
}
