using System;
using Restory.Gameplay.Common;
using UnityEngine;

namespace Restory.Gameplay.InteractiveObjects
{
	public class FoldableObject : MonoBehaviour
	{
		[SerializeField]
		private InteractiveObject interactiveObject;

		[SerializeField]
		private InteractionTrigger interactionTrigger;

		[SerializeField]
		private GameObject wholeModel;

		[SerializeField]
		private GameObject foldedModel;

		[SerializeField]
		private BoxCollider wholeCollider;

		[SerializeField]
		private BoxCollider foldedCollider;

		public event Action OnObjectFolded;

		private void OnEnable()
		{
			interactiveObject.OnInitialized += CheckIfObjectChanged;
			interactiveObject.OnDragStarted += ResolveDragStarted;
			interactiveObject.OnDragCanceled += ResolveDragCanceled;
			interactiveObject.OnDragComplete += ResolveDragComplete;
			CheckIfObjectChanged();
		}

		private void OnDisable()
		{
			interactiveObject.OnInitialized -= CheckIfObjectChanged;
			interactiveObject.OnDragStarted -= ResolveDragStarted;
			interactiveObject.OnDragCanceled -= ResolveDragCanceled;
			interactiveObject.OnDragComplete -= ResolveDragComplete;
		}

		private void CheckIfObjectChanged()
		{
			if (interactiveObject.HasChanged)
			{
				SwapToFoldedObject();
			}
		}

		private void ResolveDragStarted()
		{
			if (!interactiveObject.HasChanged)
			{
				SwapToFoldedObject();
			}
		}

		private void ResolveDragCanceled()
		{
			if (!interactiveObject.HasChanged)
			{
				SwapToWholeObject();
			}
		}

		private void ResolveDragComplete()
		{
			if (!interactiveObject.HasChanged)
			{
				interactiveObject.HasChanged = true;
			}
		}

		private void SwapToWholeObject()
		{
			foldedModel.SetActive(value: false);
			wholeModel.SetActive(value: true);
			interactionTrigger.ChangeColliderParams(wholeCollider);
		}

		private void SwapToFoldedObject()
		{
			wholeModel.SetActive(value: false);
			foldedModel.SetActive(value: true);
			interactionTrigger.ChangeColliderParams(foldedCollider);
			this.OnObjectFolded?.Invoke();
		}
	}
}
