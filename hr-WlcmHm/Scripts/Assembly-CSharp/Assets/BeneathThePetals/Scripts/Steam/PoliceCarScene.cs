using UnityEngine;
using UnityEngine.Playables;

namespace Assets.BeneathThePetals.Scripts.Steam
{
	public class PoliceCarScene : MonoBehaviour, IInteractable
	{
		[SerializeField]
		private string actionName;

		[SerializeField]
		private PlayableDirector director;

		[SerializeField]
		private AchivementEnums.Achivement achivement;

		private LeaderIntroWalk policeOfficer;

		private FirstPersonController playerControls;

		private Collider carCollider;

		private bool canInteract;

		private void Start()
		{
			playerControls = GameObject.FindGameObjectWithTag("Player").GetComponent<FirstPersonController>();
			policeOfficer = Object.FindAnyObjectByType<LeaderIntroWalk>();
			carCollider = GetComponent<Collider>();
			carCollider.enabled = false;
		}

		private void Update()
		{
			if (!policeOfficer.transform.gameObject.activeSelf || !policeOfficer.isActiveAndEnabled)
			{
				canInteract = true;
				carCollider.enabled = true;
			}
		}

		public void Interact()
		{
			playerControls.isWalking = false;
			if (canInteract)
			{
				StartCutScene();
			}
		}

		private void StartCutScene()
		{
			director.Play();
			playerControls.DisableInput();
			SteamManager.Instance.UnlockAchievement(achivement.ToString());
			CultistOutsideRun[] array = Object.FindObjectsByType<CultistOutsideRun>(FindObjectsSortMode.None);
			for (int i = 0; i < array.Length; i++)
			{
				array[i].gameObject.SetActive(value: false);
			}
		}

		public void Activate()
		{
		}

		public void Deactivate()
		{
		}

		public string GetActionName()
		{
			return actionName;
		}

		public string GetName()
		{
			return " ";
		}

		public void PlayInteractSound()
		{
		}

		public void ShowRestart()
		{
			playerControls.transform.GetComponentInChildren<PauseMenu>().ShowRestartMenu();
		}

		public string GetActionType()
		{
			return "Press";
		}
	}
}
