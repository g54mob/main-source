using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine;

public class ChainLightning : MonoBehaviour
{
	public LineRenderer lineRenderer;

	public void Set(List<Vector3> positions)
	{
		GameObject gameObject = base.gameObject;
		gameObject.SetActive(value: true);
		LineRenderer obj = lineRenderer;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [positions @ rdx (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
		obj.positionCount = 0;
		Vector3[] positions2 = positions.ToArray();
		lineRenderer.SetPositions(positions2);
		Invoke("DisableSelf", 0.18f);
	}

	private void DisableSelf()
	{
		GameObject gameObject = base.gameObject;
		gameObject.SetActive(value: false);
	}
}
