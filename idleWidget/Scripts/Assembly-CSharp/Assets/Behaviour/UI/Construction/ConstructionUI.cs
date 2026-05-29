using System.Collections.Generic;
using Assets.Source.Player;
using Assets.Source.World;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Behaviour.UI.Construction
{
	public class ConstructionUI : MonoBehaviour
	{
		public static TechNode ConstructionOverviewTech = "t3u_construction_progress";

		public static TechNode ConstructionPauseTech = "t3u_construction_pause";

		public static TechNode ConstructionCancelTech = "t3u_construction_cancelall";

		[SerializeField]
		private ScrollRect _scroll;

		[SerializeField]
		private UIConstructionRow _rowPrefab;

		[SerializeField]
		private RectTransform _rowParent;

		[SerializeField]
		private Button _cancelAllButton;

		[SerializeField]
		private Button _pauseButton;

		[SerializeField]
		private RectTransform _pauseBorder;

		[SerializeField]
		private RectTransform _noConstructionMessage;

		private List<UIConstructionRow> _rows = new List<UIConstructionRow>();

		private bool _cancelAllActive;

		private int _lastUpdatedRow;

		private Queue<ConstructionProgress> _toLoadConstruction;

		private float _toLoadY;

		public static ConstructionUI Instance { get; private set; }

		private void Update()
		{
			float y = PlayerControls.TraversalDelta.y;
			if (y != 0f)
			{
				_scroll.verticalNormalizedPosition += y * Time.deltaTime * 2000f / _rowParent.sizeDelta.y;
			}
			if (_toLoadConstruction != null)
			{
				int num = 0;
				while (num < 100 && _toLoadConstruction.Count > 0)
				{
					ConstructionProgress constructionProgress = _toLoadConstruction.Dequeue();
					if (constructionProgress.Progress < 1f)
					{
						_toLoadY = _addConstructionRow(constructionProgress, _toLoadY);
						num++;
					}
				}
				_rowParent.sizeDelta = new Vector2(_rowParent.sizeDelta.x, _toLoadY + 10f);
				if (_toLoadConstruction.Count == 0)
				{
					_toLoadConstruction = null;
				}
			}
			if (_rows.Count > 0)
			{
				for (int i = 0; i < 10; i++)
				{
					if (_lastUpdatedRow >= _rows.Count)
					{
						_lastUpdatedRow = 0;
					}
					_rows[_lastUpdatedRow].UpdateLabel();
					_lastUpdatedRow++;
				}
			}
			_noConstructionMessage.gameObject.SetActive(_rows.Count == 0);
		}

		private void OnEnable()
		{
			Instance = this;
			RefreshContent();
		}

		private void OnDisable()
		{
			if (Instance == this)
			{
				Instance = null;
			}
		}

		public void RefreshContent()
		{
			_rowParent.DestroyChildren();
			_rows.Clear();
			_toLoadConstruction = new Queue<ConstructionProgress>(GamePlayer.Current.Construction);
			_toLoadY = 0f;
			_pauseBorder.gameObject.SetActive(GamePlayer.Current.ConstructionPaused);
			UpdateButtonAvailability();
		}

		public void PrioritizeConstruction(UIConstructionRow row)
		{
			int num = _rows.IndexOf(row);
			if (num >= 0)
			{
				_rows.RemoveAt(num);
				_rows.Insert(0, row);
				((RectTransform)row.transform).anchoredPosition = new Vector2(0f, 0f);
				for (int i = 1; i <= num; i++)
				{
					((RectTransform)_rows[i].transform).anchoredPosition = new Vector2(0f, i * -100);
				}
			}
		}

		private float _addConstructionRow(ConstructionProgress row, float startY)
		{
			UIConstructionRow uIConstructionRow = Object.Instantiate(_rowPrefab, _rowParent);
			uIConstructionRow.SetConstruction(row);
			_rows.Add(uIConstructionRow);
			((RectTransform)uIConstructionRow.transform).anchoredPosition = new Vector2(0f, 0f - startY);
			return startY + 100f;
		}

		public void Toggle()
		{
			if (!GamePlayer.Current.HasTech(ConstructionOverviewTech))
			{
				return;
			}
			UISounds.TurnPage();
			base.gameObject.SetActive(!base.gameObject.activeSelf);
			if (base.gameObject.activeSelf)
			{
				GameUI.Inventory.gameObject.SetActive(value: false);
				if (OverviewUI.Instance.FullScreenActive)
				{
					OverviewUI.Instance.ToggleBuildMenu(show: false);
				}
			}
		}

		public bool Hide()
		{
			if (base.gameObject.activeSelf)
			{
				Toggle();
				return true;
			}
			return false;
		}

		public void TogglePause()
		{
			UISounds.CraftFinished();
			GamePlayer.Current.ConstructionPaused = !GamePlayer.Current.ConstructionPaused;
			TooltipSource component = _pauseButton.GetComponent<TooltipSource>();
			Image component2 = _pauseButton.transform.GetChild(0).GetComponent<Image>();
			if (GamePlayer.Current.ConstructionPaused)
			{
				component2.sprite = SpriteLibrary.Get("Items_6");
				component.Title = "Resume Construction";
				component.BodyText = "Resumes progress on all active construction projects.";
			}
			else
			{
				component2.sprite = SpriteLibrary.Get("Items_26");
				component.Title = "Pause Construction";
				component.BodyText = "Prevents progress on all active construction projects.";
			}
			_pauseBorder.gameObject.SetActive(GamePlayer.Current.ConstructionPaused);
			UITooltip.Refresh();
		}

		public void CancelAll()
		{
			UISounds.TurnPage();
			_cancelAllActive = true;
			foreach (ConstructionProgress item in new List<ConstructionProgress>(GamePlayer.Current.Construction))
			{
				item.Cancel();
			}
			_cancelAllActive = false;
			RefreshContent();
		}

		public void UpdateButtonAvailability()
		{
			_cancelAllButton.gameObject.SetActive(GamePlayer.Current.HasTech(ConstructionCancelTech));
			_pauseButton.gameObject.SetActive(GamePlayer.Current.HasTech(ConstructionPauseTech));
		}

		public void ConstructionAdded(ConstructionProgress progress)
		{
			float startY = ((_rows.Count > 0) ? (0f - (((RectTransform)_rows[_rows.Count - 1].transform).anchoredPosition.y - 100f)) : 0f);
			_rowParent.sizeDelta = new Vector2(_rowParent.sizeDelta.x, _addConstructionRow(progress, startY) + 110f);
		}

		public void ConstructionRemoved(ConstructionProgress progress)
		{
			if (_cancelAllActive)
			{
				return;
			}
			bool flag = false;
			for (int i = 0; i < _rows.Count; i++)
			{
				if (flag)
				{
					RectTransform rectTransform = _rows[i].transform as RectTransform;
					rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, rectTransform.anchoredPosition.y + 100f);
				}
				else if (_rows[i].Contained == progress)
				{
					Object.Destroy(_rows[i].gameObject);
					_rows.RemoveAt(i);
					i--;
					flag = true;
				}
			}
			if (flag)
			{
				_rowParent.sizeDelta = new Vector2(_rowParent.sizeDelta.x, _rowParent.sizeDelta.y - 100f);
			}
		}

		public void ConstructionCompleted(ConstructionProgress progress)
		{
			for (int i = 0; i < _rows.Count; i++)
			{
				if (_rows[i].Contained == progress)
				{
					_rows[i].SetCompleted();
				}
			}
		}
	}
}
