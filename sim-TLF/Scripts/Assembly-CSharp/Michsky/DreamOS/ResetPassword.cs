using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace Michsky.DreamOS
{
	public class ResetPassword : MonoBehaviour
	{
		[Header("Resources")]
		public UserManager userManager;

		public TextMeshProUGUI securityQuestion;

		public TMP_InputField securityAnswer;

		public TMP_InputField newPassword;

		public TMP_InputField newPasswordRetype;

		public ModalWindowManager modalManager;

		[Header("Events")]
		public UnityEvent onError = new UnityEvent();

		private string tempSecAnswer;

		private DreamOSDataManager.DataCategory dataCat;

		private void Awake()
		{
			if (userManager == null)
			{
				userManager = Object.FindObjectsByType<UserManager>(FindObjectsSortMode.None)[0];
			}
		}

		private void OnEnable()
		{
			if (!userManager.disableUserCreating && DreamOSDataManager.ContainsJsonKey(dataCat, "UserSecQuestion"))
			{
				securityQuestion.text = DreamOSDataManager.ReadStringData(dataCat, "UserSecQuestion");
				tempSecAnswer = DreamOSDataManager.ReadStringData(dataCat, "UserSecAnswer");
			}
			else
			{
				securityQuestion.text = userManager.systemSecurityQuestion;
				tempSecAnswer = userManager.systemSecurityAnswer;
			}
		}

		public void ChangePassword()
		{
			if (newPassword.text.Length >= userManager.minPasswordCharacter && newPassword.text.Length <= userManager.maxPasswordCharacter && newPassword.text == newPasswordRetype.text && securityAnswer.text == tempSecAnswer)
			{
				DreamOSDataManager.WriteStringData(dataCat, "UserPassword", newPassword.text);
				userManager.password = newPassword.text;
				userManager.hasPassword = true;
				modalManager.CloseWindow();
				newPassword.text = "";
				newPasswordRetype.text = "";
				securityAnswer.text = "";
			}
			else
			{
				onError.Invoke();
			}
		}
	}
}
