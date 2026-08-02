using System;
using Rhizomatic.Pooling;
using UnityEngine;

namespace GRP
{
	public class BookPaperVisual : PoolObject
	{
		public Animator animator;

		public Renderer paperRenderer;

		public Transform rotationBone;

		public Transform nextRotation;

		public Transform previousRotation;

		public Action onFinish;

		public Action onCancel;

		private BookVisual book;

		private bool movingNext;

		private bool movingPrevious;

		private Quaternion startRotation;

		private float startTime;

		private float speedMultiplier;

		private float currentPosition;

		private int rightPosition;

		private int leftPosition;

		private MaterialPropertyBlock[] materialBlocks;

		public void Setup(BookVisual book)
		{
		}

		protected override void Update()
		{
		}

		public void SetLeftContent()
		{
		}

		public void SetLeftContent(int position)
		{
		}

		public void SetRightContent()
		{
		}

		public void SetRightContent(int position)
		{
		}

		private void SetTexture(int index, Texture texture)
		{
		}

		public void SetNext(bool value, Action onFinish = null, Action onCancel = null)
		{
		}

		public void ForceFinish()
		{
		}

		public void _HandleFinishNext()
		{
		}

		public void _HandleFinishPrevious()
		{
		}
	}
}
