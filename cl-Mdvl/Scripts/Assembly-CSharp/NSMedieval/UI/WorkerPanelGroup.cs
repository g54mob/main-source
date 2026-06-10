using System;
using NSEipix.View.UI;
using NSMedieval.State;
using UnityEngine;

namespace NSMedieval.UI
{
	public abstract class WorkerPanelGroup : LayoutGroupItemView
	{
		[SerializeField]
		private WorkerEntryLayoutItemView workerView;

		[SerializeField]
		private SoundButton copyButton;

		[SerializeField]
		private SoundButton pasteButton;

		[field: NonSerialized]
		private WorkerPanelManager PanelManager { get; set; }

		protected SoundButton CopyButton => copyButton;

		protected SoundButton PasteButton => pasteButton;

		public WorkerEntryLayoutItemView WorkerView => workerView;

		[field: NonSerialized]
		public HumanoidInstance Humanoid { get; private set; }

		protected WorkerBehaviour Worker => Humanoid?.WorkerBehaviour;

		public virtual void SetWorker(HumanoidInstance humanoid, WorkerPanelManager panelManager)
		{
			base.gameObject.SetActive(value: true);
			Humanoid = humanoid;
			PanelManager = panelManager;
			WorkerView.SetHumanoidInstance(Humanoid);
		}

		protected virtual void PasteSettings()
		{
		}

		protected virtual void CopySettings()
		{
		}

		protected virtual void Start()
		{
			if (copyButton != null)
			{
				CopyButton.onClick.AddListener(CopySettings);
			}
			if (pasteButton != null)
			{
				PasteButton.onClick.AddListener(PasteSettings);
			}
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();
			Humanoid = null;
			workerView = null;
		}
	}
}
