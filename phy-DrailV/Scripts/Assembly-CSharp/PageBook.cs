using System;
using System.Collections;
using System.Collections.Generic;
using DV;
using DV.CabControls;
using DV.JObjectExtstensions;
using DV.Utils;
using Newtonsoft.Json.Linq;
using UnityEngine;

[RequireComponent(typeof(ItemSaveData))]
public class PageBook : MonoBehaviour, IScrollable
{
	private const string PAGE_NUMBER_SAVE_KEY = "BookletPageNumber";

	private const string HIGHLIGHT_MODEL_NAME = "[highlight model]";

	private const string PAPER_NAME = "paper";

	private const string PAGE_FLIPPING_HELPER_NAME = "PageFlippingHelper";

	private const float MIN_COLLIDER_THICKNESS = 0.005f;

	private readonly Vector2 PAPER_SIZE = new Vector2(0.296f, 0.421f);

	public bool generateOnStart = true;

	public bool destroyTemplate;

	public GameObject PageFlippingHelperOverridePrefab;

	[Header("Textures")]
	public Page pageTemplate;

	public Texture[] pageTextures;

	public Material innerPagesMaterial;

	public Material coverMaterial;

	[Header("Parameters")]
	public ScrollAction positiveScrollDirection = ScrollAction.ScrollLeft;

	public float pageSeparation = 0.001f;

	public bool autoColliderThickness = true;

	public int currentPage;

	public SoundList flipAudio;

	[NonSerialized]
	public GameObject bookVolumeModel;

	private ItemBase item;

	public readonly List<Page> pages = new List<Page>();

	private Transform motionPivot;

	private ItemScrolling scrolling;

	private Coroutine pivotCoro;

	private Coroutine initialPageCoro;

	private float pivotOffset;

	private float pivotSmoothVelo;

	private ItemSaveData itemSaveData;

	private bool started;

	private GameObject highlight;

	public bool PagesGenerated { get; private set; }

	public int PageNum => pageTextures.Length;

	public event Action<int> PageFlipped;

	public event Action PageBookGenerated;

	private void Awake()
	{
		UpdateHighlight();
		itemSaveData = GetComponent<ItemSaveData>();
		itemSaveData.ItemSaveDataRequested += OnItemSaveDataRequested;
		itemSaveData.ItemSaveDataLoaded += OnItemSaveDataLoaded;
	}

	private void UpdateHighlight()
	{
		if (highlight == null)
		{
			highlight = GameObject.CreatePrimitive(PrimitiveType.Cube);
			UnityEngine.Object.Destroy(highlight.GetComponent<BoxCollider>());
			highlight.transform.SetParent(base.transform, worldPositionStays: false);
			highlight.name = "[highlight model]";
			MeshRenderer component = highlight.GetComponent<MeshRenderer>();
			component.enabled = false;
			base.gameObject.AddComponent<HighlightTag>().renderers.Add(component);
		}
		highlight.transform.localPosition = new Vector3(0f, -1f * pageSeparation * ((float)PageNum * 0.5f - 0.5f), 0f);
		float y = Mathf.Max(pageSeparation * (float)PageNum, pageSeparation);
		Transform transform = base.transform.Find("paper");
		Vector3 localScale = ((!(transform != null)) ? new Vector3(0.2f, y, 0.284f) : new Vector3(PAPER_SIZE.x * transform.localScale.x, y, PAPER_SIZE.y * transform.localScale.z));
		highlight.transform.localScale = localScale;
	}

	public void ForceStart()
	{
		Start();
	}

	private void Start()
	{
		if (!started)
		{
			started = true;
			item = GetComponent<ItemBase>();
			if (generateOnStart)
			{
				Generate();
			}
			if (VRManager.IsVREnabled())
			{
				scrolling = base.gameObject.AddComponent<ItemScrollingVR>();
			}
			else
			{
				scrolling = base.gameObject.AddComponent<ItemScrollingNonVR>();
			}
			SetupListeners(on: true);
		}
	}

	private void OnDisable()
	{
		if (UnloadWatcher.isUnloading || !PagesGenerated)
		{
			return;
		}
		if (initialPageCoro != null)
		{
			SingletonBehaviour<CoroutineManager>.Instance.Stop(initialPageCoro);
		}
		if (pivotCoro != null)
		{
			SingletonBehaviour<CoroutineManager>.Instance.Stop(pivotCoro);
		}
		initialPageCoro = null;
		pivotCoro = null;
		float y = pageSeparation * (float)currentPage;
		motionPivot.localPosition = new Vector3(0f, y, 0f);
		bookVolumeModel?.SetActive(value: true);
		foreach (Page page in pages)
		{
			page.ForceEndAnimation();
		}
	}

	private void OnDestroy()
	{
		if ((bool)bookVolumeModel)
		{
			UnityEngine.Object.Destroy(bookVolumeModel.GetComponent<MeshRenderer>().material);
		}
		for (int i = 0; i < pages.Count; i++)
		{
			UnityEngine.Object.Destroy(pages[i].renderer.material);
			if (i != 0 || !coverMaterial)
			{
				UnityEngine.Object.Destroy(pages[i].pageMaterial);
			}
		}
	}

	private void SetupListeners(bool on)
	{
		if (on)
		{
			item.Grabbed += OnGrabbed;
			return;
		}
		item.Grabbed -= OnGrabbed;
		item.Ungrabbed -= OnUngrabbed;
		scrolling.Scrolled -= OnScrolled;
	}

	private void OnGrabbed(ControlImplBase _)
	{
		item.Ungrabbed += OnUngrabbed;
		scrolling.Scrolled += OnScrolled;
	}

	private void OnUngrabbed(ControlImplBase _)
	{
		item.Ungrabbed -= OnUngrabbed;
		scrolling.Scrolled -= OnScrolled;
	}

	public void Generate()
	{
		if (!started)
		{
			Start();
		}
		if (!pageTemplate)
		{
			Debug.LogError("Page template not assigned");
			return;
		}
		GameObject gameObject = new GameObject("Pivot");
		motionPivot = gameObject.transform;
		motionPivot.parent = base.transform;
		motionPivot.localPosition = Vector3.zero;
		motionPivot.localEulerAngles = Vector3.zero;
		float pageThickness = (float)PageNum * pageSeparation;
		for (int i = 0; i < PageNum; i++)
		{
			InstantiatePage(i, pageThickness);
		}
		if (destroyTemplate)
		{
			UnityEngine.Object.Destroy(pageTemplate.gameObject);
			pageTemplate = null;
		}
		if (autoColliderThickness && (bool)GetComponent<BoxCollider>())
		{
			BoxCollider component = GetComponent<BoxCollider>();
			Vector3 size = component.size;
			Vector3 center = component.center;
			Vector3 size2 = size;
			size2.y = Mathf.Max(pageSeparation * (float)(PageNum - 3), 0.005f);
			component.size = size2;
			if (PageNum > 1)
			{
				Vector3 center2 = component.center;
				center2.y = (0f - size2.y) * 0.5f;
				if (PageNum > 3)
				{
					center2.y -= pageSeparation;
				}
				component.center = center2;
				Vector3 up = base.transform.up;
				if (Vector3.Dot(up, Vector3.up) > 0f && !item.IsGrabbed())
				{
					float num = center.y - center2.y;
					float num2 = (size.y - size2.y) * 0.5f;
					Vector3 vector = up * (num - num2);
					base.transform.position += vector;
				}
				GameObject gameObject2 = ((PageFlippingHelperOverridePrefab != null) ? PageFlippingHelperOverridePrefab : Resources.Load<GameObject>("PageFlippingHelper"));
				if (gameObject2 != null)
				{
					UnityEngine.Object.Instantiate(gameObject2, base.transform, worldPositionStays: false);
				}
				else
				{
					Debug.LogError("Page flipping helper prefab not found: PageFlippingHelper");
				}
			}
		}
		if (PageNum > 10)
		{
			bookVolumeModel = GameObject.CreatePrimitive(PrimitiveType.Cube);
			bookVolumeModel.transform.SetParent(base.transform, worldPositionStays: false);
			bookVolumeModel.name = "BookVolumeModel";
			bookVolumeModel.transform.localPosition = new Vector3(0f, -1f * pageSeparation * ((float)PageNum * 0.5f - 0.5f), 0f);
			UnityEngine.Object.Destroy(bookVolumeModel.GetComponent<BoxCollider>());
			bookVolumeModel.transform.localScale = new Vector3(0.2f, pageSeparation * (float)(PageNum - 3), 0.284f);
			bookVolumeModel.GetComponent<MeshRenderer>().material = innerPagesMaterial;
		}
		item.ReCacheRenderers();
		UpdateHighlight();
		PagesGenerated = true;
		this.PageBookGenerated?.Invoke();
	}

	private bool AnyPageIsFlipping()
	{
		foreach (Page page in pages)
		{
			if (page.IsFlipping())
			{
				return true;
			}
		}
		return false;
	}

	private IEnumerator UpdatePivotPosition()
	{
		if (bookVolumeModel != null)
		{
			bookVolumeModel.SetActive(value: false);
		}
		while (AnyPageIsFlipping())
		{
			yield return null;
			float target = pageSeparation * (float)currentPage;
			if (Time.deltaTime > 0f)
			{
				pivotOffset = Mathf.SmoothDamp(pivotOffset, target, ref pivotSmoothVelo, 0.1f);
			}
			motionPivot.localPosition = new Vector3(0f, pivotOffset, 0f);
		}
		pivotOffset = pageSeparation * (float)currentPage;
		motionPivot.localPosition = new Vector3(0f, pivotOffset, 0f);
		if (bookVolumeModel != null)
		{
			bookVolumeModel.SetActive(value: true);
		}
		pivotCoro = null;
	}

	public void FlipBy(int numOfPages)
	{
		if (PagesGenerated)
		{
			FlipTo(currentPage + numOfPages);
		}
	}

	public void FlipTo(int targetPage)
	{
		if (!PagesGenerated)
		{
			return;
		}
		targetPage = Mathf.Clamp(targetPage, 0, PageNum - 1);
		if (targetPage != currentPage)
		{
			int num = targetPage - currentPage;
			int num2 = Mathf.Abs(num);
			for (int i = 0; i < num2; i++)
			{
				float value = 1f - (float)i * 0.1f;
				value = Mathf.Clamp(value, 0.5f, float.PositiveInfinity);
				float speedMultiplier = (float)Mathf.Clamp(num, -1, 1) * value;
				FlipPage((num > 0) ? pages[currentPage + i] : pages[currentPage - i - 1], speedMultiplier);
			}
			flipAudio.clips.Play(base.transform.position, 1f, 1f, 0f, 1f, 500f, default(AudioSourceCurves), null, base.transform);
			currentPage = targetPage;
			this.PageFlipped?.Invoke(currentPage);
		}
	}

	public void ForceCurrentPage(int targetPage)
	{
		if (!PagesGenerated)
		{
			return;
		}
		targetPage = Mathf.Clamp(targetPage, 0, PageNum - 1);
		if (targetPage != currentPage)
		{
			int num = targetPage - currentPage;
			int num2 = Mathf.Abs(num);
			for (int i = 0; i < num2; i++)
			{
				float speedMultiplier = (float)Mathf.Clamp(num, -1, 1) * 100f;
				FlipPage((num > 0) ? pages[currentPage + i] : pages[currentPage - i - 1], speedMultiplier);
			}
			currentPage = targetPage;
			this.PageFlipped?.Invoke(currentPage);
		}
	}

	private void FlipPage(Page page, float speedMultiplier)
	{
		page.Flip(speedMultiplier);
		if (pivotCoro != null)
		{
			SingletonBehaviour<CoroutineManager>.Instance.Stop(pivotCoro);
		}
		pivotCoro = SingletonBehaviour<CoroutineManager>.Instance.Run(UpdatePivotPosition());
	}

	private void InstantiatePage(int pageNum, float pageThickness)
	{
		GameObject obj = UnityEngine.Object.Instantiate(pageTemplate.gameObject, base.transform.position, base.transform.rotation);
		obj.name = obj.name + " " + pageNum;
		obj.transform.parent = motionPivot;
		Page component = obj.GetComponent<Page>();
		component.animator.enabled = false;
		pages.Add(component);
		float y = (component.startOffset = (0f - pageSeparation) * (float)pageNum);
		component.transform.localPosition = new Vector3(0f, y, 0f);
		component.pageMaterial = ((pageNum == 0 && coverMaterial != null) ? coverMaterial : component.renderer.material);
		component.renderer.material.mainTexture = pageTextures[pageNum];
		component.endOffset = 0f - pageThickness - (float)pageNum * pageSeparation;
	}

	public JObject OnItemSaveDataRequested(JObject data)
	{
		if (currentPage == 0)
		{
			data.Remove("BookletPageNumber");
		}
		else
		{
			data.SetInt("BookletPageNumber", currentPage);
		}
		return data;
	}

	public void OnItemSaveDataLoaded(JObject data)
	{
		if (data == null)
		{
			Debug.LogError("OnItemSaveDataLoaded got null data");
			return;
		}
		int? num = data.GetInt("BookletPageNumber");
		if (num.HasValue)
		{
			if (initialPageCoro != null)
			{
				SingletonBehaviour<CoroutineManager>.Instance.Stop(initialPageCoro);
			}
			initialPageCoro = SingletonBehaviour<CoroutineManager>.Instance.Run(ForceCurrentPageOnInitialization(num.Value));
		}
	}

	private IEnumerator ForceCurrentPageOnInitialization(int desiredPage)
	{
		while (!PagesGenerated)
		{
			yield return null;
		}
		ForceCurrentPage(desiredPage);
		initialPageCoro = null;
	}

	private void OnScrolled(ScrollAction direction)
	{
		Scroll(direction);
	}

	public void Scroll(ScrollAction action, ScrollSource source = ScrollSource.Mouse)
	{
		if (action != ScrollAction.Release)
		{
			if (!positiveScrollDirection.IsSameAxis(action))
			{
				action = action.SwitchAxis();
			}
			bool flag = positiveScrollDirection == action;
			if (GamePreferences.Get<bool>(Preferences.InvertPageFlipping))
			{
				flag = !flag;
			}
			FlipBy(flag.ToDir());
		}
	}

	public bool IsAtEnd(ScrollAction action)
	{
		if (!positiveScrollDirection.IsSameAxis(action))
		{
			action = action.SwitchAxis();
		}
		return currentPage == ((positiveScrollDirection == action) ? (pages.Count - 1) : 0);
	}
}
