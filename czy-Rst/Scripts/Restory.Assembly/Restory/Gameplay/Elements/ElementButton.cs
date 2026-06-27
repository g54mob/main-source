using System;
using Restory.Gameplay.Common;
using Restory.SimpleTweeners;
using UnityEngine;

namespace Restory.Gameplay.Elements
{
	public class ElementButton : MonoBehaviour
	{
		[SerializeField]
		private ElementBase element;

		[SerializeField]
		private BoxCollider buttonCollider;

		[SerializeField]
		private OutlinableAdapter outlineAdapter;

		[SerializeField]
		private SimpleTweenerBase buttonTweener;

		private bool isSelected;

		public BoxCollider Collider => buttonCollider;

		public bool IsSelected
		{
			get
			{
				return isSelected;
			}
			set
			{
				if (isSelected != value)
				{
					isSelected = value;
					outlineAdapter.IsActive = isSelected;
				}
			}
		}

		public event Action OnActivated;

		private void OnEnable()
		{
			element.OnActivated.AddListener(ResolveElementActivated);
			element.OnDeactivated.AddListener(ResolveElementDeactivated);
			element.OnDetached.AddListener(ResolveElementDetached);
			element.OnBlockedStateChanged.AddListener(ResolveElementBlockedStateChanged);
		}

		private void OnDisable()
		{
			element.OnActivated.RemoveListener(ResolveElementActivated);
			element.OnDeactivated.RemoveListener(ResolveElementDeactivated);
			element.OnDetached.RemoveListener(ResolveElementDetached);
			element.OnBlockedStateChanged.RemoveListener(ResolveElementBlockedStateChanged);
		}

		public void Press()
		{
			buttonTweener.Play();
			this.OnActivated?.Invoke();
		}

		private void ResolveElementActivated()
		{
			if (element.InSocket && element.IsBlocked)
			{
				buttonCollider.enabled = true;
			}
		}

		private void ResolveElementDeactivated()
		{
			IsSelected = false;
			buttonCollider.enabled = false;
		}

		private void ResolveElementDetached()
		{
			IsSelected = false;
			buttonCollider.enabled = false;
		}

		private void ResolveElementBlockedStateChanged()
		{
			buttonCollider.enabled = element.InSocket && element.IsBlocked;
		}
	}
}
