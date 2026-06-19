using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TH20.UI
{
	public class PanelItemTrophyItem : PanelItem
	{
		[SerializeField]
		private LocalisedString _awardTitleString;

		[SerializeField]
		private Image _trophyImage;

		[SerializeField]
		private Image _trophyImageBG;

		[SerializeField]
		private TooltipSpawner _trophyTooltip;

		[SerializeField]
		private Color _awardCountShadowColour;

		[SerializeField]
		private Color _newAwardCountColour;

		[SerializeField]
		private Color _previousAwardCountColour;

		[SerializeField]
		private Sprite _newTrophySpriteOverlay;

		[SerializeField]
		private TMP_Text _awardCountText;

		[SerializeField]
		private TMP_Text _awardCountTextShadow;

		[SerializeField]
		private Vector2 _newAwardCountShadowOffset;

		[SerializeField]
		private Vector2 _previousAwardCountShadowOffset;

		[SerializeField]
		private Vector2 _spotFocus;

		public HospitalAwardsManager.AwardType theAwardType;

		private HospitalAwardsManager _awardsManager;

		private Shadow _trophyShadow;

		private Transform _trophyTransform;

		private Quaternion _startRotation;

		private Vector3 _startScale;

		public bool _test;

		private int trophyCount;

		public Vector2 SpotFocus => _spotFocus;

		public override void Setup()
		{
			base.Setup();
			OverviewMenuTabPanel overviewMenuTabPanel = null;
			GameObject gameObject = base.gameObject.transform.parent.gameObject;
			while (gameObject != null && overviewMenuTabPanel == null)
			{
				overviewMenuTabPanel = gameObject.GetComponent<OverviewMenuTabPanel>();
				gameObject = gameObject.transform.parent.gameObject;
			}
			if (overviewMenuTabPanel != null && overviewMenuTabPanel.GetLevel() != null)
			{
				_awardsManager = overviewMenuTabPanel.GetLevel().HospitalAwardsManager;
				Dictionary<HospitalAwardsManager.AwardType, HospitalAwardsManager.AwardInstanceData> awardData = _awardsManager.AwardsConfig.AwardData;
				if (awardData != null)
				{
					int siblingIndex = base.transform.GetSiblingIndex();
					int num = 0;
					foreach (HospitalAwardsManager.AwardType key in awardData.Keys)
					{
						if (num++ == siblingIndex)
						{
							theAwardType = key;
							break;
						}
					}
					if (awardData.TryGetValue(theAwardType, out var value))
					{
						_awardTitleString = value.AwardNameLoc;
					}
				}
				if (_trophyTooltip != null)
				{
					_trophyTooltip.SetDataProvider(delegate(Tooltip tooltip)
					{
						tooltip.Text = _awardsManager.GetAwardTooltipText(theAwardType);
					});
				}
			}
			SetTitleText(_awardTitleString.Translation);
			_trophyTransform = ((_trophyImage != null) ? _trophyImage.GetComponent<Transform>() : base.transform);
			_trophyShadow = ((_trophyImage != null) ? _trophyImage.GetComponent<Shadow>() : null);
			_startRotation = _trophyTransform.localRotation;
			_startScale = _trophyTransform.localScale;
			SetAwardCountColour(_previousAwardCountColour);
			UpdateTrophyImage(bRecessOnly: true);
		}

		private IEnumerator Wobble()
		{
			if ((bool)_trophyTransform)
			{
				bool stop = false;
				float time = 0f;
				Quaternion destRot = _startRotation;
				int num = Random.Range(0, 2) * 2 - 1;
				Quaternion startRot = destRot * Quaternion.AngleAxis(num * 15, Vector3.forward);
				Vector3 startScale = _startScale;
				do
				{
					if (time >= 1f)
					{
						stop = true;
					}
					float t = EasingsUtils.ElasticEaseOut(Mathf.Clamp01(time));
					_trophyTransform.localRotation = Quaternion.Lerp(startRot, destRot, t);
					_trophyTransform.localScale = Vector3.LerpUnclamped(startScale * 1.4f, startScale, t);
					yield return null;
					time += Time.unscaledDeltaTime * 0.5f;
				}
				while (!stop);
			}
			yield return null;
		}

		public void AddAward()
		{
			SetNewTrophy();
			SetAwardCount(trophyCount + 1);
			SetAwardCountColour(_newAwardCountColour);
			StartCoroutine(Wobble());
		}

		public void ShowAward()
		{
			SetNewTrophy();
			SetAwardCount(trophyCount);
			SetAwardCountColour(_newAwardCountColour);
			StartCoroutine(Wobble());
		}

		public void SetAwardCount(int awardCount)
		{
			trophyCount = awardCount;
			string text = trophyCount.ToString();
			if ((bool)_awardCountText)
			{
				_awardCountText.text = text;
			}
			if ((bool)_awardCountTextShadow)
			{
				_awardCountTextShadow.text = text;
			}
		}

		public void Process()
		{
			if (_test)
			{
				AddAward();
				_test = false;
			}
		}

		private void UpdateTrophyImage(bool bRecessOnly)
		{
			SetImageData(_trophyImageBG, null);
			SetImageData(_trophyImage, null);
			Dictionary<HospitalAwardsManager.AwardType, HospitalAwardsManager.AwardInstanceData> awardData = _awardsManager.AwardsConfig.AwardData;
			if (awardData != null && awardData.TryGetValue(theAwardType, out var value))
			{
				SetImageData(_trophyImageBG, value.TrophySpriteBG);
				if (!bRecessOnly)
				{
					SetImageData(_trophyImage, value.TrophySprite);
				}
			}
			if ((bool)_trophyShadow)
			{
				_trophyShadow.enabled = true;
			}
		}

		private void SetImageData(Image inImage, Sprite inOverrideSprite)
		{
			if (inImage != null)
			{
				inImage.overrideSprite = inOverrideSprite;
				Color color = inImage.color;
				color.a = ((inOverrideSprite != null) ? 1f : 0f);
				inImage.color = color;
			}
		}

		private void SetAwardCountColour(Color inColour)
		{
			if (_awardCountText != null)
			{
				if (trophyCount > 0)
				{
					_awardCountText.color = inColour;
				}
				else
				{
					_awardCountText.color = _previousAwardCountColour;
				}
			}
		}

		private void SetNewTrophy()
		{
			UpdateTrophyImage(bRecessOnly: false);
			if ((bool)_awardCountTextShadow)
			{
				_awardCountTextShadow.rectTransform.localPosition = _newAwardCountShadowOffset;
			}
		}
	}
}
