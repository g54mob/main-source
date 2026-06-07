using System;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace NewGameplayScripts
{
	public class SwitchFloorButton : MonoBehaviour
	{
		[SerializeField]
		private UnityEngine.Object SecondFloor;

		[SerializeField]
		private UnityEngine.Object OutSideWalls;

		[SerializeField]
		private UnityEngine.Object FirstFloorBoundary;

		[SerializeField]
		private UnityEngine.Object SecondFloorBoundary;

		[SerializeField]
		private Transform CameraTarget;

		[SerializeField]
		private Button upButton;

		[SerializeField]
		private Button downButton;

		[SerializeField]
		private Transform scaleTransform;

		private bool showSecondFloor;

		public Vector3 CameraFirstFloorPosition = new Vector3(-3.77f, 0f, -3.67f);

		public Vector3 CameraSecondFloorPosition = new Vector3(-1.83f, 0f, 3.91f);

		private Sequence showAnimation;

		public event Action SwitchFloorAction;

		private void Start()
		{
			PlantCreatingSystem instance = PlantCreatingSystem.Instance;
			instance.OnPlantsLoaded = (Action)Delegate.Combine(instance.OnPlantsLoaded, new Action(SwitchFloor));
			InputManager instance2 = InputManager.Instance;
			instance2.OnFloorUp = (Action)Delegate.Combine(instance2.OnFloorUp, new Action(SwitchFloorUP));
			InputManager instance3 = InputManager.Instance;
			instance3.OnFloorDown = (Action)Delegate.Combine(instance3.OnFloorDown, new Action(SwitchFloorDown));
		}

		private void SwitchFloorDown()
		{
			if (downButton.interactable)
			{
				SwitchFloor();
			}
		}

		private void SwitchFloorUP()
		{
			if (upButton.interactable)
			{
				SwitchFloor();
			}
		}

		public void SwitchFloor()
		{
			if (!MovementSystem.Instance.IsMoving() || InputManager.Instance.gamePause)
			{
				this.SwitchFloorAction?.Invoke();
				showSecondFloor = !showSecondFloor;
				upButton.interactable = !showSecondFloor;
				downButton.interactable = showSecondFloor;
				SecondFloor.GameObject().SetActive(showSecondFloor);
				if (OutSideWalls != null)
				{
					OutSideWalls.GameObject().SetActive(showSecondFloor);
				}
				SecondFloorBoundary.GameObject().SetActive(showSecondFloor);
				FirstFloorBoundary.GameObject().SetActive(!showSecondFloor);
				PlantsOnSceneCollection.Instance.SwitchSecondFloorCollection(showSecondFloor);
				PlantsOnSceneCollection.Instance.SwitchItemsMoveOnFirstFloorPossibility(!showSecondFloor);
				EnvironmentManager.Instance.SwitchSecondFloorEnvironments(showSecondFloor);
				MovementSystem.Instance.SwitchItemsMoveOnFirstFloorPossibility(!showSecondFloor);
				CameraTarget.DOMove(showSecondFloor ? CameraSecondFloorPosition : CameraFirstFloorPosition, 1f);
			}
		}

		private void OnDestroy()
		{
			PlantCreatingSystem instance = PlantCreatingSystem.Instance;
			instance.OnPlantsLoaded = (Action)Delegate.Remove(instance.OnPlantsLoaded, new Action(SwitchFloor));
			InputManager instance2 = InputManager.Instance;
			instance2.OnFloorUp = (Action)Delegate.Remove(instance2.OnFloorUp, new Action(SwitchFloorUP));
			InputManager instance3 = InputManager.Instance;
			instance3.OnFloorDown = (Action)Delegate.Remove(instance3.OnFloorDown, new Action(SwitchFloorDown));
			showAnimation.Kill();
		}

		public void HideFloorButton()
		{
			base.gameObject.SetActive(value: false);
		}

		public void ShowFloorButton()
		{
			base.gameObject.SetActive(value: true);
			showAnimation = DOTween.Sequence();
			scaleTransform.localScale = Vector3.zero;
			showAnimation.Append(scaleTransform.DOScale(1.2f, 0.5f).SetEase(Ease.OutExpo)).Append(scaleTransform.DOScale(0.9f, 0.1f).SetEase(Ease.InOutSine)).Append(scaleTransform.DOScale(1f, 0.1f).SetEase(Ease.InOutSine))
				.Play();
		}
	}
}
