using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using UnityEngine;

public class TileObject : MonoBehaviour
{
	private float xPos;

	private float zPos;

	[SerializeField]
	private Animator animator;

	[SerializeField]
	private Transform tileObject;

	[SerializeField]
	private GameObject groundPlane;

	[SerializeField]
	private List<ObjectType> objectTypesThatGetGround;

	private bool builtOn;

	[SerializeField]
	private bool isWater;

	[SerializeField]
	private Material grassMaterial;

	[SerializeField]
	private Material waterMaterial;

	[SerializeField]
	private Renderer tileRenderer;

	[SerializeField]
	private GameObject wave;

	private void Start()
	{
		xPos = base.transform.position.x;
		zPos = base.transform.position.z;
		grassMaterial = tileRenderer.material;
	}

	private void Update()
	{
		base.transform.localPosition = new Vector3(xPos, base.transform.position.y, zPos);
	}

	public void ForceBuiltOnAnimationBeforeFinish()
	{
		base.transform.position = new Vector3(base.transform.position.x, builtOn ? (-1f) : 0f, base.transform.position.z);
	}

	public void PlayBuildOnAnimation(GridObject gridObject)
	{
		builtOn = true;
		base.transform.DOMove(new Vector3(base.transform.position.x, -1f, base.transform.position.z), 0.35f).SetEase(Ease.InOutBounce);
		if (objectTypesThatGetGround.Intersect(gridObject.GetObjectTypes()).Any())
		{
			groundPlane.SetActive(value: true);
		}
	}

	public void PlayDeleteAnimation(List<ObjectType> gridObjectTypes)
	{
		builtOn = false;
		base.transform.DOMove(new Vector3(base.transform.position.x, 0f, base.transform.position.z), 0.35f).SetEase(Ease.InOutBounce);
		if (objectTypesThatGetGround.Intersect(gridObjectTypes).Any())
		{
			groundPlane.SetActive(value: false);
		}
	}

	public void DisableAnimator()
	{
		tileObject.position = new Vector3(base.transform.position.x, -0.5f, base.transform.position.z);
		tileObject.rotation = Quaternion.Euler(0f, 0f, 0f);
		animator.enabled = false;
	}

	public IEnumerator PlayBuildFinishAnimation(int animationToPlay)
	{
		animationToPlay = 0;
		switch (animationToPlay)
		{
		case 0:
			base.transform.DOMove(new Vector3(base.transform.position.x, 3f, base.transform.position.z), 0.35f).SetEase(Ease.InOutBounce);
			base.transform.DORotate(new Vector3(0f, 180f, 0f), 0.5f).SetEase(Ease.InOutBounce);
			yield return new WaitForSeconds(0.25f);
			base.transform.DOMove(new Vector3(base.transform.position.x, -1f, base.transform.position.z), 0.35f).SetEase(Ease.InOutBounce);
			base.transform.DORotate(new Vector3(0f, -360f, 0f), 0.5f).SetEase(Ease.InOutBounce);
			break;
		case 1:
			base.transform.DOMove(new Vector3(base.transform.position.x, -5f, base.transform.position.z), 0.35f).SetEase(Ease.InOutBounce);
			base.transform.DORotate(new Vector3(180f, 0f, 0f), 0.5f).SetEase(Ease.InOutBounce);
			yield return new WaitForSeconds(0.25f);
			base.transform.DOMove(new Vector3(base.transform.position.x, 1f, base.transform.position.z), 0.35f).SetEase(Ease.InOutBounce);
			base.transform.DORotate(new Vector3(-360f, 0f, 0f), 0.5f).SetEase(Ease.InOutBounce);
			break;
		}
		yield return new WaitForSeconds(0.5f);
		base.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
	}

	public void SetTileMaterial(Material material)
	{
		tileObject.GetComponent<Renderer>().material = material;
	}

	public bool IsWater()
	{
		return isWater;
	}

	public void SetWater(bool isWater)
	{
		this.isWater = isWater;
		tileRenderer.material = (isWater ? waterMaterial : grassMaterial);
		wave.SetActive(isWater);
	}
}
