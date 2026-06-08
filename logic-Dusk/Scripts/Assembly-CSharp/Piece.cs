using System.Collections.Generic;
using UnityEngine;

public class Piece : MonoBehaviour
{
	public delegate void PieceEventHander(Piece piece, bool enabled);

	protected Vector3 basePosition;

	protected bool rotatesToCamera = true;

	public bool isSpellPiece;

	private TileData _tile;

	private int _player = -1;

	private int _originalPlayer = -1;

	public BoardScript board;

	public List<Movement> movements;

	public bool CanMoveDiag;

	public bool CanMoveStraight;

	public int MaxMoveStep;

	protected List<TileData> tileList = new List<TileData>(1);

	private static int uniqueIdCounter = 1;

	private int id;

	private Color originalColor = Color.black;

	private ColorBlinkManager blinkManager = new ColorBlinkManager();

	public virtual bool IsMultiTilePiece
	{
		get
		{
			return false;
		}
	}

	public virtual int NumberOfPieces
	{
		get
		{
			return 1;
		}
	}

	public TileData tile
	{
		get
		{
			if (!IsMultiTilePiece)
			{
				return _tile;
			}
			if (tileList.Count > 0)
			{
				return tileList[0];
			}
			return null;
		}
		set
		{
			if (!IsMultiTilePiece)
			{
				if (_tile != null)
				{
					_tile.visualComponent.RemovePiece(this);
				}
				_tile = value;
				if (_tile != null)
				{
					_tile.visualComponent.AddPiece(this);
				}
			}
			else
			{
				AddTile(value);
			}
		}
	}

	public int player
	{
		get
		{
			return _player;
		}
		set
		{
			_player = value;
			if (_originalPlayer == -1)
			{
				_originalPlayer = value;
			}
		}
	}

	public bool CanKill { get; set; }

	public virtual Vector3 OriginOffset
	{
		get
		{
			return Vector3.zero;
		}
	}

	public virtual float RotAngleOffset
	{
		get
		{
			return 0f;
		}
	}

	public virtual float PieceHeight
	{
		get
		{
			return 0.15f;
		}
	}

	public virtual bool CanRotate
	{
		get
		{
			return false;
		}
	}

	public bool IsBlinking
	{
		get
		{
			return blinkManager.IsActive;
		}
	}

	public PieceTypeEnum pieceType { get; set; }

	public bool Enabled { get; set; }

	public int Id
	{
		get
		{
			return id;
		}
	}

	public event PieceEventHander MouseDownOnPieceEvent;

	public event PieceEventHander MouseUpOnPieceEvent;

	public event PieceEventHander MouseEnterPieceEvent;

	public event PieceEventHander MouseExitPieceEvent;

	public Piece()
	{
		CanKill = true;
	}

	protected virtual void Awake()
	{
		id = uniqueIdCounter++;
		movements = new List<Movement>();
		blinkManager.OnBlinkDone -= OnPieceDoneBlinking;
		blinkManager.OnBlinkDone += OnPieceDoneBlinking;
		originalColor = GetComponent<Renderer>().material.color;
	}

	protected virtual void Start()
	{
	}

	private void Update()
	{
		if (blinkManager.IsActive)
		{
			GetComponent<Renderer>().material.color = blinkManager.Update(Time.deltaTime);
		}
	}

	public virtual bool CanPlaceOnTile(TileData tile)
	{
		return true;
	}

	protected virtual void AddTile(TileData tile)
	{
	}

	public void Enable()
	{
		Enabled = true;
	}

	public void Disable()
	{
		Enabled = false;
	}

	public virtual void ToggleRotation()
	{
		if (!CanRotate)
		{
		}
	}

	public virtual List<TileData> GetTileList()
	{
		return tileList;
	}

	private void OnMouseDown()
	{
		if (this.MouseDownOnPieceEvent != null)
		{
			this.MouseDownOnPieceEvent(this, Enabled);
		}
	}

	private void OnMouseUp()
	{
		if (this.MouseUpOnPieceEvent != null)
		{
			this.MouseUpOnPieceEvent(this, Enabled);
		}
	}

	private void OnMouseEnter()
	{
		if (this.MouseEnterPieceEvent != null)
		{
			this.MouseEnterPieceEvent(this, Enabled);
		}
	}

	private void OnMouseExit()
	{
		if (this.MouseExitPieceEvent != null)
		{
			this.MouseExitPieceEvent(this, Enabled);
		}
	}

	public string LogString()
	{
		return "Base Piece";
	}

	public void reCalcPosition()
	{
		setPosition(basePosition);
	}

	public void setPosition(Vector3 position)
	{
		basePosition = position;
		position += OriginOffset;
		position.y += PieceHeight;
		base.transform.position = position + new Vector3(0f, 0.001f, 0f);
	}

	public void rotate()
	{
	}

	public void rotateToCamera()
	{
		if (rotatesToCamera)
		{
			base.transform.forward = Vector3.Scale(new Vector3(-1f, 0f, -1f), Camera.main.transform.forward);
			reCalcPosition();
		}
	}

	public void moveToTile(TileData tile)
	{
		moveToTile(tile, false);
	}

	public void moveToTile(TileData tile, bool immediate)
	{
		this.tile = tile;
		if (immediate)
		{
			setPosition(tile.visualComponent.transform.position);
		}
	}

	public void Remove()
	{
	}

	public void InitializePiece()
	{
		GameObject gameObject = GameObject.Find("Board");
		board = (BoardScript)gameObject.GetComponent(typeof(BoardScript));
	}

	private void OnDestroy()
	{
	}

	public void SuperSecretSetId(int newId)
	{
		id = newId;
	}

	public void StartPieceBlinking()
	{
		Color startColor = originalColor;
		Color endColor = originalColor;
		endColor.a = 0.3f;
		blinkManager.Start(startColor, endColor, 1f);
	}

	public void StopPieceBlinking()
	{
		blinkManager.Stop();
	}

	private void OnPieceDoneBlinking()
	{
		GetComponent<Renderer>().material.color = originalColor;
	}
}
