using UnityEngine;

public class FrameGizmoSpawner : FrameGizmo
{
	[SerializeField]
	private Transform _spawned;

	public override void OnClickGizmo(float progress)
	{
		Spawn();
	}

	public override void OnStartGizmo()
	{
		Spawn();
	}

	public void Spawn()
	{
		Object.Instantiate(_spawned.gameObject, base.transform).SetActive(value: true);
	}
}
