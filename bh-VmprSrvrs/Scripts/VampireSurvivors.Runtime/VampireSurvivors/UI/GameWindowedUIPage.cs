using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Items;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework.Particles;

namespace VampireSurvivors.UI
{
	public class GameWindowedUIPage : BaseUIPage
	{
		[SerializeField]
		protected ParticleEmitterManager _PfxEmitter;

		[SerializeField]
		protected RectTransform _WindowContainer;

		[SerializeField]
		protected string _ParticleTexture;

		[SerializeField]
		protected List<string> _ParticleFrames;

		[SerializeField]
		protected List<string> _WindowFrames;

		[SerializeField]
		protected TextMeshProUGUI _Title;

		[SerializeField]
		protected RectTransform _TitlePanel;

		[SerializeField]
		protected RectTransform _Content;

		[SerializeField]
		protected RectTransform _BackButton;

		protected List<GameObject> _spawned;

		protected ParticleSystem _pfx1;

		protected ParticleSystem _pfx2;

		protected bool _particlesCreated;

		protected List<Image> _windows;

		protected bool hideBackgroundParticles;

		protected bool hideBackgroundWindows;

		public virtual void Purchase(ItemType t, ItemData d, ShopItemUI item, float price, RectTransform sender)
		{
		}

		public virtual void Purchase(WeaponType t, WeaponData d, float price, ShopItemUI item)
		{
		}

		public virtual void SetSelected(ShopItemUI item)
		{
		}

		public virtual void OnUserConfirmInput()
		{
		}

		public virtual float GetCurrency()
		{
			return 0f;
		}

		protected override void OnShowStart(GameObject g)
		{
		}

		protected override void OnHideFinish(GameObject g)
		{
		}

		protected virtual void CreateParticles()
		{
		}

		protected virtual void CreateWindows()
		{
		}

		protected void ClearWindows()
		{
		}

		protected Sequence BackButtonInTween()
		{
			return null;
		}
	}
}
