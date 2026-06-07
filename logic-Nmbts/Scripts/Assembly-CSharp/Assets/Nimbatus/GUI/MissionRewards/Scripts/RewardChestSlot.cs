using UnityEngine;

namespace Assets.Nimbatus.GUI.MissionRewards.Scripts
{
	public class RewardChestSlot : MonoBehaviour
	{
		[HideInInspector]
		public bool Initiated;

		public void Init(RewardChestItem item)
		{
			item.transform.parent = base.transform;
			item.transform.localPosition = Vector3.zero;
			Initiated = true;
		}
	}
}
