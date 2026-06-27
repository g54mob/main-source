using System;
using System.Collections;
using Restory.Data.Devices.Quality;
using UnityEngine;

namespace Restory.Gameplay.Effects
{
	public class CheckDeviceEffect : MonoBehaviour
	{
		private const int MAX_FRAMES = 15;

		[SerializeField]
		private Renderer renderer;

		[SerializeField]
		private string frameName = "_Frame";

		[SerializeField]
		private string textureName = "_Texture";

		[SerializeField]
		[Min(0.01f)]
		private float speed = 20f;

		[SerializeField]
		private Texture2D idealQualityFrame;

		[SerializeField]
		private Texture2D workingQualityFrame;

		[SerializeField]
		private Texture2D brokenQualityFrame;

		public void Play(DeviceQualityBase quality, Action callback = null)
		{
			Material material = renderer.material;
			if (!(quality is IdealDeviceQuality))
			{
				if (!(quality is WorkingDeviceQuality))
				{
					if (!(quality is BrokenDeviceQuality))
					{
						return;
					}
					material.SetTexture(textureName, brokenQualityFrame);
				}
				else
				{
					material.SetTexture(textureName, workingQualityFrame);
				}
			}
			else
			{
				material.SetTexture(textureName, idealQualityFrame);
			}
			renderer.material = material;
			StopAllCoroutines();
			StartCoroutine(PlayEffectCoroutine(callback));
		}

		private IEnumerator PlayEffectCoroutine(Action callback = null)
		{
			float frame = 0f;
			while (frame <= 15f)
			{
				if (Camera.main != null)
				{
					base.transform.rotation = Quaternion.LookRotation(-Camera.main.transform.forward);
				}
				Material material = renderer.material;
				material.SetFloat(frameName, frame);
				renderer.material = material;
				frame += speed * Time.deltaTime;
				yield return null;
			}
			callback?.Invoke();
		}
	}
}
