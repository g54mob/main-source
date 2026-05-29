using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
	public class OrdealCursorItem : MonoBehaviour
	{
		[SerializeField]
		private Image mainImage;

		[SerializeField]
		private Image overImage;

		private eLastBattleKey _key;

		private Vector2 _defaultPosition;

		private Action<eLastBattleKey, GameObject> SelectAction;

		private Action DeSelectAction;

		public void InitComponent(eLastBattleKey key, Action<eLastBattleKey, GameObject> SelectAction, Action DeSelectAction)
		{
		}

		private void SavePosition()
		{
		}

		public void ResetPosition()
		{
		}

		public Sequence PlayGetOrdealAnimation(string animationName, SkeletonGraphicController spineAnimation, float flyEffectDuration, float scaleUpDuration, float aftertasteDuration, float overImageScale, GameObject fromObj = null)
		{
			return null;
		}

		public void OnSelect()
		{
		}

		public void OnDeSelect()
		{
		}
	}
}
