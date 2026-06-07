using ThreeEyedGames;
using UnityEngine;

[RequireComponent(typeof(Decal))]
public class DecalLifeControl : MonoBehaviour
{
	[SerializeField]
	private float lifeTime = 10f;

	[SerializeField]
	private float fadeTime = 3f;

	private Transform otherTransform;

	private Vector3 offsetPos;

	private Vector3 offsetUpDir;

	private Vector3 offsetFwDir;

	private Decal decal;

	private float originalFadeValue;

	private float timeCounter;

	private MeshRenderer thisMeshRenderer;

	public bool IsExisting { get; private set; }

	public bool ShouldDestroy { get; set; }

	public bool ShouldStopControl { get; set; }

	public bool IsStickToOtherObject => otherTransform != null;

	private void Awake()
	{
		timeCounter = 0f;
		decal = GetComponent<Decal>();
		thisMeshRenderer = GetComponent<MeshRenderer>();
		originalFadeValue = decal.Fade;
		IsExisting = true;
		ShouldDestroy = true;
		ShouldStopControl = false;
	}

	public void Recycle()
	{
		timeCounter = 0f;
		decal.Fade = originalFadeValue;
		ShouldStopControl = false;
		otherTransform = null;
		decal.LimitTo = null;
	}

	public void SetExistence(bool isExisting)
	{
		base.enabled = isExisting;
		decal.enabled = isExisting;
		thisMeshRenderer.enabled = isExisting;
		decal.Fade = (isExisting ? originalFadeValue : 0f);
		IsExisting = isExisting;
	}

	private void Update()
	{
		if (otherTransform != null)
		{
			if (!otherTransform.gameObject.activeInHierarchy)
			{
				if (ShouldDestroy)
				{
					Object.Destroy(base.gameObject);
				}
				else
				{
					SetExistence(isExisting: false);
				}
				return;
			}
			base.transform.position = otherTransform.TransformPoint(offsetPos);
			base.transform.rotation = Quaternion.LookRotation(otherTransform.TransformDirection(offsetFwDir), otherTransform.TransformDirection(offsetUpDir));
		}
		if (ShouldStopControl)
		{
			return;
		}
		timeCounter += Time.deltaTime;
		if (!(timeCounter >= lifeTime))
		{
			return;
		}
		decal.Fade = Mathf.Lerp(0f, originalFadeValue, 1f - (timeCounter - lifeTime) / fadeTime);
		if (timeCounter >= lifeTime + fadeTime)
		{
			if (ShouldDestroy)
			{
				Object.Destroy(base.gameObject);
			}
			else
			{
				SetExistence(isExisting: false);
			}
		}
	}

	public void StickToOtherObject(Transform otherTransform, Vector3 offsetPos, Vector3 offsetUpDir, Vector3 offsetFwDir)
	{
		this.otherTransform = otherTransform;
		this.offsetPos = offsetPos;
		this.offsetUpDir = offsetUpDir;
		this.offsetFwDir = offsetFwDir;
		decal.LimitTo = otherTransform.gameObject;
	}
}
