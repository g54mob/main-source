using System;
using System.Collections;
using NSEipix.Base;
using NSEipix.View.UI;
using NSMedieval.Heraldry;
using NSMedieval.Tutorial;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace NSMedieval.UI
{
	public class MainSceneHeraldry : UIView
	{
		[Header("Heraldry")]
		[SerializeField]
		private TMP_Text heraldryLabel;

		[SerializeField]
		private HeraldryEditorView heraldryEditorView;

		[SerializeField]
		private HeraldryCamera patternCam;

		[SerializeField]
		private HeraldryCamera crestCam;

		[SerializeField]
		private Image heraldryCrest;

		[SerializeField]
		private Image heraldryPattern;

		[SerializeField]
		private SoundButton heraldryEditButton;

		[SerializeField]
		private SoundButton heraldryRandomizeButton;

		[NonSerialized]
		private bool refreshOnEnable;

		public override void Show()
		{
			MonoSingleton<UIClosableController>.Instance.CloseAll();
			base.Show();
		}

		private void Start()
		{
			heraldryLabel.SetText(GlobalSaveController.CurrentVillageData.Name);
			heraldryEditButton.onClick.AddListener(OnClickHeraldryEdit);
			heraldryRandomizeButton.onClick.AddListener(OnClickHeraldryRandomize);
			heraldryEditButton.gameObject.SetActive(!TutorialManager.IsTutorialActive);
			heraldryRandomizeButton.gameObject.SetActive(!TutorialManager.IsTutorialActive);
			crestCam = MonoSingleton<HeraldryManager>.Instance.CrestCam;
			patternCam = MonoSingleton<HeraldryManager>.Instance.PatternCam;
			heraldryEditorView.DoneButton.onClick.RemoveAllListeners();
			heraldryEditorView.DoneButton.onClick.AddListener(OnEditDoneClick);
			heraldryEditorView.SubFromMainSceneHeraldry();
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();
			heraldryEditButton.onClick.RemoveAllListeners();
			heraldryRandomizeButton.onClick.RemoveAllListeners();
			heraldryEditorView.DoneButton.onClick.RemoveAllListeners();
		}

		private void OnHeraldryChanged()
		{
			heraldryCrest.sprite = MonoSingleton<HeraldryManager>.Instance.Crest.sprite;
			heraldryPattern.sprite = MonoSingleton<HeraldryManager>.Instance.Pattern.sprite;
		}

		private void OnEditDoneClick()
		{
			heraldryEditorView.ContentHolder.SetActive(value: false);
			GlobalSaveController.CurrentVillageData.CopyHeraldryToSave();
			if (MonoSingleton<UIController>.IsInstantiated() && MonoSingleton<UIController>.Instance.InGameMenu != null)
			{
				MonoSingleton<UIController>.Instance.InGameMenu.SceneUIManager.ShowNewView("InGameMenuView");
			}
			StartCoroutine(WaitForLoadToFinish());
		}

		private void OnClickHeraldryRandomize()
		{
			heraldryEditorView.LoadRandomPreset();
			StartCoroutine(WaitForLoadToFinish());
		}

		private IEnumerator WaitForLoadToFinish()
		{
			yield return new WaitForEndOfFrame();
			crestCam.TakeSs();
			patternCam.TakeSs();
			StartCoroutine(UpdateHeraldry());
		}

		private void OnEnable()
		{
			MonoSingleton<HeraldryManager>.Instance.HeraldryChangedEvent += OnHeraldryChanged;
			if (refreshOnEnable)
			{
				MonoSingleton<HeraldryManager>.Instance.UpdateHeraldry();
				refreshOnEnable = false;
			}
			OnHeraldryChanged();
		}

		private void OnDisable()
		{
			if (MonoSingleton<HeraldryManager>.IsInstantiated())
			{
				MonoSingleton<HeraldryManager>.Instance.HeraldryChangedEvent -= OnHeraldryChanged;
			}
		}

		private void OnClickHeraldryEdit()
		{
			refreshOnEnable = true;
			heraldryEditorView.ContentHolder.SetActive(value: true);
			heraldryEditorView.LoadLastUserHeraldry();
		}

		private IEnumerator UpdateHeraldry()
		{
			yield return new WaitForEndOfFrame();
			MonoSingleton<HeraldryManager>.Instance.UpdateHeraldry(setWrapModeFromHeraldryEditor: true);
		}
	}
}
