using System;
using UnityEngine;

namespace NatSuite.Recorders.Inputs
{
	public interface ITextureInput : IDisposable
	{
		(int width, int height) frameSize { get; }

		void CommitFrame(Texture texture, long timestamp);
	}
}
