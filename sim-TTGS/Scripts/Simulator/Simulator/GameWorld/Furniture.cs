using System;
using Dhs5.Utility.Databases;
using I2.Loc;
using UnityEngine;

namespace Simulator.GameWorld
{
	public abstract class Furniture : MonoBehaviour, ISensable, IDataContainerElement
	{
		[Header("Furniture")]
		[SerializeField]
		[ReadOnly(false, false)]
		private int m_modelUID;

		[SerializeField]
		private bool m_canBeSold;

		[SerializeField]
		protected EFurnitureZone m_zone = EFurnitureZone.SHOP;

		[SerializeField]
		private Calculation m_scoreBonusOnPlaced;

		[SerializeField]
		[TermsPopup("")]
		private string m_scoreBonusTooltipTerm;

		[Header("Detection")]
		[SerializeField]
		private Outline m_outline;

		[SerializeField]
		private InputHint m_inputHint;

		[Header("Grid Placement")]
		[SerializeField]
		private Rigidbody m_rigidbody;

		[SerializeField]
		protected FurniturePhantom m_phantom;

		[Header("Models")]
		[SerializeField]
		protected GameObject m_model;

		private bool m_initialized;

		protected Vector3 m_phantomPosition;

		protected EFurnitureOrientation m_phantomOrientation;

		public int GameID { get; private set; }

		public abstract EFurnitureType Type { get; }

		public bool CanBeSold => m_canBeSold;

		public EFurnitureZone Zone => m_zone;

		public FurnitureMover Mover { get; private set; }

		public bool IsMoving => Mover != null;

		public EFurnitureOrientation Orientation { get; private set; }

		public Vector3 Position => m_rigidbody.position;

		public int UID
		{
			get
			{
				return m_modelUID;
			}
			set
			{
				m_modelUID = value;
			}
		}

		string IDataContainerElement.name
		{
			get
			{
				return base.name;
			}
			set
			{
				base.name = value;
			}
		}

		public event Action Initialized;

		public event Action Destroyed;

		public event Action<Furniture, Vector3> Moved;

		public static event Action<Furniture, bool> MoveAny;

		protected virtual void OnEnable()
		{
		}

		protected virtual void OnDisable()
		{
		}

		public virtual void Init(int gameID, Vector3 position, EFurnitureOrientation orientation, bool addScore = false)
		{
			m_initialized = true;
			GameID = gameID;
			InitPosition(position);
			SetOrientation(orientation);
			if (addScore)
			{
				World.ScoreManager.ComputeFromScore(m_scoreBonusOnPlaced, "Bonus due to placing " + GetType().Name);
			}
			this.Initialized?.Invoke();
		}

		public virtual void PreInit(int gameID)
		{
			m_initialized = false;
			GameID = gameID;
		}

		public virtual void PrepareDestruction()
		{
			this.Destroyed?.Invoke();
			World.ScoreManager.ComputeFromScore(m_scoreBonusOnPlaced.ReverseOperator(), "Reversing bonus due to removing " + GetType().Name);
		}

		public virtual void Load(int phase, SaveClass_Furnitures.FurnitureState state)
		{
			if (phase == 1)
			{
				Init(state.gameID, state.GetPosition(), state.orientation);
			}
		}

		public virtual void InitPostLoad(SaveClass_Furnitures.FurnitureState state)
		{
		}

		public virtual SaveClass_Furnitures.FurnitureState Save()
		{
			return new SaveClass_Furnitures.FurnitureState(this);
		}

		public virtual bool CanBeMoved()
		{
			return true;
		}

		public virtual void OnStartMoveBy(FurnitureMover mover)
		{
			Mover = mover;
			m_model.SetActive(value: false);
			m_phantomPosition = Position;
			m_phantom.transform.localPosition = Vector3.zero;
			m_phantomOrientation = Orientation;
			m_phantom.transform.eulerAngles = GetRotationFromOrientation(Orientation);
			Furniture.MoveAny?.Invoke(this, arg2: true);
		}

		public virtual void OnCancelMove()
		{
			OnStopMove();
		}

		public virtual void OnCompleteMove()
		{
			m_rigidbody.MovePosition(m_phantom.transform.position);
			m_rigidbody.MoveRotation(m_phantom.transform.rotation);
			Orientation = m_phantomOrientation;
			OnStopMove();
		}

		protected virtual void OnStopMove()
		{
			Mover = null;
			m_model.SetActive(value: true);
			m_phantom.transform.localPosition = Vector3.zero;
			m_phantom.transform.localEulerAngles = Vector3.zero;
			Furniture.MoveAny?.Invoke(this, arg2: false);
		}

		public abstract void RotatePhantom(int input);

		public void MovePhantom(Vector3 worldPosition)
		{
			m_phantomPosition = ComputePhantomPosition(worldPosition);
			m_phantom.transform.position = m_phantomPosition;
			SpaceCheck();
		}

		public bool Put()
		{
			Vector3 position = Position;
			if (!m_initialized)
			{
				if (m_phantom.PositionValid)
				{
					Init(GameID, m_phantomPosition, m_phantomOrientation, addScore: true);
					OnCompleteMove();
					this.Moved?.Invoke(this, position);
					return true;
				}
			}
			else if (m_phantom.PositionValid)
			{
				OnCompleteMove();
				this.Moved?.Invoke(this, position);
				return true;
			}
			return false;
		}

		protected virtual bool IsInsideLimits()
		{
			Bounds bounds = m_phantom.GetBounds();
			if ((m_zone & EFurnitureZone.SHOP) == 0 && bounds.max.z <= FurnitureSettings.MaxZ)
			{
				return false;
			}
			if ((m_zone & EFurnitureZone.RESERVE) == 0 && bounds.min.z > FurnitureSettings.MaxZ)
			{
				return false;
			}
			return bounds.max.x <= FurnitureSettings.MaxX;
		}

		protected virtual bool SpaceCheck()
		{
			if (!IsInsideLimits())
			{
				m_phantom.ForceSpaceCheckResult(result: false);
				return false;
			}
			int layerMask = Type switch
			{
				EFurnitureType.GROUND => FurnitureSettings.GroundFurniturePhantomMask, 
				EFurnitureType.CEILING => FurnitureSettings.CeilingFurniturePhantomMask, 
				EFurnitureType.WALLS => FurnitureSettings.WallsFurniturePhantomMask, 
				_ => 0, 
			};
			return m_phantom.SpaceCheck(layerMask);
		}

		protected abstract void InitPosition(Vector3 position);

		protected abstract Vector3 ComputePhantomPosition(Vector3 worldPosition);

		protected Vector3 GetRotationFromOrientation(EFurnitureOrientation orientation)
		{
			return orientation switch
			{
				EFurnitureOrientation._45 => new Vector3(0f, 45f, 0f), 
				EFurnitureOrientation._90 => new Vector3(0f, 90f, 0f), 
				EFurnitureOrientation._135 => new Vector3(0f, 135f, 0f), 
				EFurnitureOrientation._180 => new Vector3(0f, 180f, 0f), 
				EFurnitureOrientation._225 => new Vector3(0f, 225f, 0f), 
				EFurnitureOrientation._270 => new Vector3(0f, 270f, 0f), 
				EFurnitureOrientation._315 => new Vector3(0f, 315f, 0f), 
				_ => new Vector3(0f, 0f, 0f), 
			};
		}

		protected EFurnitureOrientation GetOrientationFromNormal(Vector3 normal)
		{
			float num = Vector2.SignedAngle(Vector2.up, new Vector2(normal.x, normal.z));
			if (num < -110f)
			{
				return EFurnitureOrientation._135;
			}
			if (num < -65f)
			{
				return EFurnitureOrientation._90;
			}
			if (num < -20f)
			{
				return EFurnitureOrientation._45;
			}
			if (num < 20f)
			{
				return EFurnitureOrientation.FORWARD;
			}
			if (num < 65f)
			{
				return EFurnitureOrientation._315;
			}
			if (num < 110f)
			{
				return EFurnitureOrientation._270;
			}
			if (num < 155f)
			{
				return EFurnitureOrientation._225;
			}
			return EFurnitureOrientation._180;
		}

		protected virtual void SetOrientation(EFurnitureOrientation orientation)
		{
			Orientation = orientation;
			base.transform.eulerAngles = GetRotationFromOrientation(orientation);
		}

		public virtual bool CanBeSensed()
		{
			if (World.PlayerController.Context == EControllerContext.CHARACTER)
			{
				return World.PlayerCharacter.CharacterContext == EPlayerCharacterContext.NONE;
			}
			return false;
		}

		public virtual void OnSensed()
		{
			m_outline.enabled = true;
			if (m_inputHint != null)
			{
				m_inputHint.enabled = true;
			}
			if (!string.IsNullOrEmpty(m_scoreBonusTooltipTerm))
			{
				HUD.ShowTooltip(m_scoreBonusTooltipTerm);
			}
		}

		public virtual void OnUnsensed()
		{
			m_outline.enabled = false;
			if (m_inputHint != null)
			{
				m_inputHint.enabled = false;
			}
			HUD.HideTooltip();
		}

		Type IDataContainerElement.GetType()
		{
			return GetType();
		}
	}
}
