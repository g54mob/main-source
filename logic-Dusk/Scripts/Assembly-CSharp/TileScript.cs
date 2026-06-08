using UnityEngine;

public class TileScript : MonoBehaviour
{
	public struct TileTextures
	{
		public Texture2D LetterB;

		public Texture2D LetterC;

		public Texture2D LetterD;

		public Texture2D LetterE;

		public Texture2D LetterF;

		public Texture2D LetterG;

		public Texture2D Number2;

		public Texture2D Number3;

		public Texture2D Number4;

		public Texture2D Number5;

		public Texture2D Number6;

		public Texture2D Number7;

		public Texture2D LowerLeftCorner1A;

		public Texture2D UpperLeftCorner8A;

		public Texture2D LowerRightCorner1H;

		public Texture2D UpperRightCorner8H;
	}

	public delegate void TileEventHandler(TileData tile);

	public BoardScript board;

	public Color highlightColor;

	private Color defaultColor;

	public static TileTextures Textures;

	private AutoFadeColorManager highlightFadeManager = new AutoFadeColorManager();

	private ColorContextStack colorContextStack = new ColorContextStack();

	public TileData parentTileData { get; set; }

	public Piece piece { get; private set; }

	public Piece pieceSecondary { get; private set; }

	public event TileEventHandler MouseDownOnTileEvent;

	public event TileEventHandler MouseDownOnEdgeEvent;

	public event TileEventHandler MouseUpOnTileEvent;

	public event TileEventHandler MouseEnterTileEvent;

	public event TileEventHandler MouseExitTileEvent;

	private void Awake()
	{
		if (Textures.LowerLeftCorner1A == null)
		{
			InitTileTextures();
		}
		highlightFadeManager.OnFadeDone += DoneFadingTileHighlight;
	}

	private static void InitTileTextures()
	{
	}

	private void Start()
	{
		defaultColor = GetComponent<Renderer>().material.color;
		colorContextStack.SetDefaultColor(defaultColor);
	}

	private void Update()
	{
		if (highlightFadeManager.FadeIsInProgress)
		{
			Color color = highlightFadeManager.Update(Time.deltaTime);
			if (colorContextStack.Count() == 0)
			{
				GetComponent<Renderer>().material.color = color;
			}
		}
	}

	public void SetColor(Color newColor)
	{
		if (GetComponent<Renderer>() != null)
		{
			GetComponent<Renderer>().material.color = newColor;
			defaultColor = GetComponent<Renderer>().material.color;
			colorContextStack.SetDefaultColor(defaultColor);
		}
	}

	public void SetTexture(Texture2D texture)
	{
		GetComponent<Renderer>().material.mainTexture = texture;
	}

	private void OnMouseDown()
	{
		if (!GetComponent<Renderer>().enabled)
		{
			return;
		}
		if (parentTileData != null && (parentTileData.edgeType == TileData.EdgeTypeEnum.Unknown || this.MouseDownOnEdgeEvent == null))
		{
			if (this.MouseDownOnTileEvent != null)
			{
				this.MouseDownOnTileEvent(parentTileData);
			}
		}
		else if (this.MouseDownOnEdgeEvent != null)
		{
			this.MouseDownOnEdgeEvent(parentTileData);
		}
	}

	private void OnMouseUp()
	{
		if (GetComponent<Renderer>().enabled && this.MouseUpOnTileEvent != null)
		{
			this.MouseUpOnTileEvent(parentTileData);
		}
	}

	private void OnMouseEnter()
	{
		if (GetComponent<Renderer>().enabled)
		{
			if (InputState.leftMBDown)
			{
				OnMouseDown();
			}
			if (this.MouseEnterTileEvent != null)
			{
				this.MouseEnterTileEvent(parentTileData);
			}
		}
	}

	private void OnMouseExit()
	{
		if (GetComponent<Renderer>().enabled && this.MouseExitTileEvent != null)
		{
			this.MouseExitTileEvent(parentTileData);
		}
	}

	public void TriggerOnMouseUp()
	{
		OnMouseUp();
	}

	public void TriggerOnMouseDown()
	{
		OnMouseDown();
	}

	public void TriggerOnMouseEnter()
	{
		OnMouseEnter();
	}

	public void TriggerOnMouseExit()
	{
		OnMouseExit();
	}

	public void SetTileHighLightColor(Color color, float lerpFactor, string context)
	{
		GetComponent<Renderer>().material.color = colorContextStack.Push(color, lerpFactor, context);
	}

	public void ClearTileHighLightColor(string context)
	{
		GetComponent<Renderer>().material.color = colorContextStack.Remove(context);
	}

	public void ClearAllHighlights()
	{
		GetComponent<Renderer>().material.color = colorContextStack.ClearAllColors();
	}

	public void AddPiece(Piece piece)
	{
		if (this.piece != null && this.piece.pieceType == PieceTypeEnum.Swamp)
		{
			pieceSecondary = this.piece;
		}
		this.piece = piece;
	}

	public void RemovePiece(Piece piece)
	{
		if (pieceSecondary != null)
		{
			this.piece = pieceSecondary;
			pieceSecondary = null;
		}
		else
		{
			this.piece = null;
		}
	}

	public bool CouldAccetpPiece(Piece newPiece)
	{
		if (piece == null)
		{
			return true;
		}
		return false;
	}

	public void StartAutoFadedHighlight(Color color)
	{
		highlightFadeManager.StartFade(color, defaultColor, 0.5f, 1f);
	}

	private void DoneFadingTileHighlight()
	{
		if (colorContextStack.Count() == 0)
		{
			GetComponent<Renderer>().material.color = defaultColor;
		}
	}
}
