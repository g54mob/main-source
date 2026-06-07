using System;
using System.Collections.Generic;
using I18n;
using UnityEngine;

namespace Gh.Tk.UI.InfoPanels
{
	public class EntertainerInfoPanel : InfoPanel
	{
		public TextMeshProI18n Name;

		public GameObject PreviewParent;

		[SerializeField]
		private TraitsContainer3DUIView _traitsContainer;

		[SerializeField]
		protected ProblemInfoElement ProblemInfoElement;

		public ActiveTasks3DUIView _activeTasksElement;

		private Entertainer _entertainer;

		private GameObject _model;

		[Header("Performance Data")]
		[SerializeField]
		private TextMeshProI18n _entertainerTypeText;

		[SerializeField]
		private Container3DUIView _starsContainer;

		[SerializeField]
		private List<GameObject> _stars;

		[SerializeField]
		private TextMeshProI18n _performanceEffectText;

		[SerializeField]
		private List<GameObject> _performanceTraitSockets;

		[SerializeField]
		private BaseProgressBar3DUIView _performanceProgressBar;

		public virtual Entertainer Entertainer
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public override void ShowInfo(GameObjectX gox)
		{
		}

		protected override void Awake()
		{
		}

		private void OnAiComponentRemoved(object sender, GameObjectX.GameObjectXEventArgs<AiComponent> e)
		{
		}

		private void OnAiComponentAdded(object sender, GameObjectX.GameObjectXEventArgs<AiComponent> e)
		{
		}

		private void UpdateTraits()
		{
		}

		private void OnProblemsChanged(object sender, EventArgs e)
		{
		}

		private void RefreshProblems()
		{
		}

		protected override void OnEnable()
		{
		}

		protected override void OnDisable()
		{
		}

		private void OnMinuteChanged(object sender, EventArgs e)
		{
		}

		private void UpdatePerformanceProgress(BookedEntertainerEvent gameEvent)
		{
		}

		private BookedEntertainerEvent GetOurEvent()
		{
			return null;
		}

		private void UpdatePerformanceData()
		{
		}

		private void Start()
		{
		}
	}
}
