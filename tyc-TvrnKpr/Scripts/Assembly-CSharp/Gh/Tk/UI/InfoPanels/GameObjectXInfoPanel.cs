using System;
using System.Collections.Generic;
using UnityEngine;

namespace Gh.Tk.UI.InfoPanels
{
	public class GameObjectXInfoPanel : InfoPanel
	{
		public InventoryElement InventoryElement;

		public GameObject PreviewParent;

		public Button3DUIView TooltipContainer;

		[SerializeField]
		protected ProblemInfoElement ProblemInfoElement;

		[SerializeField]
		protected TraitsContainer3DUIView _traitsContainer;

		public GameObject _nextPreviousButtonContainer;

		public Button3DUIView _nextButton;

		public Button3DUIView _previousButton;

		public ActiveTasks3DUIView _activeTasksElement;

		private GameObject _model;

		private GameObjectX _gox;

		public virtual GameObjectX Gox
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		private void RefreshTooltipSource()
		{
		}

		protected IEnumerable<GameObjectX> GetObjectsToCycle()
		{
			return null;
		}

		protected void UpdatePreview()
		{
		}

		private void OnProblemsChanged(object sender, EventArgs e)
		{
		}

		private void RefreshProblems()
		{
		}

		public virtual void Refresh()
		{
		}

		public override void ShowInfo(GameObjectX gox)
		{
		}

		protected override void OnDisable()
		{
		}

		protected override void Awake()
		{
		}

		private void OnInventoryElementClicked(int index)
		{
		}

		private void UpdateTraits()
		{
		}

		private void AiComponentRemoved(object sender, GameObjectX.GameObjectXEventArgs<AiComponent> e)
		{
		}

		private void AiComponentAdded(object sender, GameObjectX.GameObjectXEventArgs<AiComponent> e)
		{
		}

		protected override void Closed()
		{
		}
	}
}
