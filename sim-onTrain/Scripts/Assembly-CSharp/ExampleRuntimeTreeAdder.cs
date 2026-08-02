using System.Collections.Generic;
using CritiasFoliage;
using UnityEngine;

public class ExampleRuntimeTreeAdder : MonoBehaviour
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
		List<FoliageTypeRuntime> foliageTypes = getRuntime.GetFoliageTypes();
		FoliageTypeRuntime foliageTypeRuntime = default(FoliageTypeRuntime);
		bool flag = false;
		for (int i = 0; i < foliageTypes.Count; i++)
		{
			if (!foliageTypes[i].m_IsGrassType)
			{
				foliageTypeRuntime = foliageTypes[i];
				flag = true;
			}
		}
		RaycastHit hitInfo;
		if (!flag)
		{
			Debug.LogError("Could not find a tree type! Please add it in the inspector!");
		}
		else if (Physics.Raycast(base.transform.position, base.transform.forward, out hitInfo, 100f, -1) && (bool)hitInfo.collider)
		{
			getRuntime.AddFoliageInstance(instance: new FoliageInstance
			{
				m_Position = hitInfo.point,
				m_Scale = Vector3.one,
				m_Rotation = Quaternion.Euler(0f, Random.Range(0, 360), 0f)
			}, typeHash: foliageTypeRuntime.m_Hash);
		}
	}
}
