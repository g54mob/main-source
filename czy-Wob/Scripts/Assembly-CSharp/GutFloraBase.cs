using System.Collections.Generic;
using UnityEngine;

public class GutFloraBase : MonoBehaviour
{
	public Rigidbody2D rigidbodyRef;

	public SpriteRenderer floraGraphicRef;

	public Color boostedColor;

	private float destructionTimer = 1f;

	private bool isBeingDestroyed;

	public InchwormBounce destructionBounceRef;

	public GutFloraCollisionReporter collisionRef;

	public List<GutFloraMutationEffectInfo> mutationEffects = new List<GutFloraMutationEffectInfo>();

	public FloraInteractionType floraInteractionType;

	public List<CollisionEffect> collisionEffects = new List<CollisionEffect>();

	public bool mitosis;

	public float mitosisTimerLow = 10f;

	public float mitosisTimerHigh = 30f;

	private float mitosisTimerCurrent;

	private string floraPath;

	private GutFloraResource floraType;

	private float power = 0.5f;

	private float collisionTimer;

	private float minTimeBetweenCollisions = 0.5f;

	private bool boosted;

	private DogGut owningGutRef;

	private void Awake()
	{
		if (mitosis)
		{
			mitosisTimerCurrent = Random.Range(mitosisTimerLow, mitosisTimerHigh);
		}
	}

	public void SetOwningGut(DogGut gutRef)
	{
		owningGutRef = gutRef;
	}

	public string GetFloraPath()
	{
		return floraPath;
	}

	public GutFloraResource GetFloraType()
	{
		return floraType;
	}

	public void Boost()
	{
		boosted = true;
		floraGraphicRef.color = boostedColor;
	}

	public bool IsBoosted()
	{
		return boosted;
	}

	public void SetFloraInfo(GutFloraResource newType)
	{
		floraType = newType;
		floraPath = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<DogGutsManager>(GlobalObject.DOG_GUT_MANAGER).GetPathForFlora(newType);
	}

	public void ManualDestroy()
	{
		Object.Destroy(collisionRef);
		isBeingDestroyed = true;
		if (destructionBounceRef != null)
		{
			destructionBounceRef.RequestBounce();
		}
		else
		{
			MonoBehaviour.print("No destructionBounceRef assigned.");
		}
	}

	private void Update()
	{
		if (owningGutRef == null || owningGutRef.GetGutsManager() == null || owningGutRef.GetGutsManager().AreGutsPaused())
		{
			return;
		}
		if (collisionTimer > 0f)
		{
			collisionTimer -= Time.unscaledDeltaTime;
		}
		if (isBeingDestroyed)
		{
			destructionTimer -= Time.unscaledDeltaTime;
			if (destructionTimer <= 0f)
			{
				Object.Destroy(base.gameObject);
			}
		}
		else if (mitosis)
		{
			CheckMitosis();
		}
	}

	public virtual void ManualFixedUpdateMove()
	{
		rigidbodyRef.AddForce(MathUtil.GetRandomVector2InRange(0f - power, power), ForceMode2D.Impulse);
	}

	public void OnCollision(Collision2D collision)
	{
		if (collisionTimer > 0f || collision.transform == null)
		{
			return;
		}
		GutFloraBase component = collision.transform.parent.GetComponent<GutFloraBase>();
		if (component == null || component.isBeingDestroyed || isBeingDestroyed)
		{
			return;
		}
		collisionTimer = minTimeBetweenCollisions;
		for (int i = 0; i < collisionEffects.Count; i++)
		{
			if (collisionEffects[i].CheckCollision(component.floraInteractionType))
			{
				for (int j = 0; j < collisionEffects[i].effects.Count; j++)
				{
					ProcessCollisionEffect(this, component, collisionEffects[i].effects[j]);
				}
			}
		}
	}

	private void CheckMitosis()
	{
		mitosisTimerCurrent -= Time.unscaledDeltaTime;
		if (mitosisTimerCurrent <= 0f)
		{
			mitosisTimerCurrent = Random.Range(mitosisTimerLow, mitosisTimerHigh);
			owningGutRef.SpawnNewGutFlora(GetFloraType(), null, rigidbodyRef.transform.position, base.transform.localScale);
		}
	}

	private void ProcessCollisionEffect(GutFloraBase effectOwner, GutFloraBase effectTarget, GutFloraEffect effect)
	{
		switch (effect)
		{
		case GutFloraEffect.NOTHING:
			break;
		case GutFloraEffect.DUPLICATE_SELF:
			owningGutRef.SpawnNewGutFlora(effectOwner.GetFloraType(), null, effectOwner.rigidbodyRef.transform.position, effectOwner.transform.localScale);
			break;
		case GutFloraEffect.TURN_INTO_TARGET:
			owningGutRef.SpawnNewGutFlora(effectOwner.GetFloraType(), null, effectOwner.rigidbodyRef.transform.position, effectOwner.transform.localScale);
			owningGutRef.DestroyExistingGutFlora(effectOwner);
			break;
		case GutFloraEffect.BOOST_TARGET:
			effectTarget.Boost();
			break;
		case GutFloraEffect.KILL_TARGET:
			owningGutRef.DestroyExistingGutFlora(effectTarget);
			break;
		case GutFloraEffect.KILL_SELF:
			owningGutRef.DestroyExistingGutFlora(effectOwner);
			break;
		}
	}
}
