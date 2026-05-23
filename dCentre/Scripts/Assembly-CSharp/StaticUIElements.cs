using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class StaticUIElements : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CUpdateCoinsAndPrestige_TopLeft_003Ed__49 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public StaticUIElements _003C_003E4__this;

		private WaitForSeconds _003Cwait_003E5__2;

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
		public _003CUpdateCoinsAndPrestige_TopLeft_003Ed__49(int _003C_003E1__state)
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

	[CompilerGenerated]
	private sealed class _003CUpdateMessagesCoroutine_003Ed__56 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public StaticUIElements _003C_003E4__this;

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
		public _003CUpdateMessagesCoroutine_003Ed__56(int _003C_003E1__state)
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

	public static StaticUIElements instance;

	public GameObject canvasStatic;

	public GameObject imagePointer;

	[SerializeField]
	private TextMeshProUGUI txtUnderPointer;

	[SerializeField]
	private Image holdKeyIndicator;

	[SerializeField]
	private Image nextToPointer;

	public Image blackOver;

	public GameObject loading;

	public Tooltip tooltip;

	[SerializeField]
	private TextMeshProUGUI txtMessagesField;

	[SerializeField]
	private GameObject errorSignPrefab;

	[SerializeField]
	private GameObject warningSignPrefab;

	private int nextErrorWarningUID;

	private List<PositionIndicator> initiatedErrorWarningSigns;

	public GameObject topLeft_coinsPrestige;

	public TextMeshProUGUI topLeft_coinTXT;

	public TextMeshProUGUI topLeft_MoneyPerSecond;

	[SerializeField]
	private TextMeshProUGUI topLeft_reputationTXT;

	[SerializeField]
	private TextMeshProUGUI topLeft_xpTXT;

	public TextMeshProUGUI topLeft_XPPerSecond;

	[Header("Notification")]
	[SerializeField]
	private GameObject notificationGO;

	[SerializeField]
	private Image notificationSprite;

	[SerializeField]
	private TextMeshProUGUI notificationText;

	[SerializeField]
	private Sprite infoSprite;

	[Header("Keys")]
	public bool isKeyboardOrMouse;

	public GamepadIcons xboxIcons;

	public GamepadIcons ps4Icons;

	public Sprite sprite_KeyBorder;

	public Sprite sprite_RMB;

	public Sprite sprite_LMB;

	public Sprite sprite_MMB;

	[SerializeField]
	private GameObject keyhint_buttonE;

	[SerializeField]
	private Transform keyboardParent;

	[SerializeField]
	private GameObject keyHintCustomPrefab;

	private List<GameObject> instantiatedKeyHint;

	[SerializeField]
	private GameObject prefabParticleUpgrade;

	public Sprite sprite_Port_InUse;

	public Sprite sprite_Port_PlugIn;

	public Sprite sprite_Port_Unplug;

	public UI_SelectedBorder uI_SelectedBorder;

	private Queue<string> messageQueue;

	private List<float> messageExpireTimes;

	private const int MAX_MESSAGES = 10;

	private const float MESSAGE_DURATION = 30f;

	[SerializeField]
	private TextMeshProUGUI txtLoadingInfo;

	[Header("Tutorials")]
	[SerializeField]
	private GameObject tutorialObject;

	[SerializeField]
	private GameObject serverTutorialObject;

	private void Awake()
	{
	}

	private void Start()
	{
	}

	[IteratorStateMachine(typeof(_003CUpdateCoinsAndPrestige_TopLeft_003Ed__49))]
	public IEnumerator UpdateCoinsAndPrestige_TopLeft()
	{
		return null;
	}

	private void CalculateRates(out float moneyPerSec, out float xpPerSec)
	{
		moneyPerSec = default(float);
		xpPerSec = default(float);
	}

	public void SetNotification(int _localisationUID, Sprite _sprite = null, string _text = "")
	{
	}

	public void ShowStaticCanvas(bool active)
	{
	}

	public GameObject CreateCustomKeyHint(InputAction action, int textUID, Transform parent = null, bool isPermanent = false)
	{
		return null;
	}

	public void RemoveCustomKeyHint()
	{
	}

	public void InstantiateParticleUpgrade(Transform _transform)
	{
	}

	[IteratorStateMachine(typeof(_003CUpdateMessagesCoroutine_003Ed__56))]
	private IEnumerator UpdateMessagesCoroutine()
	{
		return null;
	}

	private void UpdateMessageDisplay()
	{
	}

	public void AddMeesageInField(string message)
	{
	}

	public int InstantiateErrorWarningSign(bool isError, Vector3 objectPos)
	{
		return 0;
	}

	public void DestroyErrorWarningSign(int errorWarningUID)
	{
	}

	public void ShowSpriteNextToPointer(Sprite _sprite)
	{
	}

	public void ClearSpriteNextToPointer()
	{
	}

	public void ShowServerTutorial()
	{
	}

	public void HideTutorial()
	{
	}

	public void ShowTextUnderCursor(string text)
	{
	}

	public void HideTextUnderCursor()
	{
	}

	public void UpdateHoldProgress(float value)
	{
	}

	public void SetLoadingInfo(string s)
	{
	}

	private void OnLoadingStarted()
	{
	}
}
