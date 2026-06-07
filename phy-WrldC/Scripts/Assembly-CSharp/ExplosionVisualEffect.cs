using UnityEngine;

public class ExplosionVisualEffect : VisualEffectBase
{
	[SerializeField]
	private GameObject explosionDecalPrefab;

	[SerializeField]
	private GameObject explosionDirtPrefab;

	private IExplosiveObject explosiveObject;

	protected override void Initialize()
	{
		explosiveObject = GetComponent<IExplosiveObject>();
		explosiveObject.OnExplosionEvent += OnExplosionHandler;
	}

	private void OnExplosionHandler()
	{
		Vector3 position = base.transform.position;
		Collider[] array = Physics.OverlapSphere(position, 2f);
		int num = 0;
		float num2 = float.MaxValue;
		for (int i = 0; i < array.Length; i++)
		{
			if (!IsInvalidCollider(array[i]))
			{
				Vector3 item = GetDecalPosition(array[i], position).position;
				float num3 = Vector3.Distance(position, item);
				if (num3 < num2)
				{
					num2 = num3;
					num = i;
				}
			}
		}
		for (int j = 0; j < array.Length; j++)
		{
			if (!IsInvalidCollider(array[j]))
			{
				(Vector3 position, Vector3 normal) decalPosition = GetDecalPosition(array[j], position);
				Vector3 item2 = decalPosition.position;
				Vector3 item3 = decalPosition.normal;
				GameObject gameObject = ((num != j) ? VisualEffectsManager.Instance.GetDecalInstance(explosionDirtPrefab) : VisualEffectsManager.Instance.GetDecalInstance(explosionDecalPrefab));
				gameObject.transform.position = item2;
				gameObject.transform.rotation = Quaternion.LookRotation(gameObject.transform.forward, item3);
				gameObject.transform.Rotate(Vector3.up, Random.Range(0, 360), Space.Self);
			}
		}
	}

	private (Vector3 position, Vector3 normal) GetDecalPosition(Collider collider, Vector3 explosionPosition)
	{
		Vector3 vector = Vector3.zero;
		Vector3 item = Vector3.zero;
		if (collider is MeshCollider && !(collider as MeshCollider).convex)
		{
			Vector3[] array = new Vector3[6]
			{
				-base.transform.up,
				base.transform.forward,
				-base.transform.forward,
				base.transform.right,
				-base.transform.right,
				base.transform.up
			};
			for (int i = 0; i < array.Length; i++)
			{
				if (Physics.Raycast(base.transform.position, array[i], out var hitInfo, 2.5f) && !(hitInfo.collider != collider))
				{
					vector = hitInfo.point;
					item = hitInfo.normal;
					break;
				}
			}
		}
		else
		{
			vector = collider.ClosestPoint(base.transform.position);
			item = (explosionPosition - vector).normalized;
		}
		return (position: vector, normal: item);
	}

	private bool IsInvalidCollider(Collider collider)
	{
		if (!(base.gameObject == collider.gameObject))
		{
			return collider.GetComponentInParent<Rigidbody>() != null;
		}
		return true;
	}

	public override void SetVisualEffectsByGameStyleData(GameStylesData gameStylesData)
	{
		base.SetVisualEffectsByGameStyleData(gameStylesData);
		if (gameStylesData.visualEffectStylesData.explosionDecalPrefab != null)
		{
			explosionDecalPrefab = gameStylesData.visualEffectStylesData.explosionDecalPrefab;
		}
		if (gameStylesData.visualEffectStylesData.explosionDirtDecalPrefab != null)
		{
			explosionDirtPrefab = gameStylesData.visualEffectStylesData.explosionDirtDecalPrefab;
		}
	}
}
