using System;
using Restory.Data.Localization;
using UnityEngine;
using UnityEngine.UI;

namespace Restory.UserInterface.ConfirmationDialogues
{
	public abstract class GUI_ConfirmationDialogueBase : MonoBehaviour
	{
		private bool isActive;

		[Header("General settings")]
		[SerializeField]
		protected GameObject content;

		[Header("Texts")]
		[Space(10f)]
		public Text description;

		[Header("Buttons")]
		[SerializeField]
		protected Button positiveButton;

		[SerializeField]
		protected Button negativeButton;

		protected Action OnPositiveSelection;

		protected Action OnNegativeSelection;

		protected LocalizationSystem LocalizationSystem;

		public bool IsActive
		{
			get
			{
				return isActive;
			}
			set
			{
				isActive = value;
				this.OnActiveChanged?.Invoke();
			}
		}

		public event Action OnActiveChanged;

		public void OnSelectedPositive()
		{
			Action onPositiveSelection = OnPositiveSelection;
			Close();
			onPositiveSelection?.Invoke();
		}

		public void OnSelectedNegative()
		{
			Action onNegativeSelection = OnNegativeSelection;
			Close();
			onNegativeSelection?.Invoke();
		}

		public abstract void Close();
	}
}
