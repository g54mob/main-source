using UnityEngine;

namespace PlaceholderSoftware.WetStuff
{
	public interface IWetDecal
	{
		Matrix4x4 WorldTransform { get; }

		BoundingSphere Bounds { get; }

		[NotNull]
		IDecalSettings Settings { get; }

		[CanBeNull]
		Mesh Mesh { get; }

		void Step(float dt);
	}
}
