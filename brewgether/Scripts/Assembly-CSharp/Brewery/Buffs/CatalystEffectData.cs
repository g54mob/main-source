using Brewery.Data;
using UnityEngine;

namespace Brewery.Buffs
{
	[CreateAssetMenu(fileName = "New Catalyst Effect", menuName = "Brewery/Buffs/Catalyst Effect")]
	public class CatalystEffectData : ScriptableObject
	{
		[Header("Catalyst Mapping")]
		[Tooltip("The unique ID of the catalyst (e.g., 'cocaine_powder'). Must match CatalystData.CatalystId.")]
		[SerializeField]
		private string m_CatalystId;

		[Tooltip("Optional direct reference to the CatalystData for icon/name lookup.")]
		[SerializeField]
		private CatalystData m_CatalystRef;

		[Header("Effect Configuration")]
		[Tooltip("The type of buff this catalyst applies.")]
		[SerializeField]
		private BuffType m_EffectType;

		[Tooltip("Potency multiplier. Values < 1 reduce (e.g., 0.8 = 20% reduction), values > 1 increase (e.g., 1.5 = 50% boost).")]
		[SerializeField]
		[Range(0.1f, 3f)]
		private float m_Potency;

		[Tooltip("Duration of the buff in seconds.")]
		[SerializeField]
		[Range(5f, 300f)]
		private float m_Duration;

		[Header("Display")]
		[Tooltip("Override icon for the buff. Uses catalyst icon if null.")]
		[SerializeField]
		private Sprite m_OverrideIcon;

		[Tooltip("Color tint for the buff icon border in UI.")]
		[SerializeField]
		private Color m_EffectColor;

		[Tooltip("Description shown in tooltips.")]
		[SerializeField]
		[TextArea(2, 4)]
		private string m_Description;

		[SerializeField]
		private string m_DescriptionKey;

		[Header("Apply Effects (When Buff Starts)")]
		[Tooltip("Particle effect prefab spawned when buff is applied. Falls back to default if null.")]
		[SerializeField]
		private GameObject m_ApplyEffectPrefab;

		[Tooltip("Sound played when buff is applied. Falls back to default if null.")]
		[SerializeField]
		private AudioClip m_ApplySound;

		[Header("Active Effects (While Buff Active)")]
		[Tooltip("Looping particle effect prefab attached while buff is active.")]
		[SerializeField]
		private GameObject m_ActiveEffectPrefab;

		[Header("Expire Effects (When Buff Ends)")]
		[Tooltip("Particle effect prefab spawned when buff expires.")]
		[SerializeField]
		private GameObject m_ExpireEffectPrefab;

		public string CatalystId => null;

		public CatalystData CatalystRef => null;

		public BuffType EffectType => default(BuffType);

		public float Potency => 0f;

		public float Duration => 0f;

		public Sprite Icon => null;

		public Color EffectColor => default(Color);

		public string DisplayName => null;

		public string Description => null;

		public GameObject ApplyEffectPrefab => null;

		public AudioClip ApplySound => null;

		public GameObject ActiveEffectPrefab => null;

		public GameObject ExpireEffectPrefab => null;

		private void OnValidate()
		{
		}

		private string GenerateDefaultDescription()
		{
			return null;
		}
	}
}
