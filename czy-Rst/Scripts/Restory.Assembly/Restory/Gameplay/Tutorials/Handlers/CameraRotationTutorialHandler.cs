using System.Linq;
using Restory.Data.ToDoList;
using Restory.Data.Tutorials;
using Restory.Gameplay.GameView;
using Restory.Gameplay.ToDoList;
using Restory.Gameplay.Tutorials.Settings;
using Restory.UI.Views.Tooltips;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.Tutorials.Handlers
{
	public class CameraRotationTutorialHandler : TutorialHandlerBase
	{
		private readonly DiContainer diContainer;

		private readonly ToDoListService toDoListService;

		private readonly CameraDirectionSwitcher cameraDirectionSwitcher;

		private readonly TooltipContainer tooltipContainer;

		private readonly CameraRotationTutorialSettings settings;

		private GUI_ArrowTooltip arrowTooltip;

		private bool isActivated;

		[Inject]
		public CameraRotationTutorialHandler(DiContainer diContainer, ToDoListService toDoListService, CameraDirectionSwitcher cameraDirectionSwitcher, TooltipContainer tooltipContainer, CameraRotationTutorial tutorial)
			: base(tutorial)
		{
			this.diContainer = diContainer;
			this.toDoListService = toDoListService;
			this.cameraDirectionSwitcher = cameraDirectionSwitcher;
			this.tooltipContainer = tooltipContainer;
			settings = tutorial.Settings;
		}

		public override void Init()
		{
			cameraDirectionSwitcher.OnCameraDirectionChanged += ResolveCameraDirectionChanged;
			toDoListService.OnIsActiveChanged += ResolveToDoServiceIsActiveChanged;
			toDoListService.OnCompleted += ResolveToDoItemCompleted;
			if (toDoListService.IsActive)
			{
				CheckIfTargetItemExists();
			}
		}

		public override void Cleanup()
		{
			cameraDirectionSwitcher.OnCameraDirectionChanged -= ResolveCameraDirectionChanged;
			toDoListService.OnIsActiveChanged -= ResolveToDoServiceIsActiveChanged;
			toDoListService.OnCompleted -= ResolveToDoItemCompleted;
			DestroyArrowTooltip();
		}

		private void ResolveCameraDirectionChanged()
		{
			if (base.IsCompleted)
			{
				return;
			}
			CameraDirection currentDirection = cameraDirectionSwitcher.CurrentDirection;
			if (currentDirection == CameraDirection.Left || currentDirection == CameraDirection.Right)
			{
				Complete();
			}
			else if (isActivated)
			{
				if (cameraDirectionSwitcher.CurrentDirection == CameraDirection.Main)
				{
					CreateArrowTooltip();
				}
				else
				{
					DestroyArrowTooltip();
				}
			}
		}

		private void ResolveToDoServiceIsActiveChanged(ToDoListService _)
		{
			if (!base.IsCompleted && toDoListService.IsActive)
			{
				CheckIfTargetItemExists();
			}
		}

		private void ResolveToDoItemCompleted(ToDoListService _, ToDoItem item)
		{
			if (!base.IsCompleted && settings.TargetToDoItem == item)
			{
				Activate();
			}
		}

		private void CheckIfTargetItemExists()
		{
			if (!toDoListService.Items.Contains(settings.TargetToDoItem))
			{
				Activate();
			}
		}

		private void Activate()
		{
			isActivated = true;
			if (cameraDirectionSwitcher.CurrentDirection == CameraDirection.Main)
			{
				CreateArrowTooltip();
			}
		}

		private void Complete()
		{
			if (!base.IsCompleted)
			{
				CompleteTutorial();
			}
		}

		private void CreateArrowTooltip()
		{
			if (!arrowTooltip)
			{
				arrowTooltip = diContainer.InstantiatePrefabForComponent<GUI_ArrowTooltip>(settings.ArrowTooltipPrefab.gameObject, tooltipContainer.transform);
			}
		}

		private void DestroyArrowTooltip()
		{
			if ((bool)arrowTooltip)
			{
				Object.Destroy(arrowTooltip.gameObject);
			}
		}
	}
}
