using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using Infrastructure.Services.PersistentProgress;
using NewGameplayScripts;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Infrastructure.Services.BoxService
{
	public class BoxOnLevel : MonoBehaviour, IPointerClickHandler, IEventSystemHandler, IPointerEnterHandler, IPointerExitHandler, ISavedProgress, ISavedProgressReader
	{
		[SerializeField]
		private List<Transform> itemsInBox;

		[SerializeField]
		private Outline outline;

		[SerializeField]
		private Animator animator;

		[SerializeField]
		private GameObject secondFloor;

		public Action OnOpenedBox;

		public bool boxIsFinished;

		public bool firstFloorBox;

		private int currentItemNumber;

		private IBoxService boxService;

		private string MoveId;

		private bool open;

		private bool hide;

		private float lastClickTime;

		private float doubleClickThreshold = 0.3f;

		private void Awake()
		{
			boxService = AllServices.Container.Single<IBoxService>();
			MoveId = base.transform.position.x.ToString() + base.transform.position.y + base.transform.position.z;
			boxService.SetCurrentBoxes(this);
		}

		private void Start()
		{
			for (int i = 0; i < itemsInBox.Count; i++)
			{
				if (i >= currentItemNumber)
				{
					itemsInBox[i].gameObject.SetActive(value: false);
				}
			}
		}

		private void OnEnable()
		{
			if (open)
			{
				animator.Play("Box_Opened_Idle");
			}
			if (hide)
			{
				base.gameObject.SetActive(value: false);
			}
		}

		public void OnPointerClick(PointerEventData eventData)
		{
			if ((firstFloorBox && secondFloor.activeInHierarchy) || MovementSystem.Instance.IsMoving() || currentItemNumber >= itemsInBox.Count || Time.time - lastClickTime < doubleClickThreshold)
			{
				return;
			}
			lastClickTime = Time.time;
			if (!open)
			{
				animator.SetBool("Open", value: true);
				SoundManager.Instance.OnBoxOpen();
				OnOpenedBox?.Invoke();
				open = true;
				return;
			}
			animator.SetTrigger("TakeItem");
			Transform item = itemsInBox[currentItemNumber];
			item.transform.position = base.transform.position;
			Vector3 endValue = base.transform.position + new Vector3(0f, 2f, 0f);
			item.gameObject.SetActive(value: true);
			SoundManager.Instance.OnBoxTakeItem();
			item.GetComponent<IMovable>().StartMoving();
			item.GetComponent<IMovable>().ToggleOutline(value: true);
			item.transform.DOMove(endValue, 0.3f).SetEase(Ease.OutBack).OnComplete(delegate
			{
				MoveToCursor(item);
			});
			currentItemNumber++;
			if (currentItemNumber >= itemsInBox.Count)
			{
				boxIsFinished = true;
				StartCoroutine(Disappear());
			}
		}

		private IEnumerator Disappear()
		{
			hide = true;
			animator.SetBool("Disappear", value: true);
			SoundManager.Instance.OnBoxDisappear();
			yield return new WaitForSeconds(5f);
			base.gameObject.SetActive(value: false);
		}

		private void MoveToCursor(Transform item)
		{
			MovementSystem.Instance.StartMovingTransform(item.transform, isCreated: false, item.GetComponent<IMovable>());
		}

		public void OnPointerEnter(PointerEventData eventData)
		{
			if ((!firstFloorBox || !secondFloor.activeInHierarchy) && !MovementSystem.Instance.IsMoving())
			{
				ToggleOutline(value: true);
			}
		}

		public void OnPointerExit(PointerEventData eventData)
		{
			ToggleOutline(value: false);
		}

		private void ToggleOutline(bool value)
		{
			if (outline != null)
			{
				outline.enabled = value;
			}
		}

		public void LoadProgress(PlayerProgress progress)
		{
			foreach (KeyValuePair<string, int> item in progress.BoxesOnLevel.Where((KeyValuePair<string, int> box) => box.Key == MoveId))
			{
				currentItemNumber = item.Value;
				if (currentItemNumber >= itemsInBox.Count)
				{
					boxIsFinished = true;
					base.gameObject.SetActive(value: false);
				}
				if (currentItemNumber != 0)
				{
					open = true;
					animator.SetBool("Open", value: true);
				}
				for (int num = 0; num < itemsInBox.Count; num++)
				{
					if (num < currentItemNumber)
					{
						itemsInBox[num].gameObject.SetActive(value: true);
					}
				}
			}
		}

		public void UpdateProgress(PlayerProgress progress)
		{
			if (progress.BoxesOnLevel.ContainsKey(MoveId))
			{
				progress.BoxesOnLevel[MoveId] = currentItemNumber;
			}
			else
			{
				progress.BoxesOnLevel.Add(MoveId, currentItemNumber);
			}
		}
	}
}
