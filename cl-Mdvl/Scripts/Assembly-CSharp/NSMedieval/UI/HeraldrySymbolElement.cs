using NSEipix.Base;
using NSMedieval.Controllers;
using NSMedieval.Heraldry;
using UnityEngine;
using UnityEngine.UI;

namespace NSMedieval.UI
{
	public class HeraldrySymbolElement : LayoutGroupItemView
	{
		[SerializeField]
		private Image heraldryCrest;

		[SerializeField]
		private Image heraldryPattern;

		[SerializeField]
		private bool isNotPlayerHeraldry;

		[SerializeField]
		private TooltipViewNew plainTextTooltip;

		private Sprite crestSprite;

		private Sprite patternSprite;

		private string factionId;

		public void SetSprites(Sprite crestSprite, Sprite patternSprite)
		{
			this.crestSprite = crestSprite;
			this.patternSprite = patternSprite;
			heraldryCrest.sprite = this.crestSprite;
			heraldryPattern.sprite = this.patternSprite;
		}

		public void SetFactionId(string factionId)
		{
			this.factionId = factionId;
			if (plainTextTooltip != null && this.factionId != string.Empty)
			{
				plainTextTooltip.SetSingleLineTooltip(MonoSingleton<LocalizationController>.Instance.GetText(this.factionId + "_name"));
			}
		}

		private void OnEnable()
		{
			MonoSingleton<HeraldryManager>.Instance.HeraldryChangedEvent += OnHeraldryChanged;
			if (!isNotPlayerHeraldry)
			{
				MonoSingleton<HeraldryManager>.Instance.UpdateHeraldry();
			}
		}

		private void OnDisable()
		{
			if (MonoSingleton<HeraldryManager>.IsInstantiated())
			{
				MonoSingleton<HeraldryManager>.Instance.HeraldryChangedEvent -= OnHeraldryChanged;
			}
		}

		private void OnHeraldryChanged()
		{
			heraldryCrest.sprite = MonoSingleton<HeraldryManager>.Instance.Crest.sprite;
			heraldryPattern.sprite = MonoSingleton<HeraldryManager>.Instance.Pattern.sprite;
		}
	}
}
