using CTS.BBT;
using CTS.Core;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Localization;

namespace CTS
{
	[CreateAssetMenu(fileName = "New Junk Object Data", menuName = "BBT/Junk Object")]
	public class JunkObjectParameters : ScriptableObject
	{
		[SerializeField]
		private LocalizedString _actionDisplayName;

		[field: SerializeField]
		public JunkObject Prefab { get; private set; }

		[field: SerializeField]
		public bool IsAnimationLoop { get; private set; }

		[field: SerializeField]
		[field: ShowIf("IsAnimationLoop")]
		public float AnimationDuration { get; private set; } = 1f;

		[field: SerializeField]
		public AnimKey Animation { get; private set; }

		[field: SerializeField]
		public bool ShouldCollideWithFurniture { get; private set; } = true;

		[field: SerializeField]
		public bool CanBeOverwritten { get; private set; }

		[field: SerializeField]
		public bool DiscardImmediately { get; private set; }

		[field: SerializeField]
		[field: MinValue(0f)]
		public float PrestigeMalus { get; private set; }

		public string GetLocalizedString()
		{
			return _actionDisplayName.GetLocalizedStringSafe();
		}
	}
}
