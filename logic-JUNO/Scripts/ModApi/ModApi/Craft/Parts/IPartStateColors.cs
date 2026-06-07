using UnityEngine;

namespace ModApi.Craft.Parts
{
	public interface IPartStateColors
	{
		Color Attached { get; }

		Color Colliding { get; }

		Color DisconnectedPrimary { get; }

		Color DisconnectedSecondary { get; }

		Color Highlighted { get; }

		Color Selected { get; }
	}
}
