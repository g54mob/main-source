using System;
using System.Collections.Generic;
using TH20.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TH20
{
	public class StaffMenuJobAssignRow : StaffMenuRowBase
	{
		[Header("RowHighlight")]
		[SerializeField]
		protected Image _rowBackground2;

		[SerializeField]
		protected Sprite _rowAlternateBackground2;

		[SerializeField]
		protected Image _rowThinBackground;

		[SerializeField]
		private Color _rowBackgroundValidColor = Color.white;

		[SerializeField]
		private Color _rowBackgroundInvalidColor = Color.red;

		[Header("Job Assignment")]
		[SerializeField]
		public int JobIconUnitSize = 50;

		[SerializeField]
		private GameObject _jobTogglePrefab;

		[SerializeField]
		private RectTransform _jobToggleFrame;

		[SerializeField]
		private Transform _jobToggleContainer;

		[SerializeField]
		private TMP_Text _jobsAssignedToText;

		[SerializeField]
		private DynamicButton _jobsAssignedToButton;

		private int _jobsAssigned;

		private List<StaffJobToggle> _jobToggles;

		public Action<JobDescription, Staff> ToggleChangedFunc;

		private bool _hasCleanedUpToggles;

		private bool _refreshJobsQueued;

		private List<JobDescription> _queuedJobs;

		public int JobsAssigned => _jobsAssigned;

		protected void OnEnable()
		{
			_jobsAssignedToButton.onSecondaryDown.AddListener(OnJobAssignedToPressed);
		}

		protected void OnDisable()
		{
			_jobsAssignedToButton.onSecondaryDown.RemoveListener(OnJobAssignedToPressed);
		}

		public override void Setup(Staff staff, List<JobDescription> jobs, StaffMenu staffMenu)
		{
			base.Setup(staff, jobs, staffMenu);
			if (!_hasCleanedUpToggles)
			{
				GameObjectUtils.DestroyChildren(_jobToggleContainer.gameObject);
				_jobToggleContainer.DetachChildren();
				_hasCleanedUpToggles = true;
			}
			if (jobs != null)
			{
				_jobToggleFrame.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, jobs.Count * JobIconUnitSize);
			}
			Refresh();
			RefreshJobs(jobs);
		}

		public override void SetRowBackground(int rowNum)
		{
			base.SetRowBackground(rowNum);
			if ((bool)_rowBackground2)
			{
				_rowBackground2.overrideSprite = ((rowNum % 2 == 1) ? _rowAlternateBackground2 : null);
			}
		}

		public override void Refresh(bool instant = false)
		{
			if (_refreshJobsQueued)
			{
				RefreshJobs(_queuedJobs);
				_queuedJobs = null;
				_refreshJobsQueued = false;
			}
			_rowThinBackground.color = ((_jobsAssigned == 0) ? _rowBackgroundInvalidColor : _rowBackgroundValidColor);
			base.Refresh(instant);
		}

		private bool CanChangeJob(JobDescription job)
		{
			if (base.Staff.Definition is RoboJanitorDefinition roboJanitorDefinition)
			{
				return !roboJanitorDefinition.JobExclusions.Contains(job);
			}
			return true;
		}

		public void RefreshJobs(List<JobDescription> jobs)
		{
			if (_jobToggles == null)
			{
				_jobToggles = new List<StaffJobToggle>();
			}
			else
			{
				_jobToggles.Clear();
			}
			if (jobs == null)
			{
				return;
			}
			if (CanvasUpdateRegistry.IsRebuildingLayout())
			{
				_queuedJobs = jobs;
				_refreshJobsQueued = true;
				return;
			}
			StaffMenu.GetCurrentJobAssignmentIndiciesForPage(jobs, base.StaffMenu.CurrentJobAssignmentPageIndex, out var startIndex, out var endIndex);
			int num = endIndex - startIndex + 1;
			foreach (Transform item in _jobToggleContainer)
			{
				int siblingIndex = item.GetSiblingIndex();
				if (siblingIndex < num)
				{
					GameObject obj = item.gameObject;
					JobDescription job = jobs[startIndex + siblingIndex];
					StaffJobToggle component = obj.GetComponent<StaffJobToggle>();
					bool interactable = CanChangeJob(job);
					_jobToggles.Add(component);
					component.Setup(job, base.Staff, interactable, delegate
					{
						OnTogglePressed(job);
					});
				}
				else
				{
					UnityEngine.Object.Destroy(item.gameObject);
				}
			}
			for (int num2 = _jobToggleContainer.childCount; num2 < num; num2++)
			{
				JobDescription job2 = jobs[startIndex + num2];
				StaffJobToggle component2 = UnityEngine.Object.Instantiate(_jobTogglePrefab, _jobToggleContainer, worldPositionStays: false).GetComponent<StaffJobToggle>();
				bool interactable2 = CanChangeJob(job2);
				_jobToggles.Add(component2);
				component2.Setup(job2, base.Staff, interactable2, delegate
				{
					OnTogglePressed(job2);
				});
			}
			RefreshJobAssignmentCounter(jobs);
		}

		public void RefreshJobAssignmentCounter(List<JobDescription> jobs)
		{
			_jobsAssigned = 0;
			for (int i = 0; i < jobs.Count; i++)
			{
				JobDescription jobDescription = jobs[i];
				if (jobDescription.IsSuitable(base.Staff) && !base.Staff.JobExclusions.Contains(jobDescription))
				{
					_jobsAssigned++;
				}
			}
			_jobsAssignedToText.text = $"{_jobsAssigned}/{jobs.Count}";
		}

		private void OnTogglePressed(JobDescription job)
		{
			ToggleChangedFunc.InvokeSafe(job, base.Staff);
		}

		private void OnJobAssignedToPressed()
		{
			base.StaffMenu.OnJobRowPressed(base.Staff);
		}
	}
}
