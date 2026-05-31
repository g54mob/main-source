using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace SoulGames.EasyGridBuilderPro
{
	[RequireComponent(typeof(MultiGridManager))]
	public class MultiGridInputManager : MonoBehaviour
	{
		[Tooltip("Add currently using Easy Grid Builder Pro Input SO asset")]
		[SerializeField]
		private EasyGridBuilderProInputsSO easyGridBuilderProInputsSO;

		[Tooltip("Add Grid Object Selector script")]
		[SerializeField]
		private GridObjectSelector gridObjectSelector;

		private GridObjectMover gridObjectMover;

		private FreeObjectMover freeObjectMover;

		private List<EasyGridBuilderPro> easyGridBuilderProList;

		public static MultiGridInputManager Instance { get; private set; }

		private void OnEnable()
		{
			easyGridBuilderProInputsSO.gridModeResetKey.Enable();
			easyGridBuilderProInputsSO.gridHeightChangeKey.Enable();
			easyGridBuilderProInputsSO.buildModeActivationKey.Enable();
			easyGridBuilderProInputsSO.buildablePlacementKey.Enable();
			easyGridBuilderProInputsSO.buildableListScrollKey.Enable();
			easyGridBuilderProInputsSO.ghostRotateLeftKey.Enable();
			easyGridBuilderProInputsSO.ghostRotateRightKey.Enable();
			easyGridBuilderProInputsSO.destructionModeActivationKey.Enable();
			easyGridBuilderProInputsSO.buildableDestroyKey.Enable();
			easyGridBuilderProInputsSO.selectionModeActivationKey.Enable();
			easyGridBuilderProInputsSO.buildableSelectionKey.Enable();
			easyGridBuilderProInputsSO.gridSaveKey.Enable();
			easyGridBuilderProInputsSO.gridLoadKey.Enable();
		}

		private void OnDisable()
		{
			easyGridBuilderProInputsSO.gridModeResetKey.performed -= delegate(InputAction.CallbackContext context)
			{
				GridModeResetKey(context);
			};
			easyGridBuilderProInputsSO.gridHeightChangeKey.performed -= delegate(InputAction.CallbackContext context)
			{
				GridHeightChangeKey(context);
			};
			easyGridBuilderProInputsSO.buildModeActivationKey.performed -= delegate(InputAction.CallbackContext context)
			{
				BuildModeActivationKey(context);
			};
			easyGridBuilderProInputsSO.buildablePlacementKey.performed -= delegate(InputAction.CallbackContext context)
			{
				BuildablePlacementKey(context);
			};
			easyGridBuilderProInputsSO.buildablePlacementKey.canceled -= delegate(InputAction.CallbackContext context)
			{
				BuildablePlacementKeyCancelled(context);
			};
			easyGridBuilderProInputsSO.buildableListScrollKey.performed -= delegate(InputAction.CallbackContext context)
			{
				BuildableListScrollKey(context);
			};
			easyGridBuilderProInputsSO.ghostRotateLeftKey.performed -= delegate(InputAction.CallbackContext context)
			{
				GhostRotateLeftKey(context);
			};
			easyGridBuilderProInputsSO.ghostRotateLeftKey.canceled -= delegate(InputAction.CallbackContext context)
			{
				GhostRotateLeftKeyCancelled(context);
			};
			easyGridBuilderProInputsSO.ghostRotateRightKey.performed -= delegate(InputAction.CallbackContext context)
			{
				GhostRotateRightKey(context);
			};
			easyGridBuilderProInputsSO.ghostRotateRightKey.canceled -= delegate(InputAction.CallbackContext context)
			{
				GhostRotateRightKeyCancelled(context);
			};
			easyGridBuilderProInputsSO.destructionModeActivationKey.performed -= delegate(InputAction.CallbackContext context)
			{
				DestructionModeActivationKey(context);
			};
			easyGridBuilderProInputsSO.buildableDestroyKey.performed -= delegate(InputAction.CallbackContext context)
			{
				BuildableDestroyKey(context);
			};
			easyGridBuilderProInputsSO.selectionModeActivationKey.performed -= delegate(InputAction.CallbackContext context)
			{
				SelectionModeActivationKey(context);
			};
			easyGridBuilderProInputsSO.buildableSelectionKey.performed -= delegate(InputAction.CallbackContext context)
			{
				BuildableSelectionKey(context);
			};
			easyGridBuilderProInputsSO.gridSaveKey.performed -= delegate(InputAction.CallbackContext context)
			{
				GridSaveKey(context);
			};
			easyGridBuilderProInputsSO.gridLoadKey.performed -= delegate(InputAction.CallbackContext context)
			{
				GridLoadKey(context);
			};
			easyGridBuilderProInputsSO.gridModeResetKey.Disable();
			easyGridBuilderProInputsSO.gridHeightChangeKey.Disable();
			easyGridBuilderProInputsSO.buildModeActivationKey.Disable();
			easyGridBuilderProInputsSO.buildablePlacementKey.Disable();
			easyGridBuilderProInputsSO.buildableListScrollKey.Disable();
			easyGridBuilderProInputsSO.ghostRotateLeftKey.Disable();
			easyGridBuilderProInputsSO.ghostRotateRightKey.Disable();
			easyGridBuilderProInputsSO.destructionModeActivationKey.Disable();
			easyGridBuilderProInputsSO.buildableDestroyKey.Disable();
			easyGridBuilderProInputsSO.selectionModeActivationKey.Disable();
			easyGridBuilderProInputsSO.buildableSelectionKey.Disable();
			easyGridBuilderProInputsSO.gridSaveKey.Disable();
			easyGridBuilderProInputsSO.gridLoadKey.Disable();
		}

		private void Awake()
		{
			Instance = this;
		}

		private void Start()
		{
			easyGridBuilderProList = MultiGridManager.Instance.easyGridBuilderProList;
			foreach (EasyGridBuilderPro easyGridBuilderPro in easyGridBuilderProList)
			{
				easyGridBuilderPro.SetInputGridModeVariables(easyGridBuilderProInputsSO.useBuildModeActivationKey, easyGridBuilderProInputsSO.useDestructionModeActivationKey, easyGridBuilderProInputsSO.useSelectionModeActivationKey);
			}
			if ((bool)gridObjectSelector)
			{
				gridObjectSelector.SetInputGridModeVariables(easyGridBuilderProInputsSO.useBuildModeActivationKey, easyGridBuilderProInputsSO.useDestructionModeActivationKey, easyGridBuilderProInputsSO.useSelectionModeActivationKey);
			}
			if ((bool)gridObjectMover)
			{
				gridObjectMover.SetInputGridModeVariables(easyGridBuilderProInputsSO.useBuildModeActivationKey, easyGridBuilderProInputsSO.useDestructionModeActivationKey, easyGridBuilderProInputsSO.useSelectionModeActivationKey);
			}
			if ((bool)freeObjectMover)
			{
				freeObjectMover.SetInputGridModeVariables(easyGridBuilderProInputsSO.useBuildModeActivationKey, easyGridBuilderProInputsSO.useDestructionModeActivationKey, easyGridBuilderProInputsSO.useSelectionModeActivationKey);
			}
			easyGridBuilderProInputsSO.gridModeResetKey.performed += delegate(InputAction.CallbackContext context)
			{
				GridModeResetKey(context);
			};
			easyGridBuilderProInputsSO.gridHeightChangeKey.performed += delegate(InputAction.CallbackContext context)
			{
				GridHeightChangeKey(context);
			};
			easyGridBuilderProInputsSO.buildModeActivationKey.performed += delegate(InputAction.CallbackContext context)
			{
				BuildModeActivationKey(context);
			};
			easyGridBuilderProInputsSO.buildablePlacementKey.performed += delegate(InputAction.CallbackContext context)
			{
				BuildablePlacementKey(context);
			};
			easyGridBuilderProInputsSO.buildablePlacementKey.canceled += delegate(InputAction.CallbackContext context)
			{
				BuildablePlacementKeyCancelled(context);
			};
			easyGridBuilderProInputsSO.buildableListScrollKey.performed += delegate(InputAction.CallbackContext context)
			{
				BuildableListScrollKey(context);
			};
			easyGridBuilderProInputsSO.ghostRotateLeftKey.performed += delegate(InputAction.CallbackContext context)
			{
				GhostRotateLeftKey(context);
			};
			easyGridBuilderProInputsSO.ghostRotateLeftKey.canceled += delegate(InputAction.CallbackContext context)
			{
				GhostRotateLeftKeyCancelled(context);
			};
			easyGridBuilderProInputsSO.ghostRotateRightKey.performed += delegate(InputAction.CallbackContext context)
			{
				GhostRotateRightKey(context);
			};
			easyGridBuilderProInputsSO.ghostRotateRightKey.canceled += delegate(InputAction.CallbackContext context)
			{
				GhostRotateRightKeyCancelled(context);
			};
			easyGridBuilderProInputsSO.destructionModeActivationKey.performed += delegate(InputAction.CallbackContext context)
			{
				DestructionModeActivationKey(context);
			};
			easyGridBuilderProInputsSO.buildableDestroyKey.performed += delegate(InputAction.CallbackContext context)
			{
				BuildableDestroyKey(context);
			};
			easyGridBuilderProInputsSO.selectionModeActivationKey.performed += delegate(InputAction.CallbackContext context)
			{
				SelectionModeActivationKey(context);
			};
			easyGridBuilderProInputsSO.buildableSelectionKey.performed += delegate(InputAction.CallbackContext context)
			{
				BuildableSelectionKey(context);
			};
			easyGridBuilderProInputsSO.gridSaveKey.performed += delegate(InputAction.CallbackContext context)
			{
				GridSaveKey(context);
			};
			easyGridBuilderProInputsSO.gridLoadKey.performed += delegate(InputAction.CallbackContext context)
			{
				GridLoadKey(context);
			};
		}

		public EasyGridBuilderProInputsSO GetEasyGridBuilderProInputsSO()
		{
			return easyGridBuilderProInputsSO;
		}

		private void GridHeightChangeKey(InputAction.CallbackContext context)
		{
			foreach (EasyGridBuilderPro easyGridBuilderPro in easyGridBuilderProList)
			{
				easyGridBuilderPro.TriggerGridHeightChangeManually();
			}
		}

		private void GridModeResetKey(InputAction.CallbackContext context)
		{
			foreach (EasyGridBuilderPro easyGridBuilderPro in easyGridBuilderProList)
			{
				easyGridBuilderPro.SetGridModeReset();
			}
			if ((bool)gridObjectSelector)
			{
				gridObjectSelector.SetGridModeReset();
			}
			if ((bool)gridObjectMover)
			{
				gridObjectMover.SetGridModeReset();
			}
			if ((bool)freeObjectMover)
			{
				freeObjectMover.SetGridModeReset();
			}
		}

		private void BuildModeActivationKey(InputAction.CallbackContext context)
		{
			if (!easyGridBuilderProInputsSO.useBuildModeActivationKey)
			{
				return;
			}
			foreach (EasyGridBuilderPro easyGridBuilderPro in easyGridBuilderProList)
			{
				easyGridBuilderPro.SetGridModeBuilding();
			}
		}

		private void BuildablePlacementKey(InputAction.CallbackContext context)
		{
			foreach (EasyGridBuilderPro easyGridBuilderPro in easyGridBuilderProList)
			{
				easyGridBuilderPro.TriggerBuildablePlacement();
			}
		}

		private void BuildablePlacementKeyCancelled(InputAction.CallbackContext context)
		{
			foreach (EasyGridBuilderPro easyGridBuilderPro in easyGridBuilderProList)
			{
				easyGridBuilderPro.TriggerBuildablePlacementCancelled();
			}
		}

		private void BuildableListScrollKey(InputAction.CallbackContext context)
		{
			foreach (EasyGridBuilderPro easyGridBuilderPro in easyGridBuilderProList)
			{
				easyGridBuilderPro.TriggerBuildableListScroll(easyGridBuilderProInputsSO.buildableListScrollKey.ReadValue<Vector2>());
			}
		}

		private void GhostRotateLeftKey(InputAction.CallbackContext context)
		{
			foreach (EasyGridBuilderPro easyGridBuilderPro in easyGridBuilderProList)
			{
				easyGridBuilderPro.TriggerGhostRotateLeft();
			}
		}

		private void GhostRotateLeftKeyCancelled(InputAction.CallbackContext context)
		{
			foreach (EasyGridBuilderPro easyGridBuilderPro in easyGridBuilderProList)
			{
				easyGridBuilderPro.TriggerGhostRotateLeftCancelled();
			}
		}

		private void GhostRotateRightKey(InputAction.CallbackContext context)
		{
			foreach (EasyGridBuilderPro easyGridBuilderPro in easyGridBuilderProList)
			{
				easyGridBuilderPro.TriggerGhostRotateRight();
			}
		}

		private void GhostRotateRightKeyCancelled(InputAction.CallbackContext context)
		{
			foreach (EasyGridBuilderPro easyGridBuilderPro in easyGridBuilderProList)
			{
				easyGridBuilderPro.TriggerGhostRotateRightCancelled();
			}
		}

		private void DestructionModeActivationKey(InputAction.CallbackContext context)
		{
			if (!easyGridBuilderProInputsSO.useDestructionModeActivationKey)
			{
				return;
			}
			foreach (EasyGridBuilderPro easyGridBuilderPro in easyGridBuilderProList)
			{
				easyGridBuilderPro.SetGridModeDestruction();
			}
		}

		private void BuildableDestroyKey(InputAction.CallbackContext context)
		{
			foreach (EasyGridBuilderPro easyGridBuilderPro in easyGridBuilderProList)
			{
				easyGridBuilderPro.TriggerBuildableDestroy();
			}
		}

		private void SelectionModeActivationKey(InputAction.CallbackContext context)
		{
			if (easyGridBuilderProInputsSO.useSelectionModeActivationKey)
			{
				gridObjectSelector.SetGridModeSelection();
			}
		}

		private void BuildableSelectionKey(InputAction.CallbackContext context)
		{
			gridObjectSelector.TriggerBuildableSelection();
		}

		private void MoveModeActivationKey(InputAction.CallbackContext context)
		{
		}

		private void BuildableMoveKey(InputAction.CallbackContext context)
		{
			if ((bool)gridObjectMover)
			{
				gridObjectMover.TriggerBuildableMove();
			}
			if ((bool)freeObjectMover)
			{
				freeObjectMover.SetGridModeMoving();
			}
		}

		private void GridSaveKey(InputAction.CallbackContext context)
		{
			foreach (EasyGridBuilderPro easyGridBuilderPro in easyGridBuilderProList)
			{
				easyGridBuilderPro.TriggerGridSave();
			}
		}

		private void GridLoadKey(InputAction.CallbackContext context)
		{
			foreach (EasyGridBuilderPro easyGridBuilderPro in easyGridBuilderProList)
			{
				easyGridBuilderPro.TriggerGridLoad();
			}
		}
	}
}
