using System;
using NSMedieval.BuildingComponents;
using NSMedieval.State;
using NSMedieval.UI.Utils;
using NSMedieval.Utils.Pool;
using NSMedieval.Utils.Pool.Janitors;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace NSMedieval.UI
{
	public class RallyPointListEntry : MonoBehaviour
	{
		[SerializeField]
		private Image image;

		[SerializeField]
		private Image backgroundImage;

		[SerializeField]
		private Button toggleButton;

		[SerializeField]
		private Graphic toggleGraphicCheckmark;

		[SerializeField]
		private TMP_Text text;

		[SerializeField]
		private ResourceIconItemView weaponIcon;

		[SerializeField]
		private TooltipViewNew workerNameTooltip;

		[NonSerialized]
		private HumanoidInstance worker;

		[NonSerialized]
		private RallyPointMarkerComponentInstance rallyPoint;

		private bool listenerInitialized;

		public Button Toggle => toggleButton;

		public void Init(HumanoidInstance worker, RallyPointMarkerComponentInstance rallyPoint)
		{
			this.rallyPoint = rallyPoint;
			this.worker = worker;
			Refresh();
		}

		public void Refresh()
		{
			if (worker != null && !worker.HasDied && !worker.HasDisposed)
			{
				text.SetText(worker.GetFullName());
				if (worker.HasWeapon())
				{
					weaponIcon.gameObject.SetActive(value: true);
					weaponIcon.SetData(worker.GetWeapon(), worker);
				}
				else
				{
					weaponIcon.gameObject.SetActive(value: false);
				}
				Color color = ((!CanWorkerBeDrafted()) ? Color.Lerp(Color.white, Color.clear, 0.5f) : Color.white);
				text.color = color;
				CheckInitListener();
				RefreshCheckbox();
				UpdateTooltip();
			}
		}

		private bool CanWorkerBeDrafted()
		{
			if (!worker.HasDiedOrFainted && !worker.IsInIncognitoMode())
			{
				return !worker.WorkerBehaviour.IsCrazy;
			}
			return false;
		}

		private void UpdateTooltip()
		{
			using PooledList<string> pooledList = ListPool<string>.GetJanitor(16);
			if (!CanWorkerBeDrafted())
			{
				pooledList.Add(CreatureBaseUtils.GetLocalizedCurrentActionInfo(worker));
				pooledList.Add(" ");
			}
			pooledList.Add("rally_point_already_in".ToLocalized());
			foreach (RallyPointMarkerComponentInstance workerRallyPoint in rallyPoint.Map.RallyPointMarkerComponentManager.GetWorkerRallyPoints(worker))
			{
				pooledList.Add(workerRallyPoint.Name);
			}
			if (pooledList.Count == 1)
			{
				pooledList.Add("general_none".ToLocalized());
			}
			workerNameTooltip.SetLines(pooledList);
		}

		private void OnDestroy()
		{
			rallyPoint = null;
			worker = null;
		}

		private void CheckInitListener()
		{
			if (listenerInitialized)
			{
				return;
			}
			listenerInitialized = true;
			toggleButton.onClick.AddListener(delegate
			{
				if (rallyPoint.IsWorkerSet(worker))
				{
					rallyPoint.RemoveWorker(worker);
				}
				else
				{
					rallyPoint.AssignWorker(worker);
				}
				RefreshCheckbox();
			});
		}

		private void RefreshCheckbox()
		{
			bool active = rallyPoint.IsWorkerSet(worker);
			toggleGraphicCheckmark.gameObject.SetActive(active);
		}
	}
}
