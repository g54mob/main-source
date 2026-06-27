using Helpers.Events;
using Restory.ObjectPools;
using UnityEngine;
using UnityEngine.Events;

namespace Restory.UserInterface.GameplayMenu
{
	public abstract class GUI_PanelBase : MonoBehaviour, IGUI_ModalWindow, ICleanableComponent
	{
		public readonly UnityEvent OnShown = new UnityEvent();

		public readonly UnityEvent OnHidden = new UnityEvent();

		public readonly UnityEvent OnContentChanged = new UnityEvent();

		public readonly UnityEvent<bool> OnBusyChanged = new UnityEventBool();

		private bool isBusy;

		[Header("Panel settings")]
		[SerializeField]
		protected RectTransform panelContent;

		public bool IsActive { get; protected set; }

		public bool IsBusy
		{
			get
			{
				return isBusy;
			}
			protected set
			{
				if (value != isBusy)
				{
					isBusy = value;
					OnBusyChanged.Invoke(value);
				}
			}
		}

		public virtual void Init()
		{
		}

		public virtual void Show()
		{
			IsActive = true;
			base.gameObject.SetActive(value: true);
			OnShown.Invoke();
		}

		public virtual void Hide()
		{
			IsActive = false;
			base.gameObject.SetActive(value: false);
			OnHidden.Invoke();
		}

		public virtual void Clean()
		{
			OnContentChanged.RemoveAllListeners();
			OnBusyChanged.RemoveAllListeners();
		}

		public virtual void UpdateView()
		{
		}
	}
}
