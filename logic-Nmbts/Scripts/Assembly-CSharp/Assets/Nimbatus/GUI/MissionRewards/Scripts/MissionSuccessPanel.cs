using System;
using System.Collections.Generic;
using Assets.Nimbatus.Scripts.Receivables;
using Spine;
using Spine.Unity;
using UnityEngine;

namespace Assets.Nimbatus.GUI.MissionRewards.Scripts
{
	public class MissionSuccessPanel : MonoBehaviour
	{
		public List<RewardChestSlot> Slots;

		public RewardChestItem ItemPrefab;

		public SkeletonAnimation PlayerLootbox;

		public ParticleSystem PunchEffect;

		public string RewardSound;

		private List<BaseReceivable> _missionRewards;

		public void Init(List<BaseReceivable> missionRewards)
		{
			_missionRewards = missionRewards;
			List<RewardChestSlot> list = new List<RewardChestSlot>();
			switch (_missionRewards.Count)
			{
			case 1:
				list.Add(Slots[3]);
				break;
			case 2:
				list.Add(Slots[2]);
				list.Add(Slots[4]);
				break;
			case 3:
				list.Add(Slots[1]);
				list.Add(Slots[3]);
				list.Add(Slots[5]);
				break;
			case 4:
				list.Add(Slots[0]);
				list.Add(Slots[2]);
				list.Add(Slots[4]);
				list.Add(Slots[6]);
				break;
			default:
				throw new Exception("Mission Reward Screen is set up for 1 to 4 rewards");
			}
			for (int i = 0; i < _missionRewards.Count; i++)
			{
				RewardChestItem rewardChestItem = UnityEngine.Object.Instantiate(ItemPrefab, base.transform);
				rewardChestItem.Init(_missionRewards[i]);
				rewardChestItem.transform.localScale = Vector3.one;
				list[i].Init(rewardChestItem);
			}
			StartLootboxAnimation();
		}

		public void SkipAnimation()
		{
			AudioController.Stop(RewardSound);
			PlayerLootbox.AnimationState.SetAnimation(0, "open_idle", true);
			RewardChestSlotsSetActive(true);
		}

		public void OnEnable()
		{
			PlayerLootbox.AnimationState.Event += AnimationState_Event;
		}

		public void OnDisable()
		{
			PlayerLootbox.AnimationState.Event -= AnimationState_Event;
		}

		private void StartLootboxAnimation()
		{
			AudioController.Play(RewardSound);
			RewardChestSlotsSetActive(false);
			if (PlayerLootbox != null && PlayerLootbox.AnimationState != null)
			{
				PlayerLootbox.AnimationState.ClearTracks();
				PlayerLootbox.AnimationState.Data.DefaultMix = 0f;
				PlayerLootbox.AnimationState.SetAnimation(0, "closed_shaking", false);
				PlayerLootbox.AnimationState.AddAnimation(0, "open1", false, 0f);
				PlayerLootbox.AnimationState.AddAnimation(0, "open_idle", true, 0f);
			}
		}

		private void AnimationState_Event(TrackEntry trackEntry, Spine.Event e)
		{
			if (e.Data.Name == "Punch")
			{
				if (PunchEffect != null)
				{
					PunchEffect.Play();
				}
			}
			else if (e.Data.Name == "ShowRewards")
			{
				RewardChestSlotsSetActive(true);
			}
		}

		private void RewardChestSlotsSetActive(bool active)
		{
			foreach (RewardChestSlot slot in Slots)
			{
				if (slot.Initiated)
				{
					slot.transform.GetChild(0).gameObject.SetActive(active);
				}
			}
		}
	}
}
