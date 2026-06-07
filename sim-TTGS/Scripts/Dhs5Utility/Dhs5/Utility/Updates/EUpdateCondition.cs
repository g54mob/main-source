using UnityEngine;

namespace Dhs5.Utility.Updates
{
	public enum EUpdateCondition
	{
		[InspectorName("Always")]
		ALWAYS = 0,
		[InspectorName("Game Playing")]
		GAME_PLAYING = 1,
		[InspectorName("Game Paused")]
		GAME_PAUSED = 2,
		[InspectorName("Game Over")]
		GAME_OVER = 3,
		[Tooltip("Custom conditions should be overriden in a custom updater")]
		CUSTOM1 = 4,
		[Tooltip("Custom conditions should be overriden in a custom updater")]
		CUSTOM2 = 5,
		[Tooltip("Custom conditions should be overriden in a custom updater")]
		CUSTOM3 = 6,
		[Tooltip("Custom conditions should be overriden in a custom updater")]
		CUSTOM4 = 7,
		[Tooltip("Custom conditions should be overriden in a custom updater")]
		CUSTOM5 = 8,
		[Tooltip("Custom conditions should be overriden in a custom updater")]
		CUSTOM6 = 9,
		[Tooltip("Custom conditions should be overriden in a custom updater")]
		CUSTOM7 = 10,
		[Tooltip("Custom conditions should be overriden in a custom updater")]
		CUSTOM8 = 11,
		[Tooltip("Custom conditions should be overriden in a custom updater")]
		CUSTOM9 = 12,
		[Tooltip("Custom conditions should be overriden in a custom updater")]
		CUSTOM10 = 13
	}
}
