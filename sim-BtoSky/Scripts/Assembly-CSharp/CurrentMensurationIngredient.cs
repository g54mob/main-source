using System.Collections.Generic;
using UnityEngine;

public class CurrentMensurationIngredient : MonoBehaviour
{
	public bool isHandled;

	public bool isPouring;

	private Vector3 genPos;

	private float targetZ = -60f;

	private GameObject pourEffect;

	private GameObject pourObject;

	public ParticleSystem ps;

	public int itemIndex;

	public bool isMensuration;

	public float spawnRate = 5f;

	private float timer;

	private Transform pourEffectPos;

	private List<GameObject> pourObjects;

	private Color castingColor = Color.white;

	private void Start()
	{
		isHandled = false;
		isPouring = false;
		genPos = base.transform.position;
		MotorIngredientItem component = GetComponent<MotorIngredientItem>();
		pourEffectPos = component.pourEffectPos;
		if (component.pourEffect != null)
		{
			pourEffect = Object.Instantiate(component.pourEffect, pourEffectPos);
			ps = pourEffect.GetComponent<ParticleSystem>();
			_ = castingColor;
			ParticleSystem.MainModule main = ps.main;
			main.startColor = castingColor;
		}
		else
		{
			pourObject = component.pourObject;
			spawnRate = component.spawnRate;
		}
		if (ps != null)
		{
			ps.Stop();
		}
		pourObjects = new List<GameObject>();
	}

	private void Update()
	{
		if (!isHandled && Vector3.Magnitude(base.transform.position - genPos) > 0.01f)
		{
			base.transform.position = Vector3.Lerp(base.transform.position, genPos, Time.deltaTime * 5f);
		}
		if (isPouring)
		{
			float z = Mathf.LerpAngle(base.transform.eulerAngles.z, targetZ, Time.deltaTime * 4f);
			base.transform.rotation = Quaternion.Euler(base.transform.eulerAngles.x, base.transform.eulerAngles.y, z);
		}
		else
		{
			float z2 = base.transform.eulerAngles.z;
			if (z2 > 0.01f)
			{
				float z3 = Mathf.LerpAngle(z2, 0f, Time.deltaTime * 5f);
				base.transform.rotation = Quaternion.Euler(base.transform.eulerAngles.x, base.transform.eulerAngles.y, z3);
			}
		}
		float num = base.transform.eulerAngles.z;
		if (num > 180f)
		{
			num -= 360f;
		}
		if (num < -40f)
		{
			RaycastHit hitInfo2;
			CurrentCraftingRocketGrain component2;
			if (isMensuration)
			{
				if (Physics.Raycast(new Ray(pourEffectPos.position, Vector3.down), out var hitInfo, 1f, LayerMask.GetMask("Stackable")) && hitInfo.transform.TryGetComponent<MensurationScale>(out var component) && pourObject == null)
				{
					component.PowderOnScale(itemIndex);
				}
			}
			else if (Physics.Raycast(new Ray(pourEffectPos.position, Vector3.down), out hitInfo2, 1f, LayerMask.GetMask("Interactable")) && hitInfo2.transform.TryGetComponent<CurrentCraftingRocketGrain>(out component2))
			{
				component2.PowderOnMold();
			}
		}
		if (num < -20f)
		{
			if (ps != null)
			{
				if (!ps.isPlaying)
				{
					ps.Play();
				}
				if (!AudioManager.S.CheckCookingSFXPlaying())
				{
					AudioManager.S.PlayCookingSFX(AudioManager.S.powderPour, 0.5f);
				}
			}
			if (pourObject != null)
			{
				timer += Time.deltaTime;
				float num2 = 1f / spawnRate;
				while (timer >= num2)
				{
					GameObject gameObject = Object.Instantiate(pourObject, pourEffectPos.position, Quaternion.identity);
					pourObjects.Add(gameObject);
					gameObject.GetComponent<MensurationObject>().index = itemIndex;
					timer -= num2;
				}
			}
		}
		else if (ps != null)
		{
			if (ps.isPlaying)
			{
				ps.Stop();
			}
			AudioManager.S.StopCookingSFX();
		}
	}

	private void OnDestroy()
	{
		foreach (GameObject pourObject in pourObjects)
		{
			Object.Destroy(pourObject);
		}
		AudioManager.S.StopCookingSFX();
	}

	public void SetCastingColor(Color colr)
	{
		castingColor = colr;
	}
}
