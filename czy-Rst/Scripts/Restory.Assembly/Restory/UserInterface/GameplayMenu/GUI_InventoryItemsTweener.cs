using System.Collections.Generic;
using DG.Tweening;
using Restory.Utils;
using UnityEngine;
using Zenject;

namespace Restory.UserInterface.GameplayMenu
{
	public class GUI_InventoryItemsTweener : MonoBehaviour
	{
		private static class Style
		{
			public const string ShakeTween = "Shake Tween Settings";

			public const string NewStackAppearTweens = "New Stack Appear Tweens Settings";

			public const string NewStackAppearEnlargingTween = "New Stack Appear Tweens Settings/Enlarging Tween";

			public const string NewStackAppearDiminishingTween = "New Stack Appear Tweens Settings/Diminishing Tween";

			public const string ReplaceStackTweens = "Replace Stack Tweens Settings";

			public const string ReplaceStackOldItemDisappearTween = "Replace Stack Tweens Settings/Disappearing Tween";

			public const string ReplaceStackNewItemEnlargingTween = "Replace Stack Tweens Settings/Enlarging Tween";

			public const string ReplaceStackNewItemDiminishingTween = "Replace Stack Tweens Settings/Diminishing Tween";

			public const string ItemCountInStackChangedTween = "Item Count In Stack Changed Tween Settings";
		}

		private Dictionary<Transform, Tween> activeTweens = new Dictionary<Transform, Tween>();

		private bool isTweenAutoKillOn;

		private TweenSequencesService tweenSequences;

		[Inject]
		private void Construct(TweenSequencesService tweenSequences)
		{
			this.tweenSequences = tweenSequences;
		}

		private void Awake()
		{
			isTweenAutoKillOn = DOTween.defaultAutoKill;
		}

		private void OnDisable()
		{
			KillAllTweens();
		}

		private void KillAllTweens()
		{
			foreach (KeyValuePair<Transform, Tween> activeTween in activeTweens)
			{
				tweenSequences.Kill(activeTween.Value);
				if (activeTween.Key != null && activeTween.Value.IsActive())
				{
					activeTween.Value.Kill();
				}
			}
			activeTweens.Clear();
		}

		public void Dispose()
		{
			KillAllTweens();
		}
	}
}
