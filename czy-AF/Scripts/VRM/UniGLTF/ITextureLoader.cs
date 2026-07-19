using System;
using System.Collections;
using UnityEngine;

namespace UniGLTF
{
	public interface ITextureLoader : IDisposable
	{
		Texture2D Texture { get; }

		void ProcessOnAnyThread(glTF gltf, IStorage storage);

		IEnumerator ProcessOnMainThread(bool isLinear);
	}
}
