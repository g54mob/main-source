using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UI
{
	public class RouteNodeButton : MonoBehaviour
	{
		[Serializable]
		public struct NodePlaceIcon
		{
			public ChoiceRouteCtrl.eNodeState state;

			public Sprite sprite;
		}

		public RectTransform rectTransform;

		public Image enemyIcon;

		public List<NodePlaceIcon> nodePlaceIcons;

		public Button button;

		public float selectableScale;

		public CanvasGroup canvasGroup;

		public Image selectCursor;

		public Image markImage;

		public Sprite nowMark;

		public Sprite[] clearMarkGroup;

		public SimpleAnimation simpleAnimation;

		public Image baseImage;

		[SerializeField]
		private GameObject powerOrdealObj;

		[SerializeField]
		private Image lastBossCircle;

		[SerializeField]
		private Vector3 lastBossScale;

		[SerializeField]
		private Vector2 lastBossRectSize;

		[SerializeField]
		private float namedUnSelecableScale;

		private Vector3 _initialScale;

		private ChoiceRouteCtrl.RouteNode _targetRoute;

		private bool _isLastBossNode;

		private Sprite _initSprite;

		private Vector3 AnimationScale => default(Vector3);

		public ChoiceRouteCtrl.RouteNode TargetRoute => null;

		public event UnityAction OnClickAction
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

		public event UnityAction OnPointerEnterAction
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

		public event UnityAction OnExitPointerAction
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

		private Vector3 GetScale(eEnemyType type, ChoiceRouteCtrl.eNodeState state, bool subNamed = false)
		{
			return default(Vector3);
		}

		public void InitComponent(ChoiceRouteCtrl.RouteNode targetRoute)
		{
		}

		public void PlayAnimation(ChoiceRouteCtrl.eNodeState state)
		{
		}

		public void StopAnimation()
		{
		}

		public void OnClick()
		{
		}

		public void OnPointerEnter()
		{
		}

		public void OnPointerExit()
		{
		}

		public void UpdateState(ChoiceRouteCtrl.eNodeState state, bool referenceMode)
		{
		}
	}
}
