using UnityEngine;

[ExecuteInEditMode]
public class WalkwayPusher : MonoBehaviour
{
	public enum Kind
	{
		Static = 0,
		Dynamic = 1
	}

	public enum Hull
	{
		Concave = 0,
		Convex = 1
	}

	public Kind kind;

	public Hull hull;

	[WalkwayBuilt]
	public WalkwayPhysical physical;

	private void OnEnable()
	{
		if (physical != null)
		{
			physical.gameObject.SetActive(true);
			ApplyToPhysical();
		}
	}

	private void OnDisable()
	{
		if (physical != null)
		{
			physical.gameObject.SetActive(false);
		}
	}

	private void Update()
	{
		if (physical != null && kind == Kind.Dynamic)
		{
			ApplyToPhysical();
		}
	}

	public void ApplyToPhysical()
	{
		if (Application.isPlaying)
		{
			physical.MoveTo(base.transform.position.ToVector2XZ(), base.transform.rotation.eulerAngles.y);
		}
		else
		{
			physical.WarpTo(base.transform.position, base.transform.rotation.eulerAngles.y);
		}
	}
}
