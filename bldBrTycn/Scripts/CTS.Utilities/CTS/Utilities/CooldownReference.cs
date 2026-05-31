using CTS.Core;
using UnityEngine;

namespace CTS.Utilities
{
	[CreateAssetMenu(menuName = "CTS/Cooldown")]
	public class CooldownReference : ScriptableObject
	{
		[SerializeField]
		public StringKey Key;

		[SerializeField]
		public Vector2 CooldownRange = Vector2.one;

		[SerializeField]
		public bool UseScaledTime = true;
	}
}
