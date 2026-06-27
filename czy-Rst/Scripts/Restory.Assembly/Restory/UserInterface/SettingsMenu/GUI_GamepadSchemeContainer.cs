using Restory.Data.GUIControllerElements;
using UnityEngine;
using Zenject;

namespace Restory.UserInterface.SettingsMenu
{
	public class GUI_GamepadSchemeContainer : MonoBehaviour
	{
		[SerializeField]
		private ControllerId controllerId;

		[SerializeField]
		private GuiControllerSchemeList controllerSchemeList;

		[SerializeField]
		private RectTransform gamepadSchemeContainer;

		private GuiControllerScheme currentScheme;

		private GameObject currentSchemeView;

		private DiContainer diContainer;

		public ControllerId ControllerId
		{
			get
			{
				return controllerId;
			}
			set
			{
				SetControllerId(value);
			}
		}

		[Inject]
		private void Construct(DiContainer diContainer)
		{
			this.diContainer = diContainer;
			if (base.isActiveAndEnabled)
			{
				UpdateScheme();
			}
		}

		private void Awake()
		{
			UpdateScheme();
		}

		private void OnEnable()
		{
			UpdateView();
		}

		public void SetControllerId(ControllerId controllerId)
		{
			if (!(this.controllerId == controllerId))
			{
				this.controllerId = controllerId;
				UpdateScheme();
				UpdateView();
			}
		}

		private void UpdateScheme()
		{
			if (controllerId == null)
			{
				currentScheme = controllerSchemeList.DefaultGamepadScheme;
			}
			else
			{
				controllerSchemeList.TryGetGuiControllerScheme(controllerId, out currentScheme);
			}
		}

		private void UpdateView()
		{
			if (currentSchemeView != null)
			{
				Object.Destroy(currentSchemeView);
			}
			if ((bool)currentScheme && (bool)currentScheme.SchemeView && diContainer != null)
			{
				currentSchemeView = diContainer.InstantiatePrefab(currentScheme.SchemeView, gamepadSchemeContainer);
			}
		}
	}
}
