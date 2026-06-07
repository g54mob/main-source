using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
	public class UnlockContentPanel : MonoBehaviour
	{
		[SerializeField]
		protected Image icon;

		[SerializeField]
		protected Image unlockIcon;

		[SerializeField]
		protected TMP_Text text;

		[SerializeField]
		protected RectTransform iconArea;

		[SerializeField]
		protected Sprite lockedSprite;

		[SerializeField]
		protected Sprite unlockedSprite;

		protected List<Image> unlockIcons;

		protected bool showUnlockIcon;

		protected float animationTime;

		public virtual void Init(List<string> iconPaths, string text = null)
		{
		}

		protected void InitUnlockIcon()
		{
		}

		protected void InitText(string text)
		{
		}

		public virtual Sequence PlayAnimation()
		{
			return null;
		}

		protected virtual void PlusAnimation()
		{
		}
	}
}
