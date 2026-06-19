using System;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TH20
{
	[Serializable]
	[UsedImplicitly(ImplicitUseTargetFlags.Members)]
	public struct LoadSaveProgressData
	{
		public GameObject ParentPanel;

		public Image ProgressBarImage;

		public GameObject LoadingPanel;

		public Image BackingImage;

		public CanvasGroup LoadingScreenCanvasGroup;

		public TMP_Text TitleLabelText;

		public TMP_Text DetailsLabelText;

		public Sprite DefaultBackingSprite;

		public CanvasGroup CloudCurtainsLeft;

		public CanvasGroup CloudCurtainsLeftBack;

		public CanvasGroup CloudCurtainsLeftFurtherBack;

		public CanvasGroup CloudCurtainsRight;

		public CanvasGroup CloudCurtainsRightBack;

		public CanvasGroup CloudCurtainsRightFurtherBack;
	}
}
