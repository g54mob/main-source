using System.Collections;
using UnityEngine;
using UnityEngine.VFX;

public class PooledVFXObject : MonoBehaviour
{
	public string vfxId;

	public float duration = 2f;

	private ParticleSystem ps;

	private VisualEffect vfx;

	private void Awake()
	{
		ps = GetComponent<ParticleSystem>();
		vfx = GetComponent<VisualEffect>();
	}

	private void OnEnable()
	{
		StartCoroutine(CheckIfFinished());
	}

	private IEnumerator CheckIfFinished()
	{
		if (ps != null)
		{
			yield return new WaitUntil(() => !ps.IsAlive());
		}
		else if (vfx != null)
		{
			yield return new WaitForSeconds(duration);
		}
		VFXPooler.Instance.ReturnToPool(vfxId, base.gameObject);
	}
}
