using System.Linq;
using Assets.Nimbatus.Scripts.Common.Helpers;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.WorldObjects.DronePerks;
using Assets.Nimbatus.Scripts.WorldObjects.DronePerks.Effects;
using UnityEngine;

namespace Assets.Nimbatus.GUI.MissionControl.Scripts.Main
{
	public class DisplayActiveEffects : MonoBehaviour
	{
		public UIGrid EffectsGrid;

		public EffectUi EffectPrefab;

		public void Start()
		{
			EffectsGrid.transform.DestroyAllChildren();
			if (RuntimeGlobals.GameMode == EGameMode.Campaign)
			{
				if (SerializableMonobehaviour<DronePerkManager, DronePerkManagerData>.Instance.ActiveEffects == null)
				{
					base.gameObject.SetActive(false);
					return;
				}
				foreach (DroneEffect activeEffect in SerializableMonobehaviour<DronePerkManager, DronePerkManagerData>.Instance.ActiveEffects)
				{
					EffectUi effectUi = Object.Instantiate(EffectPrefab, EffectsGrid.transform);
					effectUi.transform.localScale = Vector3.one;
					effectUi.Init(activeEffect, true);
				}
			}
			else if (RuntimeGlobals.GameMode == EGameMode.Creative)
			{
				foreach (DroneEffect effect in from s in SerializableMonobehaviour<DronePerkManager, DronePerkManagerData>.Instance.AllEffectSettings
					where s.UseInCreative
					select s.Effect)
				{
					EffectUi effectUi2 = Object.Instantiate(EffectPrefab, EffectsGrid.transform);
					effectUi2.transform.localScale = Vector3.one;
					effectUi2.Init(effect, SerializableMonobehaviour<DronePerkManager, DronePerkManagerData>.Instance.ActiveEffects.Any((DroneEffect e) => e.EffectType == effect.EffectType));
				}
			}
			EffectsGrid.enabled = true;
			EffectsGrid.Reposition();
			EffectsGrid.repositionNow = true;
		}
	}
}
