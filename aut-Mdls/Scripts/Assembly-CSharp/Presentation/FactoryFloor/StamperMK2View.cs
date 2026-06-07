using System.Collections.Generic;
using Data.FactoryFloor.Behaviours;
using UnityEngine;
using UnityEngine.VFX;

namespace Presentation.FactoryFloor
{
	public class StamperMK2View : FactoryResourceHolderView<StamperMK2Behaviour>
	{
		private const string PLAY_EFFECT_NAME = "Play";

		[SerializeField]
		private List<VisualEffect> _affectedVisualEffects = new List<VisualEffect>();

		protected override void Init()
		{
			base.Init();
			_behaviour.OnOutputResource.RegisterMainThread(base.PassResource);
		}

		protected override void ResetFactoryObject()
		{
			ResetStamperView();
			base.ResetFactoryObject();
		}

		protected override void OnDestroy()
		{
			ResetStamperView();
			base.OnDestroy();
		}

		private void ResetStamperView()
		{
			if ((bool)_behaviour)
			{
				_behaviour.OnOutputResource.UnRegisterMainThread(base.PassResource);
			}
		}

		public override void PlayStartAnimation()
		{
			base.PlayStartAnimation();
			foreach (VisualEffect affectedVisualEffect in _affectedVisualEffects)
			{
				affectedVisualEffect.SendEvent("Play");
			}
		}
	}
}
