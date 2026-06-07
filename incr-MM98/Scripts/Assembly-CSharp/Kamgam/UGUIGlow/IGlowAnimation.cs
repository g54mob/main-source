using System;
using System.Collections.Generic;
using UnityEngine;

namespace Kamgam.UGUIGlow
{
	public interface IGlowAnimation
	{
		MeshCreator MeshCreator { get; }

		event Action<GlowAnimation> OnValueChanged;

		IGlowAnimation Copy();

		void CopyValuesFrom(IGlowAnimation source);

		void TriggerOnValueChanged();

		void AddToMeshCreator(MeshCreator creator);

		void RemoveFromMeshCreator(MeshCreator creator);

		void Stop();

		void Pause();

		bool IsPaused();

		bool IsStopped();

		bool IsPlaying();

		void Play();

		void Update(float deltaTime);

		void OnUpdateMesh(MeshCreator creator, List<UIVertex> vertices, List<ushort> triangles, List<ushort> outerIndices, List<ushort> innerIndices, Dictionary<ushort, ushort> outerToInnerIndices);
	}
}
