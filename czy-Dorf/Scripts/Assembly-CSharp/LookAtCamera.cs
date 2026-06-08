using UnityEngine;
using UnityEngine.Serialization;

public class LookAtCamera : MonoBehaviour, ITileStateReceiver
{
	public bool onlyRotateY;

	[SerializeField]
	[FormerlySerializedAs("lerrrpStep")]
	private float lerpStep = 1f;

	[SerializeField]
	private bool alignWithCameraForward;

	private Camera mainCamera;

	private Camera uiCamera;

	private Camera targetCamera;

	private void Start()
	{
		mainCamera = OverwritingSingleton<IngameUi>.Instance.mainCamera;
		uiCamera = OverwritingSingleton<IngameUi>.Instance.uiCamera;
		SetRendererLayer(base.gameObject.layer);
	}

	private void Update()
	{
		if ((bool)targetCamera)
		{
			Quaternion quaternion = (alignWithCameraForward ? ((!onlyRotateY) ? Quaternion.LookRotation(targetCamera.transform.forward) : Quaternion.LookRotation(Vector3.ProjectOnPlane(targetCamera.transform.forward, base.transform.parent.up).normalized)) : ((!onlyRotateY) ? Quaternion.LookRotation((base.transform.position - targetCamera.transform.position).normalized) : Quaternion.LookRotation(Vector3.ProjectOnPlane(base.transform.position - targetCamera.transform.position, Vector3.up).normalized)));
			if (lerpStep < 1f)
			{
				base.transform.rotation = Quaternion.Lerp(base.transform.rotation, quaternion, lerpStep);
			}
			else
			{
				base.transform.rotation = quaternion;
			}
		}
	}

	public void ChangeTileState(TileState targetState)
	{
	}

	public void SetRendererLayer(int targetLayer)
	{
		if (targetLayer == LayerMask.NameToLayer("TileStack"))
		{
			targetCamera = uiCamera;
			alignWithCameraForward = true;
		}
		else
		{
			targetCamera = mainCamera;
			alignWithCameraForward = false;
		}
	}

	public void SetAnimationsRunning(bool animationsRunning)
	{
	}

	public void SetTileReference(Tile tile)
	{
	}
}
