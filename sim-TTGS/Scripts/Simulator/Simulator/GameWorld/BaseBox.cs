using System;
using System.Collections.Generic;
using UnityEngine;

namespace Simulator.GameWorld
{
	public abstract class BaseBox : MonoBehaviour, ISensable, IGrabbable, IOpenable
	{
		private static int _openParamID;

		[Header("Box")]
		[SerializeField]
		[ReadOnly(false, false)]
		protected BaseShopBoxData m_data;

		[SerializeField]
		private Rigidbody m_rigidbody;

		[SerializeField]
		private BoxCollider m_collider;

		[Header("Detection")]
		[SerializeField]
		private Outline m_outline;

		[SerializeField]
		private InputHint m_sensableInputHint;

		[Header("Animation")]
		[SerializeField]
		private Animator m_animator;

		[Header("Labels")]
		[SerializeField]
		private BoxLabel m_frontLabel;

		[SerializeField]
		private BoxLabel m_topLabel;

		[Header("Clipping")]
		[SerializeField]
		private ClippingObjectBehaviour m_clippingObjectBehaviour;

		[Header("Input Hint")]
		[SerializeField]
		private BaseBoxInputHint m_baseBoxInputHint;

		private static HashSet<BaseBox> _boxes = new HashSet<BaseBox>();

		public static int OpenParamID
		{
			get
			{
				if (_openParamID == 0)
				{
					_openParamID = Animator.StringToHash("Open");
				}
				return _openParamID;
			}
		}

		public bool IsDropped { get; private set; }

		public abstract bool IsEmpty { get; }

		public bool IsOpen { get; protected set; }

		public bool IsGrabbed { get; protected set; }

		public BaseShopBoxData BoxData => m_data;

		protected Animator Animator => m_animator;

		[field: SerializeField]
		public GrabbableData GrabbableData { get; private set; }

		public ClippingObjectBehaviour ClippingObjectBehaviour => m_clippingObjectBehaviour;

		Transform IGrabbable.transform => base.transform;

		public event Action OnGrabbed;

		public event Action OnDropped;

		public event Action OnGiven;

		public event Action OnOpened;

		protected virtual void Start()
		{
			ClippingObjectBehaviour.ValidateRenderersLayer();
		}

		protected virtual void OnEnable()
		{
			Register(register: true, this);
		}

		protected virtual void OnDisable()
		{
			Register(register: false, this);
		}

		public virtual void Init(BaseShopBoxData data)
		{
			m_data = data;
			if (m_frontLabel != null)
			{
				m_frontLabel.SetContent(data);
			}
			if (m_topLabel != null)
			{
				m_topLabel.SetContent(data);
			}
		}

		public bool CanBeSensed()
		{
			if (World.PlayerController.Context == EControllerContext.CHARACTER)
			{
				return World.PlayerCharacter.CharacterContext == EPlayerCharacterContext.NONE;
			}
			return false;
		}

		public void OnSensed()
		{
			m_outline.enabled = true;
			if (m_sensableInputHint != null)
			{
				m_sensableInputHint.enabled = true;
			}
		}

		public void OnUnsensed()
		{
			m_outline.enabled = false;
			if (m_sensableInputHint != null)
			{
				m_sensableInputHint.enabled = false;
			}
		}

		void IGrabbable.OnGrabbedBy(IGrabber grabber)
		{
			IsGrabbed = grabber is CharacterGrabber;
			OnGrabbedBy(grabber);
			this.OnGrabbed?.Invoke();
			if (IsDropped)
			{
				World.ScoreManager.ComputeFromScore(ScoreSettings.DropBoxScoreMalus.ReverseOperator(), "Bonus due to picking up dropped box");
				IsDropped = false;
			}
			if (grabber is GenericGrabber)
			{
				Register(register: false, this);
			}
		}

		protected virtual void OnGrabbedBy(IGrabber grabber)
		{
			m_rigidbody.isKinematic = true;
			m_collider.enabled = false;
			if (m_baseBoxInputHint != null)
			{
				m_baseBoxInputHint.enabled = IsGrabbed;
			}
			ClippingObjectBehaviour.SetRenderersLayer(grabber.ClippingLayerType);
			SetStateForThisInputHint(CanBeToggled());
		}

		void IGrabbable.OnDroppedBy(IGrabber grabber, Vector3 position)
		{
			IsGrabbed = false;
			OnDroppedBy(grabber, position);
			this.OnDropped?.Invoke();
		}

		protected virtual void OnDroppedBy(IGrabber grabber, Vector3 position)
		{
			base.transform.position = position;
			m_rigidbody.isKinematic = false;
			m_collider.enabled = true;
			if (m_baseBoxInputHint != null)
			{
				m_baseBoxInputHint.enabled = false;
			}
			ClippingObjectBehaviour.SetRenderersLayer(ClippingObjectBehaviour.ELayerType.DEFAULT);
			IsDropped = true;
			World.ScoreManager.ComputeFromScore(ScoreSettings.DropBoxScoreMalus, "Malus due to dropping box");
		}

		void IGrabbable.OnGivenBy(IGrabber grabber)
		{
			IsGrabbed = false;
			OnGivenBy(grabber);
			this.OnGiven?.Invoke();
		}

		protected virtual void OnGivenBy(IGrabber grabber)
		{
			m_rigidbody.isKinematic = true;
			m_collider.enabled = true;
			if (m_baseBoxInputHint != null)
			{
				m_baseBoxInputHint.enabled = false;
			}
			if (grabber is GenericGrabber)
			{
				Register(register: true, this);
			}
		}

		void IGrabbable.OnGivenTo(IGrabber grabber)
		{
			OnGivenTo(grabber);
		}

		protected virtual void OnGivenTo(IGrabber grabber)
		{
		}

		public virtual bool CanBeDropped()
		{
			return true;
		}

		public virtual bool CanBeToggled()
		{
			return !IsOpen;
		}

		public bool ToggleOpenState()
		{
			IsOpen = !IsOpen;
			if (IsOpen)
			{
				Open();
			}
			else
			{
				Close();
			}
			return IsOpen;
		}

		private void Open()
		{
			OnOpen();
			this.OnOpened?.Invoke();
		}

		protected virtual void OnOpen()
		{
			SetStateForThisInputHint(state: false);
			SetVisualOpen(open: true);
		}

		private void Close()
		{
			OnClose();
		}

		protected virtual void OnClose()
		{
			SetVisualOpen(open: false);
		}

		public abstract BoxSaveState GetSaveState();

		protected abstract void Load(BaseShopBoxData data, BoxSaveState saveState);

		protected virtual void SetVisualOpen(bool open)
		{
			if (Animator != null)
			{
				Animator.SetBool(OpenParamID, open);
			}
		}

		private void SetStateForThisInputHint(bool state)
		{
			if (!(m_baseBoxInputHint == null))
			{
				if (state)
				{
					m_baseBoxInputHint.AddFlagsAndRefreshInputHint(BaseBoxInputHint.EActionFlags.OPENABLE);
				}
				else
				{
					m_baseBoxInputHint.RemoveFlagsAndRefreshInputHint(BaseBoxInputHint.EActionFlags.OPENABLE);
				}
			}
		}

		protected static void Register(bool register, BaseBox box)
		{
			if (register)
			{
				_boxes.Add(box);
			}
			else
			{
				_boxes.Remove(box);
			}
		}

		public static IEnumerable<BoxSaveState> GetBoxesToSave()
		{
			foreach (BaseBox box in _boxes)
			{
				if (box != null)
				{
					yield return box.GetSaveState();
				}
			}
		}

		public static BaseBox LoadBoxFromSave(BoxSaveState save)
		{
			if (MarketStoreDatabase.TryGet(save.uid, out var data))
			{
				BaseBox component = UnityEngine.Object.Instantiate(data.Prefab, save.position, save.rotation).GetComponent<BaseBox>();
				component.IsDropped = !save.grabbed;
				component.Load(data, save);
				if (save.grabbed)
				{
					World.PlayerCharacter.Grab(component);
				}
				return component;
			}
			return null;
		}
	}
}
