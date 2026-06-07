using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace Battle
{
	[RequireComponent(typeof(SimpleAnimation))]
	public class SpriteAnimation : MonoBehaviour
	{
		[SerializeField]
		private bool enabledFlip;

		[SerializeField]
		[Tooltip("スピードを変更したときにそのまま影響を受ける")]
		private bool enableZeroGear;

		[Header("onDestroy,onDestroyStateはセットで利用する")]
		[Header("onDestroy有効時、onDestroyState終了後にオブジェクト破棄")]
		public bool onDestroy;

		public string onDestroyState;

		public SpriteRenderer spriteRenderer;

		public bool isAllSide;

		public Vector2 buffOffset;

		private SimpleAnimation simpleAnimation;

		private Sequence sequence;

		private string _nowPlayStateName;

		private SimpleAnimation.State _nowPlayState;

		private bool _isPause;

		private double _gearCache;

		private bool _gearChangeable;

		private Dictionary<string, float> _clipBaseLength;

		public string NowPlayState
		{
			get
			{
				return null;
			}
			private set
			{
			}
		}

		public GameObject buffEffect { get; private set; }

		private void Awake()
		{
		}

		private void Start()
		{
		}

		private void Update()
		{
		}

		public void ChangeFlipX(Vector2 directionVector = default(Vector2))
		{
		}

		public void StartSpawnAnimation(Action completedAction = null)
		{
		}

		public void PlayAnimation(string stateName)
		{
		}

		public void PlayAnimation(string stateName, Action callback = null, float? finishTime = null, bool managed = true)
		{
		}

		public void PlayAnimation(string prefix, float value, Action callback, float? finishTime = null, bool managed = true)
		{
		}

		public float GetPlayingNormalize()
		{
			return 0f;
		}

		private void CheckDestroy()
		{
		}

		private void SpeedChange()
		{
		}

		public string GetStateByDegree(string prefix, float? degree)
		{
			return null;
		}

		public static string GetActionSuffix(float degree)
		{
			return null;
		}

		public string GetStateUpperOrLower(string prefix, float y)
		{
			return null;
		}

		public void Elimination(string stateName = "", Action callback = null, float appendInterval = 0f)
		{
		}

		public bool ExistAnimation(string animationName)
		{
			return false;
		}

		public float GetClipTime(string animationName, bool onGear = false)
		{
			return 0f;
		}

		public float ClipTimeSum(params string[] param)
		{
			return 0f;
		}

		public bool PlayingState(string stateName)
		{
			return false;
		}

		public bool PlayingState()
		{
			return false;
		}

		public void StopAnimation()
		{
		}

		public void PauseAnimation()
		{
		}

		public void ReleasePause()
		{
		}

		public void CreateBuffEffect(GameObject effect)
		{
		}

		public void ReturnBuffEffect()
		{
		}

		public void ChangeMaterial(Material newMaterial)
		{
		}

		private void OnDestroy()
		{
		}
	}
}
