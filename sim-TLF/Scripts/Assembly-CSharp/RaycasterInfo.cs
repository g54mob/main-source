using System;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Raycast Info/Info", fileName = "New Raycast Info")]
public class RaycasterInfo : ScriptableObject
{
	public LayerMask LayerMask;

	public float Distance;

	public RaycastHit Hit;

	[Tooltip("Якщо увімкнено — промінь також потрапляє в тригер-колайдери. Якщо вимкнено — тригери ігноруються.")]
	public bool HitTriggers;

	[Tooltip("Шари, що завжди блокують промінь (стіни, земля, структури), навіть якщо їх немає в LayerMask. Якщо порожньо — використовується стандартний набір: Default, World, Ground, Vehicle, VehicleCoverParts.")]
	public LayerMask ObstructionLayerMask;

	[Tooltip("Якщо true — обструкція стінами/землею взагалі НЕ перевіряється. Для UI-/Inventory-променів, де геометрія світу не повинна впливати на UI-хіти.")]
	public bool DisableObstructionCheck;

	private static readonly RaycastHit[] _castBuffer = new RaycastHit[32];

	private static int _defaultObstructionMask = -1;

	[NonSerialized]
	private bool _hasLayerMaskOverride;

	[NonSerialized]
	private LayerMask _layerMaskOverride;

	private static int DefaultObstructionMask
	{
		get
		{
			if (_defaultObstructionMask == -1)
			{
				_defaultObstructionMask = LayerMask.GetMask("Default", "World", "Ground", "Vehicle", "VehicleCoverParts");
			}
			return _defaultObstructionMask;
		}
	}

	private int EffectiveObstructionMask
	{
		get
		{
			if (ObstructionLayerMask.value == 0)
			{
				return DefaultObstructionMask;
			}
			return ObstructionLayerMask.value;
		}
	}

	private QueryTriggerInteraction TriggerInteraction
	{
		get
		{
			if (!HitTriggers)
			{
				return QueryTriggerInteraction.Ignore;
			}
			return QueryTriggerInteraction.Collide;
		}
	}

	public bool HasLayerMaskOverride => _hasLayerMaskOverride;

	private int EffectiveLayerMask
	{
		get
		{
			if (!_hasLayerMaskOverride)
			{
				return LayerMask.value;
			}
			return _layerMaskOverride.value;
		}
	}

	public void OverrideLayerMask(LayerMask mask)
	{
		_hasLayerMaskOverride = true;
		_layerMaskOverride = mask;
	}

	public void ClearLayerMaskOverride()
	{
		_hasLayerMaskOverride = false;
	}

	public void ShootRay(Camera camera)
	{
		Vector3 pos = new Vector3((float)Screen.width / 2f, (float)Screen.height / 2f, 0f);
		Cast(camera.ScreenPointToRay(pos));
	}

	public void ShootRayToMousePosition(Camera camera)
	{
		Vector3 mousePosition = Input.mousePosition;
		Cast(camera.ScreenPointToRay(mousePosition));
	}

	private void Cast(Ray ray)
	{
		RaycastHit hitInfo;
		if (!TryGetNearestRelevantHit(ray, out var hit))
		{
			Hit = default(RaycastHit);
		}
		else if (!DisableObstructionCheck && Physics.Raycast(ray, out hitInfo, hit.distance, EffectiveObstructionMask, QueryTriggerInteraction.Ignore) && hitInfo.collider != hit.collider && hitInfo.distance + 0.001f < hit.distance)
		{
			Hit = default(RaycastHit);
		}
		else
		{
			Hit = hit;
		}
	}

	private bool TryGetNearestRelevantHit(Ray ray, out RaycastHit hit)
	{
		int num = Physics.RaycastNonAlloc(ray, _castBuffer, Distance, EffectiveLayerMask, TriggerInteraction);
		hit = default(RaycastHit);
		bool flag = false;
		for (int i = 0; i < num; i++)
		{
			RaycastHit raycastHit = _castBuffer[i];
			if (!IsRaycastIgnored(raycastHit.collider) && (!flag || raycastHit.distance < hit.distance))
			{
				hit = raycastHit;
				flag = true;
			}
		}
		return flag;
	}

	private static bool IsRaycastIgnored(Collider collider)
	{
		if (collider != null)
		{
			return collider.GetComponentInParent<RaycastIgnore>() != null;
		}
		return false;
	}

	public void ShootRayFromRenderTexture(Camera camera, RawImage renderImage, RawImage limiter)
	{
		if (RectTransformUtility.RectangleContainsScreenPoint(limiter.rectTransform, Input.mousePosition, null) && RectTransformUtility.ScreenPointToLocalPointInRectangle(renderImage.rectTransform, Input.mousePosition, null, out var localPoint))
		{
			float x = Mathf.InverseLerp((0f - renderImage.rectTransform.rect.width) / 2f, renderImage.rectTransform.rect.width / 2f, localPoint.x);
			float y = Mathf.InverseLerp((0f - renderImage.rectTransform.rect.height) / 2f, renderImage.rectTransform.rect.height / 2f, localPoint.y);
			Vector3 pos = new Vector3(x, y, 0f);
			Ray ray = camera.ViewportPointToRay(pos);
			Cast(ray);
		}
	}
}
