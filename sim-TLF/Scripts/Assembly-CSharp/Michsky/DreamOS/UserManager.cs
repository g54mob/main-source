using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace Michsky.DreamOS
{
	public class UserManager : MonoBehaviour
	{
		public BootManager bootManager;

		public SetupManager setupScreen;

		public Animator desktopScreen;

		public Animator lockScreen;

		public TMP_InputField lockScreenPassword;

		public ProfilePictureLibrary ppLibrary;

		[SerializeField]
		private GameObject ppItem;

		[SerializeField]
		private Transform ppParent;

		[SerializeField]
		private SystemErrorPopup wrongPassError;

		[SerializeField]
		private UIBlur lockScreenBlur;

		[Range(1f, 20f)]
		public int minNameCharacter = 1;

		[Range(1f, 20f)]
		public int maxNameCharacter = 14;

		[Range(1f, 20f)]
		public int minPasswordCharacter = 4;

		[Range(1f, 20f)]
		public int maxPasswordCharacter = 16;

		public UnityEvent onLogin = new UnityEvent();

		public UnityEvent onLock = new UnityEvent();

		public UnityEvent onWrongPassword = new UnityEvent();

		public string systemUsername = "Admin";

		public string systemLastname = "";

		public string systemPassword = "1234";

		public string systemSecurityQuestion = "Answer: DreamOS";

		public string systemSecurityAnswer = "DreamOS";

		public bool disableUserCreating;

		public bool disableLockScreen;

		public bool saveProfilePicture = true;

		public int ppIndex;

		public string firstName;

		public string lastName;

		public string password;

		public string secQuestion;

		public string secAnswer;

		public Sprite profilePicture;

		private string noSecQuestionIndicator = "No security question set.";

		private float cachedDesktopLength = 0.5f;

		private float cachedLockScreenInLength = 0.5f;

		private float cachedLockScreenOutLength = 0.5f;

		public bool isLockScreenOpen;

		private bool isLoginScreenOpen;

		public bool userCreated;

		public bool hasPassword;

		[HideInInspector]
		public bool nameOK;

		[HideInInspector]
		public bool lastNameOK;

		[HideInInspector]
		public bool passwordOK;

		[HideInInspector]
		public bool passwordRetypeOK;

		public List<GetUserInfo> guiList = new List<GetUserInfo>();

		private DreamOSDataManager.DataCategory dataCat;

		private void Awake()
		{
			if (desktopScreen != null)
			{
				cachedDesktopLength = DreamOSInternalTools.GetAnimatorClipLength(desktopScreen, "Desktop_In") + 0.1f;
			}
			if (lockScreen != null)
			{
				cachedLockScreenOutLength = DreamOSInternalTools.GetAnimatorClipLength(lockScreen, "LockScreen_PasswordIn") + 0.1f;
				cachedLockScreenOutLength = DreamOSInternalTools.GetAnimatorClipLength(lockScreen, "LockScreen_PasswordOut") + 0.1f;
			}
			if (bootManager == null)
			{
				bootManager = Object.FindObjectsByType<BootManager>(FindObjectsSortMode.None)[0];
			}
			if (setupScreen == null)
			{
				setupScreen = Object.FindObjectsByType<SetupManager>(FindObjectsSortMode.None)[0];
			}
		}

		private void OnEnable()
		{
			Initialize();
			InitializeProfilePictures();
		}

		public void Initialize()
		{
			if (!disableUserCreating)
			{
				nameOK = false;
				lastNameOK = false;
				passwordOK = false;
				passwordRetypeOK = false;
				if (!DreamOSDataManager.ContainsJsonKey(dataCat, "UserCreated"))
				{
					userCreated = false;
				}
				else if (DreamOSDataManager.ReadBooleanData(dataCat, "UserCreated"))
				{
					userCreated = true;
				}
				else
				{
					userCreated = false;
				}
				if (userCreated)
				{
					firstName = DreamOSDataManager.ReadStringData(dataCat, "UserFirstName");
					lastName = DreamOSDataManager.ReadStringData(dataCat, "UserLastName");
					password = DreamOSDataManager.ReadStringData(dataCat, "UserPassword");
					secQuestion = DreamOSDataManager.ReadStringData(dataCat, "UserSecQuestion");
					secAnswer = DreamOSDataManager.ReadStringData(dataCat, "UserSecAnswer");
					if (!DreamOSDataManager.ContainsJsonKey(dataCat, "UserProfilePicture"))
					{
						ppIndex = 0;
						DreamOSDataManager.WriteIntData(dataCat, "UserProfilePicture", ppIndex);
					}
					else
					{
						ppIndex = DreamOSDataManager.ReadIntData(dataCat, "UserProfilePicture");
					}
					if (string.IsNullOrEmpty(password))
					{
						hasPassword = false;
					}
					else
					{
						hasPassword = true;
					}
				}
				profilePicture = ppLibrary.pictures[ppIndex].pictureSprite;
			}
			else
			{
				userCreated = true;
				if (string.IsNullOrEmpty(systemPassword))
				{
					hasPassword = false;
				}
				else
				{
					hasPassword = true;
				}
				firstName = systemUsername;
				lastName = systemLastname;
				password = systemPassword;
				profilePicture = ppLibrary.pictures[ppIndex].pictureSprite;
			}
		}

		public void InitializeProfilePictures()
		{
			if (ppParent == null || ppItem == null)
			{
				return;
			}
			foreach (Transform item in ppParent)
			{
				Object.Destroy(item.gameObject);
			}
			for (int i = 0; i < ppLibrary.pictures.Count; i++)
			{
				int index = i;
				GameObject gameObject = Object.Instantiate(ppItem, new Vector3(0f, 0f, 0f), Quaternion.identity);
				gameObject.transform.SetParent(ppParent, worldPositionStays: false);
				gameObject.name = ppLibrary.pictures[i].pictureID;
				ButtonManager wpButton = gameObject.GetComponent<ButtonManager>();
				wpButton.SetIcon(ppLibrary.pictures[i].pictureSprite);
				wpButton.onClick.AddListener(delegate
				{
					SetProfilePicture(index);
					wpButton.gameObject.GetComponentInParent<ModalWindowManager>().CloseWindow();
				});
			}
		}

		public void SetUserCreated(bool value)
		{
			userCreated = value;
			DreamOSDataManager.WriteBooleanData(dataCat, "UserCreated", value);
		}

		public void SetFirstName(string textVar)
		{
			firstName = textVar;
			if (!disableUserCreating)
			{
				DreamOSDataManager.WriteStringData(dataCat, "UserFirstName", firstName);
			}
			UpdateUserInfoUI(GetUserInfo.Reference.FirstName);
			UpdateUserInfoUI(GetUserInfo.Reference.FullName);
		}

		public void SetFirstName(TMP_InputField tmpVar)
		{
			firstName = tmpVar.text;
			if (!disableUserCreating)
			{
				DreamOSDataManager.WriteStringData(dataCat, "UserFirstName", firstName);
			}
			UpdateUserInfoUI(GetUserInfo.Reference.FirstName);
			UpdateUserInfoUI(GetUserInfo.Reference.FullName);
		}

		public void SetLastName(string textVar)
		{
			lastName = textVar;
			if (!disableUserCreating)
			{
				DreamOSDataManager.WriteStringData(dataCat, "UserLastName", lastName);
			}
			UpdateUserInfoUI(GetUserInfo.Reference.LastName);
			UpdateUserInfoUI(GetUserInfo.Reference.FullName);
		}

		public void SetLastName(TMP_InputField tmpVar)
		{
			lastName = tmpVar.text;
			if (!disableUserCreating)
			{
				DreamOSDataManager.WriteStringData(dataCat, "UserLastName", lastName);
			}
			UpdateUserInfoUI(GetUserInfo.Reference.LastName);
			UpdateUserInfoUI(GetUserInfo.Reference.FullName);
		}

		public void SetPassword(string textVar)
		{
			password = textVar;
			if (!disableUserCreating)
			{
				DreamOSDataManager.WriteStringData(dataCat, "UserPassword", password);
			}
			UpdateUserInfoUI(GetUserInfo.Reference.Password);
		}

		public void SetPassword(TMP_InputField tmpVar)
		{
			password = tmpVar.text;
			if (!disableUserCreating)
			{
				DreamOSDataManager.WriteStringData(dataCat, "UserPassword", password);
			}
			UpdateUserInfoUI(GetUserInfo.Reference.Password);
		}

		public void SetSecurityQuestion(string textVar)
		{
			if (string.IsNullOrEmpty(textVar))
			{
				DreamOSDataManager.WriteStringData(dataCat, "UserSecQuestion", noSecQuestionIndicator);
			}
			else
			{
				DreamOSDataManager.WriteStringData(dataCat, "UserSecQuestion", textVar);
			}
		}

		public void SetSecurityQuestion(TMP_InputField tmpVar)
		{
			if (string.IsNullOrEmpty(tmpVar.text))
			{
				DreamOSDataManager.WriteStringData(dataCat, "UserSecQuestion", noSecQuestionIndicator);
			}
			else
			{
				DreamOSDataManager.WriteStringData(dataCat, "UserSecQuestion", tmpVar.text);
			}
		}

		public void SetSecurityAnswer(string textVar)
		{
			DreamOSDataManager.WriteStringData(dataCat, "UserSecAnswer", textVar);
		}

		public void SetSecurityAnswer(TMP_InputField tmpVar)
		{
			DreamOSDataManager.WriteStringData(dataCat, "UserSecAnswer", tmpVar.text);
		}

		public void SetProfilePicture(int pictureIndex)
		{
			ppIndex = pictureIndex;
			profilePicture = ppLibrary.pictures[ppIndex].pictureSprite;
			if (saveProfilePicture)
			{
				DreamOSDataManager.WriteIntData(dataCat, "UserProfilePicture", ppIndex);
			}
			UpdateUserInfoUI(GetUserInfo.Reference.ProfilePicture);
		}

		public void UpdateUserInfoUI(GetUserInfo.Reference reference)
		{
			foreach (GetUserInfo gui in guiList)
			{
				if (!(gui == null) && gui.getInformation == reference)
				{
					gui.GetInformation();
				}
			}
		}

		public void CreateUser()
		{
			userCreated = true;
			DreamOSDataManager.WriteBooleanData(dataCat, "UserCreated", userCreated);
			if (DreamOSDataManager.ContainsJsonKey(dataCat, "UserPassword"))
			{
				password = DreamOSDataManager.ReadStringData(dataCat, "UserPassword");
			}
			if (string.IsNullOrEmpty(password))
			{
				hasPassword = false;
			}
			else
			{
				hasPassword = true;
			}
		}

		public void LockSystem()
		{
			if (lockScreenBlur != null)
			{
				lockScreenBlur.BlurOutAnim();
			}
			if (lockScreen != null)
			{
				OpenLockScreen();
			}
			HideDesktop();
			onLock.Invoke();
		}

		public void OpenLockScreen()
		{
			if (!isLockScreenOpen && !(lockScreen == null))
			{
				if (lockScreenBlur != null)
				{
					lockScreenBlur.BlurOutAnim();
				}
				lockScreen.gameObject.SetActive(value: true);
				lockScreen.enabled = true;
				lockScreen.Play("In");
				isLockScreenOpen = true;
				if (disableLockScreen && !hasPassword)
				{
					lockScreen.enabled = true;
					isLockScreenOpen = false;
					isLoginScreenOpen = false;
					lockScreen.gameObject.SetActive(value: false);
					onLogin.Invoke();
					ShowDesktop();
				}
				StopCoroutine("DisableLockScreenAnimator");
				StartCoroutine("DisableLockScreenAnimator");
			}
		}

		public void OpenLockScreenPassword()
		{
			if (!(lockScreen == null))
			{
				if (lockScreenBlur != null)
				{
					lockScreenBlur.BlurInAnim();
				}
				isLoginScreenOpen = true;
				lockScreen.gameObject.SetActive(value: true);
				lockScreen.enabled = true;
				lockScreen.Play("Password In");
				StopCoroutine("DisableLockScreenAnimator");
				StartCoroutine("DisableLockScreenAnimator");
			}
		}

		public void CloseLockScreen()
		{
			if (isLockScreenOpen && !(lockScreen == null))
			{
				if (lockScreenBlur != null)
				{
					lockScreenBlur.BlurOutAnim();
				}
				lockScreen.enabled = true;
				isLockScreenOpen = false;
				isLoginScreenOpen = false;
				if (hasPassword)
				{
					lockScreen.Play("Password Out");
				}
				else
				{
					lockScreen.Play("Out");
				}
				StopCoroutine("DisableLockScreenAnimator");
				StartCoroutine("DisableLockScreen");
			}
		}

		public void ShowDesktop()
		{
			desktopScreen.gameObject.SetActive(value: true);
			desktopScreen.enabled = true;
			desktopScreen.Play("In");
			StopCoroutine("DisableDesktopAnimator");
			StartCoroutine("DisableDesktopAnimator");
		}

		public void HideDesktop()
		{
			desktopScreen.enabled = true;
			desktopScreen.Play("Out");
			StopCoroutine("DisableDesktopAnimator");
			StartCoroutine("DisableDesktopAnimator");
		}

		public void AnimateLockScreen()
		{
			if (!isLoginScreenOpen)
			{
				StopCoroutine("DisableDesktopAnimator");
				if (hasPassword)
				{
					OpenLockScreenPassword();
					return;
				}
				CloseLockScreen();
				ShowDesktop();
				onLogin.Invoke();
			}
		}

		public void Login()
		{
			if (lockScreenPassword.text != password)
			{
				onWrongPassword.Invoke();
				wrongPassError.Show();
			}
			else if (lockScreenPassword.text == password)
			{
				CloseLockScreen();
				ShowDesktop();
				onLogin.Invoke();
			}
		}

		public void WipeUserData()
		{
			nameOK = false;
			lastNameOK = false;
			passwordOK = false;
			passwordRetypeOK = false;
			DreamOSDataManager.DeleteDataCategory(DreamOSDataManager.DataCategory.Apps);
			DreamOSDataManager.DeleteDataCategory(DreamOSDataManager.DataCategory.User);
			DreamOSDataManager.DeleteDataCategory(DreamOSDataManager.DataCategory.System);
			DreamOSDataManager.DeleteDataCategory(DreamOSDataManager.DataCategory.DateAndTime);
			DreamOSDataManager.DeleteDataCategory(DreamOSDataManager.DataCategory.Network);
			DreamOSDataManager.DeleteDataCategory(DreamOSDataManager.DataCategory.Widgets);
			bootManager.Reboot();
		}

		private IEnumerator DisableDesktopAnimator()
		{
			yield return new WaitForSeconds(cachedDesktopLength);
			desktopScreen.enabled = false;
		}

		private IEnumerator DisableLockScreenAnimator()
		{
			yield return new WaitForSeconds(cachedLockScreenInLength);
			lockScreen.enabled = false;
		}

		private IEnumerator DisableLockScreen()
		{
			yield return new WaitForSeconds(cachedLockScreenOutLength);
			lockScreen.gameObject.SetActive(value: false);
		}
	}
}
