using System;
using UnityEngine;

namespace Assets.Scripts.Ui.Purchase
{
	public interface IVideoPlayerService
	{
		RenderTexture RenderTexture { get; }

		void Play(string videoClipPath, Action onComplete);

		void Stop();
	}
}
