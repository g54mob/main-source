using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace UI
{
	public class LonkThinkCtrl : MonoBehaviour
	{
		[SerializeField]
		private RectTransform counterParent;

		[SerializeField]
		private EmphasisObj counterPrefab;

		[SerializeField]
		private EmphasisObj mainButtonEmphasis;

		[SerializeField]
		private Sprite longthinkSprite;

		[SerializeField]
		private Sprite unLongthinkSprite;

		[SerializeField]
		private Sprite usedCounterSprite;

		[SerializeField]
		private Sprite unUseCounterSprite;

		[SerializeField]
		private Image chargeGageImage;

		[SerializeField]
		private GameObject longThinkBubbleObj;

		[SerializeField]
		private Toggle longThinkkBubbleToggle;

		[SerializeField]
		private InputActionReference _targetAction;

		public UILookEmphasis lookEmphasis;

		private List<EmphasisObj> _counterObjList;

		private double _initChargeGoalTime;

		private int _lastShowBubbleWave;

		private double _putChargeTime;

		private double _surplusChargeTime;

		private float _pressStartTime;

		private const float LongPressThreshold = 0.5f;

		private bool _isPressed;

		private bool _longPressProcessed;

		private InputAction _targetInputAction;

		public bool IsChargeMax => false;

		private bool LongthinkBubbleOk => false;

		public bool IsMaxLongthink => false;

		private event UnityAction OnClickAction
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

		public void Init(UnityAction onClickAction)
		{
		}

		private void OnActionPerformed(InputAction.CallbackContext context)
		{
		}

		private void OnActionCanceled(InputAction.CallbackContext context)
		{
		}

		private void Update()
		{
		}

		private void OnDestroy()
		{
		}

		private EmphasisObj CreateCounter()
		{
			return null;
		}

		public void UpdateLongthinkUI()
		{
		}

		private void CheckBubble()
		{
		}

		public void CloseLongthinkBubble()
		{
		}

		public void UpdateLongthinkGage()
		{
		}

		public void AddCounter()
		{
		}

		public void OnClick()
		{
		}
	}
}
