using DG.Tweening;
using Libs;
using UnityEngine.Events;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace PostProcess
{
	public class PostProcessCtrl : SingletonMonoBehaviour<PostProcessCtrl>
	{
		public Volume volume;

		private ColorAdjustments _colorAdjustments;

		private MotionBlur _motionBlur;

		private PostProcessSetting _ps;

		public ColorAdjustments ColorAdjustments => null;

		public MotionBlur MotionBlur => null;

		private void Awake()
		{
		}

		public void Init()
		{
		}

		public Sequence FadeIn(float duration, UnityAction callback = null)
		{
			return null;
		}

		public Sequence FadeOut(float duration)
		{
			return null;
		}
	}
}
