using System;
using System.Collections.Generic;
using DG.Tweening;
using Libs;
using UnityEngine;

namespace UI
{
	public class UIMouseOverCtrl : SingletonMonoBehaviour<UIMouseOverCtrl>
	{
		[Serializable]
		public class MouseOverWindowSet
		{
			public eUIMouseOverType type;

			public BaseMouseOverWindow window;
		}

		public enum eUIMouseOverType
		{
			TitleMessage = 0,
			TitleValue = 1,
			IconTitleMessageDetail = 2,
			Message = 3
		}

		private struct UIMouseOverInfo
		{
			public eUIMouseOverType type;

			public eUIMouseOverAnchorPosition anchor;

			public BaseMouseOverWindowParam param;

			public IUIMouseOverValueGetter valueGetter;

			public Vector2 offset;
		}

		[Flags]
		public enum eUIMouseOverAnchorPosition
		{
			None = 0,
			Top = 1,
			Left = 2,
			Right = 4,
			Bottom = 8
		}

		[SerializeField]
		private Canvas defaultCanvas;

		[Header("windows")]
		[SerializeField]
		private List<MouseOverWindowSet> windowSet;

		private const int FronPadCanvasSortOrder = 2;

		private static int _defaultCanvasSortOrder;

		private static Canvas _playCanvas;

		private GameObject _target;

		private UIMouseOverInfo _info;

		private Tween _delayedActionTween;

		public float delayedActionTime { get; private set; }

		private void Awake()
		{
		}

		private void Start()
		{
		}

		private void Update()
		{
		}

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
		private static void InitPlayOnMode()
		{
		}

		public void TriggerMouseOver(GameObject target, BaseMouseOverWindowParam param, IUIMouseOverValueGetter valueGetter = null, eUIMouseOverType windowType = eUIMouseOverType.TitleMessage, eUIMouseOverAnchorPosition anchor = eUIMouseOverAnchorPosition.None)
		{
		}

		private void SetWindowPosition()
		{
		}

		private void SetAnchoredPosition(ref Vector2 pos)
		{
		}

		private MouseOverWindowSet GetWindowInfo()
		{
			return null;
		}

		private void ShowMouseOverWindow()
		{
		}

		private void DisableAllWindow()
		{
		}

		public void StopMouseOver()
		{
		}

		public static void Set(GameObject target, BaseMouseOverWindowParam param, IUIMouseOverValueGetter valueGetter = null, eUIMouseOverType type = eUIMouseOverType.TitleMessage, eUIMouseOverAnchorPosition anchor = eUIMouseOverAnchorPosition.None)
		{
		}

		public static void Unset()
		{
		}

		private new void OnDestroy()
		{
		}
	}
}
