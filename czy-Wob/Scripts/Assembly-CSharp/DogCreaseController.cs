using UnityEngine;

public class DogCreaseController : MonoBehaviour
{
	private enum CreaseType
	{
		TOP = 0,
		BOTTOM = 1,
		LEFT = 2,
		RIGHT = 3
	}

	public Texture topCreaseMap;

	public Texture botCreaseMap;

	public Texture leftCreaseMap;

	public Texture rightCreaseMap;

	private float capCreaseMaxVal = 1f;

	private float capAngleMin = 5f;

	private float capAngleMax = 50f;

	private float sideCreaseMaxVal = 1f;

	private float sideAngleMin = 5f;

	private float sideAngleMax = 75f;

	private float currentCapCreaseValue;

	private float currentSideCreaseValue;

	private CreaseType capCreaseType;

	private CreaseType sideCreaseType;

	private Transform frontTransform;

	private Transform backTransform;

	private Material skinMat;

	private void Awake()
	{
		frontTransform = GetComponent<LegController>().bodyFront.transform;
		backTransform = GetComponent<LegController>().bodyBack.transform;
	}

	private void Update()
	{
		if (skinMat == null)
		{
			FindSkinMat();
		}
		if (skinMat != null)
		{
			UpdateCapCreases();
			UpdateSideCreases();
		}
	}

	private void FindSkinMat()
	{
		if (!(topCreaseMap == null))
		{
			skinMat = GetComponent<DogLooks>().GetBodyMainMaterial();
			if (!(skinMat == null))
			{
				skinMat.SetTexture("_BumpMap", topCreaseMap);
				skinMat.SetTexture("_DetailNormalMap", leftCreaseMap);
				capCreaseType = CreaseType.TOP;
				sideCreaseType = CreaseType.LEFT;
				SetCapCreaseValue(0f, forceValue: true);
				SetSideCreaseValue(0f, forceValue: true);
				skinMat.EnableKeyword("_NORMALMAP");
				skinMat.EnableKeyword("_DETAIL_MULX2");
			}
		}
	}

	private void SetCapCreaseValue(float newVal, bool forceValue = false)
	{
		if (newVal != currentCapCreaseValue || forceValue)
		{
			currentCapCreaseValue = newVal;
			skinMat.SetFloat("_BumpScale", newVal);
		}
	}

	private void SetSideCreaseValue(float newVal, bool forceValue = false)
	{
		if (newVal != currentSideCreaseValue || forceValue)
		{
			currentSideCreaseValue = newVal;
			skinMat.SetFloat("_DetailNormalMapScale", newVal);
		}
	}

	private void UpdateCapCreases()
	{
		float num = Mathf.Min(Vector3.Angle(frontTransform.up, backTransform.up), capAngleMax);
		Vector3 vector = Vector3.Cross(frontTransform.up, backTransform.up);
		float num2 = vector.x * frontTransform.forward.x + vector.y * frontTransform.forward.y + vector.z * frontTransform.forward.z;
		if (num < capAngleMin)
		{
			SetCapCreaseValue(0f);
			return;
		}
		if (num2 < 0f && capCreaseType == CreaseType.TOP)
		{
			capCreaseType = CreaseType.BOTTOM;
			skinMat.SetTexture("_BumpMap", botCreaseMap);
		}
		else if (num2 > 0f && capCreaseType == CreaseType.BOTTOM)
		{
			capCreaseType = CreaseType.TOP;
			skinMat.SetTexture("_BumpMap", topCreaseMap);
		}
		float newVal = (num - capAngleMin) / (capAngleMax - capAngleMin) * capCreaseMaxVal;
		SetCapCreaseValue(newVal);
	}

	private void UpdateSideCreases()
	{
		float num = Mathf.Min(Vector3.Angle(frontTransform.forward, backTransform.forward), sideAngleMax);
		Vector3 vector = Vector3.Cross(frontTransform.forward, backTransform.forward);
		float num2 = vector.x * frontTransform.up.x + vector.y * frontTransform.up.y + vector.z * frontTransform.up.z;
		if (num < sideAngleMin)
		{
			SetSideCreaseValue(0f);
			return;
		}
		if (num2 < 0f && sideCreaseType == CreaseType.LEFT)
		{
			sideCreaseType = CreaseType.RIGHT;
			skinMat.SetTexture("_DetailNormalMap", rightCreaseMap);
		}
		else if (num2 > 0f && sideCreaseType == CreaseType.RIGHT)
		{
			sideCreaseType = CreaseType.LEFT;
			skinMat.SetTexture("_DetailNormalMap", leftCreaseMap);
		}
		float newVal = (num - sideAngleMin) / (sideAngleMax - sideAngleMin) * sideCreaseMaxVal;
		SetSideCreaseValue(newVal);
	}
}
