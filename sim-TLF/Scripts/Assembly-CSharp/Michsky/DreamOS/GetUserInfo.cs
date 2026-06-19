using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Michsky.DreamOS
{
	[AddComponentMenu("DreamOS/User/Get User Info")]
	public class GetUserInfo : MonoBehaviour
	{
		public enum Reference
		{
			FullName = 0,
			FirstName = 1,
			LastName = 2,
			Password = 3,
			ProfilePicture = 4
		}

		[Header("Resources")]
		public UserManager userManager;

		[Header("Settings")]
		public Reference getInformation;

		public bool updateOnEnable = true;

		public bool addToManager = true;

		private TextMeshProUGUI textObject;

		private Image imageObject;

		private void Awake()
		{
			if (userManager == null)
			{
				userManager = Object.FindObjectsByType<UserManager>(FindObjectsSortMode.None)[0];
			}
			if (addToManager)
			{
				userManager.guiList.Add(this);
			}
			if (getInformation == Reference.ProfilePicture)
			{
				imageObject = base.gameObject.GetComponent<Image>();
			}
			else
			{
				textObject = base.gameObject.GetComponent<TextMeshProUGUI>();
			}
		}

		private void OnEnable()
		{
			if (updateOnEnable)
			{
				GetInformation();
			}
		}

		public void GetInformation()
		{
			if (!(userManager == null))
			{
				if (getInformation == Reference.FullName)
				{
					textObject.text = userManager.firstName + " " + userManager.lastName;
				}
				else if (getInformation == Reference.FirstName)
				{
					textObject.text = userManager.firstName;
				}
				else if (getInformation == Reference.LastName)
				{
					textObject.text = userManager.lastName;
				}
				else if (getInformation == Reference.Password)
				{
					textObject.text = userManager.password;
				}
				else if (getInformation == Reference.ProfilePicture)
				{
					imageObject.sprite = userManager.profilePicture;
				}
			}
		}
	}
}
