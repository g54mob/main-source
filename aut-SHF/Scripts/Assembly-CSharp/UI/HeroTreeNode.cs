using System.Collections.Generic;
using System.Runtime.CompilerServices;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UI
{
	public class HeroTreeNode : MonoBehaviour
	{
		public Image luggageIcon;

		public eLuggage luggage;

		public Image sourceFrame;

		public Image unitFrame;

		public Image emphasisFrame;

		public GameObject selectCursor;

		public List<HeroTreeNode> parentNode;

		public StarCounter starCounter;

		public NoticeBadge noticeBadge;

		public GameObject padGuide;

		private List<HeroTreeNode> _childNode;

		private Image _targetFrame;

		private readonly int PROPERTY_IS_SECRET;

		private readonly Color _secretColor;

		private Tween _secretTween;

		private Tween _emphasisiTween;

		private InputActionController input;

		public bool IsSource => false;

		public bool IsParts => false;

		public bool IsHide => false;

		public bool IsSecret => false;

		public List<HeroTreeNode> ChildNode
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

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

		public event UnityAction OnMouseEnterAction
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

		public event UnityAction OnMouseExitAction
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

		public bool IsUnlock()
		{
			return false;
		}

		public bool IsLockAndCollectionOk()
		{
			return false;
		}

		private void Awake()
		{
		}

		private void Update()
		{
		}

		public void Init()
		{
		}

		public void GetIconImage()
		{
		}

		public void UpdateNode(Sprite changeSprite)
		{
		}

		public void UpdateShader(float? isSecret = null)
		{
		}

		public void OnEmphasis()
		{
		}

		public void OffEmphasis()
		{
		}

		public void OnSecretEmphasis()
		{
		}

		public void OffSecretEmphasis()
		{
		}

		public void OnClick()
		{
		}

		public void OnMouseEnter()
		{
		}

		public void OnMouseExit()
		{
		}

		public void OnEnable()
		{
		}

		public void OnDisable()
		{
		}
	}
}
