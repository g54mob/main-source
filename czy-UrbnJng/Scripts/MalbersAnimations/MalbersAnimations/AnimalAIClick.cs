using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using MalbersAnimations.Controller;
using MalbersAnimations.Controller.AI;
using MalbersAnimations.Scriptables;
using UnityEngine;
using UnityEngine.EventSystems;

namespace MalbersAnimations
{
	public class AnimalAIClick : MonoBehaviour, IPointerClickHandler, IEventSystemHandler, IPointerEnterHandler, IPointerExitHandler
	{
		public List<int> SleepingModes = new List<int>();

		public GameObject HeartPopUpParticle;

		public float heartPopUpDuration = 2f;

		public MAnimal currentClickedAnimal;

		public int CurrentModePlaying;

		public MAnimalBrain animalBrain;

		public IAIControl AIControl;

		public MAnimalAIControl AIControlComp;

		public TransformVar ItemGhostVar;

		public float AIUpdateCycleTime = 0.5f;

		private bool ItemIsMoving;

		[SerializeField]
		private bool isDog;

		[SerializeField]
		private Transform heartTemplate;

		private float heartMoveOffsetY = 1f;

		private float heartMoveDuration = 1.2f;

		public event EventHandler OnCatInteracted;

		public event EventHandler OnDogInteracted;

		private void Start()
		{
			if (AIControl == null)
			{
				AIControl = base.gameObject.GetComponentInChildren<IAIControl>();
			}
		}

		private void HeartPopUp()
		{
			Transform heart = UnityEngine.Object.Instantiate(heartTemplate, heartTemplate.parent);
			heart.gameObject.SetActive(value: true);
			DOTween.Sequence().Append(heart.DOMoveY(heart.position.y + heartMoveOffsetY, heartMoveDuration).SetEase(Ease.OutSine)).AppendCallback(delegate
			{
				UnityEngine.Object.Destroy(heart.gameObject, heartMoveDuration + 1f);
			})
				.Play();
			DOTween.To(() => heart.GetComponent<CanvasGroup>().alpha, delegate(float x)
			{
				heart.GetComponent<CanvasGroup>().alpha = x;
			}, 0f, heartMoveDuration);
			if (!isDog)
			{
				this.OnCatInteracted?.Invoke(this, EventArgs.Empty);
			}
			else
			{
				this.OnDogInteracted?.Invoke(this, EventArgs.Empty);
			}
		}

		public void CurrentModeID(int ID)
		{
			CurrentModePlaying = ID;
		}

		public void SetFakeModeNumber(Animator currentAnimalAnimator)
		{
			switch (CurrentModePlaying)
			{
			case 5001:
				currentAnimalAnimator.SetInteger("CurrentFakeMode", 5002);
				break;
			case 5002:
				currentAnimalAnimator.SetInteger("CurrentFakeMode", 5003);
				break;
			case 5003:
				currentAnimalAnimator.SetInteger("CurrentFakeMode", 5001);
				break;
			}
		}

		public void OnPointerClick(PointerEventData eventData)
		{
			Debug.Log("Clicked on: " + eventData.pointerCurrentRaycast.gameObject.name);
			currentClickedAnimal = eventData.pointerCurrentRaycast.gameObject.GetComponentInParent<MAnimal>();
			if (!(currentClickedAnimal != null))
			{
				return;
			}
			MAnimalBrain componentInChildren = currentClickedAnimal.transform.root.gameObject.GetComponentInChildren<MAnimalBrain>();
			Animator component = currentClickedAnimal.GetComponent<Animator>();
			MAIState currentState = componentInChildren.currentState;
			HeartPopUp();
			if (currentState != null)
			{
				switch (currentState.ID)
				{
				case 43:
					component.SetTrigger("SwitchSleep");
					SetFakeModeNumber(component);
					break;
				case 51:
					component.SetTrigger("CaressSit");
					break;
				case 52:
					component.SetTrigger("CaressSit");
					break;
				case 55:
					component.SetTrigger("CaressSit");
					break;
				case 53:
					component.SetTrigger("CaressLie");
					break;
				case 40:
					component.SetTrigger("CaressIdle");
					break;
				case 47:
					component.SetTrigger("CaressIdle");
					break;
				case 50:
					component.SetTrigger("CaressIdle");
					break;
				default:
					Debug.Log("You should not be seeing this. Report this to the developers");
					break;
				}
			}
		}

		public void OnPointerEnter(PointerEventData eventData)
		{
			Debug.Log("Entered: " + eventData.pointerCurrentRaycast.gameObject.name);
		}

		public void OnPointerExit(PointerEventData eventData)
		{
			Debug.Log("Exited");
		}

		public void ItemPassthroughReceiver(string ItemType)
		{
			Debug.Log("Item Type Received: " + ItemType);
			if (animalBrain == null)
			{
				animalBrain = base.gameObject.GetComponentInChildren<MAnimalBrain>();
			}
			if (!(animalBrain != null))
			{
				return;
			}
			MAIState currentState = animalBrain.currentState;
			switch (ItemType)
			{
			case "Null":
				ItemIsMoving = false;
				break;
			case "Misc":
				if ((int)currentState.ID == 43 || (int)currentState.ID == 53 || (int)currentState.ID == 55)
				{
					ItemIsMoving = false;
				}
				else if ((int)currentState.ID == 40 || (int)currentState.ID == 47 || (int)currentState.ID == 51 || (int)currentState.ID == 52)
				{
					AIControlComp.enabled = false;
					animalBrain.enabled = false;
					StartCoroutine(PlayMode(4008));
				}
				break;
			case "Bed":
				ItemIsMoving = true;
				if ((int)currentState.ID != 43 && (int)currentState.ID != 53 && (int)currentState.ID != 55)
				{
					if ((int)currentState.ID == 40 || (int)currentState.ID == 47 || (int)currentState.ID == 51 || (int)currentState.ID == 52)
					{
						AIControlComp.enabled = false;
						animalBrain.enabled = false;
						StartCoroutine(PlayMode(4008));
					}
					if ((int)currentState.ID == 41)
					{
						StartCoroutine(CatFollowsTarget());
						animalBrain.enabled = true;
					}
				}
				break;
			case "CatBowl":
				ItemIsMoving = true;
				if ((int)currentState.ID != 43 && (int)currentState.ID != 53 && (int)currentState.ID != 55)
				{
					if ((int)currentState.ID == 40 || (int)currentState.ID == 47 || (int)currentState.ID == 51 || (int)currentState.ID == 52)
					{
						AIControlComp.enabled = false;
						animalBrain.enabled = false;
						StartCoroutine(PlayMode(4008));
					}
					if ((int)currentState.ID == 46)
					{
						StartCoroutine(CatFollowsTarget());
						animalBrain.enabled = true;
					}
				}
				break;
			case "ScratchPost":
				ItemIsMoving = true;
				if ((int)currentState.ID != 43 && (int)currentState.ID != 53 && (int)currentState.ID != 55)
				{
					if ((int)currentState.ID == 40 || (int)currentState.ID == 47 || (int)currentState.ID == 51 || (int)currentState.ID == 52)
					{
						AIControlComp.enabled = false;
						animalBrain.enabled = false;
						StartCoroutine(PlayMode(4008));
					}
					if ((int)currentState.ID == 49)
					{
						StartCoroutine(CatFollowsTarget());
						animalBrain.enabled = true;
					}
				}
				break;
			case "Exit":
				AIControlComp.enabled = true;
				animalBrain.enabled = true;
				ItemIsMoving = false;
				break;
			}
		}

		public void SetExitBool(bool state)
		{
			if (currentClickedAnimal == null)
			{
				currentClickedAnimal = base.gameObject.GetComponent<MAnimal>();
			}
			if (currentClickedAnimal != null)
			{
				currentClickedAnimal.GetComponent<Animator>().SetBool("CanExitSleep", state);
				currentClickedAnimal.GetComponent<Animator>().SetInteger("CurrentFakeMode", CurrentModePlaying);
			}
		}

		public IEnumerator CatFollowsTarget()
		{
			if (animalBrain == null)
			{
				animalBrain = base.gameObject.GetComponentInChildren<MAnimalBrain>();
			}
			if (AIControl == null)
			{
				AIControl = base.gameObject.GetComponentInChildren<IAIControl>();
			}
			if (animalBrain != null && AIControl != null)
			{
				animalBrain.enabled = false;
				while (ItemIsMoving)
				{
					AIControl.Target = ItemGhostVar.Value;
					Vector3 position = ItemGhostVar.Value.position;
					AIControl.SetDestination(position, move: true);
					yield return new WaitForSeconds(AIUpdateCycleTime);
				}
			}
		}

		public IEnumerator PlayMode(int Mode)
		{
			if (currentClickedAnimal == null)
			{
				currentClickedAnimal = base.gameObject.GetComponent<MAnimal>();
			}
			if (animalBrain == null)
			{
				animalBrain = base.gameObject.GetComponentInChildren<MAnimalBrain>();
			}
			if (currentClickedAnimal != null)
			{
				animalBrain.enabled = false;
				yield return new WaitForSeconds(0.5f);
				currentClickedAnimal.Mode_ForceActivate(Mode);
				yield return new WaitUntil(() => !ItemIsMoving);
				yield return new WaitForSeconds(0.5f);
				animalBrain.enabled = true;
			}
		}
	}
}
