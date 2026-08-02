using System.Collections.Generic;
using Rhizomatic.Pooling;
using UnityEngine;

namespace GRP
{
	[RequireComponent(typeof(ObjectPool))]
	public class BookVisual : MonoBehaviour
	{
		public BookPaperVisual pagePrefab;

		public BookContentBuilder contentBuilder;

		public AnimationCurve rotationCurve;

		public BookConfig config;

		public int position;

		public bool isJumping;

		private BookPaperVisual leftPage;

		private BookPaperVisual rightPage;

		private List<BookPaperVisual> nextPages;

		private List<BookPaperVisual> previousPages;

		private ObjectPool pool;

		private bool started;

		private void Awake()
		{
		}

		private void Start()
		{
		}

		private void Setup()
		{
		}

		public void SetConfig(BookConfig config)
		{
		}

		public void Jump()
		{
		}

		private void ClearAnimations()
		{
		}

		public BookPaperVisual Spawn()
		{
			return null;
		}

		public void ChangePosition(int change)
		{
		}

		public void SetPosition(int value)
		{
		}

		public void AnimateNext()
		{
		}

		public void AnimatePrevious()
		{
		}

		private void OnDisable()
		{
		}

		public void CancelJump()
		{
		}

		public void AnimateJump(int value, int steps, float time)
		{
		}
	}
}
