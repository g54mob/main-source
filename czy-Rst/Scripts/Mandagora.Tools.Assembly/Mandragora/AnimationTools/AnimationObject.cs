using UnityEngine;

namespace Mandragora.AnimationTools
{
	public class AnimationObject : MonoBehaviour
	{
		private AnimationPlayer player = new AnimationPlayer();

		[HideInInspector]
		public EditorSettings editorSettings;

		[HideInInspector]
		public float timeScale = 1f;

		public AnimationObjectData data;

		public string ThreadName = AnimationManager.Threads.baseThread.ToString();

		public AnimationPlayer Player
		{
			get
			{
				if (player.animationObject == null)
				{
					player.animationObject = this;
				}
				return player;
			}
		}

		public bool FlipX
		{
			get
			{
				return data.FlipX;
			}
			set
			{
				data.FlipX = value;
			}
		}

		public bool FlipY
		{
			get
			{
				return data.FlipY;
			}
			set
			{
				data.FlipY = value;
			}
		}

		public void Awake()
		{
			if (data != null && data.dataAsset.animations != null && data.dataAsset.animations.Count > 0 && editorSettings.playOnAwake && editorSettings.indexSelectAnimation > 0)
			{
				Animation animation = data.dataAsset.animations[editorSettings.indexSelectAnimation - 1];
				if (animation != null)
				{
					FlipX = editorSettings.flipX;
					FlipY = editorSettings.flipY;
					Player.SetPose(animation.name, editorSettings.frameIndex);
					Player.Play(animation.name, editorSettings.loopPlayAwake);
				}
			}
			if (Application.isPlaying)
			{
				SetThread(ThreadName);
				AnimationManager.Instance.OnUpdateEventHandler += Player.UpdateTracks;
			}
		}

		public void SetThread(string threadName)
		{
			ThreadName = threadName;
			Player.threadName = threadName;
		}

		public void SetThread(AnimationManager.Threads thread)
		{
			SetThread(thread.ToString());
		}

		private void Update()
		{
			if (AnimationManager.Instance.IsAutoUpdate)
			{
				Player.UpdateTracks(Time.deltaTime, Player.threadName);
			}
		}

		public void SetShader(Shader shader)
		{
			if (data != null && !(data.renderer == null))
			{
				data.renderer.material.shader = shader;
			}
		}

		private void OnDestroy()
		{
			AnimationManager.Instance.OnUpdateEventHandler -= Player.UpdateTracks;
		}
	}
}
