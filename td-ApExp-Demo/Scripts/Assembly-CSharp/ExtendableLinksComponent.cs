using System;
using System.Linq;
using UnityEngine;

public class ExtendableLinksComponent : MonoBehaviour
{
	[Header("Health")]
	[SerializeField]
	protected bool individualLinkHealth;

	[SerializeField]
	protected float health = 1f;

	[SerializeField]
	protected float linkHealth = 1f;

	[SerializeField]
	protected bool isImune;

	[NonSerialized]
	[Header("Chain")]
	public ExtensionState ExtensionState;

	[NonSerialized]
	public EnemyBase owner;

	[SerializeField]
	public float expansionSpeed = 1f;

	[SerializeField]
	public float retractionSpeed = 3f;

	[SerializeField]
	public bool IsLocked;

	[SerializeField]
	public bool KeepAtached = true;

	[SerializeField]
	public float MaxLength = 1f;

	[SerializeField]
	protected int fixedNumberOfLinks;

	[SerializeField]
	protected bool autoUpdateLinks = true;

	[Header("Links")]
	[SerializeField]
	protected GameObject firstLinkGO;

	[SerializeField]
	protected GameObject[] linksGO;

	[SerializeField]
	protected GameObject lastLinkGO;

	[Tooltip("If specified the chain will always have this number of links. If 0, the chain will automatically generate the links based on the distance to target")]
	[SerializeField]
	protected Sprite[] linkSprites;

	[SerializeField]
	protected Sprite firstLinkSprite;

	[SerializeField]
	protected Sprite lastLinkSprite;

	[Header("Effects")]
	[SerializeField]
	protected UnitAudioController audioSource;

	[SerializeField]
	protected GameObject explosionPrefab;

	[SerializeField]
	protected bool instantDestroy = true;

	[SerializeField]
	protected bool noExplosions;

	[SerializeField]
	protected bool playOnly1ExplosionSound;

	[SerializeField]
	protected float explosionScale = 0.1f;

	[SerializeField]
	protected float explosionSizeVariation = 0.05f;

	[SerializeField]
	protected float explosionPositionVariation = 0.1f;

	[SerializeField]
	protected float explosionChancePerLink = 80f;

	[SerializeField]
	protected float minTimeBetweenExplosions = 0.01f;

	[SerializeField]
	protected float maxTimeBetweenExplosions = 0.2f;

	protected Transform target;

	protected LinkComponent firstLinkLC;

	protected LinkComponent[] linksLC;

	protected LinkComponent lastLinkLC;

	protected float expansion01;

	protected int linkSpriteCount;

	protected float linkLength;

	protected bool isAttached;

	private bool onAttachedInvoked;

	private bool onDetachedInvoked;

	[NonSerialized]
	public bool Retracted = true;

	[NonSerialized]
	public bool Expanded = true;

	private bool breakingStarted;

	private Vector3 upVector = new Vector3(0f, 0f, 1f);

	public bool IsAttached => isAttached;

	public Transform FirstLink
	{
		get
		{
			if (!firstLinkGO)
			{
				return linksGO[0].transform;
			}
			return firstLinkGO.transform;
		}
	}

	public Transform LastLink
	{
		get
		{
			if (!lastLinkGO)
			{
				return linksGO[^1].transform;
			}
			return lastLinkGO.transform;
		}
	}

	public float Expansion01 => expansion01;

	public virtual event Action<ExtendableLinksComponent> OnDestroyed;

	public virtual event Action<ExtendableLinksComponent> OnAttached;

	public virtual event Action<ExtendableLinksComponent> OnDetached;

	public virtual void Start()
	{
		Initialize();
	}

	public virtual void Update()
	{
		if ((bool)target && !IsLocked)
		{
			switch (ExtensionState)
			{
			case ExtensionState.Expanding:
				if (expansion01 < 1f)
				{
					expansion01 += Time.deltaTime * expansionSpeed;
				}
				break;
			case ExtensionState.Retracting:
				if (expansion01 > 0f)
				{
					expansion01 -= Time.deltaTime * retractionSpeed;
				}
				break;
			}
			SetExpansion(expansion01);
			Aim();
		}
		else
		{
			if (expansion01 > 0f)
			{
				expansion01 -= Time.deltaTime * retractionSpeed;
			}
			SetExpansion(expansion01);
		}
		Retracted = expansion01 <= 0.05f;
		Expanded = expansion01 >= 0.95f;
	}

	public virtual void Initialize()
	{
		Transform[] array = base.transform.GetComponentsInChildren<Transform>().Where(delegate(Transform t)
		{
			LinkComponent component = t.GetComponent<LinkComponent>();
			return (object)component != null && component.linkPosition == LinkPosition.Middle;
		}).ToArray();
		int num = array.Length + (firstLinkGO ? 1 : 0) + (lastLinkGO ? 1 : 0);
		linksGO = new GameObject[array.Length];
		linksLC = new LinkComponent[num];
		linkSpriteCount = linkSprites.Length;
		linkLength = linkSprites[0].bounds.size.y;
		int num2 = 0;
		if ((bool)firstLinkGO)
		{
			firstLinkLC = firstLinkGO.GetComponent<LinkComponent>();
			firstLinkLC.SetChainController(this);
			firstLinkLC.HealthComponent.IsImmune = isImune;
			linksLC[num2] = firstLinkLC;
			num2++;
		}
		int num3 = 0;
		while (num3 < array.Length)
		{
			linksGO[num3] = array[num3].gameObject;
			linksLC[num2] = linksGO[num3].GetComponent<LinkComponent>();
			linksLC[num2].HealthComponent.IsImmune = isImune;
			linksLC[num2].SetChainController(this);
			num3++;
			num2++;
		}
		if ((bool)lastLinkGO)
		{
			lastLinkLC = lastLinkGO.GetComponent<LinkComponent>();
			lastLinkLC.SetChainController(this);
			lastLinkLC.HealthComponent.IsImmune = isImune;
			linksLC[num2] = lastLinkLC;
		}
	}

	protected virtual void Aim()
	{
		Vector3 upwards = target.position - base.transform.position;
		Quaternion to = Quaternion.LookRotation(Vector3.forward, upwards);
		base.transform.rotation = Quaternion.RotateTowards(base.transform.rotation, to, Time.deltaTime * 60f);
	}

	public void Release()
	{
		if ((bool)lastLinkGO)
		{
			lastLinkGO.transform.SetParent(base.transform);
		}
	}

	public virtual void SetTarget(Transform t)
	{
		target = t;
		_ = base.transform.position.y;
		_ = 0f;
	}

	public virtual void SetHealth(float amount)
	{
		health = amount;
	}

	public virtual void SetLinkHealth(float amount)
	{
		linkHealth = amount;
	}

	public virtual void UpdateDynamicLinksLength()
	{
		if ((bool)target)
		{
			int num = (int)MathF.Ceiling((base.transform.position - target.position).magnitude / linkLength);
			if ((bool)firstLinkGO)
			{
				num--;
			}
			if ((bool)lastLinkGO)
			{
				num--;
			}
			num = Mathf.Min(num, linksGO.Length);
			for (int i = 0; i < num; i++)
			{
				linksGO[i].SetActive(value: true);
			}
			for (int j = num; j < linksGO.Length; j++)
			{
				linksGO[j].SetActive(value: false);
			}
		}
	}

	public void SetExpansion(float extent01)
	{
		if (target == null)
		{
			return;
		}
		Vector3 upwards = target.position - base.transform.position;
		base.transform.rotation = Quaternion.LookRotation(upVector, upwards);
		float num = Mathf.Min(upwards.magnitude * extent01, MaxLength) / (float)(linksGO.Length + 1);
		if ((bool)firstLinkGO)
		{
			firstLinkGO.transform.localPosition = Vector3.zero;
		}
		int num2 = (lastLinkGO ? 1 : 0);
		for (int i = 0; i < linksGO.Length; i++)
		{
			linksGO[i].transform.localPosition = new Vector3(0f, num * (float)(i + num2), 0f);
		}
		if ((bool)lastLinkGO)
		{
			lastLinkGO.transform.localPosition = new Vector3(0f, num * (float)(linksGO.Length - 1 + num2), 0f);
		}
		isAttached = extent01 >= 0.99f && upwards.magnitude <= MaxLength;
		if (isAttached)
		{
			if (!onAttachedInvoked)
			{
				this.OnAttached?.Invoke(this);
				onAttachedInvoked = true;
				onDetachedInvoked = false;
			}
		}
		else if (!KeepAtached && !onDetachedInvoked)
		{
			this.OnDetached?.Invoke(this);
			onDetachedInvoked = true;
			onAttachedInvoked = false;
		}
	}

	public virtual void OnLinkDamaged(HealthChangeInfo info)
	{
	}

	public virtual void OnLinkDestroyed()
	{
		DestroyChainCoroutine();
	}

	public void DestroyChain()
	{
		DestroyChainCoroutine();
	}

	protected virtual void DestroyChainCoroutine()
	{
		if (!breakingStarted)
		{
			breakingStarted = true;
			this.OnDestroyed?.Invoke(this);
			int num = linksGO.Length;
			Vector3 position = linksGO[num / 2].transform.position + new Vector3(UnityEngine.Random.Range(0f - explosionPositionVariation, explosionPositionVariation), UnityEngine.Random.Range(0f - explosionPositionVariation, explosionPositionVariation));
			float radius = explosionScale * 2f;
			UnityEngine.Object.Instantiate(explosionPrefab, position, Quaternion.identity).GetComponent<Explosion>().Initialize(linksLC[num / 2], radius, 0f);
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}
}
