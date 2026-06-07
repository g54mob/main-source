using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Craft.Paint
{
	public interface IPaintTexturePreset
	{
		IReadOnlyList<IPaintColorData> Colors { get; }

		string DisplayName { get; }

		string Id { get; }

		Vector3 Offset { get; }

		Vector3 Rotation { get; }

		Vector3 Scale { get; }

		void ApplyPreset(PaintColorData[] paintColorData);

		PaintTexturePreset Clone();
	}
}
