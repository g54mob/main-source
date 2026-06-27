using System;
using Restory.Constants;
using Restory.Data.Elements;
using Restory.Data.Equipment;
using Restory.Gameplay.Disassemble.StateMachine;
using Restory.Gameplay.Elements;
using Restory.Gameplay.Equipment;
using Restory.Gameplay.Equipment.DevicePaintingTools;
using Restory.Gameplay.Work.StateMachine;
using Restory.Infrastructure.StateMachine;
using Restory.Infrastructure.StateMachine.States;
using Restory.Infrastructure.StateMachine.States.Interfaces;
using Restory.UI.Presenters;
using Restory.UserInterface;
using Restory.Utils;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Restory.Gameplay.GameCursor
{
	public sealed class VirtualCursorPresenter : IInitializable, IDisposable
	{
		private readonly CursorIcons cursorIcons;

		private readonly DisassembleToolCursor disassembleToolCursor;

		private readonly VirtualCursorView virtualCursor;

		private readonly WorkStateMachine workStateMachine;

		private readonly DisassembleStateMachine disassembleStateMachine;

		private readonly CursorSelectionService cursorSelectionService;

		private readonly CleaningToolSelectionService cleaningToolSelectionService;

		private readonly PaintingBrush paintingBrush;

		private readonly GlobalStateMachine globalStateMachine;

		public Vector2 ScreenPosition => virtualCursor.ScreenPosition;

		public VirtualCursorPresenter(VirtualCursorView virtualCursor, CursorIcons cursorIcons, DisassembleToolCursor disassembleToolCursor, WorkStateMachine workStateMachine, DisassembleStateMachine disassembleStateMachine, CursorSelectionService cursorSelectionService, CleaningToolSelectionService cleaningToolSelectionService, PaintingBrush paintingBrush, GlobalStateMachine globalStateMachine)
		{
			this.cleaningToolSelectionService = cleaningToolSelectionService;
			this.virtualCursor = virtualCursor;
			this.cursorIcons = cursorIcons;
			this.disassembleToolCursor = disassembleToolCursor;
			this.globalStateMachine = globalStateMachine;
			this.workStateMachine = workStateMachine;
			this.disassembleStateMachine = disassembleStateMachine;
			this.cursorSelectionService = cursorSelectionService;
			this.paintingBrush = paintingBrush;
		}

		public void Initialize()
		{
			workStateMachine.OnStateChanged.AddListener(ResolveWorkStateChanged);
			disassembleStateMachine.OnStateChanged.AddListener(ResolveDisassembleStateChanged);
			cursorSelectionService.OnDetectionStateChanged += ResolveDetectionStateChanged;
			virtualCursor.SetIcon(cursorIcons.DefaultCursor);
		}

		public void Dispose()
		{
			if (workStateMachine.MonoShellExists())
			{
				workStateMachine.OnStateChanged.RemoveListener(ResolveWorkStateChanged);
			}
			if (disassembleStateMachine.MonoShellExists())
			{
				disassembleStateMachine.OnStateChanged.RemoveListener(ResolveDisassembleStateChanged);
			}
			if (cursorSelectionService != null)
			{
				cursorSelectionService.OnDetectionStateChanged -= ResolveDetectionStateChanged;
			}
			if (cleaningToolSelectionService.MonoShellExists())
			{
				cleaningToolSelectionService.OnToolSwitched -= ResolveCleaningToolSwitched;
			}
			if (paintingBrush.MonoShellExists())
			{
				paintingBrush.OnCursorSizeChanged -= ResolvePaintingCursorSizeChanged;
			}
		}

		public void SetIcon(Texture2D icon)
		{
			virtualCursor.SetIcon(icon);
		}

		private void ResolveWorkStateChanged()
		{
			if (workStateMachine.ActiveState is DraggingWorkState)
			{
				virtualCursor.SetIcon(cursorIcons.HoldCursor);
			}
			else
			{
				ResolveDetectionStateChanged();
			}
		}

		private void ResolveDisassembleStateChanged()
		{
			paintingBrush.OnCursorSizeChanged -= ResolvePaintingCursorSizeChanged;
			IExitableState activeState = disassembleStateMachine.ActiveState;
			if (!(activeState is DisabledDisassembleState))
			{
				if (!(activeState is DraggingDisassembleState))
				{
					if (!(activeState is TransitionToCleaningDisassembleState))
					{
						if (!(activeState is TransitionFromCleaningDisassembleState))
						{
							if (activeState is PaintingDisassembleState)
							{
								SetPaintingCursorIfNotOverUI();
								paintingBrush.OnCursorSizeChanged += ResolvePaintingCursorSizeChanged;
							}
							else
							{
								ResolveDetectionStateChanged();
							}
						}
						else
						{
							virtualCursor.Visible = false;
							cleaningToolSelectionService.OnToolSwitched -= ResolveCleaningToolSwitched;
						}
					}
					else
					{
						virtualCursor.Visible = false;
						cleaningToolSelectionService.OnToolSwitched += ResolveCleaningToolSwitched;
					}
				}
				else
				{
					virtualCursor.SetIcon(cursorIcons.HoldCursor);
				}
			}
			else
			{
				virtualCursor.SetIcon(cursorIcons.DefaultCursor);
			}
		}

		private void ResolveDetectionStateChanged()
		{
			if (!(workStateMachine.ActiveState is DraggingWorkState) && !(disassembleStateMachine.ActiveState is DraggingDisassembleState))
			{
				if (disassembleStateMachine.ActiveState is CleaningDisassembleState)
				{
					SetToolCursorIfNotOverUI();
				}
				else if (disassembleStateMachine.ActiveState is PaintingDisassembleState)
				{
					SetPaintingCursorIfNotOverUI();
				}
				else
				{
					virtualCursor.SetIcon(GetCursor());
				}
			}
		}

		private void ResolveCleaningToolSwitched()
		{
			SetToolCursorIfNotOverUI();
		}

		private void ResolvePaintingCursorSizeChanged()
		{
			SetPaintingCursorIfNotOverUI();
		}

		private Texture2D GetCursor()
		{
			if (!cursorSelectionService.HasDetection)
			{
				return cursorIcons.DefaultCursor;
			}
			if (globalStateMachine.ActiveState is GamePauseState)
			{
				if (cursorSelectionService.DetectedGameObject.GetComponentInParent<Selectable>() != null)
				{
					return cursorIcons.HoverCursor;
				}
				return cursorIcons.DefaultCursor;
			}
			if (cursorSelectionService.DetectedGameObject.TryGetComponent<RectTransform>(out var _))
			{
				if (!cursorSelectionService.DetectedGameObject.GetComponentInParent<GUI_PcScreen>())
				{
					return cursorIcons.HoverCursor;
				}
				return cursorIcons.InvisibleCursor;
			}
			if (cursorSelectionService.DetectedGameObject.TryGetComponent<ElementBase>(out var component2) && component2.Info.Category == ElementCategory.Small)
			{
				return cursorIcons.UnscrewingCursor;
			}
			if (cursorSelectionService.DetectedGameObject.TryGetComponent<ElementConditionHandler>(out var component3) && component3.ElementData.Info.Category == ElementCategory.Small)
			{
				return cursorIcons.UnscrewingCursor;
			}
			if (cursorSelectionService.DetectedGameObject.TryGetComponent<ElementProjection>(out var _))
			{
				return cursorIcons.ScrewingCursor;
			}
			return cursorIcons.HoverCursor;
		}

		private void SetToolCursorIfNotOverUI()
		{
			if (cursorSelectionService.HasDetection)
			{
				if (cursorSelectionService.DetectedGameObject.layer == ProjectConstants.Layers.Soldering && cleaningToolSelectionService.CurrentlySelectedTool is SolderingToolInfo)
				{
					virtualCursor.SetIcon(cursorIcons.SolderDetectedCursor, cleaningToolSelectionService.CurrentlySelectedTool.CursorSize);
				}
				else
				{
					virtualCursor.SetIcon(cursorIcons.HoverCursor);
				}
			}
			else if ((bool)cleaningToolSelectionService.CurrentlySelectedTool)
			{
				if (cleaningToolSelectionService.CurrentlySelectedTool is SolderingToolInfo)
				{
					virtualCursor.SetIcon(cursorIcons.SoldererIdleCursor, cleaningToolSelectionService.CurrentlySelectedTool.CursorSize);
					return;
				}
				disassembleToolCursor.SetSize(cleaningToolSelectionService.CurrentlySelectedTool.CursorSize);
				virtualCursor.SetSpecialCursor(disassembleToolCursor);
			}
			else
			{
				virtualCursor.SetIcon(cursorIcons.DefaultCursor);
			}
		}

		private void SetPaintingCursorIfNotOverUI()
		{
			if (cursorSelectionService.HasDetection)
			{
				virtualCursor.SetIcon(cursorIcons.HoverCursor);
				return;
			}
			disassembleToolCursor.SetSize(paintingBrush.CursorSize);
			virtualCursor.SetSpecialCursor(disassembleToolCursor);
		}
	}
}
