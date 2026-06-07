using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

[RequireComponent(typeof(LineRenderer))]
[ExecuteInEditMode]
public class CableProcedural : MonoBehaviour
{
	public const string CONNECTOR_NAME = "[CableMaker connector]";

	public Transform connectTo;

	[Tooltip("Final line will have much less segments, depending on simplification tolerance")]
	public float segmentsPerMeter = 5f;

	public float simplificationTolerance = 0.02f;

	public float sag = 1f;

	private void Reset()
	{
		LineRenderer component = GetComponent<LineRenderer>();
		component.shadowCastingMode = ShadowCastingMode.Off;
		component.useWorldSpace = false;
	}

	private void Update()
	{
		UpdateCable();
	}

	private void OnValidate()
	{
		segmentsPerMeter = Mathf.Clamp(segmentsPerMeter, 0f, 100f);
		sag = Mathf.Max(0f, sag);
	}

	private void UpdateCable()
	{
		if (Validate().Count == 0)
		{
			Vector3 vector = connectTo.position - base.transform.position;
			Vector3 vector2 = Physics.gravity.normalized * sag;
			LineRenderer component = GetComponent<LineRenderer>();
			component.positionCount = Mathf.Max(2, Mathf.CeilToInt(vector.magnitude * segmentsPerMeter));
			for (int i = 0; i < component.positionCount; i++)
			{
				float num = (float)i / (float)(component.positionCount - 1);
				float num2 = Mathf.Sin(num * (float)Math.PI);
				Vector3 position = base.transform.InverseTransformPoint(base.transform.position + vector * num + vector2 * num2);
				component.SetPosition(i, position);
			}
			component.Simplify(simplificationTolerance);
		}
	}

	private List<(string msg, UnityEngine.Object context)> Validate()
	{
		List<(string, UnityEngine.Object)> list = new List<(string, UnityEngine.Object)>();
		if (connectTo == null)
		{
			list.Add(("connectTo transform is not assigned", this));
		}
		else if (connectTo == base.transform)
		{
			list.Add(("connectTo can't be the same object", this));
		}
		if (GetComponent<LineRenderer>() == null)
		{
			list.Add(("must have a LineRenderer component", this));
		}
		return list;
	}

	public static void Nuke()
	{
		CableProcedural[] array = UnityEngine.Object.FindObjectsOfType<CableProcedural>();
		foreach (CableProcedural cableProcedural in array)
		{
			cableProcedural.transform.SetParent(cableProcedural.transform.parent.parent, worldPositionStays: true);
			UnityEngine.Object.DestroyImmediate(cableProcedural);
		}
		Transform[] array2 = UnityEngine.Object.FindObjectsOfType<Transform>();
		foreach (Transform transform in array2)
		{
			if (transform.name.Contains("[CableMaker connector]"))
			{
				transform.gameObject.SetActive(value: false);
			}
		}
	}
}
