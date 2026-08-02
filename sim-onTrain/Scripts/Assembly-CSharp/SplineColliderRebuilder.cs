using System.Collections;
using UnityEngine;
using sc.modeling.splines.runtime;

public class SplineColliderRebuilder : MonoBehaviour
{
	[SerializeField]
	private Transform targetRoot;

	[SerializeField]
	private bool includeInactive = true;

	[SerializeField]
	private bool runOnStart = true;

	[SerializeField]
	[Min(0f)]
	private float startupDelaySeconds = 10f;

	[SerializeField]
	[Min(1f)]
	private int maxRebuildsPerFrame = 2;

	[SerializeField]
	private bool rebuildOnlyWhenMissingMesh = true;

	[SerializeField]
	private bool logResult = true;

	private Coroutine rebuildRoutine;

	private void Start()
	{
		if (runOnStart)
		{
			if (startupDelaySeconds <= 0f)
			{
				RebuildNow();
			}
			else
			{
				StartCoroutine(DelayedRebuild());
			}
		}
	}

	private IEnumerator DelayedRebuild()
	{
		yield return new WaitForSeconds(startupDelaySeconds);
		RebuildNow();
	}

	[ContextMenu("Rebuild Spline Meshers")]
	public void RebuildNow()
	{
		Transform transform = (targetRoot ? targetRoot : base.transform);
		SplineMesher[] componentsInChildren = transform.GetComponentsInChildren<SplineMesher>(includeInactive);
		if (!Application.isPlaying)
		{
			int num = RebuildImmediate(componentsInChildren);
			if (logResult)
			{
				Debug.Log($"[SplineColliderRebuilder] Rebuilt {num}/{componentsInChildren.Length} spline meshers on \"{transform.name}\".", this);
			}
		}
		else
		{
			if (rebuildRoutine != null)
			{
				StopCoroutine(rebuildRoutine);
			}
			rebuildRoutine = StartCoroutine(RebuildGradually(transform, componentsInChildren));
		}
	}

	private int RebuildImmediate(SplineMesher[] meshers)
	{
		int num = 0;
		foreach (SplineMesher splineMesher in meshers)
		{
			if ((bool)splineMesher && (!rebuildOnlyWhenMissingMesh || NeedsRebuild(splineMesher)))
			{
				splineMesher.Rebuild();
				num++;
			}
		}
		return num;
	}

	private IEnumerator RebuildGradually(Transform root, SplineMesher[] meshers)
	{
		int rebuilt = 0;
		int rebuiltThisFrame = 0;
		int budgetPerFrame = Mathf.Max(1, maxRebuildsPerFrame);
		foreach (SplineMesher splineMesher in meshers)
		{
			if ((bool)splineMesher && (!rebuildOnlyWhenMissingMesh || NeedsRebuild(splineMesher)))
			{
				splineMesher.Rebuild();
				rebuilt++;
				rebuiltThisFrame++;
				if (rebuiltThisFrame >= budgetPerFrame)
				{
					rebuiltThisFrame = 0;
					yield return null;
				}
			}
		}
		if (logResult)
		{
			Debug.Log($"[SplineColliderRebuilder] Rebuilt {rebuilt}/{meshers.Length} spline meshers on \"{root.name}\" with budget {budgetPerFrame}/frame.", this);
		}
		rebuildRoutine = null;
	}

	private static bool NeedsRebuild(SplineMesher mesher)
	{
		GameObject gameObject = (mesher.outputObject ? mesher.outputObject : mesher.gameObject);
		Settings.Collision collision = mesher.settings.collision;
		MeshFilter component = gameObject.GetComponent<MeshFilter>();
		bool flag = component != null && component.sharedMesh != null;
		if (collision.enable)
		{
			MeshCollider component2 = gameObject.GetComponent<MeshCollider>();
			if (!(component2 != null) || !(component2.sharedMesh != null))
			{
				return true;
			}
		}
		if ((!collision.enable || !collision.colliderOnly) && !flag)
		{
			return true;
		}
		return false;
	}
}
