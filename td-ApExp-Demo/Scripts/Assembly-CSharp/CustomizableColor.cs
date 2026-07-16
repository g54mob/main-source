using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class CustomizableColor : MonoBehaviour
{
	[SerializeField]
	private TrainCustomization.ColorCategory category;

	private SpriteRenderer sr;

	private void Awake()
	{
		sr = GetComponent<SpriteRenderer>();
	}

	private void Start()
	{
		RegisterSprite();
	}

	private void RegisterSprite()
	{
		if ((bool)sr)
		{
			Train.Instance.Customization.RegisterSRByCategory(sr, category);
		}
	}

	private void OnDestroy()
	{
		Train.Instance.Customization.UnregisterSR(sr);
	}
}
