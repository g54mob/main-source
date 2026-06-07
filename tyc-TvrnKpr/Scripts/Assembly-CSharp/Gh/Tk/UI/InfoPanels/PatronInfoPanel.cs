using System;
using Gh.Tk.UI.Dialogs.StaffHiring;
using UnityEngine;

namespace Gh.Tk.UI.InfoPanels
{
	public class PatronInfoPanel : InfoPanel
	{
		public Stars3DUIView TierElement;

		public GameObject PreviewParent;

		[SerializeField]
		private Countdown3DUIView _patienceMeter;

		[SerializeField]
		private PatienceStat3DUIView _patienceStatElement;

		[SerializeField]
		private GameObjectXStat3DUIView _energyStat;

		[SerializeField]
		private Container3DUIView _satisfactionStatContainer;

		[SerializeField]
		private SatisfactionProgressBar _satisfactionProgressBar;

		[SerializeField]
		private TraitsContainer3DUIView _traitsContainer;

		[SerializeField]
		protected ProblemInfoElement ProblemInfoElement;

		public ActiveTasks3DUIView _activeTasksElement;

		[SerializeField]
		private StaffBiosElement _biosElement;

		public Button3DUIView KickOutOfTavernButton;

		public Button3DUIView GiveFreeDrinkButton;

		public Button3DUIView TryToPlacateButton;

		public Button3DUIView PriorityButton;

		private Patron _patron;

		private GameObject _model;

		[SerializeField]
		private BaseInteractable3DUIView _followTargetButton;

		public virtual Patron Patron
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		private void UpdatePreview()
		{
		}

		private void Update()
		{
		}

		public override void ShowInfo(GameObjectX gox)
		{
		}

		protected override void Awake()
		{
		}

		private void Start()
		{
		}

		private void Patron_AiComponentRemoved(object sender, GameObjectX.GameObjectXEventArgs<AiComponent> e)
		{
		}

		private void Patron_AiComponentAdded(object sender, GameObjectX.GameObjectXEventArgs<AiComponent> e)
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
	}
}
