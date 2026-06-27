using Mandragora.Utils;
using Restory.Data.Elements;
using UnityEngine;

namespace Restory.Gameplay.Elements
{
	public class ThreadedElementView : ElementView
	{
		[Space]
		[SerializeField]
		[BoolButton(20, 0)]
		private bool outlinedWhenUnblocked = true;

		protected override void OnEnable()
		{
			element.OnActivated.AddListener(ResolveActivated);
			element.OnDeactivated.AddListener(ResolveDeactivated);
			element.OnBlockedStateChanged.AddListener(ResolveBlockedStateChanged);
			element.OnInteractionCanceled.AddListener(ResolveInteractionCanceled);
			base.OnEnable();
		}

		protected override void OnDisable()
		{
			element.OnActivated.RemoveListener(ResolveActivated);
			element.OnDeactivated.RemoveListener(ResolveDeactivated);
			element.OnBlockedStateChanged.RemoveListener(ResolveBlockedStateChanged);
			element.OnInteractionCanceled.RemoveListener(ResolveInteractionCanceled);
			base.OnDisable();
		}

		protected override void ResolveSelectionStateChanged()
		{
			if (!outlinedWhenUnblocked || element.IsSelected || element.IsBlocked || !element.InSocket)
			{
				base.ResolveSelectionStateChanged();
			}
			else
			{
				ActivateThreadedElementOutline();
			}
		}

		private void ResolveActivated()
		{
			if (outlinedWhenUnblocked && !element.IsBlocked)
			{
				ActivateThreadedElementOutline();
			}
		}

		private void ResolveDeactivated()
		{
			base.IsOutlined = false;
		}

		private void ResolveInteractionCanceled()
		{
			if (outlinedWhenUnblocked)
			{
				if (element.IsInstalling)
				{
					base.IsOutlined = false;
				}
				else
				{
					ActivateThreadedElementOutline();
				}
			}
		}

		private void ResolveBlockedStateChanged()
		{
			if (element.IsBlocked)
			{
				base.IsOutlined = false;
			}
			else if (element.Info.Category == ElementCategory.Small)
			{
				ActivateThreadedElementOutline();
			}
		}

		private void ActivateThreadedElementOutline()
		{
			base.IsOutlined = true;
			outlineAdapter.OverridePreset = outlineSettings.ThreadedElementOutline;
		}
	}
}
