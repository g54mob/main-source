using CritiasFoliage;
using UnityEngine;

public class ExampleRuntimeTreeRemover : MonoBehaviour
{
	private void OnGUI()
	{
		Vector2 vector = Camera.main.ViewportToScreenPoint(new Vector2(0.5f, 0.5f));
		GUI.Label(new Rect(vector.x - 5f, vector.y - 5f, 50f, 50f), "o");
	}

	private void Update()
	{
		if (!Input.GetMouseButtonDown(0))
		{
			return;
		}
		FoliagePainterRuntime getRuntime = Object.FindObjectOfType<FoliagePainter>().GetRuntime;
		if (Physics.Raycast(base.transform.position, base.transform.forward, out var hitInfo, 1000f, LayerMask.GetMask("Default")) && (bool)hitInfo.collider)
		{
			FoliageColliderData component = hitInfo.collider.gameObject.GetComponent<FoliageColliderData>();
			if ((bool)component)
			{
				FoliageInstance foliageInstance = component.m_FoliageInstance;
				getRuntime.RemoveFoliageInstance(component.m_FoliageType, foliageInstance.m_UniqueId, foliageInstance.m_Position);
			}
			component = hitInfo.collider.gameObject.GetComponentInParent<FoliageColliderData>();
			if ((bool)component)
			{
				FoliageInstance foliageInstance2 = component.m_FoliageInstance;
				getRuntime.RemoveFoliageInstance(component.m_FoliageType, foliageInstance2.m_UniqueId, foliageInstance2.m_Position);
			}
		}
	}
}
