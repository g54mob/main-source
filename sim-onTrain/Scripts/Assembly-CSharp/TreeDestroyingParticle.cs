using DG.Tweening;
using UnityEngine;

public class TreeDestroyingParticle : MonoBehaviour
{
	[SerializeField]
	private Renderer[] woods;

	private void Start()
	{
		Renderer[] array = woods;
		foreach (Renderer obj in array)
		{
			obj.transform.eulerAngles = new Vector3(Random.Range(0f, 25f), Random.Range(0f, 25f), Random.Range(0f, 25f));
			obj.transform.localScale = Vector3.one * Random.Range(0.35f, 0.5f);
			obj.GetComponent<Rigidbody>().AddTorque(new Vector3(Random.Range(-3f, 3f), Random.Range(-3f, 3f), Random.Range(-3f, 3f)));
			obj.GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f)));
		}
		DOVirtual.DelayedCall(1f, FadeOutMaterials).SetTarget(this);
	}

	private void OnDestroy()
	{
		DOTween.Kill(this);
	}

	private void SetMaterials()
	{
		woods = GetComponentsInChildren<Renderer>();
	}

	private void FadeOutMaterials()
	{
		MaterialPropertyBlock propertyBlock = new MaterialPropertyBlock();
		Renderer[] array = woods;
		foreach (Renderer renderer in array)
		{
			renderer.GetPropertyBlock(propertyBlock);
			Color currentColor = propertyBlock.GetColor("_BaseColor");
			if (currentColor.a == 0f)
			{
				currentColor = Color.white;
			}
			DOTween.To(() => currentColor.a, delegate(float x)
			{
				currentColor.a = x;
			}, 0f, 0.4f).SetEase(Ease.InSine).SetTarget(this)
				.OnUpdate(delegate
				{
					propertyBlock.SetColor("_BaseColor", currentColor);
					renderer.SetPropertyBlock(propertyBlock);
				});
		}
	}
}
