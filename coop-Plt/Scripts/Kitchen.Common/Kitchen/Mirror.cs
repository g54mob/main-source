using Platforms;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Kitchen
{
	public class Mirror : SerializedMonoBehaviour
	{
		public Camera Camera;

		public Renderer MirrorSurface;

		public RenderTexture Target;

		public MemoryManagerHandle Handle => this;

		public void OnEnable()
		{
			if (!PlatformSettings.ShowLobbyMirrors)
			{
				Camera.enabled = false;
				MirrorSurface.gameObject.SetActive(value: false);
				return;
			}
			if (Target == null)
			{
				Camera.enabled = true;
				Target = Handle.Register(new RenderTexture(64, 64, 0), out var _);
			}
			MirrorSurface.material.SetTexture("_BaseMap", Target);
			Camera.targetTexture = Target;
		}

		public void OnDestroy()
		{
			Object.Destroy(Target);
			Target = null;
			Handle.Dispose();
		}

		public void SetActive(bool active)
		{
			if (!PlatformSettings.ShowLobbyMirrors)
			{
				Camera.enabled = false;
				MirrorSurface.gameObject.SetActive(value: false);
			}
			else
			{
				Camera.enabled = active;
			}
		}
	}
}
