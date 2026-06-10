using System.Collections.Generic;
using NSEipix;
using NSEipix.Base;
using NSEipix.View.UI;
using UnityEngine;

namespace NSMedieval.UI
{
	public class SpawnPointEditorView : ClosableUIView
	{
		[SerializeField]
		private SoundButton saveButton;

		[SerializeField]
		private SoundButton addButton;

		[SerializeField]
		private SoundButton deleteButton;

		[SerializeField]
		private SoundButton deleteAllButton;

		[SerializeField]
		private LayoutGroupView groupsParent;

		[SerializeField]
		private SoundButton closeButton;

		[SerializeField]
		private GameObject spawnPointPrefab;

		private List<SpawnPointItemView> spawnPointViews;

		public void ShowView()
		{
			MonoSingleton<SpawnPointManager>.Instance.SetActive(isActive: true);
			Show();
		}

		public void HideView()
		{
			MonoSingleton<SpawnPointManager>.Instance.SetActive(isActive: false);
			Hide();
		}

		private void Start()
		{
			spawnPointViews = new List<SpawnPointItemView>();
			saveButton.onClick.AddListener(OnSaveClick);
			addButton.onClick.AddListener(OnAddClick);
			deleteButton.onClick.AddListener(OnDeleteClick);
			deleteAllButton.onClick.AddListener(OnDeleteAllClick);
			closeButton.onClick.AddListener(OnCloseClick);
			MonoSingleton<SpawnPointManager>.Instance.OnPointsUpdated += RefreshList;
			RefreshList();
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();
			if (MonoSingleton<SpawnPointManager>.IsInstantiated())
			{
				MonoSingleton<SpawnPointManager>.Instance.OnPointsUpdated -= RefreshList;
			}
			spawnPointViews = null;
		}

		private void OnSaveClick()
		{
			HideView();
			MonoSingleton<UIController>.Instance.LeftPanelView.SceneUIManager.ShowNewView("TravelDebugView");
		}

		private void OnAddClick()
		{
			MonoSingleton<SpawnPointManager>.Instance.AddNewPoint();
		}

		private void OnDeleteClick()
		{
			MonoSingleton<SpawnPointManager>.Instance.DeleteSpawnPoint();
		}

		private void OnDeleteAllClick()
		{
			MonoSingleton<SpawnPointManager>.Instance.DeleteAllSpawnPoints();
		}

		private void OnCloseClick()
		{
			HideView();
			MonoSingleton<UIController>.Instance.LeftPanelView.SceneUIManager.ShowNewView("TravelDebugView");
		}

		private void RefreshList()
		{
			foreach (SpawnPointItemView spawnPointView in spawnPointViews)
			{
				spawnPointView.gameObject.SetActive(value: false);
			}
			int num = 0;
			SpawnPoint selectedSpawnPoint = MonoSingleton<SpawnPointManager>.Instance.SelectedSpawnPoint;
			foreach (SpawnPoint spawnPoint in MonoSingleton<SpawnPointManager>.Instance.SpawnPoints)
			{
				SpawnPointItemView spawnPointItemView;
				if (num >= spawnPointViews.Count)
				{
					spawnPointItemView = Object.Instantiate(spawnPointPrefab, groupsParent.transform).GetComponent<SpawnPointItemView>();
					spawnPointViews.Add(spawnPointItemView);
				}
				else
				{
					spawnPointItemView = spawnPointViews[num];
				}
				spawnPointItemView.gameObject.SetActive(value: true);
				spawnPointItemView.Setup(spawnPoint, OnPointSelected, OnPointTypeChanged);
				spawnPointItemView.SetSelected(spawnPoint == selectedSpawnPoint);
				num++;
			}
		}

		private void OnPointTypeChanged(SpawnPoint spawnPoint)
		{
			MonoSingleton<SpawnPointManager>.Instance.OnSpawnPointTypeChange(spawnPoint);
		}

		private void OnPointSelected(SpawnPoint spawnPoint)
		{
			MonoSingleton<SpawnPointManager>.Instance.OnSelectSpawnPoint(spawnPoint);
			MonoSingleton<RtsCamera>.Instance.JumpTo(spawnPoint.Position.ToVector3World());
			RefreshList();
		}
	}
}
