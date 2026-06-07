using UnityEngine;

public class RoomSegmentTagger : MonoBehaviour
{
	public static RoomSegmentTagger Instance;

	public float MaxTextWidth = 100f;

	public float MaxRenderHeight = 50f;

	public TextMesh TagPrefab;

	private ObjectPool<TextMesh> _tagPool;

	public static TextMesh Get()
	{
		if (Instance != null)
		{
			return Instance._tagPool.Get();
		}
		Debug.LogError("Tried to get room segment tag when tagger was null");
		return null;
	}

	public static void Release(TextMesh m)
	{
		if (Instance != null)
		{
			Instance._tagPool.Release(m);
		}
	}

	private void Awake()
	{
		Instance = this;
		_tagPool = new ObjectPool<TextMesh>(() => Object.Instantiate(TagPrefab), delegate(TextMesh x)
		{
			x.gameObject.SetActive(true);
		}, delegate(TextMesh x)
		{
			x.gameObject.SetActive(false);
			x.transform.SetParent(base.transform);
		});
	}

	private void OnDestroy()
	{
		if (Instance == this)
		{
			Instance = null;
		}
	}
}
