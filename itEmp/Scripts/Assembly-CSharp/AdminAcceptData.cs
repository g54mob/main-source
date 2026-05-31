using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AdminAcceptData : MonoBehaviour
{
	public AppProperties appProperties;

	public PersonalizationSettings personalizationSettings;

	public AppUserAccount appUserAccount;

	[Header("Accept View")]
	public GameObject viewAcceptAdmin;

	public GameObject infoAboutLoginIncorrect;

	public Image bgView;

	public TMP_InputField loginAdminField;

	public TMP_InputField passwordAdminField;

	public int idFunction;

	[Header("Sound Effect")]
	public AudioSource audioSource;

	public AudioClip systemAdminCheck;

	public int id;

	public void ShowDataToAccept(int identi)
	{
	}

	public void AcceptLikeAdminYes()
	{
	}

	public void AcceptLikeAdminNo()
	{
	}
}
