using UnityEngine;

namespace Michsky.DreamOS
{
	public class SetupManagerButtonLimiter : MonoBehaviour
	{
		public enum VariableType
		{
			UserInformation = 0,
			Privacy = 1
		}

		[Header("Resources")]
		[SerializeField]
		private SetupManager setupManager;

		[SerializeField]
		private ButtonManager targetButton;

		[SerializeField]
		private SystemErrorPopup nameError;

		[SerializeField]
		private SystemErrorPopup lastNameError;

		[SerializeField]
		private SystemErrorPopup passError;

		[SerializeField]
		private SystemErrorPopup passCheckError;

		[Header("Settings")]
		[SerializeField]
		private bool disableButtonOnEnable = true;

		[SerializeField]
		private VariableType checkFor;

		private bool isNameOK;

		private bool isLastNameOK;

		private bool isPasswordOK;

		private bool isPasswordRetypeOK;

		private void OnEnable()
		{
			if (!(setupManager == null) && !(setupManager.userManager == null) && disableButtonOnEnable)
			{
				targetButton.Interactable(value: false);
			}
		}

		private void Update()
		{
			if (!(setupManager == null) && !(setupManager.userManager == null))
			{
				if (checkFor == VariableType.UserInformation && setupManager.userManager.nameOK && !isNameOK)
				{
					SetNameState(value: true);
				}
				else if (checkFor == VariableType.UserInformation && !setupManager.userManager.nameOK && isNameOK)
				{
					SetNameState(value: false);
				}
				else if (checkFor == VariableType.UserInformation && setupManager.userManager.lastNameOK && !isLastNameOK)
				{
					SetLastNameState(value: true);
				}
				else if (checkFor == VariableType.UserInformation && !setupManager.userManager.lastNameOK && isLastNameOK)
				{
					SetLastNameState(value: false);
				}
				else if (checkFor == VariableType.UserInformation && isNameOK && isLastNameOK && !targetButton.isInteractable)
				{
					AllowInformation();
				}
				if (checkFor == VariableType.Privacy && setupManager.userManager.passwordOK && !isPasswordOK)
				{
					SetPasswordState(value: true);
				}
				else if (checkFor == VariableType.Privacy && !setupManager.userManager.passwordOK && isPasswordOK)
				{
					SetPasswordState(value: false);
				}
				else if (checkFor == VariableType.Privacy && setupManager.userManager.passwordRetypeOK && !isPasswordRetypeOK)
				{
					SetRetypePasswordState(value: true);
				}
				else if (checkFor == VariableType.Privacy && !setupManager.userManager.passwordRetypeOK && isPasswordRetypeOK)
				{
					SetRetypePasswordState(value: false);
				}
				else if (checkFor == VariableType.Privacy && isPasswordOK && isPasswordRetypeOK && !targetButton.isInteractable)
				{
					AllowPrivacy();
				}
			}
		}

		private void SetNameState(bool value)
		{
			isNameOK = value;
			lastNameError.Hide();
			if (value)
			{
				nameError.Hide();
				return;
			}
			targetButton.Interactable(value: false);
			nameError.Show();
		}

		private void SetLastNameState(bool value)
		{
			isLastNameOK = value;
			if (value)
			{
				lastNameError.Hide();
				return;
			}
			targetButton.Interactable(value: false);
			lastNameError.Show();
		}

		private void SetPasswordState(bool value)
		{
			isPasswordOK = value;
			passCheckError.Hide();
			if (value)
			{
				passError.Hide();
				return;
			}
			targetButton.Interactable(value: false);
			passError.Show();
		}

		private void SetRetypePasswordState(bool value)
		{
			isPasswordRetypeOK = value;
			passError.Hide();
			if (value)
			{
				passCheckError.Hide();
				return;
			}
			targetButton.Interactable(value: false);
			passCheckError.Show();
		}

		private void AllowInformation()
		{
			targetButton.Interactable(value: true);
			nameError.Hide();
			lastNameError.Hide();
		}

		private void AllowPrivacy()
		{
			targetButton.Interactable(value: true);
			passError.Hide();
			passCheckError.Hide();
		}
	}
}
