using System;
using UnityEngine;

public class PhaserGameObject : GameMonoBehaviour, ArcadeColliderType
{
	public BaseBody body;

	private PhaserScene _scene;

	private bool _visible;

	private bool _ignoreDestroy;

	[NonSerialized]
	public PhaserContainer _parentContainer;

	public virtual bool isParent => false;

	public virtual bool isTilemap => false;

	BaseBody ArcadeColliderType.body => null;

	public virtual Rect? frame => null;

	public bool active
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	GameObject ArcadeColliderType.gameObject => null;

	public virtual SpriteRenderer GetAttachedRenderer()
	{
		return null;
	}

	protected override void OnDestroy()
	{
	}
}
