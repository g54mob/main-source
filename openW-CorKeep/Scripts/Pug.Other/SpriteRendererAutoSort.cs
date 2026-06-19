using System;
using System.Collections.Generic;
using Pug.UnityExtensions;
using UnityEngine;
using UnityEngine.Serialization;

public class SpriteRendererAutoSort : MonoBehaviour
{
	[Serializable]
	public class AutoSortChild
	{
		[Tooltip("Apply fixed offset to the child, relative to the autosorter component's sorting order. Positive order offsets will cause the child renderer to appear IN FRONT OF the main renderer.")]
		public int orderOffset;

		public Renderer renderer;

		public AutoSortChild(Renderer _renderer, int _orderOffset)
		{
			orderOffset = _orderOffset;
			renderer = _renderer;
		}
	}

	public enum AutoAddFollowers
	{
		RendererInThisGameObject = 0,
		DontAddFollowersAutomatically = 1,
		ChildrenSpriteRenderers = 2
	}

	private const int MIN_ORDER = -32000;

	private const int MAX_ORDER = 32000;

	private const float ORDER_SCALE = -100f;

	[Header("Auto-add follower renderers in awake:")]
	public AutoAddFollowers autoAddFollowers;

	[Header("Followed transform options:")]
	[Tooltip("Apply vertical offset to the followed transform's Y before computing the sorting order. Positive Y offsets will cause the renderer will appear BEHIND the followed transform.")]
	public float yOffset;

	[Tooltip("Compute sorting orders based on the given transform's Y position. If not set, the current gameobject's transform is used.")]
	public Transform followTransformY;

	[Header("Add extra followers here (optional):")]
	[SerializeField]
	[FormerlySerializedAs("optionalFollowers")]
	private List<AutoSortChild> followers = new List<AutoSortChild>();

	public void AddFollower(Renderer renderer, int orderOffset = 0)
	{
		followers.Add(new AutoSortChild(renderer, orderOffset));
	}

	public void RemoveFollower(Renderer renderer)
	{
		for (int i = 0; i < followers.Count; i++)
		{
			if (followers[i].renderer == renderer)
			{
				followers.RemoveAt(i);
				break;
			}
		}
	}

	private void Awake()
	{
		if (followTransformY == null)
		{
			followTransformY = base.transform;
		}
		switch (autoAddFollowers)
		{
		case AutoAddFollowers.RendererInThisGameObject:
			AddFollower(GetComponent<Renderer>());
			break;
		case AutoAddFollowers.ChildrenSpriteRenderers:
		{
			SpriteRenderer[] componentsInChildren = GetComponentsInChildren<SpriteRenderer>(includeInactive: true);
			followers.EnsureCapacity(componentsInChildren.Length);
			SpriteRenderer[] array = componentsInChildren;
			foreach (SpriteRenderer spriteRenderer in array)
			{
				if (!spriteRenderer.CompareTag("ExcludeFromSpriteAutoSort"))
				{
					int sortingOrder = spriteRenderer.sortingOrder;
					AddFollower(spriteRenderer, sortingOrder);
				}
			}
			break;
		}
		case AutoAddFollowers.DontAddFollowersAutomatically:
			break;
		}
	}

	public static int ComputeOrderForY(float y)
	{
		return Mathf.Clamp((int)(-100f * y), -32000, 32000);
	}

	private void Update()
	{
		int num = ComputeOrderForY(followTransformY.position.y + yOffset);
		foreach (AutoSortChild follower in followers)
		{
			if (!(follower.renderer == null))
			{
				int value = num + follower.orderOffset;
				value = Mathf.Clamp(value, -32000, 32000);
				follower.renderer.sortingOrder = value;
			}
		}
		if (base.gameObject.isStatic)
		{
			base.enabled = false;
		}
	}
}
