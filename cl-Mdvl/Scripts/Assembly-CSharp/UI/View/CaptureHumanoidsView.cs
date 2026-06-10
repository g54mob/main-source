using System;
using System.Collections.Generic;
using NSEipix;
using NSEipix.Base;
using NSEipix.View.UI;
using NSMedieval.Controllers;
using NSMedieval.Manager;
using NSMedieval.State;
using NSMedieval.Tools;
using NSMedieval.UI;
using NSMedieval.Utils.Pool;
using NSMedieval.Utils.Pool.Janitors;
using UnityEngine;

namespace UI.View
{
	public class CaptureHumanoidsView : PopupView
	{
		[SerializeField]
		private LayoutGroupView humanoidsGroup;

		[SerializeField]
		private SoundButton acceptButton;

		[NonSerialized]
		private List<CaravanWorkerEntry> prisonerUIEntries;

		[NonSerialized]
		private List<HumanoidInstance> possiblePrisoners;

		[NonSerialized]
		private List<HumanoidInstance> forbiddenPrisoners;

		[NonSerialized]
		private HashSet<HumanoidInstance> selectedPrisoners;

		private void OnEnable()
		{
			if (prisonerUIEntries == null)
			{
				prisonerUIEntries = new List<CaravanWorkerEntry>();
			}
			if (selectedPrisoners == null)
			{
				selectedPrisoners = new HashSet<HumanoidInstance>();
			}
		}

		public void OpenPanel(IEnumerable<HumanoidInstance> possiblePrisoners, IEnumerable<HumanoidInstance> forbiddenPrisoners)
		{
			if (!IsShowing())
			{
				if (this.possiblePrisoners == null)
				{
					this.possiblePrisoners = new List<HumanoidInstance>();
				}
				if (this.forbiddenPrisoners == null)
				{
					this.forbiddenPrisoners = new List<HumanoidInstance>();
				}
				this.possiblePrisoners.Clear();
				this.possiblePrisoners.AddRange(possiblePrisoners);
				this.forbiddenPrisoners.Clear();
				this.forbiddenPrisoners.AddRange(forbiddenPrisoners);
				Show();
			}
		}

		protected override void OnShow()
		{
			possiblePrisoners.Sort((HumanoidInstance humanA, HumanoidInstance humanB) => string.Compare(humanA.Info.GetFullName(), humanB.Info.GetFullName(), StringComparison.CurrentCulture));
			forbiddenPrisoners.Sort((HumanoidInstance humanA, HumanoidInstance humanB) => string.Compare(humanA.Info.GetFullName(), humanB.Info.GetFullName(), StringComparison.CurrentCulture));
			using PooledList<HumanoidInstance> pooledList = ListPool<HumanoidInstance>.GetJanitor();
			pooledList.AddRange(possiblePrisoners);
			pooledList.AddRangeUnique(forbiddenPrisoners);
			int num = 0;
			foreach (HumanoidInstance item in pooledList)
			{
				CaravanWorkerEntry at = prisonerUIEntries.GetAt(humanoidsGroup, num);
				num++;
				at.gameObject.SetActive(value: true);
				at.SetData(item, OnPrisonerSelectToggle);
				bool flag = possiblePrisoners.Contains(item);
				at.SetClickable(flag, flag, string.Empty, string.Empty);
				at.SetText(flag ? string.Empty : GetRandomEnemyWontSurrenderMessage(item));
			}
			prisonerUIEntries.SetActiveFromIndex(num, active: false);
		}

		private static string GetRandomEnemyWontSurrenderMessage(HumanoidInstance humanoidInstance)
		{
			int num = UnityEngine.Random.Range(1, 7);
			string key = $"enemy_wont_surrender_{num:00}";
			return TextFormatting.FormatText(MonoSingleton<LocalizationController>.Instance.GetText(key), humanoidInstance);
		}

		private void OnPrisonerSelectToggle(bool selected, HumanoidInstance prisoner)
		{
			if (selected)
			{
				selectedPrisoners.Add(prisoner);
			}
			else
			{
				selectedPrisoners.Remove(prisoner);
			}
		}

		private void OnDestroy()
		{
			selectedPrisoners.Clear();
			possiblePrisoners.Clear();
			forbiddenPrisoners.Clear();
			foreach (CaravanWorkerEntry prisonerUIEntry in prisonerUIEntries)
			{
				UnityEngine.Object.DestroyImmediate(prisonerUIEntry);
			}
			prisonerUIEntries.Clear();
		}

		private void Start()
		{
			acceptButton.onClick.RemoveAllListeners();
			acceptButton.onClick.AddListener(OnAcceptButtonClicked);
		}

		private void OnAcceptButtonClicked()
		{
			Hide();
			MonoSingleton<CaptiveNpcManager>.Instance.SetAsPrisoners(selectedPrisoners);
			selectedPrisoners.Clear();
		}
	}
}
