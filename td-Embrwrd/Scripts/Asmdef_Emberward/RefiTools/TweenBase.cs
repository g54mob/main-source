using UnityEngine;

namespace RefiTools
{
	public abstract class TweenBase : MonoBehaviour
	{
		public enum eTweenLoopType
		{
			NONE = 0,
			LOOP = 1,
			PINGPONG = 2
		}

		[Header("持續時間")]
		[SerializeField]
		protected float duration;

		[Header("重複播放的類型")]
		[SerializeField]
		protected eTweenLoopType loopType;

		[Header("是否受Timescale影響")]
		[SerializeField]
		protected bool isAffectedByTimeScale;

		[Header("是否使用遊戲時間作為進度 (而非update累計時間)")]
		[SerializeField]
		protected bool isUseGlobalGameTime;

		[Header("動畫曲線")]
		[SerializeField]
		protected AnimationCurve curve;

		[Header("是否從隨機時間點開始")]
		[SerializeField]
		private bool isStartAtRandomTime;

		protected float tweenT;

		protected float sign;

		[SerializeField]
		protected bool isTweenOn;

		private bool Validate_CanUseGlobalGameTime()
		{
			return false;
		}

		protected virtual void Start()
		{
		}

		protected virtual void Reset()
		{
		}

		protected virtual void OnValidate()
		{
		}

		protected void Update()
		{
		}

		public void SetDuration(float _duration)
		{
		}

		private void MakeSureTweenInRange()
		{
		}

		protected abstract void UpdateTween();

		public void ToggleTween(bool isOn)
		{
		}

		public void RestartTween()
		{
		}

		public void SetLoopType(eTweenLoopType _loopType)
		{
		}
	}
}
