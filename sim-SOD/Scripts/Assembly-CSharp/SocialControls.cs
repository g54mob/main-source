using System;
using System.Collections.Generic;
using UnityEngine;

public class SocialControls : MonoBehaviour
{
	[Serializable]
	public class SocialCreditBuff
	{
		public string name;

		public string description;

		public SyncDiskPreset.Effect effect;

		public float value;

		[Range(0f, 5f)]
		public int randomGrouping;

		public UpgradeEffectController.AppliedEffect GetEffect()
		{
			return null;
		}
	}

	[Tooltip("Random ranges for knowning different acquaintances")]
	[Header("Relationships/Acquaintances")]
	public Vector2 knowLoverRange;

	public Vector2 knowHousemateRange;

	public Vector2 knowFriendRange;

	public Vector2 knowNeighborRange;

	public Vector2 knowBossRange;

	public Vector2 knowWorkTeamRange;

	public Vector2 knowWorkRange;

	public Vector2 knowWorkOtherRange;

	public Vector2 knowRegularCustomerRange;

	public Vector2 knowParamourRange;

	public Vector2 knowGroupRange;

	[Header("Traits Reference")]
	public CharacterTrait paramour;

	[Header("Culture")]
	public int basePreferredBookCount;

	[Tooltip("Paygrades (see company preset wage enum")]
	[Header("Businesses")]
	public List<float> wageRanges;

	[Tooltip("Overtime ranges (see occupation preset enum")]
	public List<Vector2> overtimeRanges;

	[Tooltip("0.8 - 1 accuracy (minutes)")]
	[Space(7f)]
	[Header("Memory Accuracy Steps")]
	public float accuracy1;

	[Tooltip("0.6 - 0.8 accuracy (minutes)")]
	public float accuracy2;

	[Tooltip("0.4 - 0.6 accuracy (minutes)")]
	public float accuracy3;

	[Tooltip("0.2 - 0.4 accuracy (minutes)")]
	public float accuracy4;

	[Tooltip("0.0 - 0.2 accuracy (minutes)")]
	public float accuracy5;

	[Header("Know Thresholds")]
	[Tooltip("How well known a connection has to be before they are included in a citizen's telephone book")]
	[Range(0f, 1f)]
	[Space(7f)]
	public float telephoneBookInclusionThreshold;

	[Range(0f, 1f)]
	[Tooltip("How well known a connection has to be before they know the others' place of work")]
	public float knowPlaceOfWorkThreshold;

	[Tooltip("How well known a connection has to be before they know the others' address")]
	[Range(0f, 1f)]
	public float knowAddressThreshold;

	[Tooltip("How well known a connection has to be before a citizen mourn's another's death")]
	[Range(0f, 1f)]
	public float knowMournThreshold;

	[Tooltip("How well known a connection has to be before a citizen sends the other birthday cards or has their birthday listed on the calendar")]
	[Range(0f, 1f)]
	public float knowBirthdayThreshold;

	[Range(0f, 1f)]
	[Tooltip("How well known a connection before they can reveal their immediate location")]
	public float knowImmediateLocationThreshold;

	[Tooltip("If true; social credit buffs are selected within random groups. If false, they are ordered per the list below.")]
	[Header("Social Credit Buffs")]
	public bool randomSocialCreditBuffs;

	public AudioEvent perkNotificationAudioEvent;

	public List<SocialCreditBuff> socialCreditBuffs;

	private static SocialControls _instance;

	public static SocialControls Instance => null;

	private void Awake()
	{
	}

	private void OnDestroy()
	{
	}
}
