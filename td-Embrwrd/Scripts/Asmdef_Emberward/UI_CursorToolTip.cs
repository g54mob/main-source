using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Rewired.Glyphs.UnityUI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_CursorToolTip : AUISituational
{
	public enum eFormatType
	{
		TARGET_AT_BOTTOM = 0,
		TARGET_AT_TOP = 1
	}

	public enum eTargetType
	{
		_2D = 0,
		_3D = 1
	}

	[CompilerGenerated]
	private sealed class _003CCR_ForceRebuild_003Ed__28 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public RectTransform t;

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
		public _003CCR_ForceRebuild_003Ed__28(int _003C_003E1__state)
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
	private VerticalLayoutGroup verticalLayoutGroup;

	[SerializeField]
	private Vector3 uiOffset;

	[SerializeField]
	private GameObject node_SecondaryDescription;

	[SerializeField]
	private TMP_Text text_SecondaryDescription;

	[SerializeField]
	private TMP_Text text_Title;

	[SerializeField]
	private UnityUITextMeshProGlyphHelper text_Content;

	[SerializeField]
	private GameObject node_TowerUpgradeInfo;

	[SerializeField]
	private TMP_Text text_TowerUpgradeInfo_A;

	[SerializeField]
	private TMP_Text text_TowerUpgradeInfo_B;

	[SerializeField]
	private Image image_Deco;

	[SerializeField]
	private List<UI_Obj_SecondaryTooltip> list_SecondaryTooltip;

	private bool isUIOn;

	private Transform curTrackingTarget;

	private Vector3 curTargetOffset;

	private eTargetType curTargetType;

	[SerializeField]
	private eFormatType currentFormatType;

	private string msg_Title;

	private string msg_Content;

	private int block3DTooltipRequest;

	private Canvas canvas;

	private Vector3 lastUpdatePos;

	private static CanvasScaler canvasScaler;

	private static Vector2 canvasResolution;

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void SwitchFormat(eFormatType formatType)
	{
	}

	private void OnRequestBlock3DTooltip()
	{
	}

	private void OnRequestUnblock3DTooltip()
	{
	}

	private bool DoBlock3DTooltip()
	{
		return false;
	}

	private void OnSetMouseTooltipBySettingData(TowerSettingData data)
	{
	}

	[IteratorStateMachine(typeof(_003CCR_ForceRebuild_003Ed__28))]
	private IEnumerator CR_ForceRebuild(RectTransform t)
	{
		return null;
	}

	private void OnSetMouseTooltipSecondaryContent(List<string> list_Messages)
	{
	}

	private void OnToggleMouseTooltip(bool isOn)
	{
	}

	private void OnSetMouseTooltipTarget(eTargetType targetType, Transform target, Vector3 targetOffset)
	{
	}

	private void OnSetMouseTooltipContent(string title, string content)
	{
	}

	private void Update()
	{
	}

	private void UpdatePosition()
	{
	}

	public void UIMustInScreen(RectTransform rectTransform, Canvas canvas)
	{
	}

	private Vector3 ScreenToCanvasPosition(Vector3 screenPosition, Canvas canvas)
	{
		return default(Vector3);
	}

	private static Bounds GetCombinedBounds(RectTransform rt)
	{
		return default(Bounds);
	}

	private static void DrawBounds(Bounds bounds)
	{
	}

	public void SetTitle(string msg)
	{
	}

	public void SetContent(string msg)
	{
	}
}
