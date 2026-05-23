using System.Collections.Generic;
using DG.Tweening;
using Libs;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FooterCtrl : SingletonMonoBehaviour<FooterCtrl>
{
	private class TextAnimationCtrlInfo
	{
		public TMP_Text targetText;

		public GameObject getParticleObj;

		private Sequence animationSequence;

		public bool isPlayAnimation => false;

		public void PlayAnimation(float targetPoint, float duration = 1f)
		{
		}

		public void CompleteAnimation()
		{
		}
	}

	[SerializeField]
	private Image masterImage;

	[SerializeField]
	private TMP_Text ascensionText;

	[SerializeField]
	private GameObject ascensionContent;

	[SerializeField]
	private GameObject challengeContent;

	[SerializeField]
	private TMP_Text manaText;

	[SerializeField]
	private TMP_Text manaIncreaseText;

	[SerializeField]
	private TMP_Text researchPointText;

	[SerializeField]
	private TMP_Text redResearchPointText;

	[SerializeField]
	private TMP_Text goldText;

	[SerializeField]
	private GameObject levelupGroup;

	[SerializeField]
	private GameObject levelUpSeparator;

	[SerializeField]
	private GameObject manaParticle;

	[SerializeField]
	private GameObject researchPointParticle;

	[SerializeField]
	private GameObject redResearchPonintParticle;

	[SerializeField]
	private GameObject goldParticle;

	[SerializeField]
	private GameObject guideText;

	private Dictionary<TMP_Text, TextAnimationCtrlInfo> animationCtrlList;

	private void Awake()
	{
	}

	public void Init()
	{
	}

	public void UpdateMaterial(int mana)
	{
	}

	public void UpdateManaIncrease(float manaPerSecond)
	{
	}

	public void UpdateGreenResearchPoint(int greenResearch)
	{
	}

	public void UpdateRedResearchPoint(int redResearch)
	{
	}

	public void UpdateKeen(int keen)
	{
	}

	public void UpdateManaWithAnimation()
	{
	}

	public void UpdateResearchGreenPointWithAnimation()
	{
	}

	public void UpdateResearchRedPointWithAnimation()
	{
	}

	public void UpdateGoldWithAnimation()
	{
	}

	public void SwitchGuideText(bool isShow)
	{
	}

	public void DebugChangeAscension(int ascensionLevel)
	{
	}
}
