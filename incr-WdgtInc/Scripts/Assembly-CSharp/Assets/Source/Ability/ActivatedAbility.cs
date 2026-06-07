using System;
using System.Collections.Generic;
using System.Numerics;
using Assets.Behaviour.Util;
using Assets.Source.Item;
using Assets.Source.Player;
using Assets.Source.Util;
using Assets.Source.World.Frames;
using UnityEngine;

namespace Assets.Source.Ability
{
	public abstract class ActivatedAbility
	{
		private static Dictionary<string, ActivatedAbility> _abilities = new Dictionary<string, ActivatedAbility>();

		protected Transform _abilitySource;

		protected string _failReason;

		public string Identifier => GetType().Name;

		public virtual string DisplayName => "@Ability" + Identifier;

		public virtual string DescriptionText => DisplayName + "Desc";

		public abstract double Entropy { get; }

		public abstract int BaseCost { get; }

		public abstract string IconName { get; }

		public abstract AbilityTargetType TargetType { get; }

		public Sprite Icon => SpriteLibrary.Get(IconName);

		protected abstract bool ActivateAbility(object target);

		public virtual bool IsValidTarget(object target)
		{
			return !(target is T1GlitchedFrame);
		}

		public void DoActivateAbility(Transform source, object target)
		{
			_abilitySource = source;
			if (target is T1GlitchedFrame)
			{
				SteamAchievement.Trigger("GlitchedFeedback");
			}
			BigInteger castingCost = GetCastingCost();
			if (castingCost > GamePlayer.Current.GetInventoryCount(ItemType.GlitchedWidget))
			{
				UISounds.CraftStep();
				ShowNeedItem(source, ItemType.GlitchedWidget, castingCost);
			}
			else if (!IsValidTarget(target))
			{
				UISounds.CraftStep();
				ShowWarning(source, "@AbilityInvalidTarget");
			}
			else if (ActivateAbility(target))
			{
				UISounds.CraftFinished();
				GamePlayer.Current.AbilityEntropy *= Entropy;
				GamePlayer.Current.ConsumeInventoryItem(ItemType.GlitchedWidget, castingCost);
				SteamStatsManager.Add(SteamStatType.GlitchWidgetsSpent, (int)castingCost);
			}
			else
			{
				UISounds.CraftStep();
				ShowWarning(source, GetFailReason());
			}
		}

		public static ActivatedAbility Get(string name)
		{
			if (_abilities.TryGetValue(name, out var value))
			{
				return value;
			}
			return _abilities[name] = Create(name);
		}

		public BigInteger GetCastingCost()
		{
			return GameMath.Multiply(BaseCost, GamePlayer.Current.AbilityEntropy);
		}

		public string GetFailReason()
		{
			object obj = _failReason;
			_failReason = null;
			if (obj == null)
			{
				obj = "@AbilityFailed";
			}
			return (string)obj;
		}

		public void ShowNeedItem(Transform source, ItemType item, BigInteger count)
		{
			if (OverviewUI.Instance.FullScreenActive)
			{
				OverviewUI.Instance.ShowNeedItem(source, item, count);
			}
			else
			{
				FrameUI.Instance.ShowNeedItem(source, item, count);
			}
		}

		public void ShowWarning(Transform source, string msg)
		{
			if (OverviewUI.Instance.FullScreenActive)
			{
				OverviewUI.Instance.ShowWarning(source, msg);
			}
			else
			{
				FrameUI.Instance.ShowWarning(source, msg);
			}
		}

		public void ShowItemCrafted(Transform source, ItemType crafted, BigInteger count, float offset = 0f)
		{
			if (OverviewUI.Instance.FullScreenActive)
			{
				OverviewUI.Instance.ShowItemCrafted(source, crafted, count, offset);
			}
			else
			{
				FrameUI.Instance.ShowItemCrafted(source, crafted, count, offset);
			}
		}

		private static ActivatedAbility Create(string name)
		{
			return (ActivatedAbility)Type.GetType("Assets.Source.Ability." + name).GetConstructor(new Type[0]).Invoke(new object[0]);
		}
	}
}
