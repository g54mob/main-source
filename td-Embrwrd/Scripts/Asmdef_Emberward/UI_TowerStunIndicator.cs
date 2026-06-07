using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class UI_TowerStunIndicator : MonoBehaviour
{
	public enum eIndicatorType
	{
		STUN = 0,
		BUILDING = 1
	}

	[Serializable]
	public class IndicatorTypeToImage
	{
		public eIndicatorType indicatorType;

		public Sprite image;
	}

	[CompilerGenerated]
	private sealed class _003CCR_Effect_003Ed__10 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public UI_TowerStunIndicator _003C_003E4__this;

		public float duration;

		private float _003Ctime_003E5__2;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		[DebuggerHidden]
		public _003CCR_Effect_003Ed__10(int _003C_003E1__state)
		{
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
		}
	}

	[SerializeField]
	private Animator animator;

	[SerializeField]
	private Image image_Icon;

	[SerializeField]
	private Image image_Icon_BlackLayer;

	[SerializeField]
	private List<IndicatorTypeToImage> list_IndicatorTypeToImage;

	private ABaseTower targetTower;

	public static void CreateUI(ABaseTower tower, float duration, eIndicatorType indicatorType)
	{
	}

	public void Setup(ABaseTower tower, float duration, eIndicatorType indicatorType)
	{
	}

	private void Update()
	{
	}

	[IteratorStateMachine(typeof(_003CCR_Effect_003Ed__10))]
	private IEnumerator CR_Effect(float duration)
	{
		return null;
	}
}
