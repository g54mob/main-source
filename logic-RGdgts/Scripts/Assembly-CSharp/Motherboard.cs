using System;
using System.Collections.Generic;
using DG.Tweening;
using SE.EvilLib.AudioManager;
using UnityEngine;
using UnityEngine.Rendering;

public class Motherboard : MonoBehaviour
{
	public enum Position
	{
		Table = 0,
		Archive = 1,
		Floating = 2
	}

	public enum Layer
	{
		Bottom = 0,
		Pcb = 1,
		Cover = 2,
		BottomExtra = 3,
		PcbExtra = 4,
		CoverExtra = 5,
		MixMap = 1000
	}

	public class MixmapData
	{
		public Color32[] pixels;

		public int width;

		public int height;

		public MixmapData(Texture2D texture)
		{
		}

		public bool IsBorder(Vector2Int position, MotherboardSide side)
		{
			return false;
		}

		public bool SearchNearestBorder(Vector2Int position, int maxDistance, out Vector2Int borderPosition, out MotherboardSide borderSide)
		{
			borderPosition = default(Vector2Int);
			borderSide = default(MotherboardSide);
			return false;
		}

		public void GetBorderExtents(Vector2Int position, MotherboardSide side, out int min, out int max)
		{
			min = default(int);
			max = default(int);
		}
	}

	public class Connection
	{
		public MagneticConnectorModule sourceConnector;

		public MagneticConnectorModule targetConnector;

		public Motherboard sourceMotherboard => null;

		public Motherboard targetMotherboard => null;

		public Connection(MagneticConnectorModule sourceConnector, MagneticConnectorModule targetConnector)
		{
		}
	}

	public class Group
	{
		public HashSet<Motherboard> motherboards;

		public Rect rect => default(Rect);

		public bool Contains(Motherboard motherboard)
		{
			return false;
		}

		public bool IsOverlapping(Motherboard otherMotherboard, out Vector2 overlapPoint)
		{
			overlapPoint = default(Vector2);
			return false;
		}

		public void SetPosition(Position position)
		{
		}
	}

	public static float liftTweenTime;

	[NonSerialized]
	[HideInInspector]
	public MixmapData mixmapData;

	public static Layer[] sortedLayers;

	public Transform cableSocket;

	public MotherboardLayerRenderer bottomRenderer;

	public MotherboardLayerRenderer pcbRenderer;

	public MotherboardLayerRenderer coverRenderer;

	public MotherboardLayerRenderer bottomExtraRenderer;

	public MotherboardLayerRenderer pcbExtraRenderer;

	public MotherboardLayerRenderer coverExtraRenderer;

	public MotherboardLayerRenderer mixMapRenderer;

	private GadgetCoverMaterial _coverMaterial;

	public MotherboardCover motherboardCover;

	public MotherboardPcb motherboardPcb;

	public MotherboardBottom motherboardBottom;

	[HideInInspector]
	public float width;

	[HideInInspector]
	public float height;

	public Transform collidersRoot;

	public PixelShape pcbFullPixelShape;

	public PixelShape pcbCenterPixelShape;

	public PixelShape pcbBordersPixelShape;

	[NonSerialized]
	[HideInInspector]
	public PixelShape bottomPixelShape;

	[HideInInspector]
	public InteractableMotherboard interactableMotherboard;

	public uint id;

	[NonSerialized]
	[HideInInspector]
	public List<Connection> connections;

	private Transform pcbOrigin;

	[NonSerialized]
	[HideInInspector]
	public Transform pcbRoot;

	private SortingGroup pcbSortingGroup;

	[NonSerialized]
	[HideInInspector]
	public Transform[] modulesTransforms;

	public static float lastPoisitionChangeSfxTime;

	[NonSerialized]
	[HideInInspector]
	public List<Module>[] modules;

	[NonSerialized]
	[HideInInspector]
	public MotherboardShape shape;

	[HideInInspector]
	public Gadget gadget;

	private SpriteShadow shadow;

	private Tweener liftTween;

	[NonSerialized]
	[HideInInspector]
	public List<Sticker> stickers;

	private bool init;

	public GadgetCoverMaterial coverMaterial
	{
		get
		{
			return default(GadgetCoverMaterial);
		}
		set
		{
		}
	}

	public Rect gridBounds { get; private set; }

	public Transform visibleModulesTransform => null;

	public int modulesCount => 0;

	public ICollection<Module> visibleModules => null;

	public PcbSide pcbSide => default(PcbSide);

	public bool isOpen => false;

	public Position position { get; private set; }

	public string motherboardBackSortingLayer => null;

	public string motherboardPcbSortingLayer => null;

	public string caseSortingLayer => null;

	public MotherboardLayerRenderer GetLayerRenderer(Layer layer)
	{
		return null;
	}

	public bool IsPositionChangeComplete()
	{
		return false;
	}

	public string GetModulesBackSortingLayer(PcbSide pcbSide)
	{
		return null;
	}

	public string GetModulesBottomSortingLayer(PcbSide pcbSide)
	{
		return null;
	}

	public string GetModulesTopSortingLayer(PcbSide pcbSide)
	{
		return null;
	}

	private void Init()
	{
	}

	public void Setup(Gadget gadget, MotherboardShape shape)
	{
	}

	public void RefreshRendering()
	{
	}

	public void RefreshShape()
	{
	}

	public void CheckNeededModules()
	{
	}

	public void SetPosition(Position position)
	{
	}

	public void OnPositionChange(Position position, AudioTypeSfx? forceSfx = null)
	{
	}

	public void OpenCover(float speed = 1f)
	{
	}

	public void CloseCover(float speed = 1f)
	{
	}

	public void OnCaseOpen()
	{
	}

	public void OnCaseClose()
	{
	}

	public void OnShowPcbSide(PcbSide pcbSide)
	{
	}

	public void OnShowPcbSideAnimationComplete(PcbSide pcbSide)
	{
	}

	private Connection GetConnection(MagneticConnectorModule sourceConnector)
	{
		return null;
	}

	private Connection RemoveConnection(MagneticConnectorModule sourceConnector)
	{
		return null;
	}

	public void OnGadgetDeserialized()
	{
	}

	public void Connect(MagneticConnectorModule sourceConnector, MagneticConnectorModule targetConnector)
	{
	}

	public void Disconnect(MagneticConnectorModule sourceConnector)
	{
	}

	private static void ScanConnectedMotherboards(Motherboard motherboard, Group group)
	{
	}

	public Group GetConnectedGroup()
	{
		return null;
	}

	public void ApplySticker(Sticker sticker, Vector2 position, bool immediate)
	{
	}

	public void RemoveSticker(Sticker sticker, bool immediate, bool willMoveImmediatly)
	{
	}

	private void RefreshStickers()
	{
	}

	public bool MoveModuleToValidPosition(Module module, PcbSide pcbSide, bool inverseAlignement = false)
	{
		return false;
	}

	public bool CanModuleBePlaced(Module module, PcbSide pcbSide, out bool validMotherboardPosition, out Vector2 invalidPoint, ref Vector3 desiredPosition, ref int desiredRotation, bool snapping = true)
	{
		validMotherboardPosition = default(bool);
		invalidPoint = default(Vector2);
		return false;
	}

	private float FindDistanceToSegment(Vector2 pt, Vector2 p1, Vector2 p2, out Vector2 closest)
	{
		closest = default(Vector2);
		return 0f;
	}

	public bool IsPointInside(Vector2 point)
	{
		return false;
	}

	public bool IsOverlapping(Motherboard otherMotherboard, out Vector2 overlapPoint)
	{
		overlapPoint = default(Vector2);
		return false;
	}

	public Sticker GetSticker(Vector2 position)
	{
		return null;
	}

	private void OnDisable()
	{
	}

	private void LateUpdate()
	{
	}

	private void OnDestroy()
	{
	}
}
