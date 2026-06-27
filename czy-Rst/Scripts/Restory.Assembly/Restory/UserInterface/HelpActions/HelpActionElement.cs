using System;
using UnityEngine;

namespace Restory.UserInterface.HelpActions
{
	[Serializable]
	public class HelpActionElement
	{
		[SerializeField]
		private HelpActionElementObject button;

		[SerializeField]
		private bool interactable = true;

		[SerializeField]
		private float progress;

		public HelpActionElementObject Button => button;

		public bool Interactable
		{
			get
			{
				return interactable;
			}
			set
			{
				SetInteractable(value);
			}
		}

		public float Progress
		{
			get
			{
				return progress;
			}
			set
			{
				SetProgress(value);
			}
		}

		public event Action<bool> InteractableChanged;

		public event Action<float> ProgressChanged;

		public HelpActionElement()
		{
		}

		public HelpActionElement(HelpActionElementObject button)
		{
			this.button = button;
		}

		public void SetInteractable(bool interactable)
		{
			this.interactable = interactable;
			this.InteractableChanged?.Invoke(interactable);
		}

		public void SetProgress(float progress)
		{
			this.progress = progress;
			this.ProgressChanged?.Invoke(progress);
		}
	}
}
