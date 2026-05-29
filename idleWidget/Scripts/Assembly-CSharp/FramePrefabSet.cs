using Assets.Source.World;
using UnityEngine;

public class FramePrefabSet : MonoBehaviour
{
	[field: SerializeField]
	public ActiveWorldFrame Frame { get; private set; }

	[field: SerializeField]
	public Sprite OverviewSprite { get; private set; }

	private void Awake()
	{
		GetComponentInParent<WorldManager>().AddFramePrefabSet(this);
	}

	public WorldFrame GetPreview()
	{
		return WorldFrame.GetPreview(base.gameObject.name);
	}
}
