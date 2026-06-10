using System.Collections;
using System.Collections.Generic;
using System.Text;
using NSEipix;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.Controllers;
using NSMedieval.Manager;
using NSMedieval.Map;
using NSMedieval.Model.MapNew;
using NSMedieval.State;
using NSMedieval.UI.Utils;
using NSMedieval.WorldMap;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace NSMedieval.UI
{
	public class GameStartSummaryView : GameStartView
	{
		private const int InfoIndent = 1;

		[Header("Summary")]
		[SerializeField]
		private TMP_Text villageNameTitle;

		[SerializeField]
		private LayoutGroupView workersGroup;

		[SerializeField]
		private TMP_Text scenarioDetails;

		[SerializeField]
		private Image scenarioImage;

		[FormerlySerializedAs("worldDetails")]
		[SerializeField]
		private TMP_Text locationDetails;

		[SerializeField]
		private Toggle tutorialToggle;

		private readonly List<BasicLayoutItemView> workerViews = new List<BasicLayoutItemView>();

		private void Start()
		{
			tutorialToggle.onValueChanged.AddListener(delegate(bool isOn)
			{
				OnTutorialToggle(isOn);
			});
		}

		private void OnTutorialToggle(bool isOn)
		{
			base.StartController.ShowTutorial = isOn;
		}

		protected override void OnClickNext()
		{
			base.StartController.ShowTutorial = tutorialToggle.isOn;
			MonoSingleton<LoadingOverlayController>.Instance.ShowOverlay(show: true);
			StartCoroutine(EmbarkClickedCoroutine());
		}

		private IEnumerator EmbarkClickedCoroutine()
		{
			if (MonoSingleton<TravelManager>.IsInstantiated())
			{
				MonoSingleton<TravelManager>.Instance.JustLeftSecondMap = false;
			}
			yield return new WaitForEndOfFrame();
			yield return new WaitForSecondsRealtime(0.3f);
			while (!MonoSingleton<MapGenerationController>.IsInstantiated() || !MonoSingleton<MapGenerationController>.Instance.IsMapGenerationFinished)
			{
				yield return new WaitForEndOfFrame();
			}
			if (!MonoSingleton<MapGenerationController>.Instance.IsMapGenerationSuccessful)
			{
				MonoSingleton<LoadingOverlayController>.Instance.ShowOverlay(show: false);
				yield break;
			}
			MonoSingleton<WorldMapController>.Instance.FinalizeWorldMapSettings();
			if (base.StartController.StartGame())
			{
				Hide();
				MonoSingleton<CharacterEditController>.Instance.OnGameStart();
			}
			else
			{
				MonoSingleton<LoadingOverlayController>.Instance.ShowOverlay(show: false);
			}
		}

		public override void Show()
		{
			base.Show();
			SetVillage();
			SetScenarioDetails();
			SetLocationDetails();
			base.StartController.ShowTutorial = MonoSingleton<GlobalSaveController>.Instance.GlobalSettings.ShowTutorial;
			tutorialToggle.isOn = base.StartController.ShowTutorial;
		}

		private void SetVillage()
		{
			villageNameTitle.text = "<style=AltColorParagraphTitle>" + base.StartController.SelectedVillageName + "</style>";
			workerViews.SetAllActive(active: false);
			foreach (HumanoidInstance worker in base.StartController.Workers)
			{
				BasicLayoutItemView next = workerViews.GetNext(workersGroup);
				next.Icon.sprite = MonoSingleton<HumanoidIconManager>.Instance.GetCachedIcon(worker);
				next.SetWorkerTooltip(worker.Info.FirstName, worker);
			}
		}

		private void SetScenarioDetails()
		{
			scenarioImage.sprite = AssetUtils.GetSprite(base.StartController.SelectedScenario.ImageId);
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendLine("<style=AltColorParagraphTitle>" + base.Localize.GetText(LocKeyUtils.GetName(base.StartController.SelectedScenario.LocKeys)) + "</style>");
			stringBuilder.AppendLine();
			stringBuilder.AppendLine($"<indent={1}%>{base.Localize.GetText(LocKeyUtils.GetInfo(base.StartController.SelectedScenario.LocKeys))}</indent>");
			scenarioDetails.text = stringBuilder.ToString();
		}

		private void SetLocationDetails()
		{
			NSMedieval.Model.MapNew.Map byID = Repository<MapRepository, NSMedieval.Model.MapNew.Map>.Instance.GetByID(base.StartController.SelectedMapType);
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendLine("<style=AltColorParagraphTitle>" + base.Localize.GetText(LocKeyUtils.GetName(byID.LocKeys)) + "</style>");
			stringBuilder.AppendLine();
			stringBuilder.AppendLine($"<indent={1}%>{base.Localize.GetText(LocKeyUtils.GetInfo(byID.LocKeys))}</indent>");
			locationDetails.text = stringBuilder.ToString();
		}
	}
}
