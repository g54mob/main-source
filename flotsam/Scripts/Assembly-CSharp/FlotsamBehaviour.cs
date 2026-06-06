using System.Collections;
using PajamaLlama.Debugs;
using UnityEngine;
using UnityEngine.Events;

public abstract class FlotsamBehaviour : MonoBehaviour
{
	public FlotsamProperties Properties { get; private set; }

	public int VisualPrefabIndex { get; private set; }

	public VisualPrefab VisualPrefab { get; private set; }

	public abstract bool Interactable { get; }

	public bool Pooled { get; private set; }

	public UnityEvent OnSalvage { get; private set; } = new UnityEvent();

	public virtual bool Initialize(FlotsamProperties properties, int visualPrefabIndex = -1)
	{
		if (properties == null)
		{
			Debugger.Error($"No flotsam properties set for {base.gameObject.name}.", this);
			return false;
		}
		Properties = properties;
		VisualPrefabIndex = visualPrefabIndex;
		Pooled = false;
		return true;
	}

	public void InitializeVisual(bool removeCollider = false)
	{
		int num = VisualPrefabIndex;
		int count = Properties.VisualPrefabs.Count;
		if (num < 0 || num <= count)
		{
			num = Random.Range(0, count);
		}
		VisualPrefab = Object.Instantiate(Properties.VisualPrefabs[num]);
		VisualPrefab.transform.SetParent(base.transform, worldPositionStays: true);
		VisualPrefab.transform.localPosition = Vector3.zero;
		VisualPrefab.transform.localRotation = Quaternion.identity;
		VisualPrefab.tag = "FlotsamVisual";
		Collider component = VisualPrefab.GetComponent<Collider>();
		if ((bool)component)
		{
			if (removeCollider)
			{
				Object.Destroy(component);
			}
			else
			{
				component.enabled = true;
			}
		}
		VisualPrefabIndex = num;
	}

	public abstract void InitializeComposition(CompositionInventory composition);

	public virtual void UpdatePositionAndRotation(Vector3 position, Quaternion rotation)
	{
		base.transform.position = position;
		base.transform.rotation = rotation;
	}

	public abstract void Throw(ThrowProperties throwProperties);

	protected IEnumerator ThrowMovementCoroutine(ThrowProperties throwProperties)
	{
		Vector3 startPosition = base.transform.position;
		float timer = 0f;
		base.transform.rotation = throwProperties.Rotation;
		Vector3 target;
		float height;
		if (throwProperties.TargetTransform == null)
		{
			target = throwProperties.TargetPosition;
			height = Vector3.Distance(startPosition, throwProperties.TargetPosition);
		}
		else
		{
			target = throwProperties.TargetTransform.position;
			height = Vector3.Distance(startPosition, throwProperties.TargetTransform.position);
		}
		while (timer < throwProperties.Duration)
		{
			float num = timer / throwProperties.Duration;
			if (throwProperties.TargetTransform != null)
			{
				target = throwProperties.TargetTransform.position;
			}
			height = Mathf.Min(Vector3.Distance(startPosition, target) * 0.49f, height);
			base.transform.position = AnimationTween.SphericalPositionLerp(startPosition, target, num, height);
			if (throwProperties.ScaleUp)
			{
				base.transform.localScale = Mathf.Lerp(throwProperties.MinimumScale, throwProperties.MaximumScale, num) * Vector3.one;
			}
			else
			{
				base.transform.localScale = Mathf.Lerp(throwProperties.MaximumScale, throwProperties.MinimumScale, num) * Vector3.one;
			}
			timer += Time.deltaTime;
			yield return null;
		}
		throwProperties.Dispose();
	}

	public virtual void Activate(Vector3 position)
	{
		base.transform.position = position;
		if ((bool)VisualPrefab)
		{
			VisualPrefab.enabled = true;
		}
		Pooled = false;
	}

	public virtual void Deactivate()
	{
		base.transform.SetParent(FlotsamPool.PooledParent, worldPositionStays: true);
		if ((bool)VisualPrefab)
		{
			VisualPrefab.enabled = false;
		}
		Pooled = true;
	}

	public abstract float ReturnCompositionProgress();
}
