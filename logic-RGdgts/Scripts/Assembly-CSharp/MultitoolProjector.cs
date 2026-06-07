using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class MultitoolProjector : MonoBehaviour
{
	private abstract class Mode : IEnumerator
	{
		private bool abort;

		public object Current => null;

		public abstract void Start();

		public abstract void Stop();

		public abstract void Update();

		public abstract bool IsComplete();

		public void Abort()
		{
		}

		public void Reset()
		{
		}

		public bool MoveNext()
		{
			return false;
		}
	}

	private class ChangeGadgetCoverMaterialMode : Mode
	{
		private SpriteRenderer rendererObject;

		private Sprite sprite;

		private GadgetScreenshooter.Result previewResult;

		private Material changeGadgetMaterialPreviewMaterial;

		private Material blitAlphaMaterial;

		private Sequence sequence;

		private bool complete;

		private Gadget gadget;

		private GadgetCoverMaterial coverMaterial;

		private float progress;

		private float speed;

		private int lineSize;

		private float alphaPixelW;

		private float alphaPixelH;

		private Action onComplete;

		public ChangeGadgetCoverMaterialMode(Gadget gadget, GadgetCoverMaterial coverMaterial, Action onComplete)
		{
		}

		private Texture2D DownsampleAlpha(Texture2D colormap, int lineSize)
		{
			return null;
		}

		private List<Vector2Int> BuildGradient(Texture2D alphaTexture)
		{
			return null;
		}

		private Vector3 PixelPosition(Vector2Int p)
		{
			return default(Vector3);
		}

		public override void Start()
		{
		}

		public override void Stop()
		{
		}

		public override bool IsComplete()
		{
			return false;
		}

		private void CleanAll()
		{
		}

		public override void Update()
		{
		}
	}

	private class DestroyMode : Mode
	{
		private struct PosInfo
		{
			public RangeInt x;

			public int y;

			public Vector2Int min => default(Vector2Int);

			public Vector2Int max => default(Vector2Int);

			public PosInfo(RangeInt x, int y)
			{
				this.x = default(RangeInt);
				this.y = 0;
			}
		}

		private SpriteRenderer rendererObject;

		private Sprite sprite;

		private GadgetScreenshooter.Result previewResult;

		private Material destroyingGadgetPreviewMaterial;

		private Material blitAlphaMaterial;

		private Sequence sequence;

		private bool complete;

		private Gadget gadget;

		private float progress;

		private float speed;

		private int lineSize;

		private float alphaPixelW;

		private float alphaPixelH;

		private Action onComplete;

		public DestroyMode(Gadget gadget, Action onComplete)
		{
		}

		private Texture2D DownsampleAlpha(Texture2D colormap, int lineSize)
		{
			return null;
		}

		private List<PosInfo> BuildGradient(Texture2D alphaTexture)
		{
			return null;
		}

		private Vector3 PixelPosition(Vector2Int p)
		{
			return default(Vector3);
		}

		public override void Start()
		{
		}

		public override void Stop()
		{
		}

		public override bool IsComplete()
		{
			return false;
		}

		private void CleanAll()
		{
		}

		public override void Update()
		{
		}
	}

	private class EditHardwareMode : Mode
	{
		private bool isComplete;

		private MultitoolProjector_EditHardwareRay ray;

		public override void Start()
		{
		}

		public override void Stop()
		{
		}

		public override bool IsComplete()
		{
			return false;
		}

		public override void Update()
		{
		}

		public void OnHardwareEdit()
		{
		}
	}

	private class PrintMode : Mode
	{
		private SpriteRenderer rendererObject;

		private Sprite sprite;

		private GadgetScreenshooter.Result previewResult;

		private Material printingGadgetPreviewMaterial;

		private Material blitAlphaMaterial;

		private Sequence sequence;

		private bool complete;

		private Gadget gadget;

		private float progress;

		private float speed;

		private int lineSize;

		private float alphaPixelW;

		private float alphaPixelH;

		private Action onComplete;

		public PrintMode(Gadget gadget, Action onComplete)
		{
		}

		private Texture2D DownsampleAlpha(Texture2D colormap, int lineSize)
		{
			return null;
		}

		private List<Vector2Int> BuildGradient(Texture2D alphaTexture)
		{
			return null;
		}

		private Vector3 PixelPosition(Vector2Int p)
		{
			return default(Vector3);
		}

		public override void Start()
		{
		}

		public override void Stop()
		{
		}

		public override bool IsComplete()
		{
			return false;
		}

		private void CleanAll()
		{
		}

		public override void Update()
		{
		}
	}

	private class ProjectMode : Mode
	{
		private int border;

		private GameObject parentGO;

		private SpriteRenderer rendererObject;

		private List<Material> materials;

		private GadgetScreenshooter.Result? previewResult;

		private bool stop;

		private bool complete;

		private Sequence sequence;

		private SerializedGadgetMetaData metadata;

		public ProjectMode(SerializedGadgetMetaData metadata)
		{
		}

		public override void Start()
		{
		}

		public override void Stop()
		{
		}

		public override bool IsComplete()
		{
			return false;
		}

		public override void Update()
		{
		}
	}

	private class SoldererMode : Mode
	{
		private bool isComplete;

		private MultitoolProjector_SoldererRay ray;

		public override void Start()
		{
		}

		public override void Stop()
		{
		}

		public override bool IsComplete()
		{
			return false;
		}

		public override void Update()
		{
		}

		public void OnHardwareSoldering()
		{
		}
	}

	public DraggablePanel panel;

	public SpriteRenderer spriteRenderer;

	public Sprite[] sprites;

	public MultitoolProjector_PrintRay printRay;

	public MultitoolProjector_DestroyRay destroyRay;

	public MultitoolProjector_EditHardwareRay editHardwareRay;

	public MultitoolProjector_SoldererRay soldererRay;

	private bool status;

	private int animI;

	private float lastFrameChange;

	private float delay;

	public float xOffset;

	private float xOffsetVel;

	private float length;

	private Mode mode;

	private Mode nextMode;

	private float lastOpenSfxTime;

	private float lastCloseSfxTime;

	public bool isOpen => false;

	public bool isEditHardwareMode => false;

	private void Awake()
	{
	}

	public void OnOpen()
	{
	}

	public void OnClosed()
	{
	}

	private void Update()
	{
	}

	public void ProjectGadget(SerializedGadgetMetaData metadata)
	{
	}

	public IEnumerator PrintGadget(SerializedGadgetMetaData metadata, Action onComplete = null)
	{
		return null;
	}

	public IEnumerator DestroyGadget(Action onComplete = null)
	{
		return null;
	}

	public void StartEditHardware()
	{
	}

	public IEnumerator ChangeGadgetCoverMaterial(GadgetCoverMaterial coverMaterial, Action onComplete = null)
	{
		return null;
	}

	public void OnHardwareEdit()
	{
	}

	public void Stop()
	{
	}

	public MultitoolProjector_SoldererRay SetSolderingMode()
	{
		return null;
	}
}
