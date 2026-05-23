using MPUIKIT;
using UnityEngine;

public class Healthbar : MonoBehaviour
{
	[SerializeField]
	protected GameObject canvasParent;

	[SerializeField]
	protected MPImageBasic fill;

	[SerializeField]
	protected MPImageBasic delayedFill;

	[SerializeField]
	protected Hp target;

	[SerializeField]
	protected Color deathFillColor;

	[SerializeField]
	private bool flashWhenBelowThreshold;

	[SerializeField]
	[Range(0f, 1f)]
	private float flashThreshhold;

	[SerializeField]
	private float flashInterval = 0.25f;

	[SerializeField]
	private Color flashColor;

	[SerializeField]
	private MPImageBasic flashTarget;

	[SerializeField]
	private float damageFlashSize = 1.2f;

	public bool isenemy;

	protected Color defaultDelayedFillColor;

	protected float hpLast;

	private float hpNow;

	private float damageFlash;

	private bool shouldUnparentAndDestroyOnDeath;

	private Color flashDefaultColor;

	private float flashClock;

	private readonly float finalDrainSpeed = 0.5f;

	private readonly float maxDrainSpeed = 1f;

	private readonly float minDrainSpeed = 0.1f;

	public Hp Target => target;

	private void Start()
	{
		target.OnHpChange.AddListener(UpdateDisplay);
		defaultDelayedFillColor = delayedFill.color;
		UpdateDisplay();
		delayedFill.fillAmount = fill.fillAmount;
		hpLast = 1f;
		shouldUnparentAndDestroyOnDeath = !target.getsKnockedOutInsteadOfDying;
		if (shouldUnparentAndDestroyOnDeath)
		{
			target.OnKillOrKnockout.AddListener(UnparentItself);
		}
		if (flashWhenBelowThreshold)
		{
			flashDefaultColor = flashTarget.color;
		}
		UpdateColor();
	}

	public void UpdateColor()
	{
		if (isenemy)
		{
			fill.color = ColorAndLightManager.Instance.enemyHealthBarColor;
		}
	}

	private void Update()
	{
		hpNow = fill.fillAmount;
		bool flag = Mathf.Approximately(hpNow, 0f);
		if (!Mathf.Approximately(hpNow, delayedFill.fillAmount))
		{
			if (!flag)
			{
				delayedFill.fillAmount = Mathf.MoveTowards(delayedFill.fillAmount, fill.fillAmount, Mathf.Lerp(minDrainSpeed, maxDrainSpeed, delayedFill.fillAmount - fill.fillAmount) * Time.deltaTime);
			}
			else
			{
				delayedFill.fillAmount = Mathf.MoveTowards(delayedFill.fillAmount, fill.fillAmount, Mathf.Lerp(finalDrainSpeed, maxDrainSpeed, delayedFill.fillAmount - fill.fillAmount) * Time.deltaTime);
			}
		}
		if (hpNow < hpLast)
		{
			damageFlash = 2f;
		}
		if (flag && delayedFill.fillAmount < 0.01f)
		{
			if (shouldUnparentAndDestroyOnDeath)
			{
				Object.Destroy(base.gameObject);
			}
			else
			{
				canvasParent.SetActive(value: false);
				base.enabled = false;
			}
		}
		if (flashWhenBelowThreshold)
		{
			if (hpNow <= flashThreshhold && hpNow > 0f)
			{
				flashClock -= Time.deltaTime;
				if (flashClock <= 0f)
				{
					flashClock = flashInterval;
					if (flashTarget.color == flashColor)
					{
						flashTarget.color = flashDefaultColor;
					}
					else
					{
						flashTarget.color = flashColor;
					}
				}
			}
			else if (flashTarget.color != flashDefaultColor)
			{
				flashTarget.color = flashDefaultColor;
				flashClock = 0f;
			}
			else
			{
				flashClock = 0f;
			}
		}
		float num = Mathf.Lerp(1f, damageFlashSize, damageFlash);
		base.transform.localScale = new Vector3(num, num, num);
		damageFlash *= Mathf.Pow(0.1f, Time.deltaTime * 3f);
		hpLast = hpNow;
	}

	public virtual void UpdateDisplay()
	{
		if (target.HpPercentage == 1f)
		{
			canvasParent.SetActive(value: false);
			base.enabled = false;
			hpLast = 1f;
			delayedFill.fillAmount = hpLast;
		}
		else
		{
			canvasParent.SetActive(value: true);
			base.enabled = true;
		}
		fill.fillAmount = target.HpPercentage;
		if (Mathf.Approximately(fill.fillAmount, 0f))
		{
			delayedFill.color = deathFillColor;
		}
		else
		{
			delayedFill.color = defaultDelayedFillColor;
		}
	}

	private void UnparentItself()
	{
		base.transform.SetParent(null);
	}
}
