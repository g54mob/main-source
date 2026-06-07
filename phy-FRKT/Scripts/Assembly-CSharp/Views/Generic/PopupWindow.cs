using System;
using System.Runtime.CompilerServices;
using DG.Tweening;
using UnityEngine;

namespace Views.Generic
{
	[RequireComponent(typeof(CanvasGroup))]
	public class PopupWindow : MonoBehaviour
	{
		private sealed class ey
		{
			public float pun;

			public float puo;

			public PopupWindow pup;

			public float puq;

			public float pur;

			public bool pus;

			public Action put;

			internal void dwa()
			{
			}

			internal void ngx()
			{
			}

			internal void osq()
			{
			}

			internal void ddd()
			{
			}

			internal void cpu()
			{
			}

			internal float ija()
			{
				return 0f;
			}

			internal float dvy()
			{
				return 0f;
			}

			internal float ngs()
			{
				return 0f;
			}

			internal void dvz(float a)
			{
			}

			internal float yd()
			{
				return 0f;
			}

			internal void fib(float a)
			{
			}

			internal void gzl()
			{
			}

			internal void oej()
			{
			}

			internal void fpw()
			{
			}

			internal void dwb()
			{
			}

			internal void hsk()
			{
			}
		}

		[SerializeField]
		private CanvasGroup m_canvasGroup;

		[SerializeField]
		[Min(0f)]
		private float m_showDuration;

		[SerializeField]
		[Min(0f)]
		private float m_hideDuration;

		[SerializeField]
		private bool m_easingNeeded;

		[SerializeField]
		private Ease m_easeType;

		[SerializeField]
		private bool m_nonInteractableOnHide;

		private Tweener puw;

		private bool pux;

		public event Action puu
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action puv
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public void dwg()
		{
		}

		public void dwh()
		{
		}

		private void dwi(bool a, float b, Action c)
		{
		}

		private void dwj(bool a, float b, Action c)
		{
		}

		private void Awake()
		{
		}

		private void OnValidate()
		{
		}

		private void OnDestroy()
		{
		}
	}
}
