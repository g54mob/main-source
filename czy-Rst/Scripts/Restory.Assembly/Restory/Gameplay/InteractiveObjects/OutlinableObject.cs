using Restory.Data.Outline;
using Restory.Gameplay.Common;
using UnityEngine;

namespace Restory.Gameplay.InteractiveObjects
{
	public class OutlinableObject : MonoBehaviour
	{
		[SerializeField]
		private InteractiveObject interactiveObject;

		[SerializeField]
		private OutlineSettingsPreset selectedPreset;

		[SerializeField]
		private OutlineSettingsPreset collidingPreset;

		[SerializeField]
		private OutlinableAdapter outlinableAdapter;

		private void OnEnable()
		{
			interactiveObject.OnSelected += ResolveSelect;
			interactiveObject.OnDeselected += ResolveDeselect;
			interactiveObject.OnDragStateChanged += ResolveDragStateChanged;
		}

		private void OnDisable()
		{
			interactiveObject.OnSelected -= ResolveSelect;
			interactiveObject.OnDeselected -= ResolveDeselect;
			interactiveObject.OnDragStateChanged -= ResolveDragStateChanged;
			outlinableAdapter.IsActive = false;
		}

		private void ResolveSelect()
		{
			outlinableAdapter.OverridePreset = selectedPreset;
			outlinableAdapter.IsActive = true;
		}

		private void ResolveDeselect()
		{
			outlinableAdapter.IsActive = false;
		}

		private void ResolveDragStateChanged(InteractiveObjectDragState dragState)
		{
			switch (dragState)
			{
			case InteractiveObjectDragState.None:
			case InteractiveObjectDragState.FreeSoared:
				outlinableAdapter.IsActive = false;
				break;
			case InteractiveObjectDragState.Storable:
			case InteractiveObjectDragState.Shippable:
				outlinableAdapter.OverridePreset = selectedPreset;
				outlinableAdapter.IsActive = true;
				break;
			default:
				outlinableAdapter.OverridePreset = collidingPreset;
				outlinableAdapter.IsActive = true;
				break;
			}
		}
	}
}
