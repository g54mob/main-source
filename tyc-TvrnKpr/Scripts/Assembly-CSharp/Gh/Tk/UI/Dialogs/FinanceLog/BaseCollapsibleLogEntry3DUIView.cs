using System;
using System.Runtime.CompilerServices;
using DG.Tweening;
using UnityEngine;

namespace Gh.Tk.UI.Dialogs.FinanceLog
{
	public class BaseCollapsibleLogEntry3DUIView : MonoBehaviour
	{
		[SerializeField]
		private Button3DUIView _accordianButton;

		private Ease _collapseEase;

		private float _collapseDuration;

		private Ease _expandEase;

		private float _expandDuration;

		private Tween _transitionTween;

		[SerializeField]
		private Container3DUIView _logContainerPrefab;

		private Container3DUIView _logContainer;

		private bool _isCollapsed;

		protected Container3DUIView LogContainer => null;

		public static event EventHandler LayoutUpdated
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		protected virtual void Start()
		{
		}

		protected virtual void OnEnable()
		{
		}

		protected virtual void OnDisable()
		{
		}

		private void EnsureLogContainerPosition()
		{
		}

		protected void CreateLogContainer()
		{
		}

		public void Expand()
		{
		}

		public void Collapse()
		{
		}

		private void ExpandInternal()
		{
		}

		private void CollapseInternal()
		{
		}

		private void UpdateCollider()
		{
		}

		private void UpdateParentLayouts(Transform us)
		{
		}

		private void ResizeContainerCollider(Container3DUIView con)
		{
		}
	}
}
