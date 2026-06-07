using UnityEngine;

public class KeyCrate : DynamicObjectBase
{
	[SerializeField]
	private string keyId = "";

	private Material material;

	public string KeyId => keyId;

	public bool IsOn { get; private set; }

	protected override void Awake()
	{
		base.Awake();
		material = GetComponent<Renderer>().material;
		SetHighlightVisibility(isVisible: false);
	}

	protected override void AddReplayComponents()
	{
		base.AddReplayComponents();
		base.gameObject.AddComponent<KeyCrateReplay>();
	}

	public override void Recycle()
	{
		base.Recycle();
		SetHighlightVisibility(isVisible: false);
	}

	public void SetHighlightVisibility(bool isVisible)
	{
		int num = (isVisible ? 5 : 0);
		material.SetColor("_EmissionColor", Color.HSVToRGB(0f, 0f, num));
		IsOn = isVisible;
	}
}
