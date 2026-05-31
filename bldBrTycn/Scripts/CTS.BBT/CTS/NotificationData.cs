using UnityEngine;
using UnityEngine.Localization;

namespace CTS
{
	[CreateAssetMenu(menuName = "CTS/Notification Data")]
	public class NotificationData : ScriptableObject
	{
		[field: SerializeField]
		public Sprite Icon { get; private set; }

		[field: SerializeField]
		public LocalizedString TooltipTitle { get; private set; }

		[field: SerializeField]
		public LocalizedString TooltipDescription { get; private set; }

		[field: SerializeField]
		public float Cooldown { get; private set; } = 10f;

		[field: SerializeField]
		public AudioAsset AudioOverride { get; private set; }

		[field: SerializeField]
		public bool NeedSoundToPlay { get; private set; }

		[field: SerializeField]
		public NotificationObject PrefabOverride { get; private set; }
	}
}
