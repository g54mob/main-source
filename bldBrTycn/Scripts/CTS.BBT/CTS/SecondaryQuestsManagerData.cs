using System;
using System.Collections.Generic;
using UnityEngine;

namespace CTS
{
	[CreateAssetMenu(fileName = "SecondaryQuestsManagerData", menuName = "BBT/Data/SecondaryQuestsManagerData")]
	public class SecondaryQuestsManagerData : ScriptableObject
	{
		public enum ESelectionStyle
		{
			InOrder = 0,
			Random = 1
		}

		[Flags]
		public enum EReuseStyle
		{
			None = 0,
			Refused = 1,
			Accepted = 2
		}

		[field: SerializeField]
		public Vector2 TimeBeforeFirstSecondaryQuests { get; private set; }

		[field: SerializeField]
		public Vector2 TimeRangeBetweenSecondaryQuests { get; private set; }

		[field: SerializeField]
		public ESelectionStyle SelectionStyle { get; private set; }

		[field: SerializeField]
		public EReuseStyle ReuseStyle { get; private set; } = EReuseStyle.Refused;

		[field: SerializeField]
		public List<MapInfoSO> UnauthorizedLevels { get; private set; }

		[field: SerializeField]
		public float FailTimerDuration { get; private set; } = 900f;
	}
}
